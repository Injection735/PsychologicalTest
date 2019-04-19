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
		private static bool addMode = !true;
		[STAThread]
		private static void Main(string[] args)
		{
			if (!addMode)
			{
				JsonMaker.CreateKettelJson();
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				mainForm = new MainWindow();
				Application.Run(mainForm);
			}
			else
				SQLScripts.AddUsersScript();
		}
	}
}
