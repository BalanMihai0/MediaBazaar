using StoreLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataLibrary
{
	public class AnnouncementDataHandler : IAnnouncementDataInterface
	{
		private const string connectionString = "Server=mssqlstud.fhict.local;Database=dbi501909_s2g1grp;User Id=dbi501909_s2g1grp;Password=password;";

		public Announcement AddAnouncement(Announcement a)
		{
			string query = $"INSERT INTO Announcements (Title, Description, PosterID) VALUES ('{a.Title}', '{a.Description}', {a.PosterID})";

			using SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();

			SqlTransaction transaction = connection.BeginTransaction();

			try
			{
				using SqlCommand command = new SqlCommand(query, connection, transaction);
				command.ExecuteNonQuery();

				transaction.Commit();

				return a;
			}
			catch (Exception)
			{
				transaction.Rollback();
				throw;
			}
		}

		public bool EditAnnouncement(Announcement a)
		{
			string query = $"UPDATE Announcements SET Title = '{a.Title}', Description = '{a.Description}', PosterID = {a.PosterID} WHERE ID = {a.ID}";

			using SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();

			SqlTransaction transaction = connection.BeginTransaction();

			try
			{
				using SqlCommand command = new SqlCommand(query, connection, transaction);
				command.ExecuteNonQuery();

				transaction.Commit();

				return true;
			}
			catch (Exception)
			{
				transaction.Rollback();
				return false;
			}
		}

		public List<Announcement> GetAllAnnouncements()
		{
			string query = $"SELECT * FROM Announcements";

			List<Announcement> list = new List<Announcement>();

			using SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();

			try
			{
				using SqlCommand command = new SqlCommand(query, connection);
				using SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					Announcement a = new Announcement();
					a.ID = reader.GetInt32(0);
					a.Title = reader.GetString(1);
					if (!reader.IsDBNull(2))
					{
						a.Description = reader.GetString(2);
					}
					a.PosterID = reader.GetInt32(3);

					list.Add(a);
				}

				return list;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public List<Announcement> GetAnnouncementsByPosterID(int posterID)
		{
			string query = $"SELECT * FROM Announcements WHERE PosterID = {posterID}";

			List<Announcement> list = new List<Announcement>();

			using SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();

			try
			{
				using SqlCommand command = new SqlCommand(query, connection);
				using SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					Announcement a = new Announcement();
					a.ID = reader.GetInt32(0);
					a.Title = reader.GetString(1);
					if (!reader.IsDBNull(2))
					{
						a.Description = reader.GetString(2);
					}
					a.PosterID = reader.GetInt32(3);

					list.Add(a);
				}

				return list;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public bool RemoveAnnouncement(Announcement a)
		{
			string query = $"DELETE FROM Announcements WHERE ID = {a.ID}";

			using SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();

			SqlTransaction transaction = connection.BeginTransaction();

			try
			{
				using SqlCommand command = new SqlCommand(query, connection, transaction);
				command.ExecuteNonQuery();

				transaction.Commit();

				return true;
			}
			catch (Exception)
			{
				transaction.Rollback();
				return false;
			}
		}
	}
}
