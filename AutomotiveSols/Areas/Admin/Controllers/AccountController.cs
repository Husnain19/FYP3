using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomotiveSols.BLL.Models;
using AutomotiveSols.BLL.ViewModels;
using AutomotiveSols.EmailServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutomotiveSols.Data;

namespace AutomotiveSols.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _db;
        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager,
            IEmailSender emailSender,
            ApplicationDbContext db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            _emailSender = emailSender;
            _db = db;
        }
        [HttpGet]

        public IActionResult Register()
        {
            ViewBag.ShowroomList = new SelectList(_db.Showrooms.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            ViewBag.ShowroomList = new SelectList(_db.Showrooms.ToList(), "Id", "Name");

            if (ModelState.IsValid)
            {
                // Map data from RegisterViewModel to IdentityUser
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    StreetAddress = model.StreetAddress,
                    State = model.State,
                    PostalCode = model.PostalCode,
                    ShowroomId = model.ShowroomId
                };

                // Store the user in AspNetUsers database table
                var result = await userManager.CreateAsync(user, model.Password);

                Random r = new Random();
                int num = r.Next();

                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);

                    var callbackUrl = Url.Action(nameof(ConfirmEmail), "Account",
                    new {  userId = user.Id, token =  code }, protocol: HttpContext.Request.Scheme);
                    await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                       $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a> {num.ToString()}");

                    TempData["Message"] = "Confirmation Email has been send to your email. Please check email.";
                    TempData["MessageValue"] = "1";

                    if (signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListUsers", "Account");
                    }

                    ViewBag.ErrorTitle = "Registration successful";
                    ViewBag.ErrorMessage = "Before you can Login, please confirm your " +
                            "email, by clicking on the confirmation link we have emailed you";
                    return View("Error");

                   // await signInManager.SignInAsync(user, isPersistent: false);
                    //return RedirectToAction("index", "home","customer");
                  //  return RedirectToAction("index", "home", new { area = "customer" });

                }

                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("index", "home", new { area = "customer" });
            }

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"The User ID {userId} is invalid";
                return View("NotFound");
            }

            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View();
            }

            ViewBag.ErrorTitle = "Email cannot be confirmed";
            return View("Error");
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home", new { area = "customer" });
        }

        [HttpGet]

        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model, string returnUrl)
        {
            //model.ExternalLogins =(await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null && !user.EmailConfirmed &&
                   (await userManager.CheckPasswordAsync(user, model.Password)))
                {
                    ModelState.AddModelError(string.Empty, "Email not confirmed yet");
                    return View(model);
                }

                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "home", new { area = "customer" });
                    }

                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }
        //Get method for the Create Role 
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleVM model)
        {
            if (ModelState.IsValid)
            {
                // We just need to specify a unique role name to create a new role
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                // Saves the role in the underlying AspNetRoles table
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Account", new { area = "Admin" });
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        //Get The Roles Present In Database
        [HttpGet]
        public IActionResult ListRoles()
        {
            //Roles Property will have the Names of the Roles
            var roles = roleManager.Roles;
            return View(roles);
        }


        // Id is passed from the Url to the Action method to get the Role details
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            // Find the role by Role ID
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new EditRoleVM
            {
                Id = role.Id,
                RoleName = role.Name
            };

            // Retrieve all the Users
            foreach (var user in userManager.Users)
            {
                // If the user is in this role, add the username to
                // Users property of EditRoleViewModel. This model
                // object is then passed to the view for display
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }

        // This action responds to HttpPost and receives EditRoleViewModel
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleVM model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;

                // Update the Role using UpdateAsync
                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;
            //find the role by built in method , by passing the roleId
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)//if the role not present display the error
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} is not present";
                return View("NotFound");
            }

            var model = new List<UserRoleVM>();
            //retrive the users present in that role
            foreach (var user in userManager.Users)
            {
                var userRoleViewModel = new UserRoleVM
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };
                //if the user is present then check the checkboxes
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else // otherwise not
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleVM> model, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId); //find the role

            if (role == null) // if not present then redirect back
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} is not present";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                // if the checkbox is selected and the user does not have that role in db
                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    // add the user
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }//if the checkbox is unchecked and the user has that role
                else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    // delete the user from that role
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleId });
                }
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }
        [HttpGet]  // The Action method to get all the users
        public IActionResult ListUsers()
        {      //Users propertu Contains the users
            var users = userManager.Users;
            return View(users); //returns the users
        }


        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            ViewBag.ShowroomList = new SelectList(_db.Showrooms.ToList(), "Id", "Name");
            var user = await userManager.FindByIdAsync(id);//find the user

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} is not found";
                return View("NotFound");
            }

            // GetClaimsAsync  will retunrs all the list of user Claims
            var userClaims = await userManager.GetClaimsAsync(user);
            // GetRolesAsync will returns all the list of user Roles
            var userRoles = await userManager.GetRolesAsync(user);

            var model = new EditUserVM // populate the data
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                City = user.City,
                Claims = userClaims.Select(c => c.Value).ToList(),
                Roles = userRoles
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserVM model)
        {
            ViewBag.ShowroomList = new SelectList(_db.Showrooms.ToList(), "Id", "Name");
            var user = await userManager.FindByIdAsync(model.Id); //find the user

            if (user == null) //if the user is not present then returns
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} is not found";
                return View("NotFound");
            } //else map the properties
            else
            {
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.City = model.City;

                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded) // if the model is updated the redirect 
                {
                    return RedirectToAction("ListUsers");
                }
                //else show the errors
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }


        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);// find the user 

            if (user == null)// if not not found then return
            {
                ViewBag.ErrorMessage = $"User with Id = {id} is not found";
                return View("NotFound");
            }
            else // if the user found
            {
                var result = await userManager.DeleteAsync(user); // del the user

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListUsers");
            }

          


        }
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} is not found";
                return View("NotFound");
            }
            else
            {
                try
                {
                    //throw new Exception("Test Exception");

                    var result = await roleManager.DeleteAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListRoles");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View("ListRoles");
                }
                // If the exception is DbUpdateException, we know we are not able to
                // delete the role as there are users in the role being deleted
                catch (DbUpdateException ex)
                {
                    //Log the exception to a file. We discussed logging to a file
                    // using Nlog in Part 63 of ASP.NET Core tutorial
                    // logger.LogError($"Exception Occured : {ex}");
                    // Pass the ErrorTitle and ErrorMessage that you want to show to
                    // the user using ViewBag. The Error view retrieves this data
                    // from the ViewBag and displays to the user.
                    ViewBag.ErrorTitle = $"{role.Name} role is in use";
                    ViewBag.ErrorMessage = $"{role.Name} role cannot be deleted as there are users in this role. If you want to delete this role, please remove the users from the role and then try to delete";
                    return View("Error");

                }
            }
        }
            [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}