using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SourceCode.Workflow.Client;
using SourceCode.SmartObjects.Client;
using SourceCode.Hosting.Client.BaseAPI;
using SourceCode.SmartObjects.Client;
using SourceCode.Hosting.Client.BaseAPI;
namespace SMSStore
{
    public class smsstore
    {
        public int SaveMessage(string message, string from)
        {
            SCConnectionStringBuilder hostServerConnectionString = new SCConnectionStringBuilder();
            hostServerConnectionString.Host = "localhost"; 
            hostServerConnectionString.Port = 5555;
            hostServerConnectionString.IsPrimaryLogin = true; 
            hostServerConnectionString.Integrated = true; 
            SmartObjectClientServer soServer = new SmartObjectClientServer(); 
            soServer.CreateConnection();
            soServer.Connection.Open(hostServerConnectionString.ToString());

            SmartObject MessageSMO = soServer.GetSmartObject("Messages");
            MessageSMO.Properties["MessageBody"].Value = message;
            MessageSMO.Properties["FromNumber"].Value = from;
            MessageSMO.Properties["DateSent"].Value = DateTime.Now.ToString();
            MessageSMO.Properties["Status"].Value = "New";
            MessageSMO.Properties["Direction"].Value = "Inbound";
            MessageSMO.MethodToExecute = "Create";
            soServer.ExecuteScalar(MessageSMO);
            return Convert.ToInt32(MessageSMO.Properties["id"].Value);

        }

        public void StartWorkflow(int MessageId,string from)
        {

            Connection conn = new Connection();
            conn.Open("localhost");
            
            string processname = @"K2SMS\CaptureSMS";
            ProcessInstance pi = conn.CreateProcessInstance(processname);
            pi.DataFields["MessageId"].Value = MessageId;
            pi.Folio = from;
            conn.StartProcessInstance(pi);
        }
    }
}
