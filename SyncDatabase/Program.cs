using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;

namespace SyncDatabase
{
	class Program
	{
		static void Main(string[] args)
		{
			var clientLocal = new ClientLocal(ConfigurationManager.AppSettings["connectionLocal"], "ProductScope");
			var clientRemote = new ClientRemote(ConfigurationManager.AppSettings["connectionRemote"], "ProductScope");

			var orchestrator = new SyncOrchestrator
			                   {
				                   LocalProvider = clientLocal.SyncProvider,
				                   RemoteProvider = clientRemote.SyncProvider,
				                   Direction = SyncDirectionOrder.UploadAndDownload
			                   };

			var option = string.Empty;

			do
			{
				Run(orchestrator);
				Console.WriteLine("(exit to finish) => ");
				option = Console.ReadLine();
			} while (!string.Equals(option, "exit"));

		}

		private static void Run(SyncOrchestrator orchestrator)
		{
			var syncStats = orchestrator.Synchronize();

			Console.WriteLine("Start Time: " + syncStats.SyncStartTime);
			Console.WriteLine("Total Changes Uploaded: " + syncStats.UploadChangesTotal);
			Console.WriteLine("Total Changes Downloaded: " + syncStats.DownloadChangesTotal);
			Console.WriteLine("Complete Time: " + syncStats.SyncEndTime);
			Console.WriteLine(String.Empty);
		}
	}
}
