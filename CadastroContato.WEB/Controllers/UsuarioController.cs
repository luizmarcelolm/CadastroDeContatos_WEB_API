using CadastroContato.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Text;

namespace CadastroContato.WEB.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly string ENDPOINT = "https://localhost:7276/api/usuario/";
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

        public async Task<IActionResult> Detalhar(int id) 
        {
            try
            {
                ViewModel result = await Pesquisar(id);
                return View(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async Task<ViewModel> Pesquisar(int id)
        {
            try
            {
                ViewModel result = null;
                string url = $"{ENDPOINT}{id}";
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ViewModel>(content);
                }
              
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Create([Bind("Nome, Email, Celular")] ViewModel usuario) 
        {
            try
            {
                string json = JsonConvert.SerializeObject(usuario);
                byte[] buffer = Encoding.UTF8.GetBytes(json);
                ByteArrayContent bytecontent = new ByteArrayContent(buffer);
                bytecontent.Headers.ContentType = 
                    new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                string url = ENDPOINT;
                HttpResponseMessage response = 
                  await httpClient.PostAsync(url, bytecontent);

                if (!response.IsSuccessStatusCode)
                    ModelState.AddModelError(null, "Erro ao processar solicitação");

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                throw ex;
            }


            return View();
        }
    }
}
