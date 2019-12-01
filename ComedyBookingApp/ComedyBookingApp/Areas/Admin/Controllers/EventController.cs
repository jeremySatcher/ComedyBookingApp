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
            Event show = new Event();
            if (id == null)
            {
                return View(show);
            }
            show = _unitofWork.Event.Get(id.GetValueOrDefault());
            if (show == null)
            {
                return NotFound();
            }
            return View(show);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(Event show)
        {
            if (ModelState.IsValid)
            {
                if (show.Id == 0)
                {
                    _unitofWork.Event.Add(show);
                }
                else
                {
                    _unitofWork.Event.Update(show);
                }
                _unitofWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(show);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.Event.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitofWork.Event.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitofWork.Event.Remove(objFromDb);
            _unitofWork.Save();
            return Json(new { success = true, message = "Deleted successfully." });
        }

        #endregion
    }
}