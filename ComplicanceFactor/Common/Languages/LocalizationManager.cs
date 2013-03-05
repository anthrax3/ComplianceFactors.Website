using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ComplicanceFactor.BusinessComponent;
using System.IO;

namespace ComplicanceFactor.Common.Languages
{
    public class LocalizationManager
    {

        public static string GetLocaleResourceString(string ResourceKey, string LanguageID)
        {
            return LanguageBLL.GetResourceValue(LanguageID, ResourceKey);


        }
       
        public static string GetLocaleResourceText(string ResourceKey, string LanguageID)
        {
            return LanguageBLL.GetResourceText(LanguageID, ResourceKey);


        }
        public static string GetLocalizationLabelText(string ResourceKey, string LanguageID)
        {
            string sPath = HttpContext.Current.Request.Url.AbsolutePath;

            FileInfo oInfo = new FileInfo(sPath);

            string sRet = oInfo.Name;
            sRet = sRet.Replace(".aspx", "");
            return LanguageBLL.GetLocalizationLabel(LanguageID, ResourceKey, sRet);
        }

        //New localization
        public static string GetText(string ResourceKey, string LanguageID)
        {
            string sPath = HttpContext.Current.Request.Url.AbsolutePath;

            FileInfo oInfo = new FileInfo(sPath);

            string sRet = oInfo.Name;
            sRet = sRet.Replace(".aspx", "");
            if (sRet != "Default")
            {
                // return LanguageBLL.GetResourceText(LanguageID, ResourceKey);
                return LanguageBLL.GetText(LanguageID, ResourceKey, sRet);
            }
            else
            {
                return string.Empty;

            }


        }
        public static string GetLabel(string ResourceKey, string LanguageID)
        {
            string sPath = HttpContext.Current.Request.Url.AbsolutePath;

            FileInfo oInfo = new FileInfo(sPath);

            string sRet = oInfo.Name;
            sRet = sRet.Replace(".aspx", "");
            return LanguageBLL.GetLabel(LanguageID, ResourceKey, sRet);
            //Return LanguageBLL.GetLocalizationLabel(LanguageID, ResourceKey, sRet);
        }
        public static string GetGlobalLabel(string ResourceKey, string LanguageID)
        {

            return LanguageBLL.GetGlobalLabel(LanguageID, ResourceKey);



        }
        public static string GetGlobalText(string ResourceKey, string LanguageID)
        {
            return LanguageBLL.GetGlobalText(LanguageID, ResourceKey);

        }
    }
}