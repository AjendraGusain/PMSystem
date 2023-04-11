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
                  <div class="col-sm-12 ">                                        
					<asp:GridView ID="grvCurrentEmployees" DataKeyNames="" EmptyDataText="No Record Found"  runat="server" class="table table-striped table-bordered" AutoGenerateColumns="false" OnRowCommand="grvCurrentEmployees_RowCommand"   >
						<Columns>
							<asp:TemplateField HeaderText="Employee Name">
							<ItemTemplate>			
                                <asp:LinkButton ID="lnkViewClientInfo" runat="server" CausesValidation="false"  CommandArgument='<%# Eval("UserID") %>' CommandName="ViewEmployeeInfo" CssClass="edit-image-icon text-nowrap" datatextfield="Name"  Text='<%# Bind("UserName") %>' Visible="true" />
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
							</asp:TemplateField>

							<asp:TemplateField HeaderText="Start Date">
							<ItemTemplate>
							<asp:Label ID="lblStartDate" runat="server" Text='<%# Eval("Entrydate") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
							</asp:TemplateField>
						</Columns>
					</asp:GridView>                     
                  </div>
                </div>
              </div>
            </div>
			

			<div class="table-responsive">
              <div class="dataTables_wrapper container-fluid">
                <div class="row">
                	<h4>Previous Employee</h4>
                  <div class="col-sm-12 ">                                        
					<asp:GridView ID="grvPastEmployees" DataKeyNames="" EmptyDataText="No Record Found"  runat="server" class="table table-striped table-bordered" AutoGenerateColumns="false"  >
						<Columns>
							<asp:TemplateField HeaderText="Employee Name">
							<ItemTemplate>
							<asp:Label ID="lblUserName" runat="server" Text='<%# Eval("UserName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
							</asp:TemplateField>

							<asp:TemplateField HeaderText="Start Date">
							<ItemTemplate>
							<asp:Label ID="lblStartDate" runat="server" Text='<%# Eval("Entrydate") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
							</asp:TemplateField>
							
							<asp:TemplateField HeaderText="End Date">
							<ItemTemplate>
							<asp:Label ID="lblEndDate" runat="server" Text='<%# Eval("Enddate") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
							</asp:TemplateField>
						</Columns>
					</asp:GridView>                     
                  </div>
                </div>
              </div>
            </div>
		  
          </div>
        </div>
      </div>
    </form>
</asp:Content>
