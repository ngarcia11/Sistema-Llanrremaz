<%@ Page Title="" Language="VB" MasterPageFile="~/Usuario.master" AutoEventWireup="false" CodeFile="Usuarios.aspx.vb" Inherits="Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        
     <div class="alert alert-success alert-dismissable" id="dvExito" runat="server" visible="false" style="text-align: center">
                <button class="close" data-dismiss ="alert" ><span>&times;</span></button>
                <i class="fa-fw fa fa-check"></i>
                <strong>Éxito : </strong> Realizado Correctamente.
                <asp:Timer ID="tmExito" runat="server" Interval="3000" Enabled="true"></asp:Timer>
            </div>
          <div class="alert alert-warning alert-dismissable" id="dvAdvertencia" runat="server" visible="false" style="text-align: center">
                 <button class="close" data-dismiss ="alert" ><span>&times;</span></button>
                <i class="fa-fw fa fa-warning"></i>
                <strong>Advertencia: </strong>No puedes dejar campos vacios
                <asp:Label ID="lblAdvertencia" runat="server"></asp:Label>
            </div>
           <div class="alert alert-danger alert-dismissable" id="dvError" runat="server" visible="false" style="text-align: center">
       <button class="close" data-dismiss ="alert" ><span>&times;</span></button>
                <i class="fa-fw fa fa-times"></i>
                <strong>NOTA: </strong> Desabilitado Con Éxito 
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </div>
    <section class="content-header">
        <h1 style="text-align: center">REGISTRO DE USUARIOS</h1>
    </section>
        
    <section class="content">
        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>NOMBRE DE USUARIO</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNomUsr" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>CONTRSEÑA</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtPass" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>NIVEL</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddlNivel" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0">Administrador</asp:ListItem>
                                <asp:ListItem Value="1">Usuario</asp:ListItem>
                            </asp:DropDownList>
                            
                        </div>
                       
                    </div>
                </div>
            </div>

        </div>
        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Width="200px" Text="Realizar" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Width="200px" Text="Cancelar" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <!-- Datatable Part -->

        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Lista de Usuarios</h3>
                    </div>
                    <div class="box-body table-responsive">
                       
                            <asp:GridView ID="GvUsuarios" runat="server" AutoGenerateColumns="False"  class="table table-bordered table-hover">
                                 <Columns>
                                     <asp:BoundField DataField="Usuario" HeaderText="Identidad"  />
                                       <asp:BoundField DataField="Contraseña" HeaderText="Nombre"  />  
                                      <asp:BoundField DataField="Nivel" HeaderText="Apellidos"  />                                                           
                                           <asp:ButtonField ButtonType="Button" CommandName="btnModi" Text="Modificar">
                                           <ControlStyle CssClass="btn btn-primary" Width="100px"/>
                                           </asp:ButtonField>
                                           <asp:ButtonField ButtonType="Button" CommandName="btnEliminar" Text="Eliminar">
                                           <ControlStyle CssClass="btn btn-danger" Width="100px"/>
                                           </asp:ButtonField>
                                 
                           </Columns>
                            </asp:GridView>
                       
                    </div>
                </div>
            </div>
        </div>
        <!-- End Datatable -->
    </section>
</asp:Content>

