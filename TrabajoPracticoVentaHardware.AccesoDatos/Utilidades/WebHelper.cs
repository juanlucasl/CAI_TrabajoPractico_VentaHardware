using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Text;

namespace TrabajoPracticoVentaHardware.AccesoDatos.Utilidades
{
    internal static class WebHelper
    {
        private static readonly WebClient Client;
        private static readonly string RutaBase;
        private static readonly string TpId;

        static WebHelper()
        {
            Client = new WebClient();
            Client.Encoding = Encoding.UTF8;
            RutaBase = ConfigurationManager.AppSettings["URL_API"];
            TpId = ConfigurationManager.AppSettings["TP_ID"];

            Client.Headers.Add("ContentType", "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public static string Get(string url)
        {
            string uri = $"{RutaBase}{url}/{TpId}";

            string responseString = Client.DownloadString(uri);

            return responseString;
        }

        public static string Post(string url, NameValueCollection parametros)
        {
            string uri = RutaBase + url;

            try
            {
                byte[] response = Client.UploadValues(uri, parametros);

                string responseString = Encoding.Default.GetString(response);

                return responseString;
            }
            catch (Exception ex)
            {
                return "{ \"isOk\":false,\"id\":-1,\"error\":\"Error en el llamado al servicio\"}";
            }
        }

        public static string Put(string url, NameValueCollection parametros)
        {
            string uri = RutaBase + url;

            try
            {
                byte[] response = Client.UploadValues(uri, "PUT", parametros);

                string responseString = Encoding.Default.GetString(response);

                return responseString;
            }
            catch (Exception ex)
            {
                return "{ \"isOk\":false,\"id\":-1,\"error\":\"Error en el llamado al servicio\"}";
            }
        }

        public static string Delete(string url, NameValueCollection parametros)
        {
            string uri = RutaBase + url;

            try
            {
                byte[] response = Client.UploadValues(uri, "DELETE", parametros);

                string responseString = Encoding.Default.GetString(response);

                return responseString;
            }
            catch (Exception ex)
            {
                return "{ \"isOk\":false,\"id\":-1,\"error\":\"Error en el llamado al servicio\"}";
            }
        }
    }
}
