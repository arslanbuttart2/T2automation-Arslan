Feature: Phase 1

Background: 
	Given Admin logged in "AdminUserName" "AdminPassword"

Scenario:1 Message Actions - Deleting Message
	When Admin set system message permissions for user "Delete Messages from Inbox" "True" "User"
	And Admin set system message permissions for user "Rollback Messages from Deleted Items" "True" "User"
	And Admin set department message permissions for user "Delete Messages from Inbox" "True" "User" "internalDepartmentSameDepAr"
	And Admin set department message permissions for user "Rollback Messages from Deleted Items" "True" "User" "internalDepartmentSameDepAr"
	When user go to my messages Internal Document
	And search "internalDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
	And user compose mail "Internal message for deletion 111" "Internal message for deletion 111"
	And user attach attachments 1 "1.pdf"
	And user send the email
	Then save reference number from "my" in excel with subject "Internal Message to Internal Department 111"
	When user go to dept "InternalDepartmentSameDepartment2Ar" messages Internal Document
	And search "User" "UserMainDepartmentAr" "Users"
	And user compose mail "Internal message for deletion 222" "Internal message for deletion 222"
	And user attach attachments 1 "1.pdf"
	And user select connected document with subject "Incoming Message to outside child department 111"
	And user send the email
	#Then save reference number from "my" in excel with subject "Internal message for deletion 222"
	When user go to dept "InternalDepartmentSameDepartment2Ar" messages Incoming Document
	nd search "User" "UserMainDepartmentAr" "Users"
	And user compose mail "Incoming message for deletion 333" "Incoming message for deletion 333"
	And select the external department "ExternalEntitySameCountry"
	And user enters incomming message no "+123456789" and incomming message Gregorian date "now"
	And user set connected person "Person Name1" "PersonEmail1@mail.com" "12345" "12345" "Riyadh" "now" "هوية" "True"
	And user send the email
	#Then save reference number from "my" in excel with subject "Internal message for deletion 222"
	And User logs in "UserName" "Password"