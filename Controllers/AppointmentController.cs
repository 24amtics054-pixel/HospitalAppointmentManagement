using HospitalAppointmentManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentManagement.Controllers;

public class AppointmentController : Controller
{
    [HttpGet]
    public IActionResult Create(int doctorId)
    {
        var model = new Appointment { DoctorId = doctorId, AppointmentDate = DateTime.Today };
        ViewBag.DoctorId = doctorId;
        ViewBag.Specializations = new[] { "General Consultation", "Cardiology", "Dermatology", "Orthopedic", "Pediatrics" };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Appointment appointment)
    {
        ViewBag.Specializations = new[] { "General Consultation", "Cardiology", "Dermatology", "Orthopedic", "Pediatrics" };

        if (!ModelState.IsValid)
            return View(appointment);

        Response.Cookies.Append("PatientName", appointment.PatientName, new CookieOptions
        {
            Expires = DateTimeOffset.UtcNow.AddDays(7),
            HttpOnly = false,
            IsEssential = true
        });

        HttpContext.Session.SetString("SelectedSpecialization", appointment.Specialization);

        TempData["Message"] = $"Appointment request submitted for {appointment.PatientName}. Specialization: {appointment.Specialization}.";
        return RedirectToAction("Index", "Doctor");
    }
}
