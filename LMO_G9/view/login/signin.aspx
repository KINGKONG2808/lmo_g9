<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="LMO_G9.view.login.signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="icon" type="image/png" href="../template/signin/images/icons/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="../template/signin/vendor/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../template/signin/fonts/font-awesome-4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="../template/signin/vendor/animate/animate.css" />
    <link rel="stylesheet" type="text/css" href="../template/signin/vendor/css-hamburgers/hamburgers.min.css" />
    <link rel="stylesheet" type="text/css" href="../template/signin/vendor/select2/select2.min.css" />
    <link rel="stylesheet" type="text/css" href="../template/signin/css/util.css" />
    <link rel="stylesheet" type="text/css" href="../template/signin/css/main.css" />
</head>
<body>
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <div class="login100-pic js-tilt" data-tilt>
                    <img src="../template/signin/images/img-01.png" alt="IMG" />
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
                        <a class="txt2" href="signup.aspx">Đăng ký tài khoản
							<i class="fa fa-long-arrow-right m-l-5" aria-hidden="true"></i>
                        </a>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <script src="../template/signin/vendor/jquery/jquery-3.2.1.min.js"></script>
    <script src="../template/signin/vendor/bootstrap/js/popper.js"></script>
    <script src="../template/signin/vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="../template/signin/vendor/select2/select2.min.js"></script>
    <script src="../template/signin/vendor/tilt/tilt.jquery.min.js"></script>
    <script>
        $('.js-tilt').tilt({
            scale: 1.1
        })
    </script>
    <script src="../template/signin/js/main.js"></script>
</body>
</html>

