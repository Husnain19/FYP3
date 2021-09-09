
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutomotiveSols.BLL.ViewModels
{
    public class EditRoleVM
    {
        public EditRoleVM()
        {

            Users = new List<string>();
        }
        public string Id { get; set; }

        [Required(ErrorMessage = "Role Name is Required")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }

    }

}
