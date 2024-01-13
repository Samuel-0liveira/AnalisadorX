using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using System.IO;
using System.Reflection;
using System.Security.AccessControl;

namespace AnalisadorX
{
    public partial class Frm_ConfiguracaoBanco : Form
    {
        public Frm_ConfiguracaoBanco()
        {
            InitializeComponent();
        }

        private bool ValidarServer(string s)
        {
            bool okServer;

            if (!s.Equals(""))
            {
                lbl_A1.Visible = false;
                okServer = true;
            } else
            {
                lbl_A1.Visible = true;
                okServer = false;
            }

            return okServer;
        }

        private bool ValidarPort(string p)
        {
            bool okPort;

            if (!p.Equals(""))
            {
                lbl_A2.Visible = false;
                okPort = true;
            }
            else
            {
                lbl_A2.Visible = true;
                okPort = false;
            }

            return okPort;
        }

        private bool ValidarUser(string u)
        {
            bool okUser;

            if (!u.Equals(""))
            {
                lbl_A3.Visible = false;
                okUser = true;
            }
            else
            {
                lbl_A3.Visible = true;
                okUser = false;
            }

            return okUser;
        }

        private bool ValidarPassword(string p)
        {
            bool okPass;

            if (!p.Equals(""))
            {
                lbl_A4.Visible = false;
                okPass = true;
            }
            else
            {
                lbl_A4.Visible = true;
                okPass = false;
            }

            return okPass;
        }

        private bool ValidarDatabase(string d)
        {
            bool okData;

            if (!d.Equals(""))
            {
                lbl_A5.Visible = false;
                okData = true;
            }
            else
            {
                lbl_A5.Visible = true;
                okData = false;
            }

            return okData;
        }

        private void btn_SalvarInfo_Click(object sender, EventArgs e)
        {
            bool serverOk = ValidarServer(txt_InformacaoServidor.Text);
            bool portOk = ValidarPort(txt_InformacaoPorta.Text);
            bool userOk = ValidarUser(txt_InformacaoUser.Text);
            bool passwordOk = ValidarPassword(txt_InformacaoSenha.Text);
            bool databaseOk = ValidarDatabase(txt_InformacaoData.Text);
            bool tudoOk;

            string server, port, user, password, database;
            server = port = user = password = database = "";
            
            if (serverOk && portOk && userOk && passwordOk && databaseOk)
            {
                server = txt_InformacaoServidor.Text;
                port = txt_InformacaoPorta.Text;
                user = txt_InformacaoUser.Text;
                password = txt_InformacaoSenha.Text;
                database = txt_InformacaoData.Text;
                tudoOk = true;
            } else
            {
                tudoOk = false;
            }

            if (tudoOk == true)
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string launcherPath = Uri.UnescapeDataString(uri.Path);

                string userAdm = WindowsIdentity.GetCurrent().Name.Split('\\')[1].Trim();
                DirectoryInfo pastaInfo = new DirectoryInfo(launcherPath);
                DirectorySecurity ds = new DirectorySecurity();

                ds.AddAccessRule(new FileSystemAccessRule(userAdm, FileSystemRights.Modify, AccessControlType.Allow));
                ds.SetAccessRuleProtection(false, false);
                pastaInfo.SetAccessControl(ds);

                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                connectionStringsSection.ConnectionStrings["Database"].ConnectionString = "Server = " + server + "; Port = " + port + "; User Id = " + user + "; Password = " + password + "; Database = " + database + ";";
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");

                MessageBox.Show("Informações do banco cadastradas com sucesso!");
            } else
            {
                MessageBox.Show("Por favor, reveja as informações colocadas!");
            }
        }
    }
}
