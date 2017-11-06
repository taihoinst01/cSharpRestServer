using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restfulEx.Models
{
    public class ReqConversation
    {
        public string conversationid { get; set; }
        public string authenticationkey { get; set; }
        public List<Conversations> conversations { get; set; }
        public List<Entity> entities { get; set; }
    }
}