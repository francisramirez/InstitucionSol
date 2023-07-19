using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Application.Contract;
using School.Application.Dtos.Department;
using School.Infrastructure.Models;

namespace School.Web.Controllers
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

            var result = departamentService.Get();

            if (!result.Success)
                ViewBag.Message = result.Message;

            var departmets = (List<DepartmentModel>)result.Data;
            
            return View(departmets);
           
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            var result = departamentService.GetById(id);

            if (!result.Success)
                ViewBag.Message = result.Message;


            var departmet = (DepartmentModel)result.Data;

            return View(departmet);
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
            var result = departamentService.GetById(id);

            if (!result.Success)
                ViewBag.Message = result.Message;


            var departmet = (DepartmentModel)result.Data;

            return View(departmet);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentUpdateDto departmentUpdateDto)
        {
            try
            {
                var result = this.departamentService.Update(departmentUpdateDto);


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
