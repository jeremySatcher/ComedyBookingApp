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

        public IActionResult Upsert(int? id)
        {
            Agent agent = new Agent();
            if (id == null)
            {
                return View(agent);
            }
            agent = _unitofWork.Agent.Get(id.GetValueOrDefault());
            if (agent == null)
            {
                return NotFound();
            }
            return View(agent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(Agent agent)
        {
            if (ModelState.IsValid)
            {
                if (agent.Id == 0)
                {
                    _unitofWork.Agent.Add(agent);
                }
                else
                {
                    _unitofWork.Agent.Update(agent);
                }
                _unitofWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(agent);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.Agent.GetAll() });
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