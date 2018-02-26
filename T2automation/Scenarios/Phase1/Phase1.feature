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
	Then save reference number from "my" in txt with subject "Internal Message to Internal Department 111"
	#Check the following Step
	When user go to dept "InternalDepartmentSameDepartment2Ar" messages Internal Document
	And search "User" "UserMainDepartmentAr" "Users"
	And user compose mail "Internal message for deletion 222" "Internal message for deletion 222"
	And user attach attachments 1 "1.pdf"
	And user select connected document with subject "Incoming Message to outside child department 111"
	And user send the email
	Then save reference number from "my" in txt with subject "Internal message for deletion 222"
	When user go to dept "InternalDepartmentSameDepartment2Ar" messages Incoming Document
	And search "User" "UserMainDepartmentAr" "Users"
	And user compose mail "Incoming message for deletion 333" "Incoming message for deletion 333"
	And select the external department "ExternalEntitySameCountry"
	And user enters incomming message no "+123456789" and incomming message Gregorian date "now"
	And user set connected person "Person Name1" "PersonEmail1@mail.com" "12345" "12345" "Riyadh" "now" "هوية" "True"
	And user send the email
	Then save reference number from "my" in txt with subject "Internal message for deletion 222"
	And User logs in "UserName" "Password"
	When user go to my messages Internal Document
	And user opens inbox email with subject "Internal message for deletion 111"
	#may be following function would not work as per different btn name or xpath
	Then user deletes the draft
	When user open "my" deleted message with suject "Internal message for deletion 111" and click on button "Rollback"
	Then mail with subject "Internal message for deletion 111" should not appear in "my" deleted message
	When user opens inbox email with subject "Internal message for deletion 111"
	Then verify mail appear in the deleted folder "Type(My,Dept)" "Internal message for deletion 111" "value"	
	Then mail should appear in the inbox "User" "Incoming Message with Connected Person to User 111" "Incoming Message with Connected Person to User 111"	
	When user go to dept messages inbox select and delete messgae with subject "Dept name" "Internal message for deletion 222"
	When user go to dept messages inbox select and delete messgae with subject "Dept name" "Internal message for deletion 333"
	When user open "dept name" deleted message with suject "Internal message for deletion 222" and click on button "Rollback"
	When user open "dept name" deleted message with suject "Internal message for deletion 333" and click on button "Rollback"
	Then mail with subject "Internal message for deletion 222" should not appear in "dept name" deleted message
	And mail with subject "Internal message for deletion 333" should not appear in "dept name" deleted message
	#When user opens department "internalDepartmentSameDep" mail with subject "Internal Message with Connected Documents 111"
	Then mail should appear in department "dept name" inbox "User" "Internal message for deletion 222" "Internal message for deletion 222"	
	Then mail should appear in department "dept name" inbox "User" "Internal message for deletion 333" "Internal message for deletion 333"	
	When Admin set system message permissions for user "Delete Messages from Inbox" "False" "User"
	And Admin set system message permissions for user "Rollback Messages from Deleted Items" "False" "User"
	And Admin set department message permissions for user "Delete Messages from Inbox" "False" "User" "internalDepartmentSameDepAr"
	And Admin set department message permissions for user "Rollback Messages from Deleted Items" "False" "User" "internalDepartmentSameDepAr"

Scenario:ph 2 Message Actions - Archiving Message
	When Admin set system message permissions for user "Archive Messages" "True" "User"
	And Admin set system message permissions for user "Rollback from Archive" "True" "User"
	And Admin set department message permissions for user "Archive Messages" "True" "User" "internalDepartmentSameDepAr"
	And Admin set department message permissions for user "Rollback from Archive" "True" "User" "internalDepartmentSameDepAr"
	And Admin set department message permissions for user "Archive Messages" "True" "User" "InternalDepartmentSameDepartment2Ar"
	And Admin set department message permissions for user "Rollback from Archive" "True" "User" "InternalDepartmentSameDepartment2Ar"
	When user go to my messages Internal Document
	And search "User" "UserMainDepartmentAr" "Users"
	And user compose mail "Internal message for archiving 111" "Internal message for archiving 111"
	And user attach attachments 1 "1.docx"
	And user select connected document with subject "Internal Message to Internal Department 111"
	And user send the email
	Then save reference number from "my" in txt with subject "Internal message for archiving 111"
	When user sends an encrypted message to "UserMainDepartmentAr" "Structural Hierarchy" "internalDepartmentSameDepAr" "Encrypted message for archiving 222" "Encrypted message for archiving 222" "P@ssw0rd!@#"
	#A line needed to be added here but unable to understand yet what! because of no server response
	And user attach attachments 1 "1.xlsx"
	And user select connected document with subject "Internal Message to Internal Department 111"
	And user send the email
	Then save reference number from "my" in txt with subject "Encrypted message for archiving 222"
	When user go to dept "InternalDepartmentSameDepartment2Ar" messages Incoming Document
	And search "User" "UserMainDepartmentAr" "Users"
	And user compose mail "Incoming message for archiving 333" "Incoming message for archiving 333"
	And user attach attachments 1 "1.docx"
	And user select connected document with subject "Internal Message to Internal Department 111"
	# 2 lines need to be written here...
	When user set connected person "PersonName1" "PersonEmail1@mail.com" "12345" "12345" "Riyadh" "now" "هوية" "True"
	And user send the email
	Then save reference number from "deptAcc" in txt with subject "Internal message for archiving 111"
	When user go to dept "InternalDepartmentSameDepartment2Ar" messages Outgoing Document
	And user click CC button "UserMainDepartmentAr" "Structural Hierarchy" "internalDepartmentSameDepAr"
	And select the external department "ExternalEntitySameCountry"   
	#a line need to be added here....
	And user select connected document with subject "Internal Message to Internal Department 111"
	And user compose mail "Outgoing message for archiving 444" "Outgoing message for archiving 444"
	And user attach attachments 1 "1.png"
	And user send the email and click on Cancel button
	Then save reference number from "deptAcc" in txt with subject "Outgoing message for archiving 444"
	When User logs in "UserName" "Password"
	And user opens inbox email with subject "Internal message for archiving 111"
	Then user click on "Archive" button and set "Comment" "1.png"
	When user opens inbox email with subject "Incoming message for archiving 333"
	Then user click on "Archive" button and set "Comment" "1.png"
	And mail should not appear in the inbox "UserMainDepartment" "Internal message for archiving 111" "Internal message for archiving 111"
	And mail should not appear in the inbox "UserMainDepartment" "Incoming message for archiving 333" "Incoming message for archiving 333"
	When user go to "my" archive message with suject "Internal message for archiving 111" and click on button "Rollback"
	And user go to "my" archive message with suject "Incoming message for archiving 333" and click on button "Rollback"
	Then mail with subject "Internal message for archiving 111" should not appear in "my" archive message
	And mail with subject "Incoming message for archiving 333" should not appear in "my" archive message
	Then mail should appear in the inbox "User" "Internal message for archiving 111" "Internal message for archiving 111"
	Then mail should appear in the inbox "User" "Incoming message for archiving 333" "Incoming message for archiving 333"
	When user opens department "internalDepartmentSameDep" mail with subject "Encrypted message for archiving 222"
	Then user click on "Archive" button and set "Comment" ""
	Then mail should not appear in "dept name" dept inbox with subject "Encrypted message for archiving 222"
	When user opens department "internalDepartmentSameDep" mail with subject "Outgoing message for archiving 444"
	Then user click on "Archive" button and set "Comment" ""
	Then mail should not appear in "dept name" dept inbox with subject "Outgoing message for archiving 444"
	When user go to "dept name" archive message with suject "Encrypted message for archiving 222" and click on button "Rollback"
	And user go to "dept name" archive message with suject "Outgoing message for archiving 444" and click on button "Rollback"
	Then mail with subject "Encrypted message for archiving 222" should not appear in "dept name" archive message
	And mail with subject "Outgoing message for archiving 444" should not appear in "dept name" archive message
	Then mail should appear in dept inbox "internalDepartmentSameDepAr" "Encrypted message for archiving 222" "Encrypted message for archiving 222"
	And mail should appear in dept inbox "internalDepartmentSameDepAr" "Outgoing message for archiving 444" "Outgoing message for archiving 444"
	
