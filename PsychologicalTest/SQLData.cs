using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalTest
{
	class SQLData
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

		public SQLData()
		{
			string connectionString = "Server=alexphost.ru;Port=25435; User Id=user_pupil;Password=1337qwe;Database=postgres;";
			string sql = "INSERT INTO public.\"TestResults\" (\"user_name\", \"kettel_time\", \"miss_time\", \"Q1\", \"B\", \"Q3\", \"Q4\", \"math_result\", \"math_time\", \"memory_count\", \"encryption_count\", \"miss_count\")"
			+ $"VALUES(@user_name, {kettel_time}, {miss_time}, {Q1}, {B}, {Q3}, {Q4}, {math_result}, {math_time}, {memory_count}, {encryption_count}, {miss_count});";

			NpgsqlConnection connection = new NpgsqlConnection(connectionString);
			NpgsqlCommand command = new NpgsqlCommand(sql, connection);
			command.Parameters.Add(new NpgsqlParameter("@user_name", user_name));

			connection.Open();
			command.ExecuteScalar();
			connection.Close();
		}
	}
}
