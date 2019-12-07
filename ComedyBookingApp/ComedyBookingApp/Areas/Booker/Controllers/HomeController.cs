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
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitofWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;


        public HomeController(ILogger<HomeController> logger, IUnitofWork unitofWork, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _unitOfWork = unitofWork;
            _hostEnvironment = hostEnvironment;

        }

        public IActionResult Index()
        {
            var HomeVM = new HomeViewModel()
            {
                ComedianList = _unitOfWork.Comedian.GetAll(),
            };

            return View(HomeVM);
        }

        public IActionResult Upsert(int id)
        {
            ComedianShowVM comedianshowVM = new ComedianShowVM()
            {
                ComedianShow = new Models.ComedianShow(),
                ComedianList = _unitOfWork.Comedian.GetOneComedianForDropDown(id),
                EventList = _unitOfWork.Event.GetEventListForDropDown(),
                Comedian = _unitOfWork.Comedian.Get(id)
        };
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

        public IActionResult NewEvent(int? id)
        {
            EventVM eventVM = new EventVM()
            {
                Event = new Models.Event(),
                LocationList = _unitOfWork.Location.GetLocationListForDropDown()

            };
            if (id != null)
            {
                eventVM.Event = _unitOfWork.Event.Get(id.GetValueOrDefault());
            }

            return View(eventVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult NewEvent(EventVM eventVM)
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

        [Authorize(Roles = Booker.BookerRole)]
        public IActionResult Privacy()
        {
            return View();
        }
        //Is this just a cart function??
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
