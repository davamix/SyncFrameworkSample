using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Synchronization.Data;

namespace SyncDatabase
{
	public class ClientRemote : ClientBase
	{
		public ClientRemote(string connectionString, string scope) : base(connectionString, scope)
		{
		}

		protected override void SyncProviderOnSyncProgress(object sender, DbSyncProgressEventArgs dbSyncProgressEventArs)
		{
			ShowMessage("Remote");
		}

		protected override void SyncProviderOnSyncPeerOutdated(object sender, DbOutdatedEventArgs dbOutdatedEventArgs)
		{
			ShowMessage("Remote");
		}

		protected override void SyncProviderOnSelectingChanges(object sender, DbSelectingChangesEventArgs dbSelectingChangesEventArgs)
		{
			ShowMessage("Remote");
		}

		protected override void SyncProviderOnDbConnectionFailure(object sender, DbConnectionFailureEventArgs dbConnectionFailureEventArgs)
		{
			ShowMessage("Remote");
		}

		protected override void SyncProviderOnChangesSelected(object sender, DbChangesSelectedEventArgs dbChangesSelectedEventArgs)
		{
			ShowMessage("Remote");
		}

		protected override void SyncProviderOnChangesApplied(object sender, DbChangesAppliedEventArgs dbChangesAppliedEventArgs)
		{
			ShowMessage("Remote");
		}

		protected override void SyncProviderOnBatchSpooled(object sender, DbBatchSpooledEventArgs dbBatchSpooledEventArgs)
		{
			ShowMessage("Remote");
		}

		protected override void SyncProviderOnBatchApplied(object sender, DbBatchAppliedEventArgs dbBatchAppliedEventArgs)
		{
			ShowMessage("Remote");
		}

		protected override void SyncProviderOnApplyingChanges(object sender, DbApplyingChangesEventArgs dbApplyingChangesEventArgs)
		{
			ShowMessage("Remote");
		}

		protected override void SyncProviderOnApplyMetadataFailed(object sender, ApplyMetadataFailedEventArgs applyMetadataFailedEventArgs)
		{
			ShowMessage("Remote");
		}

		protected override void SyncProviderOnApplyChangeFailed(object sender, DbApplyChangeFailedEventArgs dbApplyChangeFailedEventArgs)
		{
			ShowMessage("Remote");
		}
	}
}
