using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentManagement.Models;

public class Appointment
{
    [Required]
    public int DoctorId { get; set; }

    [Required]
    public string PatientName { get; set; } = "";

    [Required]
    public string Specialization { get; set; } = "";

    [Required]
    [DataType(DataType.Date)]
    public DateTime AppointmentDate { get; set; } = DateTime.Today;
}
