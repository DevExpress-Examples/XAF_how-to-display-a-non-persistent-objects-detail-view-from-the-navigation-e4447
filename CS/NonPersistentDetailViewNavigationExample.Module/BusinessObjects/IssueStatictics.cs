using System;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.ExpressApp.DC;

namespace NonPersistentDetailViewNavigationExample.Module.BusinessObjects {
    [DomainComponent]
    [NavigationItem("Issues"), ImageName("BO_Report")]
    public class IssueStatistics {
        public int ActiveIssuesCount { get; set; }
        public int ClosedIssuesCount { get; set; }
        public int TotalIssuesCount { get; set; }
    }
}
