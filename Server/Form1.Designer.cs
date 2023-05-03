
namespace Server
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Users");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Groups");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Users & Groups", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Assign tests to users");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Review test results");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Users & Tests", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Tests");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Server");
            this.button1 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panelGeneral = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelUsers = new System.Windows.Forms.Panel();
            this.DeleteUserBtn = new System.Windows.Forms.Button();
            this.EditUserBtn = new System.Windows.Forms.Button();
            this.AddUserBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panelGroups = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.activePanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelGeneral.SuspendLayout();
            this.panelUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelGroups.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(721, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(18, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "AddGroup";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeView1
            // 
            this.treeView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeView1.Location = new System.Drawing.Point(3, 1);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "General";
            treeNode1.Text = "General";
            treeNode2.Name = "Users";
            treeNode2.Text = "Users";
            treeNode3.Name = "Groups";
            treeNode3.Text = "Groups";
            treeNode4.Name = "Node1";
            treeNode4.Text = "Users & Groups";
            treeNode5.Name = "Assignteststousers";
            treeNode5.Text = "Assign tests to users";
            treeNode6.Name = "Reviewtestresults";
            treeNode6.Text = "Review test results";
            treeNode7.Name = "Node2";
            treeNode7.Text = "Users & Tests";
            treeNode8.Name = "Tests";
            treeNode8.Text = "Tests";
            treeNode9.Name = "Server";
            treeNode9.Text = "Server";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode4,
            treeNode7,
            treeNode8,
            treeNode9});
            this.treeView1.Size = new System.Drawing.Size(158, 363);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panelGeneral
            // 
            this.panelGeneral.Controls.Add(this.label19);
            this.panelGeneral.Controls.Add(this.label18);
            this.panelGeneral.Controls.Add(this.label17);
            this.panelGeneral.Controls.Add(this.label16);
            this.panelGeneral.Controls.Add(this.label15);
            this.panelGeneral.Controls.Add(this.label14);
            this.panelGeneral.Controls.Add(this.label13);
            this.panelGeneral.Controls.Add(this.label12);
            this.panelGeneral.Controls.Add(this.label11);
            this.panelGeneral.Controls.Add(this.label10);
            this.panelGeneral.Controls.Add(this.textBox13);
            this.panelGeneral.Controls.Add(this.textBox12);
            this.panelGeneral.Controls.Add(this.textBox11);
            this.panelGeneral.Controls.Add(this.textBox10);
            this.panelGeneral.Controls.Add(this.textBox9);
            this.panelGeneral.Controls.Add(this.textBox8);
            this.panelGeneral.Controls.Add(this.textBox7);
            this.panelGeneral.Controls.Add(this.textBox6);
            this.panelGeneral.Controls.Add(this.textBox5);
            this.panelGeneral.Controls.Add(this.textBox4);
            this.panelGeneral.Controls.Add(this.textBox3);
            this.panelGeneral.Controls.Add(this.textBox2);
            this.panelGeneral.Controls.Add(this.textBox1);
            this.panelGeneral.Controls.Add(this.label9);
            this.panelGeneral.Controls.Add(this.label8);
            this.panelGeneral.Controls.Add(this.label7);
            this.panelGeneral.Controls.Add(this.label6);
            this.panelGeneral.Controls.Add(this.label5);
            this.panelGeneral.Controls.Add(this.label4);
            this.panelGeneral.Controls.Add(this.label1);
            this.panelGeneral.Controls.Add(this.button1);
            this.panelGeneral.Location = new System.Drawing.Point(753, 292);
            this.panelGeneral.Name = "panelGeneral";
            this.panelGeneral.Size = new System.Drawing.Size(114, 38);
            this.panelGeneral.TabIndex = 2;
            this.panelGeneral.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(494, 175);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(83, 15);
            this.label19.TabIndex = 29;
            this.label19.Text = "AVG q-s count";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(493, 146);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 15);
            this.label18.TabIndex = 28;
            this.label18.Text = "Min q-s count";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(493, 117);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 15);
            this.label17.TabIndex = 27;
            this.label17.Text = "Max q-s count";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(493, 88);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 15);
            this.label16.TabIndex = 26;
            this.label16.Text = "Count in DB";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(284, 231);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 15);
            this.label15.TabIndex = 25;
            this.label15.Text = "AVG passed";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(259, 202);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 15);
            this.label14.TabIndex = 24;
            this.label14.Text = "AVG perfomance";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(284, 175);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 15);
            this.label13.TabIndex = 23;
            this.label13.Text = "Failed tests";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(273, 146);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 15);
            this.label12.TabIndex = 22;
            this.label12.Text = "Passed tests";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(262, 117);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 15);
            this.label11.TabIndex = 21;
            this.label11.Text = "Completed tests";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(273, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 15);
            this.label10.TabIndex = 20;
            this.label10.Text = "Assigned tests";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(584, 167);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(100, 23);
            this.textBox13.TabIndex = 19;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(584, 138);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(100, 23);
            this.textBox12.TabIndex = 18;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(584, 109);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(100, 23);
            this.textBox11.TabIndex = 17;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(584, 80);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(100, 23);
            this.textBox10.TabIndex = 16;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(361, 223);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(100, 23);
            this.textBox9.TabIndex = 15;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(361, 194);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(100, 23);
            this.textBox8.TabIndex = 14;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(361, 167);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(100, 23);
            this.textBox7.TabIndex = 13;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(361, 138);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(100, 23);
            this.textBox6.TabIndex = 12;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(361, 109);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(100, 23);
            this.textBox5.TabIndex = 11;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(361, 80);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(100, 23);
            this.textBox4.TabIndex = 10;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(130, 150);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 23);
            this.textBox3.TabIndex = 9;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(130, 121);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(130, 92);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(59, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 15);
            this.label9.TabIndex = 6;
            this.label9.Text = "Groups";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "Admins";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Users";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(515, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Tests";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(284, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Users and Tests";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Users and Groups";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "General";
            // 
            // panelUsers
            // 
            this.panelUsers.Controls.Add(this.DeleteUserBtn);
            this.panelUsers.Controls.Add(this.EditUserBtn);
            this.panelUsers.Controls.Add(this.AddUserBtn);
            this.panelUsers.Controls.Add(this.dataGridView1);
            this.panelUsers.Controls.Add(this.label2);
            this.panelUsers.Location = new System.Drawing.Point(6, 11);
            this.panelUsers.Name = "panelUsers";
            this.panelUsers.Size = new System.Drawing.Size(741, 357);
            this.panelUsers.TabIndex = 3;
            this.panelUsers.Visible = false;
            // 
            // DeleteUserBtn
            // 
            this.DeleteUserBtn.Location = new System.Drawing.Point(206, 17);
            this.DeleteUserBtn.Name = "DeleteUserBtn";
            this.DeleteUserBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteUserBtn.TabIndex = 4;
            this.DeleteUserBtn.Text = "Delete User";
            this.DeleteUserBtn.UseVisualStyleBackColor = true;
            this.DeleteUserBtn.Click += new System.EventHandler(this.DeleteUserBtn_Click);
            // 
            // EditUserBtn
            // 
            this.EditUserBtn.Location = new System.Drawing.Point(125, 17);
            this.EditUserBtn.Name = "EditUserBtn";
            this.EditUserBtn.Size = new System.Drawing.Size(75, 23);
            this.EditUserBtn.TabIndex = 3;
            this.EditUserBtn.Text = "Edit User";
            this.EditUserBtn.UseVisualStyleBackColor = true;
            this.EditUserBtn.Click += new System.EventHandler(this.EditUserBtn_Click);
            // 
            // AddUserBtn
            // 
            this.AddUserBtn.Location = new System.Drawing.Point(44, 17);
            this.AddUserBtn.Name = "AddUserBtn";
            this.AddUserBtn.Size = new System.Drawing.Size(75, 23);
            this.AddUserBtn.TabIndex = 2;
            this.AddUserBtn.Text = "Add User";
            this.AddUserBtn.UseVisualStyleBackColor = true;
            this.AddUserBtn.Click += new System.EventHandler(this.AddUserBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(711, 286);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Users";
            // 
            // panelGroups
            // 
            this.panelGroups.Controls.Add(this.label3);
            this.panelGroups.Location = new System.Drawing.Point(753, 186);
            this.panelGroups.Name = "panelGroups";
            this.panelGroups.Size = new System.Drawing.Size(200, 100);
            this.panelGroups.TabIndex = 4;
            this.panelGroups.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Groups";
            // 
            // activePanel
            // 
            this.activePanel.Location = new System.Drawing.Point(753, 80);
            this.activePanel.Name = "activePanel";
            this.activePanel.Size = new System.Drawing.Size(200, 100);
            this.activePanel.TabIndex = 5;
            this.activePanel.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelGroups);
            this.groupBox1.Controls.Add(this.panelUsers);
            this.groupBox1.Controls.Add(this.activePanel);
            this.groupBox1.Controls.Add(this.panelGeneral);
            this.groupBox1.Location = new System.Drawing.Point(167, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(774, 374);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 376);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelGeneral.ResumeLayout(false);
            this.panelGeneral.PerformLayout();
            this.panelUsers.ResumeLayout(false);
            this.panelUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelGroups.ResumeLayout(false);
            this.panelGroups.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panelGeneral;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelGroups;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel activePanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button DeleteUserBtn;
        private System.Windows.Forms.Button EditUserBtn;
        private System.Windows.Forms.Button AddUserBtn;
    }
}

