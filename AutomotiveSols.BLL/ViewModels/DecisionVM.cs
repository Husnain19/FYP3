using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutomotiveSols.BLL.ViewModels
{
    public class DecisionVM
    {
        [Display(Name = "Allow Us To Sale For You")]

        public bool SaleOwn { get; set; }

        [Display(Name = "I will Manage On My Own")]

        public bool SaleUs { get; set; }
    }
}
