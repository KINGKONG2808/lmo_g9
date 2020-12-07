<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="category-modal.aspx.cs" Inherits="LMO_G9.view.modal.category_modal" %>

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
                <asp:Table runat="server" ID="t1">
                    <asp:TableRow>
                        <asp:TableCell>Ho ten</asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtht" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Dia chi</asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtdiachi" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                <button type="button" class="btn btn-primary">Save changes</button>
            </div>
        </div>
    </div>
</div>
