using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UgeCase2.Codes
{
    internal class Collection
    {

        //List<string?> _allSubjects = new() { "Clientsideprogrammering", "Studieteknik", "Grundlæggende programmering", "OOP", "Databaseprogrammering", "Computerteknologi", "Netværk" };
        //List<string?> _allStudents = new() { "Amanda Gudmand", "Aleksander Runge", "Camilla Kløjgaard", "Dennis Paaske", "Iheb Boukthir", "Jakob Rasmussen", "Micki Olsen", "Mikkel Rantala", "Mikkel Jensen", "Niclas Jensen", "Ozan Korkmaz", "Rasmus Wiell", "Rune Hansen", "Sanjit Poudel" };
        //List<string?> _studieteknikStudents = new() { "Amanda Gudmand", "Aleksander Runge", "Dennis Paaske", "Iheb Boukthir", "Jakob Rasmussen", "Micki Olsen", "Mikkel Rantala", "Mikkel Jensen", "Niclas Jensen", "Rasmus Wiell", "Rune Hansen", "Sanjit Poudel" };
        //List<string?> _allTeachers = new() { "Peter Lindenskov", "Niels Olesen", "Jan Johansen", "Henrik Poulsen" };


        public List<List<object>> ListCreation()
        {
            string[] allSubjects = { "Clientsideprogrammering", "Studieteknik", "Grundlæggende programmering", "OOP", "Databaseprogrammering", "Computerteknologi", "Netværk" };
            string[] allStudents = { "Amanda Gudmand", "Aleksander Runge", "Adil Ajak", "Camilla Kløjgaard", "Dennis Paaske", "Iheb Boukthir", "Jakob Rasmussen", "Micki Olsen", "Mikkel Rantala", "Mikkel Jensen", "Mikkel Kjærgaard", "Niclas Jensen", "Ozan Korkmaz", "Rasmus Wiell", "Rune Hansen", "Sanjit Poudel" };
            string[] studieteknikStudents = { "Amanda Gudmand", "Aleksander Runge", "Dennis Paaske", "Iheb Boukthir", "Jakob Rasmussen", "Micki Olsen", "Mikkel Rantala", "Mikkel Jensen", "Mikkel Kjærgaard", "Niclas Jensen", "Rasmus Wiell", "Rune Hansen", "Sanjit Poudel" };
            string[] allTeachers = { "Peter Lindenskov", "Niels Olesen", "Jan Johansen", "Henrik Poulsen" };

            List<object> clientsideprogrammering = new();
            clientsideprogrammering.Add(allSubjects[0]);
            clientsideprogrammering.Add(allTeachers[0]);
            clientsideprogrammering.Add(allStudents);

            List<object> studieteknik = new();
            studieteknik.Add(allSubjects[1]);
            studieteknik.Add(allTeachers[1]);
            studieteknik.Add(studieteknikStudents);

            List<object> grundlæggendeprogrammering= new();
            grundlæggendeprogrammering.Add(allSubjects[2]);
            grundlæggendeprogrammering.Add(allTeachers[1]);
            grundlæggendeprogrammering.Add(allStudents);

            List<object> oop= new();
            oop.Add(allSubjects[3]);
            oop.Add(allTeachers[1]);
            oop.Add(allStudents);

            List<object> databaseprogrammering = new();
            databaseprogrammering.Add(allSubjects[4]);
            databaseprogrammering.Add(allTeachers[1]);
            databaseprogrammering.Add(allStudents);

            List<object> computerteknologi = new();
            computerteknologi.Add(allSubjects[5]);
            computerteknologi.Add(allTeachers[2]);
            computerteknologi.Add(allStudents);

            List<object> netværk = new();
            netværk.Add(allSubjects[6]);
            netværk.Add(allTeachers[3]);
            netværk.Add(allStudents);

            List<List<object>> subjects = new();
            {
                subjects.Add(clientsideprogrammering);
                subjects.Add(studieteknik);
                subjects.Add(grundlæggendeprogrammering);
                subjects.Add(oop);
                subjects.Add(databaseprogrammering);
                subjects.Add(computerteknologi);
                subjects.Add(netværk);
            };
            return subjects;
        }

    public string[] StudentSearch(List<List<object>>listArray, string GetThisValue)
        {
            List<string> tempList = new List<string>();
            bool isBreak = false;

            foreach (var lists in listArray)
            {
                if (isBreak)
                {
tempList.Add(
@$"Læreren: {lists[1].ToString()}
Fag: {lists[0].ToString()}
-----------------------------------------------");

                    isBreak = false;
                }
                    foreach (var objects in lists)
                    {
                        if (objects.GetType() == typeof(string[]))
                        {
                            string[] convertToArray = (string[])objects;
                            foreach (var studentNames in convertToArray)
                            {
                                if (studentNames.Contains(GetThisValue))
                                {

                                isBreak = true;
                                break;
                                }
                            }
                        if (isBreak) break;
                        }
                    }
            }
            //for (int i = 0; i < tempList.Count; i++)
            //{
            //    Console.WriteLine(tempList[i]);
            //}
            return tempList.ToArray();
        }
    public string[] TeacherSearch(List<List<object>>Array, string GetThisValue)
    {
            List<string> tempList = new List<string>();

            foreach (var lists in Array)
             {
                if (lists.Contains(GetThisValue))
                {
                    tempList.Add(
@$"-------------------------------------------------
Fag: {lists[0].ToString()}
-----------------------------------------------
");

                    foreach (var objects in lists)
                    {
                        if (objects.GetType() == typeof(string[]))
                        {
                            string[] convertToArray = (string[])objects;
                            foreach (var studentNames in convertToArray)
                            {
                                tempList.Add(studentNames);

                            }
                        }
                    }
                }
        }
            return tempList.ToArray();
    }
        public string[] SubjectSearch(List<List<object>> Array, string GetThisValue)
        {
            List<string> tempList = new List<string>();

            foreach (var lists in Array)
            {
                if (lists.Contains(GetThisValue))
                {
                    tempList.Add(
@$"-------------------------------------------------
Lærer: {lists[1].ToString()}
-----------------------------------------------
");

                    foreach (var objects in lists)
                    {
                        if (objects.GetType() == typeof(string[]))
                        {
                            string[] convertToArray = (string[])objects;
                            foreach (var studentNames in convertToArray)
                            {
                                tempList.Add(studentNames);

                            }
                        }
                    }

                }
            }
            for (int i = 0; i < tempList.Count; i++)
            {
                Console.WriteLine(tempList[i]);
            }
            return tempList.ToArray();
        }
    }
}
