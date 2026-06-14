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
            Console.WriteLine($"{drName} Addedd Succefully with ID:" + drId);
        }

        public static void ViewAllPatient(HospitalContext context)// case 3
        {
            if (context.Patients.Count == 0)
            {
                Console.WriteLine("No Patient Registered Yet");


            }
            else
            {
                foreach (Patient patient in context.Patients)
                {
                    Console.WriteLine($"patient Id:{patient.patientId}" +
                        $"patient Name:{patient.patientName}" +
                        $"patient Age:{patient.patientAge}" +
                        $"patient Gender:{patient.patientGender}" +
                        $"patient Phone:{patient.patientPhone}" +
                        $"patient Email:{patient.patientEmail}" +
                        $"patient Blood Type:{patient.patientBloodType}");

                }

            }
        }

        public static void ViewDoctorsbySpecialization(HospitalContext context)// case 4
        {
            Console.WriteLine("Enter your Specialization:");
            var splict = Console.ReadLine();


            bool found = false;

            foreach (Doctor drSpecialization in context.Doctors)
            {

                if (splict == drSpecialization.doctorSpecialization)
                {
                    Console.WriteLine($"doctor Name:{drSpecialization.doctorName} with Specialization:{drSpecialization.doctorSpecialization}");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No Doctor Match");
            }
        }

        public static void AddAvailableDcotorTimeSlot(HospitalContext context)
        {

            int slodid = (context.Slots.Count) + 1;

            Console.WriteLine("Enter Doctor ID");
            int doctorid = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter slot Date");
            string slotdate = Console.ReadLine();

            Console.WriteLine("Enter slot Time");
            string slottime = Console.ReadLine();


            context.Slots.Add(new AvailableSlot
            {
                slotId = slodid,
                doctorId = doctorid,
                slotDate = slotdate,
                slotTime = slottime,
                isBooked = false

            });
            Console.WriteLine($"Slot has been added{slodid},Ready to book");



        } // case 5

        public static void BookAppointment(HospitalContext context)
        {
            Console.WriteLine("Enter Patient ID:");
            int userid = int.Parse(Console.ReadLine());

            foreach(Doctor Dr in context.Doctors)
            {
                Console.WriteLine($"Doctor ID:{Dr.doctorId}" +
                    $"Doctor Name:{Dr.doctorName}" +
                    $"Specialization:{Dr.doctorSpecialization}");
            }

            Console.WriteLine("Enter Selected Doctor ID:");
            int drid = int.Parse(Console.ReadLine());

            var SelectedDrID = context.Doctors.FirstOrDefault(item => item.doctorId == drid);

            var avaiableslot = context.Slots.Where(item => item.doctorId == drid && item.isBooked == false);

            if(context.Slots.Count == 0)
            {
                Console.WriteLine("No Avaiable slots For this Doctor");
                return;
            }

            foreach(AvailableSlot book in context.Slots)
            {
                Console.WriteLine($" Available Slot ID{book.slotId}" +
                    $"Doctor ID:{book.doctorId}" +
                    $"Slot Date:{book.slotDate}" +
                    $"Slot Time:{book.slotTime}");
            }

            Console.WriteLine("Enter Selected slot ID:");
            int SlotID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Doctor ID:");
            int DrID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Slot Date:");
            string slotdate = Console.ReadLine();

            Console.WriteLine("Enter Slot Time:");
            string slottime = Console.ReadLine();

            context.Slots.Add (new AvailableSlot
            {
                slotId= SlotID,
                doctorId= DrID,
                slotDate=slotdate,
                slotTime=slottime,
                isBooked=true

            });

            Console.WriteLine("New Book Appoinment has Been addedd");
            
        } // case 6

        public static void CancelAppointment(HospitalContext context)
        {
            Console.WriteLine("Enter Appointment ID You want To Cancel:");
            int AppointmentID = int.Parse(Console.ReadLine());

            var selecetedAppoment = context.Appointments.FirstOrDefault(item => item.appointmentId == AppointmentID);
           

            if (context.Appointments.Count == 0)
            {
                Console.WriteLine("No appointments");
                return;
            }

  
           
                if(selecetedAppoment.status == "booked")
                {
                    Console.WriteLine("cancel appointment succeffully");
                    selecetedAppoment.status = "cancel";
                return;
                   

                }
           

        } // case 7

        public static void VisitMedicalRecord(HospitalContext context)
        {

            int vistID = (context.Records.Count) + 1;

            Console.WriteLine("Enter Patient ID: ");
            int patientID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Doctor ID: ");
            int doctorID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter appointment ID: ");
            int appointmentID = int.Parse(Console.ReadLine());

            var selectappoimnet = context.Appointments.FirstOrDefault(item => item.appointmentId == appointmentID);
           
            Console.WriteLine("Enter diagnosis : ");
            string diagnosi = Console.ReadLine();

            Console.WriteLine("Enter prescription: ");
            string prescript = Console.ReadLine();

            Console.WriteLine("Enter visit Date get: ");
            string visitDate = Console.ReadLine();

            Console.WriteLine("Enter consultation fee");
            decimal consfee = decimal.Parse(Console.ReadLine());


            context.Records.Add(new MedicalRecord
            {
                recordId=vistID,
                patientId=patientID,
                doctorId=doctorID,
                appointmentId=appointmentID,
                diagnosis=diagnosi,
                prescription=prescript,
                visitDateget=visitDate,
                visitFee=consfee

            });
               //update???????

                Console.WriteLine(" Medical Record After a Visit");
                Console.WriteLine($"{context.Records}");

        } // case 8

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
                        BookAppointment(context);
                        break;

                    case 7:
                        CancelAppointment(context);
                        break;
                    case 8:
                        VisitMedicalRecord(context);
                        break;
                    case 9:
                        break;

                }
            }


            Console.WriteLine("press any key to Continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
