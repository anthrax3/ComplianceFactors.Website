using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ComplicanceFactor.Common
{
    public class ConfigurationWrapper
    {
        public static bool LogErrors
        {
            get
            {
                bool logErrors = false;
                Boolean.TryParse(ConfigurationManager.AppSettings["LogErrors"], out logErrors);
                return logErrors;
            }
        }
    }
}