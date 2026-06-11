using Hospital_Management_System.Models;

using System.ComponentModel;
using System.Timers;
{
    
}

namespace Hospital_Management_System
{
    internal class Program
    {
        public static void Registration(HospitalContext context)//case 1
        {
            int userId = (context.Patients.Count) + 1;
            
            Console.WriteLine("Enter patient Name: ");
            string userName = Console.ReadLine();

            Console.WriteLine("Enter patient Age: ");
            int userAge = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter patient Gender: ");
            string userGender = Console.ReadLine();

            Console.WriteLine("Enter patient Phone: ");
            string userPhone = Console.ReadLine();

            Console.WriteLine("Enter patient Email : ");
            string userEmail = Console.ReadLine();

            Console.WriteLine("Enter patient Blood Type: ");
            string userBloodType = Console.ReadLine();


            context.Patients.Add(new Patient
            {
                patientId= userId,
                patientName = userName,
                patientAge= userAge,
                patientGender= userGender,
                patientPhone= userPhone,
                patientEmail= userEmail,
                patientBloodType= userBloodType

            });

            Console.WriteLine("patient Addedd Successfully "+ userId);


        }//case 1

        public static void AddNewDoctor(HospitalContext context) // case 2
        {
            int drId = (context.Doctors.Count) + 1;


            Console.WriteLine("Enter doctor Name:");
            string drName = Console.ReadLine();


            Console.WriteLine("Enter doctor Specialization");
            string drSpecialization = Console.ReadLine();


            Console.WriteLine("Enter doctor Phone:");
            string drPhone = Console.ReadLine();


            Console.WriteLine("Enter doctor Email:");
            string drEmail = Console.ReadLine();


            Console.WriteLine("Enter consultation Fee:");
            decimal drconsultationFee = decimal.Parse(Console.ReadLine());


            context.Doctors.Add(new Doctor
            {
                doctorId = drId,
                doctorName= drName,
                doctorSpecialization= drSpecialization,
                doctorPhone= drPhone,
                doctorEmail= drEmail,
                consultationFee= drconsultationFee
            });
            Console.WriteLine($"{drName} Doctor Addedd Succefully" + drId);
        }

        public static void ViewAllPatient(HospitalContext context)// case 3
        {
            foreach(Patient patient in context.Patients)
            {
                if (context.Patients == null)
                {
                    Console.WriteLine("No Patient Available");
                    return;
                }
                else
                {
                    Console.WriteLine($"Patient ID:{patient.patientId}");
                    
                }
            }
        
        }

        public static void ViewDoctorsbySpecialization(HospitalContext context)// case 4
        {
        
            Console.WriteLine("Seclect available Specialization ");
                     
           foreach(Doctor DR in context.Doctors)
            {
                //Console.WriteLine($"Doctor ID :{DR.doctorId}," +
                //    $"Doctor Name:{DR.doctorName}" +
                //    $"Doctor Specialization{DR.doctorSpecialization}" +
                //    $"consultation Fee:{DR.consultationFee}");

                Console.WriteLine($"All Doctors with Specialization{context.Doctors}");

                var drId = int.Parse(Console.ReadLine());
                //var drSpecialization = int.Parse(Console.ReadLine());

                var selectdr = context.Doctors.Find(item => item.doctorId == drId);

                if (drId== DR.doctorId)
                {
                    Console.WriteLine($"Doctor ID :{DR.doctorId}," +
                        $"Specialization:{DR.doctorSpecialization}");
                    return;
                }
                else
                {
                    Console.WriteLine("NO Doctor match with this Specialization ");
                }

            }


        }

        public static void AddAvailableDcotorTimeSlot(HospitalContext context)
        {
            

            foreach (AvailableSlot slot in context.Slots)
            {
                int slodid = (context.Slots.Count) + 1;

                Console.WriteLine("Enter Doctor ID");
                int doctorid = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter slot Date");
                string slotdate = Console.ReadLine();

                Console.WriteLine("Enter slot Time");
                string slottime = Console.ReadLine();

                bool check = false;
               
                if(slot.isBooked == false)
                {
                    context.Slots.Add(new AvailableSlot
                    {
                        doctorId= doctorid,
                        slotDate= slotdate,
                        slotTime= slottime

                    });
                    Console.WriteLine($"Slot has been added{slodid} with doctor id {slot.doctorId},Ready to book");
                    
                }
                
                else
                {
                    Console.WriteLine("No Avaiable Slot");


                }

                return;

            }
         
        }//case 5 (retern)

        public static void BookAppointment(HospitalContext context)
        {

        }









        static void Main(string[] args)
        {
            HospitalContext context = new HospitalContext();
            context.Doctors = new List<Doctor>();
            context.Patients = new List<Patient>();
            context.Appointments = new List<Appointment>();
            context.Slots = new List<AvailableSlot>();
            context.Records = new List<MedicalRecord>();

            bool flag = false;
            while (flag == false)
            {
                Console.WriteLine("Welecome To Hospital Management System");
                Console.WriteLine("Choose an Option :");
                Console.WriteLine("1. Registered Patient");
                Console.WriteLine("2. Add new Dector ");
                Console.WriteLine("3. View All Patients");
                Console.WriteLine("4. View All Doctors by Specialization ");

                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Registration(context);
                        break;

                    case 2:
                        AddNewDoctor(context);
                        break;
                    case 3:
                        ViewAllPatient(context);

                        break;
                    case 4:
                        ViewDoctorsbySpecialization(context);
                        break;
                    case 5:
                        AddAvailableDcotorTimeSlot(context);
                        break;
                    case 6:
                        AddAvailableDcotorTimeSlot(context);
                        break;


                }
            }


            Console.WriteLine("press any key to Continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
