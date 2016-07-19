using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Synchronization.Data;

namespace SyncDatabase
{
	public class ClientLocal : ClientBase
	{
		public ClientLocal(string connectionString, string scope) : base(connectionString, scope)
		{

		}

		protected override void SyncProviderOnSyncProgress(object sender, DbSyncProgressEventArgs dbSyncProgressEventArs)
		{
			ShowMessage("Local");
		}

		protected override void SyncProviderOnSyncPeerOutdated(object sender, DbOutdatedEventArgs dbOutdatedEventArgs)
		{
			ShowMessage("Local");
		}

		protected override void SyncProviderOnSelectingChanges(object sender, DbSelectingChangesEventArgs dbSelectingChangesEventArgs)
		{
			ShowMessage("Local");
		}

		protected override void SyncProviderOnDbConnectionFailure(object sender, DbConnectionFailureEventArgs dbConnectionFailureEventArgs)
		{
			ShowMessage("Local");
		}

		protected override void SyncProviderOnChangesSelected(object sender, DbChangesSelectedEventArgs dbChangesSelectedEventArgs)
		{
			ShowMessage("Local");
		}

		protected override void SyncProviderOnChangesApplied(object sender, DbChangesAppliedEventArgs dbChangesAppliedEventArgs)
		{
			ShowMessage("Local");
		}

		protected override void SyncProviderOnBatchSpooled(object sender, DbBatchSpooledEventArgs dbBatchSpooledEventArgs)
		{
			ShowMessage("Local");
		}

		protected override void SyncProviderOnBatchApplied(object sender, DbBatchAppliedEventArgs dbBatchAppliedEventArgs)
		{
			ShowMessage("Local");
		}

		protected override void SyncProviderOnApplyingChanges(object sender, DbApplyingChangesEventArgs dbApplyingChangesEventArgs)
		{
			ShowMessage("Local");
		}

		protected override void SyncProviderOnApplyMetadataFailed(object sender, ApplyMetadataFailedEventArgs applyMetadataFailedEventArgs)
		{
			ShowMessage("Local");
		}

		protected override void SyncProviderOnApplyChangeFailed(object sender, DbApplyChangeFailedEventArgs dbApplyChangeFailedEventArgs)
		{
			ShowMessage("Local");
		}
	}
}
