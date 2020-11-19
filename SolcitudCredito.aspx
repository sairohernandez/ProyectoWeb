<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolcitudCredito.aspx.cs" Inherits="PrograWeb.SolcitudCredito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/misestilos.css" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <%--<link rel="icon" type="image/vnd.microsoft.icon" href="Imagenes/check.svg" sizes="16x16"/>--%>
    <script type="text/javascript" src="Js/jquery-3.5.1.min.js"></script>
    <script type="text/javascript" src="Js/bootstrap.min.js"></script>

    <link href="//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/css/bootstrap.css" rel="stylesheet" />
    <link href="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/css/bootstrap-datetimepicker.css" rel="stylesheet" />

    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/moment.js/2.15.2/moment.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/js/bootstrap.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/js/bootstrap-datetimepicker.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="card">
                <h1 class="card-header">Solicitud de crédito</h1>
                <div class="card-body">
                    <div class="form-group">
                        <p>
                            <asp:Label Class="h3" ID="Label2" runat="server" Text="Datos Personales"></asp:Label>
                        </p>

                        <div class="row">

                            <div class="col-6">
                                <asp:Label ID="Label3" runat="server" Text="Identificación"></asp:Label>
                                <asp:TextBox type="text" class="form-control" ID="TextBox1" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-6">
                                <asp:Label ID="Label4" runat="server" Text="Nombre"></asp:Label>
                                <asp:TextBox type="text" class="form-control" ID="TextBox2" runat="server"></asp:TextBox>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-6">
                                <asp:Label ID="Label5" runat="server" Text="Apellidos"></asp:Label>
                                <asp:TextBox type="text" class="form-control" ID="TextBox3" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6">
                                <asp:Label ID="Label6" runat="server" Text="Fecha Nacimiento"></asp:Label>
                                <asp:TextBox type="date" class="form-control" ID="TextBox7" runat="server"></asp:TextBox>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="Label7" runat="server" Text="Dirección Exacta"></asp:Label>
                                <asp:TextBox type="text" class="form-control" ID="TextBox4" runat="server"></asp:TextBox>
                            </div>
                        </div>



                        <div class="row">
                            <div class="col-6">
                                <asp:Label ID="Label8" runat="server" Text="Telefono"></asp:Label>
                                <asp:TextBox type="text" class="form-control" ID="TextBox5" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-6">
                                <asp:Label ID="Label10" runat="server" Text="Correo Electrónico"></asp:Label>
                                <asp:TextBox type="email" class="form-control" placeholder="name@ejemplo.com" ID="TextBox8" runat="server"></asp:TextBox>
                            </div>
                        </div>

                    </div>

                    <%--            <div class="container">
                <div class="row">
                    <div class='col-sm-6'>
                        <div class="form-group">
                            <div class='input-group date' id='datetimepicker1'>
                                <input type='text' class="form-control" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>
                        </div>
                    </div>
                    <script type="text/javascript">
                        $(function () {
                            $('#datetimepicker1').datetimepicker();
                        });
                    </script>
                </div>--%>                    <%--</div>--%>
                </div>
            </div>
        </div>
        <div class="row">
            <div class='col-5'>
            </div>
            <div class='col-1'>
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar Solicitud" OnClick="btnEnviar_Click" />

            </div>
            <div class='col-1'>

                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />

            </div>
            <div class='col-5'>
            </div>
            .    
        </div>
        <p>
            &nbsp;


        </p>

    </form>
</body>
</html>
