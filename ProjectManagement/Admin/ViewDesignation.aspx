<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ViewDesignation.aspx.cs" Inherits="ProjectManagement.Admin.ViewDesignation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h4>View Designation</h4>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="card">
            <div class="card-body">
                <div class="table-responsive">
                    <div id="zero_config_wrapper" class="dataTables_wrapper container-fluid">
                        <form runat="server">
                            <asp:GridView ID="grvDesignation" DataKeyNames="" runat="server" class="table table-striped table-bordered" AllowPaging="true" PageSize="10"
                                        ShowHeader="true" AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowCommand="grvDesignation_RowCommand" EnablePaging="true"  
                                OnPageIndexChanging="grvDesignation_PageIndexChanging">
                                   <PagerStyle CssClass="" HorizontalAlign="Right" />
                                <PagerSettings PageButtonCount="5" FirstPageText="Previous"  PreviousPageText="1" NextPageText="2" LastPageText="Next"  Mode="Numeric"  />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Designation">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("Designation") %>' ItemStyle-HorizontalAlign="Right"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEditDesignation" class="link-info" CommandName="EditDesignation" runat="server" CommandArgument='<%# Eval("Id") %>'>Edit</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDeleteDesignation" class="link-info" CommandName="DeleteDesignation" runat="server" CommandArgument='<%# Eval("Id") %>'>Delete</asp:LinkButton>
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
