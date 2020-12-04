<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeBehind="procesoVenta.aspx.cs" Inherits="PrograWeb.procesoVenta" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="js/sweetalert.min.js"></script>
    <script src="Js/misMensajes.js" type="text/javascript"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="content">

        <div class="card-group">

            <div class="card">
                <div class="card-header">
                    Datos de Formalización
                </div>
                <div class="card-body text-dark">

                    <div class="row">
                        <div class="col-4">
                            <p>
                                <asp:Label runat="server">Plazo Pago</asp:Label>
                            </p>
                        </div>
                            
                        <div class="col-3">
                            <asp:DropDownList runat="server" ID="cmbPlazos" OnSelectedIndexChanged="cmbPlazos_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Text="6 Meses" Value="180"></asp:ListItem>
                                <asp:ListItem Text="8 Meses" Value="240"></asp:ListItem>
                                <asp:ListItem Text="12 Meses" Value="360"></asp:ListItem>
                                <asp:ListItem Text="24 Meses" Value="720"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-4">
                                <p>
                            <asp:Label runat="server">Forma de entrega</asp:Label>
                                    </p>
                        </div>
                        <div class="col-3">
                            <asp:DropDownList runat="server" ID="cmdEntrega" OnSelectedIndexChanged="cmdEntrega_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Text="En tienda" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Entrega a domicilio" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>


                    <%--&nbsp;--%>




                    <asp:TextBox type="text" class="form-control" ID="txtDireccionExacta" runat="server" Wrap="true" placeholder="Dirección de envío" TextMode="MultiLine" Rows="5"></asp:TextBox>
                </div>
            </div>


            <div class="card">
                <div class="card-header">
                    Resumen de Crédito
                </div>
                <div class="card-body text-dark">

                    <div class="row">
                        <div class="col-6">
                            <asp:Label runat="server">Total Documento</asp:Label>
                        </div>
                        <div class="col-6">
                            <p>
                                <asp:Label ID="lblTotalDocumento" runat="server" Font-Bold="true"></asp:Label>
                            </p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6">
                            <p>
                                <asp:Label runat="server">Cuota Mensual</asp:Label>
                            </p>
                        </div>
                        <div class="col-6">
                            <asp:Label ID="lblMontoCuota" runat="server" Font-Bold="true"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6">
                            <p>
                                <asp:Label runat="server">Fecha Formalización</asp:Label>
                            </p>
                        </div>
                        <div class="col-6">
                            <asp:Label ID="lblFechaFormalizacion" runat="server" Font-Bold="true"></asp:Label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-6">
                            <p>
                                <asp:Label runat="server">Fecha Vencimiento</asp:Label>
                            </p>
                        </div>
                        <div class="col-6">
                            <asp:Label ID="lblTFechaVencimiento" runat="server" Font-Bold="true"></asp:Label>
                        </div>
                    </div>

                </div>

            </div>
        </div>

    </div>



    <div class="card-footer text-center">

        <asp:Button class="btn btn-success" ID="btnEnviar" runat="server" Text="Enviar Solicitud" OnClick="btnEnviar_Click" />
        <a class="btn btn-danger md-10" runat="server" href="~/Default.aspx">Cancelar</a>
    </div>


</asp:Content>
