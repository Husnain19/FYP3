﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveSols.BLL.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Car> Cars { get; set; }

    }
}
