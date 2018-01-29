Feature: Permissions of user


  Scenario Outline: User permissions on system
    Given Admin logged in "<adminUserName>" "<adminPassword>"
    When Admin set system message permissions for user "<permissionName>" "<permissionValue>" "<user>"
    And User logs in "<userName>" "<password>"
    Then "<button>" visibility should be on My Messages inbox "<permissionValue>"

    Examples:
      | adminUserName | adminPassword | permissionName | permissionValue | user | userName | password | button |
      | AdminUserName | AdminPassword | Create Internal Message | True | User | UserName | Password | Internal Document |
      | AdminUserName | AdminPassword | Create Internal Message | False | User | UserName | Password | Internal Document |
	  | AdminUserName | AdminPassword | Create Encrypted Message | True | User | UserName | Password | Encrypted internal message |
	  | AdminUserName | AdminPassword | Create Encrypted Message | False | User | UserName | Password | Encrypted internal message  |
	  | AdminUserName | AdminPassword | Create Incoming Message | True | User | UserName | Password | Incoming Document  |
	  | AdminUserName | AdminPassword | Create Incoming Message | False | User | UserName | Password | Incoming Document  |
	  | AdminUserName | AdminPassword | Create Outing Message | True | User | UserName | Password | Outgoing Document  |
	  | AdminUserName | AdminPassword | Create Outing Message | False | User | UserName | Password | Outgoing Document  |

  Scenario Outline: User permissions on Department
    Given Admin logged in "<adminUserName>" "<adminPassword>"
    When Admin set department message permissions for user "<permissionName>" "<permissionValue>" "<user>" "<dept>"
    And User logs in "<userName>" "<password>"
    Then "<button>" visibility should be "<permissionValue>" on Department Messages inbox

    Examples:
      | adminUserName | adminPassword | permissionName			| permissionValue | user   | dept					   | userName | password | button			 |
      | AdminUserName | AdminPassword | Create Internal Message | True			  | User | internalDepartmentSameDep | UserName | Password | Internal Document |
      | AdminUserName | AdminPassword | Create Internal Message | False			  | User | internalDepartmentSameDep | UserName | Password | Internal Document |
	  | AdminUserName | AdminPassword | Create Incoming Message | True			  | User | internalDepartmentSameDep | UserName | Password | Incoming Document |
	  | AdminUserName | AdminPassword | Create Incoming Message | False			  | User | internalDepartmentSameDep | UserName | Password | Incoming Document |
	  | AdminUserName | AdminPassword | Create Outing Message	| True			  | User | internalDepartmentSameDep | UserName | Password | Outgoing Document |
	  | AdminUserName | AdminPassword | Create Outing Message	| False			  | User | internalDepartmentSameDep | UserName | Password | Outgoing Document |