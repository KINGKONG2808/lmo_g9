<%@ Page Title="" Language="C#" MasterPageFile="~/view/admin/template-admin.master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="LMO_G9.view.admin.WebForm8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Profile</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageHeading" runat="server">
    <h2>Profile Manage</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentRow" runat="server">
    <div class="container profile">
        <div class="row profile__title">
            <div class="col-lg-12">
                <h1>Your profile</h1>
            </div>
            <div class="col-lg-12">
                <h6>Hello 
                    <asp:Label ID="labelFullname" runat="server" />
                    !!!
                </h6>
            </div>
        </div>

        <div class="row profile__infor">
            <div class="form-group">
                <div class="row image-spotlight">
                    <asp:Image ID="avatarPath" runat="server" />
                </div>
                <div class="row">
                    <label class="avatar" for="btnUpload">Avatar:</label>
                </div>
                <div class="row file-upload">
                    <div class="col-lg-10">
                        <div class="custom-file">
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="custom-file-input" name="filename" />
                            <label class="custom-file-label" for="contentRow_FileUpload1"><i class="far fa-file-image"></i>&nbsp;&nbsp;&nbsp;Choose an image</label>
                        </div>
                    </div>
                    <div class="col-lg-2 text-center">
                        <asp:Button ID="btnUpload" runat="server" Text="Change" OnClick="btnUpload_Click" CssClass="btn btn-custom" />
                    </div>
                </div>
            </div>

            <div class="form-group">
                <label for="txtFullname">Fullname:</label>
                <asp:TextBox ID="txtFullname" CssClass="form-control" runat="server" placeholder="Enter your fullname" />
            </div>

            <div class="form-group">
                <label for="txtAddress">Address:</label>
                <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" placeholder="Enter your address" />
            </div>

            <div class="form-group">
                <label for="txtDateOfBirth">Date of birth:</label>
                <asp:TextBox ID="txtDateOfBirth" CssClass="form-control" runat="server" placeholder="Enter your date of birth" onclick="clearValue();" />
            </div>

            <div class="form-group">
                <label for="txtUsername">Username:</label>
                <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server" placeholder="Enter your username" />
            </div>

            <div class="form-group">
                <label for="txtPassword">Password:</label>
                <asp:TextBox ID="txtPassword" type="password" CssClass="form-control" runat="server" placeholder="Enter your password:" />
            </div>
        </div>

        <div class="row profile__btn">
            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-custom" OnClick="btnUpdate_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="extendOther" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="extendScript" runat="server">
    <style>
        .datepicker {
            top: 56vh !important;
        }
    </style>
    <script>
        (function () {
            $('input').attr('autocomplete', 'off');
            showDateTimePicker();
            $('.custom-file-label').text('<%=account.AvatarPath%>');
        })();

        // show datetime picker for bootstrap
        function showDateTimePicker() {
            $('#contentRow_txtDateOfBirth').datepicker({
                changeMonth: true,
                changeYear: true,
                format: 'dd/mm/yyyy',
                language: 'tr'
            });
        }

        // Add the following code if you want the name of the file appear on select
        $(".custom-file-input").on("change", function () {
            var fileName = $(this).val().split("\\").pop();
            $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
        });

        function clearValue() {
            $('#contentRow_txtDateOfBirth').removeAttr('value');
        }
    </script>
</asp:Content>
