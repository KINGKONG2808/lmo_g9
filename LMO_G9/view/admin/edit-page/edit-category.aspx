﻿<%@ Page Title="" Language="C#" MasterPageFile="~/view/admin/template-admin.master" AutoEventWireup="true" CodeBehind="edit-category.aspx.cs" Inherits="LMO_G9.view.admin.WebForm19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Edit music category</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageHeading" runat="server">
    <h2>Edit Music Category</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentRow" runat="server">
    <div class="container">
        <div class="row padding-2rem">
            <h1 class="text-center" style="color: red; width: 100%; font-size: 3rem; font-weight: bold;">Edit a music category</h1>
        </div>
        <div class="row padding-2rem">
            <div class="col-lg-3 padding-1rem d-none" >
                Category Id:
            </div>
            <div class="col-lg-9 padding-1rem d-none">
                <asp:TextBox ID="txtId" runat="server" Enabled="false" CssClass="form-control width-100" />
            </div>
            <div class="col-lg-3 padding-1rem">
                Name:
            </div>
            <div class="col-lg-9 padding-1rem" >
                <asp:TextBox ID="txtName" runat="server"  CssClass="form-control width-100" />
            </div>
            <div class="col-lg-3 padding-1rem d-none">
                Create by:
            </div>
            <div class="col-lg-9 padding-1rem d-none">
                <asp:TextBox ID="txtCreateBy" runat="server" Enabled="false" CssClass="form-control width-100" />
            </div>
            <div class="col-lg-3 padding-1rem d-none">
                Update by:
            </div>
            <div class="col-lg-9 padding-1rem d-none">
                <asp:TextBox ID="txtUpdateBy" runat="server" Enabled="false" CssClass="form-control width-100" />
            </div>
            <div class="col-lg-3 padding-1rem d-none">
                Update date:
            </div>
            <div class="col-lg-9 padding-1rem d-none">
                <asp:TextBox ID="txtUpdateDate" runat="server" Enabled="false" CssClass="form-control width-100" />
            </div>
        </div>
        <div class="row padding-2rem">
            <div class="col-lg-4">
                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-primary width-100" OnClick="btnEdit_Click" />
               <%-- <button type="button" class="btn btn-primary width-100" onclick="saveCategory('edit-category.aspx/btnEdit_Click', 'contentRow_txtName');">Edit</button>--%>
            </div>
            <div class="col-lg-4"></div>
            <div class="col-lg-4 text-right">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary width-100" PostBackUrl="~/view/admin/category.aspx" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="extendOther" runat="server">
</asp:Content>
