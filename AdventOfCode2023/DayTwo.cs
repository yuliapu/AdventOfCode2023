using AdventOfCode2023;

internal class DayTwo
{
	public static void TaskOne()
	{
		int sum = 0;
		int maxRed = 12; int maxGreen = 13; int maxBlue = 14;

		List<string> inputLines = new Input().input2.Split("\r\n").ToList();
		foreach (string line in inputLines)
		{
			bool isPossible = true;
			string[] cubeSets = line.Split(new char[] { ':', ';' });
			int gameId = int.Parse(cubeSets[0].Split(' ')[1]);
			foreach (string gameSet in cubeSets.Skip(1))
			{
				string[] cubesOfGameSet = gameSet.Split(',', StringSplitOptions.RemoveEmptyEntries);
				foreach (string cubesOfColor  in cubesOfGameSet)
				{
					if (cubesOfColor.Contains("red"))
					{
						int cubeCount = int.Parse(cubesOfColor.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]);
						if (cubeCount > maxRed)
						{
							isPossible = false;
							break;
						}
					}
					else if (cubesOfColor.Contains("blue"))
					{
						int cubeCount = int.Parse(cubesOfColor.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]);
						if (cubeCount > maxBlue)
						{
							isPossible = false;
							break;
						}

					}
					else if (cubesOfColor.Contains("green"))
					{
						int cubeCount = int.Parse(cubesOfColor.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]);
						if (cubeCount > maxGreen)
						{
							isPossible = false;
							break;
						}
					}
				}
			}

			if (isPossible)
			{
				Console.WriteLine(gameId);
				sum += gameId;
			}
		}

		Console.WriteLine(sum);
	}

	public static void TaskTwo()
	{
		double sum = 0;

		List<string> inputLines = new Input().input2.Split("\r\n").ToList();
		foreach (string line in inputLines)
		{
			int maxRed = 0; int maxGreen = 0; int maxBlue = 0;

			string[] cubeSets = line.Split(new char[] { ':', ';' });
			int gameId = int.Parse(cubeSets[0].Split(' ')[1]);
			foreach (string gameSet in cubeSets.Skip(1))
			{
				IEnumerable<string[]> cubesOfGameSet = gameSet
					.Split(',', StringSplitOptions.RemoveEmptyEntries)
					.Select(i => i.Split(' ', StringSplitOptions.RemoveEmptyEntries));

				findMaxCubesCount(cubesOfGameSet, "red", ref maxRed);
				findMaxCubesCount(cubesOfGameSet, "blue", ref maxBlue);
				findMaxCubesCount(cubesOfGameSet, "green", ref maxGreen);
			}

			Console.WriteLine($"{maxRed} red, {maxGreen} green, {maxBlue} blue");
			sum += maxBlue * maxGreen * maxRed;
		}

		Console.WriteLine(sum);
	}

	private static void findMaxCubesCount(IEnumerable<string[]> cubesOfGameSet, string color, ref int maxByColor)
	{
		int redCubesCount = int.Parse(cubesOfGameSet
			.Where(i => i.Last() == color)
			.Max(i => i.First()) ?? "0");

		if (maxByColor < redCubesCount)
			maxByColor = redCubesCount;
	}
}