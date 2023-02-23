<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AddManager.aspx.cs" Inherits="ProjectManagement.Admin.AddManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid"> 
    <div class="card">
        <div class="card-body">
            <div class="dataTables_wrapper">
                <div class="row">
                    <div class="col-sm-7 d-flex mb-5 details">
                        <div class="card-body">
                            <form class="mt-3">
            <section class="body current">
                	<div class="form-group row">
                      <label for="Project" class="col-sm-3 text-center control-label col-form-label">Project</label>
                      <div class="col-sm-6">
                        <asp:DropDownList ID="ddlMProject" runat="server" class="select2 form-select shadow-none" >
                           </asp:DropDownList>
                      </div>
                    </div>
                    <div class="form-group row">
                      <label for="Tname" class="col-sm-3 text-center control-label col-form-label">Team Name</label>
                      <div class="col-sm-6">
                        <asp:DropDownList ID="ddlMTeamName" runat="server" class="select2 form-select shadow-none" >
                           </asp:DropDownList>
                      </div>
                    </div>
                    <div class="form-group row">
                      <label for="Mname" class="col-sm-3 text-center control-label col-form-label">Manager</label>
                      <div class="col-sm-6">
                        <input type="text" class="form-control" id="Mname" placeholder="Manager....">
                      </div>
                    </div>
                </section>
                <div class="text-center">
                    <div class="card-body">
                      <button type="button" class="btn btn-info">
                        Add Manager
                      </button>
                    </div>
                  </div>
          </form>
                        </div>
                    </div>
                </div>
            </div>
            
            <div class="table-responsive">
                        <div class="dataTables_wrapper container-fluid">
                          <div class="row">
                            <div class="col-sm-12 d-flex">
                              <table class="table table-striped table-bordered">
                                <tbody>
                                  <tr>
                                  	<th>Project</th>
                                    <th>Team Name</th>
                                    <th>Manager</th>
                                    <th>Action</th>
                                  </tr>
                                  <tr>
                                    <td>P-1</td>
                                    <td>TN-1</td>
                                    <td>M-1</td>
                                    <td><a href="#" class="link-success"> <span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-pencil-alt fa-stack-1x fa-inverse"></i> </span> </a> <a href="#" class="link-danger"> <span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-trash-alt fa-stack-1x fa-inverse"></i> </span> </a> </td>
                                  </tr>
                                </tbody>
                              </table>
                            </div>
                          </div>
                        </div>
                      </div>
        </div>
    </div>
      
    </div>
</asp:Content>
