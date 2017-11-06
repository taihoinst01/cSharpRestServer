using restfulEx.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace restFulServer.Controllers
{
    [RoutePrefix("chatbot/v1/api")]
    public class ChatBotController : ApiController
    {
        [HttpPost]
        [Route("conversations")]
        public HttpResponseMessage PostConversations(HttpRequestMessage req)
        {
            var result = req.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("[chatbot/v1/api/conversations ChatBotController.PostConversations] ==============> " + result);

            var javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            try
            {
                if (result == null)
                {
                    Error error = new Error();
                    error.status = 400;
                    error.text = "request parameter is null";
                    //var errorJavaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    string errorRes = javaScriptSerializer.Serialize(error);
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent(errorRes, System.Text.Encoding.UTF8, "application/json")
                    };
                }

                ReqConversation json = new JavaScriptSerializer().Deserialize<ReqConversation>(result);

                //response json create
                ResConversation resObj = new ResConversation();
                resObj.conversationid = json.conversationid;
                resObj.dialogCount = 1;
                resObj.status = 200;
                resObj.dialogs = new List<dialog>();
                dialog item = new dialog();
                item.type = "text";
                item.text = json.conversations[0].message;
                resObj.dialogs.Add(item);

                //var javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                string res = javaScriptSerializer.Serialize(resObj);

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(res, System.Text.Encoding.UTF8, "application/json")
                };
            }
            catch (Exception e)
            {
                Error error = new Error();
                error.status = 500;
                error.text = e.Message;
                string errorRes = javaScriptSerializer.Serialize(error);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(errorRes, System.Text.Encoding.UTF8, "application/json")
                };
            }
        }
    }
}
