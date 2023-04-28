<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="TeamDetails.aspx.cs" Inherits="ProjectManagement.Admin.TeamDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<form class="mt-3" runat="server">--%>
    <div class="page-breadcrumb">
        <div class="dataTables_wrapper container-fluid mb-4">
                <div class="row">
                    <div class="col-sm-12 col-md-3">
                        <div class="dataTables_filter" id="zero_config_length">
                            <label>
                                Project Name
                     
                                <input type="search" class="form-control form-control-sm" placeholder="">
                            </label>
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-3">
                        <div class="dataTables_filter" id="zero_config_length">
                            <label>
                                Team Name
                     
                                <input type="search" class="form-control form-control-sm" placeholder="">
                            </label>
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-3">
                        <div class="dataTables_filter" id="zero_config_length">
                            <label>
                                Employee Name
                     
                                <input type="search" class="form-control form-control-sm" placeholder="">
                            </label>
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-3">
                        <div id="zero_config_filter" class="dataTables_filter"><a href="#" class="link-success">Export to Excel <span class="fa-stack"><i class="fa fa-square fa-stack-2x"></i><i class="fa fa-file-excel fa-stack-1x fa-inverse"></i></span></a></div>
                    </div>
                </div>
            </div>
      <div class="row">
        <div class="col-12 d-flex no-block align-items-center">
          <h4 id="hProjectName" class="page-title">
              <asp:Label ID="lblProject" runat="server" Text="Label"></asp:Label></h4>
          <div class="ms-auto text-end">
            <button type="button" class="btn btn-warning btn-sm">
                    <i class="mdi mdi-chevron-left"></i>Back
            </button>
          </div>
        </div>
      </div>
    </div>
    <div class="container-fluid">
      <div class="row">
        <div class="card">
          <div class="card-body">
        
          <asp:GridView ID="grvViewDetails" DataKeyNames="" runat="server" class="table table-striped table-bordered"  
                                        ShowHeader="true" AutoGenerateColumns="False" EmptyDataText="No Record Found"  EnablePaging="true">
                                <%--<PagerStyle CssClass="" HorizontalAlign="Right" />--%>
                                <%--<PagerSettings PageButtonCount="5" FirstPageText="Previous"  PreviousPageText="1" NextPageText="2" LastPageText="Next"  Mode="Numeric"  />--%>
                                        <Columns>
                                           <%-- <asp:TemplateField HeaderText="Project Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("ProjectName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>--%>

                                            <asp:TemplateField HeaderText="Team Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTeamName" runat="server" Text='<%# Eval("TeamName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Manager Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblManager" runat="server" Text='<%# Eval("ManagerName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Team Leader">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTeamLeader" runat="server" Text='<%# Eval("TeamLeaderName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Employee Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmployee" runat="server" Text='<%# Eval("UserName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <%--<asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEditTeam" class="link-success" CommandName="Edit" runat="server" CommandArgument='<%#Eval("ProjectId")+","+ Eval("TeamId")+","+ Eval("ParrentTeamMemberId")%>'><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-pencil-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                                 <asp:LinkButton ID="btnDeleteEmployee" class="link-danger" CommandName="Delete" runat="server" CommandArgument='<%# Eval("TeamMemberId") %>'><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-trash-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" CssClass="page-link"></ItemStyle>
                                            </asp:TemplateField>--%>
                                        </Columns>
                                </asp:GridView>
 
          </div>
        </div>
      </div>
    </div>
        <%--</form>--%>
</asp:Content>
