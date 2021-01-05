<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="LMO_G9.view.client.Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #form1 {
            font-family: Tahoma;
            font-size: 12px;
            margin: 10px;
            padding: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <br />
            <strong>FILE UPLOAD<br />
            </strong>

        </div>
        <asp:FileUpload ID="FileUpload1" runat="server" Width="348px" Height="27px" />
        &nbsp;
        <asp:Button ID="btnUpload" runat="server" Text="Upload" Height="27px" OnClick="btnUpload_Click" />
        &nbsp;<br />
        <br />

        <asp:Image ID="Image1" runat="server" Width="150px" />

    </form>
</body>
</html>
