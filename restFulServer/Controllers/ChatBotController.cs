using restFulServer.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace restFulServer.Controllers
{
    public class ChatBotController : ApiController
    {
        [HttpGet]
        [Route("api")]
        public HttpResponseMessage GetMessage(String q)
        {
            var javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            textDlg obj = new textDlg();
            obj.type = "text";
            obj.text = q;
            string res = javaScriptSerializer.Serialize(obj);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(res, System.Text.Encoding.UTF8, "application/json")
            };
        }
    }
}
