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
        //Método utilizado para criptografar e descriptografar a string de conexão.
        public static void EncryptConnectionString(bool encrypt, string fileName)
        {
            Configuration configuration = null;

            try
            {

                configuration = ConfigurationManager.OpenExeConfiguration(fileName);

                ConnectionStringsSection configSection = configuration.GetSection("connectionStrings") as ConnectionStringsSection;

                if ((!(configSection.ElementInformation.IsLocked)) && (!(configSection.SectionInformation.IsLocked)))
                {
                    if (encrypt && !configSection.SectionInformation.IsProtected)
                    {
                        configSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                    }

                    if (!encrypt && configSection.SectionInformation.IsProtected)
                    {
                        configSection.SectionInformation.UnprotectSection();
                    }

                    configSection.SectionInformation.ForceSave = true;

                    configuration.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public Frm_ConfiguracaoBanco()
        {
            InitializeComponent();
        }

        //Verificar se o campo server não ficou vazio e segue com a exbição da label de aviso caso necessário.
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

        //Verificar se o campo port não ficou vazio e segue com a exbição da label de aviso caso necessário.
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

        //Verificar se o campo user não ficou vazio e segue com a exbição da label de aviso caso necessário.
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

        //Verificar se o campo password não ficou vazio e segue com a exbição da label de aviso caso necessário.
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

        //Verificar se o campo database não ficou vazio e segue com a exbição da label de aviso caso necessário.
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
            //As variáveis recebem os resultados (true ou false) das validações.
            bool serverOk = ValidarServer(txt_InformacaoServidor.Text);
            bool portOk = ValidarPort(txt_InformacaoPorta.Text);
            bool userOk = ValidarUser(txt_InformacaoUser.Text);
            bool passwordOk = ValidarPassword(txt_InformacaoSenha.Text);
            bool databaseOk = ValidarDatabase(txt_InformacaoData.Text);
            bool tudoOk;

            string server, port, user, password, database;
            server = port = user = password = database = "";

            /*Caso todas as validações retornem true, a variável tudoOk recebe true e os valores contidos
            *nos textbox serão atribuídos em variáveis.
            */
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

            //Caso a variável tudoOk seja true, altera a string de conexão, salva, atualiza e criptografa a mesma.
            if (tudoOk == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                connectionStringsSection.ConnectionStrings["Database"].ConnectionString = "Server = " + server + "; Port = " + port + "; User Id = " + user + "; Password = " + password + "; Database = " + database + ";";
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");

                MessageBox.Show("Informações do banco cadastradas com sucesso!");

                EncryptConnectionString(false, "AnalisadorX.exe");

            } else
            {
                MessageBox.Show("Por favor, reveja as informações colocadas!");
            }
        }
    }
}
