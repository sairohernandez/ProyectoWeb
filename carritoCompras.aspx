<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeBehind="carritoCompras.aspx.cs" Inherits="PrograWeb.WebForm1" %>



<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">

    <asp:GridView ID="GridView1" Class="table table-bordered small-top-margin" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" BorderStyle="None" GridLines="None">
        <Columns>

            <asp:BoundField DataField="nombreArticulo" HeaderText="Descripción" ItemStyle-Width="450px" />


            <asp:BoundField HeaderText="Precio Unitario" DataField="precioDetalle">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="140px" />
            </asp:BoundField>


            <asp:BoundField DataField="cantidadDetalle" HeaderText="Cantidad" ItemStyle-Width="50px">

                <ItemStyle CssClass="product" />
            </asp:BoundField>

            <asp:BoundField HeaderText="Subtotal" DataField="subtotal">
                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="140px" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="140px" />
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





    <div class="row justify-content-end">


        <div class="col-4">

                <asp:Label Class="btn btn-warning" ID="Label2" runat="server" Text="Total del Pedido" Width="100%"></asp:Label>
                <asp:Label Class="btn btn-warning" ID="LtotalFactura" runat="server" Text="¢5000" Width="100%"></asp:Label>
       

        </div>


    </div>
    <div class="row justify-content-end">

        <div class="col-4">

            <asp:Button Class="btn btn-primary" ID="btnGuardarCompra" runat="server" Text="Proceder con compra"  Width="100%" OnClick="btnGuardarCompra_Click"/>

        </div>

    </div>
    <style>
        .table {
            /* width: auto;
            height: auto;*/
            margin-top: 10px;
            margin-left: auto;
        }



        .select {
            text-decoration: none;
            text-align: right;
        }

        .product {
            color: Blue;
            text-align: right;
        }
    </style>

    <%--    <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:TextBox ID="nombreArticulo" runat="server" Text='<%# Eval("nombreArticulo") %>' />
                </ItemTemplate>
            </asp:TemplateField>--%>
</asp:Content>
