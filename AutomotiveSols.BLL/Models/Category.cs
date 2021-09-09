using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveSols.BLL.Models
{
   public  class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int  DisplayOrder { get; set; }

        public List<SubCategory> SubCategories { get; set; }

        public List<AutoPart> AutoParts { get; set; }
    }
}
