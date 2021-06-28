using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIService.Models;

namespace WebAPIService.Controllers
{
    public class DepartmentsController : ApiController
    {
        Department[] departments = new Department[]
        {
        new Department { Id = 1, Name = "Чай Ахмат", Description = "Бакалея" },
        new Department { Id = 2, Name = "Кукла Барби", Description = "Игрушки" },
        new Department { Id = 3, Name = "Дрель Интерскол", Description = "Инструменты"}
        };
        public IEnumerable<Department> GetAllProducts()
        {
            return departments;
        }
        public IHttpActionResult GetDepartment(int id)
        {
            var department = departments.FirstOrDefault((p) => p.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

    }
}
