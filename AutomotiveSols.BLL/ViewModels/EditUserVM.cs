using AutomotiveSols.BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutomotiveSols.BLL.ViewModels
{
   public class EditUserVM
    {
        public EditUserVM()
        {
            Claims = new List<string>();
            Roles = new List<string>();

        }
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string City { get; set; }
        public int? ShowroomId { get; set; }


        public Showroom Showroom { get; set; }

        public List<string> Claims { get; set; }

        public IList<string> Roles { get; set; }

    }
}
