using System;
using System.Collections.Generic;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace NonPersistentDetailViewNavigationExample.Module.BusinessObjects {
    [NavigationItem("Issues"), ImageName("BO_Task")]
    public class Issue : BaseObject {
        public Issue(Session session) : base(session) { }
        private string subject;
        public string Subject {
            get { return subject; }
            set { SetPropertyValue("Subject", ref subject, value); }
        }
        private string description;
        [Size(SizeAttribute.Unlimited)]
        public string Description {
            get { return description; }
            set { SetPropertyValue("Description", ref description, value); }
        }
        private IssueStatus status;
        public IssueStatus Status {
            get { return status; }
            set { SetPropertyValue("Status", ref status, value); }
        }
    }
    public enum IssueStatus { Active, Closed }
}
