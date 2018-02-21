Feature: Send Messages/Mail

Scenario Outline:sm 21 Sending internal message - personal mail
	Given Admin logged in "<adminUserName>" "<adminPassword>"
	When user sends an internal message to "<level>" "<receiverType>" "<to>" "<subject>" "<content>"
	Then mail should appear in my message out box "<to>" "<subject>" "<content>" "0" ""
	When User logs in "<userName>" "<password>"
	Then mail should appear in the inbox "<to>" "<subject>" "<content>"
	
	Examples:
		| adminUserName | adminPassword | level			  | receiverType | to		| subject		   | content	  | userName		   | password					|
		| AdminUserName | AdminPassword | UserMainDepartmentAr | Users		 |UserSameDepartment	| Internal Message | Test content | UserSameDepartment | PasswordUserSameDepartment |

Scenario Outline:sm 22 Sending encrypted message - personal mail
	Given Admin logged in "<adminUserName>" "<adminPassword>"
	When user sends an encrypted message to "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<encryptedPass>"
	Then encrypted mail should appear in the out box "<to>" "<subject>" "<content>" "<listSubject>" "<encryptedPass>"
	When User logs in "<userName>" "<password>"
	Then encrypted mail should appear in the inbox "<to>" "<subject>" "<content>" "<listSubject>" "<encryptedPass>"
	
	Examples:
		| adminUserName | adminPassword | level          | receiverType | encryptedPass		 | listSubject					| to		| subject			| content | userName | password |
		| AdminUserName | AdminPassword | UserMainDepartmentAr | Users       | EncryptedMessagePW | This message need a password	|UserSameDepartment	| Encrypted Message | Test content | UserSameDepartment | PasswordUserSameDepartment |

Scenario Outline:sm 23 Sending incoming message - personal mail
	Given Admin logged in "<adminUserName>" "<adminPassword>"
	When user sends an incoming message to "<level>" "<receiverType>" "<to>" "<subject>" "<content>"
	Then mail should appear in my message out box "<to>" "<subject>" "<content>" "" ""
	When User logs in "<userName>" "<password>"
	Then mail should appear in the inbox "<to>" "<subject>" "<content>"
	
	Examples:
		| adminUserName | adminPassword | level			  | receiverType | to		| subject		   | content	  | userName		   | password					|
		| AdminUserName | AdminPassword | UserMainDepartmentAr | Users		 |UserSameDepartment	| Incomming Message | Test content | UserSameDepartment | PasswordUserSameDepartment |

Scenario Outline:sm 24 Sending outgoing message - personal mail
	Given Admin logged in "<adminUserName>" "<adminPassword>"
	When user sends an outgoing message to "<name>" "<subject>" "<content>" "<deliveryType>"
	Then mail should appear in my message out box "<CommDept>" "<subject>" "<content>" "" ""
	Then mail should appear in Department Message with Root "<CommDept>" "<subject>" "<content>"
	
	Examples:
		| adminUserName | adminPassword | deliveryType | name                      | subject         | content      | CommDept		 |
		| AdminUserName | AdminPassword | DeliveryType | ExternalEntitySameCountry | Outgoig Message | Test content | CommDepSameDep |

Scenario:sm 25 Sending internal message - Department mail
	Given Admin logged in "AdminUserName" "AdminPassword"
	When user sends an internal message to "UserMainDepartmentAr" "Users" "UserSameDepartment" "Sending Internal Message 111" "Sending Internal Message 111"
	Then mail should appear in my message out box "UserSameDepartment" "Sending Internal Message 111" "Sending Internal Message 111" "0" ""
	When User logs in "UserSameDepartment" "PasswordUserSameDepartment"
	Then mail should appear in the inbox "UserSameDepartment" "Sending Internal Message 111" "Sending Internal Message 111"

Scenario:sm 26 Sending incoming message - Department mail
	Given Admin logged in "AdminUserName" "AdminPassword"
	When user go to my messages Incomming Document
	And search "internalDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
	And user compose mail "Sending Incoming Message 111" "Sending Incoming Message 111"
	And user send the email and click on Cancel button
	Then mail should appear in my message out box "internalDepartmentSameDepAr" "Sending Incoming Message 111" "Sending Incoming Message 111" "0" ""
	When user opens department "internalDepartmentSameDep" mail with subject "Sending Incoming Message 111"
	Then mail should appear in dept inbox "internalDepartmentSameDepAr" "Sending Incoming Message 111" "Sending Incoming Message 111"

Scenario:sm 27 Sending outgoing message - Department  mail
	Given Admin logged in "AdminUserName" "AdminPassword"
	When user go to my messages Outgoing Document
	And select the external department "ExternalEntitySameCountry"   
	And select delivery type "Delivery by hand"
	And user compose mail "Sending Outgoing Message 111" "Sending Outgoing Message 111"
	And user send the email and click on Cancel button
	Then mail should appear in my message out box "CommDepSameDep" "Sending Outgoing Message 111" "Sending Outgoing Message 111" "0" ""
	Then mail should appear in Department Message with Root "CommDepSameDep" "Sending Outgoing Message 111" "Sending Outgoing Message 111"

Scenario:sm 28 Sending Permissions -  send to all users - Personal mail
	Given Admin logged in "AdminUserName" "AdminPassword"
	When Admin set system message sending permissions for user "User" "Send All Users"
	Then Admin logged in "UserName" "Password"
	Then user sends an internal message to and cc "UserMainDepartmentAr" "Users" "UserSameDepartment" "Sending Permission to All Users 111" "Sending Permission to All Users 111" "OtherMainDepartmentAr" "Users" "UserOtherDepartment"
	Then Admin logged in "AdminUserName" "AdminPassword"
	Then Admin unset system message sending permissions for user "User" "Send All Users"
	Then Admin logged in "UserOtherDepartment" "UserOtherDepartmentPassword"
	Then mail should appear in the inbox "UserMainDepartment" "Sending Permission to All Users 111" "Sending Permission to All Users 111" "True"

Scenario:sm 29 Sending Permissions -  send to all departments - Personal mail
	Given Admin logged in "AdminUserName" "AdminPassword"
	When Admin set system message sending permissions for user "User" "Send All Departments"
	Then Admin logged in "UserName" "Password"
	Then user sends an internal message to and cc "UserMainDepartmentAr" "Structural Hierarchy" "UserSameDepartment" "Sending Permission to All Users 111" "Sending Permission to All Users 111" "OtherMainDepartmentAr" "Users" "UserOtherDepartment"
	Then Admin logged in "AdminUserName" "AdminPassword"
	Then Admin unset system message sending permissions for user "User" "Send All Departments"
	Then Admin logged in "UserOtherDepartment" "UserOtherDepartmentPassword"
	Then mail should appear in the inbox "UserMainDepartment" "Sending Permission to All Users 111" "Sending Permission to All Users 111" ""
	
	