using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataContextLayer.DataContext;
using Lets_get_lunch_Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Lets_Get_Lunch_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }


    public class DepartmentsController : Controller
    {

        EFDataContext _dbContext = new EFDataContext();

        public IActionResult Index()
        {
            List<Department> data = this._dbContext.Departments.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department model)
        {
            ModelState.Remove("DepartmentId");
            if (ModelState.IsValid)
            {
                _dbContext.Departments.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            Department data = _dbContext.Departments.Where(p => p.DepartmentId == id).FirstOrDefault();
            return View("Create", data);
        }

        [HttpPost]
        public IActionResult Edit(Department model)
        {
            ModelState.Remove("DepartmentId");
            if (ModelState.IsValid)
            {
                _dbContext.Departments.Update(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", model);
        }

        public IActionResult Delete(int id)
        {
            Department data = _dbContext.Departments.Where(p => p.DepartmentId == id).FirstOrDefault();
            if (data != null)
            {
                _dbContext.Departments.Remove(data);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }


}
