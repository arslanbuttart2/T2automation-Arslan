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
	When user open "dept" deleted message with suject "Internal message for deletion 111" and click on button "Rollback"
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


#Scenario:ph 3 Exporting Message -1
#	#When user go to my messages Incomming Document
#	#And search "internalDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
#	#And user set properties "Paper" "12345" "Parcels" "+123456789" "now" "now" ""
#	#And select the external department "ExternalEntitySameCountry"
#	#And user compose mail "Incoming message for indirect export 111" "Incoming message for indirect export 111"
#	#And user attach attachments 1 "1.pdf"
#	#And user set connected person "Person Name1" "PersonEmail1@mail.com" "12345" "12345" "Riyadh" "now" "هوية" "True"
#	#And user send the email and click on Cancel button
#	#Then save reference number from "my" in txt with subject "Incoming message for indirect export 111"
#	When user opens department "internalDepartmentSameDep" mail with subject "Incoming message for indirect export 111" ""
#	And click on export button
#	And user compose mail "Incoming message for indirect export 666" "Incoming message for indirect export 666"
#	And select the external department "ExternalEntitySameCountry"
#	And select the external cc department "ExternalEntitySameCountry2"




Scenario:ph 3 Exporting Message -1
	When user go to my messages Incomming Document
	And search "internalDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
	And user set properties "Paper" "12345" "Parcels" "+123456789" "now" "now" ""
	And select the external department "ExternalEntitySameCountry"
	And user compose mail "Incoming message for indirect export 111" "Incoming message for indirect export 111"
	And user attach attachments 1 "1.pdf"
	When user set connected person "Person Name1" "PersonEmail1@mail.com" "12345" "12345" "Riyadh" "now" "هوية" "True"	
	And user send the email and click on Ok button
	And user click cancel button
	Then save reference number from "my" in txt with subject "Incoming message for indirect export 111"
	When user opens department "internalDepartmentSameDep" mail with subject "Incoming message for indirect export 111" ""
	And click export
	And user compose mail "Incoming message for indirect export 666" "Incoming message for indirect export 666"
	And select the external department "ExternalEntitySameCountry"
	And select the external cc department "ExternalEntitySameCountry2"
	And user set properties "" "" "" "" "" "" "indirectExport"
	And user select connected document with subject "Internal Message to Internal Department 111"
	And user send the email and click on Cancel button	
	Then save reference number from "dept" in txt with subject "Incoming message for indirect export 666"
	When user opens root department "CommDepSameDep" mail with subject "Incoming message for indirect export 666"	
	And user click on edit button
	And select the external department in root"ExternalEntitySameCountry2"
	And user click ok button
	And select the external cc department in root "ExternalEntitySameCountry"
	And user click on process edit change and export button
	And user click ok button	
	And user click on cancel button
	##DUE TO BUG LEFT OUT
	#When user opens department "internalDepartmentSameDep" mail with subject "Incoming message for indirect export 666"
	#And user click on reply button compose mail with subject "Reply :incoming message for indirect export 666" "Reply :incoming message for indirect export 666"
	###And user delete the person with name "Person Name1" from the list
	###And user delete the document with subject "Incoming message for indirect export 111" from the list
	#And user delete the connected document with subject "Incoming message for indirect export 111" from the list
	#And user attach attachments 1 "1.jpg"
	#And user send the email
	###When user opens depart


Scenario:ph 4 Exporting Message - 2
	When user go to dept messages Internal Document
	And search "Admin" "UserMainDepartmentAr" "Users"
	And user compose mail "Internal message for direct export 222" "Internal message for direct export 222"
	And user attach attachments 1 "1.pdf"
	And user select and save the reference no "CD2" of connected document with subject "Internal Message to Internal Department 111"
	And user send the email
	Then save reference number from "dept" in txt with subject "Internal message for direct export 222"
	When user opens inbox email with subject "Internal message for direct export 222"
	And click on export button
	And user compose mail "Internal message for direct export 888" "Internal message for direct export 888"
	And user set properties "" "" "" "" "" "" "Direct Export Method"
	And select the external department "ExternalEntitySameCountry"
	####following is not the working!!!
	And user delete the document with subject "Internal Message to Internal Department 111" from the list
	And user send the email in "my" and click on Cancel button
	Then save reference number from "my" in txt with subject "Internal message for direct export 888"
	When user go to dept "CommDepSameDep" messages Unexported folder 
	Then user search and open mail in dept "CommDepSameDep" with subject "Internal message for direct export 888"
	And click on "Return" button
	When user go to dept "CommDepSameDep" Outbox
	Then user search and open mail in dept "CommDepSameDep" with subject "Internal message for direct export 888"
	And click on "Retrieve" button
	When user go to dept "CommDepSameDep" messages Unexported folder
	Then user search and open mail in dept "CommDepSameDep" with subject "Internal message for direct export 888"
	Then click on "Export" button
	When user go to dept "CommDepSameDep" Exported
	Then user search and open mail in dept "CommDepSameDep" with subject "Internal message for direct export 888"
	And user click on "deptCommDept,Archive" button and set "Comment for archive" "1.jpg"
	When user open "deptCommDept" archive message with suject "Internal message for direct export 888" and click on button "Delete"
	###When user go to "deptCommDept" deleted message
	Then mail with subject "Internal message for direct export 888" should appear in "deptCommDept" Delete
	When user go to search "Advance Search"
	Then click on "Clear" button
	And write reference number of "Internal message for direct export 888"
	And write export date from "now"
	Then click on "Search" button
	Then Check the advance searched results with subject "Internal message for direct export 888" 
	Then click on "Clear" button
	And write reference number of "Internal message for direct export 888"
	And write created date from "now"
	Then click on "Search" button
	Then Check the advance searched results with subject "Internal message for direct export 888" 

Scenario:ph 7 Retrieve  Message - 1
	When user go to my messages Internal Document
	And search "internalDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
	And user set properties "Paper" "12345" "Parcels" "" "" "" ""
	And user compose mail "Internal message for Retreiving 111" "Internal message for Retreiving 111"
	And user send the email
	Then save reference number from "my" in txt with subject "Internal message for Retreiving 111"
	When user opens department "internalDepartmentSameDep" mail with subject "Internal message for Retreiving 111" ""
	And click on "Print" button 
	And click on "Print Sticker" button
	When user opens outbox email with subject "Internal message for Retreiving 111"
	And click on "Retrieve" button
	And user send the email
	Then save reference number from "my" in txt with subject "Internal message for Retreiving 111"
	When user opens department "internalDepartmentSameDep" mail with subject "Internal message for Retreiving 111" ""
	And click on "Confirm Receiving" button
	When user opens outbox email with subject "Internal message for Retreiving 111"
	And click on "Retrieve" button

Scenario:ph 8 Retrieve  Message - 2
	#When Admin set department message permissions for user "Retreive Message" "True" "Admin" "internalDepartmentSameDep"
	#And Admin set department message permissions for user "Retreive Message after Reading" "False" "Admin" "internalDepartmentSameDep"
	#When Admin logged in "AdminUserName" "AdminPassword"
	When user go to dept messages Internal Document
	And search "InternalDepartmentOtherDepAr" "OtherMainDepartmentAr" "Structural Hierarchy"
	And search CC "Admin" "UserMainDepartmentAr" "Users"
	And user compose mail "Internal message for Retreiving 222" "Internal message for Retreiving 222"
	And user send the email
	Then save reference number from "dept" in txt with subject "Internal message for Retreiving 222"
	###########following needs to be executed!!! And Tested!!!
	When user go to my messages Internal Document
	And user opens inbox email with subject "Internal message for Retreiving 222"
	And user opens department "internalDepartmentSameDep" mail with subject "Internal message for Retreiving 222" ""
	And click on "Retrieve" button
	#When Admin set department message permissions for user "Retreive Message" "True" "Admin" "internalDepartmentSameDep"
	#And Admin set department message permissions for user "Retreive Message after Reading" "True" "Admin" "internalDepartmentSameDep"
	#When Admin logged in "AdminUserName" "AdminPassword"
	When user go to dept "qaDept" Outbox
	Then user search and open mail in dept "qaDept" with subject "Internal message for Retreiving 222"
	And click on "Retrieve" button
	When user send the email
	And user opens inbox email with subject "Internal message for Retreiving 222"
	And click on "Reply" button
	And user compose mail "Reply: Internal message for Retreiving 222" "Reply: Internal message for Retreiving 222"
	And user send the email
	When user go to dept "qaDept" Outbox
	Then user search and open mail in dept "qaDept" with subject "Internal message for Retreiving 222"
	And click on "Retrieve" button
	
Scenario:ph 9 Retrieve  Message - 3	
	When user go to "my" encrypted message 
	And search "InternalDepartmentOtherDepAr" "OtherMainDepartmentAr" "Structural Hierarchy"
	And search "internalDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
	And user compose mail "Encrypted message for Reteiving 333" "Encrypted message for Reteiving 333"
	And user send the email
	Then save reference number from "my" in txt with subject "Encrypted message for Reteiving 333"
	When user opens department "internalDepartmentSameDep" mail with subject "Encrypted message for Reteiving 333" "P@ssw0rd!@#"
	And user deletes the mail
	When user opens outbox email with subject "Encrypted message for Reteiving 333"
	And user click on retrive button
	When user opens department delete "internalDepartmentSameDep" mail with subject "Encrypted message for Reteiving 333" "P@ssw0rd!@#"
	And user click on roll back button
	When user opens outbox email with subject "Encrypted message for Reteiving 333"
	And user click on retrive button
	## SN 25-29 BUG NEXT STEPS NEED TO BE IMPLEMETED

Scenario:ph 10 Retrieve  Message - 4
	#######ISSUE dETECTED of Xpath
	When user go to dept messages Incoming Document
	And search "AdminUserName" "UserMainDepartmentAr" "Users"
	And user compose mail "Incoming message for Reteiving 444" "Incoming message for Reteiving 444"
	And user set properties "" "" "" "12345" "now" "now" ""
	And select the external department "ExternalEntitySameCountry"
	And user send the email and click on Ok button
	##Then save reference number from "my" in tx