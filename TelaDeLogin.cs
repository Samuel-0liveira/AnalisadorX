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

            bool loginEfetuado = con.RealizarLogin(usuario, senha);

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
