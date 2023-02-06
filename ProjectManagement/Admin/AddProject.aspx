<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AddProject.aspx.cs" Inherits="ProjectManagement.Admin.AddProject" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                 <section class="body current">
                    <div class="form-group row">
                      <label for="ProjectName" class="col-sm-3 text-center control-label col-form-label">Project Name</label>
                      <div class="col-sm-6">
                          <asp:TextBox runat="server" ID="txtProjectName" class="form-control" placeholder="Enter Project Name" />
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProjectName" ErrorMessage="*" ForeColor="Red" ValidationGroup="AC"></asp:RequiredFieldValidator>
                      </div>
                    </div>
                    <div class="form-group row">
                      <label for="Country" class="col-sm-3 text-center control-label col-form-label">Client Name</label>
                      <div class="col-sm-6">
                        <asp:DropDownList ID="ddlClientID" runat="server" class="select2 form-select shadow-none">
                            </asp:DropDownList>
                      </div>
                    </div>
                      <div class="form-group row">
                      <label for="Country" class="col-sm-3 text-center control-label col-form-label">Start Date</label>
                      <div class="col-sm-6">
                      <asp:TextBox runat="server" ID="txtStartDate" class="form-control" placeholder="dd/MM/yyyy" />
                      </div>
                    </div>
                </section>
                <div class="border-top text-center">
                    <div class="card-body">
                      <asp:Button Text="Add Project" runat="server" ID="btnAddProject" CssClass="btn btn-info" ValidationGroup="AC" OnClick="btnAddProject_Click" />
                    </div>
                  </div>
</asp:Content>
