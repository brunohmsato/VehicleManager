using Microsoft.AspNetCore.Mvc;
using VehicleManager.Application.Interfaces;
using VehicleManager.Domain.Models;

namespace VehicleManager.Web.Controllers
{
    public class ColorController(IColorService colorService) : Controller
    {
        private readonly IColorService _colorService = colorService;

        [HttpGet]
        public ActionResult Index()
        {
            List<Color> colors = _colorService.GetAll();
            return View(colors);
        }

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(Color color)
        {
            try
            {
				throw new Exception("Erro simulado durante a adição da cor");

				if (ModelState.IsValid)
                {
                    _colorService.Add(color);
                    return RedirectToAction("Index");
                }
                else
                {
					return View(color);
                }
            }
            catch (Exception)
            {
				return RedirectToAction("Error", "Home");
			}
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                if (id == null) return NotFound();

                var _result = _colorService.GetById(id);

                if (_result is null) return NotFound();

                return View(_result);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Edit(Color color)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _colorService.Update(color);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(color);
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == null) return NotFound();

                var _result = _colorService.GetById(id);

                if (_result is null) return NotFound();

                return View(_result);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _colorService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}