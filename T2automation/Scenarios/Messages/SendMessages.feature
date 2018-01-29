Feature: Send Messages/Mail

Scenario Outline: Sending internal message - personal mail
	Given Admin logged in "<adminUserName>" "<adminPassword>"
	When user sends an internal message to "<level>" "<receiverType>" "<to>" "<subject>" "<content>"
	Then mail should appear in my message out box "<to>" "<subject>" "<content>" "" ""
	When User logs in "<userName>" "<password>"
	Then mail should appear in the inbox "<to>" "<subject>" "<content>"
	
	Examples:
		| adminUserName | adminPassword | level			  | receiverType | to		| subject		   | content	  | userName		   | password					|
		| AdminUserName | AdminPassword | UserMainDepartmentAr | Users		 |UserSameDepartment	| Internal Message | Test content | UserSameDepartment | PasswordUserSameDepartment |

Scenario Outline: Sending encrypted message - personal mail
	Given Admin logged in "<adminUserName>" "<adminPassword>"
	When user sends an encrypted message to "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<encryptedPass>"
	Then encrypted mail should appear in the out box "<to>" "<subject>" "<content>" "<listSubject>" "<encryptedPass>"
	When User logs in "<userName>" "<password>"
	Then encrypted mail should appear in the inbox "<to>" "<subject>" "<content>" "<listSubject>" "<encryptedPass>"
	
	Examples:
		| adminUserName | adminPassword | level          | receiverType | encryptedPass		 | listSubject					| to		| subject			| content | userName | password |
		| AdminUserName | AdminPassword | UserMainDepartmentAr | Users       | EncryptedMessagePW | This message need a password	|UserSameDepartment	| Encrypted Message | Test content | UserSameDepartment | PasswordUserSameDepartment |

Scenario Outline: Sending incoming message - personal mail
	Given Admin logged in "<adminUserName>" "<adminPassword>"
	When user sends an incoming message to "<level>" "<receiverType>" "<to>" "<subject>" "<content>"
	Then mail should appear in my message out box "<to>" "<subject>" "<content>" "" ""
	When User logs in "<userName>" "<password>"
	Then mail should appear in the inbox "<to>" "<subject>" "<content>"
	
	Examples:
		| adminUserName | adminPassword | level			  | receiverType | to		| subject		   | content	  | userName		   | password					|
		| AdminUserName | AdminPassword | UserMainDepartmentAr | Users		 |UserSameDepartment	| Incomming Message | Test content | UserSameDepartment | PasswordUserSameDepartment |

Scenario Outline: Sending outgoing message - personal mail
	Given Admin logged in "<adminUserName>" "<adminPassword>"
	When user sends an outgoing message to "<name>" "<subject>" "<content>" "<deliveryType>"
	Then mail should appear in my message out box "<CommDept>" "<subject>" "<content>" "" ""
	Then mail should appear in Department Message with Root "<CommDept>" "<subject>" "<content>"
	
	Examples:
		| adminUserName | adminPassword | deliveryType | name                      | subject         | content      | CommDept		 |
		| AdminUserName | AdminPassword | DeliveryType | ExternalEntitySameCountry | Outgoig Message | Test content | CommDepSameDep |

Scenario: Sending internal message - Department mail
	Given Admin logged in "AdminUserName" "AdminPassword"
	When user sends an internal message to "UserMainDepartmentAr" "Users" "UserSameDepartment" "Sending Internal Message 111" "Sending Internal Message 111"
	Then mail should appear in my message out box "UserSameDepartment" "Sending Internal Message 111" "Sending Internal Message 111" "0" ""
	When User logs in "UserSameDepartment" "PasswordUserSameDepartment"
	Then mail should appear in the inbox "UserSameDepartment" "Sending Internal Message 111" "Sending Internal Message 111"
