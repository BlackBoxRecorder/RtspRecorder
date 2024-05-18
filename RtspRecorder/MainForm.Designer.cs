namespace RtspRecorder
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.TextAddr = new System.Windows.Forms.TextBox();
            this.BtnPlay = new System.Windows.Forms.Button();
            this.BtnStopPlay = new System.Windows.Forms.Button();
            this.BtnRecord = new System.Windows.Forms.Button();
            this.LabelRecordTime = new System.Windows.Forms.Label();
            this.LabelVideoFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "视频源";
            // 
            // TextAddr
            // 
            this.TextAddr.Location = new System.Drawing.Point(84, 20);
            this.TextAddr.Name = "TextAddr";
            this.TextAddr.Size = new System.Drawing.Size(267, 21);
            this.TextAddr.TabIndex = 1;
            // 
            // BtnPlay
            // 
            this.BtnPlay.Location = new System.Drawing.Point(39, 57);
            this.BtnPlay.Name = "BtnPlay";
            this.BtnPlay.Size = new System.Drawing.Size(75, 23);
            this.BtnPlay.TabIndex = 2;
            this.BtnPlay.Text = "播放";
            this.BtnPlay.UseVisualStyleBackColor = true;
            this.BtnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // BtnStopPlay
            // 
            this.BtnStopPlay.Location = new System.Drawing.Point(159, 57);
            this.BtnStopPlay.Name = "BtnStopPlay";
            this.BtnStopPlay.Size = new System.Drawing.Size(75, 23);
            this.BtnStopPlay.TabIndex = 2;
            this.BtnStopPlay.Text = "停止";
            this.BtnStopPlay.UseVisualStyleBackColor = true;
            this.BtnStopPlay.Click += new System.EventHandler(this.BtnStopPlay_Click);
            // 
            // BtnRecord
            // 
            this.BtnRecord.Location = new System.Drawing.Point(276, 57);
            this.BtnRecord.Name = "BtnRecord";
            this.BtnRecord.Size = new System.Drawing.Size(75, 23);
            this.BtnRecord.TabIndex = 2;
            this.BtnRecord.Text = "录制";
            this.BtnRecord.UseVisualStyleBackColor = true;
            this.BtnRecord.Click += new System.EventHandler(this.BtnRecord_Click);
            // 
            // LabelRecordTime
            // 
            this.LabelRecordTime.AutoSize = true;
            this.LabelRecordTime.Location = new System.Drawing.Point(37, 100);
            this.LabelRecordTime.Name = "LabelRecordTime";
            this.LabelRecordTime.Size = new System.Drawing.Size(29, 12);
            this.LabelRecordTime.TabIndex = 3;
            this.LabelRecordTime.Text = "录制";
            // 
            // LabelVideoFile
            // 
            this.LabelVideoFile.AutoSize = true;
            this.LabelVideoFile.Location = new System.Drawing.Point(193, 100);
            this.LabelVideoFile.Name = "LabelVideoFile";
            this.LabelVideoFile.Size = new System.Drawing.Size(29, 12);
            this.LabelVideoFile.TabIndex = 3;
            this.LabelVideoFile.Text = "文件";
            this.LabelVideoFile.Click += new System.EventHandler(this.LabelVideoFile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 136);
            this.Controls.Add(this.LabelVideoFile);
            this.Controls.Add(this.LabelRecordTime);
            this.Controls.Add(this.BtnRecord);
            this.Controls.Add(this.BtnStopPlay);
            this.Controls.Add(this.BtnPlay);
            this.Controls.Add(this.TextAddr);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RtspRecorder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextAddr;
        private System.Windows.Forms.Button BtnPlay;
        private System.Windows.Forms.Button BtnStopPlay;
        private System.Windows.Forms.Button BtnRecord;
        private System.Windows.Forms.Label LabelRecordTime;
        private System.Windows.Forms.Label LabelVideoFile;
    }
}

