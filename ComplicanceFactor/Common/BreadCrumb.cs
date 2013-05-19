using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComplicanceFactor.Common.Languages;

namespace ComplicanceFactor.Common
{
    public class BreadCrumb
    {
        public static string GetCurrentBreadCrumb(string navigation)
        {
            string navigationText = string.Empty;
            if (navigation == "app_nav_employee")
            {
                navigationText = "<a href=/Employee/Home/lhp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_employee") + "</a>";
                return navigationText;
            }

            else if (navigation == "app_nav_manager")
            {
                navigationText = "<a href=/Manager/Home/mhp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_manager") + "</a>";
                return navigationText;
            }
            else if (navigation == "app_nav_compliance")
            {
                navigationText = "<a href=/Compliance/cchp-01.aspx>" + LocalResources.GetLocaleResourceString("app_nav_compliance") + "</a>";
                return navigationText;
            }
            else if (navigation == "app_nav_instructor")
            {
                navigationText = "<a href=/Instructor/tihp-01.aspx>" + LocalResources.GetGlobalLabel("app_instructor_text") + "</a>";
                return navigationText;
            }
            else if (navigation == "app_nav_training")
            {
                navigationText = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_training") + "</a>";
                return navigationText;
            }
            else if (navigation == "app_nav_admin")
            {
                navigationText = "<a href=/Administrator/tahp-01.aspx>" + LocalResources.GetGlobalLabel("app_administrator_text") + "</a>";
                return navigationText;
            }
            else
            {
                navigationText = "<a href=/SystemHome/sahp-01.aspx>" + LocalResources.GetGlobalLabel("app_nav_system") + "</a>";
                return navigationText;
            }
        }
    }
}