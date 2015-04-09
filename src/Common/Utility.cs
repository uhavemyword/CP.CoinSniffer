// ------------------------------------------------------------------------------------
//      Copyright (c) uhavemyword(at)gmail.com. All rights reserved.
//      Created by Ben at 12/8/2013 3:02:41 AM
// ------------------------------------------------------------------------------------

namespace CP.CoinSniffer.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Text;

    public static class Utility
    {
        public static byte[] Force32Bytes(byte[] inbytes)
        {
            if (inbytes.Length == 32)
            {
                return inbytes;
            }
            byte[] outbytes = new byte[32];
            if (inbytes.Length > 32)
            {
                Array.Copy(inbytes, inbytes.Length - 32, outbytes, 0, 32);
            }
            else
            {
                Array.Copy(inbytes, 0, outbytes, 32 - inbytes.Length, inbytes.Length);
            }
            return outbytes;
        }

        public static string Encrypt(string s)
        {
            var b = Encoding.ASCII.GetBytes(s);
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = (byte)(b[i] + i + 100);
            }
            return Convert.ToBase64String(b);
        }

        public static string Decrypt(string s)
        {
            var b = Convert.FromBase64String(s);
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = (byte)(b[i] - i - 100);
            }
            return Encoding.ASCII.GetString(b);
        }

        /// <summary>
        /// Send e-mail
        /// </summary>
        /// <returns>null if success, or error message</returns>
        public static string SendEMail(string server, int port, string username, string password, string from, string to, string subject, string body)
        {
            try
            {
                SmtpClient client = new SmtpClient(server, port);
                if (string.IsNullOrEmpty(username))
                {
                    client.UseDefaultCredentials = true;
                }
                else
                {
                    client.Credentials = new NetworkCredential(username, password);
                }
                MailMessage message = new MailMessage(from, to, subject, body);
                message.BodyEncoding = Encoding.UTF8;
                message.SubjectEncoding = Encoding.UTF8;
                message.HeadersEncoding = Encoding.UTF8;
                client.Send(message);
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
