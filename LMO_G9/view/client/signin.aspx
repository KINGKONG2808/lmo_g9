<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="LMO_G9.view.client.signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="icon" type="image/png" href="../template/images/icons/favicon.ico" />
    <link href="../template/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../template/fonts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../template/vendor/animate/animate.css" rel="stylesheet" />
    <link href="../template/vendor/css-hamburgers/hamburgers.min.css" rel="stylesheet" />
    <link href="../template/vendor/select2/select2.min.css" rel="stylesheet" />
    <link href="../template/css/util.css" rel="stylesheet" />
    <link href="../template/css/main-signin.css" rel="stylesheet" />
    <link href="../template/css/style.css" rel="stylesheet" />
</head>
<body>
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <div class="login100-pic js-tilt" data-tilt>
                    <img src="../template/images/img-01.png" alt="IMG" />
                </div>

                <form class="login100-form validate-form">
                    <span class="login100-form-title">Tài khoản
                    </span>

                    <div class="wrap-input100 validate-input" data-validate="Email phải đúng định dạng: ex@abc.xyz">
                        <input class="input100" type="text" name="email" placeholder="Nhập vào email" />
                        <span class="focus-input100"></span>
                        <span class="symbol-input100">
                            <i class="fa fa-envelope" aria-hidden="true"></i>
                        </span>
                    </div>

                    <div class="wrap-input100 validate-input" data-validate="Mật khẩu là trường bắt buộc">
                        <input class="input100" type="password" name="pass" placeholder="Nhập vào mật khẩu" />
                        <span class="focus-input100"></span>
                        <span class="symbol-input100">
                            <i class="fa fa-lock" aria-hidden="true"></i>
                        </span>
                    </div>

                    <div class="container-login100-form-btn">
                        <button class="login100-form-btn">
                            Đăng nhập
                        </button>
                    </div>

                    <div class="text-center p-t-12">
                        <span class="txt1">Quên
                        </span>
                        <a class="txt2" href="#">Email / Mật khẩu?
                        </a>
                    </div>

                    <div class="text-center p-t-136">
                        <a class="txt2" href="../client/index.aspx" style="padding-right: 15px">
							<i class="fa fa-long-arrow-left m-l-5" aria-hidden="true"></i>
                            &nbsp;Trang chủ
                        </a>
                        <a class="txt2" href="signup.aspx" style="padding-left: 15px">
                            Đăng ký tài khoản
							<i class="fa fa-long-arrow-right m-l-5" aria-hidden="true"></i>
                        </a>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <script src="../template/vendor/jquery/jquery-3.2.1.min.js"></script>
    <script src="../template/vendor/bootstrap/js/popper.js"></script>
    <script src="../template/vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="../template/vendor/select2/select2.min.js"></script>
    <script src="../template/vendor/tilt/tilt.jquery.min.js"></script>
    <script>
        $('.js-tilt').tilt({
            scale: 1.1
        })
    </script>
    <script src="../template/js/main-signin.js"></script>
</body>
</html>

