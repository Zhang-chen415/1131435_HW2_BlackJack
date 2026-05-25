namespace _1131435_HW2_BlackJack
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.flpDealer = new System.Windows.Forms.FlowLayoutPanel();
            this.flpPlayer = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDealerScore = new System.Windows.Forms.Label();
            this.lblPlayerScore = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnHit = new System.Windows.Forms.Button();
            this.btnStand = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flpDealer
            // 
            this.flpDealer.BackColor = System.Drawing.Color.Green;
            this.flpDealer.Location = new System.Drawing.Point(0, -2);
            this.flpDealer.Name = "flpDealer";
            this.flpDealer.Size = new System.Drawing.Size(786, 129);
            this.flpDealer.TabIndex = 0;
            this.flpDealer.WrapContents = false;
            // 
            // flpPlayer
            // 
            this.flpPlayer.BackColor = System.Drawing.Color.Green;
            this.flpPlayer.Location = new System.Drawing.Point(0, 350);
            this.flpPlayer.Name = "flpPlayer";
            this.flpPlayer.Size = new System.Drawing.Size(786, 125);
            this.flpPlayer.TabIndex = 1;
            this.flpPlayer.WrapContents = false;
            // 
            // lblDealerScore
            // 
            this.lblDealerScore.AutoSize = true;
            this.lblDealerScore.Font = new System.Drawing.Font("新細明體", 14F);
            this.lblDealerScore.Location = new System.Drawing.Point(343, 130);
            this.lblDealerScore.Name = "lblDealerScore";
            this.lblDealerScore.Size = new System.Drawing.Size(90, 19);
            this.lblDealerScore.TabIndex = 2;
            this.lblDealerScore.Text = "莊家 : 0點";
            // 
            // lblPlayerScore
            // 
            this.lblPlayerScore.AutoSize = true;
            this.lblPlayerScore.Font = new System.Drawing.Font("新細明體", 14F);
            this.lblPlayerScore.Location = new System.Drawing.Point(343, 328);
            this.lblPlayerScore.Name = "lblPlayerScore";
            this.lblPlayerScore.Size = new System.Drawing.Size(90, 19);
            this.lblPlayerScore.TabIndex = 3;
            this.lblPlayerScore.Text = "玩家 : 0點";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("新細明體", 20F);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(203, 220);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 27);
            this.lblStatus.TabIndex = 4;
            // 
            // btnHit
            // 
            this.btnHit.Font = new System.Drawing.Font("新細明體", 14F);
            this.btnHit.Location = new System.Drawing.Point(208, 481);
            this.btnHit.Name = "btnHit";
            this.btnHit.Size = new System.Drawing.Size(75, 42);
            this.btnHit.TabIndex = 5;
            this.btnHit.Text = "要牌";
            this.btnHit.UseVisualStyleBackColor = true;
            this.btnHit.Click += new System.EventHandler(this.btnHit_Click);
            // 
            // btnStand
            // 
            this.btnStand.Font = new System.Drawing.Font("新細明體", 14F);
            this.btnStand.Location = new System.Drawing.Point(319, 481);
            this.btnStand.Name = "btnStand";
            this.btnStand.Size = new System.Drawing.Size(75, 42);
            this.btnStand.TabIndex = 6;
            this.btnStand.Text = "停牌";
            this.btnStand.UseVisualStyleBackColor = true;
            this.btnStand.Click += new System.EventHandler(this.btnStand_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Font = new System.Drawing.Font("新細明體", 14F);
            this.btnRestart.Location = new System.Drawing.Point(434, 481);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(95, 42);
            this.btnRestart.TabIndex = 7;
            this.btnRestart.Text = "重新開始";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnStand);
            this.Controls.Add(this.btnHit);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPlayerScore);
            this.Controls.Add(this.lblDealerScore);
            this.Controls.Add(this.flpPlayer);
            this.Controls.Add(this.flpDealer);
            this.Name = "Form1";
            this.Text = "21點 BlackJack";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // 補回遺失的變數宣告
        private System.Windows.Forms.FlowLayoutPanel flpDealer;
        private System.Windows.Forms.FlowLayoutPanel flpPlayer;
        private System.Windows.Forms.Label lblDealerScore;
        private System.Windows.Forms.Label lblPlayerScore;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnHit;
        private System.Windows.Forms.Button btnStand;
        private System.Windows.Forms.Button btnRestart;
    }
}