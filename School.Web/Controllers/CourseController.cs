using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using School.Application.Dtos.Course;
using School.Web.Models.Reponses;
using System.Text;

namespace School.Web.Controllers
{
    public class CourseController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        public CourseController(IConfiguration configuration)
        {
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };

        }
        // GET: CourseController
        public ActionResult Index()
        {
            CourseListReponse courseReponse = new CourseListReponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
             
                using (var response =  httpClient.GetAsync("http://localhost:5037/api/Course/GetCourses").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse =  response.Content.ReadAsStringAsync().Result;
                        courseReponse = JsonConvert.DeserializeObject<CourseListReponse>(apiResponse);
                    }


                }
            }
            return View(courseReponse.data);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            CourseDetailResponse courseDetailResponse = new CourseDetailResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                using (var response = httpClient.GetAsync("http://localhost:5037/api/Course/GetCourse?id=" + id).Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        courseDetailResponse = JsonConvert.DeserializeObject<CourseDetailResponse>(apiResponse);
                    }


                }
            }
            return View(courseDetailResponse.data);
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
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

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            CourseDetailResponse courseDetailResponse = new CourseDetailResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                using (var response = httpClient.GetAsync("http://localhost:5037/api/Course/GetCourse?id=" + id).Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        courseDetailResponse = JsonConvert.DeserializeObject<CourseDetailResponse>(apiResponse);
                    }


                }
            }
            return View(courseDetailResponse.data);
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseUpdateDto courseUpdateDto)
        {
            try
            {

                var courseAddResponse = new CourseAddResponse();

             

                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                  

                    StringContent content = new StringContent(JsonConvert.SerializeObject(courseUpdateDto), Encoding.UTF8, "application/json");

                    using (var response =  httpClient.PostAsync("http://localhost:5037/api/Course/Update", content).Result)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        var result = JsonConvert.DeserializeObject<CourseAddResponse>(apiResponse);
                    }
                }
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
    }
}
