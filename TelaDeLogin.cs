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
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void btn_Entrar_Click(object sender, EventArgs e)
        {
            Conexao con = new Conexao();
            string usuario = txt_User.Text;
            string senha = txt_Senha.Text;

            //Chama o método RealizarLogin para ver se as informações digitadas batem com a do banco de dados.
            bool loginEfetuado = con.RealizarLogin(usuario, senha);

            //Exibi uma mensagem diferente baseado no retorno da variável loginEfetuado.
            if (loginEfetuado)
            {
                MessageBox.Show("Login realizado com sucesso!");
            } else
            {
                MessageBox.Show("Usuário ou senha incorretos!");
            }
        }
    }
}
