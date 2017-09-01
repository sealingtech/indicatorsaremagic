using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;

namespace IndicatorMagic2
{
    class Actions
    {
        
        Output_Interface obj;
        public Actions(Output_Interface obj)
        {
           
            this.obj = obj;
        }

        /// <summary>
        /// Performs a standard HTTP or HTTPS get to a website.  Allows you to customize the useragent string that will be used
        /// </summary>
        /// <param name="url"></param>
        /// <param name="userAgent"></param>
        public void Http_Client_Get(string url, string userAgent, string accept_language)
        {
            try
            {
                obj.writeToLog("HTTP: Get on " + url + " agent: " + userAgent + " language: " + accept_language);
                WebClient client = new WebClient();
                client.Headers["User-Agent"] = userAgent;
                Stream data = client.OpenRead(url);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                
            }
            catch (Exception e)
            {
                obj.writeToLog("Error" + e);
                return;
            }
            obj.writeToLog("Success on Http Get!");
        }

        /// <summary>
        /// Performs a DNS request.  Ensures that the DNS is flushed before doing this so that the request isn't cached anywhere
        /// </summary>
        /// <param name="host"></param>
        public void Dns_Request(string host)
        {
            try
            {
                obj.writeToLog("Dns: Resolve on " + host);
                DnsUtils dns = new DnsUtils();
                DnsUtils.FlushCache();
                IPHostEntry localHost = Dns.GetHostEntry(host);
            } catch (Exception e )
            {
                obj.writeToLog("error: " + e);
                return;
            }
            obj.writeToLog("Success on DNS request!");
        }

        /// <summary>
        /// Post fields to a form
        /// </summary>
        /// <param name="url"></param>
        /// <param name="userAgent"></param>
        /// <param name="forms"></param>
        public void Http_Client_Post_Fields(string url, string userAgent, string accept_language, NameValueCollection form_fields)
        {
            obj.writeToLog("HTTP: POST on " + url + " agent: " + userAgent + " language: " + accept_language);
            try
            {
                WebClient client = new WebClient();
                client.Headers["User-Agent"] = userAgent;
                var response = client.UploadValues(url, "POST", form_fields);
            } catch (Exception e)
            {
                obj.writeToLog("Error: " + e);
                return;
            }
            obj.writeToLog("Success on HTTP POST!");
        }

        /// <summary>
        /// Post files to a website from a form field.  This was a PITA
        /// </summary>
        /// <param name="url"></param>
        /// <param name="file_path"></param>
        /// <param name="file_type"></param>
        /// <param name="param_name"></param>
        /// <param name="form_fields"></param>
        public void Http_Client_Post_File_Form(string url, string file_name, string file_type, string param_name, NameValueCollection form_fields)
        {
            try
            {
                HttpUploadFile(url, file_name, param_name, file_type, form_fields);
            } catch (Exception e)
            {
                obj.writeToLog("Error" + e);
            }
        }


        /// <summary>
        /// Helper Method for uploading files as if a user were to do this.  Shout out to Cristian Romanescu
        /// https://stackoverflow.com/questions/566462/upload-files-with-httpwebrequest-multipart-form-data
        /// </summary>
        /// <param name="url"></param>
        /// <param name="file"></param>
        /// <param name="paramName"></param>
        /// <param name="contentType"></param>
        /// <param name="nvc"></param>
        private void HttpUploadFile(string url, string file, string paramName, string contentType, NameValueCollection nvc)
        {
            obj.writeToLog(string.Format("Uploading {0} to {1}", file, url));
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            //we don't need creds
            //wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

            Stream rs = wr.GetRequestStream();

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in nvc.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, nvc[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, file, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);
            string full_file_path = Directory.GetCurrentDirectory() + "\\" + file;
            FileStream fileStream = new FileStream(full_file_path, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                obj.writeToLog(string.Format("File uploaded, server response is: {0}", reader2.ReadToEnd()));
            }
            catch (Exception ex)
            {
             obj.writeToLog("Error uploading file" + ex);
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }
        }

        public void do_things()
        {
            obj.writeToLog("hahaha");
            
        }
    }
}
