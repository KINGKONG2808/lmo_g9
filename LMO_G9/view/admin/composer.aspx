<%@ Page Title="" Language="C#" MasterPageFile="~/view/admin/template-admin.master" AutoEventWireup="true" CodeBehind="composer.aspx.cs" Inherits="LMO_G9.view.admin.WebForm7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Composer Manage</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageHeading" runat="server">
    <!-- Page Heading -->
    <h1 class="h3 mb-2 text-gray-800">Composer</h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contentRow" runat="server">
    <form id="form1" runat="server">
        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <asp:LinkButton ID="add" CommandName="add" CssClass="btn btn-primary" OnCommand="add_Command" runat="server" data-toggle="modal" data-target="#exampleModal">
                    <i class="fas fa-plus ">ADD</i>
                </asp:LinkButton>

                <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel">Add Composer</h5>

                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <asp:Table runat="server" ID="tbl">
                                    <asp:TableRow>
                                        <asp:TableCell>Name</asp:TableCell>
                                        <asp:TableCell>
                                            <asp:TextBox runat="server" ID="txtht"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>

                                    <asp:TableRow>
                                        <asp:TableCell>Image path</asp:TableCell>
                                        <asp:TableCell>
                                            <asp:TextBox runat="server" ID="txtdc"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal" runat="server">Close</button>
                                <button type="button" class="btn btn-primary" onclick="btnThem_Click" runat="server">Save</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <h2>Composer List</h2>
                    <asp:GridView ID="grComposer" runat="server" AutoGenerateColumns="false" class="table table-bordered" Width="100%" CellPadding="0">
                        <Columns>
                            <asp:BoundField DataField="composerId" HeaderText="Composer ID" />
                            <asp:BoundField DataField="musicId" HeaderText="Music ID" />
                            <asp:BoundField DataField="name" HeaderText="Name" />
                            <asp:BoundField DataField="imagePath" HeaderText="Img Path" />
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="xoa"
                                        OnCommand="Xoa_Click" runat="server" CommandName="xoa" CommandArgument='<%# Bind("composerId") %>' CssClass="btn btn-danger btn-custom far fa-trash-alt">
                                            
                                    </asp:LinkButton>


                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="sua"
                                        OnCommand="Sua_Click" runat="server" CommandName="sua" CommandArgument='<%# Bind("composerId") %>' CssClass="btn btn-success btn-custom far fa-edit"></asp:LinkButton>
                                </ItemTemplate>

                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="extendOther" runat="server">
</asp:Content>
