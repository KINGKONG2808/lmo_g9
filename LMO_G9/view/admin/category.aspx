﻿<%@ Page Title="" Language="C#" MasterPageFile="~/view/admin/template-admin.master" AutoEventWireup="true" CodeBehind="category.aspx.cs" Inherits="LMO_G9.view.admin.WebForm15" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Category</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageHeading" runat="server">
    <h2>Music Category</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentRow" runat="server">
    <div class="container">
        <div class="row">
            <button type="button" class="btn btn-primary btn-custom" data-toggle="modal" data-target="#exampleModal" style="width: 100%; margin: 1rem;">
                <i class="fas fa-plus">Add</i>
            </button>
        </div>
    </div>

    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">List category</h6>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="grdDs" runat="server" AllowPaging="true" PageSize="15" AutoGenerateColumns="false" class="table table-bordered" Width="100%" CellSpacing="0" >
                    <Columns>
                        <asp:BoundField DataField="categoryId" HeaderText="Category Id" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="name" HeaderText="Name" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="createDate" HeaderText="Create Date" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="createPeople" HeaderText="Create By" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="updateDate" HeaderText="Update Date" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="updatePeople" HeaderText="Update By" HeaderStyle-CssClass="text-center" />
                        <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:LinkButton ID="edit" CommandName="edit" CommandArgument='<%# Bind("categoryId") %>' CssClass="btn btn-success btn-custom"
                                    OnCommand="edit_Command" runat="server" OnClientClick="onShowModal(exampleModal);">
                                    <i class="fas fa-edit"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:LinkButton ID="delete" CommandName="delete" CommandArgument='<%# Bind("categoryId") %>' CssClass="btn btn-danger btn-custom"
                                    OnCommand="delete_Command" runat="server"
                                    OnClientClick="return confirm('Are you sure to detele?') ">
                                    <i class="fas fa-trash"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Category Information</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-4">Category name:</div>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtCategoryName" CssClass="form-control width-100" type="text" placeholder="Enter the category name ..." runat="server" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" onclick="saveCategory('category.aspx/saveCategory', 'contentRow_txtCategoryName');">Save</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="extendOther" runat="server">
</asp:Content>
