Imports System
Imports System.Collections.Generic

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating
Imports NonPersistentDetailViewNavigationExample.Module.BusinessObjects
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Data.Filtering


Namespace NonPersistentDetailViewNavigationExample.Module
    Public NotInheritable Partial Class NonPersistentDetailViewNavigationExampleModule
        Inherits ModuleBase

        Public Sub New()
            InitializeComponent()
        End Sub
        Public Overrides Function GetModuleUpdaters(ByVal objectSpace As IObjectSpace, ByVal versionFromDB As Version) As IEnumerable(Of ModuleUpdater)
            Dim updater As ModuleUpdater = New DatabaseUpdate.Updater(objectSpace, versionFromDB)
            Return New ModuleUpdater() { updater }
        End Function
        Public Overrides Sub Setup(ByVal application As XafApplication)
            MyBase.Setup(application)
            AddHandler application.CustomProcessShortcut, AddressOf application_CustomProcessShortcut
        End Sub

        Private Sub application_CustomProcessShortcut(ByVal sender As Object, ByVal e As CustomProcessShortcutEventArgs)
            If e.Shortcut.ViewId = "IssueStatistics_ListView" Then
                Dim nonPersistentObjectSpace As IObjectSpace = Application.CreateObjectSpace(GetType(IssueStatistics))
                Dim issueStatistics As New IssueStatistics()
                Using objectSpace As IObjectSpace = Application.CreateObjectSpace(GetType(Issue))
                    issueStatistics.ActiveIssuesCount = objectSpace.GetObjectsCount(GetType(Issue), CriteriaOperator.Parse("[Status] == 'Active'"))
                    issueStatistics.ClosedIssuesCount = objectSpace.GetObjectsCount(GetType(Issue), CriteriaOperator.Parse("[Status] == 'Closed'"))
                    issueStatistics.TotalIssuesCount = issueStatistics.ActiveIssuesCount + issueStatistics.ClosedIssuesCount
                End Using
                e.View = Application.CreateDetailView(nonPersistentObjectSpace, issueStatistics, True)
                e.View.AllowEdit("CanEditIssueStatistics") = False
                e.Handled = True
            End If
        End Sub
    End Class
End Namespace
