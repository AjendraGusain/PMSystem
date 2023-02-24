<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ViewTeam.aspx.cs" Inherits="ProjectManagement.Admin.ViewTeam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="card">
            <div class="card-body">   
                <div class="table-responsive">
              <div class="dataTables_wrapper container-fluid">
                <div class="row">
                  <div class="col-sm-12 d-flex">
                      <form runat="server">
                    <asp:GridView ID="grvViewTeam" DataKeyNames="" runat="server" class="table table-striped table-bordered"  
                                        ShowHeader="true" AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowCommand="grvViewTeam_RowCommand" EnablePaging="true">
                                <%--<PagerStyle CssClass="" HorizontalAlign="Right" />--%>
                                <%--<PagerSettings PageButtonCount="5" FirstPageText="Previous"  PreviousPageText="1" NextPageText="2" LastPageText="Next"  Mode="Numeric"  />--%>
                                        <Columns>
                                            <%--<asp:TemplateField HeaderText="Creation Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCreationDate" runat="server" Text='<%# Eval("CreationDate") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>--%>

                                            <asp:TemplateField HeaderText="Team Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTeamName" runat="server" Text='<%# Eval("TeamName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Manager Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Manager") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Team Leader">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPhoneNumber" runat="server" Text='<%# Eval("TeamLeader") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Employee">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRole" runat="server" Text='<%# Eval("Employee") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <%--<asp:TemplateField HeaderText="Designation">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("DesignationId") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>--%>

                                            <%--<asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEditTeam" class="link-success" CommandName="EditEmployee" runat="server" CommandArgument='<%# Eval("Id") %>'><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-pencil-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" CssClass="page-link"></ItemStyle>
                                            </asp:TemplateField>--%>
                                        </Columns>
                                </asp:GridView>
                          </form>
                      </div>
                    </div>
                  </div>
                    </div>
                </div>
            </div>
           </div>
</asp:Content>
