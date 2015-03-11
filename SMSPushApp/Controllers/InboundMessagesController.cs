using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;

namespace SMSPushApp.Controllers
{
    public class InboundMessagesController : ApiController
    {
     
  [System.Web.Http.AcceptVerbs("Get","POST")]
        [System.Web.Http.HttpGet]
        
        
        public void Post(HttpRequestMessage inboundMessage)
        {

            var doc = new XmlDocument();
            doc.Load(inboundMessage.Content.ReadAsStreamAsync().Result);
            XmlNode node = doc.SelectSingleNode("InboundMessage");

            string message = node.ChildNodes[3].InnerText;
            string from = node.ChildNodes[4].InnerText;
           SMSStore.smsstore sms = new SMSStore.smsstore();

           int id = sms.SaveMessage(message, from);
           sms.StartWorkflow(id,from);
           
           
        }
    }

    public class InboundMessage
    {
        public Guid Id { get; set; }
        public Guid MessageId { get; set; }
        public Guid AccountId { get; set; }
        public string MessageText { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Now { get; set; }
    }
}