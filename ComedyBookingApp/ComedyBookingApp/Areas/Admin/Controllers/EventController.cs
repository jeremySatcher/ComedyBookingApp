using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ComedyBookingApp.DataAccess.Data.Repository.IRepository;
using ComedyBookingApp.Models;
using ComedyBookingApp.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComedyBookingApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController : Controller
    {

        private readonly IUnitofWork _unitofWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public EventController(IUnitofWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitofWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
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
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (eventVM.Event.Id == 0)
                {
                    //New Service
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\events");
                    var extension = Path.GetExtension(files[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStreams);
                    }
                    eventVM.Event.ImageUrl = @"\images\events\" + fileName + extension;

                    _unitofWork.Event.Add(eventVM.Event);
                }
                else
                {
                    //Edit Service
                    var serviceFromDb = _unitofWork.Event.Get(eventVM.Event.Id);
                    if (files.Count > 0)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        var uploads = Path.Combine(webRootPath, @"images\events");
                        var extension_new = Path.GetExtension(files[0].FileName);

                        var imagePath = Path.Combine(webRootPath, serviceFromDb.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }

                        using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension_new), FileMode.Create))
                        {
                            files[0].CopyTo(fileStreams);
                        }
                        eventVM.Event.ImageUrl = @"\images\events\" + fileName + extension_new;
                    }
                    else
                    {
                        eventVM.Event.ImageUrl = serviceFromDb.ImageUrl;
                    }

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
            string webRootPath = _hostEnvironment.WebRootPath;

            var imagePath = Path.Combine(webRootPath, eventFromDb.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

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