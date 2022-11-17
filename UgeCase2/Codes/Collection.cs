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
        string[] _allSubjects = { "Clientsideprogrammering", "Studieteknik", "Grundlæggende programmering", "OOP", "Databaseprogrammering", "Computerteknologi", "Netværk" };
        string[] _allStudents = { "Amanda Gudmand", "Aleksander Runge", "Adil Ajak", "Camilla Kløjgaard", "Dennis Paaske", "Iheb Boukthir", "Jakob Rasmussen", "Micki Olsen", "Mikkel Rantala", "Mikkel Jensen", "Mikkel Kjærgaard", "Niclas Jensen", "Ozan Korkmaz", "Rasmus Wiell", "Rune Hansen", "Sanjit Poudel" };
        string[] _studieteknikStudents = { "Amanda Gudmand", "Aleksander Runge", "Adil Ajak", "Dennis Paaske", "Iheb Boukthir", "Jakob Rasmussen", "Micki Olsen", "Mikkel Rantala", "Mikkel Jensen", "Mikkel Kjærgaard", "Niclas Jensen", "Rasmus Wiell", "Rune Hansen", "Sanjit Poudel" };
        string[] _allTeachers = { "Peter Lindenskov", "Niels Olesen", "Jan Johansen", "Henrik Poulsen" };

        public List<List<object>> ListCreation()
        {

            List<object> clientsideprogrammering = new();
            clientsideprogrammering.Add(_allSubjects[0]);
            clientsideprogrammering.Add(_allTeachers[0]);
            clientsideprogrammering.Add(_allStudents);

            List<object> studieteknik = new();
            studieteknik.Add(_allSubjects[1]);
            studieteknik.Add(_allTeachers[1]);
            studieteknik.Add(_studieteknikStudents);

            List<object> grundlæggendeprogrammering = new();
            grundlæggendeprogrammering.Add(_allSubjects[2]);
            grundlæggendeprogrammering.Add(_allTeachers[1]);
            grundlæggendeprogrammering.Add(_allStudents);

            List<object> oop= new();
            oop.Add(_allSubjects[3]);
            oop.Add(_allTeachers[1]);
            oop.Add(_allStudents);

            List<object> databaseprogrammering = new();
            databaseprogrammering.Add(_allSubjects[4]);
            databaseprogrammering.Add(_allTeachers[1]);
            databaseprogrammering.Add(_allStudents);

            List<object> computerteknologi = new();
            computerteknologi.Add(_allSubjects[5]);
            computerteknologi.Add(_allTeachers[2]);
            computerteknologi.Add(_allStudents);

            List<object> netværk = new();
            netværk.Add(_allSubjects[6]);
            netværk.Add(_allTeachers[3]);
            netværk.Add(_allStudents);

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

    public string[] TeacherSearch(List<List<object>>Array, string GetThisValue)
    {
            List<string> tempList = new List<string>();

            foreach (var lists in Array)
             {
                if (lists.Contains(GetThisValue))
                {
                    tempList.Add(
@$"
Du søgte efter: {GetThisValue}
Fag: {lists[0]}
-----------------------------------------------
Elever:

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
            if (tempList.Count <= 0) return null;

            return tempList.ToArray();
    }
    public string[] StudentSearch(List<List<object>>Array, string GetThisValue)
        {
            List<string> tempList = new List<string>();
            bool isBreak = false;

            foreach (var lists in Array)
            {
                foreach (var firstLoop in lists)
                {
                    if (firstLoop.GetType() == typeof(string[]))
                    {
                        string[] convertToArray = (string[])firstLoop;
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
                if (isBreak)
                {
                    tempList.Add(
                    @$"Du søgte efter: {GetThisValue}
Læreren: {lists[1].ToString()}
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
            if (tempList.Count <= 0) return null;

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
@$"Lærer: {lists[1].ToString()}
-----------------------------------------------
Elever:

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
            if (tempList.Count <= 0) return null;
            return tempList.ToArray();
        }
    public string[] GetOptions(string? GetValueForThisEnum)
        {
            if (GetValueForThisEnum.Equals(EnumForTeacherStudents.Lærer.ToString()))
            {
                return _allTeachers;
            }
            else if (GetValueForThisEnum.Equals(EnumForTeacherStudents.Elev.ToString()))
            {
                return _allStudents;
            }
            else if (GetValueForThisEnum.Equals(EnumForTeacherStudents.Fag.ToString()))
            {
                return _allSubjects;
            }
            return null;
        }
    }
}
