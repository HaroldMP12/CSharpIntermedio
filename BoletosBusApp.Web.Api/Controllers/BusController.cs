using BoletosBusApp.Web.Api.Models;
u

using Microsoft.AspNetCore.Mvc;

namespace BoletosBusApp.Web.Api.Controllers
{
    public class BusController : Controller
    {

        // GET: BusController
        public async Task<IActionResult> Index()
        {
            BusGetAllResultModel busGetAllResultModel = new BusGetAllResultModel();

            using (HttpClient client = new HttpClient())
            {
                string urlBase = "http://localhost:5276/api/";

                client.BaseAddress = new Uri(urlBase);

                var responseTask = await client.GetAsync("Bus/GetBuses");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();

                    busGetAllResultModel = JsonConvert.DeserializeObject<BusGetAllResultModel>(response);

                }
                else
                {
                    string response = await responseTask.Content.ReadAsStringAsync();

                    ViewBag.Message = "";
                    return View();
                }



            }
            return View(busGetAllResultModel.result);
        }

        // GET: BusController/Details/5
        public async Task<IActionResult> Details(int id)
        {

            BusGetByIdResultModel busGetByIdResult = new BusGetByIdResultModel();

            using (HttpClient client = new HttpClient())
            {
                string urlBase = "http://localhost:5276/api/";

                client.BaseAddress = new Uri(urlBase);

                var responseTask = await client.GetAsync($"Bus/GetBusById?id={id}");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();

                    busGetByIdResult = JsonConvert.DeserializeObject<BusGetByIdResultModel>(response);

                }
                else
                {
                    string response = await responseTask.Content.ReadAsStringAsync();

                    busGetByIdResult = JsonConvert.DeserializeObject<BusGetByIdResultModel>(response);

                    return View(busGetByIdResult);
                }



            }

            return View(busGetByIdResult);
        }

        // GET: BusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BusController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            BusGetByIdResultModel busGetByIdResult = new BusGetByIdResultModel();

            using (HttpClient client = new HttpClient())
            {
                string urlBase = "http://localhost:5276/api/";

                client.BaseAddress = new Uri(urlBase);

                var responseTask = await client.GetAsync($"Bus/GetBusById?id={id}");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();

                    busGetByIdResult = JsonConvert.DeserializeObject<BusGetByIdResultModel>(response);

                }
                else
                {
                    string response = await responseTask.Content.ReadAsStringAsync();

                    busGetByIdResult = JsonConvert.DeserializeObject<BusGetByIdResultModel>(response);

                    return View(busGetByIdResult);
                }



            }

            return View(busGetByIdResult.result);
        }

        // POST: BusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdteBusModel updteBus)
        {
            ApiBaseModel apiBaseModel = new ApiBaseModel();
            try
            {
                string url = "http://localhost:5276/api/";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    updteBus.fechaCambio = DateTime.Now;
                    updteBus.usuarioId = 1;

                    var responseTask = await client.PutAsJsonAsync<UpdteBusModel>("Bus/UpdateBus", updteBus);

                    if (responseTask.IsSuccessStatusCode)
                    {
                        string response = await responseTask.Content.ReadAsStringAsync();

                        apiBaseModel = JsonConvert.DeserializeObject<ApiBaseModel>(response);


                        if (!apiBaseModel.success)
                        {
                            ViewBag.Message = apiBaseModel.message;
                            return View();

                        }
                        else
                        {

                            return RedirectToAction(nameof(Index));
                        }
                    }
                    else
                    {
                        string response = await responseTask.Content.ReadAsStringAsync();
                        apiBaseModel = JsonConvert.DeserializeObject<ApiBaseModel>(response);

                        ViewBag.Message = apiBaseModel.message;
                        return View();
                    }


                }

            }
            catch
            {
                return View();
            }
        }
    }
}
