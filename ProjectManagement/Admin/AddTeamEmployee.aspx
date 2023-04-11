<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AddTeamEmployee.aspx.cs" Inherits="ProjectManagement.Admin.AddTeamEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form class="mt-3" runat="server">
    <div class="container-fluid"> 
    <div class="card">
        <div class="card-body">
            <asp:Panel ID="pnlHideForm" runat="server" Visible="false">
            <div class="dataTables_wrapper">
                <div  class="row">
                    <div class="col-sm-7 d-flex mb-5 details">
                        <div class="card-body">
                            
            <section class="body current">
                	<div class="form-group row">
                      <label for="Project" class="col-sm-3 text-center control-label col-form-label">Project</label>
                      <div class="col-sm-6">
                        <asp:DropDownList ID="ddlMProject" runat="server" class="select2 form-select shadow-none" OnSelectedIndexChanged="ddlMProject_SelectedIndexChanged" AutoPostBack="true" >
                           </asp:DropDownList>
                      </div>
                    </div>
                    <div class="form-group row">
                      <label for="Tname" class="col-sm-3 text-center control-label col-form-label">Team Name</label>
                      <div class="col-sm-6">
                        <asp:DropDownList ID="ddlMTeamName" runat="server" class="select2 form-select shadow-none" OnSelectedIndexChanged="ddlMTeamName_SelectedIndexChanged" AutoPostBack="true" >
                           </asp:DropDownList>
                      </div>
                    </div>

                <div class="form-group row">
                      <label for="Tname" class="col-sm-3 text-center control-label col-form-label">Manager</label>
                      <div class="col-sm-6">
                        <asp:DropDownList ID="ddlManager" runat="server" class="select2 form-select shadow-none" OnSelectedIndexChanged="ddlManager_SelectedIndexChanged" AutoPostBack="true">
                           </asp:DropDownList>
                      </div>
                    </div>

                <div class="form-group row">
                      <label for="Tname" class="col-sm-3 text-center control-label col-form-label">Team Leader</label>
                      <div class="col-sm-6">
                        <asp:DropDownList ID="ddlTeamLeader" runat="server" class="select2 form-select shadow-none" OnSelectedIndexChanged="ddlTeamLeader_SelectedIndexChanged" AutoPostBack="true" >
                           </asp:DropDownList>
                      </div>
                    </div>

                    <div class="form-group row">
                      <label for="Mname" class="col-sm-3 text-center control-label col-form-label">Developer</label>
                      <div class="col-sm-6">
                        <asp:ListBox ID="lsEmployee" runat="server" data-live-search="true" SelectionMode="Multiple" CssClass="form-control js-example-placeholder-single" >
                                    </asp:ListBox>

                      </div>
                    </div>

                <div class="form-group row">
                      <label for="Mname" class="col-sm-3 text-center control-label col-form-label">Tester</label>
                      <div class="col-sm-6">
                        <asp:ListBox ID="lsTester" runat="server" data-live-search="true" SelectionMode="Multiple" CssClass="form-control js-example-placeholder-single" >
                                    </asp:ListBox>

                      </div>
                    </div>
                </section>
                <div class="text-center">
                    <div class="card-body">
                      <asp:Button Text="Add Employee" runat="server" ID="btnAddEmployee" OnClick="btnAddEmployee_Click" CssClass="btn btn-info" ValidationGroup="ED" />
                    </div>
                  </div>
                        </div>
                    </div>
                </div>
            </div>
            </asp:Panel>
            <asp:Panel ID="pnlHideGrid" Visible="true" runat="server">
           
                              <asp:GridView ID="grvViewEmployee" DataKeyNames="" runat="server" class="table table-striped table-bordered"  
                                        ShowHeader="true" AutoGenerateColumns="False" EmptyDataText="No Record Found"  EnablePaging="true" OnRowCommand="grvViewEmployee_RowCommand" OnRowEditing="grvViewEmployee_RowEditing" 
                                  OnRowDeleting="grvViewEmployee_RowDeleting">
                                <%--<PagerStyle CssClass="" HorizontalAlign="Right" />--%>
                                <%--<PagerSettings PageButtonCount="5" FirstPageText="Previous"  PreviousPageText="1" NextPageText="2" LastPageText="Next"  Mode="Numeric"  />--%>
                                        <Columns>
                                            <asp:TemplateField HeaderText="Project Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("ProjectName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

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

                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEditTeam" class="link-success" CommandName="Edit" runat="server" CommandArgument='<%#Eval("ProjectId")+","+ Eval("TeamId")+","+ Eval("ParrentTeamMemberId")%>'><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-pencil-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                                 <asp:LinkButton ID="btnDeleteEmployee" class="link-danger" CommandName="Delete" runat="server" CommandArgument='<%# Eval("TeamMemberId") %>'><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-trash-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" CssClass="page-link"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                </asp:GridView>
                        </asp:Panel>
        </div>
    </div>
      
    </div>
    </form>
</asp:Content>
