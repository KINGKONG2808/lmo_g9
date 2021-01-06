<%@ Page Title="" Language="C#" MasterPageFile="~/view/client/template-client.master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="LMO_G9.view.client.Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Thể loại</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="slide" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <div class="category">
        <div class="row category__title">
            <h1>Danh sách thể loại</h1>
        </div>
        <div class="row category__grid">
            <%  if (lcg.Count == 0) { %>
                    <h5>Không có danh sách thể loại</h5>
            <% } else {
                    foreach (LMO_G9.model.Category ctg in LMO_G9.view.client.Category.lcg) { %>
                        <div class="col-sm-4 grid-padding">
                            <div class="thumbnail">
                                <img src="../template/images/demo.jfif" alt="Paris">
                                <a href="list-music.aspx?id=<%=ctg.CategoryId %>">
                                    <p><strong><%=ctg.Name %></strong></p>
                                </a>
                            </div>
                        </div>
            <%      } 
               } 
            %>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="extend" runat="server">
</asp:Content>
