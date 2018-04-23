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
                Dim objectSpace As IObjectSpace = Application.CreateObjectSpace()
                Dim issueStatistics As New IssueStatistics()
                issueStatistics.ActiveIssuesCount = objectSpace.GetObjectsCount(GetType(Issue), CriteriaOperator.Parse("[Status] == 'Active'"))
                issueStatistics.ClosedIssuesCount = objectSpace.GetObjectsCount(GetType(Issue), CriteriaOperator.Parse("[Status] == 'Closed'"))
                issueStatistics.TotalIssuesCount = issueStatistics.ActiveIssuesCount + issueStatistics.ClosedIssuesCount
                e.View = Application.CreateDetailView(objectSpace, issueStatistics, True)
                e.View.AllowEdit("CanEditIssueStatistics") = False
                e.Handled = True
            End If
        End Sub
    End Class
End Namespace
