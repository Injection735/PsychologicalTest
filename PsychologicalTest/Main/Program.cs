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
