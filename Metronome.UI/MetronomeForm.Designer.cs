
using System.Windows.Forms;

namespace Metronome.UI
{
    partial class MetronomeForm
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
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MetronomeForm));
            this.beatsSlider = new System.Windows.Forms.TrackBar();
            this.controlButton = new System.Windows.Forms.Button();
            this.beatsLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.beatsSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(77, 22);
            label2.Margin = new System.Windows.Forms.Padding(0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(134, 21);
            label2.TabIndex = 2;
            label2.Text = "beats per minutes";
            // 
            // beatsSlider
            // 
            this.beatsSlider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.beatsSlider.Location = new System.Drawing.Point(0, 66);
            this.beatsSlider.Maximum = 300;
            this.beatsSlider.Minimum = 40;
            this.beatsSlider.Name = "beatsSlider";
            this.beatsSlider.Size = new System.Drawing.Size(484, 45);
            this.beatsSlider.TabIndex = 0;
            this.beatsSlider.TickFrequency = 5;
            this.beatsSlider.Value = 60;
            // 
            // controlButton
            // 
            this.controlButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.controlButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.controlButton.Location = new System.Drawing.Point(397, 12);
            this.controlButton.Name = "controlButton";
            this.controlButton.Size = new System.Drawing.Size(75, 34);
            this.controlButton.TabIndex = 3;
            this.controlButton.Text = "Start";
            this.controlButton.UseVisualStyleBackColor = true;
            this.controlButton.Click += new System.EventHandler(this.OnControlButtonClicked);
            // 
            // beatsLabel
            // 
            this.beatsLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.beatsLabel.Location = new System.Drawing.Point(12, 9);
            this.beatsLabel.Margin = new System.Windows.Forms.Padding(0);
            this.beatsLabel.Name = "beatsLabel";
            this.beatsLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.beatsLabel.Size = new System.Drawing.Size(65, 38);
            this.beatsLabel.TabIndex = 4;
            this.beatsLabel.Text = "100";
            // 
            // MetronomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 111);
            this.Controls.Add(this.beatsLabel);
            this.Controls.Add(this.controlButton);
            this.Controls.Add(label2);
            this.Controls.Add(this.beatsSlider);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(340, 140);
            this.Name = "MetronomeForm";
            this.Text = "Metronome";
            ((System.ComponentModel.ISupportInitialize)(this.beatsSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar beatsSlider;
        private System.Windows.Forms.Button controlButton;
        private Label beatsLabel;
    }
}

