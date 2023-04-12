<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="EmployeeTask.aspx.cs" Inherits="ProjectManagement.Admin.EmployeeTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form class="mt-3" runat="server">
    <div class="card">
        <div class="card-body">
           
            <div class="dataTables_wrapper">
                 <h4>Current Task</h4>
                <div class="table-responsive">
                    
                    <asp:GridView ID="grvEmployeeTask" DataKeyNames="" runat="server" class="table table-striped table-bordered" AutoGenerateColumns="false" EmptyDataText="No Record Found" OnRowCommand="grvEmployeeTask_RowCommand" >
                                
                                        <Columns>
                                            <asp:TemplateField HeaderText="Task Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("TaskNumber") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Task Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("TaskName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Start Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStartTime" runat="server" Text='<%# Convert.ToDateTime(Eval("StartTime")).ToShortDateString() %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStartDate" runat="server" Text='<%# Eval("StatusName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>


                                            <%--<asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnView" CssClass="btn btn-success btn-sm text-white" CommandName="ViewProject" runat="server" CommandArgument='<%#Eval("ProjectId")+","+ Eval("ClientId")+","+ Eval("UserId")%>'>View</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" CssClass="page-link"></ItemStyle>
                                            </asp:TemplateField>--%>
                                        </Columns>
                       </asp:GridView>

                   
                </div>
            </div>

            <div class="dataTables_wrapper">
                 <h4>Reassigned History</h4>
                <div class="table-responsive">
                    
                    <asp:GridView ID="grvReassign" DataKeyNames="" runat="server" class="table table-striped table-bordered" AutoGenerateColumns="false" EmptyDataText="No Record Found" OnRowCommand="grvEmployeeTask_RowCommand" >
                                
                                        <Columns>
                                            <asp:TemplateField HeaderText="Task Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("TaskNumber") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Task Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("TaskName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Start Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStartTime" runat="server" Text='<%# Convert.ToDateTime(Eval("StartTime")).ToShortDateString() %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStartDate" runat="server" Text='<%# Eval("StatusName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>


                                            <%--<asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnView" CssClass="btn btn-success btn-sm text-white" CommandName="ViewProject" runat="server" CommandArgument='<%#Eval("ProjectId")+","+ Eval("ClientId")+","+ Eval("UserId")%>'>View</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" CssClass="page-link"></ItemStyle>
                                            </asp:TemplateField>--%>
                                        </Columns>
                       </asp:GridView>

                   
                </div>
            </div>
        </div>
    </div>
        </form>
</asp:Content>
