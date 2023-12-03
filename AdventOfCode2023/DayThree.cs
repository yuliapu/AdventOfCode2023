using AdventOfCode2023;
using System.Linq;

internal class DayThree
{
	public static void TaskOne()
	{
		List<string> inputLines = new Input().input3.Split("\r\n").ToList();
		List<double> results = new List<double>();

		for (int i = 0; i < inputLines.Count; i++)
		{
			string line = inputLines[i];

			int startIndexOfNumber = -1;
			int endIndexOfNumber = -1;
			for (int j = 0; j < line.Length; j++)
			{
				if (char.IsDigit(line[j]))
				{
					if (startIndexOfNumber != -1)
					{
						endIndexOfNumber = j;
					}

					else
					{
						startIndexOfNumber = j;
						endIndexOfNumber = j;
					}

					if (j == line.Length - 1)
					{
						List<char> adjElements = GetAdjacentElements(inputLines, i, j - 1, startIndexOfNumber);
						if (adjElements.Any(i => IsSymbol(i)))
						{
							var substring = line.Substring(startIndexOfNumber, endIndexOfNumber - startIndexOfNumber + 1);
							results.Add(double.Parse(substring));
							Console.WriteLine(substring);
						}
					}
				}

				else if (startIndexOfNumber != -1)
				{
					List<char> adjElements = GetAdjacentElements(inputLines, i, j - 1, startIndexOfNumber);
					if (adjElements.Any(i => IsSymbol(i)))
					{
						var substring = line.Substring(startIndexOfNumber, endIndexOfNumber - startIndexOfNumber + 1);
						results.Add(double.Parse(substring));
						Console.WriteLine(substring);
					}

					startIndexOfNumber = -1;
					endIndexOfNumber = -1;
				}
			}
		}

		Console.WriteLine(results.Sum());
	}

	private static bool IsSymbol(char c)
	{
		return c != '.' && !char.IsDigit(c);
	}

	private static void GetPartNumber(List<string> inputLines, int i, int j, int startIndexOfNumber, ref List<double> results)
	{
		List<char> adjElements = GetAdjacentElements(inputLines, i, j - 1, startIndexOfNumber);
		if (adjElements.Any(i => IsSymbol(i)))
		{
			var substring = inputLines[i].Substring(startIndexOfNumber, j - startIndexOfNumber);
			results.Add(double.Parse(substring));
			Console.WriteLine(substring);
		}
	}

	private static List<char> GetAdjacentElements(List<string> lines, int i, int j, int startIndex)
	{
		List<char> result = new List<char>();

		while (j >= startIndex)
		{
			if (j > 0)
			{
				result.Add(lines[i][j - 1]);

				if (i > 0)
				{
					result.Add(lines[i - 1][j - 1]);
				}
				if (i < lines.Count - 1)
				{
					result.Add(lines[i + 1][j - 1]);
				}
			}
			if (i > 0)
			{
				result.Add(lines[i - 1][j]);	
				result.Add(lines[i - 1][j + 1]);
			}
			if (i < lines.Count - 1)
			{
				result.Add(lines[i + 1][j]);
				if (j < lines[i].Length - 1)
				{
					result.Add(lines[i][j + 1]);
					result.Add(lines[i + 1][j + 1]);
				}
			}

			j--;
		}
		return result;
	}

	public static void TaskTwo()
	{
		List<string> inputLines = new Input().input3.Split("\r\n").ToList();

		List<(char, string, int)> adjWithNumbers = new List<(char, string, int)>();
		double sum = 0;
		for (int i = 0; i < inputLines.Count; i++)
		{
			string line = inputLines[i];

			int startIndexOfNumber = -1;
			int endIndexOfNumber = -1;
			for (int j = 0; j < line.Length; j++)
			{
				if (char.IsDigit(line[j]))
				{
					if (startIndexOfNumber != -1)
					{
						endIndexOfNumber = j;
					}

					else
					{
						startIndexOfNumber = j;
						endIndexOfNumber = j;
					}

					if (j == line.Length - 1)
					{
						int number = int.Parse(line.Substring(startIndexOfNumber, endIndexOfNumber - startIndexOfNumber + 1));
						List<(char, string, int)> adjElements = GetSymbolAdjacentElementsWithIndexes(inputLines, i, j - 1, startIndexOfNumber, number);
						adjWithNumbers.AddRange(adjElements);
					}

				}

				else if (startIndexOfNumber != -1)
				{
					int number = int.Parse(line.Substring(startIndexOfNumber, endIndexOfNumber - startIndexOfNumber + 1));
					List<(char, string, int)> adjElements = GetSymbolAdjacentElementsWithIndexes(inputLines, i, j - 1, startIndexOfNumber, number);
					adjWithNumbers.AddRange(adjElements);

					startIndexOfNumber = -1;
					endIndexOfNumber = -1;
				}
			}
		}

		var gears = adjWithNumbers.GroupBy(el => el.Item2).Where(i => i.Count()>1);
		foreach (var gear in gears)
		{
			int gearValue = gear.First().Item3 * gear.Last().Item3;
			sum += gearValue;
			Console.WriteLine(gearValue);
		}

		Console.WriteLine(sum);
	}
	
	private static List<(char, string, int)> GetSymbolAdjacentElementsWithIndexes(List<string> lines, int i, int j, int startIndex, int number)
	{
		List<(char, string, int)> result = new List<(char, string, int)>();

		while (j >= startIndex)
		{
			if (j > 0)
			{
				CheckAndAddSymbol(lines, i, j - 1, number, ref result);

				if (i > 0)
				{
					CheckAndAddSymbol(lines, i - 1, j - 1, number, ref result);
				}
				if (i < lines.Count - 1)
				{
					CheckAndAddSymbol(lines, i + 1, j - 1, number, ref result);
				}
			}
			if (i > 0)
			{
				CheckAndAddSymbol(lines, i - 1, j, number, ref result);
				CheckAndAddSymbol(lines, i - 1, j + 1, number, ref result);
			}
			if (i < lines.Count - 1)
			{
				CheckAndAddSymbol(lines, i + 1, j, number, ref result);
				if (j < lines[i].Length - 1)
				{
					CheckAndAddSymbol(lines, i, j + 1, number, ref result);
					CheckAndAddSymbol(lines, i + 1, j + 1, number, ref result);
				}
			}

			j--;
		}
		return result;
	}

	private static void CheckAndAddSymbol(List<string> lines, int i, int j, int number, ref List<(char, string, int)> result)
	{
		if (IsSymbol(lines[i][j]))
			if (!result.Any(el => el.Item2.Equals($"{i},{j}")))
				result.Add((lines[i][j], $"{i},{j}", number));
	}
}