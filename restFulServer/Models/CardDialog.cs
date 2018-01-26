using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restFulServer.Models
{
    public class CardDialog
    {
        public string type { get; set; }
        public List<HeroCard> herocards { get; set; }
    }
}