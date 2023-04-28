<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AddProject.aspx.cs" Inherits="ProjectManagement.Admin.AddProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4>Add Project</h4>
     <div class="ms-auto text-end">
                        <i class="mdi mdi-chevron-left"></i>
                        <input type="submit" name="btnEdit" value="Back" onclick="return Back();" class="btn btn-warning btn-sm" id="btnEdit" />
                    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="card-body wizard-content">
          <%--<form class="mt-3" runat="server">--%>
            <div class="wizard clearfix">
              <div class="content clearfix">
                <section class="body current">
                  <div class="form-group row">
                      <label for="Pname" class="col-sm-3 text-center control-label col-form-label">Project Name</label>
                      <div class="col-sm-6">
                          <asp:TextBox runat="server" ID="txtProjectName" class="form-control" placeholder="Project Name...." />
                          <asp:RequiredFieldValidator ID="rfvProjectName" runat="server" ControlToValidate="txtProjectName" ErrorMessage="*" ForeColor="Red" ValidationGroup="AC"></asp:RequiredFieldValidator>
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
                          <asp:RequiredFieldValidator ID="rfvProjectStartDate" runat="server" ControlToValidate="txtProjectStartDate" ErrorMessage="*" ForeColor="Red" ValidationGroup="AC"></asp:RequiredFieldValidator>
                      </div>
                    </div>
                </section>
                <div class="border-top text-center">
                    <div class="card-body">
                     <asp:Button Text="Add Project" runat="server" ID="btnAddProject" OnClick="btnAddProject_Click" CssClass="btn btn-info" ValidationGroup="AC" />
                    </div>
                  </div>
              </div>
            </div>
          <%--</form>--%>
        </div>
      </div>
     <script language="javascript" type="text/javascript">
        function Back() {
            history.go(-1);
            return false;
        }
     </script>
</asp:Content>
