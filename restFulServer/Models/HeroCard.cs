using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restFulServer.Models
{
    public class HeroCard
    {
        public string type { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string text { get; set; }
        public string media_url { get; set; }
        public List<Button> buttons { get; set; }
    }
}