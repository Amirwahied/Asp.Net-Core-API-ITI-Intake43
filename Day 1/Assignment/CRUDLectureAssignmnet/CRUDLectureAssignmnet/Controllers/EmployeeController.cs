using CRUDLectureAssignmnet.Core.DTO;
using CRUDLectureAssignmnet.Core.Interface;
using CRUDLectureAssignmnet.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDLectureAssignmnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public EmployeeController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost]
        public IActionResult Create(EmployeeDTO employee)
        {
            try
            {
                _uow.Employees.Create(employee.ToEmployee());
                _uow.Save();
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, EmployeeDTO employee)
        {
            try
            {
                _uow.Employees.Update(employee.ToEmployee(id));
                _uow.Save();
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _uow.Employees.GetById(id);
                if (item != null)
                {
                    _uow.Employees.Delete(item);
                    _uow.Save();
                    return Ok("Deleted");
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_uow.Employees.GetAll());

        //Constraint to prevent ambiguous with GetByName
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var item = _uow.Employees.GetById(id);
            return item is null ? NotFound() : Ok(item);
        }

        //Constraint to prevent ambiguous with GetById
        [HttpGet("{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            var item = _uow.Employees.GetByCriteria(emp => emp.Name == name);
            return item is null ? NotFound() : Ok(item);
        }

        //Literal segment to prevent ambiguous with GetById
        [HttpGet("Salary/{salary:decimal}")]
        public IActionResult GetBySalary(decimal salary)
        {
            var item = _uow.Employees.GetByCriteria(emp => emp.Salary == salary);
            return item is null ? NotFound() : Ok(item);
        }

    }
}
