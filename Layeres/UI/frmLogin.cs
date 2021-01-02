using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTN.Winform.SQLToolBox.Layeres.BLL;
using UTN.Winform.SQLToolBox.Properties;

namespace UTN.Winform.SQLToolBox.Layeres.UI
{
    public partial class frmLogin : Form
    {

        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        private int contador = 0;

        public frmLogin()
        {
            InitializeComponent();
        } 

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            BLLLlogin _BLLLogin = new BLLLlogin();
            epError.Clear();
            try
            {
                if (string.IsNullOrEmpty(this.txtLogin.Text))
                {
                    epError.SetError(txtLogin, "Login requerido");
                    this.txtLogin.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(this.txtPassword.Text))
                {
                    epError.SetError(txtPassword, "Password requerida");
                    this.txtPassword.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(this.txtServer.Text))
                {
                    epError.SetError(txtServer, "Server requerido");
                    this.txtServer.Focus();
                    return;
                }                 

                _BLLLogin.Login(this.txtLogin.Text, this.txtPassword.Text, this.txtServer.Text);

                Settings.Default.Login = this.txtLogin.Text.Trim();
                Settings.Default.Password = this.txtPassword.Text.Trim();
                Settings.Default.Server = this.txtServer.Text.Trim();

                // Log de errores
                _MyLogControlEventos.InfoFormat("Login correcto");
                this.DialogResult = DialogResult.OK;

            }
            catch (SqlException sqlError)
            {

                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error: \n" + Utilitarios.GetCustomErrorByNumber(sqlError), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Si el contador es 3 cierre la aplicación
                if (contador == 3)
                {
                    // se devuelve Cancel
                    MessageBox.Show("Se equivocó en 3 ocasiones, el Sistema se Cerrará por seguridad", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    Application.Exit();
                }
            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(MethodBase.GetCurrentMethod(), er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
