using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalTest
{
	class TestResult
	{
		private static Dictionary<KettelTest.Type, Result> results = new Dictionary<KettelTest.Type, Result>() 
		{
			{ KettelTest.Type.MD, new Result("Низкая самооценка", "Высокая самооценка") },
			{ KettelTest.Type.A, new Result("Замкнутость", "Общительность") },
			{ KettelTest.Type.B, new Result("Конкретное мышление", "Абстрактное мышление") },
			{ KettelTest.Type.C, new Result("Эмоциональная нестабильность", "Эмоциональная стабильность") },
			{ KettelTest.Type.E, new Result("Покорность", "Доминантность") },
			{ KettelTest.Type.F, new Result("Рассудительность", "Безрасудство") },
			{ KettelTest.Type.G, new Result("Низкая нормативность поведения", "Высокая нормативность поведения") },
			{ KettelTest.Type.H, new Result("Робость", "Смелость") },
			{ KettelTest.Type.I, new Result("Жестокость", "Чувствительность") },
			{ KettelTest.Type.L, new Result("Доверчивость", "Подозрительность") },
			{ KettelTest.Type.M, new Result("Практичность", "Мечтательность") },
			{ KettelTest.Type.N, new Result("Прямолинейность", "Проницательность") },
			{ KettelTest.Type.O, new Result("Спокойствие", "Тревожность") },
			{ KettelTest.Type.Q1, new Result("Консерватизм", "Радикализм") },
			{ KettelTest.Type.Q2, new Result("Конформизм", "Нонконформизм") },
			{ KettelTest.Type.Q3, new Result("Низкий самоконтроль", "Высокий самоконтроль") },
			{ KettelTest.Type.Q4, new Result("Расслабленность", "Напряженность") },
		};

		private Dictionary<KettelTest.Type, int> pointsDictionary; 
		
		public TestResult()
		{
			pointsDictionary = new Dictionary<KettelTest.Type, int>();
			
			foreach (KettelTest.Type type in Enum.GetValues(typeof(KettelTest.Type)))
				pointsDictionary.Add(type, 0);
		}

		public void AddValue(KettelTest.Type type, int points)
		{
			pointsDictionary[type] += points;
		}

		public int GetValue(KettelTest.Type type)
		{
			return pointsDictionary[type];
		}

		public string GetResult()
		{
			string totalText = "";

			foreach (KeyValuePair<KettelTest.Type, int> item in pointsDictionary)
			{ 
				int points = KettelTest.GetPoints(item.Key, item.Value);
				totalText += item.Key.ToString() + ": " + points.ToString() + " " + (points > 6 ? results[item.Key].high : results[item.Key].low) + "\n";
			}	
			totalText += "\nКраткая характеристика\n";

			foreach (KeyValuePair<KettelTest.Type, int> item in pointsDictionary)
			{ 
				int points = KettelTest.GetPoints(item.Key, item.Value);
				totalText += item.Key.ToString() + ": " +  BriefDescription.GetDescription(item.Key) + "\n\n";
			}

			return totalText;
		}
	}

	struct Result
	{
		public string low;
		public string high;

		public Result(string low, string high)
		{
			this.low = low;	
			this.high = high;
		}
	}
}
