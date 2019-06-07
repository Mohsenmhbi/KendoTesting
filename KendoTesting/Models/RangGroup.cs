using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoTesting.Models
{
    public class RangGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Product1> Product1s { get; set; }

    }
}