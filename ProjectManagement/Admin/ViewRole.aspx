<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ViewRole.aspx.cs" Inherits="ProjectManagement.Admin.ViewRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4>View Role</h4>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="card">
            <div class="card-body">
                <div class="table-responsive">
                    <div id="zero_config_wrapper" class="dataTables_wrapper container-fluid">
                        <form runat="server">
                            <asp:GridView ID="grvRole" DataKeyNames="" runat="server" class="table table-striped table-bordered" AllowPaging="true" PageSize="2" 
                                ShowHeader="true" AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowCommand="grvRole_RowCommand" EnablePaging="true" 
                                OnPageIndexChanging="grvRole_PageIndexChanging">
                                <PagerStyle CssClass="" HorizontalAlign="Right" />
                                <PagerSettings PageButtonCount="5" FirstPageText="Previous"  PreviousPageText="1" NextPageText="2" LastPageText="Next"  Mode="Numeric"  />
                                <Columns>
                                <asp:TemplateField HeaderText="Role">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRole" runat="server" Text='<%# Eval("Role") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditRole" class="link-info" CommandName="EditRole" runat="server" CommandArgument='<%# Eval("RoleId") %>' >Edit</asp:LinkButton> 
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDeleteRole" class="link-info" CommandName="DeleteRole" runat="server" CommandArgument='<%# Eval("RoleId") %>' >Delete</asp:LinkButton> 
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                            </asp:GridView>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
     
</asp:Content>
