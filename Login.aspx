﻿<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PrograWeb.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="content">

        <div class="form-group row">
            <div class="col-8 mx-auto">
                <div class="card">
                    <form id="form2" runat="server">
                        <div class="card-body">

                            <div class="form-group row">
                                <div class="col-12">
                                    <asp:Label ID="Label_Username" runat="server" Text="Usuario"/>
                                    <asp:TextBox ID="TextBox_Username" class="form-control" placeholder="Usuario" runat="server"/>
                                </div>
                            </div>

                            <div class="form-group row">
                                <div class="col-12">
                                    <asp:Label ID="Label_Password" runat="server" Text="Password"/>
                                    <asp:TextBox ID="TextBox_Password" class="form-control" placeholder="Password" runat="server" TextMode="Password"/>
                                </div>
                            </div>

                            <asp:Label ID="Label_Error" runat="server" class="alert alert-danger d-block w-100 text-center" Text=""/>

                        </div>
                        <div class="card-footer text-center">
                            <asp:Button id="Submit" class="btn btn-lg btn-success" Onclick="Submit_Click" runat="server" Text="Entrar"/>
                        </div>
                    </form>
                </div>
            </div>
        </div>

    </div>
</asp:Content>