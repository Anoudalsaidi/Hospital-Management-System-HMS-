using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Models
{
    public class Patient
    {
        public int patientId { get; set; }
        public string patientName { get; set; }
        public int patientAge { get; set; }
        public string patientGender { get; set; }
        public string patientPhone { get; set; }
        public string patientEmail { get; set; }
        public string patientBloodType { get; set; }



        // Re-Factor Code:
        public Patient(int userId, string userName, int userAge, string userGender, string userPhone,
            string userEmail, string userBloodType)
        {
            patientId = userId;
            patientName = userName;
            patientAge = userAge;
            patientGender = userGender;
            patientPhone = userPhone;
            patientEmail = userEmail;
            patientBloodType = userBloodType;

        }

        public override string ToString() =>
       $"[{patientId}] {patientName,-10} [{patientAge,-7}] | {patientGender,8} | {patientPhone,8} | {patientEmail,8} | {patientBloodType:F2}";


        public void converDataToString()
        {
            Console.WriteLine($"patient {patientName} Addedd successfully With ID: " + patientId);
        }
    }
}

