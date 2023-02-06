<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Task.aspx.cs" Inherits="ProjectManagement.Admin.Task" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4>Add Task</h4>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:Panel ID="pnlTaskDetails" runat="server">
       <%-- <asp:UpdatePanel runat="server">--%>
                <div class="form-group row">
                    <label for="Tname" class="col-sm-3 text-center control-label col-form-label">Task Name</label>
                    <div class="col-sm-6">
                        <%--<input type="text" class="form-control" id="Tname" placeholder="Task Name....">--%>
                        <asp:TextBox ID="txtTaskName" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="Tdetails" class="col-sm-3 text-center control-label col-form-label">Task Details/Comment</label>
                    <div class="col-sm-6">
                        <%--<textarea class="form-control" placeholder="Task Details/Comment...."></textarea>--%>
                        <asp:TextBox ID="txtTaskDetails" runat="server"></asp:TextBox>
                    </div>
                </div>
            
            <div class="border-top text-center">
                <div class="card-body">
                   <%-- <button type="button" class="btn btn-info">
                        Create Task
                    </button>--%>
                    <asp:Button ID="btnCreateTask" runat="server" Text="Create Task" class="btn btn-info" OnClick="btnCreateTask_Click"></asp:Button>
                </div>
            </div>
<%--        </asp:UpdatePanel>--%>
    </asp:Panel>


</asp:Content>
