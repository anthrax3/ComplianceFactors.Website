using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;


namespace ComplicanceFactor.Common.Languages
{
    public class LocalResources : Page
    {
        #region "old Localization"
        //public static string GetLocaleResourceString(string ResourceName)
        //{
        //    string currentCulture = SessionWrapper.CultureName;
        //    //if(ResourceControl.ToUpper()=="LABEL")
        //    return LocalizationManager.GetLocaleResourceString(ResourceName, currentCulture);
        //    //else
        //    //return LocalizationManager.GetLocaleResourceText(ResourceName, currentCulture);
        //    //return LocalizationManager.GetLocaleResourceString(ResourceName,"uk_english");
        //}

        //public static string GetLocaleResourceText(string ResourceName)
        //{
        //    string currentCulture = SessionWrapper.CultureName;
        //    return LocalizationManager.GetLocaleResourceText(ResourceName, currentCulture);
        //    //return LocalizationManager.GetLocaleResourceString(ResourceName,"uk_english");
        //}
        //public static string GetLocalizationResourceLabelText(string ResourceName)
        //{
        //    string currentCulture = SessionWrapper.CultureName;
        //    return LocalizationManager.GetLocalizationLabelText(ResourceName, currentCulture);


        //}
        #endregion

        //New locazation
        public static string GetText(string ResourceName)
        {
            string currentCulture = SessionWrapper.CultureName;
            return LocalizationManager.GetText(ResourceName, currentCulture);
        }
        public static string GetLabel(string ResourceName)
        {
            string currentCulture = SessionWrapper.CultureName;
            return LocalizationManager.GetLabel(ResourceName, currentCulture);
        }
        public static string GetGlobalLabel(string ResourceName)
        {
            string currentCulture = SessionWrapper.CultureName;
            //if(ResourceControl.ToUpper()=="LABEL")
            return LocalizationManager.GetGlobalLabel(ResourceName, currentCulture);
            //else
            //return LocalizationManager.GetLocaleResourceText(ResourceName, currentCulture);
            //return LocalizationManager.GetLocaleResourceString(ResourceName,"uk_english");
        }
        public static string GetGlobalText(string ResourceName)
        {
            string currentCulture = SessionWrapper.CultureName;
            return LocalizationManager.GetGlobalText(ResourceName, currentCulture);
            //return LocalizationManager.GetLocaleResourceString(ResourceName,"uk_english");
        }
    }
}