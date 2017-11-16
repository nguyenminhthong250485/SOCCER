namespace AGENT_NEW
{
    partial class AgentList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Panel_Menu = new System.Windows.Forms.Panel();
            this.bt_WinLoseWeek = new System.Windows.Forms.Button();
            this.bt_Login = new System.Windows.Forms.Button();
            this.bt_AddAgent = new System.Windows.Forms.Button();
            this.table_Agent = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewSBO = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewIBET = new System.Windows.Forms.DataGridView();
            this.table_RichTextBox = new System.Windows.Forms.TableLayoutPanel();
            this.rtb_OutPut = new System.Windows.Forms.RichTextBox();
            this.rtb_InPut = new System.Windows.Forms.RichTextBox();
            this.bt_Transfer = new System.Windows.Forms.Button();
            this.Panel_Menu.SuspendLayout();
            this.table_Agent.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSBO)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIBET)).BeginInit();
            this.table_RichTextBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Menu
            // 
            this.Panel_Menu.Controls.Add(this.bt_Transfer);
            this.Panel_Menu.Controls.Add(this.bt_WinLoseWeek);
            this.Panel_Menu.Controls.Add(this.bt_Login);
            this.Panel_Menu.Controls.Add(this.bt_AddAgent);
            this.Panel_Menu.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel_Menu.Location = new System.Drawing.Point(0, 0);
            this.Panel_Menu.Name = "Panel_Menu";
            this.Panel_Menu.Size = new System.Drawing.Size(1151, 62);
            this.Panel_Menu.TabIndex = 0;
            // 
            // bt_WinLoseWeek
            // 
            this.bt_WinLoseWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_WinLoseWeek.Location = new System.Drawing.Point(242, 13);
            this.bt_WinLoseWeek.Name = "bt_WinLoseWeek";
            this.bt_WinLoseWeek.Size = new System.Drawing.Size(112, 32);
            this.bt_WinLoseWeek.TabIndex = 2;
            this.bt_WinLoseWeek.Text = "WL Week";
            this.bt_WinLoseWeek.UseVisualStyleBackColor = true;
            this.bt_WinLoseWeek.Click += new System.EventHandler(this.bt_WinLoseWeek_Click);
            // 
            // bt_Login
            // 
            this.bt_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Login.Location = new System.Drawing.Point(124, 13);
            this.bt_Login.Name = "bt_Login";
            this.bt_Login.Size = new System.Drawing.Size(112, 32);
            this.bt_Login.TabIndex = 1;
            this.bt_Login.Text = "Login";
            this.bt_Login.UseVisualStyleBackColor = true;
            this.bt_Login.Click += new System.EventHandler(this.bt_Login_Click);
            // 
            // bt_AddAgent
            // 
            this.bt_AddAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_AddAgent.Location = new System.Drawing.Point(6, 13);
            this.bt_AddAgent.Name = "bt_AddAgent";
            this.bt_AddAgent.Size = new System.Drawing.Size(112, 32);
            this.bt_AddAgent.TabIndex = 0;
            this.bt_AddAgent.Text = "Add Agent";
            this.bt_AddAgent.UseVisualStyleBackColor = true;
            this.bt_AddAgent.Click += new System.EventHandler(this.bt_AddAgent_Click);
            // 
            // table_Agent
            // 
            this.table_Agent.ColumnCount = 2;
            this.table_Agent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_Agent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_Agent.Controls.Add(this.groupBox2, 1, 0);
            this.table_Agent.Controls.Add(this.groupBox1, 0, 0);
            this.table_Agent.Dock = System.Windows.Forms.DockStyle.Top;
            this.table_Agent.Location = new System.Drawing.Point(0, 62);
            this.table_Agent.Name = "table_Agent";
            this.table_Agent.RowCount = 1;
            this.table_Agent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_Agent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 303F));
            this.table_Agent.Size = new System.Drawing.Size(1151, 303);
            this.table_Agent.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewSBO);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(578, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 297);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SBO";
            // 
            // dataGridViewSBO
            // 
            this.dataGridViewSBO.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewSBO.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSBO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSBO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSBO.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewSBO.Name = "dataGridViewSBO";
            this.dataGridViewSBO.RowHeadersVisible = false;
            this.dataGridViewSBO.Size = new System.Drawing.Size(564, 278);
            this.dataGridViewSBO.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewIBET);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 297);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IBET";
            // 
            // dataGridViewIBET
            // 
            this.dataGridViewIBET.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewIBET.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewIBET.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIBET.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewIBET.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewIBET.Name = "dataGridViewIBET";
            this.dataGridViewIBET.RowHeadersVisible = false;
            this.dataGridViewIBET.Size = new System.Drawing.Size(563, 278);
            this.dataGridViewIBET.TabIndex = 7;
            // 
            // table_RichTextBox
            // 
            this.table_RichTextBox.ColumnCount = 2;
            this.table_RichTextBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_RichTextBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_RichTextBox.Controls.Add(this.rtb_OutPut, 1, 0);
            this.table_RichTextBox.Controls.Add(this.rtb_InPut, 0, 0);
            this.table_RichTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.table_RichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.table_RichTextBox.Location = new System.Drawing.Point(0, 391);
            this.table_RichTextBox.Name = "table_RichTextBox";
            this.table_RichTextBox.RowCount = 1;
            this.table_RichTextBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_RichTextBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table_RichTextBox.Size = new System.Drawing.Size(1151, 243);
            this.table_RichTextBox.TabIndex = 2;
            // 
            // rtb_OutPut
            // 
            this.rtb_OutPut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_OutPut.Location = new System.Drawing.Point(578, 3);
            this.rtb_OutPut.Name = "rtb_OutPut";
            this.rtb_OutPut.Size = new System.Drawing.Size(570, 237);
            this.rtb_OutPut.TabIndex = 1;
            this.rtb_OutPut.Text = "";
            // 
            // rtb_InPut
            // 
            this.rtb_InPut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_InPut.Location = new System.Drawing.Point(3, 3);
            this.rtb_InPut.Name = "rtb_InPut";
            this.rtb_InPut.Size = new System.Drawing.Size(569, 237);
            this.rtb_InPut.TabIndex = 0;
            this.rtb_InPut.Text = "";
            // 
            // bt_Transfer
            // 
            this.bt_Transfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Transfer.Location = new System.Drawing.Point(360, 13);
            this.bt_Transfer.Name = "bt_Transfer";
            this.bt_Transfer.Size = new System.Drawing.Size(112, 32);
            this.bt_Transfer.TabIndex = 3;
            this.bt_Transfer.Text = "Transfer";
            this.bt_Transfer.UseVisualStyleBackColor = true;
            this.bt_Transfer.Click += new System.EventHandler(this.bt_Transfer_Click);
            // 
            // AgentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table_RichTextBox);
            this.Controls.Add(this.table_Agent);
            this.Controls.Add(this.Panel_Menu);
            this.Name = "AgentList";
            this.Size = new System.Drawing.Size(1151, 634);
            this.Load += new System.EventHandler(this.AgentList_Load);
            this.Panel_Menu.ResumeLayout(false);
            this.table_Agent.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSBO)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIBET)).EndInit();
            this.table_RichTextBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Menu;
        private System.Windows.Forms.TableLayoutPanel table_Agent;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewSBO;
        private System.Windows.Forms.DataGridView dataGridViewIBET;
        private System.Windows.Forms.TableLayoutPanel table_RichTextBox;
        private System.Windows.Forms.RichTextBox rtb_OutPut;
        private System.Windows.Forms.RichTextBox rtb_InPut;
        private System.Windows.Forms.Button bt_AddAgent;
        private System.Windows.Forms.Button bt_Login;
        private System.Windows.Forms.Button bt_WinLoseWeek;
        private System.Windows.Forms.Button bt_Transfer;
    }
}
