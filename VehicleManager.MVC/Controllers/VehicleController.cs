using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VehicleManager.Application.Interfaces;
using VehicleManager.Domain.Models;

namespace VehicleManager.Web.Controllers
{
    public class VehicleController(IVehicleService vehicleService,
        IFuelService fuelService,
        IColorService colorService) : Controller
    {
        private readonly IVehicleService _vehicleService = vehicleService;
        private readonly IFuelService _fuelService = fuelService;
        private readonly IColorService _colorService = colorService;

        [HttpGet]
        public IActionResult Index()
        {
            List<Vehicle> vehicles = _vehicleService.GetAll();
            return View(vehicles);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var fuels = _fuelService.GetAll();
            var colors = _colorService.GetAll();

            ViewData["Fuels"] = new SelectList(fuels, "Id", "Description");
            ViewData["Colors"] = new SelectList(colors, "Id", "Description");

            return View();
        }

        [HttpPost]
        public IActionResult Add(Vehicle vehicle, IFormFile imageFile)
        {
            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    using var ms = new MemoryStream();
                    imageFile.CopyTo(ms);
                    vehicle.VehicleImage = ms.ToArray();
                }

                _vehicleService.Add(vehicle);
                return RedirectToAction("Index");
            }
			catch (Exception ex)
            {
                return View(vehicle);
            }
        }

			[HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                if (id == null) return NotFound();

                var _result = _vehicleService.GetById(id);

                if (_result is null) return NotFound();

                var fuels = _fuelService.GetAll();
                var colors = _colorService.GetAll();

                ViewData["Fuels"] = new SelectList(fuels, "Id", "Description");
                ViewData["Colors"] = new SelectList(colors, "Id", "Description");

                return View(_result);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Edit(Vehicle vehicle, IFormFile imageFile)
        {
            try
            {
				if (imageFile != null && imageFile.Length > 0)
				{
					using var ms = new MemoryStream();
					imageFile.CopyTo(ms);
					vehicle.VehicleImage = ms.ToArray();
				}

				_vehicleService.Update(vehicle);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(vehicle);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == null) return NotFound();

                var _result = _vehicleService.GetById(id);

                if (_result is null) return NotFound();

                var fuels = _fuelService.GetAll();
                var colors = _colorService.GetAll();

                ViewData["Fuels"] = new SelectList(fuels, "Id", "Description");
                ViewData["Colors"] = new SelectList(colors, "Id", "Description");

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
                _vehicleService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

    


    }
}
