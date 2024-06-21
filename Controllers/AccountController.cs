using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace StoreApp.Controllers
{
    public class AccountController : Controller
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public AccountController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        //[ValidateAntiForgeryToken
        public async Task<ActionResult> Login(string email, string password)
        {
            var user = new
            {
                email = email,
                password = password
            };

            string json = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            // Указываем URL API Gateway, который пересылает запросы к auth сервису
            HttpResponseMessage response = await _httpClient.PostAsync("https://localhost:7064/auth/Authentication/Login", content);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                // Обрабатываем полученные данные, например, сохраняем токен и перенаправляем пользователя
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Обработка ошибки, возврат на страницу входа с сообщением об ошибке
                ModelState.AddModelError("", "Неверный email или пароль");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        //POST: Account/Register
        [HttpPost]
       // [ValidateAntiForgeryToken
        public async Task<IActionResult> Register(string name, string email, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) 
            {
                ModelState.AddModelError("", "Пожалуйста, заполните все поля");
                return View();
            }

            var user = new
            {
                Name = name,
                Email = email,
                Password = password
            };

            string json = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            string authApiUrl = _configuration.GetValue<string>("AuthApiUrl");
            HttpResponseMessage response = await _httpClient.PostAsync($"{authApiUrl}Authentication/Registration", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ConfirmEmail");
            }
            else
            {
                ModelState.AddModelError("", "Ошибка при регистрации");
                return View();
            }
        }
        // GET: Account/ConfirmEmail
        public ActionResult ConfirmEmail()
        {
            return View();
        }

        // GET: Account/ConfirmEmail?userId={userId}&code={code}
        [HttpGet]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            string authApiUrl = _configuration.GetValue<string>("AuthApiUrl");
            HttpResponseMessage response = await _httpClient.GetAsync($"{authApiUrl}Authentication/ConfirmEmail?userId={userId}&code={code}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ConfirmEmailResult", "Account", new { success = true });
            }
            else
            {
                // Отображение страницы с сообщением об ошибке
                return View("ConfirmEmailResult", "Письмо с ссылкой для подтверждения отправлено на указанную почту");
            }

        }

    }
}
