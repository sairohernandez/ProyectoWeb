<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PrograWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="content">
        
        <h1>Under Construction...</h1>

        <br /><br />

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="idArticulo" />
                <asp:BoundField HeaderText="SKU" DataField="skuArticulo" />
                <asp:BoundField HeaderText="Nombre" DataField="nombreArticulo" />
                <asp:BoundField HeaderText="Categoria" DataField="categoriaArticulo" />
                <asp:BoundField HeaderText="Precio" DataField="precioArticulo" />
                <asp:BoundField HeaderText="Cantidad" DataField="cantidadArticulo" />
                <asp:BoundField HeaderText="Imagen" DataField="rutaImagen" />
            </Columns>
        </asp:GridView>

        <br /><br />
        <a class="btn btn-success" runat="server" href="~/SolcitudCredito.aspx" role="button">SOLICITAR CREDITO</a>

        <br /><br />
        <asp:Image runat="server" ImageUrl="~/images/301871007698-e1603730839952.jpg" /> 
        
    </div>
</asp:Content>  
