<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ViewTaskDetails.aspx.cs" Inherits="ProjectManagement.Users.ViewTaskDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script type='text/javascript'>
        //function openModal() {
        //    $('[id*=exampleModal]').modal('show');
        //}

        function OpenConfirmationBox() {
            document.getElementById('divShowConfirmwindow').style.display = "block";
            $('#<%=pnlConfirmwindow.ClientID %>').show();
            $("body").addClass("modal-open");

        }

        function HideConfirmWindow() {
            $("#<%=hdnPause.ClientID %>").val("Yes");
            document.getElementById('divShowConfirmwindow').style.display = "none";
            $('#<%=pnlConfirmwindow.ClientID %>').hide();
            $("body").removeClass("modal-open");
            $("#btnSaveReason").click();

        }
    </script>

    <form runat="server">
        <asp:Panel ID="pnlDisplayUserTaskDetails" runat="server">
            <div class="row">
                <div class="card">
                    <div class="card-body">
                        <div class="dataTables_wrapper container-fluid mb-4">
                            <div class="row">
                                <div class="col-sm-12 col-md-6">
                                    <div class="dataTables_filter text-start" id="zero_config_length">
                                        <label>
                                            Search:
                     
                                        <input id="search" type="search" class="form-control form-control-sm" placeholder="">
                                        </label>
                                    </div>
                                </div>
                                <div class="col-sm-12 col-md-6">
                                    <div id="zero_config_filter" class="dataTables_filter"><a href="#" class="link-success">Export to Excel <span class="fa-stack"><i class="fa fa-square fa-stack-2x"></i><i class="fa fa-file-excel fa-stack-1x fa-inverse"></i></span></a></div>
                                </div>
                            </div>
                        </div>

                        <div class="dataTables_wrapper">
                            <div class="row details mb-5 p-5">
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <p class="mb-0">Client Name :</p>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:Label ID="lblClientName" runat="server" class="text-muted mb-0"></asp:Label>
                                        </div>
                                    </div>
                                    <hr>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <p class="mb-0">Task Name :</p>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:Label ID="lblTaskName" runat="server" class="text-muted mb-0"></asp:Label>
                                        </div>
                                    </div>
                                    <hr>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <p class="mb-0">Task# :</p>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:Label ID="lblTaskNumber" runat="server" class="text-muted mb-0"></asp:Label>
                                        </div>
                                    </div>
                                    <hr>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <p class="mb-0">Actual Time :</p>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:Label ID="lblActualTime" runat="server" class="text-muted mb-0"></asp:Label>
                                        </div>
                                    </div>
                                    <hr>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <p class="mb-0">Work in progress :</p>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:Label ID="lblWIP" runat="server" class="text-muted mb-0"></asp:Label>
                                        </div>
                                    </div>
                                    <hr>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <p class="mb-0">Pause :</p>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:Label ID="lblPause" runat="server" class="text-muted mb-0"></asp:Label>
                                        </div>
                                    </div>
                                    <hr>
                                </div>
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <p class="mb-0">Project Name :</p>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:Label ID="lblProjectName" runat="server" class="text-muted mb-0"></asp:Label>
                                        </div>
                                    </div>
                                    <hr>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <p class="mb-0">Start Date :</p>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:Label ID="lblStartDate" runat="server" class="text-muted mb-0"></asp:Label>
                                        </div>
                                    </div>
                                    <hr>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <p class="mb-0">End Date :</p>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:Label ID="lblEndDate" runat="server" class="text-muted mb-0"></asp:Label>
                                        </div>
                                    </div>
                                    <hr>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <p class="mb-0">Task Details :</p>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:Label ID="lblTaskDetails" runat="server" class="text-muted mb-0"></asp:Label>
                                        </div>
                                    </div>
                                    <hr>
                                    <div class="row">
                                        <div class="col-sm-3">

                                            <p class="mb-0">Time Estimate :</p>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:Label ID="lblTimeEstimate" runat="server" class="text-muted mb-0"></asp:Label>
                                        </div>
                                    </div>
                                    <hr>
                                    <div class="row">
                                        <div class="col-sm-3">

                                            <p class="mb-0">Status :</p>
                                        </div>
                                        <div class="col-sm-9">
                                            <asp:DropDownList ID="ddlStatus" runat="server">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">Completed</asp:ListItem>
                                                <asp:ListItem Value="2">Ready for Test</asp:ListItem>
                                                <asp:ListItem Value="3">End of the Day</asp:ListItem>
                                                <asp:ListItem Value="4">Bug Report</asp:ListItem>
                                            </asp:DropDownList>
                                            <%--<select name="languages" id="lang" class="text-muted">
                                <option value="">Select</option>
                                <option value="">Completed</option>
                                <option value="">Ready for Test</option>
                                <option value="">End of the Day</option>
                            </select>--%>
                                        </div>
                                    </div>
                                    <hr>
                                </div>

                                <div class="col-sm-12 mt-3 text-center">
                                    <%--<p><a href=""><span class="btn btn-danger">Play / Pause</span></a></p>--%>
                                    <asp:Button ID="btnPlayTask" CssClass="btn btn-danger" Text="Play" runat="server" OnClick="btnPlayTask_Click" />
                                    <asp:Button ID="btnPauseTask" CssClass="btn btn-danger" Text="Pause" Visible="false" runat="server" OnClick="btnPauseTask_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="table-responsive">
                            <div id="zero_config_wrapper" class="dataTables_wrapper">
                                <h4>Play/Pause History</h4>
                                <div class="row chat-box scrollable" style="height: 250px">
                                    <div class="col-sm-12">
                                        <div class="row">
                                            
                                                
                                                    <asp:GridView ID="grvDisplayUserTaskDetails" runat="server" class="table table-striped table-bordered" AllowPaging="true"
                                                        PageSize="40" ShowHeader="true" AutoGenerateColumns="False" EmptyDataText="No Record Found"
                                                        OnRowCommand="grvDisplayUserTaskDetails_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Date">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDate" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Start">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStart" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Pause">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPause" runat="server" Text='<%#Eval("Pause") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Resume">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblResume" runat="server" Text='<%#Eval("Resume") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Break">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBreak" runat="server" Text='<%#Eval("Break") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Reason">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblReason" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            
                                        
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="table-responsive">
                            <div id="zero_config_wrapper" class="dataTables_wrapper">
                                <h4>Bug History</h4>
                                <div class="row chat-box scrollable" style="height: 250px">
                                    <div class="col-sm-12">
                                        <div class="row">
                                            <div class="col-sm-6 d-flex mb-5 details">
                                                <div class="card-body">
                                                    <asp:GridView ID="gvDisplayBugHistory" runat="server" class="table table-striped table-bordered" AllowPaging="true"
                                                        PageSize="40" ShowHeader="true" AutoGenerateColumns="False" EmptyDataText="No Record Found"
                                                        OnRowCommand="gvDisplayBugHistory_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Tester Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTesterName" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStartTime" runat="server" Text='<%#Eval("StartTime") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Bug Details">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBugDetails" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div id="divShowConfirmwindow" style="display: none; opacity: 0.5;" class="modal-backdrop">
                            </div>
                            <asp:Panel ID="pnlConfirmwindow" runat="server" BackColor="#ddd" CssClass="modal" Style="background: transparent!important;">
                                <div class="modal-dialog modal-sm" style="margin-top: 8%; min-width: 40%;">
                                    <div class="modal-content">
                                        <div class="modal-body">
                                            <div class="row">
                                                <asp:DropDownList ID="ddlReason" runat="server" Enabled="true">
                                                    <asp:ListItem Value="0">--Select Reason--</asp:ListItem>
                                                    <asp:ListItem Value="1">Lunch Break</asp:ListItem>
                                                    <asp:ListItem Value="2">Tea Break</asp:ListItem>
                                                    <asp:ListItem Value="3">Other:</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" CssClass="form-control"
                                                    placeholder="Enter Text"></asp:TextBox>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-12 text-center">
                                                    <asp:Button Style="" runat="server" Text="Submit" class="btn btn-info" ID="btnSaveReason" OnClientClick="HideConfirmWindow();return false; " ClientIDMode="Static" OnClick="btnSaveReason_Click" />
                                                    <asp:Button Style="" runat="server" Text="Close" class="btn btn-danger" ID="btnClose" OnClientClick="HideConfirmWindow1();return false; " ClientIDMode="Static" OnClick="btnClose_Click" />
                                                    <asp:HiddenField ID="hdnPause" ClientIDMode="Static" runat="server"></asp:HiddenField>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
 

                        <div class="row">
                            <div class="col-12">
                                <div class="card">
                                    <div class="card-body">
                                        <h4 class="card-title">Chat Option</h4>
                                        <div class="chat-box scrollable">
                                            <asp:ListView ID="lstViewChatBox" runat="server">
                                                <LayoutTemplate>
                                                    <ul style="list-style: none; padding-left: 0" class="chat-list">
                                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                                    </ul>
                                                </LayoutTemplate>
                                                <ItemTemplate>
                                                    <li class="chat-item">
                                                        <div class="chat-img">
                                                        </div>
                                                        <div class="chat-content">
                                                            <h6 cssclass="font-medium">
                                                                <asp:Label ID="lblUser" runat="server" Text='<%#Eval("UserName")%>'></asp:Label>
                                                            </h6>

                                                            <div class="box bg-light-info">
                                                                <asp:Label ID="lblComment" runat="server" Text='<%#Eval("TaskComment")%>'></asp:Label>
                                                            </div>
                                                        </div>
                                                        <asp:Label ID="lblCommentTime" CssClass="chat-time" runat="server" Text='<%#Eval("CommentDate")%>'></asp:Label>
                                                    </li>
                                                </ItemTemplate>
                                                <EmptyDataTemplate>
                                                    <p>Nothing here.</p>
                                                </EmptyDataTemplate>
                                            </asp:ListView>
                                        </div>
                                    </div>
                                    <div class="card-body border-top">
                                        <div class="row">
                                            <div class="col-9">
                                                <div class="input-field mt-0 mb-0">
                                                    <asp:TextBox ID="txtChatDescription" runat="server" class="form-control border-0" TextMode="MultiLine" Placeholder="Type and enter"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-3">
                                                <asp:Button ID="btnSendDescription" runat="server" Text="Send" class="btn-lg btn-cyan float-end text-white" OnClick="btnSendDescription_Click" />
                                                <%--<a class="btn-circle btn-lg btn-cyan float-end text-white" href="javascript:void(0)"><i class="mdi mdi-send fs-3"></i></a>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </form>
</asp:Content>
