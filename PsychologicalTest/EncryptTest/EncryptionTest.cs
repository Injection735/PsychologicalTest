using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalTest.EncryptTest
{
	class EncryptionTest
	{
		public static List<bool> answers = new List<bool>();

		private static Dictionary<int, char> legend;

		public static Dictionary<int, char> GetLegend()
		{
			if (legend == null)
			{ 
				legend = new Dictionary<int, char>()
				{
					{1, GetRandomChar()},
					{2, GetRandomChar()},
					{3, GetRandomChar()},
					{4, GetRandomChar()},
					{5, GetRandomChar()},
					{6, GetRandomChar()},
					{7, GetRandomChar()},
					{8, GetRandomChar()},
					{9, GetRandomChar()},
				};
			}

			return legend;
		}

		private static List<char> chars = null;

		private static char GetRandomChar()
		{ 
			if (chars == null)
			{
				chars = new List<char>();

				for (int i = 97; i < 123; i++)
				{ 
					chars.Add((char) i);
				}

				Shuffle(chars);
			}

			char ch = chars[0];
			chars.RemoveAt(0);
			return ch;
		}

		private static Random rng = new Random();

		public static void Shuffle(List<char> list)
		{
			int n = list.Count;
			while (n > 1)
			{
				n--;
				int k = rng.Next(n + 1);
				char value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}
	}
}
