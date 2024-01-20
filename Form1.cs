using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalisadorX
{
    public partial class Frm_Principal : Form
    {
        public void FecharForms()
        {
            for (int formIndex = Application.OpenForms.Count - 1; formIndex >= 0; formIndex--)
            {
                if (Application.OpenForms[formIndex] != this)
                {
                    Application.OpenForms[formIndex].Close();
                }
            }
        }

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

        public Frm_Principal()
        {
            InitializeComponent();

            FecharForms();
            var configBanco = new Frm_ConfiguracaoBanco()
            {
                MdiParent = this
            };

            configBanco.Dock = DockStyle.Fill;
            configBanco.Show();
            EncryptConnectionString(false, "AnalisadorX.exe");
        }

        private void entrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FecharForms();
            var entrar = new Frm_Login
            {
                MdiParent = this
            };

            entrar.Dock = DockStyle.Fill;
            entrar.Show();
        }

        private void novoUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FecharForms();
            var novo = new Frm_NovoUsuario
            {
                MdiParent = this
            };

            novo.Dock = DockStyle.Fill;
            novo.Show();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FecharForms();
            var nMutante = new Frm_NovoMutante
            {
                MdiParent = this
            };

            nMutante.Dock = DockStyle.Fill;
            nMutante.Show();
        }

        private void catálogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FecharForms();
            var catalogo = new Frm_CatalogoDeMutantes
            {
                MdiParent = this
            };

            catalogo.Dock = DockStyle.Fill;
            catalogo.Show();
        }

        private void configuraçãoDoBancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FecharForms();
            var configBanco = new Frm_ConfiguracaoBanco()
            {
                MdiParent = this
            };

            configBanco.Dock = DockStyle.Fill;
            configBanco.Show();
        }
    }
}
