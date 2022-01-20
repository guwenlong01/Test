
namespace RabbitMQ_Consumer
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnXF = new System.Windows.Forms.Button();
            this.btnFanout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnXF
            // 
            this.btnXF.Location = new System.Drawing.Point(67, 85);
            this.btnXF.Name = "btnXF";
            this.btnXF.Size = new System.Drawing.Size(283, 113);
            this.btnXF.TabIndex = 0;
            this.btnXF.Text = "一般消费";
            this.btnXF.UseVisualStyleBackColor = true;
            this.btnXF.Click += new System.EventHandler(this.btnXF_Click);
            // 
            // btnFanout
            // 
            this.btnFanout.Location = new System.Drawing.Point(67, 253);
            this.btnFanout.Name = "btnFanout";
            this.btnFanout.Size = new System.Drawing.Size(283, 113);
            this.btnFanout.TabIndex = 1;
            this.btnFanout.Text = "扇形消费";
            this.btnFanout.UseVisualStyleBackColor = true;
            this.btnFanout.Click += new System.EventHandler(this.btnFanout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 930);
            this.Controls.Add(this.btnFanout);
            this.Controls.Add(this.btnXF);
            this.Name = "Form1";
            this.Text = "消费MQ消息";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnXF;
        private System.Windows.Forms.Button btnFanout;
    }
}

