using AnalisadorX.Banco_de_Dados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            Conexao con = new Conexao();
            con.PegarStringDeConexao(txt_InformacaoServidor.Text, txt_InformacaoPorta.Text, txt_InformacaoUser.Text, txt_InformacaoSenha.Text, txt_InformacaoData.Text);
        }
    }
}
