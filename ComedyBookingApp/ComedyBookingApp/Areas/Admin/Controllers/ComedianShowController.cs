using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ComedyBookingApp.DataAccess.Data.Repository.IRepository;
using ComedyBookingApp.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ComedyBookingApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ComedianShowController : Controller
    {
        private readonly IUnitofWork _unitOfWork;

        public ComedianShowController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            ComedianShowVM comedianshowVM = new ComedianShowVM()
            {
                ComedianShow = new Models.ComedianShow(),
                ComedianList = _unitOfWork.Comedian.GetComedianListForDropDown(),
                EventList = _unitOfWork.Event.GetEventListForDropDown()
            };
            if(id != null)
            {
                comedianshowVM.ComedianShow = _unitOfWork.ComedianShow.Get(id.GetValueOrDefault());
            }
            return View(comedianshowVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(ComedianShowVM comedianShowVM)
        {
            if (ModelState.IsValid)
            {
                if (comedianShowVM.ComedianShow.Id == 0)
                {
                    _unitOfWork.ComedianShow.Add(comedianShowVM.ComedianShow);
                }
                else
                {
                    _unitOfWork.ComedianShow.Update(comedianShowVM.ComedianShow);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(comedianShowVM);
            }
        }

        #region API Calls

        [HttpGet]

        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.ComedianShow.GetAll(includeProperties:"Comedian,Event")});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.ComedianShow.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitOfWork.ComedianShow.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted successfully." });
        }

        #endregion
    }
}