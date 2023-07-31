using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using School.Web.Models.Reponses;

namespace School.Web.Controllers
{
    public class CursoController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<CursoController> logger;
        private string baseUrl = string.Empty;
        public CursoController(IHttpClientFactory httpClientFactory,
                               IConfiguration configuration,
                               ILogger<CursoController> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["ApiConfig:baseUrl"];
        }
        // GET: CursoController
        public ActionResult Index()
        {
            CourseListReponse courseReponse = new CourseListReponse();


            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = httpClient.GetAsync($"{this.baseUrl}/Course/GetCourses").Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            courseReponse = JsonConvert.DeserializeObject<CourseListReponse>(apiResponse);
                        }
                        else
                        {
                            // realizar x logica //
                            ViewBag.Message = courseReponse.message;
                            return View();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo los cursos", ex.ToString());
                return View();
            }


            return View(courseReponse.data);
        }

        // GET: CursoController/Details/5
        public ActionResult Details(int id)
        {
            CourseDetailResponse courseDetailResponse = new CourseDetailResponse();


            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = httpClient.GetAsync($"{this.baseUrl}/Course/GetCourse?id={ id }").Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            courseDetailResponse = JsonConvert.DeserializeObject<CourseDetailResponse>(apiResponse);
                        }
                        else
                        {
                            // realizar x logica //
                            ViewBag.Message = courseDetailResponse.message;
                            return View();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo los cursos", ex.ToString());
                return View();
            }

            return View(courseDetailResponse.data);
        }

        // GET: CursoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CursoController/Create
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

        // GET: CursoController/Edit/5
        public ActionResult Edit(int id)
        {
            CourseDetailResponse courseDetailResponse = new CourseDetailResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = httpClient.GetAsync($"{this.baseUrl}/Course/GetCourse?id={id}").Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            courseDetailResponse = JsonConvert.DeserializeObject<CourseDetailResponse>(apiResponse);
                        }
                        else
                        {
                            // realizar x logica //
                            ViewBag.Message = courseDetailResponse.message;
                            return View();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo los cursos", ex.ToString());
                return View();
            }

            return View(courseDetailResponse.data);
        }

        // POST: CursoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

    }
}
