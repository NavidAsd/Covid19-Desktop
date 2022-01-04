using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.NetworkInformation;

namespace Covid19_data
{
    public partial class Frmsuport : Form
    {
        public Frmsuport()
        {
            InitializeComponent();
        }

        private void Frmsuport_Load(object sender, EventArgs e)
        {
            btndefultemail.ButtonText = "Defult Email";
            try
            {
                Ping png = new Ping();
                string hostname = "www.google.com"; int timeout = 1000;
                PingReply pingreply = png.Send(hostname, timeout);
                if (pingreply.Status == IPStatus.Success)
                {
                    timer1.Enabled = true;
                }
                else
                {
                    txtpassword.Visible = false;
                    checknetwork1.Visible = false;
                    txtmessage.Visible = false;
                    txtgmail.Visible = false;
                    btnmessage.Visible = false;
                    lblretry1.Visible = true;
                    btnretry.Visible = true;
                }
            }
            catch
            {
                txtpassword.Visible = false;
                checknetwork1.Visible = false;
                txtmessage.Visible = false;
                txtgmail.Visible = false;
                btnmessage.Visible = false;
                lblretry1.Visible = true;
                btnretry.Visible = true;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bunifuLabel1.Visible = true;
            txtpassword.Visible = true;
            checknetwork1.Visible = false;
            txtmessage.Visible = true;
            txtgmail.Visible = true;
            btnmessage.Visible = true;
            lblretry1.Visible = false;
            btnretry.Visible = false;
            timer1.Stop();
        }

        private void btnretry_Click(object sender, EventArgs e)
        {
            try
            {
                Ping png = new Ping();
                string hostname = "www.google.com"; int timeout = 1000;
                PingReply pingreply = png.Send(hostname, timeout);
                if (pingreply.Status == IPStatus.Success)
                {
                    timer1.Enabled = true;
                    timer1.Start();
                }
                else
                {
                    txtpassword.Visible = false;
                    checknetwork1.Visible = false;
                    txtmessage.Visible = false;
                    txtgmail.Visible = false;
                    btnmessage.Visible = false;
                    lblretry1.Visible = true;
                    btnretry.Visible = true;
                }
            }
            catch
            {
                txtpassword.Visible = false;
                checknetwork1.Visible = false;
                txtmessage.Visible = false;
                txtgmail.Visible = false;
                btnmessage.Visible = false;
                lblretry1.Visible = true;
                btnretry.Visible = true;
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnmessage_Click(object sender, EventArgs e)
        {
            int content = txtgmail.Text.IndexOf("@"), content2 = txtgmail.Text.IndexOf(".");
            if (!string.IsNullOrWhiteSpace(txtgmail.Text) && !string.IsNullOrWhiteSpace(txtpassword.Text) && txtgmail.TextLength >= 11 && content >= 0 && content2 >= 0 && txtpassword.TextLength >= 4)
            {
                picgmail.Visible = false;
                picpass.Visible = false;
                if (!string.IsNullOrWhiteSpace(txtmessage.Text))
                {
                    try
                    {
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                        //نام فرستنده
                        mail.From = new MailAddress(txtgmail.Text);
                        //آدرس گیرنده یا گیرندگان
                        mail.To.Add("navidasadi.r.80@gmail.com");
                        //عنوان ایمیل
                        mail.Subject = "Feed Back";
                        //بدنه ایمیل
                        mail.Body = txtmessage.Text;
                        //مشخص کرن پورت 
                        SmtpServer.Port = 587;
                        //username : 
                        //password : 
                        SmtpServer.Credentials = new System.Net.NetworkCredential(txtgmail.Text, txtpassword.Text);
                        SmtpServer.EnableSsl = true;

                        SmtpServer.Send(mail);
                        MessageBox.Show("Thank you feedback will help improve the program", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(Exception ex)
                    {
                        //MessageBox.Show("Problem sending Please check your email and network connection", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else if (content < 0 || content2 < 0 || txtgmail.TextLength < 11 || string.IsNullOrWhiteSpace(txtgmail.Text))
            {
                txtgmail.Clear();
                picgmail.Visible = true;
            }
            else if (string.IsNullOrWhiteSpace(txtpassword.Text) || txtpassword.TextLength <= 4)
            {
                txtpassword.Clear();
                picpass.Visible = true;
            }


        }

        private void btndefultemail_Click(object sender, EventArgs e)
        {
            txtpassword.Text = "covid19_data";
            txtgmail.Text = "coovid.data.19@gmail.com";
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
