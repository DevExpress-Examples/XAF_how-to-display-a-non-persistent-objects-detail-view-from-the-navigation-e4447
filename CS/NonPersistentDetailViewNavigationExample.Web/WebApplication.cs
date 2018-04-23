using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Xpo;

namespace NonPersistentDetailViewNavigationExample.Web {
    public partial class NonPersistentDetailViewNavigationExampleAspNetApplication : WebApplication {
        private DevExpress.ExpressApp.SystemModule.SystemModule module1;
        private DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule module2;
        private NonPersistentDetailViewNavigationExample.Module.NonPersistentDetailViewNavigationExampleModule module3;
        private System.Data.SqlClient.SqlConnection sqlConnection1;

        public NonPersistentDetailViewNavigationExampleAspNetApplication() {
            InitializeComponent();
        }

        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args) {
            args.ObjectSpaceProvider = new XPObjectSpaceProvider(args.ConnectionString, args.Connection);
        }

        private void NonPersistentDetailViewNavigationExampleAspNetApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
			e.Updater.Update();
			e.Handled = true;
        }

        private void InitializeComponent() {
            this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
            this.module2 = new DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule();
            this.module3 = new NonPersistentDetailViewNavigationExample.Module.NonPersistentDetailViewNavigationExampleModule();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = @"Integrated Security=SSPI;Pooling=false;Data Source=.\SQLEXPRESS;Initial Catalog=NonPersistentDetailViewNavigationExample";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // NonPersistentDetailViewNavigationExampleAspNetApplication
            // 
            this.ApplicationName = "NonPersistentDetailViewNavigationExample";
            this.Connection = this.sqlConnection1;
            this.Modules.Add(this.module1);
            this.Modules.Add(this.module2);
            this.Modules.Add(this.module3);
            
            this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.NonPersistentDetailViewNavigationExampleAspNetApplication_DatabaseVersionMismatch);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
    }
}
