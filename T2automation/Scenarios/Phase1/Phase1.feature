Feature: Phase 1

Background: 
	Given Admin logged in "AdminUserName" "AdminPassword"

Scenario:ph 1 Message Actions - Deleting Message
	When Admin set system message permissions for user "Delete Messages from Inbox" "True" "User"
	And Admin set system message permissions for user "Rollback Messages from Deleted Items" "True" "User"
	And Admin set department message permissions for user "Delete Messages from Inbox" "True" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Rollback Messages from Deleted Items" "True" "User" "internalDepartmentSameDep"
	When user go to my messages Internal Document
	And search "internalDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
	And user compose mail "Internal message for deletion 111" "Internal message for deletion 111"
	And user attach attachments 1 "1.pdf"
	And user send the email
	Then save reference number from "my" in txt with subject "Internal message for deletion 111"
	When user go to dept "InternalDepartmentSameDepartment2Ar" messages Internal Document
	And search "User" "UserMainDepartmentAr" "Users"
	And user compose mail "Internal message for deletion 222" "Internal message for deletion 222"
	And user attach attachments 1 "1.pdf"
	And user select connected document with subject "Incoming Message to Outside Child Department 111"
	And user send the email
	Then save reference number from "deptAcc" in txt with subject "Internal message for deletion 222"
	When user go to dept "InternalDepartmentSameDepartment2Ar" messages Incoming Document
	And search "User" "UserMainDepartmentAr" "Users"
	And user compose mail "Incoming message for deletion 333" "Incoming message for deletion 333"
	And select the external department "ExternalEntitySameCountry"
	And user enters incomming message no "+123456789" and incomming message Gregorian date "now"
	And user set connected person "Person Name1" "PersonEmail1@mail.com" "12345" "12345" "Riyadh" "now" "هوية" "True"
	And user send the email and click on Cancel button
	Then save reference number from "deptAcc" in txt with subject "Incoming message for deletion 333"
	When User logs in "UserName" "Password"
	And user opens department "internalDepartmentSameDep" mail with subject "Internal message for deletion 111" ""
	Then user deletes the mail
	Then mail with subject "Internal message for deletion 111" should not appear in "dept" inbox
	When user open "dept" deleted message with suject "Internal message for deletion 111" and click on button "  Rollback"
	Then mail with subject "Internal message for deletion 111" should not appear in "dept" deleted message
	Then mail should appear in dept inbox "internalDepartmentSameDepAr" "Internal message for deletion 111" "Internal message for deletion 111"
	When user opens inbox email with subject "Internal message for deletion 222"
	Then user deletes the mail
	Then mail with subject "Internal message for deletion 222" should not appear in "my" inbox
	When user opens inbox email with subject "Incoming message for deletion 333"
	Then user deletes the mail	
	Then mail with subject "Incoming message for deletion 333" should not appear in "my" inbox
	When user open "my" deleted message with suject "Internal message for deletion 222" and click on button "Rollback"
	Then mail with subject "Internal message for deletion 222" should not appear in "my" deleted message
	Then mail should appear in the inbox "User" "Internal message for deletion 222" "Internal message for deletion 222"
	When user open "my" deleted message with suject "Incoming message for deletion 333" and click on button "Rollback"
	Then mail with subject "Incoming message for deletion 333" should not appear in "my" deleted message
	Then mail should appear in the inbox "User" "Incoming message for deletion 333" "Incoming message for deletion 333"
	When Admin logged in "AdminUserName" "AdminPassword"
	When Admin set system message permissions for user "Delete Messages from Inbox" "False" "User"
	And Admin set system message permissions for user "Rollback Messages from Deleted Items" "False" "User"
	And Admin set department message permissions for user "Delete Messages from Inbox" "False" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Rollback Messages from Deleted Items" "False" "User" "internalDepartmentSameDep"

Scenario:ph 2 Message Actions - Archiving Message
	When Admin set system message permissions for user "Archive Messages" "True" "User"
	And Admin set system message permissions for user "Rollback from Archive" "True" "User"
	And Admin set department message permissions for user "Archive Messages" "True" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Rollback from Archive" "True" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Archive Messages" "True" "User" "CommDepSameDepEn"
	And Admin set department message permissions for user "Rollback from Archive" "True" "User" "CommDepSameDepEn"
	When user go to my messages Internal Document
	And search "User" "UserMainDepartmentAr" "Users"
	And user compose mail "Internal message for archiving 111" "Internal message for archiving 111"
	And user attach attachments 1 "1.pdf"
	And user select connected document with subject "Internal Message to Internal Department 111"
	And user send the email
	Then save reference number from "my" in txt with subject "Internal message for archiving 111"
	When user go to "my" encrypted message 
	And search "internalDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
	And user compose mail "Encrypted message for archiving 222" "Encrypted message for archiving 222"
	And user set properties "Paper" "12345" "Parcels" "" "" "" ""
	And user attach attachments 1 "1.xlsx"
	And user select connected document with subject "Internal Message to Internal Department 111"
	And user send the email  
	Then save reference number from "my" in txt with subject "Encrypted message for archiving 222"
	When user go to dept "InternalDepartmentSameDepartment2Ar" messages Incoming Document
	And search "User" "UserMainDepartmentAr" "Users"
	And user set properties "" "" "" "12345" "now" "now" ""
	And select the external department "ExternalEntitySameCountry"
	And user compose mail "Incoming message for archiving 333" "Incoming message for archiving 333"
	##docx file ko pdf se replace kiya hai ku k docx upload nai ho rai
	And user attach attachments 1 "1.pdf"
	And user select connected document with subject "Internal Message to Internal Department 111"
	When user set connected person "PersonName1" "PersonEmail1@mail.com" "12345" "12345" "Riyadh" "now" "هوية" "True"
	And user send the email and click on Cancel button
	Then save reference number from "deptAcc" in txt with subject "Incoming message for archiving 333"
	When user go to dept "InternalDepartmentSameDepartment2Ar" messages Outgoing Document
	And user click CC button "UserMainDepartmentAr" "Structural Hierarchy" "internalDepartmentSameDepAr"
	And user compose mail "Outgoing message for archiving 444" "Outgoing message for archiving 444"   
	And user set properties "Paper" "12345" "Parcels" "" "" "" "Indirect Export Method"
	And select the external department "ExternalEntitySameCountry"
	And user select connected document with subject "Internal Message to Internal Department 111"
	And user send the email and click on Cancel button
	Then save reference number from "deptAcc" in txt with subject "Outgoing message for archiving 444"
	When User logs in "UserName" "Password"
	And user opens inbox email with subject "Internal message for archiving 111"
	Then user click on "my,Archive" button and set "Comment for archive" "1.png"
	And mail with subject "Internal message for archiving 111" should not appear in "my" inbox
	When user opens inbox email with subject "Incoming message for archiving 333"
	Then user click on "my,Archive" button and set "Comment for archive" "1.png"
	And mail with subject "Incoming message for archiving 333" should not appear in "my" inbox
	When user open "my" archive message with suject "Internal message for archiving 111" and click on button "Rollback"
	Then mail with subject "Internal message for archiving 111" should not appear in "my" archive message
	When user open "my" archive message with suject "Incoming message for archiving 333" and click on button "Rollback"
	Then mail with subject "Incoming message for archiving 333" should not appear in "my" archive message
	Then mail should appear in the inbox "User" "Internal message for archiving 111" "Internal message for archiving 111"
	Then mail should appear in the inbox "User" "Incoming message for archiving 333" "Incoming message for archiving 333"
	When user opens department "internalDepartmentSameDep" mail with subject "Encrypted message for archiving 222" "P@ssw0rd!@#"
	Then user click on "dept,Archive" button and set "Comment for archive" ""
	And mail with subject "Encrypted message for archiving 222" should not appear in "dept" inbox
	When user opens department "internalDepartmentSameDep" mail with subject "Outgoing message for archiving 444" ""
	Then user click on "deptOutgoing,Archive" button and set "Comment for archive" ""
	And mail with subject "Outgoing message for archiving 444" should not appear in "dept" inbox
	When user open "dept" archive message with suject "Encrypted message for archiving 222" and click on button "Rollback"
	And user open "dept" archive message with suject "Outgoing message for archiving 444" and click on button "Rollback"
	Then mail with subject "Encrypted message for archiving 222" should not appear in "dept" archive message
	And mail with subject "Outgoing message for archiving 444" should not appear in "dept" archive message
	Then mail should appear in dept inbox "internalDepartmentSameDepAr" "Encrypted message for archiving 222" "Encrypted message for archiving 222"
	And mail should appear in dept inbox "CommDepSameDep" "Outgoing message for archiving 444" "Outgoing message for archiving 444"
	#When user go to "dept name" exported messages with suject "Outgoing message for archiving 444" 
	#Then user click on "dept,Archive" button and set "Comment for archive" ""
	#Then mail should not appear in "dept name" dept inbox with subject "Outgoing message for archiving 444"
	#Then mail with subject "Internal message for archiving 444" should not appear in "dept" archive message
	#When user go to "CommDepSameDep" archieve with suject "Outgoing message for archiving 444" and click on button "Rollback"
	#When user opens inbox email with subject "Incoming message for archiving 333"
	#Then mail with subject "Outgoing message for archiving 444" should not appear in "CommDepSameDep" archive message
	#Then mail should appear in department "CommDepSameDep" exported "User" "Outgoing message for archiving 444" "Outgoing message for archiving 444"	
	When Admin logged in "AdminUserName" "AdminPassword"
	When Admin set system message permissions for user "Archive Messages" "False" "User"
	And Admin set system message permissions for user "Rollback from Archive" "False" "User"
	And Admin set department message permissions for user "Archive Messages" "False" "User" "internalDepartmentSameDepAr"
	And Admin set department message permissions for user "Rollback from Archive" "False" "User" "internalDepartmentSameDepAr"
	And Admin set department message permissions for user "Archive Messages" "False" "User" "CommDepSameDep"
	And Admin set department message permissions for user "Rollback from Archive" "False" "User" "CommDepSameDep"


Scenario:ph 3 Exporting Message -1
	When user go to my messages Incomming Document
	And search "internalDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
	And user set properties "Paper" "12345" "Parcels" "+123456789" "now" "now" ""
	And select the external department "ExternalEntitySameCountry"
	And user compose mail "Incoming message for indirect export 111" "Incoming message for indirect export 111"
	And user attach attachments 1 "1.pdf"
	And user set connected person "Person Name1" "PersonEmail1@mail.com" "12345" "12345" "Riyadh" "now" "هوية" "True"
	And user send the email and click on Cancel button
	Then save reference number from "my" in txt with subject "Incoming message for indirect export 111"

