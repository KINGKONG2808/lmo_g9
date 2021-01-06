<%@ Page Title="" Language="C#" MasterPageFile="~/view/admin/template-admin.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="LMO_G9.view.admin.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Home Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageHeading" runat="server">
    <h1 class="h3 mb-0 text-gray-800">Dashboard</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentRow" runat="server">
    <!-- Content Row -->
    <div class="container">
        <div class="row">
            <img src="../template/images/logo.png" style="margin-left: 28vw" />
        </div>
        <div class="row">
            <div class="col-lg-6">
                <p class="introduce">
                    LMO_G9 cung cấp dịch vụ nghe nhạc trực tuyến hoàn toàn miễn phí. <br />
                    Mang lại trải nghiệm nghe nhạc tốt nhất khi sử dụng dịch vụ của chúng tôi. <br />
                    LMO_G9 provides free music streaming service. <br />
                    Bring the best music experience when using our services.
                </p>
            </div>
            <div class="col-lg-6">
                <div class="row text-center">
                    <p class="width-100">
                        <a href="https://www.facebook.com/hungvv2808" target="_blank"><i class="fab fa-facebook-f"></i>&nbsp;&nbsp;&nbsp;Facebook</a>
                    </p>
                </div>
                <div class="row text-center">
                    <p class="width-100">
                        <a href="https://www.instagram.com/hung.k2"  target="_blank"><i class="fab fa-instagram"></i>&nbsp;&nbsp;&nbsp;Instagram</a>
                    </p>
                </div>
                <div class="row text-center">
                    <p class="width-100">
                        <a href="https://github.com/hungvv2808"  target="_blank"><i class="fab fa-github"></i>&nbsp;&nbsp;&nbsp;Github</a>
                    </p>
                </div>
                <div class="row text-center">
                    <p class="width-100">
                        <a href="mailto:vuhung2881999@gmail.com" ><i class="far fa-envelope"></i>&nbsp;&nbsp;&nbsp;Gmail</a>
                    </p>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <p>Đồng sáng lập</p>
            </div>
            <div class="col-lg-12">
                <a href="https://www.facebook.com/hungvv2808">
                    <p>
                        <span class="span-first">Vũ</span><span class="span-second"> Văn Hùng</span>
                    </p>
                </a>
            </div>
            <div class="col-lg-12">
                <a href="https://www.facebook.com/Soul.Of.Death.Sofd">
                    <p>
                        <span class="span-second">Phạm Văn </span><span class="span-first">Yên</span>
                    </p>
                </a>
            </div>
            <div class="col-lg-12">
                <a href="https://www.facebook.com/niet1017">
                    <p>
                        <span class="span-first">Phạm</span><span class="span-second"> Hoàng Tiến</span>
                    </p>
                </a>
            </div>
            <div class="col-lg-12">
                <a href="https://www.facebook.com/hieu.khac.777">
                    <p>
                        <span class="span-second">Nguyễn Khắc </span><span class="span-first">Hiếu</span>
                    </p>
                </a>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="extendOther" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="extendScript" runat="server">
</asp:Content>
