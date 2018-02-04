Feature: Message actions

Background: 
	Given Admin logged in "AdminUserName" "AdminPassword"

Scenario Outline: message - Add attachement to message - 1 file - personal mail
	
	When user sends an internal message with attachment to "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>"
	Then mail should appear in my message out box "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>"	
	Examples:
		| level         | receiverType | to      | subject                      | content                      | userName           | password                   | multipleAttachementNo | multipleAttachmentType |
		| ديوان الوزارة | Users        | arslanadmin | Message with attachement 111 | Message with attachement 111 | UserSameDepartment | PasswordUserSameDepartment | 1                    | 1.jpg                    |

Scenario Outline: message - Add attachement to message - 1 file - department mail
	When user sends an departmental internal message with attachment to "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"
	Then mail should appear in department message out box "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"
	Examples:
		| level         | receiverType | to      | subject                      | content                      | userName           | password                   | multipleAttachementNo | multipleAttachmentType | dept                      |
		| ديوان الوزارة | Users        | arslanadmin | Message with attachement 111 | Message with attachement 111 | UserSameDepartment | PasswordUserSameDepartment | 1                    | 1.jpg                  | internalDepartmentSameDep |

Scenario Outline: Message- Add attachement (multiple files)- personal mail
	When user sends an internal message with attachment to "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>"
	Then mail should appear in my message out box "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>"	
	Examples:
		| level         | receiverType | to      | subject                      | content                      | userName           | password                   | multipleAttachementNo | multipleAttachmentType |
		| ديوان الوزارة | Users        | arslanadmin | Message with multiple attachement 111 | Message with attachement 111 | UserSameDepartment | PasswordUserSameDepartment | 10                   | 1.jpg                    |

Scenario Outline: Message- Add attachement (multiple files)- Department mail
	When user sends an departmental internal message with attachment to "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"
	Then mail should appear in department message out box "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"
	Examples:
		| level         | receiverType | to      | subject                      | content                      | userName           | password                   | multipleAttachementNo | multipleAttachmentType | dept                      |
		| ديوان الوزارة | Users        | arslanadmin | Message with multiple attachement 111 | Message with attachement 111 | UserSameDepartment | PasswordUserSameDepartment | 10                    | 1.jpg                  | internalDepartmentSameDep |

Scenario Outline: Message- Add attachement (multiple file types)- personal mail
	When user sends an internal message with attachment to "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>"
	Then mail should appear in my message out box "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>"	
	Examples:
		| level         | receiverType | to      | subject                      | content                      | userName           | password                   | multipleAttachementNo | multipleAttachmentType |
		| ديوان الوزارة | Users        | arslanadmin | Message with multiple type attachement 111 | Message with multiple attachement 111 | UserSameDepartment | PasswordUserSameDepartment | 3                   | 1.png,1.mp3,1.avi,1.pdf,1.xlxs |

Scenario Outline: Message- Add attachement (multiple file types)- department mail
	When user sends an departmental internal message with attachment to "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"
	Then mail should appear in department message out box "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"
	Examples:
		| level         | receiverType | to      | subject                      | content                      | userName           | password                   | multipleAttachementNo | multipleAttachmentType		  | dept                      |
		| ديوان الوزارة | Users        | arslanadmin | Message with multiple type attachement 111 |Message with multiple attachement 111 | UserSameDepartment | PasswordUserSameDepartment | 3                  | 1.png,1.mp3,1.avi,1.pdf,1.xlxs | internalDepartmentSameDep |

Scenario Outline: Message- Delete attachement from message - personal mail
	When user attach attachment to internal message "<multipleAttachmentType>" "<multipleAttachementNo>"
	And user delete the attachment "<deleteAttachmentTypes>" "<deleteAttachmentNo>"
	Then attachment should not appear "<multipleAttachmentType>" "<multipleAttachementNo>" "<deleteAttachmentNo>"
	Examples:
		| multipleAttachmentType | multipleAttachementNo | deleteAttachmentNo | deleteAttachmentTypes |
		| 1.jpg                  |           1           |			1         |       1.jpg           |

Scenario Outline: Message- Delete multiple attachements from message - department mail
	When user attach attachment to department internal message "<multipleAttachmentType>" "<multipleAttachementNo>"
	And user delete the attachment "<deleteAttachmentTypes>" "<deleteAttachmentNo>"
	Then attachment should not appear "<multipleAttachmentType>" "<multipleAttachementNo>" "<deleteAttachmentNo>"
	Examples:
		| multipleAttachmentType | multipleAttachementNo | deleteAttachmentNo | deleteAttachmentTypes |
		| 1.jpg                  | 3                     |         2          |       1.jpg           |

Scenario Outline: Download attachement. - personal mail
	When user download the attachment from inbox mail "<subject>" "<downloadFileName>" "<downloadFileNo>"
	Then the file should appear in downloads "<downloadFileName>" "<downloadFileNo>"

	Examples:
		|				subject					| downloadFileName| downloadFileNo |
		| Message with multiple attachement 111 |      1.jpg      |		1		   |

Scenario Outline: Download attachement - department mail
	When user download the attachment from department inbox mail "<subject>" "<downloadFileName>" "<downloadFileNo>"
	Then the file should appear in downloads "<downloadFileName>" "<downloadFileNo>"

	Examples:
		|				subject					| downloadFileName| downloadFileNo |
		| Message with multiple attachement 111 |      1.jpg      |		1		   |

Scenario Outline: download all attachment - personal mail
	When user download the attachment from inbox mail "<subject>" "<downloadFileName>" "<downloadFileNo>"
	Then the file should appear in downloads "<downloadFileName>" "<downloadFileNo>"

	Examples:
		|				subject					| downloadFileName| downloadFileNo |
		| Message with multiple attachement 111 |      All        |		10		   |

Scenario Outline: download all attachment - department mail
	When user download the attachment from department inbox mail "<subject>" "<downloadFileName>" "<downloadFileNo>"
	Then the file should appear in downloads "<downloadFileName>" "<downloadFileNo>"

	Examples:
		|				subject					| downloadFileName| downloadFileNo |
		| Message with multiple attachement 111 |      All        |		10		   |

Scenario Outline: message -  attachement - security level with optional attachment - with attachement -  personal mail
	When user sends an internal message with properties with attachments "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<securitylevel>" "<multipleAttachementNo>" "<multipleAttachmentType>"

	Examples:
		| level         | receiverType | to                 | subject                     | content                      | multipleAttachementNo | multipleAttachmentType | SecurityLevelOptionalAttach |
		| ديوان الوزارة | Users        | UserSameDepartment | SecurityLevelOptionalAttach | SecurityLevelOptionalAttacht | 1                     | 1.jpg                  | SecurityLevelOptionalAttach |

Scenario Outline: message -  attachement - security level with optional attachment adding -  without attachement -  department mail
	When user sends an deparment internal message with properties with attachments "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<securitylevel>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"

	Examples:
		| level         | receiverType | to                 | subject                     | content                      | multipleAttachementNo | multipleAttachmentType | securitylevel | dept                      |
		| ديوان الوزارة | Users        | internalDepartmentSameDep | SecurityLevelOptionalAttach | SecurityLevelOptionalAttacht | 1                     | 1.jpg                  | SecurityLevelOptionalAttach | internalDepartmentSameDep |

Scenario Outline: message - attachment - security level with attachment forbidden - personal mail
	When user sends an internal message with properties with attachments "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<securitylevel>" "<multipleAttachementNo>" "<multipleAttachmentType>"

	Examples:
		| level         | receiverType | to                 | subject                     | content                      | multipleAttachementNo | multipleAttachmentType | SecurityLevelOptionalAttach |
		| ديوان الوزارة | Users        | UserSameDepartment | SecurityLevelForbidAttach | SecurityLevelForbidAttach | 1                     | 1.jpg                  | SecurityLevelForbidAttach |

Scenario Outline:  message - attachment - security level with attachment forbidden - department mail
	When user sends an deparment internal message with properties with attachments "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<securitylevel>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"

	Examples:
		| level         | receiverType | to                 | subject                     | content                      | multipleAttachementNo | multipleAttachmentType | securitylevel | dept                      |
		| ديوان الوزارة | Users        | internalDepartmentSameDep | SecurityLevelForbidAttach | SecurityLevelForbidAttach | 1                     | 1.jpg                  | SecurityLevelForbidAttach | internalDepartmentSameDep |

Scenario Outline:  message - attachment - security level with attachment required - with attachement - personal mail
	When user sends an internal message with properties with attachments "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<securitylevel>" "<multipleAttachementNo>" "<multipleAttachmentType>"

	Examples:
		| level         | receiverType | to                 | subject                     | content                      | multipleAttachementNo | multipleAttachmentType | SecurityLevelOptionalAttach |
		| ديوان الوزارة | Users        | UserSameDepartment | SecurityLevelRequiredAttach | SecurityLevelRequiredAttach | 1                     | 1.jpg                  | SecurityLevelRequiredAttach |

Scenario Outline:   message - attachment - security level with attachment required - without attachement - department mail
	When user sends an deparment internal message with properties with attachments "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<securitylevel>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"

	Examples:
		| level         | receiverType | to                 | subject                     | content                      | multipleAttachementNo | multipleAttachmentType | securitylevel | dept                      |
		| ديوان الوزارة | Users        | internalDepartmentSameDep | SecurityLevelRequiredAttach | SecurityLevelRequiredAttach | 1                     | 1.jpg                  | SecurityLevelRequiredAttach | internalDepartmentSameDep |

Scenario: Message - Connected Documents - Test Case 1
	When user go to my messages Internal Document
	And search "internalDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
	And user compose mail "Internal Message to Internal Department 111" "Internal Message to Internal Department 111"
	And user attach attachments 1 "1.png"
	And user send the email
	And user go to my messages Internal Document
	And search "InternalDepartmentOtherDepAr" "OtherMainDepartmentAr" "Structural Hierarchy"
	And user compose mail "Internal Message to Outside Internal Department 111" "Internal Message to Outside Internal Department 111"
	And user attach attachments 1 "1.png"
	And user send the email
	And user go to my messages Internal Document
	And search "ChildDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
	And user compose mail "Incoming Message to Child Department 111" "Incoming Message to Child Department 111"
	And user attach attachments 1 "1.png"
	And user send the email
	And user go to my messages Internal Document
	And search "ChildDepartmentOtherDepAr" "OtherMainDepartmentAr" "Structural Hierarchy"
	And user compose mail "Incoming Message to Outside Child Department 111" "Incoming Message to Outside Child Department 111"
	And user attach attachments 1 "1.png"
	And user send the email
	And user go to my messages Outgoing Document
	And select the external department "ExternalEntitySameCountry"   
	And select delivery type "Delivery by hand"
	And user compose mail "Outgoing Message to Admin Communication department 111" "Outgoing Message to Admin Communication department 111"
	And user attach attachments 1 "1.png"
	And user send the email and click on Cancel button
	And user go to my messages Internal Document
	And search "User" "UserMainDepartmentAr" "Users"
	And search "internalDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
	And user compose mail "Internal Message with Connected Documents 111" "Internal Message with Connected Documents 111"
	And user select connected document with subject "Internal Message to Internal Department 111"
	And user select connected document with subject "Incoming Message to Child Department 111"
	And user select connected document with subject "Outgoing Message to Admin Communication department 111"
	And user send the email

Scenario: Message - View connected document - with permission -  personal mail
	When Admin set system message permissions for user "View Related Messages" "True" "User"
	And Admin set system message permissions for user "Add Related Message" "False" "User"
	And Admin set system message permissions for user "Remove Related Messages" "False" "User"
	And Admin set system message permissions for user "Open Related Messages" "False" "User"
	And User logs in "UserName" "Password"
	And user opens inbox email with subject "Internal Message with Connected Documents 111"
	Then the visibilty of tab "Connected Document" should be "True" on connected doc tab
	Then the visibilty of button "Add" should be "False" on connected doc tab
	And the visibilty of button "Delete" should be "False" on connected doc tab

Scenario: Message - View connected document - without permission -  personal mail
	When Admin set system message permissions for user "View Related Messages" "False" "User"
	And User logs in "UserName" "Password"
	And user opens inbox email with subject "Internal Message with Connected Documents 111"
	Then the visibilty of tab "Connected Document" should be "False" on connected doc tab

Scenario: Message - View connected document - with permission -  department mail
	When Admin set department message permissions for user "View Related Messages" "True" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Add Related Message" "False" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Remove Related Messages" "False" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Open Related Messages" "False" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Can Reply" "True" "User" "internalDepartmentSameDep"
	And User logs in "UserName" "Password"
	And user opens department "internalDepartmentSameDep" mail with subject "Internal Message with Connected Documents 111"
	And user click on reply button
	Then the visibilty of tab "Connected Document" should be "True" on connected doc tab
	Then the visibilty of button "Add" should be "False" on connected doc tab
	And the visibilty of button "Delete" should be "False" on connected doc tab
	When user deletes the draft

Scenario: Message - View connected document - without permission -  

	When Admin set department message permissions for user "View Related Messages" "False" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Can Reply" "False" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Can Forward" "True" "User" "internalDepartmentSameDep"
	And User logs in "UserName" "Password"
	And user opens department "internalDepartmentSameDep" mail with subject "Internal Message with Connected Documents 111"
	And user click on forward button
	Then the visibilty of tab "Connected Document" should be "False" on connected doc tab
	When user deletes the draft

Scenario: Message - add connected document - with permission -  personal mail
	When Admin set system message permissions for user "Create Internal Message" "True" "User"
	When Admin set system message permissions for user "View Related Messages" "True" "User"
	And Admin set system message permissions for user "Add Related Message" "True" "User"
	And Admin set system message permissions for user "Remove Related Messages" "False" "User"
	And Admin set system message permissions for user "Open Related Messages" "False" "User"
	And User logs in "UserName" "Password"
	And user go to my messages Internal Document
	And user select connected document with subject "Internal Message with Connected Documents 111"
	And user clicks on save draft
	Then the connected document with subject "Internal Message with Connected Documents 111" should appear in the list

Scenario: Message - add/delete connected document - no permission -  personal mail
	When Admin set system message permissions for user "Create Internal Message" "True" "User"
	When Admin set system message permissions for user "View Related Messages" "True" "User"
	And Admin set system message permissions for user "Add Related Message" "False" "User"
	And Admin set system message permissions for user "Remove Related Messages" "False" "User"
	And Admin set system message permissions for user "Open Related Messages" "True" "User"
	And User logs in "UserName" "Password"
	And user go to my messages Internal Document
	Then the visibilty of button "Add" should be "False" on connected doc tab
	And the visibilty of button "Delete" should be "False" on connected doc tab

Scenario: Message Permission - add connected document - with permission - department mail
	When Admin set department message permissions for user "Create Internal Message" "True" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "View Related Messages" "True" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Add Related Message" "True" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Remove Related Messages" "False" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Open Related Messages" "False" "User" "internalDepartmentSameDep"
	And User logs in "UserName" "Password"
	And user go to dept messages Internal Document
	And user select connected document with subject "Internal Message with Connected Documents 111"
	And user clicks on save draft
	Then the connected document with subject "Internal Message with Connected Documents 111" should appear in the list

Scenario: Message Permission - add/delete connected document - no permission - department mail
	When Admin set department message permissions for user "Create Internal Message" "True" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "View Related Messages" "True" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Add Related Message" "False" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Remove Related Messages" "False" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Open Related Messages" "True" "User" "internalDepartmentSameDep"
	And User logs in "UserName" "Password"
	And user go to dept messages Internal Document
	Then the visibilty of button "Add" should be "False" on connected doc tab
	And the visibilty of button "Delete" should be "False" on connected doc tab

Scenario: Message - add connected document - system level - with permission -  personal mail
	When Admin set system message permissions for user "Create Internal Message" "True" "User"
	When Admin set system message permissions for user "View Related Messages" "True" "User"
	And Admin set system message permissions for user "Can Link with Message from Related Departments Messages" "False" "User"
	And Admin set system message permissions for user "Can Link it with Whole System Messages" "True" "User"
	And Admin set system message permissions for user "Can Link with Related Departments Messages and Below" "False" "User"
	And User logs in "UserName" "Password"
	And user go to my messages Internal Document
	And user select connected document with subject "Incoming Message to outside child department 111"
	And user clicks on save draft
	Then the connected document with subject "Incoming Message to outside child department 111" should appear in the list
	When user deletes the draft
	Given Admin logged in "AdminUserName" "AdminPassword"
	When Admin set system message permissions for user "View Related Messages" "False" "User"
	And Admin set system message permissions for user "Can Link it with Whole System Messages" "False" "User"

Scenario: Message - add connected document - Related departments only - with permission -  personal mail
	When Admin set system message permissions for user "Create Internal Message" "True" "User"
	And Admin set system message permissions for user "View Related Messages" "True" "User"
	And Admin set system message permissions for user "Add Related Message" "True" "User"
	And Admin set system message permissions for user "Can Link with Message from Related Departments Messages" "True" "User"
	And Admin set system message permissions for user "Can Link it with Whole System Messages" "False" "User"
	And Admin set system message permissions for user "Can Link with Related Departments Messages and Below" "False" "User"
	And User logs in "UserName" "Password"
	And user go to my messages Internal Document
	And user select connected document with subject "Internal Message to Internal Department 111"
	Then verify that connected document with subject "Incoming Message to Child Department 111" should not appear in while adding new
	And verify that connected document with subject "Internal Message to Outside Internal Department 111" should not appear in while adding new
	When user clicks on save draft
	Then the connected document with subject "Internal Message to Internal Department 111" should appear in the list
	When user deletes the draft
	Given Admin logged in "AdminUserName" "AdminPassword"
	When Admin set system message permissions for user "Can Link with Message from Related Departments Messages" "False" "User"
	And Admin set system message permissions for user "Create Internal Message" "False" "User"
	And Admin set system message permissions for user "View Related Messages" "False" "User"
	And Admin set system message permissions for user "Add Related Message" "False" "User"

Scenario: Message - add connected document - Related departments and below - with permission -  personal mail
	When Admin set system message permissions for user "Create Outing Message" "True" "User"
	And Admin set system message permissions for user "View Related Messages" "True" "User"
	And Admin set system message permissions for user "Add Related Message" "True" "User"
	And Admin set system message permissions for user "Can Link with Message from Related Departments Messages" "False" "User"
	And Admin set system message permissions for user "Can Link it with Whole System Messages" "False" "User"
	And Admin set system message permissions for user "Can Link with Related Departments Messages and Below" "True" "User"
	And User logs in "UserName" "Password"
	And user go to my messages Outgoing Document
	And user select connected document with subject "Internal Message to Internal Department 111"
	And user select connected document with subject "Incoming Message to Child Department 111"
	Then verify that connected document with subject "Internal Message to Outside Internal Department 111" should not appear in while adding new
	When user clicks on save draft
	Then the connected document with subject "Internal Message to Internal Department 111" should appear in the list
	Then the connected document with subject "Incoming Message to Child Department 111" should appear in the list
	When user deletes the draft
	Given Admin logged in "AdminUserName" "AdminPassword"
	When Admin set system message permissions for user "Can Link with Related Departments Messages and Below" "False" "User"
	And Admin set system message permissions for user "Create Outing Message" "False" "User"
	And Admin set system message permissions for user "View Related Messages" "False" "User"
	And Admin set system message permissions for user "Add Related Message" "False" "User"

Scenario: Message - add connected document - system level - Department mail
	When Admin set department message permissions for user "Create Internal Message" "True" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "View Related Messages" "True" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Add Related Message" "True" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Can Link with Message from Related Departments Messages" "False" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Can Link it with Whole System Messages" "True" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Can Link with Related Departments Messages and Below" "False" "User" "internalDepartmentSameDep"
	And User logs in "UserName" "Password"
	And user go to dept messages Internal Document 
	And user select connected document with subject "Incoming Message to outside child department 111"
	Then the connected document with subject "Incoming Message to outside child department 111" should appear in the list
	Then user deletes the draft
	Given Admin logged in "AdminUserName" "AdminPassword"
	When Admin set department message permissions for user "View Related Messages" "False" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Add Related Message" "False" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Can Link it with Whole System Messages" "False" "User" "internalDepartmentSameDep"
	
Scenario: Message - add connected document - Related departments only - Department mail
	When Admin set department message permissions for user "Create Internal Message" "True" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "View Related Messages" "True" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Add Related Message" "True" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Can Link with Message from Related Departments Messages" "True" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Can Link it with Whole System Messages" "False" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Can Link with Related Departments Messages and Below" "False" "User" "internalDepartmentSameDep"
	When User logs in "UserName" "Password"
	And user go to dept messages Internal Document 
	And user select connected document with subject "Internal Message to Internal Department 111"
	Then the connected document with subject "Internal Message to Internal Department 111" should appear in the list
	Then verify that connected document with subject "Incoming Message to child department 111" should not appear in while adding new
	Then verify that connected document with subject "Incoming Message to outside internal department 111" should not appear in while adding new
	Then user deletes the draft
	Given Admin logged in "AdminUserName" "AdminPassword"
	When Admin set department message permissions for user "View Related Messages" "False" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Add Related Message" "False" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Can Link with Message from Related Departments Messages" "False" "User" "internalDepartmentSameDep"
	
Scenario: Message - add connected document - Related departments and below  - Department mail
	When Admin set department message permissions for user "Create Internal Message" "True" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "View Related Messages" "True" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Add Related Message" "True" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Can Link with Message from Related Departments Messages" "False" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Can Link it with Whole System Messages" "False" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Can Link with Related Departments Messages and Below" "True" "User" "internalDepartmentSameDep"
	And User logs in "UserName" "Password"
	And user go to my messages Outgoing Document
	And user select connected document with subject "Internal Message to Internal Department 111"
	Then the connected document with subject "Internal Message to Internal Department 111" should appear in the list
	When user select connected document with subject "Incoming Message to child department 111"
	Then the connected document with subject "Incoming Message to child department 111" should appear in the list
	Then verify that connected document with subject "Incoming Message to outside internal department 111" should not appear in while adding new
	Then user deletes the draft
	Given Admin logged in "AdminUserName" "AdminPassword"
	When Admin set department message permissions for user "View Related Messages" "False" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Add Related Message" "False" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Can Link with Related Departments Messages and Below" "False" "User" "internalDepartmentSameDep"

Scenario: Message - delete connected document from new message - Personal mail
	And Admin set system message permissions for user "View Related Messages" "True" "User"
	And Admin set system message permissions for user "Add Related Message" "True" "User"
	And Admin set system message permissions for user "Remove Related Message" "True" "User"
	And Admin set system message permissions for user "Open Related Messages" "False" "User"
	When Admin logged in "UserName" "Password"
	And user go to my messages Internal Document 
	And user select connected document with subject "Internal Message with Connected Documents 111"
	And user delete the document with subject "Internal Message with Connected Documents 111" from the list
	
Scenario: Message - open/add/delete connected document from reply messages - Personal mail
	When Admin set system message permissions for user "View Related Messages" "True" "User"
	And Admin set system message permissions for user "Can Reply" "True" "User"
	And Admin set system message permissions for user "View Message Flow and Actions" "True" "User"
	And Admin set system message permissions for user "Add Related Message" "True" "User"
	And Admin set system message permissions for user "Remove Related Message" "True" "User"
	And Admin set system message permissions for user "Open Related Messages" "True" "User"
	And User logs in "UserName" "Password"
	When user opens inbox email with subject "Internal Message with Connected Documents 111"
	And user click on reply button
	And user compose mail "" "any text" 
	And user open connected document with subject "Incoming Message to Child Department 111"
	Then Verify tab "Attributes" on connected document detail
	Then Verify tab "Document Flow" on connected document detail
	Then Verify tab "Actions" on connected document detail
	#Then Verify tab "Connected Documents" on connected document detail ############no such field is available there
	Then verify to detail open "UserMainDepartmentAr"
	Then verify from detail open "arslanadmin"
	When user open connected document with subject "Internal Message to Internal Department 111"

Scenario: Message - delete connected document from new message - department mail
	When Admin set department message permissions for user "Create Internal Message" "True" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "View Related Messages" "True" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Add Related Message" "True" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Can Link with Message from Related Departments Messages" "False" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Can Link it with Whole System Messages" "False" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Can Link with Related Departments Messages and Below" "True" "User" "internalDepartmentSameDep"

Scenario:Message - add connected document - search - Personal mail
	When Admin set department message permissions for user "Create Incoming Message" "True" "User" "internalDepartmentSameDep"
	When Admin set system message permissions for user "Add Related Message" "True" "User"
	And Admin set system message permissions for user "Can Link it with Whole System Messages" "True" "User"
	And User logs in "UserName" "Password" 
	And user go to dept messages Incoming Document 
	And user read connected document reference with subject "Incoming Message to Outside Child Department 111"
