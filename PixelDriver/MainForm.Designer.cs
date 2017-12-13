namespace PixelDriver
{
	partial class MainForm
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
			this.mainTimer = new System.Windows.Forms.Timer(this.components);
			this.buttonStartStop = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.controlPaneA = new PixelDriver.ControlPane();
			this.previewPaneA = new PixelDriver.PreviewPane();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.patchGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainTimer
			// 
			this.mainTimer.Enabled = true;
			this.mainTimer.Interval = 20;
			this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
			// 
			// buttonStartStop
			// 
			this.buttonStartStop.Location = new System.Drawing.Point(488, 32);
			this.buttonStartStop.Name = "buttonStartStop";
			this.buttonStartStop.Size = new System.Drawing.Size(75, 23);
			this.buttonStartStop.TabIndex = 1;
			this.buttonStartStop.Text = "Start";
			this.buttonStartStop.UseVisualStyleBackColor = true;
			this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 520);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 14);
			this.label1.TabIndex = 4;
			this.label1.Text = "label1";
			// 
			// controlPaneA
			// 
			this.controlPaneA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.controlPaneA.Location = new System.Drawing.Point(8, 208);
			this.controlPaneA.Name = "controlPaneA";
			this.controlPaneA.Size = new System.Drawing.Size(472, 312);
			this.controlPaneA.TabIndex = 3;
			// 
			// previewPaneA
			// 
			this.previewPaneA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.previewPaneA.Location = new System.Drawing.Point(8, 32);
			this.previewPaneA.Name = "previewPaneA";
			this.previewPaneA.Size = new System.Drawing.Size(472, 168);
			this.previewPaneA.TabIndex = 2;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patchGeneratorToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1182, 24);
			this.menuStrip1.TabIndex = 5;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// patchGeneratorToolStripMenuItem
			// 
			this.patchGeneratorToolStripMenuItem.Name = "patchGeneratorToolStripMenuItem";
			this.patchGeneratorToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
			this.patchGeneratorToolStripMenuItem.Text = "Patch Generator";
			this.patchGeneratorToolStripMenuItem.Click += new System.EventHandler(this.patchGeneratorToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1182, 590);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.controlPaneA);
			this.Controls.Add(this.previewPaneA);
			this.Controls.Add(this.buttonStartStop);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer mainTimer;
		private System.Windows.Forms.Button buttonStartStop;
		private PreviewPane previewPaneA;
		private ControlPane controlPaneA;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem patchGeneratorToolStripMenuItem;
	}
}

