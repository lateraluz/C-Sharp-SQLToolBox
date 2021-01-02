namespace UTN.Winform.SQLToolBox.Layeres.UI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tspTopBar = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnConnectDisconect = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnDesconectar = new System.Windows.Forms.ToolStripButton();
            this.toolStripClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnAcercade = new System.Windows.Forms.ToolStripButton();
            this.sttStatus = new System.Windows.Forms.StatusStrip();
            this.toolStripStatuslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.spcContenedor = new System.Windows.Forms.SplitContainer();
            this.trvDataBases = new System.Windows.Forms.TreeView();
            this.cmdBaseDatosMenuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.generarStoredProcedureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearEntitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearSqlCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgLista = new System.Windows.Forms.ImageList(this.components);
            this.tspDataBase = new System.Windows.Forms.ToolStrip();
            this.toolStripLblDataBase = new System.Windows.Forms.ToolStripLabel();
            this.toolStripCmbDataBase = new System.Windows.Forms.ToolStripComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rtbData = new System.Windows.Forms.RichTextBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.tspCommandBar = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnEjecutarSQL = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.tspTopBar.SuspendLayout();
            this.sttStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcContenedor)).BeginInit();
            this.spcContenedor.Panel1.SuspendLayout();
            this.spcContenedor.Panel2.SuspendLayout();
            this.spcContenedor.SuspendLayout();
            this.cmdBaseDatosMenuContextual.SuspendLayout();
            this.tspDataBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.tspCommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tspTopBar
            // 
            this.tspTopBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnConnectDisconect,
            this.toolStripBtnDesconectar,
            this.toolStripClose,
            this.toolStripBtnAcercade});
            this.tspTopBar.Location = new System.Drawing.Point(0, 0);
            this.tspTopBar.Name = "tspTopBar";
            this.tspTopBar.Size = new System.Drawing.Size(740, 70);
            this.tspTopBar.TabIndex = 0;
            // 
            // toolStripBtnConnectDisconect
            // 
            this.toolStripBtnConnectDisconect.Image = global::UTN.Winform.SQLToolBox.Properties.Resources.connect32;
            this.toolStripBtnConnectDisconect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnConnectDisconect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnConnectDisconect.Name = "toolStripBtnConnectDisconect";
            this.toolStripBtnConnectDisconect.Size = new System.Drawing.Size(59, 67);
            this.toolStripBtnConnectDisconect.Text = "Conectar";
            this.toolStripBtnConnectDisconect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnConnectDisconect.Click += new System.EventHandler(this.toolStripBtnConnectDisconect_Click);
            // 
            // toolStripBtnDesconectar
            // 
            this.toolStripBtnDesconectar.Image = global::UTN.Winform.SQLToolBox.Properties.Resources.disconnect1;
            this.toolStripBtnDesconectar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnDesconectar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnDesconectar.Name = "toolStripBtnDesconectar";
            this.toolStripBtnDesconectar.Size = new System.Drawing.Size(76, 67);
            this.toolStripBtnDesconectar.Text = "Desconectar";
            this.toolStripBtnDesconectar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnDesconectar.Click += new System.EventHandler(this.toolStripBtnDesconectar_Click);
            // 
            // toolStripClose
            // 
            this.toolStripClose.Image = global::UTN.Winform.SQLToolBox.Properties.Resources.cancelar;
            this.toolStripClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripClose.Name = "toolStripClose";
            this.toolStripClose.Size = new System.Drawing.Size(52, 67);
            this.toolStripClose.Text = "Cerrar";
            this.toolStripClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripClose.Click += new System.EventHandler(this.toolStripClose_Click);
            // 
            // toolStripBtnAcercade
            // 
            this.toolStripBtnAcercade.Image = global::UTN.Winform.SQLToolBox.Properties.Resources.help;
            this.toolStripBtnAcercade.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnAcercade.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnAcercade.Name = "toolStripBtnAcercade";
            this.toolStripBtnAcercade.Size = new System.Drawing.Size(63, 67);
            this.toolStripBtnAcercade.Text = "Acerca de";
            this.toolStripBtnAcercade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnAcercade.Click += new System.EventHandler(this.toolStripBtnAcercade_Click);
            // 
            // sttStatus
            // 
            this.sttStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatuslblStatus});
            this.sttStatus.Location = new System.Drawing.Point(0, 410);
            this.sttStatus.Name = "sttStatus";
            this.sttStatus.Size = new System.Drawing.Size(740, 22);
            this.sttStatus.TabIndex = 1;
            this.sttStatus.Text = "sttBarraInferior";
            // 
            // toolStripStatuslblStatus
            // 
            this.toolStripStatuslblStatus.Name = "toolStripStatuslblStatus";
            this.toolStripStatuslblStatus.Size = new System.Drawing.Size(12, 17);
            this.toolStripStatuslblStatus.Text = "-";
            // 
            // spcContenedor
            // 
            this.spcContenedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spcContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcContenedor.Location = new System.Drawing.Point(0, 70);
            this.spcContenedor.Name = "spcContenedor";
            // 
            // spcContenedor.Panel1
            // 
            this.spcContenedor.Panel1.Controls.Add(this.trvDataBases);
            this.spcContenedor.Panel1.Controls.Add(this.tspDataBase);
            // 
            // spcContenedor.Panel2
            // 
            this.spcContenedor.Panel2.Controls.Add(this.splitContainer1);
            this.spcContenedor.Panel2.Controls.Add(this.tspCommandBar);
            this.spcContenedor.Size = new System.Drawing.Size(740, 340);
            this.spcContenedor.SplitterDistance = 337;
            this.spcContenedor.TabIndex = 2;
            // 
            // trvDataBases
            // 
            this.trvDataBases.ContextMenuStrip = this.cmdBaseDatosMenuContextual;
            this.trvDataBases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDataBases.ImageIndex = 0;
            this.trvDataBases.ImageList = this.imgLista;
            this.trvDataBases.Location = new System.Drawing.Point(0, 27);
            this.trvDataBases.Name = "trvDataBases";
            this.trvDataBases.SelectedImageIndex = 0;
            this.trvDataBases.Size = new System.Drawing.Size(333, 309);
            this.trvDataBases.TabIndex = 1;
            this.trvDataBases.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.trvDataBases_ItemDrag);
            this.trvDataBases.DragDrop += new System.Windows.Forms.DragEventHandler(this.trvDataBases_DragDrop);
            this.trvDataBases.DragEnter += new System.Windows.Forms.DragEventHandler(this.trvDataBases_DragEnter);
            this.trvDataBases.DragOver += new System.Windows.Forms.DragEventHandler(this.trvDataBases_DragOver);
            // 
            // cmdBaseDatosMenuContextual
            // 
            this.cmdBaseDatosMenuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarStoredProcedureToolStripMenuItem,
            this.crearEntitiesToolStripMenuItem,
            this.crearSqlCommandToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.cmdBaseDatosMenuContextual.Name = "cmdBaseDatosMenuContextual";
            this.cmdBaseDatosMenuContextual.Size = new System.Drawing.Size(215, 92);
            this.cmdBaseDatosMenuContextual.Opening += new System.ComponentModel.CancelEventHandler(this.cmdBaseDatosMenuContextual_Opening);
            // 
            // generarStoredProcedureToolStripMenuItem
            // 
            this.generarStoredProcedureToolStripMenuItem.Name = "generarStoredProcedureToolStripMenuItem";
            this.generarStoredProcedureToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.generarStoredProcedureToolStripMenuItem.Text = "Generar Stored Procedures";
            this.generarStoredProcedureToolStripMenuItem.Click += new System.EventHandler(this.generarStoredProcedureToolStripMenuItem_Click);
            // 
            // crearEntitiesToolStripMenuItem
            // 
            this.crearEntitiesToolStripMenuItem.Name = "crearEntitiesToolStripMenuItem";
            this.crearEntitiesToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.crearEntitiesToolStripMenuItem.Text = "Crear Entities";
            this.crearEntitiesToolStripMenuItem.Click += new System.EventHandler(this.crearEntitiesToolStripMenuItem_Click);
            // 
            // crearSqlCommandToolStripMenuItem
            // 
            this.crearSqlCommandToolStripMenuItem.Name = "crearSqlCommandToolStripMenuItem";
            this.crearSqlCommandToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.crearSqlCommandToolStripMenuItem.Text = "Crear SqlCommand";
            this.crearSqlCommandToolStripMenuItem.Click += new System.EventHandler(this.crearSqlCommandToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // imgLista
            // 
            this.imgLista.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLista.ImageStream")));
            this.imgLista.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLista.Images.SetKeyName(0, "db.png");
            this.imgLista.Images.SetKeyName(1, "Table.png");
            this.imgLista.Images.SetKeyName(2, "server1.png");
            this.imgLista.Images.SetKeyName(3, "table0.png");
            this.imgLista.Images.SetKeyName(4, "table1.png");
            this.imgLista.Images.SetKeyName(5, "db2.png");
            // 
            // tspDataBase
            // 
            this.tspDataBase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLblDataBase,
            this.toolStripCmbDataBase});
            this.tspDataBase.Location = new System.Drawing.Point(0, 0);
            this.tspDataBase.Name = "tspDataBase";
            this.tspDataBase.Size = new System.Drawing.Size(333, 27);
            this.tspDataBase.TabIndex = 0;
            this.tspDataBase.Text = "toolStrip1";
            // 
            // toolStripLblDataBase
            // 
            this.toolStripLblDataBase.Image = global::UTN.Winform.SQLToolBox.Properties.Resources.Database;
            this.toolStripLblDataBase.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLblDataBase.Name = "toolStripLblDataBase";
            this.toolStripLblDataBase.Size = new System.Drawing.Size(79, 24);
            this.toolStripLblDataBase.Text = "DataBase";
            // 
            // toolStripCmbDataBase
            // 
            this.toolStripCmbDataBase.Name = "toolStripCmbDataBase";
            this.toolStripCmbDataBase.Size = new System.Drawing.Size(121, 27);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 54);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rtbData);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDatos);
            this.splitContainer1.Size = new System.Drawing.Size(399, 286);
            this.splitContainer1.SplitterDistance = 189;
            this.splitContainer1.TabIndex = 1;
            // 
            // rtbData
            // 
            this.rtbData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbData.Location = new System.Drawing.Point(0, 0);
            this.rtbData.Name = "rtbData";
            this.rtbData.Size = new System.Drawing.Size(395, 185);
            this.rtbData.TabIndex = 1;
            this.rtbData.Text = "";
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.Location = new System.Drawing.Point(0, 0);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(395, 89);
            this.dgvDatos.TabIndex = 0;
            // 
            // tspCommandBar
            // 
            this.tspCommandBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnEjecutarSQL,
            this.toolStripBtnLimpiar});
            this.tspCommandBar.Location = new System.Drawing.Point(0, 0);
            this.tspCommandBar.Name = "tspCommandBar";
            this.tspCommandBar.Size = new System.Drawing.Size(399, 54);
            this.tspCommandBar.TabIndex = 0;
            this.tspCommandBar.Text = "toolStrip1";
            // 
            // toolStripBtnEjecutarSQL
            // 
            this.toolStripBtnEjecutarSQL.Image = global::UTN.Winform.SQLToolBox.Properties.Resources.sql;
            this.toolStripBtnEjecutarSQL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnEjecutarSQL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnEjecutarSQL.Name = "toolStripBtnEjecutarSQL";
            this.toolStripBtnEjecutarSQL.Size = new System.Drawing.Size(53, 51);
            this.toolStripBtnEjecutarSQL.Text = "Ejecutar";
            this.toolStripBtnEjecutarSQL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnEjecutarSQL.Click += new System.EventHandler(this.toolStripBtnEjecutarSQL_Click);
            // 
            // toolStripBtnLimpiar
            // 
            this.toolStripBtnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripBtnLimpiar.Image = global::UTN.Winform.SQLToolBox.Properties.Resources.Clear;
            this.toolStripBtnLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnLimpiar.Name = "toolStripBtnLimpiar";
            this.toolStripBtnLimpiar.Size = new System.Drawing.Size(51, 51);
            this.toolStripBtnLimpiar.Text = "Limpiar";
            this.toolStripBtnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnLimpiar.Click += new System.EventHandler(this.toolStripBtnLimpiar_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 432);
            this.Controls.Add(this.spcContenedor);
            this.Controls.Add(this.sttStatus);
            this.Controls.Add(this.tspTopBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQLToolBox";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tspTopBar.ResumeLayout(false);
            this.tspTopBar.PerformLayout();
            this.sttStatus.ResumeLayout(false);
            this.sttStatus.PerformLayout();
            this.spcContenedor.Panel1.ResumeLayout(false);
            this.spcContenedor.Panel1.PerformLayout();
            this.spcContenedor.Panel2.ResumeLayout(false);
            this.spcContenedor.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcContenedor)).EndInit();
            this.spcContenedor.ResumeLayout(false);
            this.cmdBaseDatosMenuContextual.ResumeLayout(false);
            this.tspDataBase.ResumeLayout(false);
            this.tspDataBase.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.tspCommandBar.ResumeLayout(false);
            this.tspCommandBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspTopBar;
        private System.Windows.Forms.StatusStrip sttStatus;
        private System.Windows.Forms.ToolStripButton toolStripBtnConnectDisconect;
        private System.Windows.Forms.ToolStripButton toolStripClose;
        private System.Windows.Forms.SplitContainer spcContenedor;
        private System.Windows.Forms.ToolStrip tspDataBase;
        private System.Windows.Forms.ToolStripLabel toolStripLblDataBase;
        private System.Windows.Forms.ToolStripComboBox toolStripCmbDataBase;
        private System.Windows.Forms.RichTextBox rtbData;
        private System.Windows.Forms.ToolStrip tspCommandBar;
        private System.Windows.Forms.TreeView trvDataBases;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatuslblStatus;
        private System.Windows.Forms.ImageList imgLista;
        private System.Windows.Forms.ToolStripButton toolStripBtnDesconectar;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.ToolStripButton toolStripBtnLimpiar;
        private System.Windows.Forms.ToolStripButton toolStripBtnEjecutarSQL;
        private System.Windows.Forms.ContextMenuStrip cmdBaseDatosMenuContextual;
        private System.Windows.Forms.ToolStripMenuItem generarStoredProcedureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearEntitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearSqlCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripBtnAcercade;
    }
}