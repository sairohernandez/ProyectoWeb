<%@ Page Title="RUTA" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeBehind="RUTA.aspx.cs" Inherits="PrograWeb.RUTA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/categoria.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="content">

        <div class="bg-secondary w-100 py-5 mb-5">
            <h2 class="text-center text-light py-2">RUTA</h2>
        </div>

        <div class="row no-gutters">
            <div class="col-12 col-md-3">
                <h5 class="mb-3">Marcas:</h5>
                <asp:Repeater id="MarcasList" runat="server">
                    <ItemTemplate>
                        <div class="mb-2">
                            <asp:LinkButton runat="server" class="btn btn-secondary"  Width="170px" OnCommand="Filter_Products" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "codigoMarca") %>'>
                                <%# DataBinder.Eval(Container.DataItem, "nombreMarca") %>
                            </asp:LinkButton> 
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col-12 col-md-9">
                <asp:Repeater id="ProductosGrid" runat="server">
                    <ItemTemplate>
                        <div class="row no-gutters pb-4 mb-4 border-bottom">
                            <div class="col-4">
                                <asp:LinkButton runat="server" OnCommand="Redirect_To_Product" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "idArticulo") %>'>
                                    <asp:Image CssClass="d-block w-100 mx-auto" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "rutaImagen") %>' />
                                </asp:LinkButton>
                            </div>
                            <div class="col-8 pl-4">
                                <asp:LinkButton runat="server" OnCommand="Redirect_To_Product" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "idArticulo") %>'>
                                    <div class="h5 text-dark"><%# DataBinder.Eval(Container.DataItem, "nombreArticulo") %></div>
                                </asp:LinkButton>
                                <div><span class="h5 text-danger">₡<%# ((double)DataBinder.Eval(Container.DataItem, "precioArticulo")).ToString("#,000.00") %></span>&nbsp;<span class="text-muted"><small>IVAI</small></span></div>
                                <div class="mt-4 text-muted"><small><%# DataBinder.Eval(Container.DataItem, "descripcionArticulo") %></small></div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Label ID="EmptyGridLabel" runat="server" Text="No se encontraron productos.." />
            </div>
        </div>
        
    </div>
</asp:Content>  
