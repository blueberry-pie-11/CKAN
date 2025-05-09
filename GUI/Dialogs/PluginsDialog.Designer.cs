namespace CKAN.GUI
{
    partial class PluginsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new SingleAssemblyComponentResourceManager(typeof(PluginsDialog));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ActivePluginsListBox = new System.Windows.Forms.ListBox();
            this.DeactivateButton = new System.Windows.Forms.Button();
            this.ReloadPluginButton = new System.Windows.Forms.Button();
            this.DormantPluginsListBox = new System.Windows.Forms.ListBox();
            this.ActivatePluginButton = new System.Windows.Forms.Button();
            this.AddNewPluginButton = new System.Windows.Forms.Button();
            this.UnloadPluginButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            //
            // groupBox1
            //
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.AddNewPluginButton);
            this.groupBox1.Controls.Add(this.ReloadPluginButton);
            this.groupBox1.Controls.Add(this.DeactivateButton);
            this.groupBox1.Controls.Add(this.ActivePluginsListBox);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 173);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            //
            // groupBox2
            //
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.UnloadPluginButton);
            this.groupBox2.Controls.Add(this.ActivatePluginButton);
            this.groupBox2.Controls.Add(this.DormantPluginsListBox);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(12, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 167);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            //
            // ActivePluginsListBox
            //
            this.ActivePluginsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ActivePluginsListBox.FormattingEnabled = true;
            this.ActivePluginsListBox.Location = new System.Drawing.Point(6, 17);
            this.ActivePluginsListBox.Name = "ActivePluginsListBox";
            this.ActivePluginsListBox.Size = new System.Drawing.Size(219, 147);
            this.ActivePluginsListBox.TabIndex = 0;
            this.ActivePluginsListBox.SelectedIndexChanged += new System.EventHandler(this.ActivePluginsListBox_SelectedIndexChanged);
            //
            // DeactivateButton
            //
            this.DeactivateButton.AutoSize = true;
            this.DeactivateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.DeactivateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeactivateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeactivateButton.Enabled = false;
            this.DeactivateButton.Location = new System.Drawing.Point(231, 17);
            this.DeactivateButton.Name = "DeactivateButton";
            this.DeactivateButton.Size = new System.Drawing.Size(124, 23);
            this.DeactivateButton.TabIndex = 1;
            this.DeactivateButton.UseVisualStyleBackColor = true;
            this.DeactivateButton.Click += new System.EventHandler(this.DeactivateButton_Click);
            resources.ApplyResources(this.DeactivateButton, "DeactivateButton");
            //
            // ReloadPluginButton
            //
            this.ReloadPluginButton.AutoSize = true;
            this.ReloadPluginButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.ReloadPluginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReloadPluginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReloadPluginButton.Enabled = false;
            this.ReloadPluginButton.Location = new System.Drawing.Point(231, 46);
            this.ReloadPluginButton.Name = "ReloadPluginButton";
            this.ReloadPluginButton.Size = new System.Drawing.Size(124, 23);
            this.ReloadPluginButton.TabIndex = 2;
            this.ReloadPluginButton.UseVisualStyleBackColor = true;
            this.ReloadPluginButton.Click += new System.EventHandler(this.ReloadPluginButton_Click);
            resources.ApplyResources(this.ReloadPluginButton, "ReloadPluginButton");
            //
            // DormantPluginsListBox
            //
            this.DormantPluginsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DormantPluginsListBox.FormattingEnabled = true;
            this.DormantPluginsListBox.Location = new System.Drawing.Point(6, 19);
            this.DormantPluginsListBox.Name = "DormantPluginsListBox";
            this.DormantPluginsListBox.Size = new System.Drawing.Size(219, 134);
            this.DormantPluginsListBox.TabIndex = 3;
            this.DormantPluginsListBox.SelectedIndexChanged += new System.EventHandler(this.DormantPluginsListBox_SelectedIndexChanged);
            //
            // ActivatePluginButton
            //
            this.ActivatePluginButton.AutoSize = true;
            this.ActivatePluginButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.ActivatePluginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ActivatePluginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ActivatePluginButton.Enabled = false;
            this.ActivatePluginButton.Location = new System.Drawing.Point(231, 19);
            this.ActivatePluginButton.Name = "ActivatePluginButton";
            this.ActivatePluginButton.Size = new System.Drawing.Size(124, 23);
            this.ActivatePluginButton.TabIndex = 3;
            this.ActivatePluginButton.UseVisualStyleBackColor = true;
            this.ActivatePluginButton.Click += new System.EventHandler(this.ActivatePluginButton_Click);
            resources.ApplyResources(this.ActivatePluginButton, "ActivatePluginButton");
            //
            // AddNewPluginButton
            //
            this.AddNewPluginButton.AutoSize = true;
            this.AddNewPluginButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.AddNewPluginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddNewPluginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddNewPluginButton.Location = new System.Drawing.Point(231, 75);
            this.AddNewPluginButton.Name = "AddNewPluginButton";
            this.AddNewPluginButton.Size = new System.Drawing.Size(124, 23);
            this.AddNewPluginButton.TabIndex = 3;
            this.AddNewPluginButton.UseVisualStyleBackColor = true;
            this.AddNewPluginButton.Click += new System.EventHandler(this.AddNewPluginButton_Click);
            resources.ApplyResources(this.AddNewPluginButton, "AddNewPluginButton");
            //
            // UnloadPluginButton
            //
            this.UnloadPluginButton.AutoSize = true;
            this.UnloadPluginButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.UnloadPluginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UnloadPluginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UnloadPluginButton.Enabled = false;
            this.UnloadPluginButton.Location = new System.Drawing.Point(231, 48);
            this.UnloadPluginButton.Name = "UnloadPluginButton";
            this.UnloadPluginButton.Size = new System.Drawing.Size(124, 23);
            this.UnloadPluginButton.TabIndex = 4;
            this.UnloadPluginButton.UseVisualStyleBackColor = true;
            this.UnloadPluginButton.Click += new System.EventHandler(this.UnloadPluginButton_Click);
            resources.ApplyResources(this.UnloadPluginButton, "UnloadPluginButton");
            //
            // PluginsDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 358);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = EmbeddedImages.AppIcon;
            this.Name = "PluginsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.PluginsDialog_Load);
            resources.ApplyResources(this, "$this");
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button AddNewPluginButton;
        private System.Windows.Forms.Button ReloadPluginButton;
        private System.Windows.Forms.Button DeactivateButton;
        private System.Windows.Forms.ListBox ActivePluginsListBox;
        private System.Windows.Forms.Button UnloadPluginButton;
        private System.Windows.Forms.Button ActivatePluginButton;
        private System.Windows.Forms.ListBox DormantPluginsListBox;
    }
}
