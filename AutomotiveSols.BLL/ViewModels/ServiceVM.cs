using AutomotiveSols.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace AutomotiveSols.BLL.ViewModels
{
   public  class ServiceVM
    {
        public Services Services { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }


    }
}
