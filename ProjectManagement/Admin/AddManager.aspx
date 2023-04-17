<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AddManager.aspx.cs" Inherits="ProjectManagement.Admin.AddManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4>Add Manager</h4>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form class="mt-3" runat="server">
    <div class="container-fluid"> 
    <div class="card">
        <div class="card-body">
            <div class="dataTables_wrapper">
                <div class="row">
                    <div class="col-sm-7 d-flex mb-5 details">
                        <div class="card-body">
                            
            <section class="body current">
                	<div class="form-group row">
                      <label for="Project" class="col-sm-3 text-center control-label col-form-label">Project</label>
                      <div class="col-sm-6">
                        <asp:DropDownList ID="ddlMProject" runat="server" class="select2 form-select shadow-none" OnSelectedIndexChanged="ddlMProject_SelectedIndexChanged" AutoPostBack="true" >
                           </asp:DropDownList>
                          <asp:RequiredFieldValidator ID="rvProject" runat="server" ControlToValidate="ddlMProject" InitialValue="0" ErrorMessage="Select Project" ValidationGroup="ED" ForeColor="Red"></asp:RequiredFieldValidator>
                      </div>
                    </div>
                    <div class="form-group row">
                      <label for="Tname" class="col-sm-3 text-center control-label col-form-label">Team Name</label>
                      <div class="col-sm-6">
                        <asp:DropDownList ID="ddlMTeamName" runat="server" class="select2 form-select shadow-none" OnSelectedIndexChanged="ddlMTeamName_SelectedIndexChanged" AutoPostBack="true" >
                           </asp:DropDownList>
                          <asp:RequiredFieldValidator ID="rvTeamName" runat="server" ControlToValidate="ddlMTeamName" InitialValue="0" ErrorMessage="Select Team" ValidationGroup="ED" ForeColor="Red"></asp:RequiredFieldValidator>
                      </div>
                    </div>
                    <div class="form-group row">
                      <label for="Mname" class="col-sm-3 text-center control-label col-form-label">Manager</label>
                      <div class="col-sm-6">
                        <asp:ListBox ID="lsManager" runat="server" data-live-search="true" SelectionMode="Multiple" CssClass="form-control js-example-placeholder-single" >
                                    </asp:ListBox>
                          <asp:RequiredFieldValidator ID="rvManager" runat="server" ControlToValidate="lsManager" ErrorMessage="Select Manager" ValidationGroup="ED" ForeColor="Red"></asp:RequiredFieldValidator>
                      </div>
                    </div>
                </section>
                <div class="text-center">
                    <div class="card-body">
                      <asp:Button Text="Add Manager" runat="server" ID="btnAddTeamName" OnClick="btnAddTeamName_Click" CssClass="btn btn-info" ValidationGroup="ED" />
                    </div>
                  </div>
                        </div>
                    </div>
                </div>
            </div>
            
           
                              <asp:GridView ID="grvViewManager" DataKeyNames="" runat="server" class="table table-striped table-bordered"  
                                        ShowHeader="true" AutoGenerateColumns="False" EmptyDataText="No Record Found"  EnablePaging="true" OnRowCommand="grvViewManager_RowCommand"
                                  OnRowEditing="grvViewManager_RowEditing" OnRowDeleting="grvViewManager_RowDeleting" >
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

                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEditTeam" class="link-success" CommandName="EditManager" runat="server" CommandArgument='<%#Eval("ProjectId")+","+ Eval("TeamId")%>'><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-pencil-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                                 <asp:LinkButton ID="btnDeleteEmployee" class="link-danger" CommandName="DeleteManager" runat="server" CommandArgument='<%#Eval("ProjectId")+","+ Eval("TeamId")+","+ Eval("UserId")+","+ Eval("TeamMemberId")%>' OnClientClick="return confirm('Are you sure you want to delete this record?');"><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-trash-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" CssClass="page-link"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                </asp:GridView>
                        
        </div>
    </div>
      
    </div>
    </form>
</asp:Content>
