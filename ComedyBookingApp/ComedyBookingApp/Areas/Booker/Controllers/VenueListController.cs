using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ComedyBookingApp.Models;
using Microsoft.AspNetCore.Authorization;
using ComedyBookingApp.DataAccess.Data.Repository.IRepository;
using ComedyBookingApp.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ComedyBookingApp.Controllers
{
    [Area("Booker")]
    public class VenueListController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IUnitofWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;


        public VenueListController(ILogger<HomeController> logger, IUnitofWork unitofWork, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _unitOfWork = unitofWork;
            _hostEnvironment = hostEnvironment;

        }

        public IActionResult Index()
        {
            var LocationListVM = new VenueListVM()
            {
                LocationList = _unitOfWork.Location.GetAll()
            };

            return View(LocationListVM);
        }

        public IActionResult Upsert(int id)
        {
            EventVM eventVM = new EventVM()
            {
                Event = new Models.Event(),
                LocationList = _unitOfWork.Location.GetOneLocationForDropDown(id),
                Location = _unitOfWork.Location.Get(id)

            };

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

                    _unitOfWork.Event.Add(eventVM.Event);
                }
                else
                {
                    //Edit Service
                    var serviceFromDb = _unitOfWork.Event.Get(eventVM.Event.Id);
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

                    _unitOfWork.Event.Update(eventVM.Event);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            else
            {
                eventVM.LocationList = _unitOfWork.Location.GetLocationListForDropDown();
                return View(eventVM);
            }

        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Event.GetAll(includeProperties: "Location") });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var eventFromDb = _unitOfWork.Event.Get(id);
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

            _unitOfWork.Event.Remove(eventFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted successfully." });
        }

        #endregion
    }
}
