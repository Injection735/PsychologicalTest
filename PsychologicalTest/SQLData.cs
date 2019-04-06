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
		public SQLData()
		{
			string connectionString = "Server=127.0.0.1;Port=5432;User Id=user_pupil;Password=1337qwe;Database=diplom;";
			string sql = "SELECT * FROM public.\"TestResults\"";

			NpgsqlConnection connection = new NpgsqlConnection(connectionString);
			NpgsqlCommand command = new NpgsqlCommand(sql, connection);

			connection.Open();
			var result = command.ExecuteScalar().ToString();
			connection.Close();
		}
	}
}
