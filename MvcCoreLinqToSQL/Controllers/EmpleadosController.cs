﻿using Microsoft.AspNetCore.Mvc;
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

        public IActionResult BuscadorEmpleados()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuscadorEmpleados(string oficio, int salario)
        {
            List<Empleado> empleados = this.repo.GetEmpleadosOficioSalario(oficio, salario);
            if (empleados==null)
            {
                ViewData["MENSAJE"]="No existen empleados con oficio "+oficio+" y salario superior a "+salario;
                return View();
            }
            else
            {
                return View(empleados);
            }
        }
        public IActionResult EmpleadosOficio()
        {
            ViewData["OFICIOS"]=this.repo.GetOficios();
            return View();
        }
        [HttpPost]
        public IActionResult EmpleadosOficio(string oficio)
        {
            ViewData["OFICIOS"]=this.repo.GetOficios();
            ResumenEmpleados resumen = this.repo.GetEmpleadosOficio(oficio);
            return View(resumen);
        }
    }
}
