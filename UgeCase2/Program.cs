using System;
using System.Net.Security;

Collection list = new Collection();

int[] passIntVal = { (int)EnumForTeacherStudents.Lærer, (int)EnumForTeacherStudents.Elev, (int)EnumForTeacherStudents.Fag };
List<List<object>> returnedList = list.ListCreation();
while (true)
{
	Console.WriteLine
	("Vælg:\n1) Søg efter en lærer\n2) Søg efter en elev\n3) Søg efter et fag \n4) Luk applicationen \n\ntryk 1, 2, 3 eller 4");

	string stringInput = Console.ReadLine();
	bool canParseToInt = Int32.TryParse(stringInput, out int userInput);
	if (passIntVal.Contains(userInput) && canParseToInt)
	{
		//Laver alle variabler som bliver brugt gennem program.cs
		//------------------------------------------------------------------------------------------
        string? ChoosenEnumValue = Enum.GetName(typeof(EnumForTeacherStudents), userInput);
		string[]? showAllOptions = null;
        string[] ShowResult = null;
        string searchValue;

		//Hvis userInput matcher en Enum tag alle værdier ud under den Enum og læg ind i et array
        if (userInput == 1)
		{
			showAllOptions = list.GetOptions(ChoosenEnumValue);
		}
		else if (userInput == 2)
		{
			showAllOptions = list.GetOptions(ChoosenEnumValue);
		}
		else if (userInput == 3)
		{
			showAllOptions = list.GetOptions(ChoosenEnumValue);
		}
        Console.Clear();
		Console.WriteLine($"Her er de forskellige muligheder indenfor {ChoosenEnumValue}\n");
		try
		{ 
			if (showAllOptions == null)
			{
				throw new("Ingen valg tilgængelig :(. Prøv igen senere");
			}
			for (int i = 0; i < showAllOptions.Length; i++)
			{
				Console.WriteLine($"--{showAllOptions[i]}--");
			}
        Console.WriteLine($"\nSøg efter {ChoosenEnumValue}");
        searchValue = Console.ReadLine();
			Console.Clear();

			//Checker hvilken klasse den skal kalde angående hvad ChoosenEnumValue er.
			if (ChoosenEnumValue == EnumForTeacherStudents.Lærer.ToString() || ChoosenEnumValue == EnumForTeacherStudents.Fag.ToString())
			{
				ShowResult = (new TeacherStudentSubject(new GetTeacherSubject(), returnedList, ChoosenEnumValue, searchValue, showAllOptions).result);
                if (ShowResult == null)
                {
                    throw new("Kunne ikke finde hvad du søgte efter. Prøv igen");
                }

                for (int i = 0; i < ShowResult.Length; i++)
				{
					Console.WriteLine(ShowResult[i]);
				}
                Console.ReadKey();
                Console.Clear();
            }
            else if (ChoosenEnumValue == EnumForTeacherStudents.Elev.ToString())
            {
                ShowResult = (new TeacherStudentSubject(new GetStudents(), returnedList, ChoosenEnumValue, searchValue, showAllOptions).result);

                if (ShowResult == null)
                {
                    throw new("Kunne ikke finde hvad du søgte efter. Prøv igen");
                }
                for (int i = 0; i < ShowResult.Length; i++)
                {
                    Console.WriteLine(ShowResult[i]);
                }
                Console.ReadKey();
                Console.Clear();
            }
			//else if (ChoosenEnumValue == "Fag")
			//{
			//	ShowResult = (new TeacherStudentSubject(new GetTeacherSubject(), returnedList, ChoosenEnumValue, searchValue).result);

			//	if (ShowResult == null)
			//	{
			//		throw new("Kunne ikke finde hvad du søgte efter. Prøv igen");
			//	}
			//	for (int i = 0; i < ShowResult.Length; i++)
			//	{
			//		Console.WriteLine(ShowResult[i]);
			//	}
			//	Console.ReadKey();
			//	Console.Clear();
			//}

		}
        catch (Exception exception)
        {
			Console.WriteLine($"Fejl: {exception.Message}");
			Console.ReadKey();
			Console.Clear();
        }
    }
	else if (userInput == 4)//Lukning af programmet
	{
		int whenShutdown = 3000;
		for (int i = 3; i > 0; i--)
		{
            Console.Clear();
            Console.WriteLine($"Programmet lukker om {i} sekunder");
			System.Threading.Thread.Sleep(1000);
			whenShutdown -= 1000;
        }
        Console.Clear();
        Environment.Exit(0);
	}
	else // Hvis userInput ikke matcher op med en Enum
	{
		Console.WriteLine("Dit valg er ikke gyldigt. Tryk for at prøve igen");
		Console.ReadKey();
		Console.Clear();
	}
};

//Lavet af Rasmus :)