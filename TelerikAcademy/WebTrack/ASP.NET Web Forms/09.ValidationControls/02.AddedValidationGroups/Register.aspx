<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="_02.AddedValidationGroups.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Validation with Groups</title>
</head>
<body>
    <form id="RegistrationForm" runat="server">
        <asp:Panel runat="server" ID="LogonPanel" GroupingText="LogonInfo">
            <asp:ValidationSummary ValidationGroup="LogonInfo"
                ID="LogonSummary"
                DisplayMode="BulletList" ForeColor="Red"
                runat="server"
                HeaderText="Error List:"
                Font-Names="arial"
                Font-Size="8" />

            <asp:Label runat="server" ID="UsernameLabel" AssociatedControlID="UsernameInput">Username:</asp:Label>
            <asp:TextBox runat="server" ID="UsernameInput" MaxLength="20" ValidationGroup="LogonInfo"></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="LogonInfo"
                ID="RequiredFieldValidatorUsername"
                runat="server" ForeColor="Red" Display="Dynamic"
                ErrorMessage="The username is required!"
                ControlToValidate="UsernameInput" EnableClientScript="True">
            </asp:RequiredFieldValidator>
            <asp:CustomValidator ValidationGroup="LogonInfo"
                ID="UsernameLengthValidator"
                runat="server"
                ControlToValidate="UsernameInput" ForeColor="Red" Display="Dynamic" EnableClientScript="true"
                ErrorMessage="Username must be at least 6 characters long"
                OnServerValidate="UsernameLengthValidator_ServerValidate"></asp:CustomValidator>
            <br />

            <asp:Label runat="server" ID="PasswordLabel" AssociatedControlID="PasswordInput">Password:</asp:Label>
            <asp:TextBox runat="server" ID="PasswordInput" TextMode="Password" MaxLength="20" ValidationGroup="LogonInfo"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorPassword" ValidationGroup="LogonInfo"
                runat="server" ForeColor="Red" Display="Dynamic"
                ErrorMessage="The password is required!"
                ControlToValidate="PasswordInput" EnableClientScript="True">
            </asp:RequiredFieldValidator>
            <asp:CustomValidator ValidationGroup="LogonInfo"
                ID="PasswordLengthValidator"
                runat="server"
                ControlToValidate="PasswordInput" ForeColor="Red" Display="Dynamic" EnableClientScript="true"
                ErrorMessage="Password must be at least 6 characters long"
                OnServerValidate="PasswordLengthValidator_ServerValidate"></asp:CustomValidator>
            <br />

            <asp:Label runat="server" ID="RepeatPasswordLabel" AssociatedControlID="RepeatPasswordInput">Repeat Password:</asp:Label>
            <asp:TextBox runat="server" ID="RepeatPasswordInput" TextMode="Password" ValidationGroup="LogonInfo"></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="LogonInfo"
                ID="RequiredFieldValidatorRepeatPassword"
                runat="server" ForeColor="Red" Display="Dynamic"
                ErrorMessage="The repeat password is required!"
                ControlToValidate="RepeatPasswordInput" EnableClientScript="True">
            </asp:RequiredFieldValidator>
            <asp:CustomValidator ValidationGroup="LogonInfo"
                ID="RepeatPasswordLengthValidator"
                runat="server"
                ControlToValidate="RepeatPasswordInput" ForeColor="Red" Display="Dynamic" EnableClientScript="true"
                ErrorMessage="Password must be at least 6 characters long"
                OnServerValidate="RepeatPasswordLengthValidator_ServerValidate"></asp:CustomValidator>
            <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                ControlToCompare="PasswordInput"
                ControlToValidate="RepeatPasswordInput" Display="Dynamic"
                ErrorMessage="Passwords don't match!" ForeColor="Red" EnableClientScript="True"></asp:CompareValidator>
            <br />
            <asp:CheckBox runat="server" ID="AcceptInput"
                Text="I Accept the Terms and Conditions" ValidationGroup="LogonInfo" />
            <asp:CustomValidator ValidationGroup="LogonInfo"
                ID="CustomValidatorAgreement"
                runat="server"
                ForeColor="Red" Display="Dynamic" EnableClientScript="true"
                ErrorMessage="Agreement is required."
                OnServerValidate="CustomValidatorAgreement_ServerValidate"></asp:CustomValidator>
            <br />
        </asp:Panel>

        <asp:Panel ID="PersonalInfoPanel" runat="server" GroupingText="Personal Info">
            <asp:ValidationSummary ValidationGroup="PersonalInfo"
                ID="PersonalInfoSummary"
                DisplayMode="BulletList" ForeColor="Red"
                runat="server"
                HeaderText="Error List:"
                Font-Names="arial"
                Font-Size="8" />

            <asp:Label runat="server" ID="FirstNameLabel" AssociatedControlID="FirstNameInput">First Name:</asp:Label>
            <asp:TextBox runat="server" ID="FirstNameInput" ValidationGroup="PersonalInfo"></asp:TextBox>
            <asp:CustomValidator ValidationGroup="PersonalInfo"
                ID="FirstNameLengthValidator"
                runat="server"
                ControlToValidate="FirstNameInput" ForeColor="Red" Display="Dynamic" EnableClientScript="true"
                ErrorMessage="First name must be at least 2 characters long"
                OnServerValidate="FirstNameLengthValidator_ServerValidate"></asp:CustomValidator>
            <asp:RequiredFieldValidator ValidationGroup="PersonalInfo"
                ID="RequiredFieldValidatorFirstName"
                runat="server" ForeColor="Red" Display="Dynamic"
                ErrorMessage="The first name is required!"
                ControlToValidate="FirstNameInput" EnableClientScript="True">
            </asp:RequiredFieldValidator>
            <br />

            <asp:Label runat="server" ID="LastNameLabel" AssociatedControlID="LastNameInput">Last Name:</asp:Label>
            <asp:TextBox runat="server" ID="LastNameInput" ValidationGroup="PersonalInfo"></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="PersonalInfo"
                ID="RequiredFieldValidatorLastName"
                runat="server" ForeColor="Red" Display="Dynamic"
                ErrorMessage="The last name is required!"
                ControlToValidate="LastNameInput" EnableClientScript="True">
            </asp:RequiredFieldValidator>
            <asp:CustomValidator ValidationGroup="PersonalInfo"
                ID="LastNameLengthValidator"
                runat="server"
                ControlToValidate="LastNameInput" ForeColor="Red" Display="Dynamic" EnableClientScript="true"
                ErrorMessage="Last name must be at least 2 characters long"
                OnServerValidate="LastNameLengthValidator_ServerValidate"></asp:CustomValidator>
            <br />

            <asp:Label runat="server" ID="AgeLabel" AssociatedControlID="AgeInput">Age:</asp:Label>
            <asp:TextBox runat="server" ID="AgeInput" TextMode="Number" ValidationGroup="PersonalInfo"></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="PersonalInfo"
                ID="RequiredFieldValidatorAge"
                runat="server" ForeColor="Red" Display="Dynamic"
                ErrorMessage="The age is required!"
                ControlToValidate="AgeInput" EnableClientScript="True">
            </asp:RequiredFieldValidator>
            <asp:RangeValidator ValidationGroup="PersonalInfo"
                ControlToValidate="AgeInput"
                MinimumValue="18"
                MaximumValue="81"
                Type="Integer"
                EnableClientScript="True"
                Text="The value must be from 18 to 81!"
                runat="server"></asp:RangeValidator>
            <br />
        </asp:Panel>

        <asp:Panel ID="AddressInfoPanel" runat="server" GroupingText="Address Info">
            <asp:ValidationSummary ValidationGroup="AddressInfo"
                ID="AddressInfoSummary"
                DisplayMode="BulletList" ForeColor="Red"
                runat="server"
                HeaderText="Error List:"
                Font-Names="arial"
                Font-Size="8" />

            <asp:Label runat="server" ID="EmailLabel" AssociatedControlID="EmailInput">Email:</asp:Label>
            <asp:TextBox runat="server" ID="EmailInput" TextMode="Email" ValidationGroup="AddressInfo"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorEmail" ValidationGroup="AddressInfo"
                runat="server" ForeColor="Red" Display="Dynamic"
                ErrorMessage="The email is required!"
                ControlToValidate="EmailInput" EnableClientScript="True">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator
                ID="RegularExpressionValidatorEmail" ValidationGroup="AddressInfo"
                runat="server" ForeColor="Red" Display="Dynamic"
                ErrorMessage="Email address is incorrect!"
                ControlToValidate="EmailInput" EnableClientScript="True"
                ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}">
            </asp:RegularExpressionValidator>
            <br />

            <asp:Label runat="server" ID="AddressLabel" AssociatedControlID="AddressInput">Address:</asp:Label>
            <asp:TextBox runat="server" ID="AddressInput" ValidationGroup="AddressInfo"></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="AddressInfo"
                ID="RequiredFieldValidatorAddress"
                runat="server" ForeColor="Red" Display="Dynamic"
                ErrorMessage="The address is required!"
                ControlToValidate="AddressInput" EnableClientScript="True">
            </asp:RequiredFieldValidator>
            <br />

            <asp:Label runat="server" ID="PhoneLabel" AssociatedControlID="PhoneInput">Phone:</asp:Label>
            <asp:TextBox runat="server" ID="PhoneInput" TextMode="Phone" ValidationGroup="AddressInfo"></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="AddressInfo"
                ID="RequiredFieldValidatorPhone"
                runat="server" ForeColor="Red" Display="Dynamic"
                ErrorMessage="The phone is required!"
                ControlToValidate="PhoneInput" EnableClientScript="True">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ValidationGroup="AddressInfo"
                ID="RegularExpressionValidatorPhone"
                runat="server" ForeColor="Red" Display="Dynamic"
                ErrorMessage="Phone is incorrect!"
                ControlToValidate="PhoneInput" EnableClientScript="True"
                ValidationExpression="^[0-9]{3}([\.])?[0-9]{3}([\.])?[0-9]{4}$">
            </asp:RegularExpressionValidator>
            <br />
        </asp:Panel>

        <asp:Button runat="server" ID="LogonInfoButton" Text="Check Logon Info"
            OnClick="LogonInfoButton_Click" ValidationGroup="LogonInfo" />
        <br />
        <asp:Button runat="server" ID="PersonalInfoButton" Text="Check Personal Info"
            OnClick="PersonalInfoButton_Click" ValidationGroup="PersonalInfo" />
        <br />
        <asp:Button runat="server" ID="AddressInfoButton" Text="Check Address Info"
            OnClick="AddressInfoButton_Click" ValidationGroup="AddressInfo" />
        <br />
        <asp:Button runat="server" ID="AllInfoButton" Text="Check All"
            OnClick="AllInfoButton_Click" />
        <br />
        <asp:Label runat="server" ID="LabelMessage"></asp:Label>
    </form>
</body>
</html>
