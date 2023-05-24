<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="ProjectManagement.ResetPassword" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!-- Tell the browser to be responsive to screen width -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="robots" content="noindex,nofollow" />
    <title>Project Management</title>
    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="" />
    <!-- Custom CSS -->
    <link href="css/style.min.css" rel="stylesheet" />
</head>
<body>
    <form id="resetform" runat="server">
        <div class="main-wrapper">
            <div class="preloader">
                <div class="lds-ripple">
                    <div class="lds-pos"></div>
                    <div class="lds-pos"></div>
                </div>
            </div>
            <div class="d-flex justify-content-center align-items-center bg-cyan px-5" style="height: 100vh;">
                <div id="loginform" class="row">
                    <div class="col-12 text-center pt-3 pb-3">
                        <span class="db">
                            <img src="images/logo-text.png" alt="logo" /></span>
                    </div>
                    <!-- Form -->
                    <form class="form-horizontal mt-3" action="#">
                        <div class="row pb-4">
                            <h4 class="text-white">Reset Password</h4>
                            <div class="col-12">
                                <div class="input-group mb-3">
                                    <asp:TextBox ID="txtresetPassword" runat="server" TextMode="Password" CssClass="form-control form-control-lg" placeholder="New Password.." aria-describedby="basic-addon1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvResetPass" runat="server" ControlToValidate="txtresetPassword" ErrorMessage="Please enter New password" ValidationGroup="resetPass" Display="Dynamic" ForeColor="White"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rexResetPass" runat="server" ControlToValidate="txtresetPassword"
                                        ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$" ErrorMessage="Enter min 8 and max 15 character, including one upper and special character." ForeColor="White" ValidationGroup="resetPass"></asp:RegularExpressionValidator>
                                </div>
                                <div class="input-group mb-3">
                                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control form-control-lg" placeholder="Confirm Password.." aria-describedby="basic-addon1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvConfiPass" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Please enter Confirm  password" ValidationGroup="resetPass" Display="Dynamic" ForeColor="White"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cmpResetPass" runat="server" ControlToCompare="txtresetPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Password Mismatch" Display="Dynamic" ValidationGroup="resetPass" ForeColor="White"></asp:CompareValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row border-top border-secondary">
                            <div class="col-12">
                                <div class="form-group">
                                    <div class="pt-3 text-center">
                                        <asp:Button ID="btnResetPassword" runat="server" Text="Reset Password" CssClass="btn btn-info text-white" ValidationGroup="resetPass" OnClick="btnResetPassword_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </form>
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.bundle.min.js"></script>
    <script>
        $(".preloader").fadeOut();
        $("#to-recover").on("click", function () {
            $("#loginform").slideUp();
            $("#recoverform").fadeIn();
        });
        $("#to-login").click(function () {
            $("#recoverform").hide();
            $("#loginform").fadeIn();
        });
    </script>
</body>
</html>
