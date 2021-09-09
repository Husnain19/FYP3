using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveSols.BLL.Models
{
    public class PartGallery
    {
        public int Id { get; set; }
        public int AutoPartId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }

        public AutoPart AutoPart { get; set; }



    }
}
