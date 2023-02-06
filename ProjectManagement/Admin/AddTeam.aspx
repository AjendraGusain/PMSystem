<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AddTeam.aspx.cs" Inherits="ProjectManagement.Admin.AddTeam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4>Add Team</h4>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="card">
        <div class="card-body wizard-content">
          <form id="AddTeamForm" runat="server" class="mt-3">
            <div class="wizard clearfix">
              <div class="content clearfix">
                <section class="body current">
                  <div class="row">
                    <div class="col-sm-6">
                      <div class="p-3 mb-5 border-end">
                        <div class="form-group">
                          <label for="Tname" class="text-center control-label col-form-label">Team Name</label>
                         <asp:TextBox runat="server" ID="txtTeamName" class="form-control"  placeholder="Team Name...." />
                        </div>
                        <div class="form-group mt-3">
                          <label for="Mname" class="text-center control-label col-form-label">Manager</label>
                          <asp:DropDownList ID="ddlManager" runat="server" class="select2 form-select shadow-none" >
                           </asp:DropDownList>
                        </div>
                        <div class="form-group mt-3">
                          <label for="TLname" class="text-center control-label col-form-label">Team Leader</label>
                          <asp:DropDownList ID="ddlTeamleader" runat="server" class="select2 form-select shadow-none" >
                           </asp:DropDownList>
                        </div>
                        <div class="form-group mt-3">
                          <label for="EMname" class="text-center control-label col-form-label">Employee</label>
                            <asp:ListBox ID="lsEmpoloyee"  runat="server" SelectionMode="Multiple" >
                            <%--<asp:ListItem Text="Mango" Value="1" />
                            <asp:ListItem Text="Apple" Value="2" />
                            <asp:ListItem Text="Banana" Value="3" />
                            <asp:ListItem Text="Guava" Value="4" />
                            <asp:ListItem Text="Orange" Value="5" />--%>
                            </asp:ListBox>
                        </div>
                      </div>
                    </div>
                    <div class="col-sm-6">
                      <div class="mt-3">
                      	<div class="table-responsive">
                        <div class="dataTables_wrapper container-fluid">
                          <div class="row">
                            <div class="col-sm-12 d-flex">
                                <table class="table table-striped table-bordered">
                                <tbody>
                                  <tr>
                                    <th>Team Name</th>
                                    <th>Manager</th>
                                    <th>Team Leader</th>
                                    <th>Employee Name</th>
                                    <th>Role</th>
                                  </tr>
                                  <tr>
                                    <td id="lblTeamName" rowspan="3"></td>
                                    <td id="lblManager" rowspan="3"></td>
                                    <td id="lblTeamLeader" rowspan="3"></td>
                                    <td id="lblEmployeeName"></td>
                                    <td>Admin</td>
                                  </tr>
                                  <tr>
                                    <td id="lblEmployeeName1"></td>

                                    <td>Admin</td>
                                  </tr>
                                  <%--<tr>
                                    <td>Employee-3</td>
                                    <td>Admin</td>
                                  </tr>--%>
                                </tbody>
                              </table>
                            </div>
                          </div>
                        </div>
                      </div>
                      <div class="border-top text-center">
                        <div class="card-body">
                          <asp:Button Text="Add Team" runat="server" ID="btnAddEmployee" OnClick="btnAddEmployee_Click" CssClass="btn btn-info" ValidationGroup="ED" />
                        </div>
                      </div>
                      </div>
                    </div>
                  </div>
                </section>
              </div>
            </div>
          </form>
        </div>
      </div>
</asp:Content>
