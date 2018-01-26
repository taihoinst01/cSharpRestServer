using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restFulServer.Models
{
    public class ResTextDialog
    {
        public string conversationId { get; set; }
        public string dialogCount { get; set; }
        public string status { get; set; }
        public List<TextDialog> dialogs { get; set; }
    }
}