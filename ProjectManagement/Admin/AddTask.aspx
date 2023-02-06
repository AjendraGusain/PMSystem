<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AddTask.aspx.cs" Inherits="ProjectManagement.Admin.addTask" %>
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
                      <label for="Cname" class="col-sm-3 text-center control-label col-form-label">Client Name</label>
                      <div class="col-sm-6">
                          <asp:DropDownList ID="ddlClientName" runat="server" CssClass="select2 form-select shadow-none" AutoPostBack="true" OnSelectedIndexChanged="ddlClientName_SelectedIndexChanged"></asp:DropDownList>
                      <asp:RequiredFieldValidator ID="rfvClientName" ErrorMessage="Required" ControlToValidate="ddlClientName" InitialValue="0" runat="server" ValidationGroup="val" ForeColor="Red" />
                      </div>
                        
                    </div>
                    <div class="form-group row">
                      <label for="Pname" class="col-sm-3 text-center control-label col-form-label">Project Name</label>
                      <div class="col-sm-6">
                          <asp:DropDownList ID="ddlProjectName" runat="server" CssClass="select2 form-select shadow-none"></asp:DropDownList>
                          <asp:RequiredFieldValidator ID="rfvProjectName" ErrorMessage="Required" ControlToValidate="ddlProjectName" InitialValue="0" runat="server" ValidationGroup="val" ForeColor="Red" />
                      </div>
                    </div>
                    <div class="form-group row">
                      <label for="Tid" class="col-sm-3 text-center control-label col-form-label">Task ID</label>
                      <div class="col-sm-6">
                          <asp:TextBox ID="txtTaskID" runat="server" CssClass="form-control"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="rfvTaskID" ErrorMessage="Required" ControlToValidate="txtTaskID" runat="server" ValidationGroup="val" ForeColor="Red" />
                      </div>
                    </div>
                    <div class="form-group row">
                      <label for="Tname" class="col-sm-3 text-center control-label col-form-label">Task Name</label>
                      <div class="col-sm-6">
                          <asp:TextBox ID="txtTaskName" runat="server" CssClass="form-control"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="rfvTaskName" ErrorMessage="Required" ControlToValidate="txtTaskName" runat="server" ValidationGroup="val" ForeColor="Red" />
                      </div>
                    </div>

                    <div class="form-group row">
                      <label for="Tnum" class="col-sm-3 text-center control-label col-form-label">Task Number</label>
                      <div class="col-sm-6">
                          <asp:TextBox ID="txtTaskNumber" runat="server" CssClass="form-control"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="rfvTaskNumber" ErrorMessage="Required" ControlToValidate="txtTaskNumber" runat="server" ValidationGroup="val" ForeColor="Red" />
                      </div>
                    </div>

                    <div class="form-group row">
                      <label for="Tdetails" class="col-sm-3 text-center control-label col-form-label">Task Details</label>
                      <div class="col-sm-6">
                          <asp:TextBox ID="txtTaskDescription" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                      </div>
                    </div>
                </section>
                <div class="border-top text-center">
                    <div class="card-body">
                        <asp:Button ID="btnAddTask" runat="server" Text="Create Task" CssClass="btn btn-info" ValidationGroup="val" OnClick="btnAddTask_Click" />
                        <asp:Button ID="btnResetField" runat="server" Text="Reset" CssClass="btn btn-info" OnClick="btnResetField_Click" />
                    </div>
                  </div>
              </div>
            </div>
          </form>
        </div>
      </div>
</asp:Content>
