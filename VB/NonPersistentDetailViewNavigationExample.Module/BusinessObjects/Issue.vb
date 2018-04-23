Imports System
Imports System.Collections.Generic
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Base
Imports DevExpress.Xpo

Namespace NonPersistentDetailViewNavigationExample.Module.BusinessObjects
    <NavigationItem("Issues"), ImageName("BO_Task")> _
    Public Class Issue
        Inherits BaseObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Private subject_Renamed As String
        Public Property Subject() As String
            Get
                Return subject_Renamed
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Subject", subject_Renamed, value)
            End Set
        End Property

        Private description_Renamed As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Description() As String
            Get
                Return description_Renamed
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Description", description_Renamed, value)
            End Set
        End Property

        Private status_Renamed As IssueStatus
        Public Property Status() As IssueStatus
            Get
                Return status_Renamed
            End Get
            Set(ByVal value As IssueStatus)
                SetPropertyValue("Status", status_Renamed, value)
            End Set
        End Property
    End Class
    Public Enum IssueStatus
        Active
        Closed
    End Enum
End Namespace
