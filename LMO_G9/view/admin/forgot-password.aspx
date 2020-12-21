﻿<%@ Page Title="" Language="C#" MasterPageFile="~/view/admin/template-login.master" AutoEventWireup="true" CodeBehind="forgot-password.aspx.cs" Inherits="LMO_G9.view.admin.WebForm14" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Forgot Password Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formExtend" runat="server">
    <!-- Outer Row -->
    <div class="row justify-content-center">

        <div class="col-xl-10 col-lg-12 col-md-9">

            <div class="card o-hidden border-0 shadow-lg my-5">
                <div class="card-body p-0">
                    <!-- Nested Row within Card Body -->
                    <div class="row">
                        <div class="col-lg-6 d-none d-lg-block bg-password-image"></div>
                        <div class="col-lg-6">
                            <div class="p-5">
                                <div class="text-center">
                                    <h1 class="h4 text-gray-900 mb-2">Forgot Your Password?</h1>
                                    <p class="mb-4">We get it, stuff happens. Just enter your username place below and we'll reset your password to default!</p>
                                </div>
                                <form class="user" runat="server">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtUsernameReset" runat="server" CssClass="form-control form-control-user" placeholder="Enter your username place ..." />
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="txtError" runat="server" Text="" CssClass="text-error" />
                                    </div>

                                    <asp:Button ID="btnResetPassword" runat="server" Text="Reset Password" CssClass="btn btn-primary btn-user btn-block" OnClick="btnResetPassword_Click" />
                                </form>
                                <hr>
                                <div class="text-center">
                                    <a class="small" href="register.aspx">Create an Account!</a>
                                </div>
                                <div class="text-center">
                                    <a class="small" href="login.aspx">Already have an account? Login!</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </div>
</asp:Content>
