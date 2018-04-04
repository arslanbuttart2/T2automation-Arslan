Feature: Phase2
	
Background: 
	Given Admin logged in "AdminUserName" "AdminPassword"

Scenario: ph2.1 Message Actions
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
	And click on "Back" button