Feature: Phase2
	
Background: 
	Given Admin logged in "AdminUserName" "AdminPassword"

Scenario:ph2_1 Message Actions
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

Scenario:ph2_2 Message Actions
	


