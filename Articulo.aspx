<%@ Page Title="Articulo" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeBehind="Articulo.aspx.cs" Inherits="PrograWeb.Articulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/articulo.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="content">

        <div class="row">
            <div id="Messages" runat="server" class="col-12 mb-5">
                <div id="MessageContainer" runat="server" role="alert">
                    <asp:Label runat="server" id="MessageContent"></asp:Label>
                </div>
            </div>
            <div class="col-12 col-md-6 mb-4">
                <asp:Image CssClass="w-100" runat="server" id="ProductImage" />
            </div>
            <div class="col-12 col-md-6">
                <asp:Label CssClass="d-block mb-4 h3" runat="server" id="ProductName"></asp:Label>
                <div class="d-block mb-5 h4">
                    <asp:Label CssClass="text-danger" runat="server" id="ProductPrice"></asp:Label> <small class="text-muted">IVAI</small>
                </div>
                <asp:Label CssClass="d-block pb-4 mb-4 h6 text-muted border-bottom" runat="server" id="ProductDescription"></asp:Label>
                <div class="d-block mb-2 h6">
                    <span class="font-weight-bold">SKU: </span>
                    <asp:Label CssClass="text-muted" runat="server" id="ProductSku"></asp:Label>
                </div>
                <div class="d-block mb-4 h6">
                    <span class="font-weight-bold">Categoría: </span>
                    <asp:Label CssClass="text-muted" runat="server" id="ProductCategory"></asp:Label>
                </div>

                <div class="d-block mt-5">
                    <asp:TextBox TextMode="Number" type="number" placeholder="Cantidad" CssClass="d-inline-block w-25 mr-2 form-control align-top" runat="server" id="ProductQty" />
                    <asp:Button CssClass="d-inline-block w-50 btn btn-danger align-top" runat="server" id="AddToCartBtn" Text="AGREGAR AL CARRITO" OnClick="Add_To_Cart" />
                </div>
            </div>
        </div>
        
    </div>
</asp:Content>