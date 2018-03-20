using Newtonsoft.Json.Linq;
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
        [HttpPost]
        [Route("chatbot/v1/api")]
        public HttpResponseMessage MsgToDlgJson(HttpRequestMessage req)
        {
            const string AUTHKEY = "83ECD4D6D7C53AD5B8552209FB4E24BE";
            const string TEXTDLG = "텍스트";
            const string CARDDLG = "캐러절";
            const string MEDIADLG = "미디어";

            var result = req.Content.ReadAsStringAsync().Result;
            var javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            Debug.WriteLine("[chatbot/v1/api : ChatBotController.MsgToDlgJson] ==============> " + result);

            try
            {
                if(result != null && result != "")
                {
                    ReqMessage reqJson = new JavaScriptSerializer().Deserialize<ReqMessage>(result);
                    if (reqJson.authenticationKey.Equals(AUTHKEY))
                    {
                        string res = "";
                        if (reqJson.query.Equals(TEXTDLG))
                        {
                            ResTextDialog resObj = new ResTextDialog();
                            resObj.conversationId = reqJson.conversationId;
                            resObj.dialogCount = "1";
                            resObj.status = "200";
                            resObj.dialogs = new List<TextDialog>();

                            //DB처리

                            for (var i = 0; i < 1; i++)
                            {
                                TextDialog dlg = new TextDialog();
                                dlg.type = "text";
                                dlg.title = "WELCOME";
                                dlg.text = "안녕하세요. 저는 챗봇이라고 해요!";
                                resObj.dialogs.Add(dlg);
                            }

                            res = javaScriptSerializer.Serialize(resObj);
                        }
                        else if (reqJson.query.Equals(CARDDLG))
                        {
                            ResCardDialog resObj = new ResCardDialog();
                            resObj.conversationId = reqJson.conversationId;
                            resObj.dialogCount = "1";
                            resObj.status = "200";
                            resObj.dialogs = new List<CardDialog>();

                            //DB처리

                            for (var i = 0; i < 1; i++)
                            {
                                CardDialog dlg = new CardDialog();
                                dlg.type = "carousel";
                                dlg.herocards = new List<HeroCard>();

                                for (var j = 0; j < 1; j++)
                                {
                                    HeroCard heroCard = new HeroCard();
                                    heroCard.type = "herocard";
                                    heroCard.title = "캐러절 제목";
                                    heroCard.subtitle = "캐러절 부제목";
                                    heroCard.text = "캐러절 내용";
                                    heroCard.media_url = "https://test.com/1.png";
                                    heroCard.buttons = new List<Button>();

                                    for (var k = 0; k < 1; k++)
                                    {
                                        Button btn = new Button();
                                        btn.type = "imBack";
                                        btn.title = "자세히보기";
                                        btn.value = "캐러절 보기";
                                        heroCard.buttons.Add(btn);
                                    }

                                    dlg.herocards.Add(heroCard);
                                }
                                resObj.dialogs.Add(dlg);
                            }

                            res = javaScriptSerializer.Serialize(resObj);
                        }
                        else if (reqJson.query.Equals(MEDIADLG))
                        {
                            ResMediaDialog resObj = new ResMediaDialog();
                            resObj.conversationId = reqJson.conversationId;
                            resObj.dialogCount = "1";
                            resObj.status = "200";
                            resObj.dialogs = new List<MediaDialog>();

                            //DB처리

                            for (var i = 0; i < 1; i++)
                            {
                                MediaDialog dlg = new MediaDialog();
                                dlg.type = "media";
                                dlg.title = "소개 동영상";
                                dlg.text = "소개 동영상입니다~";
                                dlg.media_url = "https://test.com/1.png";

                                List<Button> buttons = new List<Button>();
                                for (var j = 0; j < 1; j++)
                                {
                                    Button btn = new Button();
                                    btn.type = "imBack";
                                    btn.title = "돌아가기";
                                    btn.value = "시작";
                                    buttons.Add(btn);
                                }
                                dlg.buttons = buttons;
                                resObj.dialogs.Add(dlg);
                            }

                            res = javaScriptSerializer.Serialize(resObj);
                        }
                        else // 타입 없는 경우
                        {
                            Exception e = new Exception("Not found Dialog Type");
                            
                            throw new Exception("Bad Request : Not found Dialog Type");
                        }

                        return new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StringContent(res, System.Text.Encoding.UTF8, "application/json")
                        };

                    }
                    else // 인증키가 맞지 않는 경우
                    {
                        throw new Exception("Unauthorized : Invalid authentication key");
                    }
                }
                else // request 파라미터 없는 경우
                {
                    throw new Exception("Bad Request : request parameter is empty");
                }
            }
            catch (Exception e)
            {
                //Debug.WriteLine(e.Message);
                //Debug.WriteLine(e.StackTrace);
                Error error = new Error();
                error.message = e.Message;
                error.status = "999";
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(javaScriptSerializer.Serialize(error), System.Text.Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpGet]
        [Route("chatbot/v2/api")]
        public HttpResponseMessage MsgToMeetingRoomJson(HttpRequestMessage req)
        {
            var hero1 = new JObject();
            hero1.Add("bd_cl_cd", "H0001");
            hero1.Add("bd_cl_nm", "동관");
            hero1.Add("bd_fl_cd", "6");
            hero1.Add("cnf_from_time", "1530");
            hero1.Add("cnf_from_ymd", "20180317");
            hero1.Add("cnf_to_time", "1629");
            hero1.Add("cnf_to_ymd", "20180317");
            hero1.Add("corm_cd", "M0011");
            hero1.Add("corm_nm", "대회의실");
            hero1.Add("odu_regn_cd", "1");
            hero1.Add("odu_regn_nm", "본사");
            hero1.Add("odu_sebu_cd", "1A");
            hero1.Add("odu_sebu_nm", "양재");
            hero1.Add("type", "herocard");

            var hero2 = new JObject();
            hero2.Add("bd_cl_cd", "H0001");
            hero2.Add("bd_cl_nm", "동관");
            hero2.Add("bd_fl_cd", "6");
            hero2.Add("cnf_from_time", "1530");
            hero2.Add("cnf_from_ymd", "20180317");
            hero2.Add("cnf_to_time", "1629");
            hero2.Add("cnf_to_ymd", "20180317");
            hero2.Add("corm_cd", "M0012");
            hero2.Add("corm_nm", "중회의실Ⅰ");
            hero2.Add("odu_regn_cd", "1");
            hero2.Add("odu_regn_nm", "본사");
            hero2.Add("odu_sebu_cd", "1A");
            hero2.Add("odu_sebu_nm", "양재");
            hero2.Add("type", "herocard");

            var hero3 = new JObject();
            hero3.Add("bd_cl_cd", "H0001");
            hero3.Add("bd_cl_nm", "동관");
            hero3.Add("bd_fl_cd", "6");
            hero3.Add("cnf_from_time", "1530");
            hero3.Add("cnf_from_ymd", "20180317");
            hero3.Add("cnf_to_time", "1629");
            hero3.Add("cnf_to_ymd", "20180317");
            hero3.Add("corm_cd", "M0013");
            hero3.Add("corm_nm", "중회의실 Ⅱ");
            hero3.Add("odu_regn_cd", "1");
            hero3.Add("odu_regn_nm", "본사");
            hero3.Add("odu_sebu_cd", "1A");
            hero3.Add("odu_sebu_nm", "양재");
            hero3.Add("type", "herocard");

            var hero4 = new JObject();
            hero4.Add("bd_cl_cd", "H0001");
            hero4.Add("bd_cl_nm", "동관");
            hero4.Add("bd_fl_cd", "6");
            hero4.Add("cnf_from_time", "1530");
            hero4.Add("cnf_from_ymd", "20180317");
            hero4.Add("cnf_to_time", "1629");
            hero4.Add("cnf_to_ymd", "20180317");
            hero4.Add("corm_cd", "M0014");
            hero4.Add("corm_nm", "중회의실 Ⅲ");
            hero4.Add("odu_regn_cd", "1");
            hero4.Add("odu_regn_nm", "본사");
            hero4.Add("odu_sebu_cd", "1A");
            hero4.Add("odu_sebu_nm", "양재");
            hero4.Add("type", "herocard");


            var resArr = new JArray();
            resArr.Add(hero1);
            resArr.Add(hero2);
            resArr.Add(hero3);
            resArr.Add(hero4);

            var resJson = new JObject();
            resJson.Add("conversationId", "123456789");
            resJson.Add("dialogCount", "1");
            resJson.Add("status", "200");
            resJson.Add("dialogs", resArr);

            
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(resJson.ToString(), System.Text.Encoding.UTF8, "application/json")
            };
        }
    }
}
