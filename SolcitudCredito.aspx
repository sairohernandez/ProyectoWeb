<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeBehind="SolcitudCredito.aspx.cs" Inherits="PrograWeb.SolcitudCredito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/misestilos.css" />
    <link href="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/css/bootstrap-datetimepicker.css" rel="stylesheet" />

    <script src="//cdnjs.cloudflare.com/ajax/libs/moment.js/2.15.2/moment.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/js/bootstrap.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/js/bootstrap-datetimepicker.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="content">

        <div id="mensaje" class="alert alert-success" role="alert">
            A simple success alert—check it out!
        </div>
        
        <div class="card">
            <div class="card-header h3">
                Solicitud de crédito
            </div>
            <form id="form1" runat="server">
                <div class="card-body">

                    <p class="h5">Datos Personales</p>
                    <hr />
                    
                    <div class="form-group row">
                        <div class="col-12 col-md-6">
                            <asp:Label ID="Label3" runat="server" Text="Identificación"></asp:Label>
                            <asp:TextBox type="text" class="form-control" ID="txtIdentificacion" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-12 col-md-6">
                            <asp:Label ID="Label4" runat="server" Text="Nombre"></asp:Label>
                            <asp:TextBox type="text" class="form-control" ID="txtNombre" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="col-12 col-md-6">
                            <asp:Label ID="Label5" runat="server" Text="Apellidos"></asp:Label>
                            <asp:TextBox type="text" class="form-control" ID="txtApellidos" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-12 col-md-6">
                            <asp:Label ID="Label6" runat="server" Text="Fecha Nacimiento"></asp:Label>
                            <asp:TextBox type="date" class="form-control" ID="txtFechaNacimiento" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="col-12 col-md-6">
                            <asp:Label ID="Label8" runat="server" Text="Telefono"></asp:Label>
                            <asp:TextBox type="text" class="form-control" ID="txtTelefono" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-12 col-md-6">
                            <asp:Label ID="Label10" runat="server" Text="Correo Electrónico"></asp:Label>
                            <asp:TextBox type="email" class="form-control" placeholder="name@ejemplo.com" ID="txtCorreo" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="col-12">
                            <asp:Label ID="Label7" runat="server" Text="Dirección Exacta"></asp:Label>
                            <asp:TextBox type="text" class="form-control" ID="txtDireccionExacta" runat="server" Wrap="true" TextMode="MultiLine" Rows="6"></asp:TextBox>
                        </div>
                    </div>
  
                </div>
                <div class="card-footer text-center">
                    <a class="btn btn-danger mr-4" runat="server" href="~/Default.aspx">Cancelar</a>
                    <asp:Button class="btn btn-success" ID="btnEnviar" runat="server" Text="Enviar Solicitud" OnClick="btnEnviar_Click" />
                </div>
            </form>
        </div>

        <script language="javascript" type="text/javascript">
            function myFuncionAlerta() {
                $('.alert').alert('close')
            }
        </script>
        
    </div>
</asp:Content>
