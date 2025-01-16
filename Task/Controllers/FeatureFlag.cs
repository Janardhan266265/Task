using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task.Controllers
{
    public class FeatureFlag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public string Domain { get; set; }
    }
}