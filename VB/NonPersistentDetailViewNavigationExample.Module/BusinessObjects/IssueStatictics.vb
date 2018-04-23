Imports System
Imports System.Collections.Generic
Imports DevExpress.Persistent.Base
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp.DC

Namespace NonPersistentDetailViewNavigationExample.Module.BusinessObjects
    <DomainComponent, NavigationItem("Issues"), ImageName("BO_Report")> _
    Public Class IssueStatistics
        Public Property ActiveIssuesCount() As Integer
        Public Property ClosedIssuesCount() As Integer
        Public Property TotalIssuesCount() As Integer
    End Class
End Namespace
