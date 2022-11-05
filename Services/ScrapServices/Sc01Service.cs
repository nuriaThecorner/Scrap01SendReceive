using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Services.ScrapServices
{
    public class Sc01Service
    {
        public Sc01Service()
        {
            string url1 = "https://www.miro.es/electrodomesticos/frigorificos-y-congeladores/frigorifico-combi/combi-bosch-kgn39awep.html";
            string xpath1 = "//span[@class='regular-price']//span[@class='price']";
            string url2 = "https://www.euronics.es/samsung-qe55q65bauxxc-televisor.html";
            string xpath2 = "//div[@class='sale-price']//p[@class='price']";
            string url3 = "https://www.bazarelregalo.com/destacados/lavadora-hoover-hwp610ambc1s.html";
            string xpath3 = "//span[@class='regular-price']//span[@class='price']";
            
            string valorBuscado = null;

            valorBuscado = EnviarYRecibir(url1, xpath1);

            Console.WriteLine(valorBuscado);

            valorBuscado = EnviarYRecibir(url2, xpath2);

            Console.WriteLine(valorBuscado);

            valorBuscado = EnviarYRecibir(url3, xpath3);

            Console.WriteLine(valorBuscado);

            Console.ReadLine();
        }

        private string EnviarYRecibir(string url, string xpath)
        {
            ScSendReceiveService scSendReceiveService = new ScSendReceiveService();
            string valorBuscado = scSendReceiveService.EnviarYRecibir(url, xpath);

            return valorBuscado;
        }
    }
}
