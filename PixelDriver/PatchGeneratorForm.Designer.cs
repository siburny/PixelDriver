namespace PixelDriver
{
	partial class PatchGeneratorForm
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
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonAddPatch = new System.Windows.Forms.Button();
			this.groupBoxPatchInfo = new System.Windows.Forms.GroupBox();
			this.panelPatchContainer = new PixelDriver.DoubleBufferedPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.labelX = new System.Windows.Forms.Label();
			this.labelY = new System.Windows.Forms.Label();
			this.labelLength = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxUniverse = new System.Windows.Forms.TextBox();
			this.textBoxStartChannel = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonSavePatch = new System.Windows.Forms.Button();
			this.flowLayoutPanel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBoxPatchInfo.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.groupBox1);
			this.flowLayoutPanel1.Controls.Add(this.groupBoxPatchInfo);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(872, 8);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(192, 528);
			this.flowLayoutPanel1.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.buttonCancel);
			this.groupBox1.Controls.Add(this.buttonAddPatch);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(190, 61);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Actions";
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(8, 24);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(176, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Visible = false;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonAddPatch
			// 
			this.buttonAddPatch.Location = new System.Drawing.Point(8, 24);
			this.buttonAddPatch.Name = "buttonAddPatch";
			this.buttonAddPatch.Size = new System.Drawing.Size(176, 23);
			this.buttonAddPatch.TabIndex = 0;
			this.buttonAddPatch.Text = "Add Patch";
			this.buttonAddPatch.UseVisualStyleBackColor = true;
			this.buttonAddPatch.Click += new System.EventHandler(this.buttonAddPatch_Click);
			// 
			// groupBoxPatchInfo
			// 
			this.groupBoxPatchInfo.Controls.Add(this.buttonSavePatch);
			this.groupBoxPatchInfo.Controls.Add(this.textBoxStartChannel);
			this.groupBoxPatchInfo.Controls.Add(this.label5);
			this.groupBoxPatchInfo.Controls.Add(this.textBoxUniverse);
			this.groupBoxPatchInfo.Controls.Add(this.label4);
			this.groupBoxPatchInfo.Controls.Add(this.labelLength);
			this.groupBoxPatchInfo.Controls.Add(this.labelY);
			this.groupBoxPatchInfo.Controls.Add(this.labelX);
			this.groupBoxPatchInfo.Controls.Add(this.label3);
			this.groupBoxPatchInfo.Controls.Add(this.label2);
			this.groupBoxPatchInfo.Controls.Add(this.label1);
			this.groupBoxPatchInfo.Location = new System.Drawing.Point(3, 70);
			this.groupBoxPatchInfo.Name = "groupBoxPatchInfo";
			this.groupBoxPatchInfo.Size = new System.Drawing.Size(189, 114);
			this.groupBoxPatchInfo.TabIndex = 1;
			this.groupBoxPatchInfo.TabStop = false;
			this.groupBoxPatchInfo.Text = "Patch Info";
			this.groupBoxPatchInfo.Visible = false;
			// 
			// panelPatchContainer
			// 
			this.panelPatchContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelPatchContainer.Location = new System.Drawing.Point(8, 8);
			this.panelPatchContainer.Name = "panelPatchContainer";
			this.panelPatchContainer.Size = new System.Drawing.Size(856, 528);
			this.panelPatchContainer.TabIndex = 0;
			this.panelPatchContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPatchContainer_Paint);
			this.panelPatchContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelPatchContainer_MouseDown);
			this.panelPatchContainer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelPatchContainer_MouseMove);
			this.panelPatchContainer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelPatchContainer_MouseUp);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(19, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "X:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(64, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(19, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Y:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(117, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Len:";
			// 
			// labelX
			// 
			this.labelX.AutoSize = true;
			this.labelX.Location = new System.Drawing.Point(24, 24);
			this.labelX.Name = "labelX";
			this.labelX.Size = new System.Drawing.Size(13, 13);
			this.labelX.TabIndex = 3;
			this.labelX.Text = "1";
			// 
			// labelY
			// 
			this.labelY.AutoSize = true;
			this.labelY.Location = new System.Drawing.Point(80, 24);
			this.labelY.Name = "labelY";
			this.labelY.Size = new System.Drawing.Size(13, 13);
			this.labelY.TabIndex = 4;
			this.labelY.Text = "1";
			// 
			// labelLength
			// 
			this.labelLength.AutoSize = true;
			this.labelLength.Location = new System.Drawing.Point(144, 24);
			this.labelLength.Name = "labelLength";
			this.labelLength.Size = new System.Drawing.Size(13, 13);
			this.labelLength.TabIndex = 5;
			this.labelLength.Text = "1";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(8, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(37, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Univ:";
			// 
			// textBoxUniverse
			// 
			this.textBoxUniverse.Location = new System.Drawing.Point(46, 46);
			this.textBoxUniverse.Name = "textBoxUniverse";
			this.textBoxUniverse.Size = new System.Drawing.Size(32, 20);
			this.textBoxUniverse.TabIndex = 7;
			// 
			// textBoxStartChannel
			// 
			this.textBoxStartChannel.Location = new System.Drawing.Point(145, 47);
			this.textBoxStartChannel.Name = "textBoxStartChannel";
			this.textBoxStartChannel.Size = new System.Drawing.Size(32, 20);
			this.textBoxStartChannel.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(88, 49);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Channel:";
			// 
			// buttonSavePatch
			// 
			this.buttonSavePatch.Location = new System.Drawing.Point(8, 80);
			this.buttonSavePatch.Name = "buttonSavePatch";
			this.buttonSavePatch.Size = new System.Drawing.Size(176, 23);
			this.buttonSavePatch.TabIndex = 10;
			this.buttonSavePatch.Text = "Save";
			this.buttonSavePatch.UseVisualStyleBackColor = true;
			this.buttonSavePatch.Click += new System.EventHandler(this.buttonSavePatch_Click);
			// 
			// PatchGeneratorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1072, 544);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.panelPatchContainer);
			this.Name = "PatchGeneratorForm";
			this.Text = "PatchGeneratorForm";
			this.flowLayoutPanel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBoxPatchInfo.ResumeLayout(false);
			this.groupBoxPatchInfo.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button buttonAddPatch;
		private System.Windows.Forms.Button buttonCancel;
		private DoubleBufferedPanel panelPatchContainer;
		private System.Windows.Forms.GroupBox groupBoxPatchInfo;
		private System.Windows.Forms.Label labelLength;
		private System.Windows.Forms.Label labelY;
		private System.Windows.Forms.Label labelX;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxStartChannel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxUniverse;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button buttonSavePatch;

	}
}