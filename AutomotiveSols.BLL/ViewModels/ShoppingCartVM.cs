using AutomotiveSols.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveSols.BLL.ViewModels
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCart> ListCart { get; set; }
        public OrderHeader OrderHeader { get; set; }
    }
}
