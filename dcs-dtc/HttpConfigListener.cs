using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Web;
using System.Windows.Forms;
using DTC.Properties;
using DTC.UI;
using Settings = DTC.Models.Base.Settings;

namespace DTC
{
    public sealed class HttpConfigListener
    {
        private static string getData =
            "<!DOCTYPE>" +
            "<html>" +
            "  <head>" +
            "    <title>DCS-DTC HTTP-Configloader</title>" +
            "    <script language=\"JavaScript\">" +
            "      function ol() {" +
            "        var h = document.location.hash;" +
            "        if (h == \"\") return;" +
            "        document.getElementById('data').value = h.substring(1);" +
            "        document.getElementById('load').click();" +
            "        setTimeout(function(){window.close()}, 5000);" +
            "      }" + 
            "    </script>" +
            "  </head>" +
            "  <body onLoad=\"javascript: ol()\">" +
            "    <p>Please wait a moment ... You need Javascript enabled ..</p>" +
            "    <form method=\"post\">" +
            "      <input type=\"hidden\" id=\"data\" name=\"data\" />" +
            "      <input type=\"submit\" id=\"load\" value=\"load\" />" +
            "    </form>" +
            "  </body>" + 
            "</html>";

        private MainForm _mainForm; 
        
        private static readonly Lazy<HttpConfigListener> lazyInstance =
            new Lazy<HttpConfigListener>(() => new HttpConfigListener());
        
        public static HttpConfigListener Instance
        {
            get { return lazyInstance.Value; }
        }

        private HttpConfigListener()
        {
            
        }
        
        private HttpListener _listener;

        public void Stop()
        {
            _listener.Stop();
        }

        public void Start(MainForm mainForm)
        {
            _mainForm = mainForm;
            
            if ( (_listener != null) && _listener.IsListening)
            {
                _listener.Stop();
            }

            _listener = new HttpListener();
            _listener.Prefixes.Add("http://localhost:"+Settings.HTTPTCPServerPort.ToString()+"/");
            _listener.Prefixes.Add("http://127.0.0.1:"+Settings.HTTPTCPServerPort.ToString()+"/");
            _listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
            _listener.Start();
            ReceiveRequest();
        }

        private void ReceiveRequest()
        {
            _listener.BeginGetContext(new AsyncCallback(ListenerCallback), _listener);
        }

        private void ListenerCallback(IAsyncResult result)
        {
            if (_listener.IsListening)
            {
                var context = _listener.EndGetContext(result);
                var request = context.Request;
                var response = context.Response;
                HandleRequest(request, response);
                
                ReceiveRequest();
            }
        }

        private void HandleRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            if (request.HttpMethod == "GET")
            {
                byte[] data = Encoding.UTF8.GetBytes(getData);
                response.ContentType = "text/html";
                response.ContentEncoding = Encoding.UTF8;
                response.ContentLength64 = data.LongLength;
                response.OutputStream.Write(data, 0, data.Length);
                response.Close();
            } else if (request.HttpMethod == "POST")
            {
                var inputText = new StreamReader(request.InputStream, request.ContentEncoding).ReadToEnd();
                string[] rawParams = inputText.Split('&');
                string data = null;
                foreach (string param in rawParams)
                {
                    string[] kvPair = param.Split('=');
                    if (kvPair[0].ToLower().Equals("data"))
                    {
                        data = HttpUtility.UrlDecode(kvPair[1]);
                    }
                }

                if (data == null) return;
                //_SettingsToLoad.encodedData = data;
                //_SettingsToLoad.airplane = request.Url.AbsolutePath;
                _mainForm.BeginInvoke(new MethodInvoker(delegate
                {
                    _mainForm.loadSettingsFromWeb(request.Url.AbsolutePath, data);
                }));
            }
        }
    }
}