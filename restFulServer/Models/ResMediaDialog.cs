using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restFulServer.Models
{
    public class ResMediaDialog
    {
        public string conversationId { get; set; }
        public string dialogCount { get; set; }
        public string status { get; set; }
        public List<MediaDialog> dialogs { get; set; }
    }
}