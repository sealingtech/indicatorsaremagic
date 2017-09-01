using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;
using System.Collections.Specialized;
using System.IO;

namespace IndicatorMagic2
{
    class XmlFunctions
    {
        public static XmlReader openXml(string PathOfXML)
        {
            // Set the validation settings.
            XmlReaderSettings settings = new XmlReaderSettings();

            // Create the XmlReader object.
            XmlReader reader = null;
            try
            {
                reader = XmlReader.Create(PathOfXML);
            }
            catch
            {

            }

            return reader;
        }

        public static void executeXml(XmlReader reader, Actions action)
        {
            XmlDocument document = new XmlDocument();
            document.Load(reader);
            XmlNodeList indicators = document.SelectNodes("/indicators/indicator");
            
            //This will look at all the different type of indicators and call the necessarry functions
            foreach (XmlNode indicator in indicators)
                
                if(indicator.Attributes.GetNamedItem("type").Value == "http_get")
                {
                    action.Http_Client_Get(indicator["url"].InnerText, indicator["useragent"].InnerText, indicator["language"].InnerText);
                } else if (indicator.Attributes.GetNamedItem("type").Value == "dns_request")
                {
                    action.Dns_Request(indicator["hostname"].InnerText);
                } else if (indicator.Attributes.GetNamedItem("type").Value == "http_post_fields")
                {
                    XmlNode fields = indicator.SelectSingleNode("fields");

                    //Loop through all the fields and build a a dicationary to pass in
                    NameValueCollection nvc = new NameValueCollection();
                    foreach (XmlNode field in fields.SelectNodes("field"))
                    {
                        string key = field.SelectSingleNode("key").InnerText;
                        string value = field.SelectSingleNode("value").InnerText;
                        nvc.Add(key, value);   
                    }

                    action.Http_Client_Post_Fields(indicator["url"].InnerText, indicator["useragent"].InnerText, indicator["language"].InnerText, nvc);
                }  else if (indicator.Attributes.GetNamedItem("type").Value == "http_post_file")
                {
                    XmlNode fields = indicator.SelectSingleNode("fields");

                    //Loop through all the fields and build a a dicationary to pass in
                    NameValueCollection nvc = new NameValueCollection();
                    foreach (XmlNode field in fields.SelectNodes("field"))
                    {
                        string key = field.SelectSingleNode("key").InnerText;
                        string value = field.SelectSingleNode("value").InnerText;
                        nvc.Add(key, value);
                    }

                    action.Http_Client_Post_File_Form(indicator["url"].InnerText, indicator["file"].InnerText, indicator["file_type"].InnerText, indicator["param_name"].InnerText, nvc);
                }
        }
    }
}
