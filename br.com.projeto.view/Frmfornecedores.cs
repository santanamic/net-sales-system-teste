﻿using Projeto_Vendas_Fatec_2.br.com.projeto.dao;
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
    public partial class Frmfornecedores : Form
    {
        public Frmfornecedores()
        {
            InitializeComponent();
        }

        private void Frmfornecedores_Load(object sender, EventArgs e)
        {
            //Carrega a tela
            FornecedorDAO dao = new FornecedorDAO();
            dgfornecedores.DataSource = dao.ListarTodosFornecedores();
        }

        private void Btncadastrar_Click(object sender, EventArgs e)
        {
            //Botao cadastrar
            //1 passo - Receber os dados em um objeto model de Fornecedores
            Fornecedores fornecedor = new Fornecedores();

            fornecedor.nome = txtnome.Text;
            fornecedor.cnpj = txtcnpj.Text;
            fornecedor.email = txtemail.Text;
            fornecedor.telefone = txttelefone.Text;
            fornecedor.celular = txtcelular.Text;
            fornecedor.cep = txtcep.Text;
            fornecedor.endereco = txtendereco.Text;
            fornecedor.numero = int.Parse(txtnumero.Text);
            fornecedor.complemento = txtcomp.Text;
            fornecedor.bairro = txtbairro.Text;
            fornecedor.cidade = txtcidade.Text;
            fornecedor.uf = cbuf.Text;

            //2 passo - Criar o objeto FornecedorDAO para chamar o método CadastrarFornecedor
            FornecedorDAO dao = new FornecedorDAO();
            dao.CadastrarFornecedor(fornecedor);

            //Recarregar o datagridview
            dgfornecedores.DataSource = dao.ListarTodosFornecedores();
        }

        private void dgfornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Pegando os dados da linha selecionada
            txtcodigo.Text = dgfornecedores.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = dgfornecedores.CurrentRow.Cells[1].Value.ToString();
            txtcnpj.Text = dgfornecedores.CurrentRow.Cells[2].Value.ToString();
            txtemail.Text = dgfornecedores.CurrentRow.Cells[3].Value.ToString();
            txttelefone.Text = dgfornecedores.CurrentRow.Cells[4].Value.ToString();
            txtcelular.Text = dgfornecedores.CurrentRow.Cells[5].Value.ToString();
            txtcep.Text = dgfornecedores.CurrentRow.Cells[6].Value.ToString();
            txtendereco.Text = dgfornecedores.CurrentRow.Cells[7].Value.ToString();
            txtnumero.Text = dgfornecedores.CurrentRow.Cells[8].Value.ToString();
            txtcomp.Text = dgfornecedores.CurrentRow.Cells[9].Value.ToString();
            txtbairro.Text = dgfornecedores.CurrentRow.Cells[10].Value.ToString();
            txtcidade.Text = dgfornecedores.CurrentRow.Cells[11].Value.ToString();
            cbuf.Text = dgfornecedores.CurrentRow.Cells[12].Value.ToString();

            //Alterar para a guia de dados pessoais
            tabControl1.SelectedTab = tabPage1;
        }

        private void Btneditar_Click(object sender, EventArgs e)
        {
            //Botão editar
            //1 passo - Receber os dados em um objeto model de cliente
            Fornecedores fornecedor = new Fornecedores();

            fornecedor.nome = txtnome.Text;
            fornecedor.cnpj = txtcnpj.Text;
            fornecedor.email = txtemail.Text;
            fornecedor.telefone = txttelefone.Text;
            fornecedor.celular = txtcelular.Text;
            fornecedor.cep = txtcep.Text;
            fornecedor.endereco = txtendereco.Text;
            fornecedor.numero = int.Parse(txtnumero.Text);
            fornecedor.complemento = txtcomp.Text;
            fornecedor.bairro = txtbairro.Text;
            fornecedor.cidade = txtcidade.Text;
            fornecedor.uf = cbuf.Text;

            //Receber o id do cliente
            fornecedor.id = int.Parse(txtcodigo.Text);

            //2 passo - Criar o objeto FornecedorDAO para chamar o método CadastrarFornecedor
            FornecedorDAO dao = new FornecedorDAO();
            dao.AlterarFornecedor(fornecedor);

            //Recarregar o datagridview
            dgfornecedores.DataSource = dao.ListarTodosFornecedores();

        }

        private void Btnexcluir_Click(object sender, EventArgs e)
        {
            //Botao excluir
            FornecedorDAO dao = new FornecedorDAO();
            dao.ExcluirFornecedor(int.Parse(txtcodigo.Text));

            //Recarregar o datagridview
            dgfornecedores.DataSource = dao.ListarTodosFornecedores();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Botao que consulta o cep
            try
            {
                //1 Passo - Receber o cep
                string cep = txtcep.Text;

                string xml = "https://viacep.com.br/ws/" + cep + "/xml/";

                DataSet dados = new DataSet();
                dados.ReadXml(xml);

                //Exibir os dados no campo de texto
                txtendereco.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtbairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtcidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                txtcomp.Text = dados.Tables[0].Rows[0]["complemento"].ToString();
                cbuf.Text = dados.Tables[0].Rows[0]["uf"].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Endereço não encontrado, por favor digite manualmente.");

            }
        }

        private void Btnconsultar_Click(object sender, EventArgs e)
        {
            //Botao consultar cliente
            string dados = txtconsulta.Text;
            FornecedorDAO dao = new FornecedorDAO();

            //Verificar qual é a opção escolhida no combobox filtro
            // Se for nome
            if (cbfiltro.SelectedIndex == 0)
            {
                MessageBox.Show("Consulta por Nome");
                dgfornecedores.DataSource = dao.ConsultarFornecedorPorNome(dados);

            }

            else if (cbfiltro.SelectedIndex == 1)
            {
                MessageBox.Show("Consulta por CNPJ");
                dgfornecedores.DataSource = dao.ConsultarFornecedorPorCNPJ(dados);
            }



            if (dgfornecedores.Rows.Count == 0)
            {
                MessageBox.Show("Fornecedor não encontrado!");
                dgfornecedores.DataSource = dao.ListarTodosFornecedores();
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
