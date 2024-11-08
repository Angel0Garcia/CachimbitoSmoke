using CachimbitoSmoke.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CachimbitoSmoke.Controllers
{
    public class ProductoController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductoController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7191/api");
        }

        public async Task<IActionResult>Index()
        {
            var response = await _httpClient.GetAsync("api/Productos/lista");

            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var productos = JsonConvert.DeserializeObject<IEnumerable<ProductoViewModel>>(content);
                return View("Index", productos);
            }

            return View(new List<ProductoViewModel>());

        }
        
    }
}
