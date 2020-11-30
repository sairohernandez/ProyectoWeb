<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeBehind="carritoCompras.aspx.cs" Inherits="PrograWeb.WebForm1" %>



<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">

    <asp:GridView ID="GridView1" Class="table table-bordered small-top-margin" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
        <Columns>

            <asp:BoundField DataField="nombreArticulo" HeaderText="Descripción" ItemStyle-Width="450px" />


            <asp:BoundField DataField="cantidadDetalle" HeaderText="Cantidad" ItemStyle-Width="50px" > 
                
                 <itemstyle cssclass="product" />
               </asp:BoundField>


            <%--    <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:TextBox ID="nombreArticulo" runat="server" Text='<%# Eval("nombreArticulo") %>' />
                </ItemTemplate>
            </asp:TemplateField>--%>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton Text="+" runat="server" ImageUrl="~/imagenes/Icon_Plus.png" CommandName="Aumentar" CommandArgument="<%# Container.DataItemIndex %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton Text="-" runat="server" ImageUrl="~/imagenes/Icon_Minus.png" CommandName="Disminuir" CommandArgument="<%# Container.DataItemIndex %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton Text="Borrar" runat="server" ImageUrl="~/imagenes/Icon_Trash.png" CommandName="Borrar" CommandArgument="<%# Container.DataItemIndex %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>


    <style>
        .select {
            text-decoration: none;
            text-align: right;
        }

        .product {
            color: Blue;
             text-align: right;
        }
    </style>

<%--    <asp:CommandField ShowSelectButton="True">
        <controlstyle cssclass="select" />
    </asp:CommandField>
    <asp:BoundField DataField="ProductName" HeaderText="Product Name" ItemStyle-CssClass="product">
        <itemstyle cssclass="product" />
    </asp:BoundField>--%>
</asp:Content>
