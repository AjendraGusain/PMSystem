<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ViewClient.aspx.cs" Inherits="ProjectManagement.Admin.ViewClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4>View Clients</h4>
    <div class="ms-auto text-end">
                    <i class="mdi mdi-chevron-left"></i>
                    <input type="submit" name="btnEdit" value="Back" onclick="return Back();" class="btn btn-warning btn-sm" id="btnEdit" />
                </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="card">
            <div class="card-body">
                
                <div class="table-responsive">
                    <div id="zero_config_wrapper" class="dataTables_wrapper container-fluid">
                        <form runat="server">
                            <asp:GridView ID="grvClient" DataKeyNames="" runat="server" class="table table-striped table-bordered" AllowPaging="true" PageSize="10"
                                ShowHeader="true" AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowCommand="grvClient_RowCommand" EnablePaging="true"
                                OnPageIndexChanging="grvClient_PageIndexChanging">
                                <PagerStyle CssClass="" HorizontalAlign="Right" />
                                <PagerSettings PageButtonCount="5" FirstPageText="Previous" PreviousPageText="1" NextPageText="2" LastPageText="Next" Mode="Numeric" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Client Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClientName" runat="server" Text='<%# Eval("ClientName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Country">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClientCountry" runat="server" Text='<%# Eval("CountryName") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEditEmployee" Text="Edit" CommandName="EditClient" runat="server" CommandArgument='<%# Eval("ClientId") %>' CssClass="link-success"><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-pencil-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                            <asp:LinkButton ID="btnDeleteEmployee" Text="Delete" CommandName="DeleteClient" runat="server" CommandArgument='<%# Eval("ClientId") %>' CssClass="link-danger" OnClientClick="return confirm('Are you sure you want to delete this record?');"><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-trash-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDeleteEmployee" Text="Delete" CommandName="DeleteClient" runat="server" CommandArgument='<%# Eval("ClientId") %>' CssClass="link-dange"><span class="fa-stack"> <i class="fa fa-square fa-stack-2x"></i> <i class="fa fa-trash-alt fa-stack-1x fa-inverse"></i> </span></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script language="javascript" type="text/javascript">
        function Back() {
            history.go(-1);
            return false;
        }
    </script>
</asp:Content>
