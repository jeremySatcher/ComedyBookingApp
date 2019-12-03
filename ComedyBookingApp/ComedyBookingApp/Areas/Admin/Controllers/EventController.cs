using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ComedyBookingApp.DataAccess.Data.Repository.IRepository;
using ComedyBookingApp.Models;
using ComedyBookingApp.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ComedyBookingApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController : Controller
    {

        private readonly IUnitofWork _unitofWork;


        public EventController(IUnitofWork unitOfWork)
        {
            _unitofWork = unitOfWork;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            EventVM eventVM = new EventVM()
            {
                Event = new Models.Event(),
                LocationList = _unitofWork.Location.GetLocationListForDropDown()

            };
            if (id != null)
            {
                eventVM.Event = _unitofWork.Event.Get(id.GetValueOrDefault());
            }

            return View(eventVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(EventVM eventVM)
        {
            if (ModelState.IsValid)
            {
                if (eventVM.Event.Id == 0)
                {
                    _unitofWork.Event.Add(eventVM.Event);
                }
                else
                {
                    _unitofWork.Event.Update(eventVM.Event);
                }
                _unitofWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                eventVM.LocationList = _unitofWork.Location.GetLocationListForDropDown();
                return View(eventVM);
            }
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.Event.GetAll(includeProperties: "Location") });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var eventFromDb = _unitofWork.Event.Get(id);
            if (eventFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitofWork.Event.Remove(eventFromDb);
            _unitofWork.Save();
            return Json(new { success = true, message = "Deleted successfully." });
        }

        #endregion
    }
}