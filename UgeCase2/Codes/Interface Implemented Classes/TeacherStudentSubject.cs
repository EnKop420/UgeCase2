using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UgeCase2.Codes.Interface_Implemented_Classes
{
    internal class TeacherStudentSubject
    {
        public string[]? result { get; set; }
        public TeacherStudentSubject(IShowResult teacherStudentSubject, List<List<object>> list, string? ChoosenEnum, string? searchValue, string[]? showAllOptions)
        {
            if (teacherStudentSubject != null)
            {
                if (teacherStudentSubject.GetType() == typeof(GetTeacherSubject))
                {
                    result = new GetTeacherSubject().ShowResult(list, ChoosenEnum, searchValue, showAllOptions);
                }
                else if (teacherStudentSubject.GetType() == typeof(GetStudents))
                {
                    result = new GetStudents().ShowResult(list, ChoosenEnum, searchValue, showAllOptions);
                }
            }
        }
    }
}
