using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;

namespace SyncDatabaseProvisioner
{
	class Program
	{
		static void Main(string[] args)
		{
			var option = string.Empty;

			do
			{
				Console.WriteLine("1. Provision local");
				Console.WriteLine("2. Provision remote");
				Console.Write("(enter to exit) => ");
				option = Console.ReadLine();

				if (string.Equals(option, "1"))
					ProvisioningLocal();
				if (string.Equals(option, "2"))
					ProvisioningRemote();

			} while (!string.IsNullOrEmpty(option));
		}

		private static void ProvisioningLocal()
		{
			var connectionLocal = new SqlConnection(ConfigurationManager.AppSettings["connectionLocal"]);
			var connectionRemote = new SqlConnection(ConfigurationManager.AppSettings["connectionRemote"]);
			
			var descriptionScope = SqlSyncDescriptionBuilder.GetDescriptionForScope("ProductScope", connectionRemote);
			var provisionLocal = new SqlSyncScopeProvisioning(connectionLocal, descriptionScope);

			try
			{
				provisionLocal.Apply();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[ERROR] {ex.Message}");
			}
			
		}

		private static void ProvisioningRemote()
		{
			var connectionRemote = new SqlConnection(@"Data Source=davamixsample.database.windows.net;Initial Catalog=sampleDB;Integrated Security=False;User ID=davamix;Password=Aztroline13;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
			
			var descriptionScope = new DbSyncScopeDescription("ProductScope");
			var tableDescription = SqlSyncDescriptionBuilder.GetDescriptionForTable("SalesLT.Product", connectionRemote);
			descriptionScope.Tables.Add(tableDescription);

			var provisionRemote = new SqlSyncScopeProvisioning(connectionRemote, descriptionScope);
			provisionRemote.SetCreateTableDefault(DbSyncCreationOption.Skip);

			try
			{
				provisionRemote.Apply();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[ERROR] {ex.Message}");
				throw;
			}
			

		}
	}
}
