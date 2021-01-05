<%@ Page Title="" Language="C#" MasterPageFile="~/view/admin/template-admin.master" AutoEventWireup="true" CodeBehind="composer.aspx.cs" Inherits="LMO_G9.view.admin.WebForm7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Composer Manage</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageHeading" runat="server">
    <!-- Page Heading -->
    <h1 class="h3 mb-2 text-gray-800">Composer</h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contentRow" runat="server">

    <!-- DataTales Example -->
    <div class="container">
        <div class="row">
            <button type="button" class="btn btn-primary btn-custom" data-toggle="modal" data-target="#exampleModal" style="width: 100%; margin: 1rem;">
                <i class="fas fa-plus">Add</i>
            </button>
        </div>
    </div>
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Composer Information</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-lg-4">Composer name:</div>
                                <div class="col-lg-8">
                                    <asp:TextBox ID="txtComposerName" CssClass="form-control width-100" type="text" placeholder="Enter the Composer name ..." runat="server" />
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="txtError" CssClass="text-error" runat="server" Text="" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4">Image path:</div>
                                <div class="col-lg-8">
                                    <asp:TextBox ID="txtImgPath" CssClass="form-control width-100" type="text" placeholder="Enter the Image path ..." runat="server" />
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="txtError1" CssClass="text-error" runat="server" Text="" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary" data-dismiss="modal" onclick="saveComposer('contentRow_txtComposerName', 'contentRow_txtImgPath');">Save</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">List composer</h6>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:GridView ID="grComposer" runat="server" AllowPaging="true" PageSize="15" AutoGenerateColumns="false" class="table table-bordered" Width="100%" CellSpacing="0">
                        <Columns>
                            <asp:BoundField DataField="composerId" HeaderText="Composer Id" HeaderStyle-CssClass="text-center" />
                            <asp:BoundField DataField="name" HeaderText="Name" HeaderStyle-CssClass="text-center" />
                            <asp:BoundField DataField="imagePath" HeaderText="Image Path" HeaderStyle-CssClass="text-center" />
                            <asp:BoundField DataField="createDate" HeaderText="Create Date" HeaderStyle-CssClass="text-center" />
                            <asp:BoundField DataField="CreatePeople" HeaderText="Create By" HeaderStyle-CssClass="text-center" />
                            <asp:BoundField DataField="updateDate" HeaderText="Update Date" HeaderStyle-CssClass="text-center" />
                            <asp:BoundField DataField="UpdatePeople" HeaderText="Update By" HeaderStyle-CssClass="text-center" />
                            <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="edit" CommandName="edit" CommandArgument='<%# Bind("composerId") %>' CssClass="btn btn-success btn-custom"
                                        OnCommand="edit_Command" runat="server" OnClientClick="onShowModal(exampleModal);">
                                    <i class="fas fa-edit"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="delete" CommandName="delete" CommandArgument='<%# Bind("composerId") %>' CssClass="btn btn-danger btn-custom"
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="extendOther" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="extendScript" runat="server">
</asp:Content>
