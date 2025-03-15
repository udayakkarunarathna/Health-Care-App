namespace HealthcareAPI.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Speciality { get; set; }
        public DateTime Reg_Date { get; set; }
        public int Status { get; set; } = 1;


    }
}
