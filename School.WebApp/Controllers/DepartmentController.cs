using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Application.Contract;
using School.Application.Dtos.Department;
using School.WebApp.Models;

namespace School.WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartamentService departamentService;

        public DepartmentController(IDepartamentService departamentService)
        {
            this.departamentService = departamentService;
        }

        // GET: DepartmentController
        public ActionResult Index()
        {
            var result = this.departamentService.Get();

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var deparments = ((List<Infrastructure.Models.DepartmentModel>)result.Data)
                                                  .Select(cd => new Models.DepartmentModel()
                                                  {

                                                      Administrator = cd.Administrator.Value, 
                                                      DepartmentId = cd.DepartmentId, 
                                                      Name= cd.Name,
                                                      Budget = cd.Budget, 
                                                      StartDate = cd.StartDate.ToString("dd/MM/yyyy")
                                                  }).ToList();

            return View(deparments);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            var result = this.departamentService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var depto = (Infrastructure.Models.DepartmentModel)result.Data;

            var deptModel = new Models.DepartmentModel()
            {

                Administrator = depto.Administrator.Value,
                DepartmentId = depto.DepartmentId,
                Name = depto.Name,
                Budget = depto.Budget,
                StartDate = depto.StartDate.ToString("dd/MM/yyyy")
            };

            return View(deptModel);
            
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentAddDto departmentAddDto)
        {
            try
            {
                var result = this.departamentService.Save(departmentAddDto);

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }



                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {


            var result = this.departamentService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var depto = (Infrastructure.Models.DepartmentModel)result.Data;

            var deptModel = new Models.DepartmentModel()
            {

                Administrator = depto.Administrator.Value,
                DepartmentId = depto.DepartmentId,
                Name = depto.Name,
                Budget = depto.Budget,
                StartDate = depto.StartDate.ToString("dd/MM/yyyy")
            };

            return View(deptModel);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentUpdateDto departmentUpdate)
        {
            try
            {
                var result = this.departamentService.Update(departmentUpdate);

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
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
