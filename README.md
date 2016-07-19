#SyncFramework Sample
Sample to know how the SyncFramework works with databases

Walkthrough: https://msdn.microsoft.com/en-us/library/ff928500(v=sql.110).aspx

There are two project:
- SyncDatabaseProvisioner who has the code to provision both databases local and remote 
- SyncDatabase who run the synchronization process

NOTES:
- The file App.config is not updloaded with the code, so create a new one and add the connection string for local and remote databases. 
- You need to run provisioners first for both databases local and remote. 
  - At this moment I cannot run the local provisioner at my local machine due to a permissions problem... I guess, but the code should be works properly.
