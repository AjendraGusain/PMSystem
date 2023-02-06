<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="EmployeeDetail.aspx.cs" Inherits="ProjectManagement.Admin.EmployeeDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:Label runat="server" id="lblName" Text=""></asp:Label>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <div class="table-responsive">
              <div class="dataTables_wrapper container-fluid">
                <div class="row">
                <h4 class="text-center mb-3">Employee Details</h4>
                  <div class="col-sm-6 d-flex mb-5 details">
                    <div class="card-body">
            <div class="row">
              <div class="col-sm-3">
                <lable id="lblEmployee" class="mb-0">Employee Code</lable>
              </div>
              <div class="col-sm-9">
                <asp:Label id="lblEmployeeCode" runat="server" class="text-muted mb-0"></asp:Label>
              </div>
            </div>
            <hr>
            <div class="row">
              <div class="col-sm-3">
                <p class="mb-0">Employee Name</p>
              </div>
              <div class="col-sm-9">
                <asp:Label runat="server" id="lblEmployeeName" class="text-muted mb-0"></asp:Label>
              </div>
            </div>
            <hr>
            <div class="row">
              <div class="col-sm-3">
                <p class="mb-0">Email ID</p>
              </div>
              <div class="col-sm-9">
                <asp:Label runat="server" id="lblEmail" class="text-muted mb-0"></asp:Label>
              </div>
            </div>
            <hr>
            <div class="row">
              <div class="col-sm-3">
                <p class="mb-0">Phone No</p>
              </div>
              <div class="col-sm-9">
                <asp:Label runat="server" id="lblPhoneNo" class="text-muted mb-0"></asp:Label>
              </div>
            </div>
            <hr>
            <div class="row">
              <div class="col-sm-3">
                <p class="mb-0">Role</p>
              </div>
              <div class="col-sm-9">
                <asp:Label runat="server" id="lblRole" class="text-muted mb-0"></asp:Label>
              </div>
            </div>
            <hr>
            <div class="row">
              <div class="col-sm-3">
                <p class="mb-0">Designation</p>
              </div>
              <div class="col-sm-9">
                <asp:Label runat="server" id="lblDesignation" class="text-muted mb-0"></asp:Label>
              </div>
            </div>
          </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="table-responsive">
              <div class="dataTables_wrapper container-fluid">
                <div class="row">
                	<h4>Current Project</h4>
                  <div class="col-sm-12 d-flex">
                    <table class="table table-striped table-bordered">
                      <tbody>
                        <tr>
                          <td>Client Name</td>
                          <td>Project Name</td>
                          <td>Start Date</td>
                          <td><a href="employeeTask.html"><button type="button" class="btn btn-success btn-sm text-white">View Task</button></a></td>
                        </tr>
                      </tbody>
                    </table>
                  </div>
                </div>
              </div>
            </div>
            <div class="table-responsive">
              <div class="dataTables_wrapper container-fluid">
                <div class="row">
                	<h4>Previous Project</h4>
                  <div class="col-sm-12 d-flex">
                    <table class="table table-striped table-bordered">
                      <tbody>
                        <tr>
                          <td>Client Name</td>
                          <td>Project Name</td>
                          <td>Start Date</td>
                          <td>End Date</td>
                        </tr>
                      </tbody>
                    </table>
                  </div>
                </div>
              </div>
            </div>
</asp:Content>
