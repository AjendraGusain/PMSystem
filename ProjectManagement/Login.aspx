<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjectManagement.Login" %>

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
    <link rel="icon" type="image/png" sizes="16x16" />
    <!-- Custom CSS -->
    <link href="css/style.min.css" rel="stylesheet" />
</head>

<body>
    <section class="background-radial-gradient d-flex" style="min-height: 100vh;">
        <div class="container py-5">
            <div class="row align-items-center justify-content-center">
                <div class="col-sm-6">
                    <div class="card p-5" style="border-radius: 1rem;">
                        <div class="card-body">
                            <div class="text-center mb-5">
                                <img src="images/login-logo.png" alt="logo" class="img-fluid" />
                            </div>
                            <form id="form2" runat="server">

                                <h3 class="fw-normal mb-3 pb-3" style="letter-spacing: 1px;">Log in</h3>

                                <div class="form-outline mb-5">
                                    <label class="form-label sr-only" for="form2Example18">Email address</label>

                                    <asp:TextBox ID="txtUsername" runat="server" onkeypress="setFocus(event)" class="form-control form-control-lg" placeholder="Username"></asp:TextBox>
                                    <asp:Label ID="lblUserName" CssClass="errorMesg" runat="server" ForeColor="Red"></asp:Label>
                                    <asp:RequiredFieldValidator ID="rfvUserName" ControlToValidate="txtUsername" runat="server"
                                        ErrorMessage="User name required!" Display="Dynamic" ValidationGroup="logingroup" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rgvEmail" runat="server" ControlToValidate="txtUsername"
                            ErrorMessage="Incorrect Email"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-outline mb-5">
                                    <label class="form-label sr-only" for="form2Example28">Password</label>

                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" onkeypress="setFocus(event)" class="form-control form-control-lg" placeholder="Password"></asp:TextBox>
                                    <asp:Label ID="lblError" CssClass="errorMesg" runat="server" ForeColor="Red"></asp:Label>
                                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                                        ErrorMessage="Password is required!" Display="Dynamic" ValidationGroup="logingroup" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="pt-1 mb-4 text-center">
                                    <asp:LinkButton runat="server" ID="cmdLogin" class="btn btn-lg btn-success text-white" CommandName="Login" OnClick="cmdLogin_Click" Style="margin-bottom: 15px;" ValidationGroup="logingroup">Submit</asp:LinkButton>
                                </div>
                                <p class="text-center">
                                    <%--<a href="#">Forgot Password?</a>--%>
                                    <asp:LinkButton ID="lnkbtnForgetPassword" runat="server" Text="Forgot Password" ValidationGroup="logingroup"  OnClick="lnkbtnForgetPassword_Click"></asp:LinkButton>
                                </p>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    
</body>
</html>
