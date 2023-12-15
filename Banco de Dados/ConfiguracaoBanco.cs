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

namespace AnalisadorX
{
    public partial class Frm_ConfiguracaoBanco : Form
    {
        public Frm_ConfiguracaoBanco()
        {
            InitializeComponent();
        }

        private void btn_SalvarInfo_Click(object sender, EventArgs e)
        {
            string server = txt_InformacaoServidor.Text;
            string port = txt_InformacaoPorta.Text;
            string user = txt_InformacaoUser.Text;
            string password = txt_InformacaoSenha.Text;
            string database = txt_InformacaoData.Text;

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["Database"].ConnectionString = "Server = " + server + "; Port = " + port + "; User Id = " + user + "; Password = " + password + "; Database = " + database + ";";
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");

            MessageBox.Show("Informações do banco cadastradas com sucesso!");
        }
    }
}
