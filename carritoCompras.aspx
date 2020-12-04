<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeBehind="carritoCompras.aspx.cs" Inherits="PrograWeb.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="Js/sweetalert.min.js"></script>

    <script src="Js/misMensajes.js" type="text/javascript"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">

    <style>
        .table {
            /* width: auto;
            height: auto;*/
            margin-top: 10px;
        }

        .qty {
            border-style: none;
            width: 100%;
            height: 100%;
        }


        .btn {
            border-radius: 0px;
        }
    </style>

    <asp:GridView ID="GridView1" Class="table table" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" BorderStyle="None" GridLines="None">
        <Columns>

            <asp:BoundField DataField="nombreArticulo" HeaderText="Descripción" ItemStyle-Width="450px" />


            <asp:BoundField HeaderText="Precio Unitario" DataField="precioDetalle" DataFormatString="{0:C0}">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="140px" />
            </asp:BoundField>



            <asp:TemplateField ControlStyle-Width="20px" >
                <ItemTemplate>
                    <asp:ImageButton Text="+" runat="server"  ImageUrl="~/imagenes/Icon_Plus.png" CommandName="Aumentar" CommandArgument="<%# Container.DataItemIndex %>" />
                </ItemTemplate>
            </asp:TemplateField>


            <asp:BoundField DataField="cantidadDetalle" HeaderText="Cant" ItemStyle-Width="25px">
                <%--<ItemStyle CssClass="product" />--%>
            </asp:BoundField>

            <asp:TemplateField ControlStyle-Width="20px">
                <ItemTemplate>
                    <asp:ImageButton Text="-" runat="server" ImageUrl="~/imagenes/Icon_Minus.png" CommandName="Disminuir" CommandArgument="<%# Container.DataItemIndex %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <%--            <asp:TemplateField HeaderText="Cantidad" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:TextBox ID="cantidadPedido" Class="qty" runat="server" min="0" max="20" step="1" Text='<%# Eval("cantidadDetalle") %>' />
                </ItemTemplate>
            </asp:TemplateField>--%>

            <asp:BoundField HeaderText="Subtotal" DataField="subtotal" DataFormatString="{0:C0}">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="140px" />
            </asp:BoundField>




            <asp:TemplateField ControlStyle-Width="20px" HeaderText="Eliminar">
                <ItemTemplate>
                    <asp:ImageButton Class="img" Text="Borrar" runat="server" ImageUrl="~/imagenes/Icon_Trash.png" CommandName="Borrar" CommandArgument="<%# Container.DataItemIndex %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>


    <div class="row justify-content-end">


        <div class="col-4">

            <asp:Label Class="btn btn-secondary" ID="Label2" runat="server" Text="Total del Pedido" Width="100%"></asp:Label>
            <asp:Label Class="btn btn-secondary" ID="LtotalFactura" runat="server" Text="" Width="100%"></asp:Label>


        </div>


    </div>
    <div class="row justify-content-end">

        <div class="col-4">

            <asp:Button Class="btn btn-success" ID="btnGuardarCompra" runat="server" Text="Proceder con compra" Width="100%" OnClick="btnGuardarCompra_Click" />

        </div>

    </div>


    <%--    <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:TextBox ID="nombreArticulo" runat="server" Text='<%# Eval("nombreArticulo") %>' />
                </ItemTemplate>
            </asp:TemplateField>--%>
</asp:Content>
