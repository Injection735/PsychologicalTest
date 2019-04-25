using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalTest
{
	static class SQLData
	{
		public static string user_name = "DEFAULT";
		public static int Q1 = -1;
		public static int B;
		public static int Q3;
		public static int Q4;
		public static int math_result;
		public static int math_time;
		public static int memory_count;
		public static int encryption_count;
		public static int miss_count = -3;
		public static int kettel_time = 0;
		public static int miss_time = 0;
	}
}
