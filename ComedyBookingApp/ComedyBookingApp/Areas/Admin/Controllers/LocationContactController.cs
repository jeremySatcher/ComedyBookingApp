using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComedyBookingApp.DataAccess.Data.Repository.IRepository;
using ComedyBookingApp.Models;
using ComedyBookingApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ComedyBookingApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LocationContactController : Controller
    {
        
        private readonly IUnitofWork _unitofWork;

        public LocationContactController(IUnitofWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            LocationContactVM locationcontactVM = new LocationContactVM()
            {
                LocationContact = new Models.LocationContact(),
                LocationList = _unitofWork.Location.GetLocationListForDropDown(),
            };
            if (id != null)
            {
                locationcontactVM.LocationContact = _unitofWork.LocationContact.Get(id.GetValueOrDefault());
            }
            return View(locationcontactVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(LocationContactVM locationContactVM)
        {
            if(ModelState.IsValid)
            {
                if(locationContactVM.LocationContact.Id == 0)
                {
                    _unitofWork.LocationContact.Add(locationContactVM.LocationContact);
                }
                else
                {
                    _unitofWork.LocationContact.Update(locationContactVM.LocationContact);
                }
                _unitofWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(locationContactVM);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.LocationContact.GetAll(includeProperties: "Location") });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitofWork.LocationContact.Get(id);
            if(objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitofWork.LocationContact.Remove(objFromDb);
            _unitofWork.Save();
            return Json(new { success = true, message = "Deleted successfully." });
        }

        #endregion
    }
}