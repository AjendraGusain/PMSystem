<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="UserTask.aspx.cs" Inherits="ProjectManagement.Users.UserTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4>My Task</h4>
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

    
        <div class="table-responsive">
            <div id="zero_config_wrapper" class="dataTables_wrapper container-fluid">
                <div class="row">
                    <div class="card">
                        <div class="card-body">
                            <div class="dataTables_wrapper mb-9">
                                <div class="row">
                                    <%--<div class="col-sm-12 col-md-3">
                                        <div class="dataTables_filter" id="zero_config_length">
                                            <label>
                                                Client Name
                                                <input type="search" class="form-control form-control-sm" placeholder="">
                                                <asp:DropDownList ID="ddlSearchClient" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlSearchClient_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </label>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-3">
                                        <div class="dataTables_filter" id="zero_config_length">
                                            <label>
                                                Project Name
                                                <input type="search" class="form-control form-control-sm" placeholder="">
                                                <asp:DropDownList ID="ddlSerachProject" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlSerachProject_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </label>
                                        </div>
                                    </div>--%>
                                    <div class="col-sm-12 col-md-2">
                                        <div class="dataTables_filter" id="zero_config_length">
                                            <label>
                                                Search
                                               <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-sm" placeholder="Search.."></asp:TextBox>
                                                <%--<input type="search" class="form-control form-control-sm" placeholder="">--%>
                                                <%--<asp:DropDownList ID="ddlSearchStatus" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlSearchStatus_SelectedIndexChanged">
                                                </asp:DropDownList>--%>
                                            </label>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-6">
                                        <div id="zero_config_filter" class="dataTables_filter">
                                            <label>
                                                Date Range:
                                               
                                                <%--<input id="start" class="form-control form-control-sm" placeholder="Start Date">--%>
                                                <asp:TextBox ID="txtSearchStartDate" runat="server" CssClass="form-control form-control-sm" placeholder="Start Date.." type="date"></asp:TextBox>
                                            </label>
                                            <label>
                                                to
                                               
                                                <%--<input id="end" class="form-control form-control-sm" placeholder="End Date">--%>
                                                <asp:TextBox ID="txtSearchEndDate" runat="server" CssClass="form-control form-control-sm" placeholder="End Date.." type="date"></asp:TextBox>
                                            </label>
                                            <asp:Button ID="btnSearchStartEnd" runat="server" Text="Search" CssClass="form-control form-control-sm" OnClick="btnSearchStartEnd_Click" />
                                            <asp:Button ID="btnCancelStartEnd" runat="server" Text="Clear Search" CssClass="form-control form-control-sm" OnClick="btnCancelStartEnd_Click" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-3">
                                        <div id="zero_config_filter" class="dataTables_filter"><a href="#" class="link-success"><span class="fa-stack"><i class="fa fa-square fa-stack-2x"></i><i class="fa fa-file-excel fa-stack-1x fa-inverse"></i></span></a></div>
                                    </div>
                                    
                                </div>
                            </div>
                            <div id="zero_config_wrapper" class="dataTables_wrapper">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:Panel ID="pnlDisplayUserTask" runat="server">
                                            <asp:GridView ID="gvDisplayUserTask" runat="server" OnRowCommand="gvDisplayUserTask_RowCommand" class="table table-striped table-bordered"
                                                AutoGenerateColumns="false" AutoGenerateDeleteButton="false" AutoGenerateEditButton="false" AutoGenerateSelectButton="false"
                                                OnRowDataBound="gvDisplayUserTask_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField DataField="TeamId" HeaderText="" Visible="false"/>
                                                    <asp:BoundField DataField="TeamMemberId" HeaderText="" Visible="false"/>
                                                    <asp:BoundField DataField="ClientName" HeaderText="Client Name" />
                                                    <asp:BoundField DataField="ProjectName" HeaderText="Project Name" />
                                                    <asp:BoundField DataField="TaskNumber" HeaderText="Task#" />
                                                    <asp:BoundField DataField="StartDate" HeaderText="Start Date" DataFormatString = "{0:MM/dd/yyyy}" />
                                                    <asp:BoundField DataField="EndDate" HeaderText="End Date" DataFormatString = "{0:MM/dd/yyyy}"/>
                                                    <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnViewUserTask" CommandName="ViewUserTask" runat="server" CommandArgument='<%#Eval("TaskId")+","+Eval("ProjectId")+", "+Eval("ClientId")%>' class="badge bg-info"><span class="fa-stack">  <i class="fa fa-eye fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                                            <%--+", "+Eval("TeamId")+", "+Eval("TeamMemberId")--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Assign/Play/Pause">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkbtnAssign" runat="server" Text="Assign" CssClass="badge bg-success" CommandName="AssignUserTask" CommandArgument='<%#Eval("TaskId")+","+Eval("TaskNumber")+","+Eval("ProjectId")+", "+Eval("ClientId")%>'></asp:LinkButton>
                                                            <%--+", "+Eval("TeamId")+", "+Eval("TeamMemberId")--%>
                                                            <asp:LinkButton ID="lnkbtnPlay" runat="server" Text="Play" CommandName="PlayTask" CommandArgument='<%#Eval("TaskId")+","+Eval("ProjectId")+", "+Eval("ClientId")%>' CssClass="btn btn-danger badge"><span class="fa-stack">  <i class="fa fa-play fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                                            <%--+", "+Eval("TeamId")+", "+Eval("TeamMemberId")--%>
                                                            <asp:LinkButton ID="lnkbtnPause" runat="server" Text="Pause" CommandName="PauseTask" CommandArgument='<%#Eval("TaskId")+","+Eval("ProjectId")+", "+Eval("ClientId")%>' CssClass="btn btn-danger badge"><span class="fa-stack">  <i class="fa fa-pause fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                                            <%--+", "+Eval("TeamId")+", "+Eval("TeamMemberId")--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="StatusName" HeaderText="Status" />
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
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
                        </div>
                    </div>
                </div>
            </div>
        </div>
    
</asp:Content>
