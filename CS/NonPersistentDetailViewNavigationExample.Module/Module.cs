using System;
using System.Collections.Generic;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using NonPersistentDetailViewNavigationExample.Module.BusinessObjects;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;


namespace NonPersistentDetailViewNavigationExample.Module {
    public sealed partial class NonPersistentDetailViewNavigationExampleModule : ModuleBase {
        public NonPersistentDetailViewNavigationExampleModule() {
            InitializeComponent();
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }
        public override void Setup(XafApplication application) {
            base.Setup(application);
            application.CustomProcessShortcut += application_CustomProcessShortcut;
        }

        void application_CustomProcessShortcut(object sender, CustomProcessShortcutEventArgs e) {
            if (e.Shortcut.ViewId == "IssueStatistics_ListView") {
                IObjectSpace objectSpace = Application.CreateObjectSpace();
                IssueStatistics issueStatistics = new IssueStatistics();
                issueStatistics.ActiveIssuesCount =
                    objectSpace.GetObjectsCount(typeof(Issue), 
                    CriteriaOperator.Parse("[Status] == 'Active'"));
                issueStatistics.ClosedIssuesCount =
                    objectSpace.GetObjectsCount(typeof(Issue),
                    CriteriaOperator.Parse("[Status] == 'Closed'"));
                issueStatistics.TotalIssuesCount = issueStatistics.ActiveIssuesCount + issueStatistics.ClosedIssuesCount;
                e.View = Application.CreateDetailView(objectSpace, issueStatistics, true);
                e.View.AllowEdit["CanEditIssueStatistics"] = false;
                e.Handled = true;
            }
        }
    }
}
