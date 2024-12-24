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
    public partial class Frm_NovoMutante : Form
    {
        Conexao conn = new Conexao();
        public Frm_NovoMutante()
        {
            InitializeComponent();
        }

        /*Método que valida o nome digitado, caso esteja ok, mantém o aviso da label invisivel,
         *do contrário, exibi o mesmo e atribuí o valor de false na variável.
         */
        private bool ValidarNome(string n)
        {
            bool okNome;

            if (n.Length < 4 || n.Length > 60)
            {
                lbl_A1.Visible = true;
                okNome = false;
                txt_Nome.Focus();
            }
            else
            {
                lbl_A1.Visible = false;
                okNome = true;
            }

            return okNome;
        }

        /*Verifica o que foi digitado no campo de alterego, além do tamanho, é feita uma verificação
         *no banco de dados para evitar que sejam digitados alteregos duplicados.
         */
        private bool ValidarAlterego(string a)
        {
            bool okAlterEgo;

            if ((a.Length < 4 || a.Length > 60) || (!conn.VerificarAlteregoNoBanco(a)))
            {
                lbl_A2.Visible = true;
                okAlterEgo = false;
                txt_AlterEgo.Focus();
            }
            else
            {
                lbl_A2.Visible = false;
                okAlterEgo = true;
            }

            return okAlterEgo;
        }

        //Verifica se o campo idade não está vazio e segue com a exbição da label de aviso caso necessário.
        public bool ValidarIdade(string i)
        {
            bool okIdade;

            if (!i.Equals(""))
            {
                lbl_A3.Visible = false;
                okIdade = true;
            } else
            {
                lbl_A3.Visible = true;
                okIdade = false;
                txt_Idade.Focus();
            }

            return okIdade;
        }

        //Verifica o tamanho do campo filiação e segue com a exbição da label de aviso caso necessário
        private bool ValidarFiliacao(string f)
        {
            bool okFiliacao;

            if (f.Length < 4 || f.Length > 25)
            {
                lbl_A4.Visible = true;
                okFiliacao = false;
                txt_Filiacao.Focus();
            }
            else
            {
                lbl_A4.Visible = false;
                okFiliacao = true;
            }

            return okFiliacao;
        }

        //Verifica o tamanho do campo habilidade e segue com a exbição da label de aviso caso necessário.
        private bool ValidarHabilidade(string h)
        {
            bool okHabilidade;

            if (h.Length < 4 || h.Length > 60)
            {
                lbl_A5.Visible = true;
                okHabilidade = false;
                txt_Habilidade.Focus();
            }
            else
            {
                lbl_A5.Visible = false;
                okHabilidade = true;
            }

            return okHabilidade;
        }

        /*Analisa o que foi digitado no campo de classificação, caso não se encaixe em uma das 6 opções 
         *é exibida uma message box alertando.
         */
        private bool ValidarClassificacao(string c)
        {
            bool okClassificacao;

            if (c.Equals("Ômega") || c.Equals("Alfa") || c.Equals("Beta") || c.Equals("Gama") || c.Equals("Delta") || c.Equals("Épsilon"))
            {
                lbl_A6.Visible = false;
                okClassificacao = true;
            } else
            {
                lbl_A6.Visible = true;
                okClassificacao = false;
                MessageBox.Show("O campo classificação só aceita as seguintes classes de mutantes: Ômega, Alfa, Beta, Gama, Delta, Épsilon");
                txt_Classificacao.Focus();
            }

            return okClassificacao;
        }

        private void btn_Catalogar_Click(object sender, EventArgs e)
        {
            //As variáveis recebem os resultados (true ou false) das validações.
            bool nomeOk = ValidarNome(txt_Nome.Text);
            bool alteregoOk = ValidarAlterego(txt_AlterEgo.Text);
            bool idadeOk = ValidarIdade(txt_Idade.Text);
            bool filiacaoOk = ValidarFiliacao(txt_Filiacao.Text);
            bool habilidadeOk = ValidarHabilidade(txt_Habilidade.Text);
            bool classificacaoOk = ValidarClassificacao(txt_Classificacao.Text);
            bool tudoOk;

            int idade = 0;
            string nome, alterego, filiacao, habilidade, classificacao;
            nome = alterego = filiacao = habilidade = classificacao = "";

           /*Caso todas as validações retornem true, a variável tudoOk recebe true e os valores contidos
            *nos textbox serão atribuídos em variáveis.
            */
            if (nomeOk && alteregoOk && idadeOk && filiacaoOk && habilidadeOk && classificacaoOk)
            {
                nome = txt_Nome.Text;
                alterego = txt_AlterEgo.Text;
                idade = Int32.Parse(txt_Idade.Text);
                filiacao = txt_Filiacao.Text;
                habilidade = txt_Habilidade.Text;
                classificacao = txt_Classificacao.Text;
                tudoOk = true;
            }
            else
            {
                tudoOk = false;
            }

            //Se tudoOk for true, chamamos o método InserirMutante que inclui as informações no banco de dados.
            if (tudoOk == true)
            {
                conn.InserirMutante(nome, alterego, idade, filiacao, habilidade, classificacao);
            }
            else
            {
                MessageBox.Show("Campo(s) inválido(s)!");
            }
        }
    }
}
