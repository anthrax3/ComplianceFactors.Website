using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;
using System.Configuration;
using System.IO;
using System.Data;
using System.ComponentModel;
using System.Collections;
using System.Reflection;

namespace ComplicanceFactor.Common
{
    public class Utility
    {
        public static string GetHtmlTemplate(string filePath)
        {
            string emailBody = string.Empty;
            StreamReader sr;
            try
            {

                FileInfo fi = new FileInfo(filePath);
                if (fi.Exists)
                {
                    sr = File.OpenText(filePath);
                    emailBody = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                if (ConfigurationWrapper.LogErrors == true)
                {
                    if (ex.InnerException != null)
                    {
                        Logger.WriteToErrorLog("Common/Utility.cs", ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        Logger.WriteToErrorLog("Common/Utility.cs", ex.Message);
                    }
                }
            }
            return emailBody;
        }
        /// <summary>
        /// Sends email message
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public static void SendEMailMessage(List<MailAddress> toAddresses, string subject, string body)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.Priority = MailPriority.High;
                message.From = new MailAddress(ConfigurationManager.AppSettings["FROMMAIL"]);

                foreach (MailAddress toAddress in toAddresses)
                {
                    message.To.Add(toAddress);
                }

                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;

                //SmtpClient emailClient = new SmtpClient(ConfigurationManager.AppSettings["Email.HostAddress"]);
                SmtpClient emailClient = new SmtpClient();
                //emailClient.UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["Email.UseDefaultCredentials"]);

                emailClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["FROMMAIL"],
                    ConfigurationManager.AppSettings["FROMPWD"]);
                emailClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["PORT"]);
                emailClient.Host = ConfigurationManager.AppSettings["SMTP"].ToString();
                emailClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["ENABLESSL"]);
                
                emailClient.Send(message);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        ///  This temporary method.
        /// </summary>
        /// <param name="toAddresses"></param>
        /// <param name="fromAddress"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public static void SendEMailMessages(List<MailAddress> toAddresses, string fromAddress, string subject, string body)
        {
            try
            {
                if (toAddresses.Count > 0 && !string.IsNullOrEmpty(fromAddress))
                {
                    MailMessage message = new MailMessage();
                    message.Priority = MailPriority.High;
                    message.From = new MailAddress(fromAddress);

                    foreach (MailAddress toAddress in toAddresses)
                    {
                        message.To.Add(toAddress);
                    }

                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = true;

                    //SmtpClient emailClient = new SmtpClient(ConfigurationManager.AppSettings["Email.HostAddress"]);
                    SmtpClient emailClient = new SmtpClient();
                    //emailClient.UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["Email.UseDefaultCredentials"]);

                    emailClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["FROMMAIL"],
                        ConfigurationManager.AppSettings["FROMPWD"]);
                    emailClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["PORT"]);
                    emailClient.Host = ConfigurationManager.AppSettings["SMTP"].ToString();
                    emailClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["ENABLESSL"]);

                    emailClient.Send(message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}