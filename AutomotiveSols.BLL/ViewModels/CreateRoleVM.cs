using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutomotiveSols.BLL.ViewModels
{
    public class CreateRoleVM
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }

    }
}
