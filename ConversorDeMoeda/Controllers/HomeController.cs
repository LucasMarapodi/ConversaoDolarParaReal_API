using ConversorDeMoeda.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConversorDeMoeda.Controllers
{
    public class HomeController : Controller
    {


        public async Task<IActionResult> Index()
         {
             var httpClient = new HttpClient();

             var json = httpClient.GetStringAsync("https://economia.awesomeapi.com.br/last/USD-BRL");

             await json;

            dynamic data = JObject.Parse(json.Result);

            //Valores da API
            double high = Convert.ToDouble(data.USDBRL.high);
            double low = Convert.ToDouble(data.USDBRL.low);


            ValorModel valorModel = new ValorModel();

            //Media dos Valores da API
            valorModel.ValorReal = Math.Round(((high + low) /2),2).ToString();





            return View(valorModel);
        }

        [HttpPost]
        public IActionResult index(ValorModel valorModel)
        {


            if (ModelState.IsValid)
            {
                try
                {

                    //valorModel.ValorConvertido = (float.Parse(valorModel.ValorDolar) * float.Parse(valorModel.ValorReal)).ToString();

                    valorModel.ValorConvertido = Math.Round((float.Parse(valorModel.ValorDolar) * float.Parse(valorModel.ValorReal)),2).ToString(); ;
                 }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = "Erro: " +  e.Message;
                }
            }
           


            return View(valorModel);
        }

    }
}
