using CadastroContato.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace CadastroContato.WEB.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly string ENDPOINT = "https://localhost:7276/api/usuario";
        private readonly HttpClient httpClient = null;

        public UsuarioController() 
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ENDPOINT);
        }
        public async Task <IActionResult> Index()
        {
            try
            {
                List<ViewModel> usuario = null;

                HttpResponseMessage response = await httpClient.GetAsync(ENDPOINT);

                if (response.IsSuccessStatusCode)
                {
                  string content = await response.Content.ReadAsStringAsync();
                    usuario = JsonConvert.DeserializeObject<List<ViewModel>>(content);
                }
                else
                {
                    ModelState.AddModelError(null, "Erro ao processar solicitação");
                }

                return View(usuario);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
    }
}
