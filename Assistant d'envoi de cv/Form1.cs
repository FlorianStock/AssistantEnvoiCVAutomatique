using System;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;

namespace Assistant_d_envoi_de_cv
{
    public class mailTo : Form
    {
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private TextBox adresseto;
        private Button button1;
        private OpenFileDialog openFileDialog1;
        private Button buttonParam;

        public mailTo()
        {
            TheSetupXMLFile.getInstance().readXML();

            InitializeComponent();

            this.Text = "Assistant d'envoi de CV";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = true;

            //Ajout des profils dans la comboBox 
            for (var i = 0; i < TheSetupXMLFile.getInstance().profils.Count; i++)
            {
                comboBox1.Items.Add(TheSetupXMLFile.getInstance().profils[i].profilName);
            }

            if (comboBox1.Items.Count > 0) { comboBox1.SelectedIndex = TheSetupXMLFile.getInstance().selectionProfil; }
            
           
        }

        private void showParam(object sender, EventArgs e)
        {
            ParamsForm formParam = new ParamsForm();           
            formParam.Text = "Paramètres";
            formParam.FormBorderStyle = FormBorderStyle.FixedDialog;
            formParam.MaximizeBox = false;
            formParam.MinimizeBox = false;

            formParam.ShowDialog();
        }

        private void InitializeComponent()
        {
            this.buttonParam = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.adresseto = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // buttonParam
            // 
            this.buttonParam.Location = new System.Drawing.Point(196, 12);
            this.buttonParam.Name = "buttonParam";
            this.buttonParam.Size = new System.Drawing.Size(76, 23);
            this.buttonParam.TabIndex = 0;
            this.buttonParam.Text = "Paramètres";
            this.buttonParam.UseVisualStyleBackColor = true;
            this.buttonParam.Click += new System.EventHandler(this.showParam);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(68, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Profil :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "E-mail de l\'entreprise :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // adresseto
            // 
            this.adresseto.Location = new System.Drawing.Point(127, 50);
            this.adresseto.Name = "adresseto";
            this.adresseto.Size = new System.Drawing.Size(145, 20);
            this.adresseto.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Postuler";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // mailTo
            // 
            this.ClientSize = new System.Drawing.Size(284, 124);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.adresseto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonParam);
            this.Name = "mailTo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            for (var i = 0; i < TheSetupXMLFile.getInstance().profils.Count; i++)
            {
                comboBox1.Items.Add(TheSetupXMLFile.getInstance().profils[i].profilName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(TheSetupXMLFile.getInstance().smtp);


                Attachment attachment;

                for (int a=0; a< TheSetupXMLFile.getInstance().profils[TheSetupXMLFile.getInstance().selectionProfil].filesPath.Count;a++)
                {
                    attachment = new Attachment(TheSetupXMLFile.getInstance().profils[TheSetupXMLFile.getInstance().selectionProfil].filesPath[a]);
                    mail.Attachments.Add(attachment);
                }
              

                mail.From = new MailAddress(TheSetupXMLFile.getInstance().mailUser);
                mail.To.Add(adresseto.Text);

                mail.Subject = TheSetupXMLFile.getInstance().profils[TheSetupXMLFile.getInstance().selectionProfil].subject;
                mail.Body = TheSetupXMLFile.getInstance().profils[TheSetupXMLFile.getInstance().selectionProfil].mailContent;

                SmtpServer.Port = int.Parse(TheSetupXMLFile.getInstance().port);
                SmtpServer.Credentials = new System.Net.NetworkCredential(TheSetupXMLFile.getInstance().userName, TheSetupXMLFile.getInstance().userPwd);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Votre email a bien été envoyé !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}