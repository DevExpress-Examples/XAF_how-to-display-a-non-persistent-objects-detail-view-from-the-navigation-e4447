Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating
Imports NonPersistentDetailViewNavigationExample.Module.BusinessObjects

Namespace NonPersistentDetailViewNavigationExample.Module.DatabaseUpdate
    Public Class Updater
        Inherits ModuleUpdater

        Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
            MyBase.New(objectSpace, currentDBVersion)
        End Sub
        Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
            MyBase.UpdateDatabaseAfterUpdateSchema()
#If Not EASYTEST Then
            ' Create 100 Issue objects with random Status:
            Dim random As New Random()
            For i As Integer = 0 To 99
                Dim issue As Issue = ObjectSpace.CreateObject(Of Issue)()
                issue.Subject = String.Format("Issue {0:D3}", i)
                If random.Next(3) = 0 Then
                    issue.Status = IssueStatus.Active
                Else
                    issue.Status = IssueStatus.Closed
                End If
            Next i
#End If
        End Sub
    End Class
End Namespace
