﻿Feature: Message actions

Background: 
	Given Admin logged in "AdminUserName" "AdminPassword"

Scenario Outline:01 message - Add attachement to message - 1 file - personal mail
	
	When user sends an internal message with attachment to "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>"
	Then mail should appear in my message out box "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>"
	Then save reference number from "my" in txt with subject "<subject>"
	Examples:
		| level         | receiverType | to      | subject                      | content                      | userName           | password                   | multipleAttachementNo | multipleAttachmentType |
		| UserMainDepartmentAr | Users        | AdminUserName | Message with attachement 111 | Message with attachement 111 | UserSameDepartment | PasswordUserSameDepartment | 1                    | 1.jpg                    |

Scenario Outline:02 message - Add attachement to message - 1 file - department mail
	When user sends an departmental internal message with attachment to "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"
	Then mail should appear in department message out box "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"
	Then save reference number from "dept" in txt with subject "<subject>"
	Examples:
		| level         | receiverType | to      | subject                      | content                      | userName           | password                   | multipleAttachementNo | multipleAttachmentType | dept                      |
		| UserMainDepartmentAr | Users        | AdminUserName | Message with attachement 111 | Message with attachement 111 | UserSameDepartment | PasswordUserSameDepartment | 1                    | 1.jpg                  | internalDepartmentSameDepAr |

Scenario Outline:03 Message- Add attachement (multiple files)- personal mail
	When user sends an internal message with attachment to "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>"
	Then mail should appear in my message out box "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>"	
	Then save reference number from "my" in txt with subject "<subject>"
	Examples:
		| level         | receiverType | to      | subject                      | content                      | userName           | password                   | multipleAttachementNo | multipleAttachmentType |
		| UserMainDepartmentAr | Users        | AdminUserName | Message with multiple attachement 111 | Message with multiple attachement 111 | UserSameDepartment | PasswordUserSameDepartment | 10                   | 1.jpg                    |

Scenario Outline:04 Message- Add attachement (multiple files)- Department mail
	When user sends an departmental internal message with attachment to "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"
	Then mail should appear in department message out box "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"
	Then save reference number from "dept" in txt with subject "<subject>"
	Examples:
		| level         | receiverType | to      | subject                      | content                      | userName           | password                   | multipleAttachementNo | multipleAttachmentType | dept                      |
		| UserMainDepartmentAr | Users        | AdminUserName | Message with multiple attachement 111 | Message with attachement 111 | UserSameDepartment | PasswordUserSameDepartment | 10                    | 1.jpg                  | internalDepartmentSameDep |

Scenario Outline:05 Message- Add attachement (multiple file types)- personal mail
	When user sends an internal message with attachment to "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>"
	Then mail should appear in my message out box "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>"	
	Then save reference number from "my" in txt with subject "<subject>"
	Examples:
		| level         | receiverType | to      | subject                      | content                      | userName           | password                   | multipleAttachementNo | multipleAttachmentType |
		| UserMainDepartmentAr | Users        | AdminUserName | Message with multiple type attachement 111 | Message with multiple attachement 111 | UserSameDepartment | PasswordUserSameDepartment | 3                   | 1.png,1.mp3,1.avi,1.pdf,1.xlsx |

Scenario Outline:06 Message- Add attachement (multiple file types)- department mail
	When user sends an departmental internal message with attachment to "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"
	Then mail should appear in department message out box "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"
	Then save reference number from "dept" in txt with subject "<subject>"
	Examples:
		| level         | receiverType | to      | subject                      | content                      | userName           | password                   | multipleAttachementNo | multipleAttachmentType		  | dept                      |
		| UserMainDepartmentAr | Users        | AdminUserName | Message with multiple type attachement 111 |Message with multiple attachement 111 | UserSameDepartment | PasswordUserSameDepartment | 3                  | 1.png,1.mp3,1.avi,1.pdf,1.xlsx | internalDepartmentSameDepAr |

Scenario Outline:07 Message- Delete attachement from message - personal mail
	When user attach attachment to internal message "<multipleAttachmentType>" "<multipleAttachementNo>"
	And user delete the attachment "<deleteAttachmentTypes>" "<deleteAttachmentNo>"
	Then attachment should not appear "<multipleAttachmentType>" "<multipleAttachementNo>" "<deleteAttachmentNo>"
	Examples:
		| multipleAttachmentType | multipleAttachementNo | deleteAttachmentNo | deleteAttachmentTypes |
		| 1.jpg                  |           1           |			1         |       1.jpg           |

Scenario Outline:08 Message- Delete multiple attachements from message - department mail
	When user attach attachment to department internal message "<multipleAttachmentType>" "<multipleAttachementNo>"
	And user delete the attachment "<deleteAttachmentTypes>" "<deleteAttachmentNo>"
	Then attachment should not appear "<multipleAttachmentType>" "<multipleAttachementNo>" "<deleteAttachmentNo>"
	Examples:
		| multipleAttachmentType | multipleAttachementNo | deleteAttachmentNo | deleteAttachmentTypes |
		| 1.jpg                  | 3                     |         2          |       1.jpg           |

Scenario Outline:09 Download attachement. - personal mail
	When user download the attachment from inbox mail "<subject>" "<downloadFileName>" "<downloadFileNo>"
	Then the file should appear in downloads "<downloadFileName>" "<downloadFileNo>"

	Examples:
		|				subject					| downloadFileName| downloadFileNo |
		| Message with multiple attachement 111 |      1.jpg      |		1		   |

Scenario Outline:10 Download attachement - department mail
	When user download the attachment from department inbox mail "<subject>" "<downloadFileName>" "<downloadFileNo>"
	Then the file should appear in downloads "<downloadFileName>" "<downloadFileNo>"

	Examples:
		|				subject					| downloadFileName| downloadFileNo |
		| Message with multiple attachement 111 |      1.jpg      |		1		   |

Scenario Outline:11 download all attachment - personal mail
	When user download the attachment from inbox mail "<subject>" "<downloadFileName>" "<downloadFileNo>"
	Then the file should appear in downloads "<downloadFileName>" "<downloadFileNo>"

	Examples:
		|				subject					| downloadFileName| downloadFileNo |
		| Message with multiple attachement 111 |      All        |		1		   |

Scenario Outline:12 download all attachment - department mail
	When user download the attachment from department inbox mail "<subject>" "<downloadFileName>" "<downloadFileNo>"
	Then the file should appear in downloads "<downloadFileName>" "<downloadFileNo>"

	Examples:
		|				subject					| downloadFileName| downloadFileNo |
		| Message with multiple attachement 111 |      All        |		1		   |

Scenario Outline:19 message -  attachement - security level with optional attachment - with attachement -  personal mail
	When user sends an internal message with properties with attachments "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<securitylevel>" "<multipleAttachementNo>" "<multipleAttachmentType>"
	Then save reference number from "my" in txt with subject "<subject>"
	Examples:
		| level         | receiverType | to                 | subject                     | content                      | multipleAttachementNo | multipleAttachmentType | securitylevel |
		| UserMainDepartmentAr | Users        | UserSameDepartment | SecurityLevelOptionalAttach | SecurityLevelOptionalAttacht | 1                     | 1.jpg                  | SecurityLevelOptionalAttach |

Scenario Outline:20 message -  attachement - security level with optional attachment adding -  without attachement -  department mail
	When user sends an deparment internal message with properties with attachments "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<securitylevel>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"
	Then save reference number from "dept" in txt with subject "<subject>"
	Examples:
		| level         | receiverType | to                 | subject                     | content                      | multipleAttachementNo | multipleAttachmentType | securitylevel | dept                      |
		| UserMainDepartmentAr | Structural Hierarchy        | internalDepartmentSameDepAr | SecurityLevelOptionalAttach | SecurityLevelOptionalAttacht | 1                     | 1.jpg                  | SecurityLevelOptionalAttach | internalDepartmentSameDepAr |

Scenario Outline:21 message - attachment - security level with attachment forbidden - personal mail
	When user sends an internal message with properties with attachments "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<securitylevel>" "<multipleAttachementNo>" "<multipleAttachmentType>"
	Then save reference number from "my" in txt with subject "<subject>"
	Examples:
		| level         | receiverType | to                 | subject                     | content                      | multipleAttachementNo | multipleAttachmentType | securitylevel |
		| UserMainDepartmentAr | Users        | UserSameDepartment | SecurityLevelForbidAttach | SecurityLevelForbidAttach | 1                     | 1.jpg                  | SecurityLevelForbidAttach |

Scenario Outline:22 message - attachment - security level with attachment forbidden - department mail
	When user sends an deparment internal message with properties with attachments "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<securitylevel>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"
	Then save reference number from "dept" in txt with subject "<subject>"
	Examples:
		| level         | receiverType | to                 | subject                     | content                      | multipleAttachementNo | multipleAttachmentType | securitylevel | dept                      |
		| UserMainDepartmentAr | Structural Hierarchy        | internalDepartmentSameDepAr | SecurityLevelForbidAttach | SecurityLevelForbidAttach | 1                     | 1.jpg                  | SecurityLevelForbidAttach | internalDepartmentSameDepAr |

Scenario Outline:23 message - attachment - security level with attachment required - with attachement - personal mail
	When user sends an internal message with properties with attachments "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<securitylevel>" "<multipleAttachementNo>" "<multipleAttachmentType>"
	Then save reference number from "my" in txt with subject "<subject>"
	Examples:
		| level         | receiverType | to                 | subject                     | content                      | multipleAttachementNo | multipleAttachmentType | securitylevel |
		| UserMainDepartmentAr | Users        | UserSameDepartment | SecurityLevelRequiredAttach | SecurityLevelRequiredAttach | 1                     | 1.jpg                  | SecurityLevelRequiredAttach |

Scenario Outline:24 message - attachment - security level with attachment required - without attachement - department mail
	When user sends an deparment internal message with properties with attachments "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<securitylevel>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"
	Then save reference number from "dept" in txt with subject "<subject>"
	Examples:
		| level         | receiverType | to                 | subject                     | content                      | multipleAttachementNo | multipleAttachmentType | securitylevel | dept                      |
		| UserMainDepartmentAr | Structural Hierarchy        | internalDepartmentSameDepAr | SecurityLevelRequiredAttach | SecurityLevelRequiredAttach | 1                     | 1.jpg                  | SecurityLevelRequiredAttach | internalDepartmentSameDepAr |

Scenario:25 Message - Connected Documents - Test Case 1
	When user go to my messages Internal Document
	And search "internalDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
	And user compose mail "Internal Message to Internal Department 111" "Internal Message to Internal Department 111"
	And user attach attachments 1 "1.png"
	And user send the email
	Then save reference number from "my" in txt with subject "Internal Message to Internal Department 111"
	When user go to my messages Internal Document
	And search "InternalDepartmentOtherDepAr" "OtherMainDepartmentAr" "Structural Hierarchy"
	And user compose mail "Internal Message to Outside Internal Department 111" "Internal Message to Outside Internal Department 111"
	And user attach attachments 1 "1.png"
	And user send the email
	Then save reference number from "my" in txt with subject "Internal Message to Outside Internal Department 111"
	When user go to my messages Internal Document
	And search "ChildDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
	And user compose mail "Incoming Message to Child Department 111" "Incoming Message to Child Department 111"
	And user attach attachments 1 "1.png"
	And user send the email
	Then save reference number from "my" in txt with subject "Incoming Message to Child Department 111"
	When user go to my messages Internal Document
	And search "ChildDepartmentOtherDepAr" "OtherMainDepartmentAr" "Structural Hierarchy"
	And user compose mail "Incoming Message to Outside Child Department 111" "Incoming Message to Outside Child Department 111"
	And user attach attachments 1 "1.png"
	And user send the email
	Then save reference number from "my" in txt with subject "Incoming Message to Outside Child Department 111"
	When user go to my messages Outgoing Document
	And select the external department "ExternalEntitySameCountry"   
	And select delivery type "Delivery by hand"
	And user set properties "" "" "" "" "" "" "Indirect Export Method"
	And user compose mail "Outgoing Message to Admin Communication department 111" "Outgoing Message to Admin Communication department 111"
	And user attach attachments 1 "1.png"
	And user send the email and click on Cancel button
	Then save reference number from "my" in txt with subject "Outgoing Message to Admin Communication department 111"
	When user go to my messages Internal Document
	And search "User" "UserMainDepartmentAr" "Users"
	And search "internalDepartmentSameDepAr" "UserMainDepartmentAr" "Structural Hierarchy"
	And user compose mail "Internal Message with Connected Documents 111" "Internal Message with Connected Documents 111"
	And user select connected document with subject "Internal Message to Internal Department 111"
	And user select connected document with subject "Incoming Message to Child Department 111"
	And user select connected document with subject "Outgoing Message to Admin Communication department 111"
	And user send the email
	Then save reference number from "my" in txt with subject "Internal Message with Connected Documents 111"
	
Scenario:26 Message - View connected document - with permission -  personal mail
	When Admin set system message permissions for user "View Related Messages" "True" "User"
	And Admin set system message permissions for user "Add Related Message" "False" "User"
	And Admin set system message permissions for user "Remove Related Messages" "False" "User"
	And Admin set system message permissions for user "Open Related Messages" "False" "User"
	And User logs in "UserName" "Password"
	And user opens inbox email with subject "Internal Message with Connected Documents 111"
	Then the visibilty of tab "Connected Document" should be "True" on connected doc tab
	Then the visibilty of button "Add" should be "False" on connected doc tab
	And the visibilty of button "Delete" should be "False" on connected doc tab
	#isske tab visibiility main error hai k connected tab ka elemanet nai milta isko
Scenario:27 Message - View connected document - without permission -  personal mail
	When Admin set system message permissions for user "View Related Messages" "False" "User"
	And User logs in "UserName" "Password"
	And user opens inbox email with subject "Internal Message with Connected Documents 111"
	Then the visibilty of tab "Connected Document" should be "False" on connected doc tab

Scenario:28 Message - View connected document - with permission -  department mail
	When Admin set department message permissions for user "View Related Messages" "True" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Add Related Message" "False" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Remove Related Messages" "False" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Open Related Messages" "False" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Can Reply" "True" "User" "internalDepartmentSameDep"
	And User logs in "UserName" "Password"
	And user opens department "internalDepartmentSameDep" mail with subject "Internal Message with Connected Documents 111" ""
	And user click on reply button
	Then the visibilty of tab "Connected Document" should be "True" on connected doc tab
	Then the visibilty of button "Add" should be "False" on connected doc tab
	And the visibilty of button "Delete" should be "False" on connected doc tab
	When user deletes the draft

Scenario:29 Message - View connected document - without permission -  
	When Admin set department message permissions for user "View Related Messages" "False" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Can Reply" "False" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Can Forward" "True" "User" "internalDepartmentSameDep"
	And User logs in "UserName" "Password"
	And user opens department "internalDepartmentSameDep" mail with subject "Internal Message with Connected Documents 111" ""
	And user click on forward button
	Then the visibilty of tab "Connected Document" should be "False" on connected doc tab
	When user deletes the draft

Scenario:30 Message - add connected document - with permission -  personal mail
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

Scenario:31 Message - add/delete connected document - no permission -  personal mail
	When Admin set system message permissions for user "Create Internal Message" "True" "User"
	When Admin set system message permissions for user "View Related Messages" "True" "User"
	And Admin set system message permissions for user "Add Related Message" "False" "User"
	And Admin set system message permissions for user "Remove Related Messages" "False" "User"
	And Admin set system message permissions for user "Open Related Messages" "True" "User"
	And User logs in "UserName" "Password"
	And user go to my messages Internal Document
	Then the visibilty of button "Add" should be "False" on connected doc tab
	And the visibilty of button "Delete" should be "False" on connected doc tab

Scenario:32 Message Permission - add connected document - with permission - department mail
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

Scenario:33 Message Permission - add/delete connected document - no permission - department mail
	When Admin set department message permissions for user "Create Internal Message" "True" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "View Related Messages" "True" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Add Related Message" "False" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Remove Related Messages" "False" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Open Related Messages" "True" "User" "internalDepartmentSameDep"
	And User logs in "UserName" "Password"
	And user go to dept messages Internal Document
	Then the visibilty of button "Add" should be "False" on connected doc tab
	And the visibilty of button "Delete" should be "False" on connected doc tab

Scenario:34 Message - add connected document - system level - with permission -  personal mail
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

Scenario:35 Message - add connected document - Related departments only - with permission -  personal mail
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

Scenario:36 Message - add connected document - Related departments and below - with permission -  personal mail
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

Scenario:37 Message - add connected document - system level - Department mail
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
	
Scenario:38 Message - add connected document - Related departments only - Department mail
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
	
Scenario:39 Message - add connected document - Related departments and below  - Department mail
	When Admin set system message permissions for user "Create Outing Message" "True" "User"
	When Admin set system message permissions for user "View Related Messages" "True" "User"
	When Admin set system message permissions for user "Add Related Message" "True" "User"
	And Admin set system message permissions for user "Can Link with Message from Related Departments Messages" "False" "User"
	And Admin set system message permissions for user "Can Link it with Whole System Messages" "False" "User"
	And Admin set system message permissions for user "Can Link with Related Departments Messages and Below" "True" "User"
	And User logs in "UserName" "Password"
	And user go to my messages Outgoing Document
	And user select connected document with subject "Internal Message to Internal Department 111"
	Then the connected document with subject "Internal Message to Internal Department 111" should appear in the list
	When user select connected document with subject "Incoming Message to child department 111"
	Then the connected document with subject "Incoming Message to child department 111" should appear in the list
	Then verify that connected document with subject "Incoming Message to outside internal department 111" should not appear in while adding new
	Then user deletes the draft
	Given Admin logged in "AdminUserName" "AdminPassword"
	When Admin set system message permissions for user "View Related Messages" "False" "User" "internalDepartmentSameDep"
	When Admin set system message permissions for user "Add Related Message" "False" "User" "internalDepartmentSameDep"
	And Admin set system message permissions for user "Can Link with Related Departments Messages and Below" "False" "User" "internalDepartmentSameDep"

Scenario:40 Message - delete connected document from new message - Personal mail
	When Admin set system message permissions for user "Create Internal Message" "True" "User"
	And Admin set system message permissions for user "View Related Messages" "True" "User"
	And Admin set system message permissions for user "Add Related Message" "True" "User"
	And Admin set system message permissions for user "Remove Related Message" "True" "User"
	And Admin set system message permissions for user "Open Related Messages" "False" "User"
	When Admin logged in "UserName" "Password"
	And user go to my messages Internal Document 
	And user select connected document with subject "Internal Message with Connected Documents 111"
	And user delete the document with subject "Internal Message with Connected Documents 111" from the list
	
Scenario:41 Message - open/add/delete connected document from reply messages - Personal mail
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
	Then verify from detail open "AdminUserName"
	When user open connected document with subject "Internal Message to Internal Department 111"

Scenario:42 Message - delete connected document from new message - department mail
	When Admin set system message permissions for user "Remove Related Messages" "True" "User"
	And User logs in "UserName" "Password"
	And user go to dept messages Internal Document
	And user select connected document with subject "Internal Message with Connected Documents 111"
	And user delete the document with subject "Internal Message with Connected Documents 111" from the list

Scenario:44 Message - add connected document - search - Personal mail
	When Admin set department message permissions for user "Create Incoming Message" "True" "User" "internalDepartmentSameDep"
	When Admin set system message permissions for user "Add Related Message" "True" "User"
	And Admin set system message permissions for user "Can Link it with Whole System Messages" "True" "User"
	And User logs in "UserName" "Password" 
	And user go to dept messages Incoming Document 
	And user read connected document reference with subject "Incoming Message to outside child department 111" add 100
	And user select document type as "" with subject "Incoming Message to outside child department 111" "True"
	And user select document type as "Outgoing Document" with subject "Incoming Message to outside child department 111" "False"
	And user select document type as "Internal Document" with subject "Incoming Message to outside child department 111" "True"
	Then the connected document with subject "Incoming Message to outside child department 111" should appear in the list

Scenario:45 Message - add connected document - search - Department mail
	When Admin set department message permissions for user "Create Outing Message" "True" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "View Related Messages" "True" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Add Related Message" "True" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Can Link it with Whole System Messages" "True" "User" "internalDepartmentSameDep"
	When User logs in "UserName" "Password" 
	And user go to dept messages Outgoing Document
	And user read connected document reference with subject "Outgoing Message to Admin Communication department 111" add -1
	And user select document type as "" with subject "Outgoing Message to Admin Communication department 111" "True"
	And user select document type as "Incoming Document" with subject "Outgoing Message to Admin Communication department 111" "False"
	And user select document type as "Outgoing Document" with subject "Outgoing Message to Admin Communication department 111" "True"
	And user select delivery type as "DeliveryType2Ar" with subject "Outgoing Message to Admin Communication department 111" "False"
	And user select delivery type as "DeliveryTypeAr" with subject "Outgoing Message to Admin Communication department 111" "True"
	Then the connected document with subject "Outgoing Message to Admin Communication department 111" should appear in the list

Scenario:46 Message - add connected document - Cancel button - Personal mail
	When Admin set system message permissions for user "Create Internal Message" "True" "User"
	When Admin set system message permissions for user "View Related Messages" "True" "User"
	When Admin set system message permissions for user "Add Related Message" "True" "User"
	And User logs in "UserName" "Password"
	And user go to my messages Internal Document
	And user select connected document without saving it with subject "Internal Message with Connected Documents 111" "False"
	Then the connected document with subject "Internal Message with Connected Documents 111" should not appear in the list
	When Admin logged in "AdminUserName" "AdminPassword"
	When Admin set system message permissions for user "View Related Messages" "False" "User"
	When Admin set system message permissions for user "Add Related Message" "False" "User"
	
Scenario:47 Message - add connected document - Cancel button - department mail
	When Admin set department message permissions for user "Add Related Message" "True" "User" "internalDepartmentSameDep"
	And User logs in "UserName" "Password" 
	And user go to dept messages Internal Document
	And user select connected document without saving it with subject "Internal Message with Connected Documents 111" "False"
	Then the connected document with subject "Internal Message with Connected Documents 111" should not appear in the list
	When Admin logged in "AdminUserName" "AdminPassword"
	When Admin set department message permissions for user "Add Related Message" "False" "User" "internalDepartmentSameDep"
	
Scenario:48 Message - connected Person - Permission view and add - with permission - Personal mail
	When Admin set system message permissions for user "View Related Persons" "True" "User"
	When Admin set system message permissions for user "Add Related Person" "True" "User"
	And User logs in "UserName" "Password"
	And user go to my messages Incomming Document
	And user send incoming message to "UserMainDepartmentAr" "Users" "User"
	And user compose mail "Incoming Message with Connected Person to User 111" "Incoming Message with Connected Person to User 111"	
	And select the external department "ExternalEntitySameCountry"
	And user enters incomming message no "+123456789" and incomming message Gregorian date "now"
	And user set properties "" "" "" "" "" "now" ""
	And user set connected person "Person Name1" "PersonEmail1@mail.com" "12345" "12345" "Riyadh" "now" "هوية" "True"
	And user send the email and click on Cancel button
	Then save reference number from "my" in txt with subject "Incoming Message with Connected Person to User 111"
	Then mail should appear in the inbox "User" "Incoming Message with Connected Person to User 111" "Incoming Message with Connected Person to User 111"	
	When Admin logged in "AdminUserName" "AdminPassword"
	When Admin set system message permissions for user "View Related Persons" "False" "User"
	When Admin set system message permissions for user "Add Related Person" "False" "User"
	
Scenario:50 Message - connected Person - Permission view only - with permission - Personal mail
	When Admin set system message permissions for user "View Related Persons" "True" "User"
	When Admin set system message permissions for user "Add Related Person" "False" "User"
	And User logs in "UserName" "Password"
	And user go to my messages Incomming Document
	Then the visibilty of button "Add" should be "False" on connected person tab
	######### Delete button is always visible! 
	#And the visibilty of button "Delete" should be "False" on connected person tab
	And the visibilty of button "Edit" should be "False" on connected person tab
	And user deletes the draft
	When Admin logged in "AdminUserName" "AdminPassword"
	When Admin set system message permissions for user "View Related Persons" "False" "User"	
	
Scenario:52 Message - Adding connected Person - Invalid / incomplete data - Personal mail
	When Admin set system message permissions for user "View Related Persons" "True" "User"
	When Admin set system message permissions for user "Add Related Person" "True" "User"
	And User logs in "UserName" "Password"
	And user go to my messages Incomming Document
	And user set connected person "Person Name1" "PersonEmail1mail.com" "12345" "12345" "Riyadh" "now" "هوية" "True"
	And user set connected person "Person Name1" "PersonEmail1@mail.com" "abcd" "12345" "Riyadh" "now" "هوية" "True"
	And user set connected person "Person Name1" "PersonEmail1@mail.com" "12345" "abcd" "Riyadh" "now" "هوية" "True"
	And user set connected person "" "PersonEmail1@mail.com" "12345" "12345" "Riyadh" "now" "هوية" "True"
	And user set connected person "Person Name1" "PersonEmail1@mail.com" "" "12345" "Riyadh" "now" "هوية" "True"
	And user set connected person "Person Name1" "PersonEmail1@mail.com" "12345" "" "Riyadh" "now" "هوية" "True"
	And user set connected person "Person Name1" "PersonEmail1@mail.com" "12345" "12345" "Riyadh" "now" "" "True"
	And user set connected person "Person Name1" "" "12345" "12345" "" "" "هوية" "True"
	Then the connected person with name "Person Name1" should appear in the list
	When user set connected person "Person Name1" "PersonEmail1@mail.com" "12345" "12345" "Riyadh" "now" "هوية" "False"
	Then user deletes the draft
	Given Admin logged in "AdminUserName" "AdminPassword"
	When Admin set system message permissions for user "View Related Persons" "False" "User"
	And Admin set system message permissions for user "Add Related Person" "False" "User"
	
	Scenario:53 Message - Adding connected Person - Invalid / incomplete data - Department mail
	When Admin set department message permissions for user "View Related Persons" "True" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Add Related Persons" "True" "User" "internalDepartmentSameDep"
	And User logs in "UserName" "Password"
	And user go to dept messages Incoming Document
	When user set connected person "Person Name1" "PersonEmail1mail.com" "12345" "12345" "Riyadh" "now" "هوية" "True"
	Then Error is shown as "Invalid Email Address" "Email"
	When user set connected person "Person Name1" "PersonEmail1@mail.com" "abcd" "12345" "Riyadh" "now" "هوية" "True"
	Then Error is shown as "Invalid number format" "Mobile"
	When user set connected person "Person Name1" "PersonEmail1@mail.com" "12345" "abcd" "Riyadh" "now" "هوية" "True"
	Then Error is shown as "Invalid number format" "IDNumber"
	When user set connected person "" "PersonEmail1@mail.com" "12345" "12345" "Riyadh" "now" "هوية" "True"
	Then Error is shown as "Required Field" "Name"
	When user set connected person "Person Name1" "PersonEmail1@mail.com" "" "12345" "Riyadh" "now" "هوية" "True"
	Then Error is shown as "Required Field" "Mobile"
	When user set connected person "Person Name1" "PersonEmail1@mail.com" "12345" "" "Riyadh" "now" "هوية" "True"
	Then Error is shown as "Required Field" "IDNumber"
	When user set connected person "Person Name1" "PersonEmail1@mail.com" "12345" "12345" "Riyadh" "now" "" "True"
	Then Error is shown as "Required Field" "ID"
	When user set connected person "Person Name1" "PersonEmail1@mail.com" "12345" "12345" "" "" "هوية" "True"
	Then the connected person with name "Person Name1" should appear in the list
	###check error for adding person with same name and id number
	Then user deletes the draft
	Given Admin logged in "AdminUserName" "AdminPassword"
	When Admin set department message permissions for user "View Related Persons" "False" "User" "internalDepartmentSameDep"
	When Admin set department message permissions for user "Add Related Persons" "False" "User" "internalDepartmentSameDep"

Scenario:54 Message - connected Person - no permission - Personal mail
	When Admin set system message permissions for user "View Related Persons" "False" "User"
	When Admin set system message permissions for user "Add Related Person" "False" "User"
	And User logs in "UserName" "Password"
	And user go to my messages Incomming Document
	Then the visibilty of tab "Connected Persons" should be "False" on connected doc tab
	Then user deletes the draft
	Given Admin logged in "adminUserName" "adminPassword"
	When Admin set system message permissions for user "View Related Persons" "True" "User"
	When Admin set system message permissions for user "Add Related Person" "True" "User"
	
Scenario:56 Message - Connected Person - Edit/Delete - Personal mail
	When Admin set system message permissions for user "View Related Persons" "True" "User"
	When Admin set system message permissions for user "Add Related Person" "True" "User"
	And User logs in "UserName" "Password"
	And user go to my messages Incomming Document
	When user set connected person "Person Name1" "PersonEmail1@mail.com" "12345" "12345" "Riyadh" "now" "هوية" "True"
	And user update person with name "Person Name1" from the list to "Person Name2" "PersonEmail2@mail.com" "12345" "12345" "Riyadh" "yesterday" "هوية" "True"
	Then the connected person with name "Person Name2" should appear in the list
	When user delete the person with name "Person Name2" from the list
	Then verify the connected person with name "Person Name2" should not appear in the list
	And user deletes the draft
	Given Admin logged in "AdminUserName" "AdminPassword"
	When Admin set system message permissions for user "View Related Persons" "False" "User"
	When Admin set system message permissions for user "Add Related Person" "False" "User"
	
Scenario: 58 Message - Connected Persons - Add Connected Person - Cancel - Personal mail
	When Admin set system message permissions for user "View Related Persons" "True" "User"
	When Admin set system message permissions for user "Add Related Person" "True" "User"
	And User logs in "UserName" "Password"
	And user go to my messages Incomming Document
	And user send incoming message to "UserMainDepartmentAr" "Users" "User"
	When user set connected person "Person Name1" "PersonEmail1@mail.com" "12345" "12345" "Riyadh" "now" "هوية" "False"
	Then verify the connected person with name "Person Name1" should not appear in the list
	And user deletes the draft
	Given Admin logged in "AdminUserName" "AdminPassword"
	When Admin set system message permissions for user "View Related Persons" "False" "User"
	When Admin set system message permissions for user "Add Related Person" "False" "User"
	
Scenario: 59 Message - Connected Persons - Add Connected Person - Cancel - Department mail
	When Admin set department message permissions for user "View Related Persons" "True" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Add Related Person" "True" "User" "internalDepartmentSameDep"
	And User logs in "UserName" "Password"
	And user go to dept messages Incoming Document
	When user set connected person "Person Name1" "PersonEmail1@mail.com" "12345" "12345" "Riyadh" "now" "هوية" "False"
	Then verify the connected person with name "Person Name1" should not appear in the list
	And user deletes the draft
	Given Admin logged in "AdminUserName" "AdminPassword"
	When Admin set department message permissions for user "View Related Persons" "False" "User" "internalDepartmentSameDep"
	And Admin set department message permissions for user "Add Related Person" "False" "User" "internalDepartmentSameDep"
	