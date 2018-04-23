using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using NonPersistentDetailViewNavigationExample.Module.BusinessObjects;

namespace NonPersistentDetailViewNavigationExample.Module.DatabaseUpdate {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
#if !EASYTEST
            // Create 100 Issue objects with random Status:
            Random random = new Random();
            for (int i = 0; i < 100; i++) {
                Issue issue = ObjectSpace.CreateObject<Issue>();
                issue.Subject = String.Format("Issue {0:D3}", i);
                if (random.Next(3) == 0) issue.Status = IssueStatus.Active; 
                else issue.Status = IssueStatus.Closed;
            }
#endif
        }
    }
}
