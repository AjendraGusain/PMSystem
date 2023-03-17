<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ProjectDetail.aspx.cs" Inherits="ProjectManagement.Admin.ProjectDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form class="mt-3" runat="server">  
    <div class="row">
        <div class="card">
          <div class="card-body">
            <div class="table-responsive">
              <div class="dataTables_wrapper container-fluid">
                <div class="row">
                	<h4 class="text-center mb-3">Project Details</h4>
                  <div class="col-sm-6 d-flex mb-5 details">
                    <div class="card-body">
            <div class="row">
              <div class="col-sm-3">
                <p class="mb-0">Project Name</p>
              </div>
              <div class="col-sm-9">
                  <asp:Label runat="server" ID="lblProjectName" ></asp:Label>
              </div>
            </div>
            <hr>
            <div class="row">
              <div class="col-sm-3">
                <p class="mb-0">Client Name</p>
              </div>
              <div class="col-sm-9">
                   <asp:Label runat="server" ID="lblClientName" ></asp:Label>
              </div>
            </div>
            <hr>
            <div class="row">
              <div class="col-sm-3">
                <p class="mb-0">Start Date</p>
              </div>
              <div class="col-sm-9">
                    <asp:Label runat="server" ID="lblStartDate" ></asp:Label>
              </div>
            </div>
            <hr>
            <div class="row">
              <div class="col-sm-3">
                <p class="mb-0">End Date</p>
              </div>
              <div class="col-sm-9">
                    <asp:Label runat="server" ID="lblEndDate" ></asp:Label>
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
                	<h4>Current Employee</h4>
                  <div class="col-sm-12 d-flex">
                    <table class="table table-striped table-bordered">
                      <tbody>
                        <tr>
                          <td><a href="employeeDetail.html">Employee Name</a></td>
                          <td>Start Date</td>
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
                	<h4>Previous Employee</h4>
                  <div class="col-sm-12 d-flex">
                    <table class="table table-striped table-bordered">
                      <tbody>
                        <tr>
                          <td><a href="#">Employee Name</a></td>
                          <td>Start Date</td>
                          <td>End Date</td>
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
    </form>
</asp:Content>
