<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AddProject.aspx.cs" Inherits="ProjectManagement.Admin.AddProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="card-body wizard-content">
          <form class="mt-3" runat="server">
            <div class="wizard clearfix">
              <div class="content clearfix">
                <section class="body current">
                  <div class="form-group row">
                      <label for="Pname" class="col-sm-3 text-center control-label col-form-label">Project Name</label>
                      <div class="col-sm-6">
                          <asp:TextBox runat="server" ID="txtProjectName" class="form-control" placeholder="Project Name...." />
                      </div>
                    </div>
                    <div class="form-group row">
                      <label for="Cname" class="col-sm-3 text-center control-label col-form-label">Client Name</label>
                      <div class="col-sm-6">
                            <asp:DropDownList ID="ddlClient" runat="server" class="select2 form-select shadow-none"></asp:DropDownList>
                      </div>
                    </div>
                    <div class="form-group row">
                      <label for="Sdate" class="col-sm-3 text-center control-label col-form-label">Start Date</label>
                      <div class="col-sm-6"> 
                        <asp:TextBox ID="txtProjectStartDate" runat="server" class="form-control" placeholder="Start Date...." type="date"></asp:TextBox>
                      </div>
                    </div>
                </section>
                <div class="border-top text-center">
                    <div class="card-body">
                     <asp:Button Text="Add Project" runat="server" ID="btnAddProject" OnClick="btnAddProject_Click" CssClass="btn btn-info" ValidationGroup="AD" />
                    </div>
                  </div>
              </div>
            </div>
          </form>
        </div>
      </div>
</asp:Content>
