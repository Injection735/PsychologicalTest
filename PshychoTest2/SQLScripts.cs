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
				
				command.Parameters.Add(new NpgsqlParameter("@user", PrepareUserName(text[i])));
				command.ExecuteScalar();
			}

			connection.Close();
		}

		public static string PrepareUserName(string name)
		{
			string result = name;
			result = result.Replace(".", "");
			result = result.Replace(" ", "");
			MD5 md5Hash = MD5.Create();
			result = GetMd5Hash(md5Hash, result.ToLower());
			return result;
		}

		public static string GetMd5Hash(MD5 md5Hash, string input)
		{
			byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
			StringBuilder sBuilder = new StringBuilder();
			for (int i = 0; i < data.Length; i++)
				sBuilder.Append(data[i].ToString("x2"));

			return sBuilder.ToString();
		}

		public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
		{
			string hashOfInput = GetMd5Hash(md5Hash, input);
			StringComparer comparer = StringComparer.OrdinalIgnoreCase;

			return comparer.Compare(hashOfInput, hash) == 0;
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
			string sql = "DELETE FROM public.\"TestUsers\" WHERE public.\"TestUsers\".user = @user";

			NpgsqlConnection connection = new NpgsqlConnection(connectionString);
			NpgsqlCommand command = new NpgsqlCommand(sql, connection);
			command.Parameters.Add(new NpgsqlParameter("@user", PrepareUserName(SQLData.user_name)));

			connection.Open();
			command.ExecuteScalar();
			connection.Close();
		}
	}
}
