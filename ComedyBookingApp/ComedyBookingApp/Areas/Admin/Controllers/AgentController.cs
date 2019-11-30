using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComedyBookingApp.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ComedyBookingApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AgentController : Controller
    {
        private readonly IUnitofWork _unitofWork;

        public AgentController(IUnitofWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.LocationContact.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitofWork.Agent.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitofWork.Agent.Remove(objFromDb);
            _unitofWork.Save();
            return Json(new { success = true, message = "Deleted successfully." });
        }

        #endregion
    }
}