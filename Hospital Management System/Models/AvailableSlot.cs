using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Models
{
    public class AvailableSlot
    {
        public int slotId { get; set; }
        public int doctorId { get; set; }
        public string slotDate { get; set; }
        public string slotTime { get; set; }

        public bool isBooked { get; set; }


        public AvailableSlot(int slodid, int doctor, string slotdate, string slottime,bool isBooked)
        {
            slotId = slodid;
            doctorId = doctor;
            slotDate = slotdate;
            slotTime = slottime;
            
        }
    }
}
