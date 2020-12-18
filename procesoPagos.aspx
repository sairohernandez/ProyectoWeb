<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeBehind="procesoPagos.aspx.cs" Inherits="PrograWeb.procesoPagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="Js/sweetalert.min.js"></script>
    <script src="Js/misMensajes.js" type="text/javascript"></script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="content">

        <script type="text/javascript">

            //$(function () {

           <%--     $("#<%=txtIdentificacion.ClientID %>").keydown(function (e) {

                    if (e.keyCode == 13) {

                        <%CargarPrestamos();%>

                    }

                });--%>

            //});

        </script>


        <div class="card-group">

            <div class="card">
                <div class="card-body text-dark">
                    <div class="form-group row">
                        <div class="col-3">
                            <asp:Label ID="Label2" runat="server" Text="Identifiación"></asp:Label>
                        </div>
                        <div class="col-5">
                            <asp:TextBox runat="server" ID="txtIdentificacion" OnTextChanged="txtIdentificacion_TextChanged"></asp:TextBox>
                        </div>
                        <div class="col-2">
                            <asp:Button ID="btnBuscarCliente" runat="server" Text="Validar Cliente" OnClick="btnBuscarCliente_Click" />
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="col-3">
                            <asp:Label ID="Label1" runat="server" Text="#Operación"></asp:Label>
                        </div>
                        <div class="col-3">
                            <asp:DropDownList ID="cmbPrestamos" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbPrestamos_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="col-3">
                            <asp:Label ID="Label5" runat="server" Text="Saldo crédito"></asp:Label>
                        </div>
                        <div class="col-3">
                            <asp:Label ID="lblSaldoFactura" runat="server"></asp:Label>
                        </div>

                    </div>

                    <div class="form-group row">
                        <div class="col-3">
                            <asp:Label ID="Label9" runat="server" Text="#Cuotas"></asp:Label>
                        </div>
                        <div class="col-2">
                            <asp:TextBox ID="txtNumeroCuotas" TextMode="Number" Text="1" AutoPostBack="true" runat="server" OnTextChanged="txtNumeroCuotas_TextChanged"></asp:TextBox>
                        </div>
                        <div class="col-2">
                        </div>

                    </div>
                </div>
            </div>
            <div class="card">

                <div class="card-body text-dark">
                    <div class="form-group row">
                        <div class="col-4">
                            <asp:Label ID="Label7" runat="server" Text="Fecha Última Pago"></asp:Label>
                        </div>
                        <div class="col-3">
                            <asp:Label ID="lblFechaUltimaCuota" runat="server"></asp:Label>
                        </div>

                        <div class="col-3">
                            <asp:Label ID="Label10" text="Saldo Cuotas" runat="server"></asp:Label>
                        </div>

                               <div class="col-2">
                            <asp:Label ID="lblSaldoCuotas" runat="server"></asp:Label>
                        </div>

                    </div>

                    <div class="form-group row">
                        <div class="col-4">
                            <asp:Label ID="Label8" runat="server" Text="Vencimiento crédito"></asp:Label>
                        </div>
                        <div class="col-3">
                            <asp:Label ID="lblFechaVencimiento" runat="server"></asp:Label>
                        </div>


                    </div>

                    <div class="form-group row">

                        <div class="col-4">
                            <asp:Label ID="Label4" runat="server" Text="Amortización"></asp:Label>
                        </div>
                        <div class="col-3">
                            <asp:Label ID="lblTotalAmortizacion" runat="server"></asp:Label>
                        </div>

                    </div>

                    <div class="form-group row">
                        <div class="col-4">
                            <asp:Label ID="Label6" runat="server" Text="Intereses"></asp:Label>
                        </div>
                        <div class="col-3">
                            <asp:Label ID="lblTotalIntereses" runat="server"></asp:Label>
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="col-4">
                            <asp:Label ID="Label3" runat="server" Text="Total a Pagar"></asp:Label>
                        </div>
                        <div class="col-3">
                            <asp:Label ID="lblTotalPago" runat="server"></asp:Label>
                        </div>
                    </div>

                </div>
            </div>

        </div>

        <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Procesar" />
    </div>


</asp:Content>
