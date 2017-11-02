namespace neuralNet
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.start = new System.Windows.Forms.Button();
            this.numNeuron = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.TextBox();
            this.reset = new System.Windows.Forms.Button();
            this.error = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.xval = new System.Windows.Forms.TextBox();
            this.yval = new System.Windows.Forms.TextBox();
            this.hTrain = new System.Windows.Forms.HScrollBar();
            this.hNeurons = new System.Windows.Forms.HScrollBar();
            this.hNoise = new System.Windows.Forms.HScrollBar();
            this.hLearn = new System.Windows.Forms.HScrollBar();
            this.trainLabel = new System.Windows.Forms.Label();
            this.noiseLabel = new System.Windows.Forms.Label();
            this.tGoal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(547, 411);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 1;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // numNeuron
            // 
            this.numNeuron.Location = new System.Drawing.Point(643, 206);
            this.numNeuron.Name = "numNeuron";
            this.numNeuron.Size = new System.Drawing.Size(100, 20);
            this.numNeuron.TabIndex = 2;
            this.numNeuron.TextChanged += new System.EventHandler(this.numNeuron_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(538, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of Neurons";
            // 
            // tRate
            // 
            this.tRate.Location = new System.Drawing.Point(643, 332);
            this.tRate.Name = "tRate";
            this.tRate.Size = new System.Drawing.Size(100, 20);
            this.tRate.TabIndex = 4;
            this.tRate.TextChanged += new System.EventHandler(this.tRate_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(540, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Learn Rate (K)";
            // 
            // time
            // 
            this.time.Location = new System.Drawing.Point(643, 411);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(100, 20);
            this.time.TabIndex = 6;
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(547, 435);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 23);
            this.reset.TabIndex = 7;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // error
            // 
            this.error.Location = new System.Drawing.Point(541, 55);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(100, 20);
            this.error.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(541, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Error";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(544, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ticks";
            // 
            // xval
            // 
            this.xval.Location = new System.Drawing.Point(541, 94);
            this.xval.Name = "xval";
            this.xval.Size = new System.Drawing.Size(100, 20);
            this.xval.TabIndex = 11;
            // 
            // yval
            // 
            this.yval.Location = new System.Drawing.Point(643, 55);
            this.yval.Name = "yval";
            this.yval.Size = new System.Drawing.Size(100, 20);
            this.yval.TabIndex = 12;
            // 
            // hTrain
            // 
            this.hTrain.Location = new System.Drawing.Point(541, 176);
            this.hTrain.Maximum = 10000;
            this.hTrain.Minimum = 1;
            this.hTrain.Name = "hTrain";
            this.hTrain.Size = new System.Drawing.Size(207, 17);
            this.hTrain.TabIndex = 13;
            this.hTrain.Value = 1;
            this.hTrain.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hTrain_Scroll);
            // 
            // hNeurons
            // 
            this.hNeurons.Location = new System.Drawing.Point(541, 238);
            this.hNeurons.Minimum = 1;
            this.hNeurons.Name = "hNeurons";
            this.hNeurons.Size = new System.Drawing.Size(207, 17);
            this.hNeurons.TabIndex = 14;
            this.hNeurons.Value = 1;
            this.hNeurons.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hNeurons_Scroll);
            // 
            // hNoise
            // 
            this.hNoise.Location = new System.Drawing.Point(541, 297);
            this.hNoise.Name = "hNoise";
            this.hNoise.Size = new System.Drawing.Size(207, 17);
            this.hNoise.TabIndex = 15;
            this.hNoise.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hNoise_Scroll);
            // 
            // hLearn
            // 
            this.hLearn.Location = new System.Drawing.Point(541, 355);
            this.hLearn.Maximum = 1000;
            this.hLearn.Minimum = 1;
            this.hLearn.Name = "hLearn";
            this.hLearn.Size = new System.Drawing.Size(207, 17);
            this.hLearn.TabIndex = 16;
            this.hLearn.Value = 1;
            this.hLearn.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hLearn_Scroll);
            // 
            // trainLabel
            // 
            this.trainLabel.AutoSize = true;
            this.trainLabel.Location = new System.Drawing.Point(541, 143);
            this.trainLabel.Name = "trainLabel";
            this.trainLabel.Size = new System.Drawing.Size(53, 13);
            this.trainLabel.TabIndex = 17;
            this.trainLabel.Text = "Trainings:";
            // 
            // noiseLabel
            // 
            this.noiseLabel.AutoSize = true;
            this.noiseLabel.Location = new System.Drawing.Point(541, 281);
            this.noiseLabel.Name = "noiseLabel";
            this.noiseLabel.Size = new System.Drawing.Size(67, 13);
            this.noiseLabel.TabIndex = 18;
            this.noiseLabel.Text = "Initial Noise: ";
            // 
            // tGoal
            // 
            this.tGoal.Location = new System.Drawing.Point(648, 124);
            this.tGoal.Name = "tGoal";
            this.tGoal.Size = new System.Drawing.Size(100, 20);
            this.tGoal.TabIndex = 19;
            this.tGoal.TextChanged += new System.EventHandler(this.tGoal_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(559, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Enter Error Goal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(640, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Output[0]";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(627, 437);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 22;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(541, 480);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 17);
            this.checkBox1.TabIndex = 23;
            this.checkBox1.Text = "Use RPROP";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 517);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tGoal);
            this.Controls.Add(this.noiseLabel);
            this.Controls.Add(this.trainLabel);
            this.Controls.Add(this.hLearn);
            this.Controls.Add(this.hNoise);
            this.Controls.Add(this.hNeurons);
            this.Controls.Add(this.hTrain);
            this.Controls.Add(this.yval);
            this.Controls.Add(this.xval);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.error);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.time);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tRate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numNeuron);
            this.Controls.Add(this.start);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Luke Preslar";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.TextBox numNeuron;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox time;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.TextBox error;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox xval;
        private System.Windows.Forms.TextBox yval;
        private System.Windows.Forms.HScrollBar hTrain;
        private System.Windows.Forms.HScrollBar hNeurons;
        private System.Windows.Forms.HScrollBar hNoise;
        private System.Windows.Forms.HScrollBar hLearn;
        private System.Windows.Forms.Label trainLabel;
        private System.Windows.Forms.Label noiseLabel;
        private System.Windows.Forms.TextBox tGoal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

