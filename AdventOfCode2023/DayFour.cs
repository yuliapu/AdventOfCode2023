namespace AdventOfCode2023
{
	internal class DayFour
	{
		public static void TaskOne()
		{
			List<string> inputLines = new Input().input4.Split("\r\n").ToList();

			double sum = 0;

			foreach (var line in inputLines)
			{
				string[] splitByCardId = line.Split(':');
				string[] splitByNumberTypes = splitByCardId[1].Split('|');
				string[] winningNumbers = splitByNumberTypes[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
				string[] myNumbers = splitByNumberTypes[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

				int result = winningNumbers.Intersect(myNumbers).Count();
				double points = result > 0 ? Math.Pow(2, result - 1) : 0;
				Console.WriteLine(points);
				sum += points;
			}

			Console.WriteLine(sum);
		}
	}
}
