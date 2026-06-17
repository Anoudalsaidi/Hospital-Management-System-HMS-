using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Models
{
    public class Doctor
    {
        public int doctorId { get; set; }
        public string doctorName { get; set; }
        public string doctorSpecialization { get; set; }
        public string doctorPhone { get; set; }
        public string doctorEmail { get; set; }
        public decimal consultationFee { get; set; }
     
        public Doctor(int drId,string drName,string drSpecialization,string drPhone,string drEmail,decimal drconsultationFee)
        {
            doctorId = drId;
            doctorName = drName;
            doctorSpecialization = drSpecialization;
            doctorPhone = drPhone;
            doctorEmail = drEmail;
            consultationFee = drconsultationFee;

        }
        public override string ToString() =>
            $"[{doctorId}] | {doctorName,8} | {doctorSpecialization,10} | {doctorPhone,8} | {doctorEmail,7} | {consultationFee:F2} ";
       
        public void convertoStringDoctor()
        {
            Console.WriteLine($"Doctor ID: {doctorId} doctor Name:{doctorId}\n Specialization:{doctorSpecialization}\n" +
                       $"consultation Fee{consultationFee}");
        }

    }
}
