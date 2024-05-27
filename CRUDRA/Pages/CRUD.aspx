<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="CRUDRA.Pages.CRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    CRUD
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="mx-auto" style="width: 250px">
        <asp:Label runat="server" CssClass="h2" ID="lbltitulo"></asp:Label>
    </div>
    <form runat="server" class="h-100 d-flex align-items-center justify-content-center">
        <div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbnombre"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido Paterno</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbapellidop"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido Materno</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbapellidom"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Numero de control</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbnumeroc"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Carrera</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbcarrera"></asp:TextBox>
            </div>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnCreate" Text="Crear" Visible="false" OnClick="BtnCreate_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnUpdate" Text="Actualizar" Visible="false" onclick="BtnUpdate_Click"/>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnDelete" Text="Borrar" Visible="false" OnClick="BtnDelete_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary btn-dark" ID="BtnVolver" Text="Volver" Visible="True" OnClick="BtnVolver_Click" />
        </div>
    </form>
</asp:Content>