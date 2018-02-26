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
 testRunner.Then("save reference number from \"my\" in txt with subject \"Internal Message to Internal" +
                    " Department 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 18
 testRunner.When("user go to dept \"InternalDepartmentSameDepartment2Ar\" messages Internal Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
 testRunner.And("search \"User\" \"UserMainDepartmentAr\" \"Users\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.And("user compose mail \"Internal message for deletion 222\" \"Internal message for delet" +
                    "ion 222\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("user attach attachments 1 \"1.pdf\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("user select connected document with subject \"Incoming Message to outside child de" +
                    "partment 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("user send the email", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.Then("save reference number from \"my\" in txt with subject \"Internal message for deletio" +
                    "n 222\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
 testRunner.When("user go to dept \"InternalDepartmentSameDepartment2Ar\" messages Incoming Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
 testRunner.And("search \"User\" \"UserMainDepartmentAr\" \"Users\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And("user compose mail \"Incoming message for deletion 333\" \"Incoming message for delet" +
                    "ion 333\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.And("select the external department \"ExternalEntitySameCountry\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("user enters incomming message no \"+123456789\" and incomming message Gregorian dat" +
                    "e \"now\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("user set connected person \"Person Name1\" \"PersonEmail1@mail.com\" \"12345\" \"12345\" " +
                    "\"Riyadh\" \"now\" \"هوية\" \"True\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And("user send the email", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.Then("save reference number from \"my\" in txt with subject \"Internal message for deletio" +
                    "n 222\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
 testRunner.And("User logs in \"UserName\" \"Password\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.When("user go to my messages Internal Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
 testRunner.And("user opens inbox email with subject \"Internal message for deletion 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.Then("user deletes the draft", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
 testRunner.When("user open \"my\" deleted message with suject \"Internal message for deletion 111\" an" +
                    "d click on button \"Rollback\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
 testRunner.Then("mail with subject \"Internal message for deletion 111\" should not appear in \"my\" d" +
                    "eleted message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
 testRunner.When("user opens inbox email with subject \"Internal message for deletion 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
 testRunner.Then("verify mail appear in the deleted folder \"Type(My,Dept)\" \"Internal message for de" +
                    "letion 111\" \"value\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
 testRunner.Then("mail should appear in the inbox \"User\" \"Incoming Message with Connected Person to" +
                    " User 111\" \"Incoming Message with Connected Person to User 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
 testRunner.When("user go to dept messages inbox select and delete messgae with subject \"Dept name\"" +
                    " \"Internal message for deletion 222\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
 testRunner.When("user go to dept messages inbox select and delete messgae with subject \"Dept name\"" +
                    " \"Internal message for deletion 333\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
 testRunner.When("user open \"dept name\" deleted message with suject \"Internal message for deletion " +
                    "222\" and click on button \"Rollback\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
 testRunner.When("user open \"dept name\" deleted message with suject \"Internal message for deletion " +
                    "333\" and click on button \"Rollback\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
 testRunner.Then("mail with subject \"Internal message for deletion 222\" should not appear in \"dept " +
                    "name\" deleted message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 48
 testRunner.And("mail with subject \"Internal message for deletion 333\" should not appear in \"dept " +
                    "name\" deleted message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.Then("mail should appear in department \"dept name\" inbox \"User\" \"Internal message for d" +
                    "eletion 222\" \"Internal message for deletion 222\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
 testRunner.Then("mail should appear in department \"dept name\" inbox \"User\" \"Internal message for d" +
                    "eletion 333\" \"Internal message for deletion 333\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
 testRunner.When("Admin set system message permissions for user \"Delete Messages from Inbox\" \"False" +
                    "\" \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
 testRunner.And("Admin set system message permissions for user \"Rollback Messages from Deleted Ite" +
                    "ms\" \"False\" \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.And("Admin set department message permissions for user \"Delete Messages from Inbox\" \"F" +
                    "alse\" \"User\" \"internalDepartmentSameDepAr\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And("Admin set department message permissions for user \"Rollback Messages from Deleted" +
                    " Items\" \"False\" \"User\" \"internalDepartmentSameDepAr\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
                    "\" \"internalDepartmentSameDepAr\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And("Admin set department message permissions for user \"Rollback from Archive\" \"True\" " +
                    "\"User\" \"internalDepartmentSameDepAr\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And("Admin set department message permissions for user \"Archive Messages\" \"True\" \"User" +
                    "\" \"InternalDepartmentSameDepartment2Ar\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.And("Admin set department message permissions for user \"Rollback from Archive\" \"True\" " +
                    "\"User\" \"InternalDepartmentSameDepartment2Ar\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.When("user go to my messages Internal Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
 testRunner.And("search \"User\" \"UserMainDepartmentAr\" \"Users\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.And("user compose mail \"Internal message for archiving 111\" \"Internal message for arch" +
                    "iving 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And("user attach attachments 1 \"1.docx\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.And("user select connected document with subject \"Internal Message to Internal Departm" +
                    "ent 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.And("user send the email", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.Then("save reference number from \"my\" in txt with subject \"Internal message for archivi" +
                    "ng 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 71
 testRunner.When("user sends an encrypted message to \"UserMainDepartmentAr\" \"Structural Hierarchy\" " +
                    "\"internalDepartmentSameDepAr\" \"Encrypted message for archiving 222\" \"Encrypted m" +
                    "essage for archiving 222\" \"P@ssw0rd!@#\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 73
 testRunner.And("user attach attachments 1 \"1.xlsx\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.And("user select connected document with subject \"Internal Message to Internal Departm" +
                    "ent 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And("user send the email", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.Then("save reference number from \"my\" in txt with subject \"Encrypted message for archiv" +
                    "ing 222\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 77
 testRunner.When("user go to dept \"InternalDepartmentSameDepartment2Ar\" messages Incoming Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
 testRunner.And("search \"User\" \"UserMainDepartmentAr\" \"Users\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.And("user compose mail \"Incoming message for archiving 333\" \"Incoming message for arch" +
                    "iving 333\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.And("user attach attachments 1 \"1.docx\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.And("user select connected document with subject \"Internal Message to Internal Departm" +
                    "ent 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
 testRunner.When("user set connected person \"PersonName1\" \"PersonEmail1@mail.com\" \"12345\" \"12345\" \"" +
                    "Riyadh\" \"now\" \"هوية\" \"True\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 84
 testRunner.And("user send the email", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
 testRunner.Then("save reference number from \"deptAcc\" in txt with subject \"Internal message for ar" +
                    "chiving 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 86
 testRunner.When("user go to dept \"InternalDepartmentSameDepartment2Ar\" messages Outgoing Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 87
 testRunner.And("user click CC button \"UserMainDepartmentAr\" \"Structural Hierarchy\" \"internalDepar" +
                    "tmentSameDepAr\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
 testRunner.And("select the external department \"ExternalEntitySameCountry\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.And("user select connected document with subject \"Internal Message to Internal Departm" +
                    "ent 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.And("user compose mail \"Outgoing message for archiving 444\" \"Outgoing message for arch" +
                    "iving 444\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.And("user attach attachments 1 \"1.png\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.And("user send the email and click on Cancel button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.Then("save reference number from \"deptAcc\" in txt with subject \"Outgoing message for ar" +
                    "chiving 444\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 95
 testRunner.When("User logs in \"UserName\" \"Password\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 96
 testRunner.And("user opens inbox email with subject \"Internal message for archiving 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.Then("user click on \"Archive\" button and set \"Comment\" \"1.png\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 98
 testRunner.When("user opens inbox email with subject \"Incoming message for archiving 333\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 99
 testRunner.Then("user click on \"Archive\" button and set \"Comment\" \"1.png\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 100
 testRunner.And("mail should not appear in the inbox \"UserMainDepartment\" \"Internal message for ar" +
                    "chiving 111\" \"Internal message for archiving 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.And("mail should not appear in the inbox \"UserMainDepartment\" \"Incoming message for ar" +
                    "chiving 333\" \"Incoming message for archiving 333\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
 testRunner.When("user go to \"my\" archive message with suject \"Internal message for archiving 111\" " +
                    "and click on button \"Rollback\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 103
 testRunner.And("user go to \"my\" archive message with suject \"Incoming message for archiving 333\" " +
                    "and click on button \"Rollback\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
 testRunner.Then("mail with subject \"Internal message for archiving 111\" should not appear in \"my\" " +
                    "archive message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 105
 testRunner.And("mail with subject \"Incoming message for archiving 333\" should not appear in \"my\" " +
                    "archive message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
 testRunner.Then("mail should appear in the inbox \"User\" \"Internal message for archiving 111\" \"Inte" +
                    "rnal message for archiving 111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 107
 testRunner.Then("mail should appear in the inbox \"User\" \"Incoming message for archiving 333\" \"Inco" +
                    "ming message for archiving 333\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 108
 testRunner.When("user opens department \"internalDepartmentSameDep\" mail with subject \"Encrypted me" +
                    "ssage for archiving 222\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 109
 testRunner.Then("user click on \"Archive\" button and set \"Comment\" \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 110
 testRunner.Then("mail should not appear in \"dept name\" dept inbox with subject \"Encrypted message " +
                    "for archiving 222\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 111
 testRunner.When("user opens department \"internalDepartmentSameDep\" mail with subject \"Outgoing mes" +
                    "sage for archiving 444\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 112
 testRunner.Then("user click on \"Archive\" button and set \"Comment\" \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 113
 testRunner.Then("mail should not appear in \"dept name\" dept inbox with subject \"Outgoing message f" +
                    "or archiving 444\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 114
 testRunner.When("user go to \"dept name\" archive message with suject \"Encrypted message for archivi" +
                    "ng 222\" and click on button \"Rollback\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 115
 testRunner.And("user go to \"dept name\" archive message with suject \"Outgoing message for archivin" +
                    "g 444\" and click on button \"Rollback\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
 testRunner.Then("mail with subject \"Encrypted message for archiving 222\" should not appear in \"dep" +
                    "t name\" archive message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 117
 testRunner.And("mail with subject \"Outgoing message for archiving 444\" should not appear in \"dept" +
                    " name\" archive message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
 testRunner.Then("mail should appear in dept inbox \"internalDepartmentSameDepAr\" \"Encrypted message" +
                    " for archiving 222\" \"Encrypted message for archiving 222\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 119
 testRunner.And("mail should appear in dept inbox \"internalDepartmentSameDepAr\" \"Outgoing message " +
                    "for archiving 444\" \"Outgoing message for archiving 444\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion