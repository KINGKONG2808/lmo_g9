<%@ Page Title="" Language="C#" MasterPageFile="~/view/admin/template-admin.master" AutoEventWireup="true" CodeBehind="edit-composer.aspx.cs" Inherits="LMO_G9.view.admin.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Edit List Composer</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageHeading" runat="server">
    <h2>Edit List Composer</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentRow" runat="server">
    <div class="container">
        <div class="row padding-2rem">
            <h1 class="text-center" style="color: red; width: 100%; font-size: 3rem; font-weight: bold;"><%
    if (Session["composerEdit"] != null)
    { %>Edit a
                <% }
    else
    { %> Add a<% } %>Composer</h1>
        </div>
        <div class="row padding-2rem">
            <div class="col-lg-3 padding-1rem d-none">
                Composer Id:
            </div>
            <div class="col-lg-9 padding-1rem d-none">
                <asp:TextBox ID="txtId" runat="server" Enabled="false" CssClass="form-control width-100" />
            </div>
            <div class="col-lg-3 padding-1rem">
                Name:
            </div>
            <div class="col-lg-9 padding-1rem">
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control width-100" />
            </div>
           <div class="col-lg-3 padding-1rem">
                Image:
            </div>
            <div class="col-lg-9 padding-1rem">
                <asp:FileUpload ID="imageFUL" CssClass="form-control width-100" runat="server" />
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
            <div class="col-lg-4"><%
    if (Session["composerEdit"] != null)
    { %>
                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-primary width-100" OnClick="btnEdit_Click" />
                <% }
    else
    { %> 
                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary width-100" OnClick="btnAdd_Click" /> <% } %>
            </div>
            <div class="col-lg-4"></div>
            <div class="col-lg-4 text-right">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary width-100" PostBackUrl="~/view/admin/composer.aspx" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="extendOther" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="extendScript" runat="server">
</asp:Content>
