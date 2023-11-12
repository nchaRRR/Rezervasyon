using Data.Repoitories;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Rezervasyon.Controllers
{
    public class DoctorController : Controller
    {
        DoctorRepo _drrepo;
        public DoctorController(DoctorRepo drrepo)
        {
            _drrepo = drrepo;
        }
        public IActionResult Index()
        {
            List<Doctor> drList=_drrepo.GetAll();
            return View(drList);
        }
        public IActionResult AddDoctor(int id)
        {
            Doctor doctor = new Doctor();
            if (id>0)
            {
                doctor = _drrepo.GetDoctorById(id);
            }
            return View(doctor);
        }
        [HttpPost]
        public IActionResult AddDoctor(Doctor dr)
        {
            _drrepo.InsertOrUpdate(dr);
            return RedirectToAction("Index");
        }

    }
}
