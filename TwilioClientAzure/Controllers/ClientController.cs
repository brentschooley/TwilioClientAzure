using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.TwiML;
using Twilio.TwiML.Mvc;
using System.Text.RegularExpressions;

namespace TwilioClientAzure.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Token(string clientName)
        {
            if(String.IsNullOrEmpty(clientName))
            {
                clientName = "default";
            }

            var capability = new TwilioCapability(Credentials.AccountSid, Credentials.AuthToken);
            capability.AllowClientIncoming(clientName);
            capability.AllowClientOutgoing(Credentials.AppSid);

            return Content(capability.GenerateToken());
        }

        public ActionResult Call(string source, string target)
        {
            var response = new TwilioResponse();

            if (Regex.IsMatch(target, @"^[\d\+\-\(\) ]+$"))
            {
                response.Dial(new Number(target), new { callerId = source });
            }
            else
            {
                response.Dial(new Client(target), new { callerId = source });
            }

            return new TwiMLResult(response);
        }
    }
}