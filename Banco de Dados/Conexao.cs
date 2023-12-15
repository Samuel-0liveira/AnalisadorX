﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalisadorX.Banco_de_Dados
{
    public class ControleM
    {
        public string Nome { get; set; }
        public string Alterego { get; set; }
        public int Idade { get; set; }
        public string Filiacao { get; set; }
        public string Habilidade { get; set; }
        public string Classificacao { get; set; }
    }

    public class Conexao
    {
        NpgsqlConnection con = new NpgsqlConnection("Server = 192.168.15.8; Port = 5432; User Id = postgres; Password = Dantemustdie66; Database = db_projetox;");
        public Conexao()
        {
            con.Open();
            con.Close();
        }
        public bool VerificarUsuarioNoBanco(string usuario)
        {
            bool okUsuario = false;

            try
            {
                con.Open();

                NpgsqlCommand cmd = new NpgsqlCommand();

                cmd.CommandText = "SELECT usuario FROM analisador WHERE (usuario = @usuario)";
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                NpgsqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    okUsuario = false;
                    MessageBox.Show("Nome de usuário já utilizado!");
                }
                else
                {
                    okUsuario = true;
                }

                con.Close();
            } 
            catch (Exception ex) {
                MessageBox.Show("Erro: " + ex);
                con.Close();
            }

            return okUsuario;
        }

        public bool VerificarEmailNoBanco(string email)
        {
            bool okEmail = false;

            try
            {
                con.Open();

                NpgsqlCommand cmd = new NpgsqlCommand();

                cmd.CommandText = "SELECT email FROM analisador WHERE (email = @email)";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                NpgsqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    okEmail = false;
                    MessageBox.Show("E-mail já cadastrado!");
                }
                else
                {
                    okEmail = true;
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
                con.Close();
            }

            return okEmail;
        }

        public bool VerificarAlteregoNoBanco(string alterego)
        {
            bool okAlter = false;

            try
            {
                con.Open();

                NpgsqlCommand cmd = new NpgsqlCommand();

                cmd.CommandText = "SELECT alterego FROM mutante WHERE (alterego = @alterego)";
                cmd.Parameters.AddWithValue("alterego", alterego);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                NpgsqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    okAlter = false;
                    MessageBox.Show("Nome de usuário já utilizado!");
                }
                else
                {
                    okAlter = true;
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
                con.Close();
            }

            return okAlter;
        }

        public void InserirUsuario(string nome, string usuario, string email, string senha)
        {
            try
            {
                con.Open();

                NpgsqlCommand cmd = new NpgsqlCommand();
                Hash admDeHash = new Hash();

                byte[] salt = admDeHash.GerarSalt();

                cmd.CommandText = "INSERT INTO analisador (nome, usuario, email, senha, salt) VALUES (@nome, @usuario, @email, @senha, @salt);";
                cmd.Parameters.AddWithValue("nome", nome);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("email", email);
                senha = admDeHash.CriarHash(senha, salt);
                cmd.Parameters.AddWithValue("senha", senha);
                cmd.Parameters.AddWithValue("salt", salt);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("CADASTRO EFETUADO COM SUCESSO!");
            }
            catch (Exception ex) {
                MessageBox.Show("Erro: " + ex);
                con.Close();
            }
        }

        public bool RealizarLogin(string usuario, string senha)
        {
            bool igual = false;

            try
            {
                con.Open();

                NpgsqlCommand cmd = new NpgsqlCommand();
                Hash admDeHash = new Hash();

                string hashDoBanco = "";
                byte[] salt = new byte[16];

                cmd.CommandText = "SELECT salt, senha FROM analisador WHERE (usuario = @usuario);";
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    salt = (byte[])reader["salt"];
                    hashDoBanco = reader["senha"].ToString();
                }

                reader.Close();

                cmd.CommandText = "SELECT * FROM analisador WHERE (usuario = @usuario AND senha = @senha);";
                cmd.Parameters.AddWithValue("usuario", usuario);
                senha = admDeHash.CompararSenhas(senha, salt);
                cmd.Parameters.AddWithValue("senha", senha);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                NpgsqlDataReader reader2 = cmd.ExecuteReader();

                if (reader2.HasRows)
                {
                    igual = true;
                }
                else
                {
                    igual = false;
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
                con.Close();
            }

            return igual;
        }

        public void InserirMutante(string nome, string alterego, int idade, string filiacao, string habilidade, string classificacao)
        {
            try
            {
                con.Open();

                NpgsqlCommand cmd = new NpgsqlCommand();

                cmd.CommandText = "INSERT INTO mutante (nome, alterego, idade, filiacao, habilidade, classificacao) VALUES (@nome, @alterego, @idade, @filiacao, @habilidade, CAST (@classificacao AS classificacao_mutante));";
                cmd.Parameters.AddWithValue("nome", nome);
                cmd.Parameters.AddWithValue("alterego", alterego);
                cmd.Parameters.AddWithValue("idade", idade);
                cmd.Parameters.AddWithValue("filiacao", filiacao);
                cmd.Parameters.AddWithValue("habilidade", habilidade);
                cmd.Parameters.AddWithValue("classificacao", classificacao);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Mutante cadastrado com sucesso!");
            }
            catch (Exception ex) {
                MessageBox.Show("Erro: " + ex);
                con.Close();
            }
        }

        public void IncluirCatalogo(ComboBox combo)
        {
            try
            {
                List<ControleM> resultados = new List<ControleM>();
                NpgsqlCommand cmd = new NpgsqlCommand();

                con.Open();

                cmd.CommandText = "SELECT * FROM mutante;";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                NpgsqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    ControleM m = new ControleM();
                    m.Nome = reader["nome"].ToString();
                    m.Alterego = reader["alterego"].ToString();
                    m.Idade = Convert.ToInt32(reader["idade"]);
                    m.Filiacao = reader["filiacao"].ToString();
                    m.Habilidade = reader["habilidade"].ToString();
                    resultados.Add(m);
                }

                combo.DataSource = resultados;
                combo.DisplayMember = "Alterego";

                con.Close();
            }
            catch (Exception ex) {
                MessageBox.Show("Erro: " + ex);
                con.Close();
            }
        }

        public void AlterarInfosLabel(string alter, Label nome, Label alterego, Label idade, Label filiacao, Label habilidade, Label classificacao)
        {
            try
            {
                con.Close();

                con.Open();

                NpgsqlCommand cmd = new NpgsqlCommand();

                cmd.CommandText = "SELECT * FROM mutante WHERE (alterego = @alterego);";
                cmd.Parameters.AddWithValue("alterego", alter);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    nome.Text = reader.GetString(1);
                    alterego.Text = reader.GetString(2);
                    idade.Text = reader.GetInt32(3).ToString();
                    filiacao.Text = reader.GetString(4);
                    habilidade.Text = reader.GetString(5);
                    classificacao.Text = reader.GetString(6);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
                con.Close();
            }
        }
    }
}

