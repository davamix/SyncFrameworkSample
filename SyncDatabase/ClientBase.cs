using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;

namespace SyncDatabase
{
	public abstract class ClientBase
	{
		public SqlSyncProvider SyncProvider { get; }

		protected ClientBase(string connectionString, string scope)
		{
			if(string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(scope))
				throw new ArgumentNullException();

			var connection = new SqlConnection(connectionString);

			SyncProvider = new SqlSyncProvider(scope, connection);

			SyncProvider.ApplyChangeFailed += SyncProviderOnApplyChangeFailed;
			SyncProvider.ApplyMetadataFailed += SyncProviderOnApplyMetadataFailed;
			SyncProvider.ApplyingChanges += SyncProviderOnApplyingChanges;
			SyncProvider.BatchApplied += SyncProviderOnBatchApplied;
			SyncProvider.BatchSpooled += SyncProviderOnBatchSpooled;
			SyncProvider.ChangesApplied += SyncProviderOnChangesApplied;
			SyncProvider.ChangesSelected += SyncProviderOnChangesSelected;
			SyncProvider.DbConnectionFailure += SyncProviderOnDbConnectionFailure;
			SyncProvider.SelectingChanges += SyncProviderOnSelectingChanges;
			SyncProvider.SyncPeerOutdated += SyncProviderOnSyncPeerOutdated;
			SyncProvider.SyncProgress += SyncProviderOnSyncProgress;
		}


		protected virtual void ShowMessage(string caller, string message = "", [CallerMemberName] string eventName = "")
		{
			Console.WriteLine($"[{caller}] :: [{eventName}] :: {message}");
		}

		protected abstract void SyncProviderOnSyncProgress(object sender, DbSyncProgressEventArgs dbSyncProgressEventArs);
		protected abstract void SyncProviderOnSyncPeerOutdated(object sender, DbOutdatedEventArgs dbOutdatedEventArgs);
		protected abstract void SyncProviderOnSelectingChanges(object sender, DbSelectingChangesEventArgs dbSelectingChangesEventArgs);
		protected abstract void SyncProviderOnDbConnectionFailure(object sender, DbConnectionFailureEventArgs dbConnectionFailureEventArgs);
		protected abstract void SyncProviderOnChangesSelected(object sender, DbChangesSelectedEventArgs dbChangesSelectedEventArgs);
		protected abstract void SyncProviderOnChangesApplied(object sender, DbChangesAppliedEventArgs dbChangesAppliedEventArgs);
		protected abstract void SyncProviderOnBatchSpooled(object sender, DbBatchSpooledEventArgs dbBatchSpooledEventArgs);
		protected abstract void SyncProviderOnBatchApplied(object sender, DbBatchAppliedEventArgs dbBatchAppliedEventArgs);
		protected abstract void SyncProviderOnApplyingChanges(object sender, DbApplyingChangesEventArgs dbApplyingChangesEventArgs);
		protected abstract void SyncProviderOnApplyMetadataFailed(object sender, ApplyMetadataFailedEventArgs applyMetadataFailedEventArgs);
		protected abstract void SyncProviderOnApplyChangeFailed(object sender, DbApplyChangeFailedEventArgs dbApplyChangeFailedEventArgs);
	}
}
