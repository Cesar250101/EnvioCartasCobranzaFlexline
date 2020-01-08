using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Configuration;

namespace EnvioCartasCobranzas
{
    public partial class frmCobranza : Form
    {
        string host = "";
        string puerto = "";
        Boolean ssl = true;
        string usuario = "";
        string password = "";
        string usuarioFlexline;
        string cuentaCorreo;
        string nombreUsuario;
        string puestoTrabajo;
        string telefono;
        string destinatarios;
        string asunto;
        string stringhtmlBody;
        string empresa = "vendomatic";
        string servidor = "192.168.255.162";
        string usuarioBD = "DesarrolloCO";
        string passwordBD = "fF6s9JMLoVpF5";
        //string empresa = "001";
        //string servidor = "191.0.0.35";
        //string usuarioBD = "flexline";
        //string passwordBD = "flexline";

        string pieEmail;

        public frmCobranza()
        {
            InitializeComponent();
        }

        private void ParametrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmParametros pmt = new FrmParametros();
            pmt.Show();
        }

        private void BtnLeer_Click(object sender, EventArgs e)
        {
            LeerDatos();
        }

        private void LeerDatos()
        {
            dgvDatos.Rows.Clear();
            tsslMensajes.Text = "Status : Cargando Datos.....";
            string strCommand = "SELECT convert(varchar(20),m.aux_valor3) as Rut,g1.DESCRIPCION as Nombre, coalesce((select max(coalesce(cd.Email, ''))";
            strCommand += " from ctacte c, CtaCteDirecciones cd";
            strCommand += " where c.Empresa = cd.Empresa";
            strCommand += " and c.TipoCtaCte = cd.TipoCtaCte";
            strCommand += " and c.CtaCte = cd.CtaCte";
            strCommand += " and c.CodLegal = m.AUX_VALOR3";
            strCommand += " and c.Empresa = m.EMPRESA";
            strCommand += " and c.TipoCtaCte = 'cliente'),'') as Email, ";
            strCommand += " c.ALIAS_CUENTA as Cuentas,c.DESCRIPCION as NombreCuenta,  sum(m.debe_Origen - m.haber_origen) Saldo,min(m.FECHAVCTO) as PrimerVcto,";
            strCommand += " coalesce((select top 1 Actividad from COB_ACCIONES where Empresa=m.EMPRESA and Cliente=m.AUX_VALOR3 order by FechaAccion desc),'') UltimaActividad,";
            strCommand += " COALESCE((SELECT TOP 1 FechaAccion FROM COB_ACCIONES WHERE Empresa = m.EMPRESA AND Cliente = m.AUX_VALOR3 ORDER BY FechaAccion DESC), '') FechaUltimaActividad";
            strCommand += " FROM BDFlexline.flexline.con_movcom m";
            strCommand += " INNER JOIN BDFlexline.flexline.con_enccom e ON m.fecha = e.fecha";
            strCommand += " AND m.empresa = e.empresa";
            strCommand += " AND m.estado = e.estado";
            strCommand += " AND m.empresa = e.empresa";
            strCommand += " AND m.tipo_comprobante = e.tipo_comprobante";
            strCommand += " AND m.correlativo = e.correlativo";
            strCommand += " AND m.periodo = e.periodo";
            strCommand += " INNER JOIN BDFlexline.flexline.con_ctacon c ON c.empresa = m.empresa";
            strCommand += " AND c.cuenta = m.cuenta";
            strCommand += " RIGHT JOIN BDFlexline.flexline.gen_tabcod g1 ON g1.empresa = m.empresa";
            strCommand += " AND g1.codigo = m.aux_valor3";
            strCommand += " AND g1.tipo = 'con_client'";
            strCommand += " LEFT JOIN Documento d ON m.EMPRESA = d.Empresa";
            strCommand += " AND m.TIPO_DOCUMENTO = d.TipoDocto";
            strCommand += " AND m.CORRELATIVOCOMERCIAL = d.Correlativo";
            strCommand += " AND d.TipoCtaCte = 'cliente'";
            strCommand += " WHERE e.empresa = 'vendomatic'";
            strCommand += " and e.periodo= '"+ dtpVencidosDesde.Value.Year +"'";
            strCommand += " AND e.estado = 'a'";
            strCommand += " AND COALESCE(m.proceso, '') <> 'cierre'";
            strCommand += " AND NOT(m.debe_origen = 0";
            strCommand += " AND m.haber_origen = 0)";
            strCommand += " AND COALESCE(m.aux_valor3, '') <> ''";
            strCommand += " AND c.cuenta IN('010104010000')";
            strCommand += " AND c.ind_analisis = 's'";
            strCommand += " AND c.aux_valor3 = 2";
            if (rbPorVencer.Checked == true)
            {
                strCommand += " and m.FECHAVCTO >= getdate()";
            }
            else
            {
                strCommand += " AND m.fechavcto <= '" + dtpVencidosHasta.Value + "'";
            }
            if (cbGrupoCobranza.Text!="")
            {
                strCommand += " and m.AUX_VALOR3 in(select CodLegal from CTACTE where Empresa='" + empresa + "' and TipoCtaCte='cliente' and flujocob='" + cbGrupoCobranza.Text + "')";
            }
            if (cbGrupoCtaCte.Text!="")
            {
                strCommand += " and m.AUX_VALOR3 in(select CodLegal from CTACTE where Empresa='"+empresa+"' and TipoCtaCte='cliente' and Grupo='"+ cbGrupoCtaCte.Text +"')";
            }
            if (cbVendedor.Text!="")
            {
                strCommand += " and m.AUX_VALOR3 in(select codlegal from CTACTE where Empresa='" + empresa + "' and TipoCtaCte='cliente' and CobradorCob='" + cbVendedor.Text + "')";
            }
            if (cbUltimaAccion.Text!="")
            {
                strCommand += " and COALESCE((SELECT TOP 1 Actividad FROM COB_ACCIONES WHERE Empresa = m.EMPRESA AND Cliente = m.AUX_VALOR3 ORDER BY FechaAccion DESC), '')= '"+cbUltimaAccion.Text+"'";
            }
            strCommand += " GROUP BY m.empresa,convert(varchar(20), m.aux_valor3),g1.DESCRIPCION,c.ALIAS_CUENTA ,c.DESCRIPCION";
            strCommand += " HAVING sum(m.debe_Origen - m.haber_origen) <> 0";
            strCommand += " order by m.AUX_VALOR3";
            using (SqlConnection cn = new SqlConnection("Server='"+ servidor +"';User Id='"+ usuarioBD +"';Password='"+ passwordBD +"';Database=BdFlexline;"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(strCommand, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                int i = 1;

                while (dr.Read())
                {
                    int renglon = dgvDatos.Rows.Add();
                    dgvDatos.Rows[renglon].Cells["Rut"].Value = dr.GetString(0);
                    dgvDatos.Rows[renglon].Cells["Nombre"].Value = dr.GetString(1);
                    dgvDatos.Rows[renglon].Cells["eMail"].Value = dr.GetString(2);
                    dgvDatos.Rows[renglon].Cells["Cuenta"].Value = dr.GetString(3);
                    dgvDatos.Rows[renglon].Cells["NombreCuenta"].Value = dr.GetString(4);
                    dgvDatos.Rows[renglon].Cells["Saldo"].Value = dr.GetDecimal(5).ToString("###,###");
                    dgvDatos.Rows[renglon].Cells["PrimerVcto"].Value = dr.GetDateTime(6);
                    dgvDatos.Rows[renglon].Cells["UltimaAccion"].Value = dr.GetString(7);
                    dgvDatos.Rows[renglon].Cells["FechaUltimaAccion"].Value = dr.GetDateTime(8);
                    
                }
                cn.Close();
            }
            tsslMensajes.Text = "Status : ";

        }

        private void BtnSeleccionarTodos_Click(object sender, EventArgs e)
        {
            int r = 0;            
            foreach (var i in dgvDatos.Rows)
            {
                dgvDatos.Rows[r].Cells["Seleccion"].Value = true;
                r += 1;
            }
        }

        private void BtnEnviarEmail_Click(object sender, EventArgs e)
        {
            DataGridViewCheckBoxCell oCell;
            foreach (DataGridViewRow i in dgvDatos.Rows)
            {
                oCell = i.Cells["Seleccion"] as DataGridViewCheckBoxCell;
                bool bChecked = (null != oCell && null != oCell.Value && true == (bool)oCell.Value);
                if (true == bChecked)
                {
                    if (cbTipoEmail.Text!="")
                    {
                        EnviarEmailCobranza(i.Cells["Rut"].Value.ToString(), Convert.ToDouble(i.Cells["Saldo"].Value), cbTipoEmail.Text);
                    }

                }
            }
        }

        private void EnviarEmailCobranza(string rut,double totalDeuda,string tipoEmail)
        {
            tsslMensajes.Text = "Status : Enviando eMail a Clientes.......";
            ObtenerParametros();
            string strCommand = "SELECT convert(varchar(20),m.aux_valor3) as Rut,g1.DESCRIPCION as Nombre, ";
            strCommand += " (select max(coalesce(cd.Email, '')) from bdflexline.flexline.ctacte c, CtaCteDirecciones cd";
            strCommand += " where c.Empresa = cd.Empresa";
            strCommand += " and c.TipoCtaCte = cd.TipoCtaCte";
            strCommand += " and c.CtaCte = cd.CtaCte";
            strCommand += " and c.CodLegal = m.AUX_VALOR3";
            strCommand += " and c.Empresa = m.EMPRESA";
            strCommand += " and c.TipoCtaCte = 'cliente') as Email,";
            strCommand += " COALESCE(td.Nemotecnico, m.Tipo_Documento) TipoDocto,  m.Referencia Numero, max(coalesce(d.FECHA,getdate())) FechaEmision, Min(coalesce(m.FECHAVCTO,'01/01/2000')) FechaVcto,  ";
            strCommand += " sum(m.debe_Origen - m.haber_origen) Saldo,max(coalesce(d.Glosa,'')) 'Glosa',convert(integer, max(datediff(dd, m.fechavcto, getdate()))) 'DifDias'";
            strCommand += " FROM BDFlexline.flexline.con_movcom m";
            strCommand += " INNER JOIN BDFlexline.flexline.con_enccom e ON m.fecha = e.fecha";
            strCommand += " AND m.empresa = e.empresa";
            strCommand += " AND m.estado = e.estado";
            strCommand += " AND m.empresa = e.empresa";
            strCommand += " AND m.tipo_comprobante = e.tipo_comprobante";
            strCommand += " AND m.correlativo = e.correlativo";
            strCommand += " AND m.periodo = e.periodo";
            strCommand += " INNER JOIN BDFlexline.flexline.con_ctacon c ON c.empresa = m.empresa";
            strCommand += " AND c.cuenta = m.cuenta";
            strCommand += " RIGHT JOIN BDFlexline.flexline.gen_tabcod g1 ON g1.empresa = m.empresa";
            strCommand += " AND g1.codigo = m.aux_valor3";
            strCommand += " AND g1.tipo = 'con_client'";
            strCommand += " LEFT JOIN BDFlexline.flexline.gen_tabcod td ON m.empresa = td.empresa";
            strCommand += " AND m.Tipo_Documento = td.codigo";
            strCommand += " AND 'CON_TIPDOC' = td.tipo";
            strCommand += " LEFT JOIN BDFlexline.flexline.Documento d ON m.EMPRESA = d.Empresa";
            strCommand += " AND m.TIPO_DOCUMENTO = d.TipoDocto";
            strCommand += " AND m.CORRELATIVOCOMERCIAL = d.Correlativo";
            strCommand += " AND d.TipoCtaCte = 'cliente'";
            strCommand += " WHERE e.empresa = 'vendomatic'";
            strCommand += " AND e.estado = 'a'";
            strCommand += " AND e.periodo = '"+ dtpVencidosDesde.Value.Year +"'";
            strCommand += " AND COALESCE(m.proceso, '') <> 'cierre'";
            strCommand += " AND NOT(m.debe_origen = 0";
            strCommand += " AND m.haber_origen = 0)";
            strCommand += " AND COALESCE(m.aux_valor3, '') <> ''";
            strCommand += " AND c.cuenta IN('010104010000')";
            strCommand += " AND c.ind_analisis = 's'";
            strCommand += " AND c.aux_valor3 = 2";
            strCommand += " AND COALESCE(m.aux_valor3, '') = '"+ rut +"'";
            if (rbPorVencer.Checked == true)
            {
                strCommand += " and m.FECHAVCTO >= getdate()";
            }
            else
            {
                strCommand += " AND e.fecha <= '"+ dtpVencidosHasta.Value +"'";
            }
            if (cbGrupoCobranza.Text != "")
            {
                strCommand += " and m.AUX_VALOR3 in(select CodLegal from CTACTE where Empresa='" + empresa + "' and TipoCtaCte='cliente' and flujocob='" + cbGrupoCobranza.Text + "')";
            }
            if (cbGrupoCtaCte.Text != "")
            {
                strCommand += " and m.AUX_VALOR3 in(select CodLegal from CTACTE where Empresa='" + empresa + "' and TipoCtaCte='cliente' and Grupo='" + cbGrupoCtaCte.Text + "')";
            }
            if (cbVendedor.Text != "")
            {
                strCommand += " and m.AUX_VALOR3 in(select codlegal from CTACTE where Empresa='" + empresa + "' and TipoCtaCte='cliente' and CobradorCob='" + cbVendedor.Text + "')";
            }
            if (cbUltimaAccion.Text != "")
            {
                strCommand += " and COALESCE((SELECT TOP 1 Actividad FROM COB_ACCIONES WHERE Empresa = m.EMPRESA AND Cliente = m.AUX_VALOR3 ORDER BY FechaAccion DESC), '')= '" + cbUltimaAccion.Text + "'";
            }
            strCommand += " GROUP BY convert(varchar(20), m.aux_valor3),g1.DESCRIPCION,c.Descripcion, COALESCE(td.Nemotecnico, m.Tipo_Documento), m.Referencia,m.Empresa";
            strCommand += " HAVING sum(m.debe_Origen - m.haber_origen) <> 0";
            strCommand += " order by convert(integer, max(datediff(dd, m.fechavcto, getdate()))) desc";


            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem mailItem = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;


            using (SqlConnection cn = new SqlConnection("Server='"+ servidor +"';User Id='"+ usuarioBD +"';Password='"+ passwordBD +"';Database=BdFlexline;"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(strCommand, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                int i = 1;
                string encabezado= String.Format("{0}\t{1}\t{2}\t{3}\t{4}", "Factura", "Fecha Emisión","Fecha Vcto","Saldo","Servicio");
                string encabezadoEmail = "";

                while (dr.Read())
                {
                    if (i==1)
                    {
                        asunto = rbPorVencer.Checked ? "Aviso proximos vencimientos " + dr.GetString(1) + "" : "Aviso Deuda Vencida " + dr.GetString(1) + "";
                        if (rbPorVencer.Checked==true)
                        {
                            stringhtmlBody = "<p>Estimado cliente <strong>" + dr.GetString(1) + "</strong> , mediante la presente, nos permitimos recordarle los vencimientos de documentos que continuación detallamos:</p>";
                        }
                        else
                        {
                            switch (tipoEmail)
                            {
                                case "eMail_1":
                                    encabezadoEmail = "Junto con saludar y en nuestra permanente búsqueda por entregar una mejor y más oportuna información, ";
                                    encabezadoEmail += " le recordamos que según nuestros registros su empresa mantiene una deuda pendiente ";
                                    encabezadoEmail += " por un monto de $"+ totalDeuda.ToString("###,###") +" , monto cuya composición detallamos en tabla adjunta.";
                                    break;
                                case "eMail_2":
                                    encabezadoEmail = "A través de la presente informo a usted que a la fecha y según nuestros registros mantiene una deuda ";
                                    encabezadoEmail += " pendiente de pago de $"+ totalDeuda.ToString("###,###") + ", de no solucionar esta situación lamentablemente nos obligara a la suspensión del servicio.";
                                    break;
                                case "eMail_3":
                                    encabezadoEmail = "A través de la presente, informo a usted que a pesar de las reiteradas gestiones de cobranza que se han realizado,";
                                    encabezadoEmail += " a la fecha no se han cancelado los documentos detallados a continuación por un monto de $" + totalDeuda.ToString("###,###") + ".";
                                    encabezadoEmail += " Damos aviso de la suspensión de nuestro servicio y posterior publicación en Dicom de no tener respuesta dentro de los próximos 5 días hábiles";
                                    break;
                                default:
                                    break;
                            }
                            stringhtmlBody += "<p>Estimado cliente <strong>" + dr.GetString(1) + "</strong> "+ encabezadoEmail +":</p>";
                        }
                        stringhtmlBody += "</br>";
                        stringhtmlBody += "</br>";
                        stringhtmlBody += "<body>";
                        stringhtmlBody += "<table width = '600' border = '1' >";
                        stringhtmlBody += "<tr>";
                            stringhtmlBody += "<td bgcolor = '#000080' style='color:#FFFFFF;'>Documento</td>";
                            stringhtmlBody += "<td bgcolor = '#000080' style='color:#FFFFFF;'>Número</td>";
                            stringhtmlBody += "<td bgcolor = '#000080' style='color:#FFFFFF;'>Fecha Emisión</td>";
                            stringhtmlBody += "<td bgcolor = '#000080' style='color:#FFFFFF;'>Fecha Vcto</td>";
                            stringhtmlBody += "<td bgcolor = '#000080' style='color:#FFFFFF;'>Saldo</td>";
                            stringhtmlBody += "<td bgcolor = '#000080' style='color:#FFFFFF;'>Servicio</td>";
                            stringhtmlBody += "<td bgcolor = '#000080' style='color:#FFFFFF;'>Días Atraso</td>";
                        stringhtmlBody += "</tr>";
                    }

                    destinatarios = dr.GetString(2).ToString();
                    stringhtmlBody += "<tr>";
                        stringhtmlBody += "<td bgcolor = '#000080' style='color:#FFFFFF;'>Factura</td>";
                        stringhtmlBody += "<td bgcolor = '#FFFFFF'>" + dr.GetString(4) + "</td>";
                        stringhtmlBody += "<td bgcolor = '#FFFFFF'>"+ dr.GetDateTime(5).ToString().Substring(0, 10) + "</td>";
                        stringhtmlBody += "<td bgcolor = '#FFFFFF'>" + dr.GetDateTime(6).ToString().Substring(0, 10) + "</td>";
                        stringhtmlBody += "<td bgcolor = '#FFFFFF' align='right' >" + Convert.ToInt64(dr.GetDecimal(7)).ToString("###,###") + "</td>";
                        stringhtmlBody += "<td bgcolor = '#FFFFFF'>" + dr.GetString(8) + "</td>";
                        stringhtmlBody += "<td bgcolor = '#FFFFFF' align='right' >" + dr.GetInt32(9).ToString() + "</td>";
                    stringhtmlBody += "</tr>";

                    RegistrarActividad(dr.GetString(0),dr.GetString(3),dr.GetString(4),dr.GetDateTime(5),asunto,tipoEmail);
                    i += 1;
                }
                cn.Close();
            }
                mailItem.Body += nombreUsuario;
                mailItem.Body += puestoTrabajo;
                mailItem.Body += telefono;

            stringhtmlBody += "</table>";
            
            switch (tipoEmail)
            {
                case "eMail_3":
                    pieEmail = "Quedamos a su disposición para aclarar cualquier duda al respecto";
                    break;
                default:
                    pieEmail = "Si a la fecha usted pago parte o toda la deuda por favor enviar información de pago al siguiente mail: pagos@vendomatica.cl";
                    break;
            }

            stringhtmlBody += "<p>"+ pieEmail +"</p>";
            stringhtmlBody += "<br/>";
            stringhtmlBody += "<br/>";
            stringhtmlBody += "<div align='center'>";
            stringhtmlBody += "<span><strong>"+nombreUsuario+"</strong></span>";
            stringhtmlBody += "<br>";
            stringhtmlBody += "<span><strong>"+ puestoTrabajo +"</strong></span>";
            stringhtmlBody += "<br>";
            stringhtmlBody += "<span><strong>"+ telefono +"</strong></span>";
            stringhtmlBody += "<br>";
            stringhtmlBody += "</div>";
            stringhtmlBody += "</body>";
            mailItem.Subject = asunto;
            mailItem.To = destinatarios;
            mailItem.CC = "cristian.saavedra@vendomatica.cl;eric.rodriguez@vendomatica.cl;monica.vasquez@vendomatica.cl";
            //mailItem.Attachments.Add(logPath);//logPath is a string holding path to the log.txt file
            mailItem.Importance = Outlook.OlImportance.olImportanceHigh;
            mailItem.HTMLBody = stringhtmlBody;
            mailItem.Send();
            stringhtmlBody = "";
            mailItem = null;


            tsslMensajes.Text = "Status : ";
        }

        private void RegistrarActividad(string cliente, string tipoDocto, string numero, DateTime fecha, string descripcionActividad, string Actividad)
        {
            tsslMensajes.Text = "Status : Grabando actividade de cobranza en Flexline en le módulo de cobranza";
            using (SqlConnection cnn = new SqlConnection("Server='"+ servidor +"';User Id='"+ usuarioBD +"';Password='"+ passwordBD +"';Database=BdFlexline;"))
            {
                cnn.Open();
                string strCommandU = "insert into COB_ACCIONES (Empresa,Cuenta,Cliente,TipoDocumento,Referencia,FechaOriginal,Actividad,Flujo,Cobrador,Comentario,FechaProx,FechaAccion,FechaModif,";
                strCommandU += " UsuarioModif,ESTADOACT,fecharealizada) ";
                strCommandU += " values('" + empresa + "', '010104010000', '" + cliente + "', '" + tipoDocto + "', '" + numero + "', '" + fecha + "', '"+ Actividad +"', 'PEQUEÑAS.EMPRESAS', '" + usuarioFlexline + "', '"+ descripcionActividad + "', getdate(), getdate(),";
                strCommandU += " getdate(), '"+ usuarioFlexline +"', 'Finalizado', getdate())";
                SqlCommand cmdU = new SqlCommand(strCommandU, cnn);
                cmdU.ExecuteNonQuery();
            }
            tsslMensajes.Text = "Status : ";
        }

            private void ObtenerParametros()
        {
            using (StreamReader archico = new StreamReader("Envio.ini"))
            {

                int i = 1;
                while (!archico.EndOfStream)
                {
                    switch (i)
                    {
                        case 1:
                            host = archico.ReadLine();
                            break;
                        case 2:
                            puerto = archico.ReadLine();
                            break;
                        case 3:
                            ssl = archico.ReadLine() == "True" ? true : false;
                            break;
                        case 4:
                            usuario = archico.ReadLine();
                            break;
                        case 5:
                            password = archico.ReadLine();
                            break;
                        case 6:
                            usuarioFlexline = archico.ReadLine();
                            break;
                        case 7:
                            cuentaCorreo = archico.ReadLine();
                            break;
                        case 8:
                            nombreUsuario = archico.ReadLine();
                            break;
                        case 9:
                            puestoTrabajo = archico.ReadLine();
                            break;
                        case 10:
                            telefono = archico.ReadLine();
                            break;

                        default:
                            break;
                    }
                    i += 1;

                }
            }

        }

        private void RbPorVencer_CheckedChanged(object sender, EventArgs e)
        {
            dgvDatos.Rows.Clear();
        }

        private void RbVencidos_CheckedChanged(object sender, EventArgs e)
        {
            dgvDatos.Rows.Clear();
        }

        private void FrmCobranza_Load(object sender, EventArgs e)
        {
            string año = DateTime.Now.Year.ToString();
            dtpVencidosDesde.Value = Convert.ToDateTime("01/01/"+año);
            dtpVencidosHasta.Value = DateTime.Now;
            CargarCombos();
        }

        private void CargarCombos()
        {
            tsslMensajes.Text = "Status : Cargando Datos.....";
            string strCommand = "select distinct grupo from CTACTE where EMPRESA='"+empresa+"' and coalesce(Grupo,'')<>'' ";

            using (SqlConnection cn = new SqlConnection("Server='" + servidor + "';User Id='" + usuarioBD + "';Password='" + passwordBD + "';Database=BdFlexline;"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(strCommand, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                int i = 1;

                while (dr.Read())
                {
                    cbGrupoCtaCte.Items.Add(dr.GetString(0));
                }
                cn.Close();
            }
            tsslMensajes.Text = "Status : ";

            tsslMensajes.Text = "Status : Cargando Datos.....";
            strCommand = "select distinct CobradorCob from CTACTE where Empresa='"+ empresa + "' and TipoCtaCte='cliente' ";

            using (SqlConnection cn = new SqlConnection("Server='" + servidor + "';User Id='" + usuarioBD + "';Password='" + passwordBD + "';Database=BdFlexline;"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(strCommand, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                int i = 1;

                while (dr.Read())
                {
                    cbVendedor.Items.Add(dr.GetString(0));
                }
                cn.Close();
            }
            tsslMensajes.Text = "Status : ";

            tsslMensajes.Text = "Status : Cargando Datos.....";

            strCommand = "select distinct FlujoCob from CTACTE where EMPRESA='"+empresa+"'  and coalesce(FlujoCob,'')<>''";

            using (SqlConnection cn = new SqlConnection("Server='" + servidor + "';User Id='" + usuarioBD + "';Password='" + passwordBD + "';Database=BdFlexline;"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(strCommand, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                int i = 1;

                while (dr.Read())
                {
                    cbGrupoCobranza.Items.Add(dr.GetString(0));
                }
                cn.Close();
            }
            tsslMensajes.Text = "Status : ";


        }


        private void RbVencidos_CheckedChanged_1(object sender, EventArgs e)
        {
            dgvDatos.Rows.Clear();
        }

        private void RbPorVencer_CheckedChanged_1(object sender, EventArgs e)
        {
            dgvDatos.Rows.Clear();
        }

        private void LimpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvDatos.Rows.Clear();
            cbGrupoCobranza.SelectedIndex = -1;
            cbGrupoCtaCte.SelectedIndex = -1;
            cbVendedor.SelectedIndex = -1;
        }
    }
}
