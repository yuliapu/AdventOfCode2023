using AdventOfCode2023;

internal class DayOne
{
	public static void TaskOne()
	{
		List<string> inputLines = new Input().input1.Split("\r\n").ToList();

		double sum = 0;

		foreach (var line in inputLines)
		{
			char firstDigit = line.First(i => char.IsDigit(i));
			char lastDigit = line.Last(i => char.IsDigit(i));
			double calibrationValue = char.GetNumericValue(firstDigit) * 10 + char.GetNumericValue(lastDigit);
			Console.WriteLine(calibrationValue);
			sum += calibrationValue;
		}

		Console.WriteLine(sum);
	}

	public static void TaskTwo()
	{
		List<string> inputLines = new Input().input1.Split("\r\n").ToList();

		double sum = 0;

		foreach (var line in inputLines)
		{
			var words = wordsToDigits.Keys;
			var orderedWords = words.OrderBy(i => line.IndexOf(i));
			var reverseOrderedWords = words.OrderBy(i => line.LastIndexOf(i)); 

			string firstDigit = orderedWords.First(i => line.Contains(i));
			string lastDigit = reverseOrderedWords.Last(i => line.Contains(i));

			double calibrationValue = wordsToDigits[firstDigit] * 10 + wordsToDigits[lastDigit];
			Console.WriteLine(calibrationValue);
			sum += calibrationValue;
		}
		

		Console.WriteLine(sum);
	}

	private static readonly Dictionary<string, int> wordsToDigits = new Dictionary<string, int>()
	{
		{ "one", 1 },
		{ "two", 2 },
		{ "three", 3 },
		{ "four", 4 },
		{ "five", 5 },
		{ "six", 6 },
		{ "seven", 7 },
		{ "eight", 8 },
		{ "nine", 9 },

		//{ "eno", 1 },
		//{ "owt", 2 },
		//{ "eerht", 3 },
		//{ "ruof", 4 },
		//{ "evif", 5 },
		//{ "xis", 6 },
		//{ "neves", 7 },
		//{ "thgie", 8 },
		//{ "enin", 9 },

		{ "1", 1 },
		{ "2", 2 },
		{ "3", 3 },
		{ "4", 4 },
		{ "5", 5 },
		{ "6", 6 },
		{ "7", 7 },
		{ "8", 8 },
		{ "9", 9 },
	};
}