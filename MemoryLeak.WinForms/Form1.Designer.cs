namespace MemoryLeak.WinForms
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelShortLived = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.labelShortLivedEventSubscribers = new System.Windows.Forms.Label();
            this.buttonForceGC = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.labelShortLivedPublishers = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.labelShortLivedSubscribers = new System.Windows.Forms.Label();
            this.buttonShortLivedWeakSubscribers = new System.Windows.Forms.Button();
            this.labelShortLivedWeakSubscribers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Short-Lived Event Raisers";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnSubscribeToShortlivedObjects);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // labelShortLived
            // 
            this.labelShortLived.AutoSize = true;
            this.labelShortLived.Location = new System.Drawing.Point(219, 18);
            this.labelShortLived.Name = "labelShortLived";
            this.labelShortLived.Size = new System.Drawing.Size(39, 13);
            this.labelShortLived.TabIndex = 1;
            this.labelShortLived.Text = "{code}";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(194, 24);
            this.button2.TabIndex = 2;
            this.button2.Text = "Short-Lived Event Subscribers";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnShortlivedEventSubscribersClick);
            // 
            // labelShortLivedEventSubscribers
            // 
            this.labelShortLivedEventSubscribers.AutoSize = true;
            this.labelShortLivedEventSubscribers.Location = new System.Drawing.Point(219, 49);
            this.labelShortLivedEventSubscribers.Name = "labelShortLivedEventSubscribers";
            this.labelShortLivedEventSubscribers.Size = new System.Drawing.Size(39, 13);
            this.labelShortLivedEventSubscribers.TabIndex = 1;
            this.labelShortLivedEventSubscribers.Text = "{code}";
            // 
            // buttonForceGC
            // 
            this.buttonForceGC.Location = new System.Drawing.Point(13, 160);
            this.buttonForceGC.Name = "buttonForceGC";
            this.buttonForceGC.Size = new System.Drawing.Size(194, 23);
            this.buttonForceGC.TabIndex = 3;
            this.buttonForceGC.Text = "Force Garbage Collection";
            this.buttonForceGC.UseVisualStyleBackColor = true;
            this.buttonForceGC.Click += new System.EventHandler(this.OnForceGcClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 73);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(194, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Short-Lived publishers";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OnShortlivedEventPublishersClick);
            // 
            // labelShortLivedPublishers
            // 
            this.labelShortLivedPublishers.AutoSize = true;
            this.labelShortLivedPublishers.Location = new System.Drawing.Point(219, 78);
            this.labelShortLivedPublishers.Name = "labelShortLivedPublishers";
            this.labelShortLivedPublishers.Size = new System.Drawing.Size(39, 13);
            this.labelShortLivedPublishers.TabIndex = 1;
            this.labelShortLivedPublishers.Text = "{code}";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(13, 102);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(194, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "Short-Lived subscribers";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.OnShortLivedEventBusSubscribersClick);
            // 
            // labelShortLivedSubscribers
            // 
            this.labelShortLivedSubscribers.AutoSize = true;
            this.labelShortLivedSubscribers.Location = new System.Drawing.Point(219, 107);
            this.labelShortLivedSubscribers.Name = "labelShortLivedSubscribers";
            this.labelShortLivedSubscribers.Size = new System.Drawing.Size(39, 13);
            this.labelShortLivedSubscribers.TabIndex = 1;
            this.labelShortLivedSubscribers.Text = "{code}";
            // 
            // buttonShortLivedWeakSubscribers
            // 
            this.buttonShortLivedWeakSubscribers.Location = new System.Drawing.Point(13, 131);
            this.buttonShortLivedWeakSubscribers.Name = "buttonShortLivedWeakSubscribers";
            this.buttonShortLivedWeakSubscribers.Size = new System.Drawing.Size(194, 23);
            this.buttonShortLivedWeakSubscribers.TabIndex = 0;
            this.buttonShortLivedWeakSubscribers.Text = "Short-Lived weak subscribers";
            this.buttonShortLivedWeakSubscribers.UseVisualStyleBackColor = true;
            this.buttonShortLivedWeakSubscribers.Click += new System.EventHandler(this.OnShortLivedWeakSubscribersClick);
            // 
            // labelShortLivedWeakSubscribers
            // 
            this.labelShortLivedWeakSubscribers.AutoSize = true;
            this.labelShortLivedWeakSubscribers.Location = new System.Drawing.Point(219, 136);
            this.labelShortLivedWeakSubscribers.Name = "labelShortLivedWeakSubscribers";
            this.labelShortLivedWeakSubscribers.Size = new System.Drawing.Size(39, 13);
            this.labelShortLivedWeakSubscribers.TabIndex = 1;
            this.labelShortLivedWeakSubscribers.Text = "{code}";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 262);
            this.Controls.Add(this.buttonForceGC);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelShortLivedEventSubscribers);
            this.Controls.Add(this.labelShortLivedWeakSubscribers);
            this.Controls.Add(this.labelShortLivedSubscribers);
            this.Controls.Add(this.labelShortLivedPublishers);
            this.Controls.Add(this.labelShortLived);
            this.Controls.Add(this.buttonShortLivedWeakSubscribers);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelShortLived;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelShortLivedEventSubscribers;
        private System.Windows.Forms.Button buttonForceGC;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label labelShortLivedPublishers;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label labelShortLivedSubscribers;
        private System.Windows.Forms.Button buttonShortLivedWeakSubscribers;
        private System.Windows.Forms.Label labelShortLivedWeakSubscribers;
    }
}

