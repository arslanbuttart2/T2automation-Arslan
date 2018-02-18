Feature: Send Messages/Mail

Scenario Outline:21 Sending internal message - personal mail
	Given Admin logged in "<adminUserName>" "<adminPassword>"
	When user sends an internal message to "<level>" "<receiverType>" "<to>" "<subject>" "<content>"
	Then mail should appear in my message out box "<to>" "<subject>" "<content>" "" ""
	When User logs in "<userName>" "<password>"
	Then mail should appear in the inbox "<to>" "<subject>" "<content>"
	
	Examples:
		| adminUserName | adminPassword | level			  | receiverType | to		| subject		   | content	  | userName		   | password					|
		| AdminUserName | AdminPassword | UserMainDepartmentAr | Users		 |UserSameDepartment	| Internal Message | Test content | UserSameDepartment | PasswordUserSameDepartment |

Scenario Outline:22 Sending encrypted message - personal mail
	Given Admin logged in "<adminUserName>" "<adminPassword>"
	When user sends an encrypted message to "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<encryptedPass>"
	Then encrypted mail should appear in the out box "<to>" "<subject>" "<content>" "<listSubject>" "<encryptedPass>"
	When User logs in "<userName>" "<password>"
	Then encrypted mail should appear in the inbox "<to>" "<subject>" "<content>" "<listSubject>" "<encryptedPass>"
	
	Examples:
		| adminUserName | adminPassword | level          | receiverType | encryptedPass		 | listSubject					| to		| subject			| content | userName | password |
		| AdminUserName | AdminPassword | UserMainDepartmentAr | Users       | EncryptedMessagePW | This message need a password	|UserSameDepartment	| Encrypted Message | Test content | UserSameDepartment | PasswordUserSameDepartment |

Scenario Outline:23 Sending incoming message - personal mail
	Given Admin logged in "<adminUserName>" "<adminPassword>"
	When user sends an incoming message to "<level>" "<receiverType>" "<to>" "<subject>" "<content>"
	Then mail should appear in my message out box "<to>" "<subject>" "<content>" "" ""
	When User logs in "<userName>" "<password>"
	Then mail should appear in the inbox "<to>" "<subject>" "<content>"
	
	Examples:
		| adminUserName | adminPassword | level			  | receiverType | to		| subject		   | content	  | userName		   | password					|
		| AdminUserName | AdminPassword | UserMainDepartmentAr | Users		 |UserSameDepartment	| Incomming Message | Test content | UserSameDepartment | PasswordUserSameDepartment |

Scenario Outline:24 Sending outgoing message - personal mail
	Given Admin logged in "<adminUserName>" "<adminPassword>"
	When user sends an outgoing message to "<name>" "<subject>" "<content>" "<deliveryType>"
	Then mail should appear in my message out box "<CommDept>" "<subject>" "<content>" "" ""
	Then mail should appear in Department Message with Root "<CommDept>" "<subject>" "<content>"
	
	Examples:
		| adminUserName | adminPassword | deliveryType | name                      | subject         | content      | CommDept		 |
		| AdminUserName | AdminPassword | DeliveryType | ExternalEntitySameCountry | Outgoig Message | Test content | CommDepSameDep |

Scenario:25 Sending internal message - Department mail
	Given Admin logged in "AdminUserName" "AdminPassword"
	When user sends an internal message to "UserMainDepartmentAr" "Users" "UserSameDepartment" "Sending Internal Message 111" "Sending Internal Message 111"
	Then mail should appear in my message out box "UserSameDepartment" "Sending Internal Message 111" "Sending Internal Message 111" "0" ""
	When User logs in "UserSameDepartment" "PasswordUserSameDepartment"
	Then mail should appear in the inbox "UserSameDepartment" "Sending Internal Message 111" "Sending Internal Message 111"

Scenario:26 Sending incoming message - Department mail
	Given Admin logged in "AdminUserName" "AdminPassword"
	When user go to my messages Incomming Document
	And search "internalDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
	And user compose mail "Sending Incoming Message 111" "Sending Incoming Message 111"
	And user send the email and click on Cancel button
	Then mail should appear in my message out box "internalDepartmentSameDepAr" "Sending Incoming Message 111" "Sending Incoming Message 111" "0" ""
	When user opens department "internalDepartmentSameDep" mail with subject "Sending Incoming Message 111"
	Then mail should appear in dept inbox "internalDepartmentSameDepAr" "Sending Incoming Message 111" "Sending Incoming Message 111"

Scenario: 27 Sending outgoing message - Department  mail
	Given Admin logged in "AdminUserName" "AdminPassword"
	When user go to my messages Outgoing Document
	And select the external department "ExternalEntitySameCountry"   
	And select delivery type "Delivery by hand"
	And user compose mail "Sending Outgoing Message 111" "Sending Outgoing Message 111"
	And user send the email and click on Cancel button
	Then mail should appear in my message out box "CommDepSameDep" "Sending Outgoing Message 111" "Sending Outgoing Message 111" "0" ""
	Then mail should appear in Department Message with Root "CommDepSameDep" "Sending Outgoing Message 111" "Sending Outgoing Message 111"
	
	