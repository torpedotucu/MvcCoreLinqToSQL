using Microsoft.AspNetCore.Mvc;
using MvcCoreLinqToSQL.Models;
using MvcCoreLinqToSQL.Repositories;

namespace MvcCoreLinqToSQL.Controllers
{
    public class EnfermosController : Controller
    {
        RepositoryEnfermos repo;

        public EnfermosController()
        {
            this.repo=new RepositoryEnfermos();
        }
        public IActionResult Index()
        {
            List<Enfermo> enfermos = this.repo.GetEnfermos();
            return View(enfermos);
        }
        public IActionResult Details(string idEnfermo)
        {
            Enfermo enfermo = this.repo.GetEnfermo(idEnfermo);
            return View(enfermo);
        }

        public async Task<IActionResult>Delete(string idEnfermo)
        {
            await this.repo.DeleteEnfermoAsync(idEnfermo);
            return RedirectToAction("Index");
        }
    }
}
