namespace WeatherApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtCity = new TextBox();
            btnGetWeather = new Button();
            lblTemp = new Label();
            lblDesc = new Label();
            picWeather = new PictureBox();
            chkFahrenheit = new CheckBox();
            lblHumidity = new Label();
            lblWindSpeed = new Label();
            lblFeelsLike = new Label();
            ((System.ComponentModel.ISupportInitialize)picWeather).BeginInit();
            SuspendLayout();
            // 
            // txtCity
            // 
            txtCity.Location = new Point(221, 41);
            txtCity.Name = "txtCity";
            txtCity.PlaceholderText = "Enter city name";
            txtCity.Size = new Size(125, 27);
            txtCity.TabIndex = 0;
            // 
            // btnGetWeather
            // 
            btnGetWeather.BackColor = SystemColors.ControlDark;
            btnGetWeather.FlatStyle = FlatStyle.Flat;
            btnGetWeather.ForeColor = SystemColors.ActiveCaptionText;
            btnGetWeather.Location = new Point(197, 87);
            btnGetWeather.Name = "btnGetWeather";
            btnGetWeather.Size = new Size(185, 29);
            btnGetWeather.TabIndex = 1;
            btnGetWeather.Text = "Get Weather";
            btnGetWeather.UseVisualStyleBackColor = false;
            btnGetWeather.Click += btnGetWeather_Click;
            // 
            // lblTemp
            // 
            lblTemp.AutoSize = true;
            lblTemp.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTemp.Location = new Point(251, 145);
            lblTemp.Name = "lblTemp";
            lblTemp.Size = new Size(0, 23);
            lblTemp.TabIndex = 2;
            // 
            // lblDesc
            // 
            lblDesc.AutoSize = true;
            lblDesc.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblDesc.Location = new Point(251, 204);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(0, 20);
            lblDesc.TabIndex = 3;
            // 
            // picWeather
            // 
            picWeather.Location = new Point(221, 270);
            picWeather.Name = "picWeather";
            picWeather.Size = new Size(125, 62);
            picWeather.TabIndex = 4;
            picWeather.TabStop = false;
            // 
            // chkFahrenheit
            // 
            chkFahrenheit.AutoSize = true;
            chkFahrenheit.Location = new Point(489, 92);
            chkFahrenheit.Name = "chkFahrenheit";
            chkFahrenheit.Size = new Size(186, 24);
            chkFahrenheit.TabIndex = 5;
            chkFahrenheit.Text = "Show temperature in °F";
            chkFahrenheit.UseVisualStyleBackColor = true;
            // 
            // lblHumidity
            // 
            lblHumidity.AutoSize = true;
            lblHumidity.Location = new Point(32, 261);
            lblHumidity.Name = "lblHumidity";
            lblHumidity.Size = new Size(0, 20);
            lblHumidity.TabIndex = 6;
            //lblHumidity.Click += label1_Click;
            // 
            // lblWindSpeed
            // 
            lblWindSpeed.AutoSize = true;
            lblWindSpeed.Location = new Point(13, 305);
            lblWindSpeed.Name = "lblWindSpeed";
            lblWindSpeed.Size = new Size(0, 20);
            lblWindSpeed.TabIndex = 7;
            // 
            // lblFeelsLike
            // 
            lblFeelsLike.AutoSize = true;
            lblFeelsLike.Location = new Point(19, 399);
            lblFeelsLike.Name = "lblFeelsLike";
            lblFeelsLike.Size = new Size(0, 20);
            lblFeelsLike.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(800, 450);
            Controls.Add(lblFeelsLike);
            Controls.Add(lblWindSpeed);
            Controls.Add(lblHumidity);
            Controls.Add(chkFahrenheit);
            Controls.Add(picWeather);
            Controls.Add(lblDesc);
            Controls.Add(lblTemp);
            Controls.Add(btnGetWeather);
            Controls.Add(txtCity);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picWeather).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCity;
        private Button btnGetWeather;
        private Label lblTemp;
        private Label lblDesc;
        private PictureBox picWeather;
        private CheckBox chkFahrenheit;
        private Label lblHumidity;
        private Label lblWindSpeed;
        private Label lblFeelsLike;
    }
}
