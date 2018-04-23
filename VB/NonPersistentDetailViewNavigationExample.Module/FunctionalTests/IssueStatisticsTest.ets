
#Application NonPersistentDetailViewNavigationExample.Win
#Application NonPersistentDetailViewNavigationExample.Web

*Action Navigation(Issue)

*Action New

*FillForm
 Subject = Issue One
 Status = Active
 
*Action Save and New

*FillForm
 Subject = Issue Two
 Status = Closed
 
*Action Save and New

*FillForm
 Subject = Issue Three
 Status = Closed
 
*Action Save and Close
 
*Action Navigation(Issue Statistics)

*CheckFieldValues
 Active Issues Count = 1
 Closed Issues Count = 2
 Total Issues Count = 3
 
 

