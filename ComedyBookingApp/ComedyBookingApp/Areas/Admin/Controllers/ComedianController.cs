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
    public class ComedianController : Controller
    {

        private readonly IUnitofWork _unitofWork;

        public ComedianController(IUnitofWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Comedian comedian = new Comedian();
            if (id == null)
            {
                return View(comedian);
            }
            comedian = _unitofWork.Comedian.Get(id.GetValueOrDefault());
            if (comedian == null)
            {
                return NotFound();
            }
            return View(comedian);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(Comedian comedian)
        {
            if (ModelState.IsValid)
            {
                if (comedian.Id == 0)
                {
                    _unitofWork.Comedian.Add(comedian);
                }
                else
                {
                    _unitofWork.Comedian.Update(comedian);
                }
                _unitofWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(comedian);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.Comedian.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitofWork.Comedian.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitofWork.Comedian.Remove(objFromDb);
            _unitofWork.Save();
            return Json(new { success = true, message = "Deleted successfully." });
        }

        #endregion
    }
}