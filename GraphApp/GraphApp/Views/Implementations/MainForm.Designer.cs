namespace GraphApp.Views.Implementations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.addVertexButton = new System.Windows.Forms.Button();
            this.vertexCountLabel = new System.Windows.Forms.Label();
            this.removableVertexTextBox = new System.Windows.Forms.TextBox();
            this.removableVertexLabel = new System.Windows.Forms.Label();
            this.removeVertexButton = new System.Windows.Forms.Button();
            this.secondVertexNumber = new System.Windows.Forms.TextBox();
            this.firstVertexNumber = new System.Windows.Forms.TextBox();
            this.firstVertexNumberLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addEdgeButton = new System.Windows.Forms.Button();
            this.removeEdgeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.weightTextBox = new System.Windows.Forms.TextBox();
            this.verticesAdjacentButton = new System.Windows.Forms.Button();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromAdjacentMatrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromEdgeListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToAdjacentMatrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToEdgeListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileAcitonsMenuStrip = new System.Windows.Forms.MenuStrip();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.edgesCountLabel = new System.Windows.Forms.Label();
            this.getWeightButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.fileAcitonsMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // addVertexButton
            // 
            resources.ApplyResources(this.addVertexButton, "addVertexButton");
            this.addVertexButton.Name = "addVertexButton";
            this.addVertexButton.UseVisualStyleBackColor = true;
            this.addVertexButton.Click += new System.EventHandler(this.addVertexButton_Click);
            // 
            // vertexCountLabel
            // 
            resources.ApplyResources(this.vertexCountLabel, "vertexCountLabel");
            this.vertexCountLabel.Name = "vertexCountLabel";
            // 
            // removableVertexTextBox
            // 
            resources.ApplyResources(this.removableVertexTextBox, "removableVertexTextBox");
            this.removableVertexTextBox.Name = "removableVertexTextBox";
            // 
            // removableVertexLabel
            // 
            resources.ApplyResources(this.removableVertexLabel, "removableVertexLabel");
            this.removableVertexLabel.Name = "removableVertexLabel";
            // 
            // removeVertexButton
            // 
            resources.ApplyResources(this.removeVertexButton, "removeVertexButton");
            this.removeVertexButton.Name = "removeVertexButton";
            this.removeVertexButton.UseVisualStyleBackColor = true;
            this.removeVertexButton.Click += new System.EventHandler(this.removeVertexButton_Click);
            // 
            // secondVertexNumber
            // 
            resources.ApplyResources(this.secondVertexNumber, "secondVertexNumber");
            this.secondVertexNumber.Name = "secondVertexNumber";
            // 
            // firstVertexNumber
            // 
            resources.ApplyResources(this.firstVertexNumber, "firstVertexNumber");
            this.firstVertexNumber.Name = "firstVertexNumber";
            // 
            // firstVertexNumberLabel
            // 
            resources.ApplyResources(this.firstVertexNumberLabel, "firstVertexNumberLabel");
            this.firstVertexNumberLabel.Name = "firstVertexNumberLabel";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // addEdgeButton
            // 
            resources.ApplyResources(this.addEdgeButton, "addEdgeButton");
            this.addEdgeButton.Name = "addEdgeButton";
            this.addEdgeButton.UseVisualStyleBackColor = true;
            this.addEdgeButton.Click += new System.EventHandler(this.addEdgeButton_Click);
            // 
            // removeEdgeButton
            // 
            resources.ApplyResources(this.removeEdgeButton, "removeEdgeButton");
            this.removeEdgeButton.Name = "removeEdgeButton";
            this.removeEdgeButton.UseVisualStyleBackColor = true;
            this.removeEdgeButton.Click += new System.EventHandler(this.removeEdgeButton_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // weightTextBox
            // 
            resources.ApplyResources(this.weightTextBox, "weightTextBox");
            this.weightTextBox.Name = "weightTextBox";
            // 
            // verticesAdjacentButton
            // 
            resources.ApplyResources(this.verticesAdjacentButton, "verticesAdjacentButton");
            this.verticesAdjacentButton.Name = "verticesAdjacentButton";
            this.verticesAdjacentButton.UseVisualStyleBackColor = true;
            this.verticesAdjacentButton.Click += new System.EventHandler(this.verticesAdjacentButton_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createGraphToolStripMenuItem,
            this.loadFromAdjacentMatrixToolStripMenuItem,
            this.loadFromEdgeListToolStripMenuItem,
            this.saveToAdjacentMatrixToolStripMenuItem,
            this.saveToEdgeListToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // createGraphToolStripMenuItem
            // 
            this.createGraphToolStripMenuItem.Name = "createGraphToolStripMenuItem";
            resources.ApplyResources(this.createGraphToolStripMenuItem, "createGraphToolStripMenuItem");
            this.createGraphToolStripMenuItem.Click += new System.EventHandler(this.createGraphToolStripMenuItem_Click);
            // 
            // loadFromAdjacentMatrixToolStripMenuItem
            // 
            this.loadFromAdjacentMatrixToolStripMenuItem.Name = "loadFromAdjacentMatrixToolStripMenuItem";
            resources.ApplyResources(this.loadFromAdjacentMatrixToolStripMenuItem, "loadFromAdjacentMatrixToolStripMenuItem");
            this.loadFromAdjacentMatrixToolStripMenuItem.Click += new System.EventHandler(this.loadFromAdjacentMatrixToolStripMenuItem_Click);
            // 
            // loadFromEdgeListToolStripMenuItem
            // 
            this.loadFromEdgeListToolStripMenuItem.Name = "loadFromEdgeListToolStripMenuItem";
            resources.ApplyResources(this.loadFromEdgeListToolStripMenuItem, "loadFromEdgeListToolStripMenuItem");
            this.loadFromEdgeListToolStripMenuItem.Click += new System.EventHandler(this.loadFromEdgeListToolStripMenuItem_Click);
            // 
            // saveToAdjacentMatrixToolStripMenuItem
            // 
            this.saveToAdjacentMatrixToolStripMenuItem.Name = "saveToAdjacentMatrixToolStripMenuItem";
            resources.ApplyResources(this.saveToAdjacentMatrixToolStripMenuItem, "saveToAdjacentMatrixToolStripMenuItem");
            this.saveToAdjacentMatrixToolStripMenuItem.Click += new System.EventHandler(this.saveToAdjacentMatrixToolStripMenuItem_Click);
            // 
            // saveToEdgeListToolStripMenuItem
            // 
            this.saveToEdgeListToolStripMenuItem.Name = "saveToEdgeListToolStripMenuItem";
            resources.ApplyResources(this.saveToEdgeListToolStripMenuItem, "saveToEdgeListToolStripMenuItem");
            this.saveToEdgeListToolStripMenuItem.Click += new System.EventHandler(this.saveToEdgeListToolStripMenuItem_Click);
            // 
            // fileAcitonsMenuStrip
            // 
            this.fileAcitonsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            resources.ApplyResources(this.fileAcitonsMenuStrip, "fileAcitonsMenuStrip");
            this.fileAcitonsMenuStrip.Name = "fileAcitonsMenuStrip";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "*.txt";
            this.saveFileDialog.FileName = "graph";
            resources.ApplyResources(this.saveFileDialog, "saveFileDialog");
            // 
            // edgesCountLabel
            // 
            resources.ApplyResources(this.edgesCountLabel, "edgesCountLabel");
            this.edgesCountLabel.Name = "edgesCountLabel";
            // 
            // getWeightButton
            // 
            resources.ApplyResources(this.getWeightButton, "getWeightButton");
            this.getWeightButton.Name = "getWeightButton";
            this.getWeightButton.UseVisualStyleBackColor = true;
            this.getWeightButton.Click += new System.EventHandler(this.getWeightButton_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.getWeightButton);
            this.Controls.Add(this.edgesCountLabel);
            this.Controls.Add(this.removeVertexButton);
            this.Controls.Add(this.verticesAdjacentButton);
            this.Controls.Add(this.weightTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.removeEdgeButton);
            this.Controls.Add(this.addEdgeButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.firstVertexNumberLabel);
            this.Controls.Add(this.firstVertexNumber);
            this.Controls.Add(this.secondVertexNumber);
            this.Controls.Add(this.removableVertexLabel);
            this.Controls.Add(this.removableVertexTextBox);
            this.Controls.Add(this.vertexCountLabel);
            this.Controls.Add(this.addVertexButton);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.fileAcitonsMenuStrip);
            this.MainMenuStrip = this.fileAcitonsMenuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.fileAcitonsMenuStrip.ResumeLayout(false);
            this.fileAcitonsMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button addVertexButton;
        private System.Windows.Forms.Label vertexCountLabel;
        private System.Windows.Forms.TextBox removableVertexTextBox;
        private System.Windows.Forms.Label removableVertexLabel;
        private System.Windows.Forms.Button removeVertexButton;
        private System.Windows.Forms.TextBox secondVertexNumber;
        private System.Windows.Forms.TextBox firstVertexNumber;
        private System.Windows.Forms.Label firstVertexNumberLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addEdgeButton;
        private System.Windows.Forms.Button removeEdgeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox weightTextBox;
        private System.Windows.Forms.Button verticesAdjacentButton;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromAdjacentMatrixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromEdgeListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToAdjacentMatrixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToEdgeListToolStripMenuItem;
        private System.Windows.Forms.MenuStrip fileAcitonsMenuStrip;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label edgesCountLabel;
        private System.Windows.Forms.Button getWeightButton;
    }
}