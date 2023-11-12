using Data.Repoitories;
using Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Core.Types;

namespace Rezervasyon.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        AppointmentRepo _appo;
        DoctorRepo _drrepo;
        public AppointmentController(AppointmentRepo appo, DoctorRepo drrepo)
        {
            _appo = appo;
            _drrepo = drrepo;
        }
        public IActionResult Index()
        {
            ViewData["Doctorname"] = new SelectList(_drrepo.GetAll(), "DoctorId", "Name");

            List<Appointment> appoList = _appo.GetAll();
            return View(appoList);
        }
        public IActionResult AddAppo(int id) 
        {
            ViewData["DoctorName"] = new SelectList(_drrepo.GetAll(), "DoctorId", "Name");

            Appointment appo = new Appointment();
            if (id>0)
            {
                appo = _appo.GetAppoById(id);
            }
            return View(appo);
        }
        [HttpPost]
        public IActionResult AddAppo(Appointment appo)
        {
            _appo.InsertOrUpdate(appo);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _appo.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Appointment appo = _appo.GetAppoById(id);
            return View(appo);
        }

    }
}
