using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComedyBookingApp.DataAccess.Data.Repository.IRepository;
using ComedyBookingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComedyBookingApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LocationController : Controller
    {

        private readonly IUnitofWork _unitofWork;

        public LocationController(IUnitofWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Location location = new Location();
            if (id == null)
            {
                return View(location);
            }
            location = _unitofWork.Location.Get(id.GetValueOrDefault());
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(Location location)
        {
            if (ModelState.IsValid)
            {
                if (location.Id == 0)
                {
                    _unitofWork.Location.Add(location);
                }
                else
                {
                    _unitofWork.Location.Update(location);
                }
                _unitofWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.Location.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitofWork.Location.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitofWork.Location.Remove(objFromDb);
            _unitofWork.Save();
            return Json(new { success = true, message = "Deleted successfully." });
        }

        #endregion
    }
}