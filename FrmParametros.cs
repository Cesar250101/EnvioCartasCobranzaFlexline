using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace EnvioCartasCobranzas
{
    public partial class FrmParametros : Form
    {
        public FrmParametros()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            TextWriter archivo;
            archivo = new StreamWriter("Envio.ini");
            archivo.WriteLine(tbHost.Text);
            archivo.WriteLine(tbPuerto.Text);
            archivo.WriteLine(chckSSL.Checked);
            archivo.WriteLine(tbUsuario.Text);
            archivo.WriteLine(tbPassword.Text);
            archivo.WriteLine(tbUsuarioFlexline.Text);
            archivo.WriteLine(tbCuentaCorreo.Text);
            archivo.WriteLine(tbNombreUsuario.Text);
            archivo.WriteLine(tbPuestoTrabajo.Text);
            archivo.WriteLine(tbTelefono.Text);
            archivo.Close();
            MessageBox.Show("Configuración guardada con exito", "Guardar", MessageBoxButtons.OK,MessageBoxIcon.Information);
            tbHost.Text = "";
            tbPuerto.Text = "";
            tbUsuario.Text = "";
            tbPassword.Text = "";
            chckSSL.Checked = false;
            tbUsuarioFlexline.Text = "";
            tbCuentaCorreo.Text = "";
            tbNombreUsuario.Text = "";
        }

        private void FrmParametros_Load(object sender, EventArgs e)
        {
            using (StreamReader archico= new StreamReader("Envio.ini"))
            {

                int i = 1;
                while (!archico.EndOfStream)
                {
                    switch (i)
                    {
                        case 1:
                            tbHost.Text = archico.ReadLine();
                            break;
                        case 2:
                            tbPuerto.Text = archico.ReadLine();
                            break;
                        case 3:
                            chckSSL.Checked = archico.ReadLine() == "True" ? chckSSL.Checked = true : chckSSL.Checked = false;
                            break;
                        case 4:
                            tbUsuario.Text = archico.ReadLine();
                            break;
                        case 5:
                            tbPassword.Text = archico.ReadLine();
                            break;
                        case 6:
                            tbUsuarioFlexline.Text = archico.ReadLine();
                            break;
                        case 7:
                            tbCuentaCorreo.Text = archico.ReadLine();
                            break;
                        case 8:
                            tbNombreUsuario.Text = archico.ReadLine();
                            break;
                        case 9:
                            tbPuestoTrabajo.Text = archico.ReadLine();
                            break;
                        case 10:
                            tbTelefono.Text = archico.ReadLine();
                            break;

                        default:
                            break;
                    }
                    i += 1;

                }
            }
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }
    }
}
