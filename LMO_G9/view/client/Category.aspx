<%@ Page Title="" Language="C#" MasterPageFile="~/view/client/template-client.master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="LMO_G9.view.client.Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Thể loại</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="slide" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="row text-center category">

            <%
                foreach (LMO_G9.model.Category ctg in LMO_G9.view.client.Category.lcg)

                { %>
            <div class="col-sm-4">
                <div class="thumbnail">
                    <img src="https://source.unsplash.com/K4mSJ7kc0As/200x200" alt="Paris">
                    <a href="ListMusic.aspx?id=<%=ctg.CategoryId %>" >
                        <p><strong><%=ctg.Name %></strong></p>
                    </a>
                </div>
            </div>
            <%} %>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="extend" runat="server">
</asp:Content>
