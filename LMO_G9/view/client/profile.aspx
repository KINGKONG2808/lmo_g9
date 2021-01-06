<%@ Page Title="" Language="C#" MasterPageFile="~/view/client/template-client.master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="LMO_G9.view.client.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Thông tin cá nhân</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="slide" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="profile">
            <div class="row profile__title">
                <div class="col-lg-12">
                    <h1>Thông tin cá nhân</h1>
                </div>
                <div class="col-lg-12">
                    <h6>Xin chào
                    <asp:Label ID="labelFullname" runat="server" />
                        !!!
                    </h6>
                </div>
            </div>

            <div class="row profile__infor">
                <div class="form-group">
                    <div class="row image-spotlight">
                        <asp:Image ID="avatarPath" runat="server" />
                    </div>
                    <div class="row">
                        <label class="avatar" for="btnUpload">Ảnh đại diện:</label>
                    </div>
                    <div class="row file-upload">
                        <div class="col-lg-10">
                            <div class="custom-file width-100">
                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="custom-file-input" name="filename" />
                                <label class="custom-file-label width-100" for="content_FileUpload1"><i class="far fa-file-image"></i>&nbsp;&nbsp;&nbsp;Chọn ảnh đại diện</label>
                            </div>
                        </div>
                        <div class="col-lg-2 text-center">
                            <asp:Button ID="btnUpload" runat="server" Text="Thay đổi" OnClick="btnUpload_Click" CssClass="btn btn-custom" />
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <label for="txtFullname">Họ tên:</label>
                    <asp:TextBox ID="txtFullname" CssClass="form-control" runat="server" placeholder="Nhập vào họ tên" />
                </div>

                <div class="form-group">
                    <label for="txtAddress">Địa chỉ:</label>
                    <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" placeholder="Nhập vào địa chỉ" />
                </div>

                <div class="form-group">
                    <label for="txtDateOfBirth">Ngày sinh:</label>
                    <asp:TextBox ID="txtDateOfBirth" CssClass="form-control" runat="server" placeholder="Nhập vào ngày sinh" onclick="clearValue();" />
                </div>

                <div class="form-group">
                    <label for="txtUsername">Tên đăng nhập:</label>
                    <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server" placeholder="Nhập vào tên đăng nhập" />
                </div>

                <div class="form-group">
                    <label for="txtPassword">Mật khẩu:</label>
                    <asp:TextBox ID="txtPassword" type="password" CssClass="form-control" runat="server" placeholder="Nhập vào mật khẩu:" />
                </div>
            </div>

            <div class="row profile__btn">
                <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" CssClass="btn btn-custom" OnClick="btnUpdate_Click" />
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="extend" runat="server">
    <style>
        .datepicker {
            top: 56vh !important;
        }
    </style>
    <script>
        (function () {
            $('input').attr('autocomplete', 'off');
            showDateTimePicker();
            $('.custom-file-label').text('<%=account.AvatarPath%>');
        })();

        // show datetime picker for bootstrap
        function showDateTimePicker() {
            $('#content_txtDateOfBirth').datepicker({
                changeMonth: true,
                changeYear: true,
                format: 'dd/mm/yyyy',
                language: 'tr'
            });
        }

        // Add the following code if you want the name of the file appear on select
        $(".custom-file-input").on("change", function () {
            var fileName = $(this).val().split("\\").pop();
            $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
        });

        function clearValue() {
            $('#content_txtDateOfBirth').removeAttr('value');
        }
    </script>
</asp:Content>
