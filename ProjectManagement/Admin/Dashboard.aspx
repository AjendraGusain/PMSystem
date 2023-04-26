<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ProjectManagement.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4>Dashboard</h4>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
    <div class="row">
        <!-- Column -->
        <div class="col-md-6 col-lg-3">
            <div class="card card-hover">
                <div class="box bg-cyan text-center">
                    <h1 class="font-light text-white">10 </h1>
                    <h6 class="text-white">Completed Task</h6>
                </div>
            </div>
        </div>
        <!-- Column -->
        <div class="col-md-6 col-lg-3">
            <div class="card card-hover">
                <div class="box bg-success text-center">
                    <h1 class="font-light text-white">12</h1>
                    <h6 class="text-white">Unassigned Task</h6>
                </div>
            </div>
        </div>
        <!-- Column -->
        <div class="col-md-6 col-lg-3">
            <div class="card taskInfo">
                <a href="#">
                    <div class="box text-center">
                        <h1 class="font-light text-white">8</h1>
                        <h6 class="text-white">Active Task</h6>
                    </div>
                </a>
            </div>
        </div>
        <!-- Column -->
        <div class="col-md-6 col-lg-3">
            <div class="card card-hover">
                <div class="box bg-danger text-center">
                    <h1 class="font-light text-white">5</h1>
                    <h6 class="text-white">Overdue Task</h6>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="card">
            <div class="card-body">
                <h5 class="card-title">Task List</h5>
                <div class="dataTables_wrapper container-fluid mb-4">
                    <div class="row">
                        <div class="col-sm-12 col-md-2">
                            <div class="dataTables_length" id="zero_config_length">
                                <label>
                                    Record
                      <select name="zero_config_length" aria-controls="zero_config" class="form-control form-control-sm">
                          <option value="10">10</option>
                          <option value="25">25</option>
                          <option value="50">50</option>
                          <option value="100">100</option>
                      </select>
                                </label>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-3">
                            <div id="zero_config_filter" class="dataTables_filter">
                                <label>
                                    Search:
                      <input type="search" class="form-control form-control-sm" placeholder="">
                                </label>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-5">
                            <div id="zero_config_filter" class="dataTables_filter">
                                <label>
                                    Date Range:
                      <input id="start" class="form-control form-control-sm" placeholder="Start Date" />
                                </label>
                                <label>
                                    to
                      <input id="end" class="form-control form-control-sm" placeholder="End Date" />
                                </label>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-2">
                            <div id="zero_config_filter" class="dataTables_filter"><a href="#" class="link-success">Export to Excel <span class="fa-stack"><i class="fa fa-square fa-stack-2x"></i><i class="fa fa-file-excel fa-stack-1x fa-inverse"></i></span></a></div>
                        </div>
                    </div>
                </div>
                <div id="zero_config_wrapper" class="dataTables_wrapper container-fluid">
                                    <div class="table-responsive">
                                    
                                        <asp:GridView ID="grvDashboard" DataKeyNames="" runat="server" class="table table-striped table-bordered" PageSize="2"
                                            ShowHeader="true" AutoGenerateColumns="False" EmptyDataText="No Record Found" EnablePaging="true">
                                            <PagerStyle CssClass="" HorizontalAlign="Right" />
                                            <PagerSettings PageButtonCount="5" FirstPageText="Previous" PreviousPageText="1" NextPageText="2" LastPageText="Next" Mode="Numeric" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Client Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClientName" runat="server" Text='<%# Eval("ClientName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Project Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("ProjectName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Task Id">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTaskID" runat="server" Text='<%# Eval("TaskId") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Task Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTaskNumber" runat="server" Text='<%# Eval("TaskName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Time Estimate">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEstimate" runat="server" Text='<%# Eval("EstimateTime") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <%--                                            <asp:TemplateField HeaderText="Start Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("StartDate") , "{00:00}"%>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>--%>

                                                <asp:TemplateField HeaderText="StartTime">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStartTime" runat="server" Text='<%# Eval("StartTime", "{0:t}") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="EndTime">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEndTime" runat="server" Text='<%# Eval("EndTime", "{0:t}") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Employee Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmpName" runat="server" Text='<%# Eval("UserName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("StatusName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <%--                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnViewEmployee" CssClass="link-info" CommandName="ViewEmployee" runat="server" CommandArgument='<%# Eval("UserId") %>'><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-eye fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                                    <asp:LinkButton ID="btnEditEmployee" class="link-success" CommandName="EditEmployee" runat="server" CommandArgument='<%# Eval("UserId") %>'><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-pencil-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                                    <asp:LinkButton ID="btnDeleteEmployee" class="link-danger" CommandName="DeleteEmployee" runat="server" CommandArgument='<%# Eval("UserId") %>'><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-trash-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" CssClass="page-link"></ItemStyle>
                                            </asp:TemplateField>--%>
                                                <%--                                             <asp:TemplateField>
            <ItemTemplate>
                <asp:CheckBox ID="myCb" runat="server" Text='Hi'/>
                <ul id="myUnorderedList" runat="server" Visible="True">
                    <li>
                        <asp:TextBox ID="myTb" runat="server" Width="300" />
                    </li>
                </ul>
            </ItemTemplate>
        </asp:TemplateField>--%>
                                            </Columns>

                                        </asp:GridView>
                                    
                                </div>
                            </div>

            </div>
        </div>
    </div>
</form>
</asp:Content>
