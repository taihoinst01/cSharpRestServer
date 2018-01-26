using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restFulServer.Models
{
    public class MediaDialog
    {
        public string type { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public string media_url { get; set; }
        public List<Button> buttons { get; set; }

    }
}