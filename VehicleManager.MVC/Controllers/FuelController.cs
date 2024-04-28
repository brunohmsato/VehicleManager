using Microsoft.AspNetCore.Mvc;
using VehicleManager.Application.Interfaces;
using VehicleManager.Domain.Models;

namespace VehicleManager.Web.Controllers
{
    public class FuelController(IFuelService fuelService) : Controller
    {
        private readonly IFuelService _fuelService = fuelService;

        [HttpGet]
        public ActionResult Index()
        {
            List<Fuel> fuels = _fuelService.GetAll();
            return View(fuels);
        }

        [HttpGet]
        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(Fuel fuel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _fuelService.Add(fuel);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(fuel);
                }
            }
            catch (Exception ex)
            {
                return View(fuel);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                if (id == null) return NotFound();

                var _result = _fuelService.GetById(id);

                if (_result is null) return NotFound();

                return View(_result);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Edit(Fuel fuel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _fuelService.Update(fuel);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(fuel);
                }
            }
            catch (Exception ex)
            {
                return View(fuel);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == null) return NotFound();

                var _result = _fuelService.GetById(id);

                if (_result is null) return NotFound();

                return View(_result);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _fuelService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
    }
}