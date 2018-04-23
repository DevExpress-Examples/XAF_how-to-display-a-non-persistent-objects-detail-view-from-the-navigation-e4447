Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Web
Imports DevExpress.ExpressApp.Xpo

Namespace NonPersistentDetailViewNavigationExample.Web
    Partial Public Class NonPersistentDetailViewNavigationExampleAspNetApplication
        Inherits WebApplication

        Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
        Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
        Private module3 As NonPersistentDetailViewNavigationExample.Module.NonPersistentDetailViewNavigationExampleModule
        Private sqlConnection1 As System.Data.SqlClient.SqlConnection

        Public Sub New()
            InitializeComponent()
        End Sub

        Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
            args.ObjectSpaceProvider = New XPObjectSpaceProvider(args.ConnectionString, args.Connection)
        End Sub

        Private Sub NonPersistentDetailViewNavigationExampleAspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
            e.Updater.Update()
            e.Handled = True
        End Sub

        Private Sub InitializeComponent()
            Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
            Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
            Me.module3 = New NonPersistentDetailViewNavigationExample.Module.NonPersistentDetailViewNavigationExampleModule()
            Me.sqlConnection1 = New System.Data.SqlClient.SqlConnection()
            DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            ' 
            ' sqlConnection1
            ' 
            Me.sqlConnection1.ConnectionString = "Integrated Security=SSPI;Pooling=false;Data Source=.\SQLEXPRESS;Initial Catalog=NonPersistentDetailViewNavigationExample"
            Me.sqlConnection1.FireInfoMessageEventOnUserErrors = False
            ' 
            ' NonPersistentDetailViewNavigationExampleAspNetApplication
            ' 
            Me.ApplicationName = "NonPersistentDetailViewNavigationExample"
            Me.Connection = Me.sqlConnection1
            Me.Modules.Add(Me.module1)
            Me.Modules.Add(Me.module2)
            Me.Modules.Add(Me.module3)

            DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
    End Class
End Namespace
