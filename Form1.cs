using Projeto_Vendas_Fatec_2.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Vendas_Fatec_2.br.com.projeto.view
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frmclientes form = new Frmclientes();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frmfuncionarios form = new Frmfuncionarios();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frmfornecedores form = new Frmfornecedores();
            form.ShowDialog();
        }
    }
}
