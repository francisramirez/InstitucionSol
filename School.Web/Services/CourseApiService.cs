using Newtonsoft.Json;
using School.Application.Dtos.Course;
using School.Application.Dtos.Department;
using School.Infrastructure.Models;
using School.Web.Controllers;
using School.Web.Models.Reponses;
using System.Text;

namespace School.Web.Services
{
    public class CourseApiService : ICourseApiService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<CourseApiService> logger;
        private string baseUrl = string.Empty;
        public CourseApiService(IHttpClientFactory httpClientFactory,
                               IConfiguration configuration,
                               ILogger<CourseApiService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = configuration["ApiConfig:baseUrl"];
        }

        public CourseDetailResponse GetCourse(int id)
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
                            courseDetailResponse.success = false;
                            courseDetailResponse.message = "Error conectandose al api de curso";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                courseDetailResponse.success = false;
                courseDetailResponse.message = "Error obteniendo los cursos";
                this.logger.LogError($"{courseDetailResponse.message}", ex.ToString());

            }
            return courseDetailResponse;
        }

        public CourseListReponse GetCourses()
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


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                courseReponse.success = false;
                courseReponse.message = "Error obteniendo los cursos";
                this.logger.LogError($"{courseReponse.message}", ex.ToString());

            }
            return courseReponse;
        }

        public CourseSaveReponse Save(CourseAddDto courseAddDto)
        {
            CourseSaveReponse courseSaveReponse = new CourseSaveReponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(courseAddDto), Encoding.UTF8, "application/json");


                    using (var response = httpClient.PostAsync($"{this.baseUrl}/Course/Save", content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            courseSaveReponse = JsonConvert.DeserializeObject<CourseSaveReponse>(apiResponse);
                        }
                        else
                        {

                            // realizar x logica //
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                courseSaveReponse.success = false;
                courseSaveReponse.message = "Error guardando el curso.";
                this.logger.LogError($"{courseSaveReponse.message}", ex.ToString());
            }
            return courseSaveReponse;
        }

        public CourseUpdateResponse Update(CourseUpdateDto courseUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
    public class CourseApiHttpClientService : ICourseApiService
    {
        public CourseDetailResponse GetCourse(int id)
        {
            throw new NotImplementedException();
        }

        public CourseListReponse GetCourses()
        {
            throw new NotImplementedException();
        }

        public CourseSaveReponse Save(CourseAddDto courseAddDto)
        {
            throw new NotImplementedException();
        }

        public CourseUpdateResponse Update(CourseUpdateDto courseUpdateDto)
        {
            throw new NotImplementedException();
        }
    }

}
