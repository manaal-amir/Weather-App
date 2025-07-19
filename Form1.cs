er﻿using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            btnGetWeather.Click += btnGetWeather_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(30, 30, 60);
            this.Font = new Font("Segoe UI", 10);

            Label lblTitle = new Label();
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Weather App";
            lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize = true;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblTitle);

            CenterControl(lblTitle, yOffset: 10);

            txtCity.Width = 250;
            CenterControl(txtCity, yOffset: 90);

            
            chkFahrenheit.AutoSize = true;
            chkFahrenheit.ForeColor = Color.White;
            chkFahrenheit.Location = new Point((this.ClientSize.Width - chkFahrenheit.Width) / 2, 130);

            btnGetWeather.Width = 300;
            btnGetWeather.Height = 40;
            btnGetWeather.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            btnGetWeather.BackColor = Color.FromArgb(0, 120, 215);
            btnGetWeather.ForeColor = Color.White;
            btnGetWeather.FlatStyle = FlatStyle.Standard;
            btnGetWeather.UseCompatibleTextRendering = true;
            btnGetWeather.TextAlign = ContentAlignment.MiddleCenter;
            btnGetWeather.Padding = new Padding(0);
            btnGetWeather.Cursor = Cursors.Hand;
            btnGetWeather.FlatAppearance.BorderSize = 0;
            btnGetWeather.MouseEnter += (s, ev) => btnGetWeather.BackColor = Color.FromArgb(0, 150, 255);
            btnGetWeather.MouseLeave += (s, ev) => btnGetWeather.BackColor = Color.FromArgb(0, 120, 215);
            CenterControl(btnGetWeather, yOffset: 160);


            //Weather labels
            SetupLabel(lblTemp, 16, FontStyle.Bold, Color.White, 200);
            SetupLabel(lblDesc, 14, FontStyle.Regular, Color.LightGray, 245);

            SetupLabel(lblHumidity, 14, FontStyle.Regular, Color.LightGray, 280);
            SetupLabel(lblWindSpeed, 14, FontStyle.Regular, Color.LightGray, 315);
            SetupLabel(lblFeelsLike, 14, FontStyle.Regular, Color.LightGray, 350);

            picWeather.SizeMode = PictureBoxSizeMode.Zoom;
            picWeather.Size = new Size(100, 100);
            CenterControl(picWeather, yOffset: 390);
        }

        private void SetupLabel(Label lbl, int fontSize, FontStyle style, Color color, int yOffset)
        {
            lbl.Font = new Font("Segoe UI", fontSize, style);
            lbl.ForeColor = color;
            lbl.AutoSize = false;
            lbl.Width = 3000;
            lbl.Height = 40;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            CenterControl(lbl, yOffset);
        }

        private void CenterControl(Control ctrl, int yOffset)
        {
            ctrl.Location = new Point((this.ClientSize.Width - ctrl.Width) / 2, yOffset);
        }

        private async void btnGetWeather_Click(object sender, EventArgs e)
        {
            string apiKey = "ENTER YOUR OWN API KEY";
            string city = txtCity.Text.Trim();

            if (string.IsNullOrEmpty(city))
            {
                MessageBox.Show("Please enter a city name.");
                return;
            }

            string units = chkFahrenheit.Checked ? "imperial" : "metric";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units={units}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    btnGetWeather.Enabled = false;

                    string response = await client.GetStringAsync(url);
                    var obj = JObject.Parse(response);

                    string cod = obj["cod"]?.ToString() ?? "";
                    if (cod != "200")
                    {
                        string message = obj["message"]?.ToString() ?? "Unknown error";
                        MessageBox.Show($"Error from API: {message}");
                        return;
                    }

                    var main = obj["main"];
                    var weatherArray = obj["weather"] as JArray;

                    if (main != null && weatherArray != null && weatherArray.Count > 0)
                    {
                        string temp = main["temp"]?.ToString() ?? "N/A";
                        string desc = weatherArray[0]["description"]?.ToString() ?? "N/A";
                        string icon = weatherArray[0]["icon"]?.ToString() ?? "";

                        string tempUnit = chkFahrenheit.Checked ? "°F" : "°C";
                        string windUnit = chkFahrenheit.Checked ? "mph" : "m/s";

                        lblTemp.Text = $"🌡 Temperature: {temp} {tempUnit}";
                        lblDesc.Text = $"🌤 Condition: {desc}";

                        string humidity = main["humidity"]?.ToString() ?? "N/A";
                        string windSpeed = obj["wind"]?["speed"]?.ToString() ?? "N/A";
                        string feelsLike = main["feels_like"]?.ToString() ?? "N/A";

                        lblHumidity.Text = $"💧 Humidity: {humidity} %";
                        lblWindSpeed.Text = $"🌬 Wind Speed: {windSpeed} {windUnit}";
                        lblFeelsLike.Text = $"🌡 Feels Like: {feelsLike} {tempUnit}";

                        if (!string.IsNullOrEmpty(icon))
                            picWeather.Load($"http://openweathermap.org/img/wn/{icon}.png");
                        else
                            picWeather.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("Could not retrieve weather data.");
                    }
                }
                catch (HttpRequestException httpEx)
                {
                    MessageBox.Show("Network error: " + httpEx.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected error: " + ex.Message);
                }
                finally
                {
                    btnGetWeather.Enabled = true;
                }
            }
        }
    }
}
