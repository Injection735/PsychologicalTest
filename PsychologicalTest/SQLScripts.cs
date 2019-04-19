using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace PsychologicalTest
{//8ovt47ymny937b3qy0nny390q
	static class SQLScripts
	{
		private static Dictionary<char, char> leet = new Dictionary<char, char>()
		{
			{ 'й', 'q' },
			{ 'ц', 'w' },
			{ 'у', 'e' },
			{ 'к', 'r' },
			{ 'е', 't' },
			{ 'н', 'y' },
			{ 'г', 'u' },
			{ 'ш', 'i' },
			{ 'щ', 'o' },
			{ 'з', 'p' },
			{ 'х', '[' },
			{ 'ъ', ']' },
			{ 'ф', 'a' },
			{ 'ы', 's' },
			{ 'в', 'd' },
			{ 'а', 'f' },
			{ 'п', 'g' },
			{ 'р', 'h' },
			{ 'о', 'j' },
			{ 'л', 'k' },
			{ 'д', 'l' },
			{ 'ж', ';' },
			{ 'э', '\'' },
			{ 'я', 'z' },
			{ 'ч', 'x' },
			{ 'с', 'c' },
			{ 'м', 'v' },
			{ 'и', 'b' },
			{ 'т', 'n' },
			{ 'ь', 'm' },
			{ 'б', ',' },
			{ 'ю', '.' },
		};

		public static void AddUsersScript()
		{
			string connectionString = "Server=alexphost.ru;Port=25435; User Id=postgres;Password=8ovt47ymny937b3qy0nny390q;Database=postgres;";
			string sql = "INSERT INTO public.\"TestUsers\" (\"user\") VALUES(@user)";

			NpgsqlConnection connection = new NpgsqlConnection(connectionString);

			connection.Open();
			string[] text = File.ReadAllLines("users.txt");

			for (int i = 0; i < text.Length; i++)
			{
				NpgsqlCommand command = new NpgsqlCommand(sql, connection);
				
				command.Parameters.Add(new NpgsqlParameter("@user", PrepareUserName(text[i].ToLower())));
				command.ExecuteScalar();
			}

			connection.Close();
		}

		public static string PrepareUserName(string name)
		{
			string result = name;
			result = result.Replace(".", "");
			result = result.Replace(" ", "");
			return result.ToLower();
		}

		public static bool VerifyUser(string user)
		{
			string connectionString = "Server=alexphost.ru;Port=25435; User Id=user_pupil;Password=1337qwe;Database=postgres;";
			string sql = "SELECT * FROM public.\"TestUsers\" WHERE public.\"TestUsers\".user = @user";

			NpgsqlConnection connection = new NpgsqlConnection(connectionString);

			NpgsqlCommand command = new NpgsqlCommand(sql, connection);
			command.Parameters.Add(new NpgsqlParameter("@user", PrepareUserName(user)));
			connection.Open();
			var result = command.ExecuteScalar();
			connection.Close();
			return result != null;
		}

		public static void SetAnswers()
		{
			string connectionString = "Server=alexphost.ru;Port=25435; User Id=user_pupil;Password=1337qwe;Database=postgres;";
			string sql = "INSERT INTO public.\"TestResults\" (\"user_name\", \"kettel_time\", \"miss_time\", \"Q1\", \"B\", \"Q3\", \"Q4\", \"math_result\", \"math_time\", \"memory_count\", \"encryption_count\", \"miss_count\")"
			+ $"VALUES(@user_name, {SQLData.kettel_time}, {SQLData.miss_time}, {SQLData.Q1}, {SQLData.B}, {SQLData.Q3}, {SQLData.Q4}, {SQLData.math_result}, {SQLData.math_time}, {SQLData.memory_count}, {SQLData.encryption_count}, {SQLData.miss_count});";

			NpgsqlConnection connection = new NpgsqlConnection(connectionString);
			NpgsqlCommand command = new NpgsqlCommand(sql, connection);
			command.Parameters.Add(new NpgsqlParameter("@user_name", SQLData.user_name));

			connection.Open();
			command.ExecuteScalar();
			connection.Close();
		}

		public static void RemoveUser()
		{
			string connectionString = "Server=alexphost.ru;Port=25435; User Id=postgres;Password=8ovt47ymny937b3qy0nny390q;Database=postgres;";
			string sql = "DELETE FROM public.\"TestResults\" WHERE public.\"TestResults\".user = @user";

			NpgsqlConnection connection = new NpgsqlConnection(connectionString);
			NpgsqlCommand command = new NpgsqlCommand(sql, connection);
			command.Parameters.Add(new NpgsqlParameter("@user", PrepareUserName(SQLData.user_name)));

			connection.Open();
			command.ExecuteScalar();
			connection.Close();
		}
	}
}
