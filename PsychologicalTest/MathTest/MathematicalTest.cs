using PsychologicalTest.MathTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalTest
{
	class MathematicalTest
	{
		public static List<MathTestQuestion> questions = new List<MathTestQuestion>()
		{
			new MathTestQuestion("Используются 7 кубиков Кооса. Раскладываются двумя группами (красный цвет наверху) по 3 и 4 кубика.\nРасстояние между кубиками 0.5 см, а между группами - 2 см. Сколько кубиков получится, если сложить их в одно место?", 7),
			new MathTestQuestion("Если у вас было 3 книги и вы одну отдали, сколько книг у вас осталось?", 2),
			new MathTestQuestion("Сколько будет 4 руб. и 5 руб. (в рублях)", 9),
			new MathTestQuestion("Человек купил значок, стоящий 6 коп., и дал 10 коп. Сколько он должен получить сдачи? (в копейках)", 4),
			new MathTestQuestion("Ученик купил 6 тетрадей по 25 коп. Сколько денег он заплатил? (в рублях)", 1.5),
			new MathTestQuestion("Сколько кг в 2.5 центнерах? (в кг)", 250),
			new MathTestQuestion("Сколько пирожков можно купить за 36 коп, если 1 пирожок стоит 6 коп? (в копейках)", 6),
			new MathTestQuestion("Сколько времени нужно человеку, чтобы пройти 24 км, если он идет со скоростью 3 км/час? (в часах)", 8),
			new MathTestQuestion("Человек купил 7 почтовых марок по 2 коп. и дал полрубля. Сколько он должен получить сдачи? (в копейках)", 36),
			new MathTestQuestion("Из 18 руб. человек истратил 7 руб. 50 коп. Сколько денег у него осталось? (в рублях)", 10.5),
			new MathTestQuestion("Две консервных банки вместе стоят 31 коп. Сколько стоят 12 таких банок? (в рублях)", 1.86),
			new MathTestQuestion("Старую мебель человек купил за 2/3 стоимости новой мебели. Он заплатил 400 руб. Сколько стоит новая мебель? (в рублях)", 600),
			new MathTestQuestion("Пальто 1 сорта стоит 60 руб., пальто 2 сорта на 15% дешевле. Сколько стоит пальто 2 сорта? (в рублях)", 51),
			new MathTestQuestion("8 человек могут выполнить работу за 6 дней. Сколько нужно людей, чтобы выполнить эту работу за полдня?", 96),
		};
		
		public static List<TestControlElement> visualElements = new List<TestControlElement>();

		public static List<double> answers = new List<double>();
	}

	struct MathTestQuestion
	{
		public string description;
		public double answer;

		public MathTestQuestion(string description, double answer)
		{
			this.description = description;
			this.answer = answer;
		}
	}
}
