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

		//public static void TaskTwo()
		//{
		//	List<string> inputLines = new Input().input4.Split("\r\n").ToList();

		//	double totalcount = 0;

		//	Dictionary<int, int> cardIdsToPoints = new Dictionary<int, int>();
		//	//List<int, int> copyCards = new Dictionary<int, int>();

		//	for (int i = 0; i < inputLines.Count; i++)
		//	{
		//		string line = inputLines[i];
		//		string[] splitByCardId = line.Split(':');
		//		string[] splitByNumberTypes = splitByCardId[1].Split('|');
		//		string[] winningNumbers = splitByNumberTypes[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
		//		string[] myNumbers = splitByNumberTypes[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

		//		int points = winningNumbers.Intersect(myNumbers).Count();
		//		cardIdsToPoints.Add(i + 1, points);

		//		Console.WriteLine(i + 1 + ": " + points);
		//	}

		//	var orderedCards = cardIdsToPoints.OrderByDescending(i => i.Value);
		//	for (int i = 0; i < orderedCards.Count(); i++) 
		//	{

		//	}
		//}

	}


	internal class Card
	{
		public int Id { get; set; }
		public int? Points { get; set; }
		public List<Card> CopyCards { get; set; }

		internal Card(int id, int points)
		{
			Id = id;
			Points = points;
			CopyCards = new List<Card>();
		}
	}
}