using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreeNodeMVC.Models
{
    public class Child
    {
        public string id { get; set; }
        public string text { get; set; }
        public IEnumerable<Child> children { get; set; }
    }
}