<%@ Page Title="" Language="C#" MasterPageFile="~/view/admin/template-login.master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="LMO_G9.view.admin.WebForm13" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formExtend" runat="server">
    <!-- Outer Row -->
    <div class="row justify-content-center">

        <div class="col-xl-10 col-lg-12 col-md-9">

            <div class="card o-hidden border-0 shadow-lg my-5">
                <div class="card-body p-0">
                    <!-- Nested Row within Card Body -->
                    <div class="row">
                        <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
                        <div class="col-lg-6">
                            <div class="p-5">
                                <div class="text-center">
                                    <h1 class="h4 text-gray-900 mb-4">Welcome Back!</h1>
                                </div>
                                <form class="user" runat="server">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtUsername" CssClass="form-control form-control-user" type="text" placeholder="Enter username" runat="server" />
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtPassword" CssClass="form-control form-control-user" type="password" placeholder="Enter password" runat="server" />
                                    </div>
                                    <div class="form-group">
                                        <div class="custom-control custom-checkbox small">
                                            <asp:CheckBox ID="btnCheck" runat="server" />
                                            <label class="custom-control-label" for="formExtend_btnCheck">Remember Me</label>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="txtError" CssClass="text-error" runat="server" Text="" />
                                    </div>
                                    <asp:Button ID="btnLogin" CssClass="btn btn-primary btn-user btn-block" Text="Login" runat="server" OnClick="btnLogin_Click" />
                                </form>
                                <hr>
                                <div class="text-center">
                                    <a class="small" target="_blank" href="../client/index.aspx">Go to Client Page</a>
                                </div>
                                <div class="text-center">
                                    <a class="small" href="forgot-password.aspx">Forgot Password?</a>
                                </div>
                                <div class="text-center">
                                    <a class="small" href="register.aspx">Create an Account!</a>
                                </div>
                            </div>
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
            $("#formExtend_btnCheck").addClass("custom-control-input");
        })();
        $(document).ready(function () {
        })
    </script>
</asp:Content>
