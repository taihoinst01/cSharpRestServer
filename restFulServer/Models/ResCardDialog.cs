using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restFulServer.Models
{
    public class ResCardDialog
    {
        public string conversationId { get; set; }
        public string dialogCount { get; set; }
        public string status { get; set; }
        public List<CardDialog> dialogs { get; set; }
    }
}