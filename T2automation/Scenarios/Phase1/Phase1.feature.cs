﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace T2automation.Scenarios.Phase1
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Phase 1")]
    public partial class Phase1Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Phase1.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Phase 1", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 3
#line 4
 testRunner.Given("Admin logged in \"AdminUserName\" \"AdminPassword\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("ph 1 Message Actions - Deleting Message")]
        public virtual void Ph1MessageActions_DeletingMessage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ph 1 Message Actions - Deleting Message", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 7
 testRunner.When("Admin set system message permissions for user \"Delete Messages from Inbox\" \"True\"" +
                    " \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 8
 testRunner.And("Admin set system message permissions for user \"Rollback Messages from Deleted Ite" +
                    "ms\" \"True\" \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.And("Admin set department message permissions for user \"Delete Messages from Inbox\" \"T" +
                    "rue\" \"User\" \"internalDepartmentSameDep\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("Admin set department message permissions for user \"Rollback Messages from Deleted" +
                    " Items\" \"True\" \"User\" \"internalDepartmentSameDep\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.When("user go to my messages Internal Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.And("search \"internalDepartmentSameDepAr\" \"UserMainDepartmentAr\" \"Structural Hierarchy" +
                    "\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.And("user compose mail \"Internal message for deletion 111\" \"Internal message for delet" +
                    "ion 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("user attach attachments 1 \"1.pdf\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And("user send the email", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.Then("save reference number from \"my\" in txt with subject \"Internal message for deletio" +
                    "n 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
 testRunner.When("user go to dept \"InternalDepartmentSameDepartment2Ar\" messages Internal Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.And("search \"User\" \"UserMainDepartmentAr\" \"Users\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("user compose mail \"Internal message for deletion 222\" \"Internal message for delet" +
                    "ion 222\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.And("user attach attachments 1 \"1.pdf\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("user select connected document with subject \"Incoming Message to Outside Child De" +
                    "partment 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("user send the email", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.Then("save reference number from \"deptAcc\" in txt with subject \"Internal message for de" +
                    "letion 222\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
 testRunner.When("user go to dept \"InternalDepartmentSameDepartment2Ar\" messages Incoming Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
 testRunner.And("search \"User\" \"UserMainDepartmentAr\" \"Users\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("user compose mail \"Incoming message for deletion 333\" \"Incoming message for delet" +
                    "ion 333\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And("select the external department \"ExternalEntitySameCountry\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.And("user enters incomming message no \"+123456789\" and incomming message Gregorian dat" +
                    "e \"now\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("user set connected person \"Person Name1\" \"PersonEmail1@mail.com\" \"12345\" \"12345\" " +
                    "\"Riyadh\" \"now\" \"هوية\" \"True\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("user send the email and click on Cancel button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.Then("save reference number from \"deptAcc\" in txt with subject \"Incoming message for de" +
                    "letion 333\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 32
 testRunner.When("User logs in \"UserName\" \"Password\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
 testRunner.And("user opens department \"internalDepartmentSameDep\" mail with subject \"Internal mes" +
                    "sage for deletion 111\" \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.Then("user deletes the mail", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
 testRunner.Then("mail with subject \"Internal message for deletion 111\" should not appear in \"dept\"" +
                    " inbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 36
 testRunner.When("user open \"dept\" deleted message with suject \"Internal message for deletion 111\" " +
                    "and click on button \"Rollback\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.Then("mail with subject \"Internal message for deletion 111\" should not appear in \"dept\"" +
                    " deleted message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
 testRunner.Then("mail should appear in dept inbox \"internalDepartmentSameDepAr\" \"Internal message " +
                    "for deletion 111\" \"Internal message for deletion 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
 testRunner.When("user opens inbox email with subject \"Internal message for deletion 222\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
 testRunner.Then("user deletes the mail", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
 testRunner.Then("mail with subject \"Internal message for deletion 222\" should not appear in \"my\" i" +
                    "nbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
 testRunner.When("user opens inbox email with subject \"Incoming message for deletion 333\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
 testRunner.Then("user deletes the mail", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
 testRunner.Then("mail with subject \"Incoming message for deletion 333\" should not appear in \"my\" i" +
                    "nbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 45
 testRunner.When("user open \"my\" deleted message with suject \"Internal message for deletion 222\" an" +
                    "d click on button \"Rollback\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
 testRunner.Then("mail with subject \"Internal message for deletion 222\" should not appear in \"my\" d" +
                    "eleted message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
 testRunner.Then("mail should appear in the inbox \"User\" \"Internal message for deletion 222\" \"Inter" +
                    "nal message for deletion 222\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 48
 testRunner.When("user open \"my\" deleted message with suject \"Incoming message for deletion 333\" an" +
                    "d click on button \"Rollback\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 49
 testRunner.Then("mail with subject \"Incoming message for deletion 333\" should not appear in \"my\" d" +
                    "eleted message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
 testRunner.Then("mail should appear in the inbox \"User\" \"Incoming message for deletion 333\" \"Incom" +
                    "ing message for deletion 333\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
 testRunner.When("Admin logged in \"AdminUserName\" \"AdminPassword\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
 testRunner.When("Admin set system message permissions for user \"Delete Messages from Inbox\" \"False" +
                    "\" \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
 testRunner.And("Admin set system message permissions for user \"Rollback Messages from Deleted Ite" +
                    "ms\" \"False\" \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.And("Admin set department message permissions for user \"Delete Messages from Inbox\" \"F" +
                    "alse\" \"User\" \"internalDepartmentSameDep\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And("Admin set department message permissions for user \"Rollback Messages from Deleted" +
                    " Items\" \"False\" \"User\" \"internalDepartmentSameDep\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("ph 2 Message Actions - Archiving Message")]
        public virtual void Ph2MessageActions_ArchivingMessage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ph 2 Message Actions - Archiving Message", ((string[])(null)));
#line 57
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 58
 testRunner.When("Admin set system message permissions for user \"Archive Messages\" \"True\" \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 59
 testRunner.And("Admin set system message permissions for user \"Rollback from Archive\" \"True\" \"Use" +
                    "r\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And("Admin set department message permissions for user \"Archive Messages\" \"True\" \"User" +
                    "\" \"internalDepartmentSameDep\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And("Admin set department message permissions for user \"Rollback from Archive\" \"True\" " +
                    "\"User\" \"internalDepartmentSameDep\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And("Admin set department message permissions for user \"Archive Messages\" \"True\" \"User" +
                    "\" \"CommDepSameDepEn\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.And("Admin set department message permissions for user \"Rollback from Archive\" \"True\" " +
                    "\"User\" \"CommDepSameDepEn\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.When("user go to my messages Internal Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
 testRunner.And("search \"User\" \"UserMainDepartmentAr\" \"Users\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.And("user compose mail \"Internal message for archiving 111\" \"Internal message for arch" +
                    "iving 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And("user attach attachments 1 \"1.pdf\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.And("user select connected document with subject \"Internal Message to Internal Departm" +
                    "ent 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.And("user send the email", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.Then("save reference number from \"my\" in txt with subject \"Internal message for archivi" +
                    "ng 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 71
 testRunner.When("user go to \"my\" encrypted message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 72
 testRunner.And("search \"internalDepartmentSameDepAr\" \"UserMainDepartmentAr\" \"Structural Hierarchy" +
                    "\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.And("user compose mail \"Encrypted message for archiving 222\" \"Encrypted message for ar" +
                    "chiving 222\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.And("user set properties \"Paper\" \"12345\" \"Parcels\" \"\" \"\" \"\" \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And("user attach attachments 1 \"1.xlsx\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And("user select connected document with subject \"Internal Message to Internal Departm" +
                    "ent 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.And("user send the email", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.Then("save reference number from \"my\" in txt with subject \"Encrypted message for archiv" +
                    "ing 222\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 79
 testRunner.When("user go to dept \"InternalDepartmentSameDepartment2Ar\" messages Incoming Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 80
 testRunner.And("search \"User\" \"UserMainDepartmentAr\" \"Users\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.And("user set properties \"\" \"\" \"\" \"12345\" \"now\" \"now\" \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.And("select the external department \"ExternalEntitySameCountry\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
 testRunner.And("user compose mail \"Incoming message for archiving 333\" \"Incoming message for arch" +
                    "iving 333\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
 testRunner.And("user attach attachments 1 \"1.pdf\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.And("user select connected document with subject \"Internal Message to Internal Departm" +
                    "ent 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
 testRunner.When("user set connected person \"PersonName1\" \"PersonEmail1@mail.com\" \"12345\" \"12345\" \"" +
                    "Riyadh\" \"now\" \"هوية\" \"True\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 88
 testRunner.And("user send the email and click on Cancel button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.Then("save reference number from \"deptAcc\" in txt with subject \"Incoming message for ar" +
                    "chiving 333\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 90
 testRunner.When("user go to dept \"InternalDepartmentSameDepartment2Ar\" messages Outgoing Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 91
 testRunner.And("user click CC button \"UserMainDepartmentAr\" \"Structural Hierarchy\" \"internalDepar" +
                    "tmentSameDepAr\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.And("user compose mail \"Outgoing message for archiving 444\" \"Outgoing message for arch" +
                    "iving 444\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.And("user set properties \"Paper\" \"12345\" \"Parcels\" \"\" \"\" \"\" \"Indirect Export Method\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.And("select the external department \"ExternalEntitySameCountry\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.And("user select connected document with subject \"Internal Message to Internal Departm" +
                    "ent 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.And("user send the email and click on Cancel button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.Then("save reference number from \"deptAcc\" in txt with subject \"Outgoing message for ar" +
                    "chiving 444\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 98
 testRunner.When("User logs in \"UserName\" \"Password\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 99
 testRunner.And("user opens inbox email with subject \"Internal message for archiving 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.Then("user click on \"my,Archive\" button and set \"Comment for archive\" \"1.png\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 101
 testRunner.And("mail with subject \"Internal message for archiving 111\" should not appear in \"my\" " +
                    "inbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
 testRunner.When("user opens inbox email with subject \"Incoming message for archiving 333\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 103
 testRunner.Then("user click on \"my,Archive\" button and set \"Comment for archive\" \"1.png\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 104
 testRunner.And("mail with subject \"Incoming message for archiving 333\" should not appear in \"my\" " +
                    "inbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
 testRunner.When("user open \"my\" archive message with suject \"Internal message for archiving 111\" a" +
                    "nd click on button \"Rollback\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 106
 testRunner.Then("mail with subject \"Internal message for archiving 111\" should not appear in \"my\" " +
                    "archive message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 107
 testRunner.When("user open \"my\" archive message with suject \"Incoming message for archiving 333\" a" +
                    "nd click on button \"Rollback\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 108
 testRunner.Then("mail with subject \"Incoming message for archiving 333\" should not appear in \"my\" " +
                    "archive message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 109
 testRunner.Then("mail should appear in the inbox \"User\" \"Internal message for archiving 111\" \"Inte" +
                    "rnal message for archiving 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 110
 testRunner.Then("mail should appear in the inbox \"User\" \"Incoming message for archiving 333\" \"Inco" +
                    "ming message for archiving 333\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 111
 testRunner.When("user opens department \"internalDepartmentSameDep\" mail with subject \"Encrypted me" +
                    "ssage for archiving 222\" \"P@ssw0rd!@#\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 112
 testRunner.Then("user click on \"dept,Archive\" button and set \"Comment for archive\" \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 113
 testRunner.And("mail with subject \"Encrypted message for archiving 222\" should not appear in \"dep" +
                    "t\" inbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
 testRunner.When("user opens department \"internalDepartmentSameDep\" mail with subject \"Outgoing mes" +
                    "sage for archiving 444\" \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 115
 testRunner.Then("user click on \"deptOutgoing,Archive\" button and set \"Comment for archive\" \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 116
 testRunner.And("mail with subject \"Outgoing message for archiving 444\" should not appear in \"dept" +
                    "\" inbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
 testRunner.When("user open \"dept\" archive message with suject \"Encrypted message for archiving 222" +
                    "\" and click on button \"Rollback\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 118
 testRunner.And("user open \"dept\" archive message with suject \"Outgoing message for archiving 444\"" +
                    " and click on button \"Rollback\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
 testRunner.Then("mail with subject \"Encrypted message for archiving 222\" should not appear in \"dep" +
                    "t\" archive message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 120
 testRunner.And("mail with subject \"Outgoing message for archiving 444\" should not appear in \"dept" +
                    "\" archive message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
 testRunner.Then("mail should appear in dept inbox \"internalDepartmentSameDepAr\" \"Encrypted message" +
                    " for archiving 222\" \"Encrypted message for archiving 222\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 122
 testRunner.And("mail should appear in dept inbox \"CommDepSameDep\" \"Outgoing message for archiving" +
                    " 444\" \"Outgoing message for archiving 444\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 131
 testRunner.When("Admin logged in \"AdminUserName\" \"AdminPassword\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 132
 testRunner.When("Admin set system message permissions for user \"Archive Messages\" \"False\" \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 133
 testRunner.And("Admin set system message permissions for user \"Rollback from Archive\" \"False\" \"Us" +
                    "er\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 134
 testRunner.And("Admin set department message permissions for user \"Archive Messages\" \"False\" \"Use" +
                    "r\" \"internalDepartmentSameDepAr\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 135
 testRunner.And("Admin set department message permissions for user \"Rollback from Archive\" \"False\"" +
                    " \"User\" \"internalDepartmentSameDepAr\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 136
 testRunner.And("Admin set department message permissions for user \"Archive Messages\" \"False\" \"Use" +
                    "r\" \"CommDepSameDep\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 137
 testRunner.And("Admin set department message permissions for user \"Rollback from Archive\" \"False\"" +
                    " \"User\" \"CommDepSameDep\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("ph 3 Exporting Message -1")]
        public virtual void Ph3ExportingMessage_1()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ph 3 Exporting Message -1", ((string[])(null)));
#line 140
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 150
 testRunner.When("user opens department \"internalDepartmentSameDep\" mail with subject \"Incoming mes" +
                    "sage for indirect export 111\" \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 151
 testRunner.And("click on export button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 152
 testRunner.And("user compose mail \"Incoming message for indirect export 666\" \"Incoming message fo" +
                    "r indirect export 666\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
 testRunner.And("select the external department \"ExternalEntitySameCountry\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 154
 testRunner.And("select the external cc department \"ExternalEntitySameCountry2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("ph 4 Exporting Message - 2")]
        public virtual void Ph4ExportingMessage_2()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ph 4 Exporting Message - 2", ((string[])(null)));
#line 156
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 157
 testRunner.When("user go to dept messages Internal Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 158
 testRunner.And("search \"Admin\" \"UserMainDepartmentAr\" \"Users\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 159
 testRunner.And("user compose mail \"Internal message for direct export 222\" \"Internal message for " +
                    "direct export 222\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 160
 testRunner.And("user attach attachments 1 \"1.pdf\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 161
 testRunner.And("user select and save the reference no \"CD2\" of connected document with subject \"I" +
                    "nternal Message to Internal Department 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 162
 testRunner.And("user send the email", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 163
 testRunner.Then("save reference number from \"dept\" in txt with subject \"Internal message for direc" +
                    "t export 222\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 164
 testRunner.When("user opens inbox email with subject \"Internal message for direct export 222\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 165
 testRunner.And("click on export button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 166
 testRunner.And("user compose mail \"Internal message for direct export 888\" \"Internal message for " +
                    "direct export 888\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 167
 testRunner.And("user set properties \"\" \"\" \"\" \"\" \"\" \"\" \"Direct Export Method\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 168
 testRunner.And("select the external department \"ExternalEntitySameCountry\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 170
 testRunner.And("user delete the document with subject \"Internal Message to Internal Department 11" +
                    "1\" from the list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 171
 testRunner.And("user send the email in \"my\" and click on Cancel button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 172
 testRunner.Then("save reference number from \"my\" in txt with subject \"Internal message for direct " +
                    "export 888\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 173
 testRunner.When("user go to dept \"CommDepSameDep\" messages Unexported folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 174
 testRunner.Then("user search and open mail in dept \"CommDepSameDep\" with subject \"Internal message" +
                    " for direct export 888\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 175
 testRunner.And("click on \"Return\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 176
 testRunner.When("user go to dept \"CommDepSameDep\" Outbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 177
 testRunner.Then("user search and open mail in dept \"CommDepSameDep\" with subject \"Internal message" +
                    " for direct export 888\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 178
 testRunner.And("click on \"Retrieve\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 179
 testRunner.When("user go to dept \"CommDepSameDep\" messages Unexported folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 180
 testRunner.Then("user search and open mail in dept \"CommDepSameDep\" with subject \"Internal message" +
                    " for direct export 888\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 181
 testRunner.Then("click on \"Export\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 182
 testRunner.When("user go to dept \"CommDepSameDep\" Exported", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 183
 testRunner.Then("user search and open mail in dept \"CommDepSameDep\" with subject \"Internal message" +
                    " for direct export 888\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 184
 testRunner.And("user click on \"deptCommDept,Archive\" button and set \"Comment for archive\" \"1.jpg\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 185
 testRunner.When("user open \"deptCommDept\" archive message with suject \"Internal message for direct" +
                    " export 888\" and click on button \"Delete\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 187
 testRunner.Then("mail with subject \"Internal message for direct export 888\" should appear in \"dept" +
                    "CommDept\" Delete", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 188
 testRunner.When("user go to search \"Advance Search\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 189
 testRunner.Then("click on \"Clear\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 190
 testRunner.And("write reference number of \"Internal message for direct export 888\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 191
 testRunner.And("write export date from \"now\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 192
 testRunner.Then("click on \"Search\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 193
 testRunner.Then("Check the advance searched results with subject \"Internal message for direct expo" +
                    "rt 888\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 194
 testRunner.Then("click on \"Clear\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 195
 testRunner.And("write reference number of \"Internal message for direct export 888\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 196
 testRunner.And("write created date from \"now\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 197
 testRunner.Then("click on \"Search\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 198
 testRunner.Then("Check the advance searched results with subject \"Internal message for direct expo" +
                    "rt 888\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("ph 7 Retrieve  Message - 1")]
        public virtual void Ph7RetrieveMessage_1()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ph 7 Retrieve  Message - 1", ((string[])(null)));
#line 200
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 201
 testRunner.When("user go to my messages Internal Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 202
 testRunner.And("search \"internalDepartmentSameDepAr\" \"UserMainDepartmentAr\" \"Structural Hierarchy" +
                    "\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 203
 testRunner.And("user set properties \"Paper\" \"12345\" \"Parcels\" \"\" \"\" \"\" \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 204
 testRunner.And("user compose mail \"Internal message for Retreiving 111\" \"Internal message for Ret" +
                    "reiving 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 205
 testRunner.And("user send the email", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 206
 testRunner.Then("save reference number from \"my\" in txt with subject \"Internal message for Retreiv" +
                    "ing 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 207
 testRunner.When("user opens department \"internalDepartmentSameDep\" mail with subject \"Internal mes" +
                    "sage for Retreiving 111\" \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 208
 testRunner.And("click on \"Print\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
