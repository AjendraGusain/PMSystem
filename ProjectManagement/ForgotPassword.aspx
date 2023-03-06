<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="ProjectManagement.ForgotPassword" %>

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
    <div class="main-wrapper">
      <!-- ============================================================== -->
      <!-- Preloader - style you can find in spinners.css -->
      <!-- ============================================================== -->
      <div class="preloader">
        <div class="lds-ripple">
          <div class="lds-pos"></div>
          <div class="lds-pos"></div>
        </div>
      </div>
      <!-- ============================================================== -->
      <!-- Preloader - style you can find in spinners.css -->
      <!-- ============================================================== -->
      <!-- ============================================================== -->
      <!-- Login box.scss -->
      <!-- ============================================================== -->
      <div class="d-flex justify-content-center align-items-center bg-cyan px-5" style="height: 100vh;">
        <div id="loginform" class="row">
            <div class="col-12 text-center pt-3 pb-3">
              <span class="db"><img src="images/logo-text.png" alt="logo"/></span>
            </div>
            <!-- Form -->
            <form class="form-horizontal mt-3" action="#" runat="server">
              <div class="row pb-4">
              	<h4 class="text-white">Lost Password</h4>
                <div class="col-12">
                  <div class="input-group mb-3">
                    <%--<input type="email" class="form-control form-control-lg" placeholder="Type Your Email-ID.." aria-describedby="basic-addon1"
                      required=""/>--%>
                      <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-lg" placeholder="Type Your Email-ID.."></asp:TextBox>
                      <asp:RegularExpressionValidator ID="rgvEmail" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Incorrect Email"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" ForeColor="White" ValidationGroup="forgotPass"></asp:RegularExpressionValidator>
                  </div>
                </div>
              </div>
              <div class="row border-top border-secondary">
                <div class="col-12">
                  <div class="form-group">
                    <div class="pt-3 text-center">
                      <%--<button class="btn btn-info text-white" type="submit">
                        Lost Password
                      </button>--%>
                        <asp:Button ID="btnForgotPassword" runat="server" Text="Lost Password" ValidationGroup="forgotPass" OnClick="btnForgotPassword_Click" />
                    </div>
                  </div>
                </div>
              </div>
            </form>
          </div>
      </div>
      <!-- ============================================================== -->
      <!-- Login box.scss -->
      <!-- ============================================================== -->
      <!-- ============================================================== -->
      <!-- Page wrapper scss in scafholding.scss -->
      <!-- ============================================================== -->
      <!-- ============================================================== -->
      <!-- Page wrapper scss in scafholding.scss -->
      <!-- ============================================================== -->
    </div>
    <!-- ============================================================== -->
    <!-- All Required js -->
    <!-- ============================================================== -->
    <script src="js/jquery.min.js"></script>
    <!-- Bootstrap tether Core JavaScript -->
    <script src="js/bootstrap.bundle.min.js"></script>
    <!-- ============================================================== -->
    <!-- This page plugin js -->
    <!-- ============================================================== -->
    <script>
      $(".preloader").fadeOut();
      // ==============================================================
      // Login and Recover Password
      // ==============================================================
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
