<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PrograWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/homepage.css" />
    <link rel="stylesheet" href="css/slider/jquery.bxslider.min.css" />
    <script src="js/slider/jquery.bxslider.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="content">

        <div class="slider">
            <div>
                <a runat="server" href="~/MTB.aspx">
                    <asp:Image runat="server" ImageUrl="~/images/homepage/ciclo-banner-1.jpg" ToolTip="Nuestras MTB para tu siguiente aventura" />
                </a>
            </div>
            <div>
                <a runat="server" href="~/RUTA.aspx">
                    <asp:Image runat="server" ImageUrl="~/images/homepage/ciclo-banner-2.jpg" ToolTip="Nuestras bicicletas de RUTA siempre en carretera" />
                </a>
            </div>
            <div>
                <a runat="server" href="~/SolcitudCredito.aspx">
                    <asp:Image runat="server" ImageUrl="~/images/homepage/ciclo-banner-3.jpg" ToolTip="Solicite su credito con nosotros" />
                </a>
            </div>
        </div>


        <h2 class="text-center mb-4">NUEVOS PRODUCTOS</h2>
        
        <asp:Repeater id="NuevosProductos" runat="server">
            <HeaderTemplate>
                <div class="row">
            </HeaderTemplate>

            <ItemTemplate>
                <div class="col-12 col-md-4">
                    <div class="text-center px-4 py-4">
                        <a runat="server" href="~/Articulo.aspx">
                            <asp:Image CssClass="d-block w-100 mx-auto" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "rutaImagen") %>' />
                        </a>
                        <a runat="server" href="~/Articulo.aspx">
                            <div class="h6 pt-2 text-dark"><%# DataBinder.Eval(Container.DataItem, "nombreArticulo") %></div>
                        </a>
                        <div><span class="text-danger">₡<%# ((double)DataBinder.Eval(Container.DataItem, "precioArticulo")).ToString("#,000.00") %></span>&nbsp;<span class="text-muted"><small>IVAI</small></span></div>
                    </div>
                </div>
            </ItemTemplate>

            <FooterTemplate>
                </div>
            </FooterTemplate>

        </asp:Repeater>

        
    </div>

    <script>
        $(document).ready(function(){
            $('.slider').bxSlider({
                mode: 'fade',
                captions: true,
                pager: false,
                auto: true
            });
        });
    </script>
</asp:Content>  
