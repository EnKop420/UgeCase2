using UgeCase2.Codes;

Collection list = new();
int[] passIntVal = { (int)EnumForTeacherStudents.Teachers, (int)EnumForTeacherStudents.Students, (int)EnumForTeacherStudents.Subjects };
List<List<object>> returnedList = list.ListCreation();

Console.WriteLine
(@"
Vælg:
1) Søg efter en lærer
2) Søg efter en elev
3) Søg efter et fag

tryk 1, 2 eller 3"
);
int userInput = Convert.ToInt32(Console.ReadLine());

//for (int i = 0; i < passIntVal.Length; i++)
//{
//	if (userInput == passIntVal[i])
//	{
//		if (userInput == 1)
//		{
//			string
//		}
//		if (userInput == 2)
//		{

//		}
//		if (userInput == 3)
//		{

//		}
//	}
//}

string searching = "Clientsideprogrammering";
string[] studentNames = list.StudentSearch(returnedList, searching);
string[] teacher = list.TeacherSearch(returnedList, searching);
string[] subjects = list.SubjectSearch(returnedList, searching);