Feature: Phase2
	
Background: 
	Given Admin logged in "AdminUserName" "AdminPassword"

Scenario:ph2_001 Message Actions
	When user go to my messages Incomming Document
	And search "internalDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
	And user compose mail "Incoming message for various actions 111" "Incoming message for various actions 111"
	And select the external department "ExternalEntitySameCountry"
	And user set properties "Paper" "12345" "Parcels" "+123456789" "now" "now" ""
	And user attach attachments 1 "1.jpg"
	And user select connected document with subject "Any Doc"
	And user add signature ""
	And user send the email and click on Cancel button
	Then save reference number from "my" in txt with subject "Incoming message for various actions 111"
	When user go to dept "QA" messages Inbox folder
	Then user search and select mail in dept "QA" with subject "Incoming message for various actions 111" 
	And click on "Follow-up Button" button and select "" "Formal View" ""
	And click on "Actions And Movements" button and select "" "" "Just open Messaage Flow Tab"
	###Some times back btn redirect us to the unwanted place!!! Here it redirect to outbox!!! -_-
	When user go to dept "QA" messages Inbox folder
	Then user search and open mail in dept "QA" with subject "Incoming message for various actions 111"
	When user go to dept "QA" messages Inbox folder
	Then user search and open mail in dept "QA" with subject "Incoming message for various actions 111"
	And click on "Confirm Receiving" button
	Then user search and open mail in dept "QA" with subject "Incoming message for various actions 111"
	And click on "Print Delivery statement,And read D1 and Cancel," button
	When user go to messages Delivery Statment Report folder
	Then read Deliver Statment Number "D1" and Save from list
	When user search Delivery Statment Report with "D1"
	And click on "Upload Delivery Statment,1.jpg" button
	And click on "Manual Insert" button
	And user search and open Delivery Statment Report with "D1"
	And user click on "Attachment,popup" tab
	And click on "Attachment print button,Save As,D1,D1,Delivery Statement Upload" button
	When user go to dept "QA" messages Inbox folder
	Then user search and open mail in dept "QA" with subject "Incoming message for various actions 111"
	When user click on "Delivery statement reports" tab
	And user select "D1" from list and click on "Show Image" button
	When user go to messages Delivery Statment Report folder
	And user search and open Delivery Statment Report with "D1"
	And user click on "Attachment,popup" tab
	And click on "Delete Attachment button Popup" button
	When user opens department "internalDepartmentSameDep" mail with subject "Incoming message for various actions 111" ""
	And user click on "Delivery statement reports" tab
	And user click on "Message Flow" tab
	And user click on "Actions" tab
	And user click on "Change Status to Unread" upper bar button
	When user opens department "internalDepartmentSameDep" mail with subject "Incoming message for various actions 111" ""
	And user click on "Link,InternalDocument" upper bar button
	And search "Admin" "UserMainDepartmentAr" "Users"
	And user compose mail "Internal message for various actions 222" "Internal message for various actions 222"
	And user set properties "Paper" "12345" "Parcels" "" "" "" ""
	And user send the email
	Then save reference number from "dept" in txt with subject "Internal message for various actions 222"
	When user opens outbox email with subject "Incoming message for various actions 111"
	And click on "Retrieve" button
	When user go to dept "my" messages Inbox folder
	Then user search and select mail in dept "my" with subject "Internal message for various actions 222" 
	And click on "Follow-up Button" button and select "" "Formal View" ""
	And click on "Actions And Movements" button and select "" "" "Just open Messaage Flow Tab"
	When user opens inbox email with subject "Internal message for various actions 222"
	And click on "Confirm Receiving" button
	When user opens inbox email with subject "Internal message for various actions 222"
	And user click on "Print Delivery Statement" upper bar button
	And user click on "Delivery statement reports" tab
	And user click on "Message Flow" tab
	And user click on "Actions" tab
	And user click on "Connected Message" tab
	And open connected document in "my" with subject "Incoming message for various actions 111"
	And user click on "Document" tab
	And user click on "Attribute" tab
	And user click on "Attachment" tab
	And user click on "Connected Message" tab
	And user click on "Message Flow" tab
	And user click on "Actions" tab
	And user click on "Change Status to Unread" upper bar button
	When user opens inbox email with subject "Internal message for various actions 222"
	And user click on "Forward" upper bar button
	And search "internalDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
	And user compose mail "Internal message for various actions 333" "Internal message for various actions 333"
	And user send the email
	Then save reference number from "my" in txt with subject "Internal message for various actions 333"
	
Scenario:ph2_002 Folders - 1 - inbox
	When Admin set department message permissions for user "Delete Messages from Inbox" "True" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Rollback Messages from Deleted Items" "True" "User" "internalDepartmentSameDep"
	When user open department "internalDepartmentSameDep" inbox and create new folder "Automation 111"
	And right click on "Automation 111" and create "Automation 222" folder
	When user go to my messages Incomming Document
	And search "internalDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
	And user compose mail "Internal message folders 111" "Internal message folders 111"
	And user set properties "" "" "" "+123456789" "now" "now" ""
	And select the external department "ExternalEntitySameCountry"
	Then user send the email and save refrence no from popup "my" "Internal message folders 111" "True"
	#######As notification on sending email is not appearing so saving refernce number from popup
	#######And user send the email and click on Cancel button
	#######Then save reference number from "my" in txt with subject "Internal message folders 111"
	When user opens department "internalDepartmentSameDep" mail with subject "Internal message folders 111" ""
	And user move mail to new folder "Automation 111"
	And user opens Automation department "internalDepartmentSameDep" mail with subject "Internal message folders 111" ""
	Then user deletes the mail
	When user open "dept" deleted message with suject "Internal message folders 111" and click on button "Rollback"
	And user opens Automation department "internalDepartmentSameDep" mail with subject "Internal message folders 111" ""
	And user move mail to new folder "Automation 222"
	And user open "Automation 222" in department "internalDepartmentSameDep" mail with subject "Internal message folders 111" ""
	And user click on archieve button
	When user open "dept" archive message with suject "Internal message folders 111" and click on button "Rollback"
	And user open "Automation 222" in department "internalDepartmentSameDep" mail with subject "Internal message folders 111" ""
	And right click on "Automation 222" folder and delete it
	#dont need of step 41 and 42 as it is already opened
	And user move mail to new folder "Inbox"
	When user opens department "internalDepartmentSameDep" mail with subject "Internal message folders 111" ""
	And right click on "Automation 222" folder and delete it

Scenario:ph2_005 Department FavGroups - 1
	When user search and open settings for "InternalDepartmentSameDep" in Lookups and open User Group tab
	And added new user group "Department Group for Automation 111"
	And open members popup for "Department Group for Automation 111"
	And click on add new member
	And search in user group "ChildDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
	#And click on add new member
	#And search in user group "InternalDepartmentSameDepartment2Ar" "UserMainDepartmentAr" "Structural Hierarchy"
	And click on add new member
	And search in user group "Admin" "UserMainDepartmentAr" "Users"
	And click on add new member
	And search in user group "InternalDepartmentOtherDepAr" "OtherMainDepartmentAr" "Structural Hierarchy"
	And click on add new member
	And search in user group "ChildDepartmentOtherDepAr" "OtherMainDepartmentAr" "Structural Hierarchy"
	When Admin set department sending message permissions for user "User Groups" "True" "Admin" "internalDepartmentSameDep"
	And search and add "Department Group for Automation 111"
	And Admin logged in "AdminUserName" "AdminPassword"
	When user go to dept messages Internal Document
	And search "UserGroups" "UserMainDepartmentAr" "User Groups"
	And user compose mail "Internal message for department groups 111" "Internal message for department groups 111"
	And user select connected document with subject "Any Doc"
	And user attach attachments 1 "1.pdf"
	And user send the email
	Then save reference number from "dept" in txt with subject "Internal message for department groups 111"
	When user go to dept "Audit" messages Inbox folder
	And user search and open mail in dept "Audit" with subject "Internal message for department groups 111"
	And user click on "Attachment" tab
	And user click on "Connected Message" tab
	When user go to dept "qaDept" Outbox
	And user search and open mail in dept "qaOut" with subject "Internal message for department groups 111"
	And click on "Retrieve" button
	And user press To_user "Department Group for Automation 111" and uncheck "InternalDepartmentOtherDep" from popup
	###Unable to send mail because accounting department!
	And user send the email
	And user go to dept "my" messages Inbox folder
	And user search and open mail in dept "my" with subject "Internal message for department groups 111"
	When user go to dept "Saudi Affair" messages Inbox folder
	And user search and open mail in dept "Saudi Affair" with subject "Internal message for department groups 111"
	And user go to dept "Audit" messages Inbox folder
	And user search and open mail in dept "Audit" with subject "Internal message for department groups 111"
	When Admin set department sending message permissions for user "User Groups" "False" "Admin" "internalDepartmentSameDep"
	###Need to updadate this!!!

	When user search and open settings for "InternalDepartmentSameDep" in Lookups and open User Group tab
	And user delete user_group "Department Group for Automation 111"

Scenario:ph2_006 Department FavGroups - 2
	When user search and open settings for "InternalDepartmentSameDep" in Lookups and open User Group tab
	And added new user group "Department Group for Automation 222"
	And open members popup for "Department Group for Automation 222"
	And click on add new member
	And search in user group "ChildDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
	And click on add new member
	And search in user group "InternalDepartmentSameDepartment2Ar" "UserMainDepartmentAr" "Structural Hierarchy"
	And click on add new member
	And search in user group "Admin" "UserMainDepartmentAr" "Users"
	And click on add new member
	And search in user group "InternalMailChild" "InternalMailMain" "Structural Hierarchy"
	And click on add new member
	And search in user group "InternalDepartmentDisabled" "AutomationDepartment" "Structural Hierarchy"
	And click on add new member
	And search in user group "InternalDepForbidden" "AutomationDepartment" "Structural Hierarchy"
	And click on add new member
	And search in user group "InternalDepNoMembers" "AutomationDepartment" "Structural Hierarchy"
	When Admin set department sending message permissions for user "Send All Departments" "False" "Admin" "internalDepartmentSameDep"
	When Admin set department sending message permissions for user "Send to all organizations except" "True" "Admin" "internalDepartmentSameDep"
	And search and add "Department Group for Automation 222"
	And Admin logged in "AdminUserName" "AdminPassword"
	#And user go to dept messages Incoming Document
	####No Data available
	#And search "UserGroups2" "UserMainDepartmentAr" "User Groups"
	#And user compose mail "Incoming message for department groups 222" "Incoming message for department groups 222"
	#And user set properties "" "" "" "12345" "now" "now" ""
	#And select the external department "ExternalEntitySameCountry"
	#And user attach attachments 1 "1.jpg"
	#And user send the email and click on Cancel button
	#Then save reference number from "dept" in txt with subject "Incoming message for department groups 222"
	#When user go to dept "Accounting" messages Inbox folder
	#And user search and open mail in dept "Accounting" with subject "Incoming message for department groups 222"
	#And user go to dept "my" messages Inbox folder
	#And user search and open mail in dept "my" with subject "Incoming message for department groups 222"
	#And user go to dept "Audit" messages Inbox folder
	#And user search and open mail in dept "Audit" with subject "Incoming message for department groups 222"
	


