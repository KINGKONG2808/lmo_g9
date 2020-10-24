<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="LMO_G9.view.login.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng ký</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="icon" type="image/png" href="../template/signup/images/icons/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="..template/signup/vendor/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="..template/signup/fonts/font-awesome-4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="..template/signup/fonts/Linearicons-Free-v1.0.0/icon-font.min.css" />
    <link rel="stylesheet" type="text/css" href="..template/signup/fonts/iconic/css/material-design-iconic-font.min.css" />
    <link rel="stylesheet" type="text/css" href="..template/signup/vendor/animate/animate.css" />
    <link rel="stylesheet" type="text/css" href="..template/signup/vendor/css-hamburgers/hamburgers.min.css" />
    <link rel="stylesheet" type="text/css" href="..template/signup/vendor/animsition/css/animsition.min.css" />
    <link rel="stylesheet" type="text/css" href="..template/signup/vendor/select2/select2.min.css" />
    <link rel="stylesheet" type="text/css" href="..template/signup/vendor/daterangepicker/daterangepicker.css" />
    <link rel="stylesheet" type="text/css" href="..template/signup/css/util.css" />
    <link rel="stylesheet" type="text/css" href="..template/signup/css/main.css" />
</head>
<body style="background-color: #999999;">
    <div class="limiter">
        <div class="container-login100">
            <div class="login100-more" style="background-image: url('..template/signup/images/bg-01.jpg');"></div>

            <div class="wrap-login100 p-l-50 p-r-50 p-t-72 p-b-50">
                <form class="login100-form validate-form">
                    <span class="login100-form-title p-b-59">Đăng ký
                    </span>

                    <div class="wrap-input100 validate-input" data-validate="Họ tên là trường bắt buộc">
                        <span class="label-input100">Họ và tên</span>
                        <input class="input100" type="text" name="name" placeholder="Họ và tên ..." />
                        <span class="focus-input100"></span>
                    </div>

                    <div class="wrap-input100 validate-input" data-validate="Email phải đúng định dạng: ex@abc.xyz">
                        <span class="label-input100">Email</span>
                        <input class="input100" type="text" name="email" placeholder="Địa chỉ email ..." />
                        <span class="focus-input100"></span>
                    </div>

                    <div class="wrap-input100 validate-input" data-validate="Tên đăng nhập là trường bắt buộc">
                        <span class="label-input100">Tên đăng nhập</span>
                        <input class="input100" type="text" name="username" placeholder="Tên đăng nhập ..." />
                        <span class="focus-input100"></span>
                    </div>

                    <div class="wrap-input100 validate-input" data-validate="Mật khẩu là trường bắt buộc">
                        <span class="label-input100">Mật khẩu</span>
                        <input class="input100" type="text" name="pass" placeholder="*************" />
                        <span class="focus-input100"></span>
                    </div>

                    <div class="wrap-input100 validate-input" data-validate="Nhập lại mật khẩu là bắt buộc">
                        <span class="label-input100">Nhập lại mật khẩu</span>
                        <input class="input100" type="text" name="repeat-pass" placeholder="*************" />
                        <span class="focus-input100"></span>
                    </div>

                    <div class="flex-m w-full p-b-33">
                        <div class="contact100-form-checkbox">
                            <input class="input-checkbox100" id="ckb1" type="checkbox" name="remember-me" />
                            <label class="label-checkbox100" for="ckb1">
                                <span class="txt1">Tôi đồng ý với điều khoản người dùng của
									<a href="#" class="txt2 hov1">LMO-G9 Teams
                                    </a>
                                </span>
                            </label>
                        </div>


                    </div>

                    <div class="container-login100-form-btn">
                        <div class="wrap-login100-form-btn">
                            <div class="login100-form-bgbtn"></div>
                            <button class="login100-form-btn">
                                Đăng ký
                            </button>
                        </div>

                        <a href="signin.aspx" class="dis-block txt3 hov1 p-r-30 p-t-10 p-b-10 p-l-30">Đăng nhập
							<i class="fa fa-long-arrow-right m-l-5"></i>
                        </a>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <script src="..template/signup/vendor/jquery/jquery-3.2.1.min.js"></script>
    <script src="..template/signup/vendor/animsition/js/animsition.min.js"></script>
    <script src="..template/signup/vendor/bootstrap/js/popper.js"></script>
    <script src="..template/signup/vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="..template/signup/vendor/select2/select2.min.js"></script>
    <script src="..template/signup/vendor/daterangepicker/moment.min.js"></script>
    <script src="..template/signup/vendor/daterangepicker/daterangepicker.js"></script>
    <script src="..template/signup/vendor/countdowntime/countdowntime.js"></script>
    <script src="..template/signup/js/main.js"></script>
</body>
</html>
