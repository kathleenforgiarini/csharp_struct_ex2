using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CODED BY KATHLEEN FORGIARINI DA SILVA

namespace lab3_2_struct_array
{
    //Creating struct for Person
    struct Person
    {
        public string fname;
        public string lname;
        public sbyte age;
    }
    //Creating struct for Student
    struct Student
    {
        public Person pData; //object of Person struct
        public uint sId;
        public string cName;
        public string cAdr;
        public string cCity;
    }
    class Program
    {
        static void Main(string[] args)
        {
            // creating the array of struct
            const int maxStudents = 5;
            Student[] student = new Student[maxStudents];
            int qtdStudents = 0;
            char option;

            // Inicializing the operation
            do
            {
                Console.WriteLine("\nSelect an option: ");
                Console.WriteLine("1) Add nem student");
                Console.WriteLine("2) Display students");
                Console.WriteLine("0) Exit application\n");
                option = Convert.ToChar(Console.ReadLine()); //Convert string to char

                switch (option)
                {
                    case '1':
                        {
                            if (qtdStudents < maxStudents)
                            {
                                //student information
                                Console.WriteLine("Enter student's first name: ");
                                student[qtdStudents].pData.fname = Console.ReadLine();
                                Console.WriteLine("Enter student's last name: ");
                                student[qtdStudents].pData.lname = Console.ReadLine();


                            age: //label for goto

                                // If the age entered is not supported by SByte
                                try
                                {
                                    Console.WriteLine("Enter student's age: ");
                                    student[qtdStudents].pData.age = Convert.ToSByte(Console.ReadLine());
                                    if (student[qtdStudents].pData.age < 18 || student[qtdStudents].pData.age > 65)
                                    {
                                        Console.WriteLine("Please enter a value between 18 and 65");
                                        goto age; //if the age is not between 18 and 65, go back to ask again
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Oh no! An exception occurred.\n - Details: " + e.Message);
                                    goto age;
                                }

                            id: // label for goto

                                // If the ID entered is not supported by Int32
                                try
                                {
                                    Console.WriteLine("Enter student's ID: ");
                                    student[qtdStudents].sId = Convert.ToUInt32(Console.ReadLine());
                                    if (student[qtdStudents].sId.ToString().Length > 7)
                                    {
                                        Console.WriteLine("Enter a number less than 7 digits");
                                        goto id;
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Oh no! An exception occurred.\n - Details: " + e.Message);
                                    goto id;
                                }

                                Console.WriteLine("Enter college's name: ");
                                student[qtdStudents].cName = Console.ReadLine();
                                Console.WriteLine("Enter the city: ");
                                student[qtdStudents].cCity = Console.ReadLine();
                                Console.WriteLine("Enter the address: ");
                                student[qtdStudents].cAdr = Console.ReadLine();

                                //increment number of std registered
                                qtdStudents++;
                                Console.WriteLine("\nStudent was successfully registered!\n");
                            }
                            else
                            {
                                Console.WriteLine("\nSorry, number of students exceeded.");
                            }
                        }
                        break;
                    case '2':
                        {
                            //Display the informations of the students
                            if (qtdStudents > 0)
                            {
                                for (int i = 0; i < qtdStudents; i++)
                                {
                                    Console.WriteLine("\nStudent {0}: First Name: {1,-15} ,Last Name: {2,-15} ,Age: {3,5} ,ID: {4}", i + 1, student[i].pData.fname, student[i].pData.lname, student[i].pData.age, student[i].sId);
                                    Console.WriteLine("College info.: College Name: {0} ,City: {1} ,Address: {2}", student[i].cName, student[i].cCity, student[i].cAdr);
                                }
                            }
                            else // If there is no student registered
                            {
                                Console.WriteLine("There is nothing to display!\n");
                            }
                        }
                        break;
                    case '0': 
                        {
                            Console.WriteLine("Bye bye!");
                            Console.ReadKey();
                        } 
                        break;
                    default: { } break;
                }//end switch
            } while (option != '0');
        }//end Main()
    }
}