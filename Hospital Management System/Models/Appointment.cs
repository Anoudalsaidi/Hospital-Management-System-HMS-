using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Models
{
    public class Appointment
    {
        public int appointmentId { get; set; }
        public int patientId { get; set; }
        public int doctorId { get; set; }
        public string appointmentDate { get; set; }
        public string appointmentTime { get; set; }

        public string status { get; set; }

        public Appointment(int appointmentID, int userid,int drid,string slotDate,string slotTime,string status)
        {
            appointmentId = appointmentID;
            patientId = userid;
            doctorId = drid;
            appointmentDate = slotDate;
            appointmentTime = slotTime;
            


        }
    }
}
