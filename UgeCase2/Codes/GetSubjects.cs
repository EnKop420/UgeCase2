using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UgeCase2.Codes
{
    internal class GetSubjects : IShowResult
    {
        public string[] ShowResult(List<List<object>> list, string? choosenEnum, string? searchValue)
        {
            if (choosenEnum.Equals(EnumForTeacherStudents.Fag.ToString()))
            {
                Collection getSubject = new();
                string[]? result = getSubject.SubjectSearch(list, searchValue);
                return result;
            }
            return null;
        }
    }
}
