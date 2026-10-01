using HospitalAppointmentManagement.Extensions;
using HospitalAppointmentManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace HospitalAppointmentManagement.Controllers;

public class DoctorController : Controller
{
    private readonly IMemoryCache _cache;

    private static readonly List<Doctor> Doctors = new()
    {
        new Doctor { DoctorId = 1, DoctorName = "Dr. A. Sharma", Specialization = "Cardiologist", Experience = 12, ConsultationFee = 800 },
        new Doctor { DoctorId = 2, DoctorName = "Dr. Neha Patel", Specialization = "Dermatologist", Experience = 8, ConsultationFee = 600 },
        new Doctor { DoctorId = 3, DoctorName = "Dr. Rahul Mehta", Specialization = "Orthopedic", Experience = 15, ConsultationFee = 1000 },
        new Doctor { DoctorId = 4, DoctorName = "Dr. Priya Shah", Specialization = "Pediatrician", Experience = 10, ConsultationFee = 700 }
    };

    public DoctorController(IMemoryCache cache)
    {
        _cache = cache;
    }

    public IActionResult Index()
    {
        if (!_cache.TryGetValue("doctorList", out List<Doctor>? doctorList))
        {
            doctorList = Doctors;
            _cache.Set("doctorList", doctorList, TimeSpan.FromMinutes(3));
        }

        return View(doctorList);
    }

    [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
    public IActionResult Details(int id)
    {
        var doctor = Doctors.FirstOrDefault(d => d.DoctorId == id);
        if (doctor == null)
            return NotFound();

        ViewBag.TotalCharge = doctor.CalculateTotalCharge();
        return View(doctor);
    }
}
