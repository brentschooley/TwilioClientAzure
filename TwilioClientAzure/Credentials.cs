using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace TwilioClientAzure
{
    public static class Credentials
    {
        public static string AccountSid
        {
            get
            {
                return GetCredential("AccountSid");
            }
        }

        public static string AuthToken
        {
            get
            {
                return GetCredential("AuthToken");
            }
        }

        public static string AppSid
        {
            get
            {
                return GetCredential("AppSid");
            }
        }

        public static string GetCredential(string credentialName)
        {
            var credential = ConfigurationManager.AppSettings[credentialName];
            if(String.IsNullOrEmpty(credential))
            {
                credential = System.Environment.GetEnvironmentVariable(credentialName, EnvironmentVariableTarget.Machine);
            }
            return credential;
        }
    }
}