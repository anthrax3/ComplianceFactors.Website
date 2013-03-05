using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Globalization;
using System.IO;
using System.Threading;
using System.Data;
using ComplicanceFactor.BusinessComponent;
namespace ComplicanceFactor.Common
{
    public sealed class LanguageManager
    {
        /// <summary>
        /// Default CultureInfo
        /// </summary>
        public static readonly CultureInfo DefaultCulture = new CultureInfo("en-US");

        /// <summary>
        /// Available CultureInfo that according resources can be found
        /// </summary>
        public static readonly CultureInfo[] AvailableCultures;

        static LanguageManager()
        {
            ////
            //// Available Cultures
            ////
            //List<string> availableResources = new List<string>();
            //string resourcespath = Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, "App_GlobalResources");
            //DirectoryInfo dirInfo = new DirectoryInfo(resourcespath);
            //foreach (FileInfo fi in dirInfo.GetFiles("*.*.resx", SearchOption.AllDirectories))
            //{
            // //Take the cultureName from resx filename, will be smt like en-US
            // string cultureName = Path.GetFileNameWithoutExtension(fi.Name); //get rid of .resx
            // if (cultureName.LastIndexOf(".") == cultureName.Length - 1)
            // continue; //doesnt accept format FileName..resx
            // cultureName = cultureName.Substring(cultureName.LastIndexOf(".") + 1);
            // availableResources.Add(cultureName);
            //}

            //List<CultureInfo> result = new List<CultureInfo>();
            //foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            //{
            // //If language file can be found
            // if (availableResources.Contains(culture.ToString()))
            // {
            // result.Add(culture);
            // }
            //}

            //AvailableCultures = result.ToArray();

            ////
            //// Current Culture
            ////
            //CurrentCulture = DefaultCulture;
            //// If default culture is not available, take another available one to use
            //if (!result.Contains(DefaultCulture) && result.Count > 0)
            //{
            // CurrentCulture = result[0];
            //}

            //
            // Available Cultures
            //
            List<string> availableResources = new List<string>();
            DataTable dtCulture = new DataTable();
            dtCulture = LanguageBLL.GetAvailableCulture();

            for (int i = 0; i < dtCulture.Rows.Count; i++)
            {
                availableResources.Add(dtCulture.Rows[i]["s_locale_culture"].ToString());
            }
            //availableResources.Add("en-US");
            //availableResources.Add("it-IT");

            List<CultureInfo> result = new List<CultureInfo>();
            foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                //If language file can be found
                if (availableResources.Contains(culture.ToString()))
                {
                    result.Add(culture);
                }
            }

            AvailableCultures = result.ToArray();

            //
            // Current Culture
            //
            CurrentCulture = DefaultCulture;
            // If default culture is not available, take another available one to use
            if (!result.Contains(DefaultCulture) && result.Count > 0)
            {
                CurrentCulture = result[0];
            }
        }

        /// <summary>
        /// Current selected culture
        /// </summary>
        public static CultureInfo CurrentCulture
        {
            get { return Thread.CurrentThread.CurrentCulture; }
            set
            {

                Thread.CurrentThread.CurrentUICulture = value;
                Thread.CurrentThread.CurrentCulture = value;
            }
        }

        /// <summary>
        /// Sets the CultureInfo
        /// </summary>
        /// <param name="culture">Culture</param>
        public void SetCulture(CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        }
    }
}
