using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace PsychologicalTest
{
	class Program
	{
		public static MainWindow mainForm = null;
		[STAThread]
		private static void Main(string[] args)
		{
			JsonMaker.CreateKettelJson();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			mainForm = new MainWindow();
			Application.Run(mainForm);
			return;
			
			Console.WriteLine("Определение личности человека по тесту Кеттелла форма C");
			Console.WriteLine("1. Не нужно тратить много времени на обдумывание ответов. Давайте тот ответ, который первым придет Вам в голову.\nКонечно, вопросы часто будут сформулированы не так подробно, как Вам хотелось бы. В таком случае старайтесь представить себе «среднюю», наиболее частую ситуацию, которая соответствует смыслу вопроса и, исходя из этого, выбирайте ответ.\nОтвечать надо как можно точнее, но не слишком медленно.");
			Console.WriteLine("2. Старайтесь не прибегать к промежуточным, неопределенным ответам\n(типа «не знаю», «нечто среднее» и т.п.) слишком часто.");
			Console.WriteLine("3. Обязательно отвечайте на все вопросы подряд, ничего не пропуская.\nВозможно, некоторые вопросы покажутся Вам не очень точно сформулированными, но и тогда постарайтесь найти наиболее точный ответ.\nНекоторые вопросы могут показаться Вам личными, но Вы можете быть уверены в том, что ответы не будут разглашены.\nОтветы могут быть расшифрованы только с помощью специального «ключа», который находится у экспериментатора.Причем ответы на каждый отдельный вопрос вообще не будут рассматриваться: нас интересуют только обобщенные показатели.");
			Console.WriteLine("4. Не старайтесь произвести хорошее впечатление своими ответами, они должны соответствовать действительности.\nВ этом случае Вы сможете лучше узнать себя и очень поможете нам в нашей работе.Заранее благодарим Вас за помощь в отработке методики.");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("Нажмите ENTER чтобы начать тестирование");

			Console.ReadLine();
		}

		//private static void StartTest()
		//{
		//	for (int i = 0; i < questions.Count; i++)
		//	{
		//		Console.Clear();
		//		Console.WriteLine(questions[i].text);
		//		for (int j = 0; j < questions[i].answers.Count; j++)
		//			Console.WriteLine(questions[i].answers[j].name);
		//		
		//		ConsoleKeyInfo key = Console.ReadKey();
		//		int variant;
		//
		//		while (true)
		//		{
		//			if (int.TryParse(key.KeyChar.ToString(), out variant))
		//				if (variant > 0 && variant <= questions[i].answers.Count)
		//					break;
		//
		//			key = Console.ReadKey();
		//		}
		//
		//		result.AddValue(questions[i].type, questions[i].answers[variant - 1].points);
		//	}
		//}
	}
}
