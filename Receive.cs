using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2SMS
{
    public class Receive
    {
        private static string _Username = "Username Name";
        private static string _Password = "Password";
        private static string _Account = "Account Number";


        public static List<Inbox> GetInbox()
        {
            List<Inbox> result = new List<Inbox>();
            var inbox = new InboxSMS.InboxServiceNoHeader();
            
            foreach(InboxSMS.message item in inbox.GetMessages(_Username,_Password,_Account))
            {
                result.Add(new Inbox
                {
                    DeliveredDate = item.receivedat.Date,
                    // Direction = item..ToString(),
                    MessageBody = item.body,
                    MessageId = item.id.ToString(),
                   SentDate = item.sentat.Date,
                    Status = item.status.ToString(),
                    From = item.originator

                });
            
            
            }

            return result;
        }

    }


    public class Inbox
    {
        public string MessageId
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


        public DateTime DeliveredDate
        {
            get;
            set;
        }


        public DateTime SentDate
        {
            get;
            set;
        }
        public string From
        {
            get;
            set;
        }

    }
}
