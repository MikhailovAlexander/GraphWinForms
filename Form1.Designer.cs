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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.pnlGraphEditor = new System.Windows.Forms.Panel();
            this.gbGraphGen = new System.Windows.Forms.GroupBox();
            this.chBoxShowID = new System.Windows.Forms.CheckBox();
            this.lblMaxWeight = new System.Windows.Forms.Label();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.chBoxWithoutLoop = new System.Windows.Forms.CheckBox();
            this.chBoxDiffWheight = new System.Windows.Forms.CheckBox();
            this.tBarMaxWeight = new System.Windows.Forms.TrackBar();
            this.btnShowMST = new System.Windows.Forms.Button();
            this.gbEditMode = new System.Windows.Forms.GroupBox();
            this.rbChangeWeight = new System.Windows.Forms.RadioButton();
            this.rbEdgeRemove = new System.Windows.Forms.RadioButton();
            this.rbVertexAdd = new System.Windows.Forms.RadioButton();
            this.rbEdgeAdd = new System.Windows.Forms.RadioButton();
            this.rbVertexRemove = new System.Windows.Forms.RadioButton();
            this.rbVertexMove = new System.Windows.Forms.RadioButton();
            this.btnSetWeigthAsDiastance = new System.Windows.Forms.Button();
            this.dgvAdjMatrix = new System.Windows.Forms.DataGridView();
            this.gbMatrix = new System.Windows.Forms.GroupBox();
            this.rbAdjLists = new System.Windows.Forms.RadioButton();
            this.rbAdjMatrix = new System.Windows.Forms.RadioButton();
            this.tabPageAlgVis = new System.Windows.Forms.TabPage();
            this.gbDescrSwitch = new System.Windows.Forms.GroupBox();
            this.rbDataStructures = new System.Windows.Forms.RadioButton();
            this.rbLog = new System.Windows.Forms.RadioButton();
            this.pnlAlgorithmsControls = new System.Windows.Forms.Panel();
            this.gbSpeedVis = new System.Windows.Forms.GroupBox();
            this.tbSpeedVis = new System.Windows.Forms.TrackBar();
            this.lblSpeedBotom = new System.Windows.Forms.Label();
            this.lblSpeedTop = new System.Windows.Forms.Label();
            this.gbAlgSet = new System.Windows.Forms.GroupBox();
            this.chBoxPrimStartFrom0 = new System.Windows.Forms.CheckBox();
            this.rbBoruvka = new System.Windows.Forms.RadioButton();
            this.rbPrim = new System.Windows.Forms.RadioButton();
            this.rbKruskal = new System.Windows.Forms.RadioButton();
            this.gbDescription = new System.Windows.Forms.GroupBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnStartAlgorithm = new System.Windows.Forms.Button();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.lblLog = new System.Windows.Forms.Label();
            this.pbDataStructures = new System.Windows.Forms.PictureBox();
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
            this.pnlGraphEditor.SuspendLayout();
            this.gbGraphGen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBarMaxWeight)).BeginInit();
            this.gbEditMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdjMatrix)).BeginInit();
            this.gbMatrix.SuspendLayout();
            this.tabPageAlgVis.SuspendLayout();
            this.gbDescrSwitch.SuspendLayout();
            this.pnlAlgorithmsControls.SuspendLayout();
            this.gbSpeedVis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeedVis)).BeginInit();
            this.gbAlgSet.SuspendLayout();
            this.gbDescription.SuspendLayout();
            this.pnlLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDataStructures)).BeginInit();
            this.SuspendLayout();
            // 
            // GraphArea
            // 
            this.GraphArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(239)))), ((int)(((byte)(170)))));
            this.GraphArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GraphArea.Location = new System.Drawing.Point(0, 0);
            this.GraphArea.Name = "GraphArea";
            this.GraphArea.Size = new System.Drawing.Size(717, 743);
            this.GraphArea.TabIndex = 0;
            this.GraphArea.TabStop = false;
            this.GraphArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GraphArea_MouseDown);
            this.GraphArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GraphArea_MouseMove);
            this.GraphArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GraphArea_MouseUp);
            // 
            // btnGenerateGraph
            // 
            this.btnGenerateGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateGraph.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(187)))), ((int)(((byte)(93)))));
            this.btnGenerateGraph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(46)))), ((int)(((byte)(0)))));
            this.btnGenerateGraph.Location = new System.Drawing.Point(433, 53);
            this.btnGenerateGraph.Name = "btnGenerateGraph";
            this.btnGenerateGraph.Size = new System.Drawing.Size(142, 56);
            this.btnGenerateGraph.TabIndex = 1;
            this.btnGenerateGraph.Text = "Сгенерировать граф";
            this.btnGenerateGraph.UseVisualStyleBackColor = false;
            this.btnGenerateGraph.Click += new System.EventHandler(this.btnGenerateGraph_Click);
            // 
            // tBarProbability
            // 
            this.tBarProbability.Location = new System.Drawing.Point(6, 53);
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
            this.lblProbability.Location = new System.Drawing.Point(14, 27);
            this.lblProbability.Name = "lblProbability";
            this.lblProbability.Size = new System.Drawing.Size(248, 18);
            this.lblProbability.TabIndex = 4;
            this.lblProbability.Text = "Вероятность соединения вершин:";
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Location = new System.Drawing.Point(14, 99);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(112, 18);
            this.lblOrder.TabIndex = 6;
            this.lblOrder.Text = "Порядок графа";
            // 
            // tBarOrder
            // 
            this.tBarOrder.Location = new System.Drawing.Point(6, 124);
            this.tBarOrder.Maximum = 30;
            this.tBarOrder.Minimum = 1;
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
            this.splitContainer1.Size = new System.Drawing.Size(1326, 745);
            this.splitContainer1.SplitterDistance = 719;
            this.splitContainer1.TabIndex = 7;
            // 
            // pnlGraphState
            // 
            this.pnlGraphState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(187)))), ((int)(((byte)(93)))));
            this.pnlGraphState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlGraphState.Controls.Add(this.lblGraphState);
            this.pnlGraphState.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlGraphState.Location = new System.Drawing.Point(0, 713);
            this.pnlGraphState.Name = "pnlGraphState";
            this.pnlGraphState.Size = new System.Drawing.Size(717, 30);
            this.pnlGraphState.TabIndex = 4;
            // 
            // lblGraphState
            // 
            this.lblGraphState.AutoSize = true;
            this.lblGraphState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(46)))), ((int)(((byte)(0)))));
            this.lblGraphState.Location = new System.Drawing.Point(3, 7);
            this.lblGraphState.Name = "lblGraphState";
            this.lblGraphState.Size = new System.Drawing.Size(40, 18);
            this.lblGraphState.TabIndex = 3;
            this.lblGraphState.Text = "Граф";
            this.lblGraphState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mtbChangeWeight
            // 
            this.mtbChangeWeight.Location = new System.Drawing.Point(683, 14);
            this.mtbChangeWeight.Mask = "00";
            this.mtbChangeWeight.Name = "mtbChangeWeight";
            this.mtbChangeWeight.Size = new System.Drawing.Size(25, 25);
            this.mtbChangeWeight.TabIndex = 2;
            this.mtbChangeWeight.ValidatingType = typeof(int);
            this.mtbChangeWeight.Visible = false;
            this.mtbChangeWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbChangeWeight_KeyPress);
            // 
            // tcPages
            // 
            this.tcPages.Controls.Add(this.tabPageEditor);
            this.tcPages.Controls.Add(this.tabPageAlgVis);
            this.tcPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPages.Location = new System.Drawing.Point(0, 0);
            this.tcPages.MinimumSize = new System.Drawing.Size(520, 0);
            this.tcPages.Name = "tcPages";
            this.tcPages.SelectedIndex = 0;
            this.tcPages.Size = new System.Drawing.Size(601, 743);
            this.tcPages.TabIndex = 7;
            // 
            // tabPageEditor
            // 
            this.tabPageEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(250)))), ((int)(((byte)(217)))));
            this.tabPageEditor.Controls.Add(this.pnlGraphEditor);
            this.tabPageEditor.Location = new System.Drawing.Point(4, 27);
            this.tabPageEditor.Name = "tabPageEditor";
            this.tabPageEditor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEditor.Size = new System.Drawing.Size(593, 712);
            this.tabPageEditor.TabIndex = 0;
            this.tabPageEditor.Text = "Редактор графа";
            this.tabPageEditor.UseVisualStyleBackColor = true;
            // 
            // pnlGraphEditor
            // 
            this.pnlGraphEditor.AutoSize = true;
            this.pnlGraphEditor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlGraphEditor.Controls.Add(this.gbGraphGen);
            this.pnlGraphEditor.Controls.Add(this.btnShowMST);
            this.pnlGraphEditor.Controls.Add(this.gbEditMode);
            this.pnlGraphEditor.Controls.Add(this.btnSetWeigthAsDiastance);
            this.pnlGraphEditor.Controls.Add(this.dgvAdjMatrix);
            this.pnlGraphEditor.Controls.Add(this.gbMatrix);
            this.pnlGraphEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGraphEditor.Location = new System.Drawing.Point(3, 3);
            this.pnlGraphEditor.Name = "pnlGraphEditor";
            this.pnlGraphEditor.Size = new System.Drawing.Size(587, 706);
            this.pnlGraphEditor.TabIndex = 6;
            // 
            // gbGraphGen
            // 
            this.gbGraphGen.Controls.Add(this.chBoxShowID);
            this.gbGraphGen.Controls.Add(this.lblMaxWeight);
            this.gbGraphGen.Controls.Add(this.lblOrder);
            this.gbGraphGen.Controls.Add(this.btnForward);
            this.gbGraphGen.Controls.Add(this.btnBack);
            this.gbGraphGen.Controls.Add(this.chBoxWithoutLoop);
            this.gbGraphGen.Controls.Add(this.tBarProbability);
            this.gbGraphGen.Controls.Add(this.chBoxDiffWheight);
            this.gbGraphGen.Controls.Add(this.lblProbability);
            this.gbGraphGen.Controls.Add(this.tBarOrder);
            this.gbGraphGen.Controls.Add(this.btnGenerateGraph);
            this.gbGraphGen.Controls.Add(this.tBarMaxWeight);
            this.gbGraphGen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(46)))), ((int)(((byte)(0)))));
            this.gbGraphGen.Location = new System.Drawing.Point(3, 3);
            this.gbGraphGen.Name = "gbGraphGen";
            this.gbGraphGen.Size = new System.Drawing.Size(581, 263);
            this.gbGraphGen.TabIndex = 1;
            this.gbGraphGen.TabStop = false;
            this.gbGraphGen.Text = "Генератор графов";
            // 
            // chBoxShowID
            // 
            this.chBoxShowID.AutoSize = true;
            this.chBoxShowID.Checked = true;
            this.chBoxShowID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBoxShowID.Location = new System.Drawing.Point(438, 196);
            this.chBoxShowID.Name = "chBoxShowID";
            this.chBoxShowID.Size = new System.Drawing.Size(134, 40);
            this.chBoxShowID.TabIndex = 13;
            this.chBoxShowID.Text = "Показывать  №\nвершин";
            this.chBoxShowID.UseVisualStyleBackColor = true;
            // 
            // lblMaxWeight
            // 
            this.lblMaxWeight.AutoSize = true;
            this.lblMaxWeight.Location = new System.Drawing.Point(14, 171);
            this.lblMaxWeight.Name = "lblMaxWeight";
            this.lblMaxWeight.Size = new System.Drawing.Size(184, 18);
            this.lblMaxWeight.TabIndex = 8;
            this.lblMaxWeight.Text = "Максимальный вес ребра";
            // 
            // btnForward
            // 
            this.btnForward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(187)))), ((int)(((byte)(93)))));
            this.btnForward.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(46)))), ((int)(((byte)(0)))));
            this.btnForward.Location = new System.Drawing.Point(519, 11);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(56, 35);
            this.btnForward.TabIndex = 12;
            this.btnForward.Text = "=>";
            this.btnForward.UseVisualStyleBackColor = false;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(187)))), ((int)(((byte)(93)))));
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(46)))), ((int)(((byte)(0)))));
            this.btnBack.Location = new System.Drawing.Point(433, 11);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(58, 35);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = " <=";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // chBoxWithoutLoop
            // 
            this.chBoxWithoutLoop.AutoSize = true;
            this.chBoxWithoutLoop.Location = new System.Drawing.Point(438, 128);
            this.chBoxWithoutLoop.Name = "chBoxWithoutLoop";
            this.chBoxWithoutLoop.Size = new System.Drawing.Size(110, 22);
            this.chBoxWithoutLoop.TabIndex = 10;
            this.chBoxWithoutLoop.Text = "Без петель";
            this.chBoxWithoutLoop.UseVisualStyleBackColor = true;
            // 
            // chBoxDiffWheight
            // 
            this.chBoxDiffWheight.AutoSize = true;
            this.chBoxDiffWheight.Location = new System.Drawing.Point(438, 155);
            this.chBoxDiffWheight.Name = "chBoxDiffWheight";
            this.chBoxDiffWheight.Size = new System.Drawing.Size(134, 40);
            this.chBoxDiffWheight.TabIndex = 9;
            this.chBoxDiffWheight.Text = "Различный вес\nвсех ребер";
            this.chBoxDiffWheight.UseVisualStyleBackColor = true;
            // 
            // tBarMaxWeight
            // 
            this.tBarMaxWeight.Location = new System.Drawing.Point(6, 196);
            this.tBarMaxWeight.Maximum = 50;
            this.tBarMaxWeight.Minimum = 1;
            this.tBarMaxWeight.Name = "tBarMaxWeight";
            this.tBarMaxWeight.Size = new System.Drawing.Size(395, 56);
            this.tBarMaxWeight.TabIndex = 7;
            this.tBarMaxWeight.TickFrequency = 5;
            this.tBarMaxWeight.Value = 1;
            this.tBarMaxWeight.Scroll += new System.EventHandler(this.tBarMaxWeight_Scroll);
            // 
            // btnShowMST
            // 
            this.btnShowMST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(187)))), ((int)(((byte)(93)))));
            this.btnShowMST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(46)))), ((int)(((byte)(0)))));
            this.btnShowMST.Location = new System.Drawing.Point(383, 331);
            this.btnShowMST.Name = "btnShowMST";
            this.btnShowMST.Size = new System.Drawing.Size(197, 52);
            this.btnShowMST.TabIndex = 5;
            this.btnShowMST.Text = "Найти минимальное остовное дерево";
            this.btnShowMST.UseVisualStyleBackColor = false;
            this.btnShowMST.Click += new System.EventHandler(this.btnShowMST_Click);
            // 
            // gbEditMode
            // 
            this.gbEditMode.Controls.Add(this.rbChangeWeight);
            this.gbEditMode.Controls.Add(this.rbEdgeRemove);
            this.gbEditMode.Controls.Add(this.rbVertexAdd);
            this.gbEditMode.Controls.Add(this.rbEdgeAdd);
            this.gbEditMode.Controls.Add(this.rbVertexRemove);
            this.gbEditMode.Controls.Add(this.rbVertexMove);
            this.gbEditMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(46)))), ((int)(((byte)(0)))));
            this.gbEditMode.Location = new System.Drawing.Point(3, 265);
            this.gbEditMode.Name = "gbEditMode";
            this.gbEditMode.Size = new System.Drawing.Size(369, 115);
            this.gbEditMode.TabIndex = 0;
            this.gbEditMode.TabStop = false;
            this.gbEditMode.Text = "Текущий режим редактирования";
            // 
            // rbChangeWeight
            // 
            this.rbChangeWeight.AutoSize = true;
            this.rbChangeWeight.Location = new System.Drawing.Point(206, 81);
            this.rbChangeWeight.Name = "rbChangeWeight";
            this.rbChangeWeight.Size = new System.Drawing.Size(141, 22);
            this.rbChangeWeight.TabIndex = 5;
            this.rbChangeWeight.TabStop = true;
            this.rbChangeWeight.Text = "Изменение веса";
            this.rbChangeWeight.UseVisualStyleBackColor = true;
            // 
            // rbEdgeRemove
            // 
            this.rbEdgeRemove.AutoSize = true;
            this.rbEdgeRemove.Location = new System.Drawing.Point(206, 52);
            this.rbEdgeRemove.Name = "rbEdgeRemove";
            this.rbEdgeRemove.Size = new System.Drawing.Size(141, 22);
            this.rbEdgeRemove.TabIndex = 4;
            this.rbEdgeRemove.TabStop = true;
            this.rbEdgeRemove.Text = "Удаление ребер";
            this.rbEdgeRemove.UseVisualStyleBackColor = true;
            // 
            // rbVertexAdd
            // 
            this.rbVertexAdd.AutoSize = true;
            this.rbVertexAdd.Location = new System.Drawing.Point(7, 51);
            this.rbVertexAdd.Name = "rbVertexAdd";
            this.rbVertexAdd.Size = new System.Drawing.Size(165, 22);
            this.rbVertexAdd.TabIndex = 3;
            this.rbVertexAdd.TabStop = true;
            this.rbVertexAdd.Text = "Добавление вершин";
            this.rbVertexAdd.UseVisualStyleBackColor = true;
            // 
            // rbEdgeAdd
            // 
            this.rbEdgeAdd.AutoSize = true;
            this.rbEdgeAdd.Location = new System.Drawing.Point(206, 24);
            this.rbEdgeAdd.Name = "rbEdgeAdd";
            this.rbEdgeAdd.Size = new System.Drawing.Size(157, 22);
            this.rbEdgeAdd.TabIndex = 2;
            this.rbEdgeAdd.TabStop = true;
            this.rbEdgeAdd.Text = "Добавление ребер";
            this.rbEdgeAdd.UseVisualStyleBackColor = true;
            // 
            // rbVertexRemove
            // 
            this.rbVertexRemove.AutoSize = true;
            this.rbVertexRemove.Location = new System.Drawing.Point(7, 80);
            this.rbVertexRemove.Name = "rbVertexRemove";
            this.rbVertexRemove.Size = new System.Drawing.Size(149, 22);
            this.rbVertexRemove.TabIndex = 1;
            this.rbVertexRemove.TabStop = true;
            this.rbVertexRemove.Text = "Удаление вершин";
            this.rbVertexRemove.UseVisualStyleBackColor = true;
            // 
            // rbVertexMove
            // 
            this.rbVertexMove.AutoSize = true;
            this.rbVertexMove.Checked = true;
            this.rbVertexMove.Location = new System.Drawing.Point(7, 24);
            this.rbVertexMove.Name = "rbVertexMove";
            this.rbVertexMove.Size = new System.Drawing.Size(173, 22);
            this.rbVertexMove.TabIndex = 0;
            this.rbVertexMove.TabStop = true;
            this.rbVertexMove.Text = "Перемещение вершин";
            this.rbVertexMove.UseVisualStyleBackColor = true;
            // 
            // btnSetWeigthAsDiastance
            // 
            this.btnSetWeigthAsDiastance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(187)))), ((int)(((byte)(93)))));
            this.btnSetWeigthAsDiastance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(46)))), ((int)(((byte)(0)))));
            this.btnSetWeigthAsDiastance.Location = new System.Drawing.Point(383, 273);
            this.btnSetWeigthAsDiastance.Name = "btnSetWeigthAsDiastance";
            this.btnSetWeigthAsDiastance.Size = new System.Drawing.Size(197, 52);
            this.btnSetWeigthAsDiastance.TabIndex = 4;
            this.btnSetWeigthAsDiastance.Text = "Установить вес ребер, как расстояние";
            this.btnSetWeigthAsDiastance.UseVisualStyleBackColor = false;
            this.btnSetWeigthAsDiastance.Click += new System.EventHandler(this.btnSetWeigthAsDiastance_Click);
            // 
            // dgvAdjMatrix
            // 
            this.dgvAdjMatrix.AllowUserToAddRows = false;
            this.dgvAdjMatrix.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(250)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(46)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(46)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(250)))), ((int)(((byte)(217)))));
            this.dgvAdjMatrix.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvAdjMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvAdjMatrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAdjMatrix.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAdjMatrix.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(187)))), ((int)(((byte)(93)))));
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(250)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(46)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(46)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(250)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAdjMatrix.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvAdjMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(250)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(46)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(46)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(250)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAdjMatrix.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvAdjMatrix.EnableHeadersVisualStyles = false;
            this.dgvAdjMatrix.Location = new System.Drawing.Point(0, 443);
            this.dgvAdjMatrix.Name = "dgvAdjMatrix";
            this.dgvAdjMatrix.ReadOnly = true;
            this.dgvAdjMatrix.RowHeadersVisible = false;
            this.dgvAdjMatrix.RowHeadersWidth = 20;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(250)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(250)))), ((int)(((byte)(217)))));
            this.dgvAdjMatrix.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvAdjMatrix.RowTemplate.Height = 24;
            this.dgvAdjMatrix.Size = new System.Drawing.Size(587, 263);
            this.dgvAdjMatrix.TabIndex = 2;
            // 
            // gbMatrix
            // 
            this.gbMatrix.Controls.Add(this.rbAdjLists);
            this.gbMatrix.Controls.Add(this.rbAdjMatrix);
            this.gbMatrix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(46)))), ((int)(((byte)(0)))));
            this.gbMatrix.Location = new System.Drawing.Point(1, 386);
            this.gbMatrix.Name = "gbMatrix";
            this.gbMatrix.Size = new System.Drawing.Size(583, 51);
            this.gbMatrix.TabIndex = 3;
            this.gbMatrix.TabStop = false;
            this.gbMatrix.Text = "Представление графа";
            // 
            // rbAdjLists
            // 
            this.rbAdjLists.AutoSize = true;
            this.rbAdjLists.Location = new System.Drawing.Point(254, 21);
            this.rbAdjLists.Name = "rbAdjLists";
            this.rbAdjLists.Size = new System.Drawing.Size(325, 22);
            this.rbAdjLists.TabIndex = 1;
            this.rbAdjLists.Text = "Сортированные списки смежности вершин";
            this.rbAdjLists.UseVisualStyleBackColor = true;
            this.rbAdjLists.CheckedChanged += new System.EventHandler(this.rbAdjLists_CheckedChanged);
            // 
            // rbAdjMatrix
            // 
            this.rbAdjMatrix.AutoSize = true;
            this.rbAdjMatrix.Checked = true;
            this.rbAdjMatrix.Location = new System.Drawing.Point(8, 20);
            this.rbAdjMatrix.Name = "rbAdjMatrix";
            this.rbAdjMatrix.Size = new System.Drawing.Size(165, 22);
            this.rbAdjMatrix.TabIndex = 0;
            this.rbAdjMatrix.TabStop = true;
            this.rbAdjMatrix.Text = "Матрица смежности";
            this.rbAdjMatrix.UseVisualStyleBackColor = true;
            this.rbAdjMatrix.CheckedChanged += new System.EventHandler(this.rbAdjMatrix_CheckedChanged);
            // 
            // tabPageAlgVis
            // 
            this.tabPageAlgVis.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageAlgVis.Controls.Add(this.gbDescrSwitch);
            this.tabPageAlgVis.Controls.Add(this.pnlAlgorithmsControls);
            this.tabPageAlgVis.Controls.Add(this.pnlLog);
            this.tabPageAlgVis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(75)))), ((int)(((byte)(0)))));
            this.tabPageAlgVis.Location = new System.Drawing.Point(4, 25);
            this.tabPageAlgVis.Name = "tabPageAlgVis";
            this.tabPageAlgVis.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAlgVis.Size = new System.Drawing.Size(593, 714);
            this.tabPageAlgVis.TabIndex = 1;
            this.tabPageAlgVis.Text = "Визуализация алгоритмов";
            this.tabPageAlgVis.SizeChanged += new System.EventHandler(this.tabPageAlgVis_SizeChanged);
            // 
            // gbDescrSwitch
            // 
            this.gbDescrSwitch.Controls.Add(this.rbDataStructures);
            this.gbDescrSwitch.Controls.Add(this.rbLog);
            this.gbDescrSwitch.Location = new System.Drawing.Point(3, 259);
            this.gbDescrSwitch.Name = "gbDescrSwitch";
            this.gbDescrSwitch.Size = new System.Drawing.Size(304, 50);
            this.gbDescrSwitch.TabIndex = 14;
            this.gbDescrSwitch.TabStop = false;
            this.gbDescrSwitch.Text = "Подробности";
            // 
            // rbDataStructures
            // 
            this.rbDataStructures.AutoSize = true;
            this.rbDataStructures.Location = new System.Drawing.Point(150, 19);
            this.rbDataStructures.Name = "rbDataStructures";
            this.rbDataStructures.Size = new System.Drawing.Size(157, 22);
            this.rbDataStructures.TabIndex = 1;
            this.rbDataStructures.Text = "Структуры данных";
            this.rbDataStructures.UseVisualStyleBackColor = true;
            this.rbDataStructures.CheckedChanged += new System.EventHandler(this.rbDataStructures_CheckedChanged);
            // 
            // rbLog
            // 
            this.rbLog.AutoSize = true;
            this.rbLog.Checked = true;
            this.rbLog.Location = new System.Drawing.Point(5, 19);
            this.rbLog.Name = "rbLog";
            this.rbLog.Size = new System.Drawing.Size(141, 22);
            this.rbLog.TabIndex = 0;
            this.rbLog.TabStop = true;
            this.rbLog.Text = "Ход выполнения";
            this.rbLog.UseVisualStyleBackColor = true;
            this.rbLog.CheckedChanged += new System.EventHandler(this.rbLog_CheckedChanged);
            // 
            // pnlAlgorithmsControls
            // 
            this.pnlAlgorithmsControls.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlAlgorithmsControls.Controls.Add(this.gbSpeedVis);
            this.pnlAlgorithmsControls.Controls.Add(this.gbAlgSet);
            this.pnlAlgorithmsControls.Controls.Add(this.gbDescription);
            this.pnlAlgorithmsControls.Controls.Add(this.btnStartAlgorithm);
            this.pnlAlgorithmsControls.Location = new System.Drawing.Point(3, 3);
            this.pnlAlgorithmsControls.Name = "pnlAlgorithmsControls";
            this.pnlAlgorithmsControls.Size = new System.Drawing.Size(584, 250);
            this.pnlAlgorithmsControls.TabIndex = 13;
            // 
            // gbSpeedVis
            // 
            this.gbSpeedVis.Controls.Add(this.tbSpeedVis);
            this.gbSpeedVis.Controls.Add(this.lblSpeedBotom);
            this.gbSpeedVis.Controls.Add(this.lblSpeedTop);
            this.gbSpeedVis.Location = new System.Drawing.Point(3, 3);
            this.gbSpeedVis.Name = "gbSpeedVis";
            this.gbSpeedVis.Size = new System.Drawing.Size(93, 242);
            this.gbSpeedVis.TabIndex = 4;
            this.gbSpeedVis.TabStop = false;
            this.gbSpeedVis.Text = "Скорость";
            // 
            // tbSpeedVis
            // 
            this.tbSpeedVis.LargeChange = 2;
            this.tbSpeedVis.Location = new System.Drawing.Point(18, 52);
            this.tbSpeedVis.Minimum = 1;
            this.tbSpeedVis.Name = "tbSpeedVis";
            this.tbSpeedVis.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbSpeedVis.Size = new System.Drawing.Size(56, 154);
            this.tbSpeedVis.TabIndex = 1;
            this.tbSpeedVis.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbSpeedVis.Value = 1;
            // 
            // lblSpeedBotom
            // 
            this.lblSpeedBotom.AutoSize = true;
            this.lblSpeedBotom.Location = new System.Drawing.Point(11, 215);
            this.lblSpeedBotom.Name = "lblSpeedBotom";
            this.lblSpeedBotom.Size = new System.Drawing.Size(64, 18);
            this.lblSpeedBotom.TabIndex = 3;
            this.lblSpeedBotom.Text = "Быстрее";
            // 
            // lblSpeedTop
            // 
            this.lblSpeedTop.AutoSize = true;
            this.lblSpeedTop.Location = new System.Drawing.Point(11, 27);
            this.lblSpeedTop.Name = "lblSpeedTop";
            this.lblSpeedTop.Size = new System.Drawing.Size(72, 18);
            this.lblSpeedTop.TabIndex = 2;
            this.lblSpeedTop.Text = "Медленее";
            // 
            // gbAlgSet
            // 
            this.gbAlgSet.Controls.Add(this.chBoxPrimStartFrom0);
            this.gbAlgSet.Controls.Add(this.rbBoruvka);
            this.gbAlgSet.Controls.Add(this.rbPrim);
            this.gbAlgSet.Controls.Add(this.rbKruskal);
            this.gbAlgSet.Location = new System.Drawing.Point(103, 3);
            this.gbAlgSet.Name = "gbAlgSet";
            this.gbAlgSet.Size = new System.Drawing.Size(371, 66);
            this.gbAlgSet.TabIndex = 8;
            this.gbAlgSet.TabStop = false;
            this.gbAlgSet.Text = "Алгоритм поиска минимального остова";
            // 
            // chBoxPrimStartFrom0
            // 
            this.chBoxPrimStartFrom0.AutoSize = true;
            this.chBoxPrimStartFrom0.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chBoxPrimStartFrom0.Location = new System.Drawing.Point(255, 29);
            this.chBoxPrimStartFrom0.Name = "chBoxPrimStartFrom0";
            this.chBoxPrimStartFrom0.Size = new System.Drawing.Size(110, 21);
            this.chBoxPrimStartFrom0.TabIndex = 12;
            this.chBoxPrimStartFrom0.Text = "начать с 0";
            this.chBoxPrimStartFrom0.UseVisualStyleBackColor = true;
            // 
            // rbBoruvka
            // 
            this.rbBoruvka.AutoSize = true;
            this.rbBoruvka.Location = new System.Drawing.Point(98, 27);
            this.rbBoruvka.Name = "rbBoruvka";
            this.rbBoruvka.Size = new System.Drawing.Size(85, 22);
            this.rbBoruvka.TabIndex = 11;
            this.rbBoruvka.Text = "Борувки";
            this.rbBoruvka.UseVisualStyleBackColor = true;
            this.rbBoruvka.CheckedChanged += new System.EventHandler(this.rbBoruvka_CheckedChanged);
            // 
            // rbPrim
            // 
            this.rbPrim.AutoSize = true;
            this.rbPrim.Checked = true;
            this.rbPrim.Location = new System.Drawing.Point(187, 27);
            this.rbPrim.Name = "rbPrim";
            this.rbPrim.Size = new System.Drawing.Size(69, 22);
            this.rbPrim.TabIndex = 9;
            this.rbPrim.TabStop = true;
            this.rbPrim.Text = "Прима";
            this.rbPrim.UseVisualStyleBackColor = true;
            this.rbPrim.CheckedChanged += new System.EventHandler(this.rbPrim_CheckedChanged);
            // 
            // rbKruskal
            // 
            this.rbKruskal.AutoSize = true;
            this.rbKruskal.Location = new System.Drawing.Point(6, 27);
            this.rbKruskal.Name = "rbKruskal";
            this.rbKruskal.Size = new System.Drawing.Size(93, 22);
            this.rbKruskal.TabIndex = 10;
            this.rbKruskal.Text = "Краскала";
            this.rbKruskal.UseVisualStyleBackColor = true;
            this.rbKruskal.CheckedChanged += new System.EventHandler(this.rbKruskal_CheckedChanged);
            // 
            // gbDescription
            // 
            this.gbDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbDescription.Controls.Add(this.lblDescription);
            this.gbDescription.Location = new System.Drawing.Point(103, 76);
            this.gbDescription.Name = "gbDescription";
            this.gbDescription.Size = new System.Drawing.Size(478, 169);
            this.gbDescription.TabIndex = 10;
            this.gbDescription.TabStop = false;
            this.gbDescription.Text = "Краткое описание алгоритма";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 20);
            this.lblDescription.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(72, 18);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.Text = "Описание";
            // 
            // btnStartAlgorithm
            // 
            this.btnStartAlgorithm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(187)))), ((int)(((byte)(93)))));
            this.btnStartAlgorithm.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartAlgorithm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(46)))), ((int)(((byte)(0)))));
            this.btnStartAlgorithm.Location = new System.Drawing.Point(475, 11);
            this.btnStartAlgorithm.Name = "btnStartAlgorithm";
            this.btnStartAlgorithm.Size = new System.Drawing.Size(105, 58);
            this.btnStartAlgorithm.TabIndex = 9;
            this.btnStartAlgorithm.Text = "Запустить алгоритм";
            this.btnStartAlgorithm.UseVisualStyleBackColor = false;
            this.btnStartAlgorithm.Click += new System.EventHandler(this.btnStartAlgorithm_Click);
            // 
            // pnlLog
            // 
            this.pnlLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlLog.AutoScroll = true;
            this.pnlLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(224)))), ((int)(((byte)(149)))));
            this.pnlLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLog.Controls.Add(this.lblLog);
            this.pnlLog.Controls.Add(this.pbDataStructures);
            this.pnlLog.Location = new System.Drawing.Point(3, 315);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(587, 394);
            this.pnlLog.TabIndex = 12;
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(224)))), ((int)(((byte)(149)))));
            this.lblLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(46)))), ((int)(((byte)(0)))));
            this.lblLog.Location = new System.Drawing.Point(3, 3);
            this.lblLog.MaximumSize = new System.Drawing.Size(520, 0);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(200, 18);
            this.lblLog.TabIndex = 0;
            this.lblLog.Text = "Ход выполнения алгоритма";
            this.lblLog.SizeChanged += new System.EventHandler(this.lblLog_SizeChanged);
            // 
            // pbDataStructures
            // 
            this.pbDataStructures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pbDataStructures.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(224)))), ((int)(((byte)(149)))));
            this.pbDataStructures.Location = new System.Drawing.Point(0, 0);
            this.pbDataStructures.Name = "pbDataStructures";
            this.pbDataStructures.Size = new System.Drawing.Size(585, 392);
            this.pbDataStructures.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbDataStructures.TabIndex = 1;
            this.pbDataStructures.TabStop = false;
            this.pbDataStructures.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(250)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(1328, 753);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinimumSize = new System.Drawing.Size(1320, 800);
            this.Name = "Form1";
            this.Text = "Поиск минимального остова взвешенного неориентированного графа";
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
            this.tabPageEditor.PerformLayout();
            this.pnlGraphEditor.ResumeLayout(false);
            this.gbGraphGen.ResumeLayout(false);
            this.gbGraphGen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBarMaxWeight)).EndInit();
            this.gbEditMode.ResumeLayout(false);
            this.gbEditMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdjMatrix)).EndInit();
            this.gbMatrix.ResumeLayout(false);
            this.gbMatrix.PerformLayout();
            this.tabPageAlgVis.ResumeLayout(false);
            this.gbDescrSwitch.ResumeLayout(false);
            this.gbDescrSwitch.PerformLayout();
            this.pnlAlgorithmsControls.ResumeLayout(false);
            this.gbSpeedVis.ResumeLayout(false);
            this.gbSpeedVis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeedVis)).EndInit();
            this.gbAlgSet.ResumeLayout(false);
            this.gbAlgSet.PerformLayout();
            this.gbDescription.ResumeLayout(false);
            this.gbDescription.PerformLayout();
            this.pnlLog.ResumeLayout(false);
            this.pnlLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDataStructures)).EndInit();
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
        private System.Windows.Forms.TabPage tabPageAlgVis;
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
        private System.Windows.Forms.Label lblSpeedBotom;
        private System.Windows.Forms.Label lblSpeedTop;
        private System.Windows.Forms.TrackBar tbSpeedVis;
        private System.Windows.Forms.GroupBox gbSpeedVis;
        private System.Windows.Forms.Button btnStartAlgorithm;
        private System.Windows.Forms.GroupBox gbAlgSet;
        private System.Windows.Forms.RadioButton rbBoruvka;
        private System.Windows.Forms.RadioButton rbKruskal;
        private System.Windows.Forms.RadioButton rbPrim;
        private System.Windows.Forms.GroupBox gbDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.Panel pnlGraphEditor;
        private System.Windows.Forms.Panel pnlAlgorithmsControls;
        private System.Windows.Forms.PictureBox pbDataStructures;
        private System.Windows.Forms.GroupBox gbDescrSwitch;
        private System.Windows.Forms.RadioButton rbDataStructures;
        private System.Windows.Forms.RadioButton rbLog;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.CheckBox chBoxShowID;
        private System.Windows.Forms.CheckBox chBoxPrimStartFrom0;
    }
}

