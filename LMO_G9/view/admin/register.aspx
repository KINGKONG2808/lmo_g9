<%@ Page Title="" Language="C#" MasterPageFile="~/view/admin/template-login.master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="LMO_G9.view.admin.WebForm12" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Register Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formExtend" runat="server">
    <div class="card o-hidden border-0 shadow-lg my-5">
        <div class="card-body p-0">
            <!-- Nested Row within Card Body -->
            <div class="row">
                <div class="col-lg-5 d-none d-lg-block bg-register-image"></div>
                <div class="col-lg-7">
                    <div class="p-5">
                        <div class="text-center">
                            <h1 class="h4 text-gray-900 mb-4">Create an Account!</h1>
                        </div>
                        <form class="user" runat="server">
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <asp:TextBox ID="txtFullname" runat="server" placeholder="Fullname" CssClass="form-control form-control-user" />
                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtAddress" runat="server" placeholder="Address" CssClass="form-control form-control-user" />
                                </div>
                            </div>
                            <div class="form-group row">
                                 <div class="col-sm-6 mb-3 mb-sm-0">
                                    <asp:TextBox ID="txtUsername" runat="server" placeholder="Username" CssClass="form-control form-control-user" />
                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtDateOfBirth" runat="server" placeholder="Date of birth" CssClass="form-control form-control-user" />
                                </div>
                            </div>
                            <div class="form-group row">
                                 <div class="col-sm-6 mb-3 mb-sm-0">
                                    <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" CssClass="form-control form-control-user" type="password" autocomplete="anyrandomstring" />
                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtRepassword" runat="server" placeholder="Repassword" CssClass="form-control form-control-user" type="password" autocomplete="anyrandomstring" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-lg-12">
                                    <asp:Label ID="txtError" runat="server" Text="" CssClass="text-error" />
                                </div>
                            </div>
                            <asp:Button ID="btnRegister" runat="server" Text="Register Account" CssClass="btn btn-primary btn-user btn-block" OnClick="btnRegister_Click" />
                        </form>
                        <hr>
                        <div class="text-center">
                            <a class="small" href="forgot-password.aspx">Forgot Password?</a>
                        </div>
                        <div class="text-center">
                            <a class="small" href="login.aspx">Already have an account? Login!</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="customScript" runat="server">
    <script>
        (function () {
            $('input').attr('autocomplete', 'off');
            showDateTimePicker();
        })();

        // show datetime picker for bootstrap
        function showDateTimePicker() {
            $('#formExtend_txtDateOfBirth').datepicker({
                changeMonth: true,
                changeYear: true,
                format: 'dd/mm/yyyy',
                language: 'tr'
            });
        }
    </script>
</asp:Content>
