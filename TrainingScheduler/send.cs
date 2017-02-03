using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Mail;

namespace TrainingScheduler
{
    public partial class send : Form
    {
        private SmtpClient SmtpServer;
        private string password = "";
        private string email = "";
        private string messageBody = "";
        private string subjectBody = "";
        private bool autoFeePolicy;
        private bool cdlFeePolicy;
        private bool confirmation;
        private bool skillsTestGuide;
        private bool memoryAid;
        private bool lotDirections;

        public send()
        {
            InitializeComponent();
        }

        private void setFalse()
        {
            autoFeePolicy = false;
            cdlFeePolicy = false;
            confirmation = false;
            skillsTestGuide = false;
            memoryAid = false;
            lotDirections = false;
        }

        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                //send auto info only
                subjectBody = "Auto Fee Policy, Skills Test Study Guide";
                messageBody = File.ReadAllText("autoinfo.txt");
                messageTextBox.Text = messageBody;
                subjectTextBox.Text = subjectBody;
                setFalse();
                autoFeePolicy = true;
                skillsTestGuide = true;
            }
            else
            {
                //cdl info only
                subjectBody = "CDL Fee Policy, Memory Aid, Directions to Lot";
                messageBody = File.ReadAllText("cdlinfo.txt");
                messageTextBox.Text = messageBody;
                subjectTextBox.Text = subjectBody;
                setFalse();
                cdlFeePolicy = true;
                memoryAid = true;
                lotDirections = true;
            }
        }

        private void send_Load(object sender, EventArgs e)
        {
            setFalse();
            password = File.ReadAllText("p.txt");
            email = File.ReadAllText("e.txt");
            radioButton3.Checked = true;
            radioButton1.Checked = true;
            subjectBody = "CDL Fee Policy, Memory Aid, Directions to Lot";
            messageBody = File.ReadAllText("cdlinfo.txt");
            subjectTextBox.Text = subjectBody;
            messageTextBox.Text = messageBody;
            cdlFeePolicy = true;
            memoryAid = true;
            lotDirections = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            messageBody = messageTextBox.Text;
            subjectBody = subjectTextBox.Text;
            button3.Enabled = false;
            button3.Text = "Sending...";
            Application.DoEvents();

            if (validateEmail(textBox1.Text))
            {
                SmtpServer = new SmtpClient("smtp.live.com");
                var mail = new MailMessage();
                mail.From = new MailAddress(email);
                mail.To.Add(textBox1.Text);
                mail.Subject = "Test Mail - 1";
                mail.IsBodyHtml = false;
                mail.Body = messageBody;
                mail.Subject = subjectBody;
                if (confirmation)
                {
                    try
                    {
                        mail.Attachments.Add(new Attachment(@"./confirmations_pdf/" + Globals.first + Globals.last + ".pdf"));
                    }
                    catch
                    {
                        MessageBox.Show("Confirmation not created in main program! Could not send!");
                        this.Close();
                    }
                }
                if (skillsTestGuide)
                {
                    mail.Attachments.Add(new Attachment("autoskills.pdf"));
                }
                if (memoryAid)
                {
                    mail.Attachments.Add(new Attachment("memoryaid.pdf"));
                }
                if (lotDirections)
                {
                    mail.Attachments.Add(new Attachment("directions.pdf"));
                }
                if (autoFeePolicy)
                {
                    mail.Attachments.Add(new Attachment("autofee.pdf"));
                }
                if (cdlFeePolicy)
                {
                    mail.Attachments.Add(new Attachment("cdlfee.pdf"));
                }
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(email, password);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                this.Close();
            }
            else
            {
                //invalid email
                MessageBox.Show("Confirmation not created in main program! Could not send!");
                button3.Enabled = true;
            }
        }

        private void radioButton4_MouseClick(object sender, MouseEventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                //send auto info only
                subjectBody = "Auto Fee Policy, Skills Test Study Guide";
                messageBody = File.ReadAllText("autoinfo.txt");
                messageTextBox.Text = messageBody;
                subjectTextBox.Text = subjectBody;
                setFalse();
                autoFeePolicy = true;
                skillsTestGuide = true;
            }
            else
            {
                //send confirmation and info
                subjectBody = "Confirmation, Auto Fee Policy, Skills Test Study Guide";
                messageBody = File.ReadAllText("autoinfoconfirm.txt");
                messageTextBox.Text = messageBody;
                subjectTextBox.Text = subjectBody;
                setFalse();
                confirmation = true;
                autoFeePolicy = true;
                skillsTestGuide = true;
            }
        }

        private void radioButton3_MouseClick(object sender, MouseEventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                //cdl info only
                subjectBody = "CDL Fee Policy, Memory Aid, Directions to Lot";
                messageBody = File.ReadAllText("cdlinfo.txt");
                messageTextBox.Text = messageBody;
                subjectTextBox.Text = subjectBody;
                setFalse();
                cdlFeePolicy = true;
                memoryAid = true;
                lotDirections = true;
            }
            else
            {
                //send confirmation and info for auto
                subjectBody = "Confirmation, Auto Fee Policy, Skills Test Study Guide";
                messageBody = File.ReadAllText("autoinfoconfirm.txt");
                messageTextBox.Text = messageBody;
                subjectTextBox.Text = subjectBody;
                setFalse();
                confirmation = true;
                autoFeePolicy = true;
                skillsTestGuide = true;
            }
        }

        private void radioButton2_MouseClick(object sender, MouseEventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                //cdl info and confirm
                subjectBody = "Confirmation, CDL Fee Policy, Memory Aid, Directions to Lot";
                messageBody = File.ReadAllText("cdlinfoconfirm.txt");
                messageTextBox.Text = messageBody;
                subjectTextBox.Text = subjectBody;
                setFalse();
                confirmation = true;
                cdlFeePolicy = true;
                memoryAid = true;
                lotDirections = true;
            }
            else
            {
                //send confirmation and info for auto
                subjectBody = "Confirmation, Auto Fee Policy, Skills Test Study Guide";
                messageBody = File.ReadAllText("autoinfoconfirm.txt");
                messageTextBox.Text = messageBody;
                subjectTextBox.Text = subjectBody;
                setFalse();
                confirmation = true;
                autoFeePolicy = true;
                skillsTestGuide = true;
            }
        }

        private bool validateEmail(string text)
        {
            //provide validation checks for email here
            if (text != "")
            {
                return true;
            }
            return false;
        }
    }
}
