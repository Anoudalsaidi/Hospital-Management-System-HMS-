using Hospital_Management_System.Models;

using System.ComponentModel;
using System.Timers;


namespace Hospital_Management_System
{
 public class Program
    {
        public static void Registration(List<Patient> PatientList)//case 1
        {
            int userId = (PatientList.Count) + 1;
            
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

            PatientList.Add(new Patient
            (
                userId,
                userName,
              userAge,
           userGender,
              userPhone,
              userEmail,
         userBloodType

            ));

            printPatients(PatientList);

            //Console.WriteLine($"patient {userName} Addedd successfully With ID: " + userId);

        }

        public static void AddNewDoctor(List<Doctor> DoctorList) // case 2
        {
            int drId = (DoctorList.Count) + 1;


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


            DoctorList.Add(new Doctor
            {
                doctorId = drId,
                doctorName = drName,
                doctorSpecialization = drSpecialization,
                doctorPhone = drPhone,
                doctorEmail = drEmail,
                consultationFee = drconsultationFee
            });

            Console.WriteLine($"DR:{drName} Added Successfully with ID:" + drId);
        }

        public static void ViewAllPatient(List<Patient> PatientList)// case 3
        {
            //bool availablePatient = PatientList.Any(item => item.patientId > 0);


            if (PatientList.Count == 0)
            {
                Console.WriteLine("No Patient Registered Yet");
                return;

            }
            
            foreach(Patient p in PatientList)
            {
                Console.WriteLine($"Patient ID:{p.patientId} | Patient Name:{p.patientName}| Patient Age: {p.patientAge} | Patient Gender: {p.patientGender} | Patient phone:{p.patientPhone} | Patient Email:{p.patientEmail} | Patient Blood Type:{p.patientBloodType} ");
            }
        }

        public static void ViewDoctorsbySpecialization(List<Doctor> DoctorList)// case 4
        {
            Console.WriteLine("Enter your Specialization:");
            string splict = Console.ReadLine();

            List<Doctor> DrSpecialist = DoctorList.Where(item => item.doctorSpecialization.ToLower() == splict).ToList();
           
            if(DrSpecialist.Count ==0)
            {
                Console.WriteLine($"No doctors found with specialization {splict}");
                return;
            }
            foreach(Doctor d in DoctorList)
            {
                Console.WriteLine($" doctor ID:{d.doctorId} | doctor Name: {d.doctorName} ");
            }


            //bool found = false;

            //foreach (Doctor drSpecialization in DoctorList)
            //{

            //    if (splict == drSpecialization.doctorSpecialization)
            //    {
            //        Console.WriteLine($"doctor Name:{drSpecialization.doctorName}\n Specialization:{drSpecialization.doctorSpecialization}\n" +
            //            $"consultation Fee{drSpecialization.consultationFee}");
            //        found = true;
            //    }
            //}
            //if (!found)
            //{
            //    Console.WriteLine("No Doctor Match");
            //}
        }

        public static void AddAvailableDcotorTimeSlot(List<AvailableSlot> SlotList)
        {

            int slodid = (SlotList.Count) + 1;

            Console.WriteLine("Enter Doctor ID");
            int doctor = int.Parse(Console.ReadLine());

            AvailableSlot checkdoctor = SlotList.FirstOrDefault(item => item.doctorId == doctor);
            
            if(checkdoctor == null)
            {
                Console.WriteLine("Doctor Not Found");
            }



            Console.WriteLine("Enter slot Date");
            string slotdate = Console.ReadLine();

            Console.WriteLine("Enter slot Time");
            string slottime = Console.ReadLine();

            bool isBooked = false;

            SlotList.Add(new AvailableSlot
            (
                slodid,
                doctor,
                 slotdate,
                 slottime,
                isBooked = false

            ));

            Console.WriteLine($" Slot ID: {slodid} has been added,Ready to book");



        } // case 5

        public static void BookAppointment(List<Appointment> appointmentList)
        {
            int appointmentID = (appointmentList.Count) + 1;
            
            Console.WriteLine("Enter Patient ID:");
            int userid = int.Parse(Console.ReadLine());

            bool selectdoctor = appointmentList.Any(item => item.doctorId > 0);

            if(selectdoctor == true)
            {
                convertoStringDoctor(selectdoctor);
            }
            l

            foreach (Doctor Dr in appointmentList)
            {
                Console.WriteLine("Doctors Available:\n");
                Console.WriteLine($"Doctor ID:{Dr.doctorId}\t" +
                    $"Doctor Name:{Dr.doctorName}\t" +
                    $"Specialization:{Dr.doctorSpecialization}");
            }

            Console.WriteLine("\n Enter Selected Doctor ID:");
            int drid = int.Parse(Console.ReadLine());

            //var SelectedDrID = context.Doctors.FirstOrDefault(item => item.doctorId == drid);

            var avaiableslot = context.Slots.Where(item => item.doctorId == drid && item.isBooked == false).ToList();


            if(avaiableslot.Count == 0)
            {
                Console.WriteLine("No Avaiable slots For this Doctor");
                return;
            }

            foreach(AvailableSlot book in avaiableslot)
            {
                Console.WriteLine($" Available Slot\n ID: {book.slotId}\t" +
                    $"Doctor ID:{book.doctorId}\t" +
                    $"Slot Date:{book.slotDate}\t" +
                    $"Slot Time:{book.slotTime}");
            }

            Console.WriteLine("Enter Selected slot ID:");
            int SlotID = int.Parse(Console.ReadLine());

            var selectedSlot = context.Slots.FirstOrDefault(s => s.slotId == SlotID);



            string status;

            appointmentList.Add(new Appointment
            (
              appointmentID,
                userid,
                drid,
                selectedSlot.slotDate,
                selectedSlot.slotTime,
                status = "pending"
            ));



            selectedSlot.isBooked = true;

            Console.WriteLine("New Book Appoinment has Been addedd with id = " + appointmentID);
            
        } // case 6

        public static void CancelAppointment(HospitalContext context)
        {
            Console.WriteLine("Enter Appointment ID You want To Cancel:");
            int AppointmentID = int.Parse(Console.ReadLine());

            var selecetedAppoment = context.Appointments.FirstOrDefault(item => item.appointmentId == AppointmentID);

            selecetedAppoment.status = "cancel";


        }
                
           

         // case 7

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

        static void printPatients(List<Patient> PatientList)
        {
            foreach (var p in PatientList)
            {
                p.converDataToString();
            }

        }
        
        static void printDoctors(List<Doctor> DoctorList)
        {
            foreach (var d in DoctorList)
            {
                d.convertoStringDoctor();
            }

        }

        static void Main(string[] args)
        {



            HospitalContext context = new HospitalContext();
            context.Doctors = new List<Doctor>(); //seed data
            {
                new Doctor ();
            }
            ;


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
                Console.WriteLine("5. Add an Available Time Slot for a Doctor ");
                Console.WriteLine("6. Book an Appointment ");
                Console.WriteLine("7. Cancel an Appointment ");
                Console.WriteLine("8. Create a Medical Record After a Visit ");
                Console.WriteLine("0. Exit");

                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Registration(context.Patients);
                        break;

                    case 2:
                        AddNewDoctor(context.Doctors);
                        break;
                    case 3:
                        ViewAllPatient(context.Patients);

                        break;
                    case 4:
                        ViewDoctorsbySpecialization(context.Doctors);
                        break;
                    case 5:
                        AddAvailableDcotorTimeSlot(context.Slots);
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
                    case 0:
                        flag = true;
                        break;

                    default:
                        Console.WriteLine("Invalied Input");
                        break;


                }



                Console.WriteLine("press any key to Continue...");
                Console.ReadKey();
                Console.Clear();


             
            }
        }
    }
}
