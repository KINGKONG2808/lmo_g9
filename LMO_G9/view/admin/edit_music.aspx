<%@ Page Title="" Language="C#" MasterPageFile="~/view/admin/template-admin.master" AutoEventWireup="true" CodeBehind="edit_music.aspx.cs" Inherits="LMO_G9.view.admin.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>music information</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageHeading" runat="server">
    <h2>Music Information</h2>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentRow" runat="server">
    <div class="container">
        <div class="row padding-2rem">
            <h1 class="text-center" style="color: red; width: 100%; font-size: 3rem; font-weight: bold;">
                <asp:Label ID="typeP" runat="server"></asp:Label>
                a music</h1>
        </div>
        <div class="row padding-2rem">
            <%--hidden id--%>
            <div class="col-lg-3 padding-1rem d-none">
                Music Id:
            </div>
            <div class="col-lg-9 padding-1rem d-none">
                <asp:TextBox ID="txtId" runat="server" Enabled="false" CssClass="form-control width-100" />
            </div>

            <%--input information--%>
            <div class="col-lg-3 padding-1rem">
                Name:
            </div>
            <div class="col-lg-9 padding-1rem">
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control width-100" placeholder="Enter the music name ..." />
            </div>
            <div class="col-lg-3 padding-1rem">
                Category:
            </div>
            <div class="col-lg-9 padding-1rem">
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control width-100" />
            </div>
            <div class="col-lg-3 padding-1rem">
                Singer:
            </div>
            <div class="col-lg-9 padding-1rem">
                <asp:DropDownList ID="ddlSinger" CssClass="form-control width-100" runat="server" />
            </div>
            <div class="col-lg-3 padding-1rem">
                Singer Featuring:
            </div>
            <div class="col-lg-9 padding-1rem">
                <asp:DropDownList ID="ddlSingerFeat" CssClass="form-control width-100" runat="server" />
            </div>
            <div class="col-lg-3 padding-1rem">
                Composer:
            </div>
            <div class="col-lg-9 padding-1rem">
                <asp:DropDownList ID="ddlComposer" CssClass="form-control width-100" runat="server" />
            </div>
            <div class="col-lg-3 padding-1rem">
                Image:
            </div>
            <div class="col-lg-9 padding-1rem ">
                <div class="custom-file">
                    <asp:FileUpload ID="imageFUL" CssClass="form-control width-100 custom-file-input" runat="server" />
                    <%--custom-file-input--%>
                    <label id="labelImage" class="custom-file-label" for="content_imageFUL"><i class="far fa-file-image"></i>&nbsp;&nbsp;&nbsp;Chọn the image</label>
                </div>
            </div>
            <div class="col-lg-3 padding-1rem">
                Audio:
            </div>
            <div class="col-lg-9 padding-1rem">
                <div class="custom-file">
                    <asp:FileUpload ID="audioFUL" CssClass="form-control width-100 custom-file-input" runat="server" />
                    <label id="labelAudio" class="custom-file-label" for="content_imageFUL"><i class="far fa-file-image"></i>&nbsp;&nbsp;&nbsp;Choose the audio</label>
                </div>
            </div>



            <%--hidden create-update--%>
            <div class="col-lg-3 padding-1rem d-none">
                Create by:
            </div>
            <div class="col-lg-9 padding-1rem d-none">
                <asp:TextBox ID="txtCreateBy" runat="server" Enabled="false" CssClass="form-control width-100" />
            </div>
            <div class="col-lg-3 padding-1rem d-none">
                Create date:
            </div>
            <div class="col-lg-9 padding-1rem d-none">
                <asp:TextBox ID="txtCreateDate" runat="server" Enabled="false" CssClass="form-control width-100" />
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
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary width-100" OnClick="btnSave_Click" />
            </div>
            <div class="col-lg-4"></div>
            <div class="col-lg-4 text-right">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary width-100" PostBackUrl="~/view/admin/music.aspx" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="extendOther" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="extendScript" runat="server">
    <script>
        (function () {
            var placeholderImage = '<%=msBak.ImagePath%>';
            var placeholderAudio = '<%=msBak.FilePath%>';
            $('#labelImage').text(placeholderImage == '' ? 'Choose the image' : placeholderImage);
            $('#labelAudio').text(placeholderAudio == '' ? 'Choose the audio' : placeholderAudio);
        })();

        $(".custom-file-input").on("change", function () {
            var fileName = $(this).val().split("\\").pop();
            $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
        });
    </script>
</asp:Content>
