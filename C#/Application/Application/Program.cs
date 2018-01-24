using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class Patient
    {
        public string name;
        public string service;
        public int cost;

        public Patient()
        {
            name = "-";
            service = "-";
            cost = 0;
        }

        public Patient(string _name, string _service, int _cost)
        {
            name = _name;
            service = _service;
            cost = _cost;
        }


    }

    public class Database
    {
        List<Patient> listPatients = new List<Patient>();

        public void pause()
        {
            Console.Write("\n\nPress any key to continue...");
            Console.ReadKey();
        }

        public void printAllPatient()
        {
            Console.WriteLine("==================================================================");
            Console.WriteLine("| " + "№".PadLeft(4) + " | " + "FIO patient".PadLeft(22) + " | " + "Service".PadLeft(16) + " | " + "Cost".PadLeft(11) + " |");
            Console.WriteLine("| " + " ".PadLeft(4) + " | " + " ".PadLeft(22) + " | " + " ".PadLeft(16) + " | " + " ".PadLeft(11) + " |");
            Console.WriteLine("==================================================================");
            int countPatients = 1;
            foreach (Patient pacient in listPatients)
            {
                Console.WriteLine("| " + countPatients.ToString().PadLeft(4) + " | " + pacient.name.PadLeft(22) + " | " + pacient.service.PadLeft(16) + " | " + pacient.cost.ToString().PadLeft(11) + " |");
                Console.WriteLine("==================================================================");
                countPatients++;
            }
        }

        public bool viewAllPatients()
        {
            if (listPatients.Count != 0)
            {
                printAllPatient();
                return true;
            }
            else return false;
        }


        public bool addNewPatientInDatabase(Patient _patient)
        {
            if (_patient.name != "-" && _patient.service != "-")
            {
                listPatients.Add(_patient);
                return true;
            }
            else return false;

        }

        public bool deletePatientByNumber(string number)
        {
            int countPatients = 1;
            foreach (Patient pacient in listPatients)
            {
                if (countPatients.ToString() == number)
                {
                    listPatients.Remove(pacient);
                    return true;
                }
                countPatients++;
            }
            return false;
        }

    }



    class Program
    {

        static void Main(string[] args)
        {
            int enterNumber;
            string command;
            Database database = new Database();

            Patient patient1 = new Patient("Sidorov A.S.", "Massage", 20);
            Patient patient2 = new Patient("Sidorov A.S.", "Massage", 22);
            Patient patient3 = new Patient("Sidorov A.S.", "Yzi", 4);
            Patient patient4 = new Patient("Sidorov A.S.", "Blood analize", 67);
            Patient patient5 = new Patient("Sidorov A.S.", "Massage", 12);

            database.addNewPatientInDatabase(patient1);
            database.addNewPatientInDatabase(patient2);
            database.addNewPatientInDatabase(patient3);
            database.addNewPatientInDatabase(patient4);
            database.addNewPatientInDatabase(patient5);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n-----User menu-----\n");
                Console.WriteLine("1.View all patients");
                Console.WriteLine("2.Add new patient");
                Console.WriteLine("3.Remove patient");
                Console.WriteLine("0.Exit\n");

                Console.Write("\nEntry menu number: ");
                try {
                    enterNumber = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException) {
                    enterNumber = 404;
                }

            
                switch (enterNumber)
                {
                    case 1:
                        Console.Clear(); Console.WriteLine("\n----List all patients----\n\n");
                        if (!database.viewAllPatients())
                        {
                            Console.Write("\nError!\nList patients is empty!\n");
                        }

                        database.pause();
                        break;
                    case 2:
                        Console.Clear(); Console.Write("\n-----Adding new patient-----\n\n");

                        string name;
                        string service;
                        int cost;

                        Console.Write("\nEntry name - "); name = Convert.ToString(Console.ReadLine());
                        Console.Write("\nEntry service name - "); service = Convert.ToString(Console.ReadLine());
                        try
                        {
                            Console.Write("\nEntry service cost - "); cost = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.Clear();
                            Console.Write("\n\n-----Error!-----\n");
                            Console.Write("\nThe cost of the service can not contain string characters!\n");
                            Console.Write("Try again!\n\n");
                            database.pause();
                            return;
                        }

                        Patient patient = new Patient(name, service, cost);

                        Console.WriteLine("\n\nDo you really want to add a new patient?\n");

                        Console.Write("\nAdd new patient (y/n) - "); command = Convert.ToString(Console.ReadLine());
                        if (command == "y")
                        {
                            if (database.addNewPatientInDatabase(patient)) Console.WriteLine("\n\nThe patient was successfully added \nto the database!\n\n");
                            else Console.WriteLine("\n\nError adding patient to database!\n\n");
                        }
                        else Console.WriteLine("\n\nCancellation of patient addition!\n\n");

                        database.pause();
                        break;
                    case 3:
                        string patientNumberForRemove; Console.Clear();
                        Console.Write("\n-----Removing the patient from the database-----\n\n");
                        database.printAllPatient();

                        Console.Write("\nEntry number patient for remove - "); patientNumberForRemove = Convert.ToString(Console.ReadLine());

                        Console.Write("\nRemove this patient (y/n) - "); command = Convert.ToString(Console.ReadLine());
                        if (command == "y")
                        {
                            if (database.deletePatientByNumber(patientNumberForRemove))
                            {
                                Console.Write("\nThe patient was successfully removed!\n\n");
                            }
                            else
                            {
                                Console.Write("\nA patient with such a number is not listed!\n\n");
                            }
                            database.pause();
                        }
                        else
                        {
                            Console.Write("\nUndo delete!\n\n");
                            database.pause();
                        }
                        break;
                    case 0:
                        Console.WriteLine("\n\nPress any key to continue...");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("\n\nThere is no such command in the menu!");
                        Console.WriteLine("Try again!\n\n");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            } 


        }

    }
}
