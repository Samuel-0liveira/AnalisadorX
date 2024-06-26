﻿using AnalisadorX.Banco_de_Dados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AnalisadorX
{
    public partial class Frm_NovoUsuario : Form
    {
        Conexao conn = new Conexao();
        public Frm_NovoUsuario()
        {
            InitializeComponent();
        }

        //Verifica o tamanho do campo nome e segue com a exbição da label de aviso caso necessário.
        private bool ValidarNome(string n)
        {
            bool okNome;

            if (n.Length < 4 || n.Length > 60)
            {
                lbl_Aviso.Visible = true;
                okNome = false;
                txt_Nome.Focus();
            }
            else
            {
                lbl_Aviso.Visible = false;
                okNome = true;
            }

            return okNome;
        }

        /*Verifica o que foi digitado no campo de usuário, além do tamanho, é feita uma verificação
         *no banco de dados para evitar que sejam digitados usuários duplicados.
         */
        private bool ValidarUsuario(string u)
        {
            bool okUsuario;

            if ((u.Length < 4 || u.Length > 30) || (!conn.VerificarUsuarioNoBanco(u)))
            {
                lbl_Aviso2.Visible = true;
                okUsuario = false;
                txt_Usuario.Focus();
            }
            else
            {
                lbl_Aviso2.Visible = false;
                okUsuario = true;
            }

            return okUsuario;
        }

        private bool ValidarEmail(string e)
        {
            //Atribui em uma variável o modelo de e-mail que deve ser seguido
            string modeloEmail = "^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
            
            //Verifica se o e-mail digitado está de acordo com o modelo e retorna para a variável true ou false.
            bool okEmail = Regex.IsMatch(e, modeloEmail);

            /*Estrutura condicional que analisa se o que foi digitado no campo de e-mail está de acordo
             *com o modelo, não está vazio ou se já não existe dentro do banco de dados e segue com a 
             *exbição da label de aviso caso necessário .
             */
            if ((!okEmail || e == "") || (!conn.VerificarEmailNoBanco(e)))
            {
                okEmail = false;
                lbl_Aviso3.Visible = true;
                txt_Email.Focus();
            } else
            {
                okEmail = true;
                lbl_Aviso3.Visible = false;
            }

            return okEmail;
        }

        private bool ValidarSenha(string s)
        {
            //Atribui em uma variável o modelo de senha que deve ser seguido
            string modeloSenha = "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[$*&@#!])(?:([0-9a-zA-Z$*&@#!])(?!\\1)){8,13}$";

            //Verifica se o e-mail digitado está de acordo com o modelo e retorna para a variável true ou false.
            bool okSenha = Regex.IsMatch(s, modeloSenha);

            //Verifica se o que foi digitado no campo de senha está dentro do modelo ou não está vazio.
            if (!okSenha || s == "")
            {
                okSenha = false;
                lbl_Aviso4.Visible = true;
                MessageBox.Show("A senha deve ter: \n Entre 8 e 13 digítos; \n Ao menos 1 letra maiúscula; \n Ao menos um número; \n Não pode ter caractere repetido em sequência; \n Um dos caracteres especiais a seguir: $*&@#!");
                txt_Password.Focus();
            } else
            {
                okSenha = true;
                lbl_Aviso4.Visible = false;
            }

            return okSenha;
        }

        //Método que confirma se o que foi digitado em confirmar senha está igual a senha digitada.
        private bool ValidarConfirmarSenha(string cf, string s)
        {
            bool okConfirmarSenha;

            if (cf != s || cf == "")
            {
                okConfirmarSenha = false;
                lbl_Aviso5.Visible = true;
                txt_ConfSenha.Focus();
            } else
            {
                okConfirmarSenha = true;
                lbl_Aviso5.Visible = false;
            }

            return okConfirmarSenha;
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            //As variáveis recebem os resultados (true ou false) das validações.
            bool nomeOk = ValidarNome(txt_Nome.Text);
            bool usuarioOk = ValidarUsuario(txt_Usuario.Text);
            bool emailOk = ValidarEmail(txt_Email.Text);
            bool senhaOk = ValidarSenha(txt_Password.Text);
            bool confirmarSenhaOk = ValidarConfirmarSenha(txt_ConfSenha.Text, txt_Password.Text);
            bool tudoOk;

            string nome ,usuario, email, senha;
            nome = usuario = email = senha = "";

            /*Caso todas as validações retornem true, a variável tudoOk recebe true e os valores contidos
            *nos textbox serão atribuídos em variáveis.
            */
            if (nomeOk && usuarioOk && emailOk && senhaOk && confirmarSenhaOk)
            {
                    nome = txt_Nome.Text;
                    usuario = txt_Usuario.Text;
                    email = txt_Email.Text;
                    senha = txt_Password.Text;
                    tudoOk = true;
            } else
            {
                tudoOk = false;
            }

            //Se tudoOk for true, chamamos o método InserirUsuario que inclui as informações no banco de dados.
            if (tudoOk == true)
            {
                conn.InserirUsuario(nome, usuario, email, senha);
            } else
            {
                MessageBox.Show("Campo(s) inválido(s)!");
            }
        }
    }
}
