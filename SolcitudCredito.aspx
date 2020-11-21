﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeBehind="SolcitudCredito.aspx.cs" Inherits="PrograWeb.SolcitudCredito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/misestilos.css" />
    <script src="js/sweetalert.min.js"></script>
    <script src="http://digitalbush.com/wp-content/uploads/2013/01/jquery.maskedinput-1.3.1.min_.js"></script>

    <script language="javascript" type="text/javascript">

        function mensajeCorrecto() {
            swal("", "La solicitud ha sido enviada correctamente", "success");
        }

        function mensajeExisteRegistro() {
            swal("", "La identicación ya existe registrada en la base de datos", "warning");
        }

        function mensajeError() {
            swal("", "Se ha presentado un error enviando la solicitud, favor intentar mas tarde", "warning");
        }

        //$(function () {
        //    // Define your mask (using 9 to denote any digit)
        //    $(#txtTelefono).mask('999-9999');
        //});

  
    </script>
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="content">

        <div class="card">
            <div class="card-header h3">
                Solicitud de crédito
            </div>
            <form id="form2" runat="server" class="needs-validation">
                <div class="card-body">

                    <p class="h5">Datos Personales</p>
                    <hr />

                    <div class="form-group row">
                        <div class="col-12 col-md-6">
                            <asp:Label for="txtIdentificacion" ID="Label3" runat="server" Text="Identificación"></asp:Label>
                            <asp:TextBox type="text" class="form-control" ID="txtIdentificacion" required="true" placeholder="Identificación" runat="server"></asp:TextBox>
                            <div class="invalid-feedback">
                                Favor digitar una identificación
                            </div>
                        </div>
                        <div class="col-12 col-md-6">
                            <asp:Label ID="Label4" runat="server" Text="Nombre"></asp:Label>
                            <asp:TextBox type="text" class="form-control" ID="txtNombre" required="true" placeholder="Nombre" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="col-12 col-md-6">
                            <asp:Label ID="Label5" runat="server" Text="Apellidos"></asp:Label>
                            <asp:TextBox type="text" class="form-control" ID="txtApellidos" required="true" placeholder="Apellidos" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-12 col-md-6">
                            <asp:Label ID="Label6" runat="server" Text="Fecha Nacimiento"></asp:Label>
                            <asp:TextBox type="date" class="form-control" ID="txtFechaNacimiento" required="true"  runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="col-12 col-md-6">
                            <asp:Label ID="Label8" runat="server" Text="Telefono"></asp:Label>
                            <asp:TextBox type="mask" class="form-control" ID="txtTelefono" required="true" placeholder="Teléfono" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-12 col-md-6">
                            <asp:Label ID="Label10" runat="server" Text="Correo Electrónico"></asp:Label>
                            <asp:TextBox type="email" class="form-control" placeholder="Nombre@ejemplo.com" ID="txtCorreo" required="true"  runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="col-12">
                            <asp:Label ID="Label7" runat="server" Text="Dirección Exacta"></asp:Label>
                            <asp:TextBox type="text" class="form-control" ID="txtDireccionExacta" runat="server" Wrap="true"  placeholder="Dirección" TextMode="MultiLine" Rows="6"></asp:TextBox>
                        </div>
                    </div>

                </div>
                <div class="card-footer text-center">

                    <asp:Button class="btn btn-success" ID="btnEnviar" runat="server" Text="Enviar Solicitud" OnClick="btnEnviar_Click" />
                    <a class="btn btn-danger md-10" runat="server" href="~/Default.aspx">Cancelar</a>
                </div>
            </form>
        </div>


    </div>
</asp:Content>
