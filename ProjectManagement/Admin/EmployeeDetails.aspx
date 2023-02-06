<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="ProjectManagement.Admin.EmployeeDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="page-wrapper">
    <div class="page-breadcrumb">
      <div class="row">
        <div class="col-12 d-flex no-block align-items-center">
          <h4 class="page-title">View All Employee</h4>
        </div>
      </div>
    </div>
    <div class="container-fluid">
      <div class="row">
        <div class="card">
          <div class="card-body">
            <div class="dataTables_wrapper container-fluid mb-4">
              <div class="row">
                <div class="col-sm-12 col-md-2">
                  <div class="dataTables_length" id="zero_config_length">
                    <label>Record
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
                    <label>Search:
                      <input type="search" class="form-control form-control-sm" placeholder="">
                    </label>
                  </div>
                </div>
                <div class="col-sm-12 col-md-5">
                  <div id="zero_config_filter" class="dataTables_filter">
                    <label> Date Range:
                      <input id="start" class="form-control form-control-sm" placeholder="Start Date" />
                    </label>
                    <label> to
                      <input id="end" class="form-control form-control-sm" placeholder="End Date" />
                    </label>
                    </label>
                  </div>
                </div>
                <div class="col-sm-12 col-md-2">
                  <div id="zero_config_filter" class="dataTables_filter"> <a href="#" class="link-success">Export to Excel <span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-file-excel fa-stack-1x fa-inverse"></i> </span></a> </div>
                </div>
              </div>
            </div>
            <div class="table-responsive">
              <div id="zero_config_wrapper" class="dataTables_wrapper container-fluid">
                <div class="row">
                  <div class="col-sm-12 d-flex" runat="server">
                      <form id="form1" runat="server">
                      <asp:GridView ID="grvEmployeeDetails" DataKeyNames="" runat="server" class="table table-striped table-bordered" AllowPaging="true" PageSize="40" 
                                ShowHeader="true" AutoGenerateColumns="False" EmptyDataText="No Record Found"  OnRowCommand="grvEmployeeDetails_RowCommand" >
                                <Columns>
                                <asp:TemplateField HeaderText="Employee Code"  HeaderStyle-Width="5%" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPolicyNumber" runat="server" Text='<%# Eval("EmployeeCode") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Employee Name"  HeaderStyle-Width="5%" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("UserName") %>' ItemStyle-HorizontalAlign="Right" ></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Email"  HeaderStyle-Width="4%" ItemStyle-Width="4%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPolicyDate" runat="server" Text='<%# Eval("PhoneNumber") %>' ItemStyle-HorizontalAlign="Right" ></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Phone Number"  HeaderStyle-Width="5%" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInsuredName" runat="server" Text='<%# Eval("Email") %>' ItemStyle-HorizontalAlign="Right" ></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Role"  HeaderStyle-Width="5%" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("RoleId") %>' ItemStyle-HorizontalAlign="Right" ></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Designation"  HeaderStyle-Width="5%" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Designation") %>' ItemStyle-HorizontalAlign="Right" ></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>

                                    <asp:TemplateField HeaderText="View"  HeaderStyle-Width="1.9%" ItemStyle-Width="2%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnViewEmployee" runat="server" CommandName="ViewEmployeeDetail" class="link-info"> <span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-eye fa-stack-1x fa-inverse"></i> </span> </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Edit"  HeaderStyle-Width="1.9%" ItemStyle-Width="2%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditEmployee" runat="server" CommandName="EditEmployeeDetail" class="link-success"><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-pencil-alt fa-stack-1x fa-inverse"></i> </span> </asp:LinkButton> 
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Delete"  HeaderStyle-Width="1.6%" ItemStyle-Width="2%">
                                    <ItemTemplate>
                                            <asp:LinkButton ID="btnDeleteEmployee" runat="server" CommandName="DeleteEmployeeDetail" href="#" class="link-danger"> 
                                            <span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-trash-alt fa-stack-1x fa-inverse"></i> </span> 
                                            </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                            </asp:GridView>
                          </form>
                  </div>
                </div>
                <div class="row">
                  <div class="col-sm-12 col-md-5">
                    <div class="dataTables_info" id="zero_config_info" role="status" aria-live="polite">Showing 1 to 10 of 57 entries</div>
                  </div>
                  <div class="col-sm-12 col-md-7">
                    <div class="dataTables_paginate paging_simple_numbers" id="zero_config_paginate">
                      <ul class="pagination">
                        <li class="paginate_button page-item previous disabled" id="zero_config_previous"><a href="#" aria-controls="zero_config" data-dt-idx="0" tabindex="0" class="page-link">Previous</a></li>
                        <li class="paginate_button page-item active"><a href="#" aria-controls="zero_config" data-dt-idx="1" tabindex="0" class="page-link">1</a></li>
                        <li class="paginate_button page-item "><a href="#" aria-controls="zero_config" data-dt-idx="2" tabindex="0" class="page-link">2</a></li>
                        <li class="paginate_button page-item next" id="zero_config_next"><a href="#" aria-controls="zero_config" data-dt-idx="7" tabindex="0" class="page-link">Next</a></li>
                      </ul>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <footer class="footer text-center"> All Rights Reserved </footer>
  </div>
</div>
</asp:Content>
