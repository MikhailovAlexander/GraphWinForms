namespace GraphWinForms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GraphArea = new System.Windows.Forms.PictureBox();
            this.btnGenerateGraph = new System.Windows.Forms.Button();
            this.tBarProbability = new System.Windows.Forms.TrackBar();
            this.lblProbability = new System.Windows.Forms.Label();
            this.lblOrder = new System.Windows.Forms.Label();
            this.tBarOrder = new System.Windows.Forms.TrackBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlGraphState = new System.Windows.Forms.Panel();
            this.lblGraphState = new System.Windows.Forms.Label();
            this.mtbChangeWeight = new System.Windows.Forms.MaskedTextBox();
            this.tcPages = new System.Windows.Forms.TabControl();
            this.tabPageEditor = new System.Windows.Forms.TabPage();
            this.btnSetWeigthAsDiastance = new System.Windows.Forms.Button();
            this.gbMatrix = new System.Windows.Forms.GroupBox();
            this.rbAdjLists = new System.Windows.Forms.RadioButton();
            this.rbAdjMatrix = new System.Windows.Forms.RadioButton();
            this.dgvAdjMatrix = new System.Windows.Forms.DataGridView();
            this.gbEditMode = new System.Windows.Forms.GroupBox();
            this.rbChangeWeight = new System.Windows.Forms.RadioButton();
            this.rbEdgeRemove = new System.Windows.Forms.RadioButton();
            this.rbVertexAdd = new System.Windows.Forms.RadioButton();
            this.rbEdgeAdd = new System.Windows.Forms.RadioButton();
            this.rbVertexRemove = new System.Windows.Forms.RadioButton();
            this.rbVertexMove = new System.Windows.Forms.RadioButton();
            this.gbGraphGen = new System.Windows.Forms.GroupBox();
            this.chBoxWithoutLoop = new System.Windows.Forms.CheckBox();
            this.chBoxDiffWheight = new System.Windows.Forms.CheckBox();
            this.lblMaxWeight = new System.Windows.Forms.Label();
            this.tBarMaxWeight = new System.Windows.Forms.TrackBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnShowMST = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GraphArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBarProbability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBarOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlGraphState.SuspendLayout();
            this.tcPages.SuspendLayout();
            this.tabPageEditor.SuspendLayout();
            this.gbMatrix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdjMatrix)).BeginInit();
            this.gbEditMode.SuspendLayout();
            this.gbGraphGen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBarMaxWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // GraphArea
            // 
            this.GraphArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GraphArea.Location = new System.Drawing.Point(0, 0);
            this.GraphArea.Name = "GraphArea";
            this.GraphArea.Size = new System.Drawing.Size(717, 854);
            this.GraphArea.TabIndex = 0;
            this.GraphArea.TabStop = false;
            this.GraphArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GraphArea_MouseDown);
            this.GraphArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GraphArea_MouseMove);
            this.GraphArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GraphArea_MouseUp);
            // 
            // btnGenerateGraph
            // 
            this.btnGenerateGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateGraph.Location = new System.Drawing.Point(417, 15);
            this.btnGenerateGraph.Name = "btnGenerateGraph";
            this.btnGenerateGraph.Size = new System.Drawing.Size(142, 50);
            this.btnGenerateGraph.TabIndex = 1;
            this.btnGenerateGraph.Text = "Сгенерировать граф";
            this.btnGenerateGraph.UseVisualStyleBackColor = true;
            this.btnGenerateGraph.Click += new System.EventHandler(this.btnGenerateGraph_Click);
            // 
            // tBarProbability
            // 
            this.tBarProbability.Location = new System.Drawing.Point(6, 47);
            this.tBarProbability.Maximum = 100;
            this.tBarProbability.Name = "tBarProbability";
            this.tBarProbability.Size = new System.Drawing.Size(395, 56);
            this.tBarProbability.TabIndex = 3;
            this.tBarProbability.TickFrequency = 5;
            this.tBarProbability.Value = 1;
            this.tBarProbability.Scroll += new System.EventHandler(this.tBarProbability_Scroll);
            // 
            // lblProbability
            // 
            this.lblProbability.AutoSize = true;
            this.lblProbability.Location = new System.Drawing.Point(14, 24);
            this.lblProbability.Name = "lblProbability";
            this.lblProbability.Size = new System.Drawing.Size(234, 17);
            this.lblProbability.TabIndex = 4;
            this.lblProbability.Text = "Вероятность соединения вершин:";
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Location = new System.Drawing.Point(14, 106);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(109, 17);
            this.lblOrder.TabIndex = 6;
            this.lblOrder.Text = "Порядок графа";
            // 
            // tBarOrder
            // 
            this.tBarOrder.Location = new System.Drawing.Point(6, 129);
            this.tBarOrder.Maximum = 50;
            this.tBarOrder.Name = "tBarOrder";
            this.tBarOrder.Size = new System.Drawing.Size(395, 56);
            this.tBarOrder.TabIndex = 5;
            this.tBarOrder.TickFrequency = 5;
            this.tBarOrder.Value = 1;
            this.tBarOrder.Scroll += new System.EventHandler(this.tBarOrder_Scroll);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.pnlGraphState);
            this.splitContainer1.Panel1.Controls.Add(this.mtbChangeWeight);
            this.splitContainer1.Panel1.Controls.Add(this.GraphArea);
            this.splitContainer1.Panel1MinSize = 600;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tcPages);
            this.splitContainer1.Panel2MinSize = 600;
            this.splitContainer1.Size = new System.Drawing.Size(1380, 856);
            this.splitContainer1.SplitterDistance = 719;
            this.splitContainer1.TabIndex = 7;
            // 
            // pnlGraphState
            // 
            this.pnlGraphState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlGraphState.Controls.Add(this.lblGraphState);
            this.pnlGraphState.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlGraphState.Location = new System.Drawing.Point(0, 827);
            this.pnlGraphState.Name = "pnlGraphState";
            this.pnlGraphState.Size = new System.Drawing.Size(717, 27);
            this.pnlGraphState.TabIndex = 4;
            // 
            // lblGraphState
            // 
            this.lblGraphState.AutoSize = true;
            this.lblGraphState.Location = new System.Drawing.Point(3, 6);
            this.lblGraphState.Name = "lblGraphState";
            this.lblGraphState.Size = new System.Drawing.Size(43, 17);
            this.lblGraphState.TabIndex = 3;
            this.lblGraphState.Text = "Граф";
            // 
            // mtbChangeWeight
            // 
            this.mtbChangeWeight.Location = new System.Drawing.Point(683, 12);
            this.mtbChangeWeight.Mask = "00";
            this.mtbChangeWeight.Name = "mtbChangeWeight";
            this.mtbChangeWeight.Size = new System.Drawing.Size(25, 22);
            this.mtbChangeWeight.TabIndex = 2;
            this.mtbChangeWeight.ValidatingType = typeof(int);
            this.mtbChangeWeight.Visible = false;
            this.mtbChangeWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbChangeWeight_KeyPress);
            // 
            // tcPages
            // 
            this.tcPages.Controls.Add(this.tabPageEditor);
            this.tcPages.Controls.Add(this.tabPage2);
            this.tcPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPages.Location = new System.Drawing.Point(0, 0);
            this.tcPages.MinimumSize = new System.Drawing.Size(600, 0);
            this.tcPages.Name = "tcPages";
            this.tcPages.SelectedIndex = 0;
            this.tcPages.Size = new System.Drawing.Size(655, 854);
            this.tcPages.TabIndex = 7;
            // 
            // tabPageEditor
            // 
            this.tabPageEditor.Controls.Add(this.btnShowMST);
            this.tabPageEditor.Controls.Add(this.btnSetWeigthAsDiastance);
            this.tabPageEditor.Controls.Add(this.gbMatrix);
            this.tabPageEditor.Controls.Add(this.dgvAdjMatrix);
            this.tabPageEditor.Controls.Add(this.gbEditMode);
            this.tabPageEditor.Controls.Add(this.gbGraphGen);
            this.tabPageEditor.Location = new System.Drawing.Point(4, 25);
            this.tabPageEditor.Name = "tabPageEditor";
            this.tabPageEditor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEditor.Size = new System.Drawing.Size(647, 825);
            this.tabPageEditor.TabIndex = 0;
            this.tabPageEditor.Text = "Редактор графа";
            this.tabPageEditor.UseVisualStyleBackColor = true;
            // 
            // btnSetWeigthAsDiastance
            // 
            this.btnSetWeigthAsDiastance.Location = new System.Drawing.Point(384, 293);
            this.btnSetWeigthAsDiastance.Name = "btnSetWeigthAsDiastance";
            this.btnSetWeigthAsDiastance.Size = new System.Drawing.Size(184, 46);
            this.btnSetWeigthAsDiastance.TabIndex = 4;
            this.btnSetWeigthAsDiastance.Text = "Установить вес ребер, как расстояние";
            this.btnSetWeigthAsDiastance.UseVisualStyleBackColor = true;
            this.btnSetWeigthAsDiastance.Click += new System.EventHandler(this.btnSetWeigthAsDiastance_Click);
            // 
            // gbMatrix
            // 
            this.gbMatrix.Controls.Add(this.rbAdjLists);
            this.gbMatrix.Controls.Add(this.rbAdjMatrix);
            this.gbMatrix.Location = new System.Drawing.Point(7, 394);
            this.gbMatrix.Name = "gbMatrix";
            this.gbMatrix.Size = new System.Drawing.Size(561, 45);
            this.gbMatrix.TabIndex = 3;
            this.gbMatrix.TabStop = false;
            this.gbMatrix.Text = "Представление графа";
            // 
            // rbAdjLists
            // 
            this.rbAdjLists.AutoSize = true;
            this.rbAdjLists.Location = new System.Drawing.Point(193, 19);
            this.rbAdjLists.Name = "rbAdjLists";
            this.rbAdjLists.Size = new System.Drawing.Size(312, 21);
            this.rbAdjLists.TabIndex = 1;
            this.rbAdjLists.Text = "Сортированные списки смежности вершин";
            this.rbAdjLists.UseVisualStyleBackColor = true;
            this.rbAdjLists.CheckedChanged += new System.EventHandler(this.rbAdjLists_CheckedChanged);
            // 
            // rbAdjMatrix
            // 
            this.rbAdjMatrix.AutoSize = true;
            this.rbAdjMatrix.Checked = true;
            this.rbAdjMatrix.Location = new System.Drawing.Point(7, 18);
            this.rbAdjMatrix.Name = "rbAdjMatrix";
            this.rbAdjMatrix.Size = new System.Drawing.Size(162, 21);
            this.rbAdjMatrix.TabIndex = 0;
            this.rbAdjMatrix.TabStop = true;
            this.rbAdjMatrix.Text = "Матрица смежности";
            this.rbAdjMatrix.UseVisualStyleBackColor = true;
            this.rbAdjMatrix.CheckedChanged += new System.EventHandler(this.rbAdjMatrix_CheckedChanged);
            // 
            // dgvAdjMatrix
            // 
            this.dgvAdjMatrix.AllowUserToAddRows = false;
            this.dgvAdjMatrix.AllowUserToDeleteRows = false;
            this.dgvAdjMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvAdjMatrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAdjMatrix.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAdjMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdjMatrix.Location = new System.Drawing.Point(6, 445);
            this.dgvAdjMatrix.Name = "dgvAdjMatrix";
            this.dgvAdjMatrix.ReadOnly = true;
            this.dgvAdjMatrix.RowHeadersWidth = 20;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgvAdjMatrix.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAdjMatrix.RowTemplate.Height = 24;
            this.dgvAdjMatrix.Size = new System.Drawing.Size(562, 364);
            this.dgvAdjMatrix.TabIndex = 2;
            // 
            // gbEditMode
            // 
            this.gbEditMode.Controls.Add(this.rbChangeWeight);
            this.gbEditMode.Controls.Add(this.rbEdgeRemove);
            this.gbEditMode.Controls.Add(this.rbVertexAdd);
            this.gbEditMode.Controls.Add(this.rbEdgeAdd);
            this.gbEditMode.Controls.Add(this.rbVertexRemove);
            this.gbEditMode.Controls.Add(this.rbVertexMove);
            this.gbEditMode.Location = new System.Drawing.Point(9, 286);
            this.gbEditMode.Name = "gbEditMode";
            this.gbEditMode.Size = new System.Drawing.Size(369, 102);
            this.gbEditMode.TabIndex = 0;
            this.gbEditMode.TabStop = false;
            this.gbEditMode.Text = "Текущий режим редактирования";
            // 
            // rbChangeWeight
            // 
            this.rbChangeWeight.AutoSize = true;
            this.rbChangeWeight.Location = new System.Drawing.Point(212, 72);
            this.rbChangeWeight.Name = "rbChangeWeight";
            this.rbChangeWeight.Size = new System.Drawing.Size(137, 21);
            this.rbChangeWeight.TabIndex = 5;
            this.rbChangeWeight.TabStop = true;
            this.rbChangeWeight.Text = "Изменение веса";
            this.rbChangeWeight.UseVisualStyleBackColor = true;
            // 
            // rbEdgeRemove
            // 
            this.rbEdgeRemove.AutoSize = true;
            this.rbEdgeRemove.Location = new System.Drawing.Point(212, 46);
            this.rbEdgeRemove.Name = "rbEdgeRemove";
            this.rbEdgeRemove.Size = new System.Drawing.Size(138, 21);
            this.rbEdgeRemove.TabIndex = 4;
            this.rbEdgeRemove.TabStop = true;
            this.rbEdgeRemove.Text = "Удаление ребер";
            this.rbEdgeRemove.UseVisualStyleBackColor = true;
            // 
            // rbVertexAdd
            // 
            this.rbVertexAdd.AutoSize = true;
            this.rbVertexAdd.Location = new System.Drawing.Point(7, 45);
            this.rbVertexAdd.Name = "rbVertexAdd";
            this.rbVertexAdd.Size = new System.Drawing.Size(165, 21);
            this.rbVertexAdd.TabIndex = 3;
            this.rbVertexAdd.TabStop = true;
            this.rbVertexAdd.Text = "Добавление вершин";
            this.rbVertexAdd.UseVisualStyleBackColor = true;
            // 
            // rbEdgeAdd
            // 
            this.rbEdgeAdd.AutoSize = true;
            this.rbEdgeAdd.Location = new System.Drawing.Point(212, 21);
            this.rbEdgeAdd.Name = "rbEdgeAdd";
            this.rbEdgeAdd.Size = new System.Drawing.Size(155, 21);
            this.rbEdgeAdd.TabIndex = 2;
            this.rbEdgeAdd.TabStop = true;
            this.rbEdgeAdd.Text = "Добавление ребер";
            this.rbEdgeAdd.UseVisualStyleBackColor = true;
            // 
            // rbVertexRemove
            // 
            this.rbVertexRemove.AutoSize = true;
            this.rbVertexRemove.Location = new System.Drawing.Point(7, 71);
            this.rbVertexRemove.Name = "rbVertexRemove";
            this.rbVertexRemove.Size = new System.Drawing.Size(148, 21);
            this.rbVertexRemove.TabIndex = 1;
            this.rbVertexRemove.TabStop = true;
            this.rbVertexRemove.Text = "Удаление вершин";
            this.rbVertexRemove.UseVisualStyleBackColor = true;
            // 
            // rbVertexMove
            // 
            this.rbVertexMove.AutoSize = true;
            this.rbVertexMove.Checked = true;
            this.rbVertexMove.Location = new System.Drawing.Point(7, 21);
            this.rbVertexMove.Name = "rbVertexMove";
            this.rbVertexMove.Size = new System.Drawing.Size(177, 21);
            this.rbVertexMove.TabIndex = 0;
            this.rbVertexMove.TabStop = true;
            this.rbVertexMove.Text = "Перемещение вершин";
            this.rbVertexMove.UseVisualStyleBackColor = true;
            // 
            // gbGraphGen
            // 
            this.gbGraphGen.Controls.Add(this.chBoxWithoutLoop);
            this.gbGraphGen.Controls.Add(this.tBarProbability);
            this.gbGraphGen.Controls.Add(this.chBoxDiffWheight);
            this.gbGraphGen.Controls.Add(this.lblProbability);
            this.gbGraphGen.Controls.Add(this.lblMaxWeight);
            this.gbGraphGen.Controls.Add(this.tBarOrder);
            this.gbGraphGen.Controls.Add(this.tBarMaxWeight);
            this.gbGraphGen.Controls.Add(this.lblOrder);
            this.gbGraphGen.Controls.Add(this.btnGenerateGraph);
            this.gbGraphGen.Location = new System.Drawing.Point(3, 3);
            this.gbGraphGen.Name = "gbGraphGen";
            this.gbGraphGen.Size = new System.Drawing.Size(565, 277);
            this.gbGraphGen.TabIndex = 1;
            this.gbGraphGen.TabStop = false;
            this.gbGraphGen.Text = "Генератор графов";
            // 
            // chBoxWithoutLoop
            // 
            this.chBoxWithoutLoop.AutoSize = true;
            this.chBoxWithoutLoop.Location = new System.Drawing.Point(417, 82);
            this.chBoxWithoutLoop.Name = "chBoxWithoutLoop";
            this.chBoxWithoutLoop.Size = new System.Drawing.Size(104, 21);
            this.chBoxWithoutLoop.TabIndex = 10;
            this.chBoxWithoutLoop.Text = "Без петель";
            this.chBoxWithoutLoop.UseVisualStyleBackColor = true;
            // 
            // chBoxDiffWheight
            // 
            this.chBoxDiffWheight.AutoSize = true;
            this.chBoxDiffWheight.Location = new System.Drawing.Point(417, 106);
            this.chBoxDiffWheight.Name = "chBoxDiffWheight";
            this.chBoxDiffWheight.Size = new System.Drawing.Size(130, 38);
            this.chBoxDiffWheight.TabIndex = 9;
            this.chBoxDiffWheight.Text = "Различный вес\nвсех ребер";
            this.chBoxDiffWheight.UseVisualStyleBackColor = true;
            // 
            // lblMaxWeight
            // 
            this.lblMaxWeight.AutoSize = true;
            this.lblMaxWeight.Location = new System.Drawing.Point(14, 188);
            this.lblMaxWeight.Name = "lblMaxWeight";
            this.lblMaxWeight.Size = new System.Drawing.Size(177, 17);
            this.lblMaxWeight.TabIndex = 8;
            this.lblMaxWeight.Text = "Максимальный вес ребра";
            // 
            // tBarMaxWeight
            // 
            this.tBarMaxWeight.Location = new System.Drawing.Point(6, 211);
            this.tBarMaxWeight.Maximum = 50;
            this.tBarMaxWeight.Name = "tBarMaxWeight";
            this.tBarMaxWeight.Size = new System.Drawing.Size(395, 56);
            this.tBarMaxWeight.TabIndex = 7;
            this.tBarMaxWeight.TickFrequency = 5;
            this.tBarMaxWeight.Value = 1;
            this.tBarMaxWeight.Scroll += new System.EventHandler(this.tBarMaxWeight_Scroll);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(647, 825);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnShowMST
            // 
            this.btnShowMST.Location = new System.Drawing.Point(384, 345);
            this.btnShowMST.Name = "btnShowMST";
            this.btnShowMST.Size = new System.Drawing.Size(184, 46);
            this.btnShowMST.TabIndex = 5;
            this.btnShowMST.Text = "Найти минимальное остовное дерево";
            this.btnShowMST.UseVisualStyleBackColor = true;
            this.btnShowMST.Click += new System.EventHandler(this.btnShowMST_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 863);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(1400, 910);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.GraphArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBarProbability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBarOrder)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlGraphState.ResumeLayout(false);
            this.pnlGraphState.PerformLayout();
            this.tcPages.ResumeLayout(false);
            this.tabPageEditor.ResumeLayout(false);
            this.gbMatrix.ResumeLayout(false);
            this.gbMatrix.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdjMatrix)).EndInit();
            this.gbEditMode.ResumeLayout(false);
            this.gbEditMode.PerformLayout();
            this.gbGraphGen.ResumeLayout(false);
            this.gbGraphGen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBarMaxWeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox GraphArea;
        private System.Windows.Forms.Button btnGenerateGraph;
        private System.Windows.Forms.TrackBar tBarProbability;
        private System.Windows.Forms.Label lblProbability;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.TrackBar tBarOrder;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tcPages;
        private System.Windows.Forms.TabPage tabPageEditor;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblMaxWeight;
        private System.Windows.Forms.TrackBar tBarMaxWeight;
        private System.Windows.Forms.CheckBox chBoxWithoutLoop;
        private System.Windows.Forms.CheckBox chBoxDiffWheight;
        private System.Windows.Forms.GroupBox gbEditMode;
        private System.Windows.Forms.RadioButton rbEdgeAdd;
        private System.Windows.Forms.RadioButton rbVertexRemove;
        private System.Windows.Forms.RadioButton rbVertexMove;
        private System.Windows.Forms.GroupBox gbGraphGen;
        private System.Windows.Forms.RadioButton rbChangeWeight;
        private System.Windows.Forms.RadioButton rbEdgeRemove;
        private System.Windows.Forms.RadioButton rbVertexAdd;
        private System.Windows.Forms.MaskedTextBox mtbChangeWeight;
        private System.Windows.Forms.DataGridView dgvAdjMatrix;
        private System.Windows.Forms.GroupBox gbMatrix;
        private System.Windows.Forms.RadioButton rbAdjLists;
        private System.Windows.Forms.RadioButton rbAdjMatrix;
        private System.Windows.Forms.Button btnSetWeigthAsDiastance;
        private System.Windows.Forms.Panel pnlGraphState;
        private System.Windows.Forms.Label lblGraphState;
        private System.Windows.Forms.Button btnShowMST;
    }
}

