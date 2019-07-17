<%@ Page Title="" Language="VB" MasterPageFile="~/Administrador.master" AutoEventWireup="false" CodeFile="Bancos.aspx.vb" Inherits="Bancos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
     <section class="content-header">
        <h1 style="text-align: center">REGISTRO DE BANCOS</h1>
    </section>
        
    <section class="content">
        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>Codigo</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtCod" runat="server" Text="" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>NOMBRE</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNombres" runat="server" Text="" CssClass="form-control"></asp:TextBox>
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
                        <h3 class="box-title">Lista de Bancos</h3>
                    </div>
                    <div class="box-body table-responsive">
                       
                            <asp:GridView ID="GvBancos" runat="server" AutoGenerateColumns="False"  class="table table-bordered table-hover">
                             <Columns>
                                 <asp:BoundField DataField="Codigo" HeaderText="Codigo"  />          
                                       <asp:BoundField DataField="Nombre" HeaderText="Nombre"  />                               
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
     
    </section>
</asp:Content>

