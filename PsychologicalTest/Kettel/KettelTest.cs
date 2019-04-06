using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalTest
{
	class KettelTest
	{
		public enum Type
		{
			MD,
			A,
			B,
			C,
			E,
			F,
			G,
			H,
			I,
			L,
			M,
			N,
			O,
			Q1,
			Q2,
			Q3,
			Q4
		}

		public static List<KettelTestQuestion> questions;
		public static TestResult result;
		public static int currentIterator = 0;
		public static Dictionary<int, AnswerPoints> answersPoints;

		private static List<Type> deniedTypes = new List<Type>()
		{
			//Type.MD,
			//Type.A,
			//Type.C,
			//Type.E,
			//Type.G,
			//Type.H,
			//Type.I,
			//Type.L,
			//Type.F
			Type.A,
			Type.B,
			Type.C,
			Type.E,
			Type.F,
			Type.G,
			Type.H,
			Type.I,
			Type.L,
			Type.M,
			Type.N,
			Type.O,
			Type.Q1,
			Type.Q2,
			Type.Q3,
			Type.Q4,
			Type.MD
		};

		private static Dictionary<Type, List<Pair>> pointsDictionary = new Dictionary<Type, List<Pair>>()
		{
			{ Type.A,  new List<Pair>(){ new Pair(0, 4),    new Pair(5),    new Pair(6),    new Pair(7),    new Pair(8),    new Pair(-1),   new Pair(9), new Pair(10),  new Pair(11),   new Pair(12) }},
			{ Type.B,  new List<Pair>(){ new Pair(0, 2),    new Pair(-1),   new Pair(3),    new Pair(-1),   new Pair(4),    new Pair(-1),   new Pair(5), new Pair(6),   new Pair(-1),   new Pair(7, 8) }},
			{ Type.C,  new List<Pair>(){ new Pair(0, 3),    new Pair(4),    new Pair(5),    new Pair(6),    new Pair(7),    new Pair(8),    new Pair(9), new Pair(10),  new Pair(11),   new Pair(12) }},
			{ Type.E,  new List<Pair>(){ new Pair(0, 1),    new Pair(2),    new Pair(3),    new Pair(4),    new Pair(5),    new Pair(6),    new Pair(7), new Pair(8),   new Pair(9),    new Pair(10, 12) }},
			{ Type.F,  new List<Pair>(){ new Pair(0, 1),    new Pair(-1),   new Pair(3),    new Pair(4),    new Pair(5),    new Pair(6),    new Pair(7), new Pair(8),   new Pair(9),    new Pair(10, 12) }},
			{ Type.G,  new List<Pair>(){ new Pair(0, 3),    new Pair(4),    new Pair(5),    new Pair(6),    new Pair(7),    new Pair(8),    new Pair(9), new Pair(10),  new Pair(11),   new Pair(12) }},
			{ Type.H,  new List<Pair>(){ new Pair(0, 3),    new Pair(4),    new Pair(5),    new Pair(6),    new Pair(7),    new Pair(8),    new Pair(9), new Pair(10),  new Pair(11),   new Pair(12) }},
			{ Type.I,  new List<Pair>(){ new Pair(0, 3),    new Pair(4),    new Pair(5),    new Pair(6),    new Pair(7),    new Pair(8),    new Pair(9), new Pair(10),  new Pair(11),   new Pair(12) }},
			{ Type.L,  new List<Pair>(){ new Pair(0, 1),    new Pair(2),    new Pair(-1),   new Pair(3),    new Pair(4),    new Pair(-1),   new Pair(5), new Pair(6),   new Pair(7),    new Pair(8, 12) }},
			{ Type.M,  new List<Pair>(){ new Pair(0, 3),    new Pair(-1),   new Pair(4),    new Pair(5),    new Pair(6),    new Pair(7),    new Pair(8), new Pair(9),   new Pair(10),   new Pair(11, 12) }},
			{ Type.N,  new List<Pair>(){ new Pair(0, 1),    new Pair(2),    new Pair(3),    new Pair(4),    new Pair(5),    new Pair(6),    new Pair(7), new Pair(8),   new Pair(9),    new Pair(10, 12) }},
			{ Type.O,  new List<Pair>(){ new Pair(0, 1),    new Pair(2),    new Pair(3),    new Pair(4),    new Pair(5),    new Pair(6),    new Pair(7), new Pair(8),   new Pair(9),    new Pair(10, 12) }},
			{ Type.Q1, new List<Pair>(){ new Pair(0, 4),    new Pair(5),    new Pair(6),    new Pair(-1),   new Pair(7),    new Pair(8),    new Pair(9), new Pair(10),  new Pair(11),   new Pair(12) }},
			{ Type.Q2, new List<Pair>(){ new Pair(0, 2),    new Pair(3),    new Pair(-1),   new Pair(4),    new Pair(5),    new Pair(6),    new Pair(7), new Pair(8),   new Pair(9),    new Pair(10, 12) }},
			{ Type.Q3, new List<Pair>(){ new Pair(0, 2),    new Pair(3),    new Pair(4),    new Pair(5),    new Pair(6),    new Pair(7),    new Pair(8), new Pair(9),   new Pair(10),   new Pair(11, 12) }},
			{ Type.Q4, new List<Pair>(){ new Pair(0, 1),    new Pair(2),    new Pair(3),    new Pair(4),    new Pair(5),    new Pair(6,7),  new Pair(8), new Pair(9),   new Pair(10),   new Pair(11, 12) }},
			{ Type.MD, new List<Pair>(){ new Pair(0, 2),    new Pair(3),    new Pair(4),    new Pair(5),    new Pair(6),    new Pair(7),    new Pair(8), new Pair(9),   new Pair(10),   new Pair(11, 12) }}
		};

		public static void LoadTest()
		{
			ParseQuestions();
			result = new TestResult();
		}

		public static KettelTestQuestion GetNextQuestion()
		{
			currentIterator++;

			if (questions.Count <= currentIterator)
				return null;

			if (deniedTypes.Contains(questions[currentIterator].type))
				return GetNextQuestion();

			return questions[currentIterator];
		}
	
		private static void ParseQuestions()
		{
			questions = new List<KettelTestQuestion>();

			string json = File.ReadAllText("Questions.json");
			File.Delete("Questions.json");
			JObject jsonresult = JsonConvert.DeserializeObject<JObject>(json);
			JArray parsedQuestion = (JArray) jsonresult["questions"];

			for (int i = 0; i < parsedQuestion.Count; i++)
			{
				string text = (string) parsedQuestion[i]["text"];

				Type type;
				Enum.TryParse((string) parsedQuestion[i]["type"], out type);

				JArray jsonAnswers = (JArray) parsedQuestion[i]["answers"];
				List<Answer> answers = new List<Answer>();

				for (int j = 0; j < jsonAnswers.Count; j++)
					answers.Add(new Answer((string) jsonAnswers[j]["answer"], int.Parse(jsonAnswers[j]["points"].ToString())));

				questions.Add(new KettelTestQuestion(text, type, answers));
			}
		}

		public static int GetAnswer(Type type)
		{
			return result.GetValue(type);
		}

		public static int GetPoints(Type type, int points)
		{
			List<Pair> pairList = pointsDictionary[type];

			for (int i = 0; i < pairList.Count; i++)
				if (pairList[i].InRange(points))
					return i + 1;

			Console.WriteLine("ERROR IN GetPoints");
			return -1;
		}
	}
}
