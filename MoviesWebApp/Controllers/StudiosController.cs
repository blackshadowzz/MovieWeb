using Microsoft.AspNetCore.Mvc;
using MoviesWebApp.Data;
using MoviesWebApp.Models;
using MoviesWebApp.Repositories;
using System.Data;

namespace MoviesWebApp.Controllers
{
    public class StudiosController : Controller
    {
        private IStudioRepository _studioRepository;

        public StudiosController(IStudioRepository studioRepository)
        {
            _studioRepository = studioRepository;
        }
        public IActionResult Index()
        {
            var studios= _studioRepository.GetAll();
            return View(studios);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Studio studio)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _studioRepository.NewStudio(studio);
                    _studioRepository.Save();
                }
                catch (DBConcurrencyException)
                {
                   throw;
                }
               
                TempData["success"] = "Created studio successfully!";
                return RedirectToAction("Index");
            }
           
            return View(studio);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var studio=_studioRepository.GetId(id);
            return View(studio);
        }
        [HttpPost]
        public IActionResult Edit(Studio studio)
        {
            if (ModelState.IsValid)
            {
                _studioRepository.UpdateStudio(studio);
                _studioRepository.Save();
                TempData["success"] = "Updated studio successfully!";
                return RedirectToAction("Index");
            }
            return View(studio);
        }
        public IActionResult Details(int id)
        {
            var studio= _studioRepository.GetId(id);
            if(studio==null) return NotFound();
            return View(studio);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var studio = _studioRepository.GetId(id);
            if(studio == null) return NotFound();

            _studioRepository.DeleteStudio(id);
            _studioRepository.Save();
            TempData["success"] = "Deleted studio successfully!";
            return RedirectToAction("Index");

        }
    }
}
