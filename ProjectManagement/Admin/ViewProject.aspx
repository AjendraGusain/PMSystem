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



   
   
    
    

<div class="dataTables_wrapper container-fluid mb-4">
              <div class="row">

                <div class="col-sm-12 col-md-3">
                  <div id="zero_config_filter" class="dataTables_filter">
                    <label>Search:
                      <asp:TextBox ID="txtProNameSearch" runat="server"></asp:TextBox>
                    </label>
                  </div>
                </div>
                <div class="col-sm-12 col-md-5">
                  <div id="zero_config_filter" class="dataTables_filter">
                    <label> Date Range:
                         <asp:TextBox ID="txtProStartDateSearch" runat="server" class="form-control" placeholder="Start Date...." type="date"></asp:TextBox>
                      <!--input id="start" class="form-control form-control-sm" placeholder="Start Date"-->
                    </label>
                    <label> to
                        <asp:TextBox ID="txtProEndDateSearch" runat="server" class="form-control" placeholder="Start Date...." type="date"></asp:TextBox>
                      <!--input id="end" class="form-control form-control-sm" placeholder="End Date"-->
                    </label>
                    
                  </div>
                </div>
				                <div class="col-sm-12 col-md-2">
                  <div class="dataTables_length" id="zero_config_length">
                    <label>
                            <asp:Button Text="Search" ID="btnSearch" runat="server" OnClick="btnSearch_Click"/>
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
              <%--    <div class="col-sm-12 d-flex">--%>
                      
    <asp:Panel ID="Panel1" runat="server">
          <asp:GridView ID="AllProjects" runat="server" AutoGenerateColumns="false" OnRowCommand="AllProjects_RowCommand"    class="table table-striped table-bordered" EmptyDataText="No Record Found" AllowPaging="true" PageSize="10"  OnPageIndexChanging="AllProjects_PageIndexChanging" >
             
              <PagerStyle CssClass="" HorizontalAlign="Right" />
                <PagerSettings PageButtonCount="5" FirstPageText="Previous"  PreviousPageText="1" NextPageText="2" LastPageText="Next"  Mode="Numeric"  />
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
                          
                        
                          <asp:Label ID="lblStartDate" runat="server" Text='<%# Eval("StartDate", "{0:dd/MM/yyyy}") %>' ></asp:Label>

                      </ItemTemplate>
                  </asp:TemplateField> 
                  
             <asp:TemplateField HeaderText="End Date">
                <ItemTemplate>
                     
                    <asp:Label ID="lblEndDate" runat="server" Text='<%# Eval("EndDate", "{0:dd/MM/yyyy}") %>' ></asp:Label>

                 </ItemTemplate>
            </asp:TemplateField>

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
