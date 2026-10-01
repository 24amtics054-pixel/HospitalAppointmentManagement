using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentManagement.Models;

public class Doctor
{
    public int DoctorId { get; set; }

    [Required]
    public string DoctorName { get; set; } = "";

    [Required]
    public string Specialization { get; set; } = "";

    [Range(0, 60)]
    public int Experience { get; set; }

    [Range(0, 100000)]
    public decimal ConsultationFee { get; set; }
}
