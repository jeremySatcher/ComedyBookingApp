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
    public class ComedianController : Controller
    {

        private readonly IUnitofWork _unitofWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ComedianController(IUnitofWork unitOfWork, IWebHostEnvironment hostEnvironment)
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
            ComedianVM comedianVM = new ComedianVM()
            {
                Comedian = new Models.Comedian(),
                AgentList = _unitofWork.Agent.GetAgentListForDropDown()

            };
            if (id != null)
            {
                comedianVM.Comedian = _unitofWork.Comedian.Get(id.GetValueOrDefault());
            }

            return View(comedianVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(ComedianVM comedianVM)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if(comedianVM.Comedian.Id == 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\comedians");
                    var extension = Path.GetExtension(files[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(uploads,fileName+extension),FileMode.Create))
                    {
                        files[0].CopyTo(fileStreams);
                    }
                    comedianVM.Comedian.ImageUrl = @"images\comedians\" + fileName + extension;

                    _unitofWork.Comedian.Add(comedianVM.Comedian);
                }
                else
                {
                    var comedianFromDb = _unitofWork.Comedian.Get(comedianVM.Comedian.Id);
                    if(files.Count > 0)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        var uploads = Path.Combine(webRootPath, @"images\comedians");
                        var extension_new = Path.GetExtension(files[0].FileName);

                        var imagePath = Path.Combine(webRootPath, comedianFromDb.ImageUrl.TrimStart('\\'));
                        if(System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }

                        using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension_new), FileMode.Create))
                        {
                            files[0].CopyTo(fileStreams);
                        }
                        comedianVM.Comedian.ImageUrl = @"images\comedians\" + fileName + extension_new;
                    }
                    else
                    {
                        comedianVM.Comedian.ImageUrl = comedianFromDb.ImageUrl;
                    }

                    _unitofWork.Comedian.Update(comedianVM.Comedian);
                }
                _unitofWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(comedianVM);
            }
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.Comedian.GetAll(includeProperties: "Agent") });
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