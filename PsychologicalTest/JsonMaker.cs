using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalTest
{
	class JsonMaker
	{
		public static void CreateKettelJson()
		{
			string[] text = File.ReadAllLines("Questions.tabf");
			string[] answers = File.ReadAllLines("answers.tabf");

			KettelTest.answersPoints = new Dictionary<int, AnswerPoints>();
			int currentAnswer = 0;
			AnswerPoints currentPoints = new AnswerPoints();

			for (int i = 0; i < answers.Length; i++)
			{
				for (int j = 0; j < answers[i].Length; j++)
				{
					if (char.IsNumber(answers[i][j]))
						currentAnswer = currentAnswer * 10 + int.Parse(answers[i][j].ToString());

					else if (char.IsLetter(answers[i][j]))
					{
						if (i == 2)
						{
							if (answers[i][j] == 'a')
								currentPoints.answer1 = 1;

							if (answers[i][j] == 'b')
								currentPoints.answer2 = 1;

							if (answers[i][j] == 'c')
								currentPoints.answer3 = 1;

							continue;
						}

						if (answers[i][j] == 'a')
							currentPoints.answer1 = 2;

						if (answers[i][j] == 'b')
							currentPoints.answer2 = 1;

						if (answers[i][j] == 'c')
							currentPoints.answer3 = 2;
					}
					else if (answers[i][j] == '\t')
					{
						KettelTest.answersPoints.Add(currentAnswer, new AnswerPoints(currentPoints.answer1, currentPoints.answer2, currentPoints.answer3));
						currentAnswer = 0;
						currentPoints.SetEmpty();
					}
				}
			}

			string json = "";
			json += "{ \"questions\": [ ";
			int currentType = 0;
			Array typeEnum = Enum.GetNames(typeof(KettelTest.Type));
			typeEnum.GetValue(currentType);
			int currentQuestion = 1;

			for (int i = 0; i < text.Length; i += 4)
			{
				json += "{";
				json += "\"text\": \"" + text[i] + "\",";
				json += "\"type\": \"" + typeEnum.GetValue(currentType) + "\" ,";
				json += "\"answers\": [";
				json += "{\"answer\": \"" + text[i + 1] + "\", " + "\"points\": \"" + KettelTest.answersPoints[currentQuestion].answer1 + "\"},";
				json += "{\"answer\": \"" + text[i + 2] + "\", " + "\"points\": \"" + KettelTest.answersPoints[currentQuestion].answer2 + "\"},";
				json += "{\"answer\": \"" + text[i + 3] + "\", " + "\"points\": \"" + KettelTest.answersPoints[currentQuestion].answer3 + "\"}";
				json += "] },";

				currentType++;
				currentQuestion++;

				if (currentType >= typeEnum.Length)
					currentType = 0;
			}
			json = json.Remove(json.Length - 1, 1);

			json += "]}";
			File.WriteAllText("Questions.json", json);
		}

		public static void CreateMathematicalJson()
		{
			string[] text = File.ReadAllLines("Questions.tabf");
		}
	}
}
