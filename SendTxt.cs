using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2SMS
{
    public class SendTxt
    {
        private static string _Username = "Username Name";
        private static string _Password = "Password";
        private static string _Account = "Account Number";


        /// <summary>
        /// Sends a Text Message
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="MobileNumber"></param>
        public static void SendMessage(string Message,string MobileNumber)
        {
            var sms = new SendSMS.SendServiceNoHeader();
            string messageid = sms.SendMessage(_Username,_Password,_Account,MobileNumber,Message,"Text");

    
        }

        /// <summary>
        /// Gets the status of a sms message
        /// </summary>
        /// <param name="MessageId"></param>
        /// <returns></returns>
        public static string MessageStatus(string MessageId)
        {
            var sms = new SendSMS.SendServiceNoHeader();
            return sms.GetMessageStatus(_Username, _Password, _Account, MessageId);
            
        }

        /// <summary>
        /// Gets a list of all the sent messages
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static List<SentItems> GetSentMessages(int year,int month)
        {
            List<SentItems> result = new List<SentItems>();
            var sent = new SMSAdmin.AccountServiceNoHeader();
            foreach (SMSAdmin.message item in sent.GetSentMessages(_Username, _Password, _Account, year, month))
            {
                result.Add(new SentItems
                {
                    DeliveredDate = item.receivedat.Date,
                   // Direction = item..ToString(),
                    MessageBody = item.body,
                    MessageId = item.id.ToString(),
                    SentDate = item.sentat.Date,
                    Status = item.status.ToString(),

                });
            }

            return result;
        
        }

        
    }


    public class Message
    {
        public string Body
        {
            get;
            set;
        }
    
        public string MobileNumber
        {
            get;
            set;
        }
    }

    public class SentItems
    {
        public String MessageId
        {
            get;
            set;

        }

        public string MessageBody
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public string Direction
        {
            get;
            set;
        }

        public DateTime SentDate
        {
            get;
            set;
        }

        public DateTime DeliveredDate
        {
            get;
            set;
        }

    }
}
