<%@ Page Title="" Language="VB" MasterPageFile="~/Administrador.master" AutoEventWireup="false" CodeFile="Facturas.aspx.vb" Inherits="Facturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <section class="content-header">
        <h1 style="text-align: center">FACTURAS</h1>
    </section>
    <asp:Label ID="LblFac" runat="server" Text="Label" Visible="false"></asp:Label>
     <asp:Label ID="LblPagos" runat="server" Text="Label" Visible="false"></asp:Label>
      <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
    <asp:Label ID="Lblsal" runat="server" Text="Label" Visible="false"></asp:Label>
    <section class="content">
        <div class="row">
                <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>NUMERO DE REFERENCIA</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="TxtRef" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>CLIENTE</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddlCLIENTES" runat="server" CssClass="form-control" DataSourceID="SqlDataSource1" DataTextField="Nombres" DataValueField="Identidad"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LLANRREMAZConnectionString %>" SelectCommand="VerClientesDDL" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        </div>
                        <div class="form-group">
                            <label>FECHA DE LIMITE PAGO</label>
                        </div>
                        <div class="form-group">
                         <%--   <asp:TextBox ID="TextBox3" runat="server" Text="" CssClass="form-control"></asp:TextBox>--%>
                            <input id="txtFch" runat="server" type="date" class="form-control"/>
                        </div>
                        
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>Dias de Credito</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddlDias" runat="server" CssClass="form-control" DataSourceID="SqlDataSource2" DataTextField="NomTiempo" DataValueField="CodTiempo"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LLANRREMAZConnectionString %>" SelectCommand="SELECT [CodTiempo], [NomTiempo] FROM [TiempoCredito]"></asp:SqlDataSource>
                        </div>
                          <div class="form-group">
                            <label>SALDO</label>
                        </div>
                        <div class="form-group">
                             <input id="txtSal" type="number" runat="server"  class="form-control"/>
                        </div>
                         <div class="form-group">
                            <label>Descripcion</label>
                        </div>
                        <div class="form-group">
                            <textarea id="txtDesc"  runat="server"  class="form-control"></textarea>
                        </div>
                    </div>
                </div>
            </div>
                  
        </div>
        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Width="200px" Text="Registrar" />
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
                        <h3 class="box-title">Facturas</h3>
                    </div>
                    <div class="box-body table-responsive">
                       
                       <asp:GridView ID="GvFacturas" runat="server" AutoGenerateColumns="False"  class="table table-bordered table-hover">
                             <Columns>
                                 <asp:BoundField DataField="CRR" HeaderText="CRR"  /> 
                                 <asp:BoundField DataField="Nro_Referencia" HeaderText="Nro_Referencia"  />          
                                       <asp:BoundField DataField="Identidad" HeaderText="Identidad"  />   
                                    <asp:BoundField DataField="Nombres" HeaderText="Nombres"  />  
                                    <asp:BoundField DataField="Apellido" HeaderText="Apellido"  />  
                                    <asp:BoundField DataField="Saldo" HeaderText="Saldo"  />     
                                     <asp:BoundField DataField="Fecha" HeaderText="Fecha"  />                             
                                           <asp:ButtonField ButtonType="Button" CommandName="btnModi" Text="Agg Pago">
                                           <ControlStyle CssClass="btn btn-primary" Width="100px"/>
                                           </asp:ButtonField>
                                           <asp:ButtonField ButtonType="Button" CommandName="btnEliminar" Text="Ver">
                                           <ControlStyle CssClass="btn btn-danger" Width="100px"/>
                                           </asp:ButtonField>  
                                 
                             
                           </Columns>
                            </asp:GridView>
                       
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
                <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>PAGOS</label>
                        </div>
                        <div class="form-group">
                           <asp:TextBox ID="TxtFact" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>MONTO</label>
                        </div>
                        <div class="form-group">
                            <input id="txtMonto" type="number" runat="server"  class="form-control"/>
                           
                        </div>
                        <div class="form-group">
                            <label>BANCO EMISOR</label>
                        </div>
                        <div class="form-group">
                         <asp:DropDownList ID="ddlBanco" runat="server" CssClass="form-control" DataSourceID="SqlDataSource3" DataTextField="Nombre" DataValueField="CodBanco"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:LLANRREMAZConnectionString %>" SelectCommand="SELECT [CodBanco], [Nombre] FROM [Bancos]"></asp:SqlDataSource>
                        </div>
                        
                    </div>
                </div>
            </div>
               </div>
         <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="BtnPagar" runat="server" CssClass="btn btn-primary" Width="200px" Text="Registrar" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <asp:Button ID="BtnCan" runat="server" CssClass="btn btn-danger" Width="200px" Text="Cancelar" />
                    </td>
                </tr>
            </table>
        </div>
        <!-- End Datatable -->
    </section>

</asp:Content>

