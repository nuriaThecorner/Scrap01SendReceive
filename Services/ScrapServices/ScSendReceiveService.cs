using HtmlAgilityPack;
using System;
using System.Text;

namespace Services.ScrapServices
{
    internal class ScSendReceiveService
    {
        public string EnviarYRecibir(string url, string xpath)
        {
            string valorBuscado = "";
            //objeto web mediante el cual nos comunicamos con la web 
            HtmlWeb web = new HtmlWeb();

            //Set tipo codifcacion para acentos.
            web.OverrideEncoding = Encoding.UTF8;

            //objeto que recoge el html
            HtmlDocument doc = null;

            ////PROXI
            //WebProxy proxy = new WebProxy(proxyUrl);

            //// TRET D'AQUESTA PÀGINA: https://bLogHelper.jongallant.com/2012/07/htmlagilitypack-windows-authentication/
            //web.PreRequest = delegate (HttpWebRequest webRequest)
            //{
            //    webRequest.Timeout = 30000;
            //    return true;
            //};

            //web.BrowserTimeout = new TimeSpan(0, 0, 1000);

            //doc = web.Load(url, "GET", null, CredentialCache.DefaultNetworkCredentials);

            //Pasamos la url al objeto web y el resultado, lo cargamos en el objeto doc
            doc = web.Load(url);            

            //Creamos el objeto documentNode Que se encarga de diferenciar cada una de las html tags
            HtmlNode documentNode = doc.DocumentNode;            

            //Creamos un objeto Lista de Nodes
            HtmlNodeCollection nodes = documentNode.SelectNodes(xpath);

            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    //El método InnerAtml del objeto node nos devuelve el texto del interior de la tag
                    string precioString = node.InnerHtml;
                    if (precioString != null)
                    {
                        valorBuscado = precioString;
                        Console.WriteLine(DateTime.Now.ToString() + " " + precioString);
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("");
                    }
                    //break;
                }
            }

            return valorBuscado;
        }
    }
}
