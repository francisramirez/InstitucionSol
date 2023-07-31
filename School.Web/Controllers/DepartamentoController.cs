using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using School.Application.Dtos.Course;
using School.Application.Dtos.Department;
using School.Web.Models.Reponses;
using System.Text;

namespace School.Web.Controllers
{
    public class DepartamentoController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        public DepartamentoController(IConfiguration configuration)
        {
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };

        }
        // GET: DepartamentoController
        public ActionResult Index()
        {
            DepartmentListResponse departmentList = new DepartmentListResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                using (var response = httpClient.GetAsync("http://localhost:5037/api/Department").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        departmentList = JsonConvert.DeserializeObject<DepartmentListResponse>(apiResponse);
                    }


                }
            }



            return View(departmentList.data);
        }

        // GET: DepartamentoController/Details/5
        public ActionResult Details(int id)
        {
            DepartmentDetailResponse departmentDetail = new DepartmentDetailResponse();
           
            
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                using (var response = httpClient.GetAsync($"http://localhost:5037/api/Department/{ id }").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        departmentDetail = JsonConvert.DeserializeObject<DepartmentDetailResponse>(apiResponse);
                    }


                }
            }



            return View(departmentDetail.data);
        }

        // GET: DepartamentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartamentoController/Create
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

        // GET: DepartamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            DepartmentDetailResponse departmentDetail = new DepartmentDetailResponse();


            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                using (var response = httpClient.GetAsync($"http://localhost:5037/api/Department/{id}").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        departmentDetail = JsonConvert.DeserializeObject<DepartmentDetailResponse>(apiResponse);
                    }

                }
            }


            return View(departmentDetail.data);
        }

        // POST: DepartamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentUpdateDto departmentUpdateDto)
        {
            try
            {
                var departmentUpdateResponse = new DepartmentUpdateResponse();

                using (var httpClient = new HttpClient(this.httpClientHandler))
                {

                    StringContent content = new StringContent(JsonConvert.SerializeObject(departmentUpdateDto), Encoding.UTF8, "application/json");

                    using (var response = httpClient.PostAsync("http://localhost:5037/api/Department/Update", content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            var result = JsonConvert.DeserializeObject<DepartmentUpdateResponse>(apiResponse);

                            if (!result.success)
                            {
                                ViewBag.Message = result.message;
                                return View();
                            }
                            return RedirectToAction(nameof(Index));

                        }
                        else
                        {
                            ViewBag.Message = "Error actualizando el departamento";
                            return View();
                        }


                       
                    }
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: DepartamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
