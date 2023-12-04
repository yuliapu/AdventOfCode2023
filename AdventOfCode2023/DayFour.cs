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

		public static void TaskTwoTakeTwo()
		{
			List<string> inputLines = new Input().input4.Split("\r\n").ToList();

			double totalCount = 0;
			List<Card> cards = new List<Card>();

			Dictionary<int, int> cardIdsToPoints = new Dictionary<int, int>();

			for (int i = 0; i < inputLines.Count; i++)
			{
				string line = inputLines[i];
				string[] splitByCardId = line.Split(':');
				string[] splitByNumberTypes = splitByCardId[1].Split('|');
				string[] winningNumbers = splitByNumberTypes[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
				string[] myNumbers = splitByNumberTypes[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

				int points = winningNumbers.Intersect(myNumbers).Count();
				cardIdsToPoints.Add(i + 1, points);

				Console.WriteLine(points);
			}


			foreach (var cardIdToPoints in cardIdsToPoints)
			{
				var currentCard = new Card(cardIdToPoints.Key, cardIdToPoints.Value);

				int points = 1;
				while (points <= cardIdToPoints.Value)
				{
					int winCard = currentCard.Id + points;
					var winPoints = cardIdsToPoints[winCard];

					currentCard.CopyCards!.Add(new Card(winCard, winPoints));
					points++;
				}

				cards.Add(FillCopyCards(currentCard, cardIdsToPoints));
			}
		}

		Card winCopyCard;
		private static Card FillCopyCards(Card currentCard, Dictionary<int, int> cardIdsToPoints)
		{
			foreach (var copyCard in currentCard.CopyCards!)
			{
				int pointsOfCopyCard = 1;

				while (pointsOfCopyCard <= copyCard.Points)
				{
					int winCard = copyCard.Id + pointsOfCopyCard;
					var winPoints = cardIdsToPoints[winCard];

					copyCard.CopyCards!.Add(new Card(winCard, winPoints));
					pointsOfCopyCard++;
				}

				return FillCopyCards(copyCard, cardIdsToPoints);
			}

			//return copyCard;
		}
	}


	internal class Card
	{
		public int Id { get; set; }
		public int? Points { get; set; }
		public List<Card>? CopyCards { get; set;}

		internal Card(int id, int points)
		{
			Id = id;
			Points = points;
			CopyCards = new List<Card>();
		}
	}
}
