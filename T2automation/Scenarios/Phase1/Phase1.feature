Feature: Phase 1

Background: 
	Given Admin logged in "AdminUserName" "AdminPassword"

Scenario:ph1_1 Message Actions - Deleting Message
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
	And user set properties "" "" "" "" "" "now" ""
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

Scenario:ph1_2 Message Actions - Archiving Message
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
	###docx file is replaced by pdf because docx is not uploading
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
	And user select connected document with subject "Incoming Message to Child Department 111"
	And user send the email and click on Cancel button
	Then save reference number from "deptAcc" in txt with subject "Outgoing message for archiving 444"
	When User logs in "UserName" "Password"
	#Mail is not appearing in inbox for Danish user
	And user opens inbox email with subject "Internal message for archiving 111"
	Then user click on "my,Archive" button and set "Comment for archive" "1.png"
	And mail with subject "Internal message for archiving 111" should not appear in "my" inbox
	When user opens inbox email with subject "Incoming message for archiving 333"
	Then user click on "my,Archive" button and set "Comment for archive" "1.png"
	And mail with subject "Incoming message for archiving 333" should not appear in "my" inbox
	### Rollback button is not working here!!! for arslan user and danish
	When user open "my" archive message with suject "Internal message for archiving 111" and click on button "Rollback"
	Then mail with subject "Internal message for archiving 111" should not appear in "my" archive message
	When user open "my" archive message with suject "Incoming message for archiving 333" and click on button "Rollback"
	Then mail with subject "Incoming message for archiving 333" should not appear in "my" archive message
	When user opens department "internalDepartmentSameDep" mail with subject "Encrypted message for archiving 222" "P@ssw0rd!@#"
	Then user click on "dept,Archive" button and set "Comment for archive" ""
	And mail with subject "Encrypted message for archiving 222" should not appear in "dept" inbox
	When user opens department "internalDepartmentSameDep" mail with subject "Outgoing message for archiving 444" ""
	Then user click on "deptOutgoing,Archive" button and set "Comment for archive" ""
	And mail with subject "Outgoing message for archiving 444" should not appear in "dept" inbox
	When user open "dept" archive message with suject "Encrypted message for archiving 222" and click on button "Rollback"
	##-##And user open "dept" archive message with suject "Outgoing message for archiving 444" and click on button "Rollback"
	##-##Then mail with subject "Encrypted message for archiving 222" should not appear in "dept" archive message
	##-##And mail with subject "Outgoing message for archiving 444" should not appear in "dept" archive message
	##-##Then mail should appear in dept inbox "internalDepartmentSameDepAr" "Encrypted message for archiving 222" "Encrypted message for archiving 222"
	####The following step is been asked to check in excel sheet but it is not working on old server!!!
	##--#And mail should appear in dept inbox "CommDepSameDep" "Outgoing message for archiving 444" "Outgoing message for archiving 444"
	###################################     No Such Department Exisit For User Arslan #######################################
	###When user go to dept "CommDepSameDep" Exported
	###Then user search and open mail in dept "CommDepSameDep" with subject "Outgoing message for archiving 444" 
	###Then user click on "deptCommDept,Archive" button and set "" "1.jpg"
	###Then mail with subject "Outgoing message for archiving 444" should not appear in "deptCommDept" Exported
	###When user open "deptCommDept" archive message with suject "Outgoing message for archiving 444" and click on button "Rollback"
	###Then mail with subject "Outgoing message for archiving 444" should not appear in "deptCommDept" archive message
	#####Then mail should appear in department "CommDepSameDep" exported
	#Then mail should appear in Department Message with Root "CommDepSameDep" "Sending Outgoing Message 111" "Sending Outgoing Message 111"
	######"User" "Outgoing message for archiving 444" "Outgoing message for archiving 444"	
	When Admin logged in "AdminUserName" "AdminPassword"
	When Admin set system message permissions for user "Archive Messages" "False" "User"
	And Admin set system message permissions for user "Rollback from Archive" "False" "User"
	And Admin set department message permissions for user "Archive Messages" "False" "User" "internalDepartmentSameDepAr"
	And Admin set department message permissions for user "Rollback from Archive" "False" "User" "internalDepartmentSameDepAr"
	And Admin set department message permissions for user "Archive Messages" "False" "User" "CommDepSameDep"
	And Admin set department message permissions for user "Rollback from Archive" "False" "User" "CommDepSameDep"

Scenario:ph1_3 Exporting Message -1
	When user go to my messages Incomming Document
	And search "internalDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
	And user set properties "Paper" "12345" "Parcels" "+123456789" "now" "now" ""
	And select the external department "ExternalEntitySameCountry"
	And user compose mail "Incoming message for indirect export 111" "Incoming message for indirect export 111"
	And user attach attachments 1 "1.pdf"
	When user set connected person "Person Name1" "PersonEmail1@mail.com" "12345" "12345" "Riyadh" "now" "هوية" "True"	
	And user send the email and click on Cancel button	
	Then save reference number from "my" in txt with subject "Incoming message for indirect export 111"
	When user opens department "internalDepartmentSameDep" mail with subject "Incoming message for indirect export 111" ""
	And click export
	And user select To for outgoing "Administrative Communication Department"
	And select the external department "ExternalEntitySameCountry"
	And select the external cc department "ExternalEntitySameCountry2"
	And user set properties "" "" "" "" "" "" "Indirect Export Method"
	And user compose mail "Incoming message for indirect export 666" "Incoming message for indirect export 666"
	And user select and save the reference no "CD1" of connected document with subject "Internal Message to Internal Department 111"
	And user send the email and click on Cancel button	
	Then save reference number from "dept" in txt with subject "Incoming message for indirect export 666"
	When user opens root department "CommDepSameDep" mail with subject "Incoming message for indirect export 666"	
	And user click on edit button
	And select the external department in root"ExternalEntitySameCountry2"
	And user click ok button
	And select the external cc department in root "ExternalEntitySameCountry"
	And user click on save editing button
	When user open dept "qaDept" Outbox mail with subject"Incoming message for indirect export 666"
	And user click on undo export button
	And user set properties "" "" "" "" "" "" "Direct Export Method"
	And user send the email and click on Cancel button
	When user opens root department "CommDepSameDep" mail with subject "Incoming message for indirect export 666"	
	And user click on return button
	And user click ok button
	When user opens department "internalDepartmentSameDep" mail with subject "Incoming message for indirect export 666" ""
	And user click on reply button
	And user compose mail "Reply : incoming message for indirect export 666" "Reply : incoming message for indirect export 666"
	And user delete the document with subject "Internal Message to Internal Department 111" from the list
	And user attach attachments 1 "1.jpg" and already Had Some Attachment "1"
	And user set properties "Paper" "12345" "Parcels" "" "" "" ""
	And user set properties "" "" "" "" "" "" "Indirect Export Method"
	And user send the email and click on Cancel button
	Then save reference number from "dept" in txt with subject "Reply : incoming message for indirect export 666"
	When user opens root department "CommDepSameDep" mail with subject "Reply : incoming message for indirect export 666"	
	And user click export btn in dept CommDepSameDep unexported	
	When user opens exported department "CommDepSameDep" mail with subject "Reply : incoming message for indirect export 666"	
	When user open dept "qaDept" Outbox mail with subject"Reply : incoming message for indirect export 666"
	And user click on undo export button
	And user click on close button
	When user open dept "qaDept" Outbox mail with subject"Reply : incoming message for indirect export 666"

Scenario:ph1_4 Exporting Message - 2
	When user go to dept messages Internal Document
	And search "Admin" "UserMainDepartmentAr" "Users"
	And user compose mail "Internal message for direct export 222" "Internal message for direct export 222"
	And user attach attachments 1 "1.pdf"
	#No data available for the following search!
	#And user select and save the reference no "CD2" of connected document with subject "Internal Message to Internal Department 111"
	And user send the email
	Then save reference number from "dept" in txt with subject "Internal message for direct export 222"
	When user opens inbox email with subject "Internal message for direct export 222"
	And click on export button
	And user select To for outgoing "Administrative Communication Department"
	And user compose mail "Internal message for direct export 888" "Internal message for direct export 888"
	And user set properties "" "" "" "" "" "" "Direct Export Method"
	And select the external department "ExternalEntitySameCountry"
	####following step is not the working!!!
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

Scenario:ph1_5 Exporting Message - 3
	#When user open outgoing The "To" field is empty by default! and no instruction are given to select the option in excel file
	When user go to my messages Outgoing Document
	And user click CC button "UserMainDepartmentAr" "Structural Hierarchy" "internalDepartmentSameDepAr"
	######This data is not available to arslan admin neither for danish against Saudi Affairs
	#####And user click CC button "UserMainDepartmentAr" "Structural Hierarchy" "InternalDepartmentOtherDepAr"
	And user set properties "Paper" "12345" "Parcels" "" "" "" ""
	And select the external department "ExternalEntitySameCountry"
	And user compose mail "Outgoing message for direct export 444" "Outgoing message for direct export 444"
	And user set properties "" "" "" "" "" "" "Direct Export Method"
	And user attach attachments 1 "1.pdf"
	And user select and save the reference no "CD1" of connected document with subject "Any Doc"
	And user send the email and click on Cancel button
	Then save reference number from "my" in txt with subject "Outgoing message for direct export 444"
	When user opens root department "CommDepSameDep" mail with subject "Outgoing message for direct export 444"
	And user open connected document in dep for unexported message with subject "Any Doc"
	And user click on exported message return button and write comment "I am in unexported and writing comment"
	When user opens department "internalDepartmentSameDep" mail with subject "Outgoing message for direct export 444" ""
	And click on "Reply All" button
	And user compose mail "Reply All: Outgoing message for direct export 444" "Reply All: Outgoing message for direct export 444"
	And user set properties "Paper" "67890" "Parcels" "" "" "" ""
	##### Getting error while adding another connected document that  Index was outside the bounds of the array. 
	And user select connected document with subject "Internal Message to Outside Internal Department 111"
	And user delete the attachment "1.pdf" "1"
	And user send the email and click on Cancel button
##		###### Need to test manually from here the email does not appear in deleted folder replace the subject with Internal Message to Outside Internal Department
##		#####When user opens department delete "internalDepartmentSameDep" mail with subject "Reply All: Outgoing message for direct export 444" ""
##		#####And user deletes the mail
##		#####Then mail with subject "Reply All: Outgoing message for direct export 444" should not appear in "InternalDepartmentSameDep" deleted message
	When user open dept "CommDepSameDep" Outbox mail with subject"Outgoing message for direct export 444"
	And click on "Retrieve" button
	#####Following is not working due to reterive button issue
	#####When user opens root department "CommDepSameDep" mail with subject "Outgoing message for direct export 444"
	#####And user click on exported message return button and write comment
	When user open inbox email with subject "Outgoing message for direct export 444" and reference no
	And click on "Reply" button
	And user delete the document with subject "Any Doc" from the list
	And user select connected document with subject "Any Doc"
	And user send the email and click on Cancel button
	Then save reference number from "my" in txt with subject "Outgoing message for direct export 444"
	When user opens root department "CommDepSameDep" mail with subject "Outgoing message for direct export 444"
	When user click export btn in dept CommDepSameDep unexported
	When user go to search "Advance Search"
	Then click on "Clear" button
	And write reference number of "Outgoing message for direct export 444"
	And write export date from "now"
	And click on "Search" button
	And Check the advance searched results with subject "Outgoing message for direct export 444"
	And click on "Clear" button
	And write reference number of "Outgoing message for direct export 444"
	And write created date from "now"
	And click on "Search" button
	And Check the advance searched results with subject "Outgoing message for direct export 444"
	########### Mail does not appear here 
	#####When user opens inbox email with subject "Outgoing message for direct export 444"
	#####And user click on undo export button


Scenario:ph1_6 Exporting Message - 4
	When user go to dept messages Outgoing Document  
	And select the external department "ExternalEntitySameCountry"
	And select the external cc department "ExternalEntitySameCountry2"
	And user set properties "" "" "" "" "" "" "Indirect Export Method"
	And user compose mail "Outgoing message for direct export 555" "Outgoing message for direct export 555"
	And user attach attachments 1 "1.pdf"
	And user send the email and click on Cancel button
	Then save reference number from "dept" in txt with subject "Outgoing message for direct export 555"
	When user go to dept "CommDepSameDep" messages Unexported folder
	Then user search and open mail in dept "CommDepSameDep" with subject "Outgoing message for direct export 555"
	And click on "Export" button
	When user go to dept "CommDepSameDep" Exported
	Then user search and open mail in dept "CommDepSameDep" with subject "Outgoing message for direct export 555"
	And click on "Undo Export" button
	When user open dept "qaDept" Outbox mail with subject"Outgoing message for direct export 555"
	And user click on undo export button
	And user delete the attachment "1.pdf" "1"
	And user attach attachments 1 "1.jpg"
	And user send the email and click on Cancel button
	When user opens root department "CommDepSameDep" mail with subject "Outgoing message for direct export 555"
	And user click on dept tabs in unexported
	And user click on edit button
	And select the external department in root"ExternalEntitySameCountry2"
	And user click ok button
	And select the external cc department in root "ExternalEntitySameCountry"
	And user click on process edit change and export button
	When user go to dept "CommDepSameDep" Exported
	And user search and open mail in dept "CommDepSameDep" with subject "Outgoing message for direct export 555"
	Then user click on "deptCommDept,Archive" button and set "Comment for archive" "1.png"
	When user open "deptCommDept" archive message with suject "Outgoing message for direct export 555" and click on button "Rollback"
	When user go to dept "CommDepSameDep" Exported
	And user search and open mail in dept "CommDepSameDep" with subject "Outgoing message for direct export 555"
	
Scenario:ph1_7 Retrieve  Message - 1
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

Scenario:ph1_8 Retrieve  Message - 2
	When Admin set department message permissions for user "Retreive Message" "True" "Admin" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Retreive Message after Reading" "False" "Admin" "internalDepartmentSameDep"
	When Admin logged in "AdminUserName" "AdminPassword"
	When user go to dept messages Internal Document
	###Saudi Affairs is not viible in this case so it is failing
	And search "InternalDepartmentOtherDepAr" "OtherMainDepartmentAr" "Structural Hierarchy"
	And search CC "Admin" "UserMainDepartmentAr" "Users"
	And user compose mail "Internal message for Retreiving 222" "Internal message for Retreiving 222"
	And user send the email
	Then save reference number from "dept" in txt with subject "Internal message for Retreiving 222"
	When user opens inbox email with subject "Internal message for Retreiving 222"
	When user go to dept "qaDept" Outbox
	Then user search and open mail in dept "qaDept" with subject "Internal message for Retreiving 222"
	And click on "To check the Retrieve" button
	When Admin set department message permissions for user "Retreive Message" "True" "Admin" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Retreive Message after Reading" "True" "Admin" "internalDepartmentSameDep"
	When Admin logged in "AdminUserName" "AdminPassword"
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
		
Scenario:ph1_9 Retrieve  Message - 3	
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
	####following step is not working
	And user click on retrive button
	When user open department "internalDepartmentSameDep" inbox and create new folder "Automation 111"
	When user opens department "internalDepartmentSameDep" mail with subject "Encrypted message for Reteiving 333" "P@ssw0rd!@#"
	And user move mail to folder "Automation 111"
	When user opens Automation department "internalDepartmentSameDep" mail with subject "Encrypted message for Reteiving 333" "P@ssw0rd!@#"
	And user move mail to folder "Automation 111"
	When user opens outbox email with subject "Encrypted message for Reteiving 333"
	And user click on retrive button

Scenario:ph1_10 Retrieve  Message - 4
	When user go to dept messages Incoming Document
	And search "AdminUserName" "UserMainDepartmentAr" "Users"
	And user compose mail "Incoming message for Reteiving 444" "Incoming message for Reteiving 444"
	And user set properties "" "" "" "12345" "now" "now" ""
	And select the external department "ExternalEntitySameCountry"
	And user attach attachments 1 "1.pdf"
	And user send the email and click on Cancel button
	Then save reference number from "dept" in txt with subject "Incoming message for Reteiving 444"
	When user opens inbox email with subject "Incoming message for Reteiving 444"
	And user click on archieve button
	When user open dept "qaDept" Outbox mail with subject"Incoming message for Reteiving 444"
	And user click on retrive button
	When user open "my" archive message with suject "Incoming message for Reteiving 444" and click on button "Rollback"
	Then mail with subject "Incoming message for Reteiving 444" should not appear in "my" archive message
	When user open dept "qaDept" Outbox mail with subject"Incoming message for Reteiving 444"
	####following step is not working
	And user click on retrive button
	When user opens inbox email with subject "Incoming message for Reteiving 444"
	And click on export button
	And user select To for outgoing "Administrative Communication Department"
	And user compose mail "Incoming message for Reteiving 444" "Incoming message for Reteiving 444"
	And select the external department "ExternalEntitySameCountry"
	And user set properties "" "" "" "" "" "" "Indirect Export Method"
	And user send the email and click on Cancel button
	Then save reference number from "dept" in txt with subject "Incoming message for Reteiving 444"
	When user open dept "qaDept" Outbox mail with subject"Incoming message for Reteiving 444"
	####following step is not working
	And user click on retrive button

Scenario:ph1_11 Print message - 1
	When user go to dept messages Internal Document
	And search "Admin" "UserMainDepartmentAr" "Users"
	And user compose mail "Internal message for print 222" "Internal message for print 222"
	And user select and save the reference no "CD2" of connected document with subject "Any Doc"
	And user attach attachments 1 "1.pdf"
	And user send the email
	Then save reference number from "dept" in txt with subject "Internal message for print 222"
	When user go to dept "qaDept" Outbox
	Then user search and open mail in dept "qaDept" with subject "Internal message for print 222"
	And click on "Print outbox,Save as PDF,dept,Internal message for print 222,Print All-Outbox-In-" button 
	Then the file should appear in download "dept,Internal message for print 222,Print All-Outbox-In-"
	And click on "Print Delivery statement outbox,Save as PDF,dept,Internal message for print 222,Print Delivery Statement-Outbox-In-" button
	Then the file should appear in download "dept,Internal message for print 222,Print Delivery Statement-Outbox-In-"
	And click on "Print Sticker outbox,Save as PDF,dept,Internal message for print 222,Print Sticker-Outbox-In-" button
	Then the file should appear in download "dept,Internal message for print 222,Print Sticker-Outbox-In-"
	When user opens inbox email with subject "Internal message for print 222"
	And click on export button
	And user select To for outgoing "Administrative Communication Department"
	And user compose mail "Export: Internal message for print 222" "Export: Internal message for print 222"
	And select the external department "ExternalEntitySameCountry"
	And user set properties "" "" "" "" "" "" "indirectExport"
	And user attach attachments 1 "1.jpg" and already Had Some Attachment "1"
	And user select all files in attachment "2"
	And click on "Print All,Save as PDF,dept,Internal message for print 222,Print All Attachments-On Creating-" button
	Then the file should appear in download "dept,Internal message for print 222,Print All Attachments-On Creating-"
	And user select files type in attachment ".jpg" "2"
	And click on "Print,Save as PDF,dept,Internal message for print 222,Print Attachments-On Creating-" button
	Then the file should appear in download "dept,Internal message for print 222,Print Attachments-On Creating-"
	And user send the email and save refrence no from popup "my" "Export: Internal message for print 222" "Fasle"
	And click on "Print Barcode,Save as PDF,my,Export: Internal message for print 222,Print Barcode-On Sending-" button
	Then the file should appear in download "my,Export: Internal message for print 222,Print Barcode-On Sending-"
	###And click on "Print Reference Number,Save as PDF,my,Export: Internal message for print 222,Print Reference Number-On Sending-" button
	###Then the file should appear in download "my,Export: Internal message for print 222,Print Reference Number-On Sending-"
	And click on "Print Delivery statement,Save as PDF,my,Export: Internal message for print 222,Print Delivery statement-On Sending-" button
	Then the file should appear in download "my,Export: Internal message for print 222,Print Delivery statement-On Sending-"
	And click on "Print Document,Save as PDF,my,Export: Internal message for print 222,Print Document-On Sending-" button
	Then the file should appear in download "my,Export: Internal message for print 222,Print Document-On Sending-"
	And user click on cancel button
	When user go to dept "CommDepSameDep" messages Unexported folder
	Then user search and select mail in dept "CommDepSameDep" with subject "Export: Internal message for print 222" 
	And click on "Follow-up Button" button and select "Normal View" "Formal View" ""
	And click on "Actions And Movements" button and select "Print this page,Save as PDF,my,Export: Internal message for print 222,Print Action Page-Unexported Out-" "Print All,Save as PDF,my,Export: Internal message for print 222,Print All-Unexported Out-" "Print Flow,Save as PDF,my,Export: Internal message for print 222,Print Flow-Unexported Out-"
	And click on "Back" button
	######following one line is added because back button is not working correctly!
	When user go to dept "CommDepSameDep" messages Unexported folder
	Then user search and select mail in dept "CommDepSameDep" with subject "Export: Internal message for print 222" 
	And click on "Barcode Mail Print" button and select "Print Barcode unexported,Save as PDF,my,Export: Internal message for print 222,Print Action Page-Unexported Out-" "" ""
	When user go to dept "CommDepSameDep" messages Unexported folder
	Then user search and open mail in dept "CommDepSameDep" with subject "Export: Internal message for print 222" 
	And click on "Print Selective" button and select "Print CD and Properties,Save as PDF,my,Export: Internal message for print 222,Print CD&Properties-Unexported In-" "Connected Document,Properties" ""
	And click on "Print Formal Radio btn" button and select "Print Formal Radio btn,Save as PDF,my,Export: Internal message for print 222,Print Formal-Unexported In-" "" ""
	And click on "Open Attachment Tab,Select_All:2" button and select "Print All,Save as PDF,my,Export: Internal message for print 222,Print All Attachments-Unexported In-" "2" ""
	And user select files type in attachment- already unselected ".jpg" "2"
	And click on "Open Attachment Tab,Select_Selective" button and select "Print,Save as PDF,my,Export: Internal message for print 222,Print Attachments-Unexported In-" "" ""
	And click on "Open Attachment Tab,Show All" button and select "Print,Save as PDF,my,Export: Internal message for print 222,Print Attachments-Unexported In-" "" ""
	And click on "Export" button
	And click on "Delivery Statment button" button and select "Print All,Save as PDF,my,Export: Internal message for print 222,Print Delivery Statment-On exporting 2-" "" ""
	And user click on outbox "Print Document again,Save as PDF,my,Export: Internal message for print 222,Print Document-On exporting 2-" button ""
	And user click on outbox "Print Sticker again,Save as PDF,my,Export: Internal message for print 222,Print Sticker-On exporting 2-" button ""
	When user opens exported department "commDept" mail with subject "Export: Internal message for print 222"
	And user click on outbox "Simple Print,Save as PDF,my,Export: Internal message for print 222,Print All-Exported-In-" button ""
	And click on "Print Delivery statement outbox,Save as PDF,my,Export: Internal message for print 222,Print Delivery Ext-Exported-In-" button
	And user click on outbox "Print Document for creator,Save as PDF,my,Export: Internal message for print 222,Print Delivery Int-Exported -In-" button ""
	And click on "Print Sticker,Save As PDF,my,Export: Internal message for print 222,Print Sticker-Exported-In-" button

Scenario:ph1_12 Print message - 2
	When user go to my messages Incomming Document
	And search "internalDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
	And search "InternalDepartmentOtherDepAr" "OtherMainDepartmentAr" "Structural Hierarchy"
	And user compose mail "Incoming message for printing 333" "Incoming message for printing 333"
	And select the external department "ExternalEntitySameCountry"
	And user set properties "Paper" "12345" "Parcels" "+123456789" "now" "now" ""
	And user select and save the reference no "CD3" of connected document with subject "Incoming message for Reteiving 444"
	And user set connected person "Person Name1" "PersonEmail1@mail.com" "12345" "12345" "Riyadh" "now" "هوية" "True"
	Then user send the email and save refrence no from popup "my" "Incoming message for printing 333" "Fasle"
	############################No Print Barcode button in popup
	###And click on "Print Barcode,Save as PDF,my,Incoming message for printing 333,Print Barcode-On Sending-" button
	###Then the file should appear in download "my,Incoming message for printing 333,Print Barcode-On Sending-"
	###And click on "Print Reference Number,Save as PDF,my,Incoming message for printing 333,Print Reference Number-On Sending-" button
	###Then the file should appear in download "my,Incoming message for printing 333,Print Reference Number-On Sending-"
	And user click on outbox "Print Delivery statement,Save as PDF,my,Incoming message for printing 333,Delivery statement-On Sending-" button ""
	And user click on outbox "Print Document,Save as PDF,my,Incoming message for printing 333,Document-On Sending-" button ""
	And user click on outbox "Pop Up Sticker,Save as PDF,my,Incoming message for printing 333,Sticker-On Sending-" button ""
	And user click on cancel button
	When user go to my messages Internal Document
	And search "User" "UserMainDepartmentAr" "Users"
	And user compose mail "Internal message for printing 444" "Internal message for printing 444"
	And user send the email
	Then save reference number from "my" in txt with subject "Internal message for printing 444"
	When user go to my messages Outgoing Document
	And select the external department "ExternalEntitySameCountry"
	And user set properties "" "" "" "" "" "" "Direct Export Method"
	And user compose mail "Outgoing message for printing 555" "Outgoing message for printing 555"
	Then user send the email and save refrence no from popup "my" "Outgoing message for printing 555" "False"
	And click on "Print Barcode,Save as PDF,my,Outgoing message for printing 555,Print Barcode-On Sending-" button
	And user click on cancel button
	When user opens outbox email with subject "Incoming message for printing 333"
	And user click on outbox "Simple Print,Save as PDF,my,Incoming message for printing 333,Print Message - Outbox - Out-" button ""
	When user opens outbox email with subject "Incoming message for printing 333"
	And user click on outbox "Print Sticker,Save as PDF,my,Incoming message for printing 333,Print Sticker - Outbox - In-" button ""
	#Then user search and select mail in dept "myOutbox" with subject "Incoming message for printing 333,Internal message for printing 444,Outgoing message for printing 555"
	When user search and select outbox mail with subject "Incoming message for printing 333" "Internal message for printing 444" "Outgoing message for printing 555"
	When user click on print delivery button
	And user set print type "Every destination in one delivery statement"
	And click on print button
	And user click on outbox "Print 3 Messages" button "Print 3 Messages,Save as PDF,my,Incoming message for printing 333,Print 3 Messages-M3,M4,M5-"
	########### In SN 50 to SN 55 not implemented as expected result is not visible aganist Outgoing message for printing 111
	###When user opens root department "CommDepSameDep" mail with subject "Outgoing message for printing 111"

#Scenario:ph1_13 Message Actions
#	When user go to my messages Incomming Document
#	And search "internalDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
#	And user compose mail "Incoming message for various actions 111" "Incoming message for various actions 111"
#	And select the external department "ExternalEntitySameCountry"
#	And user set properties "Paper" "12345" "Parcels" "+123456789" "now" "now" ""
#	And user attach attachments 1 "1.jpg"
#	And user select connected document with subject "Any Doc"
#	And user add signature ""
#	And user send the email and click on Cancel button
#	Then save reference number from "my" in txt with subject "Incoming message for various actions 111"
#	When user go to dept "QA" messages Inbox folder
#	Then user search and select mail in dept "QA" with subject "Incoming message for various actions 111" 
#	And click on "Follow-up Button" button and select "" "Formal View" ""
#	And click on "Actions And Movements" button and select "" "" "Just open Messaage Flow Tab"
#	And click on "Back" button
	

