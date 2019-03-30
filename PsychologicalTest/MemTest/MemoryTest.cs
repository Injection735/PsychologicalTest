﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalTest.MemTest
{
	class MemoryTest
	{
		private static int numCount = 4;
		private static int tryCount = 2;
		private static int symbolLength = 0;

		private static Random random = new Random();

		private static string previousRow;

		public static string GetRow()
		{
			previousRow = "";

			for (int i = 0; i < numCount; i++)
			{
				previousRow += random.Next(10);

				if (i != numCount - 1)
					previousRow += " ";
			}

			return previousRow;
		}

		public static bool CanBeContinued(string row)
		{
			symbolLength = Math.Max(previousRow.Replace(" ", "").Length, symbolLength);
			if (previousRow == ReverseString(row))
			{
				numCount++;
				return true;
			}

			numCount--;
			tryCount--;
			return tryCount > 0;
		}

		private static string ReverseString(string s)
		{
			char[] arr = s.ToCharArray();
			Array.Reverse(arr);
			return new string(arr);
		}
	}
}