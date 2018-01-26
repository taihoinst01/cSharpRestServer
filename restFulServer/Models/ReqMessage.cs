using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restFulServer.Models
{
    public class ReqMessage
    {
        public string conversationId { get; set; }
        public string authenticationKey { get; set; }
        public string entities { get; set; }
        public string intent { get; set; }
        public string query { get; set; }
    }
}