using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assistant_d_envoi_de_cv
{
    class ParamsForm : Form
    {
        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private CheckBox checkBox1;
        private GroupBox groupBox1;
        private TextBox textSMTP;
        private TextBox textUser;
        private Label label5;
        private Label label4;
        private TextBox textPort;
        private Label label3;
        private TextBox textBoxFiles;
        private TextBox textMpd;
        private GroupBox groupBox2;
        private TextBox textProfil;
        private GroupBox groupBox3;
        private Button buttonJoinFiles;
        private ListBox profilsList;
        private Button buttonAddProfil;
        private Button buttonDeleteProfil;
        private Button backButton;
        private Label label6;
        private TextBox textBoxMail;
        private LinkLabel linkLabel1;
        private TextBox subjectBox;
        private Label label7;
        private OpenFileDialog openFileDialog1;

        public ParamsForm()
        {

            TheSetupXMLFile.getInstance().readXML();
            InitializeComponent();

            textBox1.Text = TheSetupXMLFile.getInstance().mailUser;//ID
            textMpd.Text = TheSetupXMLFile.getInstance().userPwd;//MPD
            textSMTP.Text = TheSetupXMLFile.getInstance().smtp;//SMTP
            textUser.Text = TheSetupXMLFile.getInstance().userName;
            textPort.Text = TheSetupXMLFile.getInstance().port;
            //textBoxMail.Text = TheSetupXMLFile.getInstance().mailContent;
            
            for (var i=0;i< TheSetupXMLFile.getInstance().profils.Count;i++)
            {
                profilsList.Items.Add(TheSetupXMLFile.getInstance().profils[i].profilName);
            }
        }

        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textMpd = new System.Windows.Forms.TextBox();
            this.textUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textSMTP = new System.Windows.Forms.TextBox();
            this.textBoxFiles = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textProfil = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.subjectBox = new System.Windows.Forms.TextBox();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonJoinFiles = new System.Windows.Forms.Button();
            this.profilsList = new System.Windows.Forms.ListBox();
            this.buttonAddProfil = new System.Windows.Forms.Button();
            this.buttonDeleteProfil = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Joindre des fichiers au mail";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Joindre des fichiers au mail";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Pièces jointes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Adresse mail :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(84, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(185, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "SMTP :";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(104, 91);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textMpd);
            this.groupBox1.Controls.Add(this.textUser);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textPort);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textSMTP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 120);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mail d\'envoi";
            // 
            // textMpd
            // 
            this.textMpd.Location = new System.Drawing.Point(89, 94);
            this.textMpd.Name = "textMpd";
            this.textMpd.Size = new System.Drawing.Size(180, 20);
            this.textMpd.TabIndex = 10;
            this.textMpd.Text = "smtp.gmail.com";
            this.textMpd.UseSystemPasswordChar = true;
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(89, 71);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(180, 20);
            this.textUser.TabIndex = 9;
            this.textUser.Text = "smtp.gmail.com";
            this.textUser.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mot de passe :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Utilisateur :";
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(242, 39);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(27, 20);
            this.textPort.TabIndex = 6;
            this.textPort.Text = "587";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Port :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textSMTP
            // 
            this.textSMTP.Location = new System.Drawing.Point(55, 39);
            this.textSMTP.Name = "textSMTP";
            this.textSMTP.Size = new System.Drawing.Size(143, 20);
            this.textSMTP.TabIndex = 4;
            this.textSMTP.Text = "smtp.gmail.com";
            // 
            // textBoxFiles
            // 
            this.textBoxFiles.Enabled = false;
            this.textBoxFiles.Location = new System.Drawing.Point(122, 19);
            this.textBoxFiles.Name = "textBoxFiles";
            this.textBoxFiles.Size = new System.Drawing.Size(132, 20);
            this.textBoxFiles.TabIndex = 10;
            this.textBoxFiles.Text = "Aucune choisie";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textProfil);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.profilsList);
            this.groupBox2.Controls.Add(this.buttonAddProfil);
            this.groupBox2.Controls.Add(this.buttonDeleteProfil);
            this.groupBox2.Location = new System.Drawing.Point(3, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 350);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Profils";
            // 
            // textProfil
            // 
            this.textProfil.Location = new System.Drawing.Point(159, 19);
            this.textProfil.Name = "textProfil";
            this.textProfil.Size = new System.Drawing.Size(110, 20);
            this.textProfil.TabIndex = 11;
            this.textProfil.Text = "nouveau profil";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.subjectBox);
            this.groupBox3.Controls.Add(this.textBoxMail);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.buttonJoinFiles);
            this.groupBox3.Controls.Add(this.textBoxFiles);
            this.groupBox3.Location = new System.Drawing.Point(9, 107);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 235);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Profil";
            // 
            // subjectBox
            // 
            this.subjectBox.Enabled = false;
            this.subjectBox.Location = new System.Drawing.Point(49, 48);
            this.subjectBox.Name = "subjectBox";
            this.subjectBox.Size = new System.Drawing.Size(205, 20);
            this.subjectBox.TabIndex = 11;
            this.subjectBox.Text = "Candidature";
            this.subjectBox.TextChanged += new System.EventHandler(this.subjectBox_TextChanged);
            // 
            // textBoxMail
            // 
            this.textBoxMail.Enabled = false;
            this.textBoxMail.Location = new System.Drawing.Point(6, 87);
            this.textBoxMail.Multiline = true;
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(248, 142);
            this.textBoxMail.TabIndex = 16;
            this.textBoxMail.Text = "Bonjour, \r\n\r\nVeuillez trouver ci joint mon curriculum vitae ainsi que ma lettre d" +
    "e motivation pour le poste de technicien en informatique.\r\n\r\nCordialement,\r\nFlor" +
    "ian Stock.\r\n\r\n\r\n\r\n\r\n";
            this.textBoxMail.TextChanged += new System.EventHandler(this.textChangedMail);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Sujet :";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Message du mail :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // buttonJoinFiles
            // 
            this.buttonJoinFiles.Enabled = false;
            this.buttonJoinFiles.Location = new System.Drawing.Point(6, 19);
            this.buttonJoinFiles.Name = "buttonJoinFiles";
            this.buttonJoinFiles.Size = new System.Drawing.Size(110, 23);
            this.buttonJoinFiles.TabIndex = 15;
            this.buttonJoinFiles.Text = "Pièces jointes";
            this.buttonJoinFiles.UseVisualStyleBackColor = true;
            this.buttonJoinFiles.Click += new System.EventHandler(this.buttonJoinFiles_Click);
            // 
            // profilsList
            // 
            this.profilsList.FormattingEnabled = true;
            this.profilsList.Location = new System.Drawing.Point(6, 19);
            this.profilsList.Name = "profilsList";
            this.profilsList.Size = new System.Drawing.Size(147, 82);
            this.profilsList.TabIndex = 13;
            this.profilsList.SelectedIndexChanged += new System.EventHandler(this.profilSelected);
            // 
            // buttonAddProfil
            // 
            this.buttonAddProfil.Location = new System.Drawing.Point(159, 48);
            this.buttonAddProfil.Name = "buttonAddProfil";
            this.buttonAddProfil.Size = new System.Drawing.Size(110, 23);
            this.buttonAddProfil.TabIndex = 12;
            this.buttonAddProfil.Text = "Ajouter";
            this.buttonAddProfil.UseVisualStyleBackColor = true;
            this.buttonAddProfil.Click += new System.EventHandler(this.addProfile);
            // 
            // buttonDeleteProfil
            // 
            this.buttonDeleteProfil.Enabled = false;
            this.buttonDeleteProfil.Location = new System.Drawing.Point(159, 78);
            this.buttonDeleteProfil.Name = "buttonDeleteProfil";
            this.buttonDeleteProfil.Size = new System.Drawing.Size(110, 23);
            this.buttonDeleteProfil.TabIndex = 11;
            this.buttonDeleteProfil.Text = "Supprimer ";
            this.buttonDeleteProfil.UseVisualStyleBackColor = true;
            this.buttonDeleteProfil.Click += new System.EventHandler(this.removeProfile);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(179, 486);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(93, 23);
            this.backButton.TabIndex = 14;
            this.backButton.Text = "Enregistrer";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.closeWindow);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Silver;
            this.linkLabel1.Location = new System.Drawing.Point(6, 491);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(69, 13);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Florian Stock";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ParamsForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 513);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ParamsForm";
            this.ShowIcon = false;
            this.Text = "Paramètres";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void closeWindow(object sender, EventArgs e)
        {
            TheSetupXMLFile.getInstance().mailUser = textBox1.Text;
            TheSetupXMLFile.getInstance().port = textPort.Text;
            TheSetupXMLFile.getInstance().smtp = textSMTP.Text;
            TheSetupXMLFile.getInstance().userName = textUser.Text;
            TheSetupXMLFile.getInstance().userPwd = textMpd.Text;
            //TheSetupXMLFile.getInstance().mailContent = textBoxMail.Text;
            TheSetupXMLFile.getInstance().saveXML();

            profilsList.Items.Clear();
            this.Close();

        }
        private void addProfile(object sender, EventArgs e)
        {
            bool dejaAdd = false;

            for(int a=0;a< profilsList.Items.Count;a++)
            {
                if(profilsList.Items[a].Equals(textProfil.Text))
                {

                    
                    dejaAdd = true;
                    break;
                }
            }

            if (dejaAdd == false)
            {
                profilsList.Items.Add(textProfil.Text);
                Profile profil = new Profile();
                profil.profilName = textProfil.Text;
                TheSetupXMLFile.getInstance().profils.Add(profil);
            }
        }
        private void removeProfile(object sender, EventArgs e)
        {
            if (profilsList.SelectedIndex != -1)
            {
                TheSetupXMLFile.getInstance().profils[profilsList.SelectedIndex].live = false;
                //TheSetupXMLFile.getInstance().profils.RemoveAt(profilsList.SelectedIndex);
                profilsList.Items.RemoveAt(profilsList.SelectedIndex);
               
            }

            if (profilsList.Items.Count == 0)
            {
                buttonJoinFiles.Enabled = false;
                textBoxMail.Enabled = false;
                subjectBox.Enabled = false;
            }

        }

        private void profilSelected(object sender, EventArgs e)
        {
            if (profilsList.SelectedIndex != -1)
            {
                buttonDeleteProfil.Enabled = true;
                buttonJoinFiles.Enabled = true;
                textBoxMail.Enabled = true;
                subjectBox.Enabled = true;

                textBoxMail.Text = TheSetupXMLFile.getInstance().profils[profilsList.SelectedIndex].mailContent;
                subjectBox.Text = TheSetupXMLFile.getInstance().profils[profilsList.SelectedIndex].subject;

                if (TheSetupXMLFile.getInstance().profils[profilsList.SelectedIndex].filesPath.Count != 0)
                {
                    textBoxFiles.Text = TheSetupXMLFile.getInstance().profils[profilsList.SelectedIndex].filesPath[0];
                }
                else
                {
                    textBoxFiles.Text = "Aucun fichiers";
                }
            }
            else
            {
                buttonJoinFiles.Enabled = false;
                textBoxMail.Enabled = false;
                subjectBox.Enabled = false;
            }
        }

        private void buttonJoinFiles_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBoxFiles.Text = openFileDialog1.FileName;


        }

        private void textChangedMail(object sender, EventArgs e)
        {
            TheSetupXMLFile.getInstance().profils[profilsList.SelectedIndex].mailContent = textBoxMail.Text;


            TheSetupXMLFile.getInstance().profils[profilsList.SelectedIndex].mailContent = textBoxMail.Text;
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TheSetupXMLFile.getInstance().profils[profilsList.SelectedIndex].filesPath.Clear();

            foreach (String name in openFileDialog1.FileNames)
            {
                TheSetupXMLFile.getInstance().profils[profilsList.SelectedIndex].filesPath.Add(name);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void subjectBox_TextChanged(object sender, EventArgs e)
        {
            TheSetupXMLFile.getInstance().profils[profilsList.SelectedIndex].subject = subjectBox.Text;
        }
    }
}
