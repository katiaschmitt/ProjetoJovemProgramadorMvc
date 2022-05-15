using JovemProgramadorMVC2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JovemProgramadorMVC2.Controllers
{
    public class ProfessoraController : Controller
    {
        private readonly IConfiguration _configuration;
        public ProfessoraController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BuscarEnderecoP(string cep)
        {
            EnderecoModel enderecoModel = new();

            try
            {
                cep = cep.Replace("-", "");

                using var client = new HttpClient();
                var result = await client.GetAsync(_configuration.GetSection("ApiCep")["BaseUrl"] + cep + "/json");

                if (result.IsSuccessStatusCode)
                {
                    enderecoModel = JsonSerializer.Deserialize<EnderecoModel>(
                        await result.Content.ReadAsStringAsync(), new JsonSerializerOptions() { });

                    if (enderecoModel.complemento == "")
                    {
                        enderecoModel.complemento = "Nenhum";
                    }
                }
                else
                {
                    ViewData["Mensagem"] = "Erro na busca do endereço!";
                    return View("Index");
                }


            }
            catch (Exception e)
            {
                ViewData["Mensagem"] = "Erro na requisição!";
                return View("Index");
            }

            return View("BuscarEnderecoP", enderecoModel);
        }
    

    }
}


