using Microsoft.AspNetCore.Mvc;
using MvcCoreLinqToSQL.Models;
using MvcCoreLinqToSQL.Repositories;

namespace MvcCoreLinqToSQL.Controllers
{
    public class EmpleadosController : Controller
    {

        RepositoryEmpleados repo;

        public EmpleadosController()
        {
            this.repo=new RepositoryEmpleados();
        }
        public IActionResult Index()
        {
            List<Empleado> empleados = this.repo.GetEmpleados();
            return View(empleados);
        }

        public IActionResult Details(int idEmpleado)
        {
            Empleado empleado = this.repo.FindEmpleado(idEmpleado);
            return View(empleado);
        }
    }
}
