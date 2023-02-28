<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ViewProject.aspx.cs" Inherits="ProjectManagement.Admin.ViewProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
      <div class="row">
        <div class="card">
          <div class="card-body">


    <%--<asp:TextBox ID="txtProNameSearch" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtProStartDateSearch" runat="server" class="form-control" placeholder="Start Date...." type="date"></asp:TextBox>
    <asp:TextBox ID="txtProEndDateSearch" runat="server" class="form-control" placeholder="Start Date...." type="date"></asp:TextBox>
    <asp:Button Text="Search" ID="btnSearch" runat="server" OnClick="btnSearch_Click"/>--%>




            <div class="table-responsive">
              <div id="zero_config_wrapper" class="dataTables_wrapper container-fluid">
                <div class="row">
              <%--    <div class="col-sm-12 d-flex">--%>
                      
    <asp:Panel ID="Panel1" runat="server">
          <asp:GridView ID="AllProjects" runat="server" AutoGenerateColumns="false" OnRowCommand="AllProjects_RowCommand"    class="table table-striped table-bordered" EmptyDataText="No Record Found">
              <Columns>


                  <asp:TemplateField HeaderText="Project Name">
                      <ItemTemplate>
                          <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("ProjectName") %>' ></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>

                   <asp:TemplateField HeaderText="Client Name">
                      <ItemTemplate>
                          <asp:Label ID="lblClientName" runat="server" Text='<%# Eval("ClientName") %>' ></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>

                   <asp:TemplateField HeaderText="Start Date">
                      <ItemTemplate>
                          <asp:Label ID="lblStartDate" runat="server" Text='<%# Eval("StartDate") %>' ></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField> 
                  
            <%-- <asp:TemplateField HeaderText="End Date">
                <ItemTemplate>
                     <asp:Label ID="lblEndDate" runat="server" Text='<%# Eval("EndDate") %>' ></asp:Label>
                 </ItemTemplate>
            </asp:TemplateField>--%>

    <asp:TemplateField HeaderText="Action">
        <ItemTemplate>
            <asp:LinkButton ID="btnProjectDetail" Class="link-info" CommandName="ProjectDetail" runat="server" CommandArgument='<%# Eval("ProjectId") %>'><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-eye fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
            <asp:LinkButton ID="btnEditProject" class="link-success" CommandName="EditProject" runat="server" CommandArgument='<%# Eval("ProjectId") %>'><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-pencil-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
            <asp:LinkButton ID="btnDeleteProject" class="link-danger" CommandName="DeleteProject" runat="server" CommandArgument='<%# Eval("ProjectId") %>'><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-trash-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
        </ItemTemplate>       
    </asp:TemplateField>


              </Columns>
          </asp:GridView>
    </asp:Panel>


                      

                    
                 <%-- </div>--%>
                </div>
        
              </div>
            </div>
          </div>
        </div>
      </div>
     </form>
</asp:Content>
