using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UgeCase2.Codes.Interface_Implemented_Classes
{
    internal class GetTeacherSubject : IShowResult
    {
        public string[] ShowResult(List<List<object>> list, string? choosenEnum, string? searchValue, string[]? showAllOptions)
        {
            if (choosenEnum.Equals(EnumForTeacherStudents.Lærer.ToString()) || choosenEnum.Equals(EnumForTeacherStudents.Fag.ToString()))
            {
            Collection getTeacher = new();
            string[]? result = getTeacher.TeacherSubjectSearch(list, searchValue, choosenEnum, showAllOptions);
                return result;
            }
            return null;
        }
    }
}
