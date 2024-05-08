using AnalisadorX.Banco_de_Dados;
using System;
using System.Windows.Forms;

namespace AnalisadorX
{
    public partial class Frm_CatalogoDeMutantes : Form
    {
        //Chama método para conectar ao banco de dados.
        Conexao conn = new Conexao();
        public Frm_CatalogoDeMutantes()
        {
            InitializeComponent();
        }

        private void Frm_CatalogoDeMutantes_Load(object sender, EventArgs e)
        {
            //Chama método do banco para incluir informações no banco de dados.
            conn.IncluirCatalogo(cb_Mutantes);
        }

        private void cb_Mutantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*Caso a combobox tenha algum valor selecionado, altera as labels de acordo
             *com as informações do banco de dados baseada no campo alterego.
             */
            
            if (cb_Mutantes != null)
            {
                conn.AlterarInfosLabel(cb_Mutantes.Text, lbl_N, lbl_A, lbl_I, lbl_F, lbl_H, lbl_C);
            }
        }
    }
}
