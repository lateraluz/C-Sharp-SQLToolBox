using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTN.Winform.SQLToolBox.Layeres.BLL;
using UTN.Winform.SQLToolBox.Layeres.Entities;
using UTN.Winform.SQLToolBox.Properties;

namespace UTN.Winform.SQLToolBox.Layeres.UI
{
    public partial class frmMain : Form
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        public frmMain()
        {
            InitializeComponent();
            rtbData.DragEnter += RtbData_DragEnter;
            rtbData.DragDrop += RtbData_DragDrop;
            this.rtbData.AllowDrop = true;
            spcContenedor.DragEnter += SpcContenedor_DragEnter;
            spcContenedor.Panel1.DragEnter += Panel1_DragEnter;
            spcContenedor.Panel2.DragEnter += Panel2_DragEnter;
            spcContenedor.Panel1.AllowDrop = true;
            spcContenedor.Panel2.AllowDrop = true;
            spcContenedor.AllowDrop = true;
            splitContainer1.AllowDrop = true;

        }

        private void RtbData_DragDrop(object sender, DragEventArgs e)
        {
            // Point clientPoint = rtbData.PointToClient(new Point(e.X, e.Y));
            // this.cmdBaseDatosMenuContextual.Show(rtbData, clientPoint);
        }

        private void Panel2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void Panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void SpcContenedor_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void RtbData_DragEnter(object sender, DragEventArgs e)
        {

            if (this.trvDataBases.SelectedNode == null)
            {
                return;
            }

            if (this.trvDataBases.SelectedNode.Level == 0)
            {
                return;
            }

            e.Effect = DragDropEffects.Copy;
            Point clientPoint = rtbData.PointToClient(new Point(e.X, e.Y));
            this.cmdBaseDatosMenuContextual.Show(rtbData, clientPoint);

        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {

                this.trvDataBases.AllowDrop = true;

                _MyLogControlEventos.InfoFormat("Entro a Form Principal");
                this.Text = Application.ProductName + " " + Application.ProductVersion;
                //     this.dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                Utilitarios.CultureInfo();

                if (!Directory.Exists(@"C:\temp"))
                    Directory.CreateDirectory(@"C:\temp");
            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(MethodBase.GetCurrentMethod(), er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void toolStripClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripBtnConnectDisconect_Click(object sender, EventArgs e)
        {
            frmLogin ofrmLogin = new frmLogin();
            BLLDataBase _BLLDataBase = new BLLDataBase();
            try
            {
                ofrmLogin.ShowDialog(this);
                if (ofrmLogin.DialogResult == DialogResult.OK)
                {
                    List<DataBaseStorage> listaBasesDatos = _BLLDataBase.GetDataBases();
                    // Sort
                    listaBasesDatos = listaBasesDatos.OrderBy(p => p.DataBaseName).ToList();

                    if (listaBasesDatos != null)
                    {
                        foreach (var item in listaBasesDatos)
                            this.toolStripCmbDataBase.Items.Add(item);
                    }

                    if (listaBasesDatos.Count > 0)
                    {
                        this.toolStripCmbDataBase.SelectedIndex = 0;

                        // llenar TreeView
                        trvDataBases.Nodes.Clear();

                        trvDataBases.ImageList = this.imgLista;
                        trvDataBases.ImageIndex = 0;

                        TreeNode root = trvDataBases.Nodes.Add("Server", "Server " + Settings.Default.Server, 2, 2);

                        int nivel = 0;
                        int tableTag = 0;
                        foreach (var BaseDatos in listaBasesDatos)
                        {
                            TreeNode sibling = root.Nodes.Add(BaseDatos.Id.ToString(), BaseDatos.DataBaseName.ToString(), 0, 5);

                            List<Table> listaTablas = BaseDatos.GetTablas();

                            tableTag = 0;
                            foreach (var tabla in listaTablas)
                            {
                                sibling.Nodes.Add(tabla.Id.ToString(), tabla.TableName.ToString(), 3, 4);

                                tableTag++;
                            }
                            nivel++;
                        }
                    }
                }

                toolStripStatuslblStatus.Text = "Conectado";
                _MyLogControlEventos.InfoFormat("Llenó Combo Bases de Datos");
            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(MethodBase.GetCurrentMethod(), er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolStripBtnDesconectar_Click(object sender, EventArgs e)
        {
            try
            {

                Settings.Default.Server = "";
                Settings.Default.Login = "";
                Settings.Default.Password = "";
                this.trvDataBases.Nodes.Clear();
                this.rtbData.Clear();
                this.dgvDatos.DataSource = null;

                toolStripStatuslblStatus.Text = "Desconectado";
                _MyLogControlEventos.InfoFormat("Desconectado");
            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(MethodBase.GetCurrentMethod(), er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripBtnLimpiar_Click(object sender, EventArgs e)
        {
            this.rtbData.Clear();
            this.dgvDatos.DataSource = null;
        }

        private void cmdBaseDatosMenuContextual_Opening(object sender, CancelEventArgs e)
        {

            if (this.trvDataBases.SelectedNode == null)
            {
                e.Cancel = true;
                return;
            }

            if (this.trvDataBases.SelectedNode.Level == 0)
            {
                e.Cancel = true;
                return;
            }

            if (this.trvDataBases.SelectedNode.Level == 1)
            {
                this.generarStoredProcedureToolStripMenuItem.Visible = false;
                this.crearEntitiesToolStripMenuItem.Visible = true;
                this.crearSqlCommandToolStripMenuItem.Visible = false;
            }
            else
            {
                if (this.trvDataBases.SelectedNode.Level == 2)
                {
                    this.generarStoredProcedureToolStripMenuItem.Visible = true;
                    this.crearEntitiesToolStripMenuItem.Visible = false;
                    this.crearSqlCommandToolStripMenuItem.Visible = true;
                }
            }
        }

        private void generarStoredProcedureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string statement = "";
            int indice = 0;
            BLLStoredProcedure _BLLCRUD = new BLLStoredProcedure();
            try
            {
                if (this.trvDataBases.SelectedNode.Parent.FullPath != null)
                {
                    indice = this.toolStripCmbDataBase.FindString(this.trvDataBases.SelectedNode.Parent.Text);
                    this.toolStripCmbDataBase.SelectedIndex = indice;
                    statement = _BLLCRUD.CreateStoredProcedure(this.trvDataBases.SelectedNode.Parent.Text,
                                                                this.trvDataBases.SelectedNode.Text);
                    this.rtbData.AppendText(statement);

                    ColorSQLTextStatements();
                }
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(MethodBase.GetCurrentMethod(), er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ColorADOTextStatements()
        {
            string[] arreglo1 = { "SqlCommand command = new SqlCommand();",
                                  "command.Parameters.AddWithValue",
                                  "command.CommandType = CommandType.Text",
                                  "command.CommandText = sql;",
                                  "string  sql=" };

            if (string.IsNullOrEmpty(this.rtbData.Text))
            {
                return;
            }

 
            arreglo1.ToList().ForEach(
               (item) =>
               {
                   ChangeColorWord(item, Color.Black);
               }
             );
  

            string[] arreglo2 = { "sql ", "@"   };          
            arreglo2.ToList().ForEach(
              (item) =>
              {
                  ChangeColorWord(item, Color.Blue);
              }
            );

            string[] arreglo3 = { ",\"\"" };
            arreglo3.ToList().ForEach(
              (item) =>
              {
                  ChangeColorWord(item, Color.Red);
              }
            );

            // Deseleccionar cualquier cosa
            this.rtbData.Select(0, 0);
        }

        /// <summary>
        /// Pintar el SQL 
        /// </summary>
        private void ColorSQLTextStatements()
        {
            string[] arreglo1 = { "USE ", "CREATE procedure ", "If ", "As ", "is NOT NULL ", "Drop Proc", "Object_id('", "')" };
            string[] arreglo2 = { "Insert Into ", "VALUES ", "Delete from", "Select ", " from ", "Update ", "SET ", "Where ", " and ", " OR " };

            if (string.IsNullOrEmpty(this.rtbData.Text))
            {
                return;
            }

            arreglo1.ToList().ForEach(
               (item) =>
               {
                   ChangeColorWord(item, Color.Green);
               }
             );


            arreglo2.ToList().ForEach(
                (item) =>
                  {
                      ChangeColorWord(item, Color.Green);
                  }
                );

            // Deseleccionar cualquier cosa
            this.rtbData.Select(0, 0);
        }

        private void ChangeColorWord(string pWord, Color pColor)
        {

            int last = 0;
            int index = 0;

            while ((index = this.rtbData.Text.IndexOf(pWord, last, StringComparison.CurrentCultureIgnoreCase)) >= 0)
            {
                if (index >= 0)
                {
                    rtbData.Select(index, pWord.Length);
                    rtbData.SelectionColor = pColor;
                    rtbData.SelectionFont = new Font(rtbData.Font, FontStyle.Bold);
                    last = index + 1;
                }
            }

        }

        private void crearEntitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Entity> listaEntities = new List<Entity>();
            BLLEntities _BLLEntities = new BLLEntities();
            try
            {
                listaEntities = _BLLEntities.CreateEntities(this.trvDataBases.SelectedNode.Text);

                foreach (var item in listaEntities)
                {
                    this.rtbData.AppendText(item.Detail);
                }

            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(MethodBase.GetCurrentMethod(), er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void crearSqlCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLLCommand _BLLCommand = new BLLCommand();
            try
            {
                string mensaje = _BLLCommand.CrearCommand(this.trvDataBases.SelectedNode.Parent.Text,
                                                            this.trvDataBases.SelectedNode.Text);
                this.rtbData.AppendText(mensaje);

                ColorADOTextStatements();


            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(MethodBase.GetCurrentMethod(), er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripBtnAcercade_Click(object sender, EventArgs e)
        {
            frmAcercade ofrmAcercade = new frmAcercade();
            ofrmAcercade.ShowDialog(this);
        }

        private void toolStripBtnEjecutarSQL_Click(object sender, EventArgs e)
        {
            string sentencia = "";
            DataSet ds = new DataSet();
            BLLSql _BLLSql = new BLLSql();
            try
            {
                if (string.IsNullOrEmpty(this.rtbData.Text))
                {
                    this.rtbData.Focus();
                    return;
                }

                if (this.rtbData.SelectedText.Trim().Length > 0)
                    sentencia = this.rtbData.SelectedText.Trim();
                else
                    sentencia = this.rtbData.Text.Trim();

                this.dgvDatos.AutoGenerateColumns = true;

                ds = _BLLSql.ExecuteSQL(((DataBaseStorage)this.toolStripCmbDataBase.SelectedItem).DataBaseName, sentencia);

                if (ds.Tables.Count > 0)
                {
                    this.dgvDatos.DataSource = ds.Tables[0];
                }

            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(MethodBase.GetCurrentMethod(), er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trvDataBases_ItemDrag(object sender, ItemDragEventArgs e)
        {
            trvDataBases.DoDragDrop(e.Item, DragDropEffects.Copy);

            //DoDragDrop(e.Item, DragDropEffects.Copy);
        }

        private void trvDataBases_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void trvDataBases_DragOver(object sender, DragEventArgs e)
        {
            //// Retrieve the client coordinates of the mouse position.  
            //Point targetPoint = trvDataBases.PointToClient(new Point(e.X, e.Y));

            //// Select the node at the mouse position.  
            //this.trvDataBases.SelectedNode = trvDataBases.GetNodeAt(targetPoint);
        }

        private void trvDataBases_DragDrop(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(typeof(TreeNode)))
            //{
            //    TreeNode sourceNode = e.Data.GetData(typeof(TreeView)) as TreeNode;

            //    var item = new TreeNode(sourceNode.Text);


            //    System.Drawing.Point pt = ((TreeView)sender).PointToClient(new System.Drawing.Point(e.X, e.Y));
            //    TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);

            //    DestinationNode.Nodes.Add(item);
            //    DestinationNode.Expand();
            //} 
        }
    }
}
