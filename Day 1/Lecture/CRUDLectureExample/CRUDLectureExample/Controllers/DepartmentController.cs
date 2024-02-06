using CRUDLectureExample.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDLectureExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        //TODO: Inject Repository Pattern
        public DepartmentController(ApplicationDbContext context)
        {
            this._context = context;
        }

        //CRUD

        [HttpGet]
        //retrieving all items
        public IActionResult Get()
        {
            List<Department> departments = _context.Departments.ToList();
            return Ok(departments);
        }

        [HttpGet("{id:int}")]
        //retrieving one item by id
        public IActionResult GetById(int id)
        {
            Department department = _context.Departments.FirstOrDefault(x => x.Id == id);
            return department is null ? NotFound() : Ok(department);
        }

        [HttpGet("{name:alpha}")]
        //retrieving one item by name
        public IActionResult GetByName(string name)
        {
            Department department = _context.Departments.FirstOrDefault(x => x.Name == name);
            return department is null ? NotFound() : Ok(department);
        }
        [HttpGet("Manager/{manager:alpha}")]
        //retrieving one item by manager
        public IActionResult GetByManagerName(string manager)
        {
            Department department = _context.Departments.FirstOrDefault(x => x.ManagerName == manager);
            return department is null ? NotFound() : Ok(department);
        }

        [HttpPost]
        //add new item to database
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return Ok("Created");//or Create();
            }
            // in case data in request body not valid then return Status Code BadRequest
            return BadRequest(ModelState);
        }


        [HttpPut("{id}")]
        //updating one item by id
        public IActionResult Update(int id, Department department)
        {
            if (ModelState.IsValid)
            {
                Department orgDep = _context.Departments.FirstOrDefault(x => x.Id == id);
                orgDep.Name = department.Name;
                orgDep.ManagerName = department.ManagerName;
                _context.SaveChanges();
                return Ok("Updated");//or NoContent();
            }
            // in case data in request body not valid then return Status Code BadRequest
            return BadRequest(ModelState);
        }


        [HttpDelete("{id}")]
        //deleting item by id
        public IActionResult Delete(int id)
        {
            try
            {
                Department orgDep = _context.Departments.FirstOrDefault(x => x.Id == id);
                _context.Remove(orgDep);
                _context.SaveChanges();
                return Ok("Deleted");//or NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
