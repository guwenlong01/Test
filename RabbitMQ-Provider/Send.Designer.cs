
namespace RabbitMQ_Provider
{
    partial class Send
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
            this.btnFS = new System.Windows.Forms.Button();
            this.btnFanout = new System.Windows.Forms.Button();
            this.btndirect = new System.Windows.Forms.Button();
            this.btnTopic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFS
            // 
            this.btnFS.Location = new System.Drawing.Point(52, 80);
            this.btnFS.Name = "btnFS";
            this.btnFS.Size = new System.Drawing.Size(283, 126);
            this.btnFS.TabIndex = 0;
            this.btnFS.Text = "普通模式";
            this.btnFS.UseVisualStyleBackColor = true;
            this.btnFS.Click += new System.EventHandler(this.btnFS_Click);
            // 
            // btnFanout
            // 
            this.btnFanout.Location = new System.Drawing.Point(52, 201);
            this.btnFanout.Name = "btnFanout";
            this.btnFanout.Size = new System.Drawing.Size(283, 120);
            this.btnFanout.TabIndex = 2;
            this.btnFanout.Text = "扇形模式";
            this.btnFanout.UseVisualStyleBackColor = true;
            this.btnFanout.Click += new System.EventHandler(this.btnFanout_Click);
            // 
            // btndirect
            // 
            this.btndirect.Location = new System.Drawing.Point(52, 317);
            this.btndirect.Name = "btndirect";
            this.btndirect.Size = new System.Drawing.Size(283, 120);
            this.btndirect.TabIndex = 3;
            this.btndirect.Text = "完全匹配模式";
            this.btndirect.UseVisualStyleBackColor = true;
            this.btndirect.Click += new System.EventHandler(this.btndirect_Click);
            // 
            // btnTopic
            // 
            this.btnTopic.Location = new System.Drawing.Point(52, 430);
            this.btnTopic.Name = "btnTopic";
            this.btnTopic.Size = new System.Drawing.Size(283, 120);
            this.btnTopic.TabIndex = 4;
            this.btnTopic.Text = "模糊匹配模式";
            this.btnTopic.UseVisualStyleBackColor = true;
            this.btnTopic.Click += new System.EventHandler(this.btnTopic_Click);
            // 
            // Send
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 863);
            this.Controls.Add(this.btnTopic);
            this.Controls.Add(this.btndirect);
            this.Controls.Add(this.btnFanout);
            this.Controls.Add(this.btnFS);
            this.Name = "Send";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFS;
        private System.Windows.Forms.Button btnFanout;
        private System.Windows.Forms.Button btndirect;
        private System.Windows.Forms.Button btnTopic;
    }
}

