<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeBehind="activarnuevoscreditos.aspx.cs" Inherits="PrograWeb.activarnuevoscreditos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="Js/sweetalert.min.js"></script>
    <script src="Js/misMensajes.js" type="text/javascript"></script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="content">
        
        
        <asp:GridView ID="GridView1"   Class="table table" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" BorderStyle="None" GridLines="None" >

             <Columns>
                       
                 
                <asp:BoundField DataField="codigoUsuario" HeaderText="#solicitud" Visible="true" ItemStyle-Width="0px"/>

                <asp:BoundField DataField="identificacionUsuario" HeaderText="Identificación" ItemStyle-Width="450px" />
                 
                <asp:BoundField DataField="nombreUsuario" HeaderText="Nombre" ItemStyle-Width="450px" />
                 

                <asp:BoundField DataField="apellidosUsuario" HeaderText="Apellidos" ItemStyle-Width="450px" />

                   <asp:BoundField DataField="correoUsuario" HeaderText="Correo" ItemStyle-Width="450px" />

                   <asp:BoundField DataField="telefonoUsuario" HeaderText="Teléfono" ItemStyle-Width="200px" />

                <asp:TemplateField ControlStyle-Width="20px" HeaderText="Autorizar">
                    <ItemTemplate>
                        <asp:ImageButton Class="img"  runat="server" ImageUrl="~/imagenes/Icon_true.png" CommandName="Aprobar" CommandArgument="<%# Container.DataItemIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField ControlStyle-Width="20px" HeaderText="Rechazar">
                    <ItemTemplate>
                        <asp:ImageButton Class="img"  runat="server" ImageUrl="~/imagenes/Icon_False.png" CommandName="Rechazar" CommandArgument="<%# Container.DataItemIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>


    </div>

</asp:Content>
