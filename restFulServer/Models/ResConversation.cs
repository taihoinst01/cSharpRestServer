using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restfulEx.Models
{
    public class ResConversation
    {
        public string conversationid { get; set; }
        public int dialogCount { get; set; }
        public int status { get; set; }
        public List<dialog> dialogs { get; set; }
    }
}