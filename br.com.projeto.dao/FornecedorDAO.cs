using MySql.Data.MySqlClient;
using Projeto_Vendas_Fatec_2.br.com.projeto.con;
using Projeto_Vendas_Fatec_2.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Vendas_Fatec_2.br.com.projeto.dao
{
    public class FornecedorDAO
    {
        //Atributo
        private MySqlConnection conexao;

        //Construtor
        public FornecedorDAO()
        {
            this.conexao = new ConnectionFactory().GetConnection();
        }

        #region  Método que cadastra um fornecedor
        public void CadastrarFornecedor(Fornecedores fornecedor)
        {
            try
            {                
                //1 passo - Criar o comando SQL
                string sql = @"insert into tb_fornecedores (nome,cnpj,email,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado)
                                 values (@nome, @cnpj, @email, @telefone, @celular, @cep, @end, @numero, @comp, @bairro, @cidade, @estado)";

                //2 passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@nome", fornecedor.nome);
                executasql.Parameters.AddWithValue("@cnpj", fornecedor.cnpj);
                executasql.Parameters.AddWithValue("@email",    fornecedor.email);
                executasql.Parameters.AddWithValue("@telefone", fornecedor.telefone);
                executasql.Parameters.AddWithValue("@celular",  fornecedor.celular);
                executasql.Parameters.AddWithValue("@cep",      fornecedor.cep);
                executasql.Parameters.AddWithValue("@end",      fornecedor.endereco);
                executasql.Parameters.AddWithValue("@numero",   fornecedor.numero);
                executasql.Parameters.AddWithValue("@comp",     fornecedor.complemento);
                executasql.Parameters.AddWithValue("@bairro",   fornecedor.bairro);
                executasql.Parameters.AddWithValue("@cidade",   fornecedor.cidade);
                executasql.Parameters.AddWithValue("@estado",   fornecedor.uf);

                // 3 passo - Abrir a conexao e executa o comando sql
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Fornecedor Cadastrado com Sucesso!");

                //fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);                
            }
        }


        #endregion

        #region Método que alterar um fornecedor
        public void AlterarFornecedor(Fornecedores fornecedor)
        {
            try
            {
                //1 passo - Criar o comando SQL
                string sql = @"update tb_fornecedores set nome = @nome, cnpj= @cnpj,
                               email = @email, telefone = @telefone, celular = @celular,
                               cep = @cep, endereco = @endereco, numero = @numero, complemento = @comp,
                               bairro = @bairro, cidade = @cidade, estado = @estado where id = @id";

                //2 passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@nome", fornecedor.nome);
                executasql.Parameters.AddWithValue("@rg", fornecedor.rg);
                executasql.Parameters.AddWithValue("@cnpj", fornecedor.cnpj);
                executasql.Parameters.AddWithValue("@email", fornecedor.email);
                executasql.Parameters.AddWithValue("@telefone", fornecedor.telefone);
                executasql.Parameters.AddWithValue("@celular", fornecedor.celular);
                executasql.Parameters.AddWithValue("@cep", fornecedor.cep);
                executasql.Parameters.AddWithValue("@endereco", fornecedor.endereco);
                executasql.Parameters.AddWithValue("@numero", fornecedor.numero);
                executasql.Parameters.AddWithValue("@comp", fornecedor.complemento);
                executasql.Parameters.AddWithValue("@bairro", fornecedor.bairro);
                executasql.Parameters.AddWithValue("@cidade", fornecedor.cidade);
                executasql.Parameters.AddWithValue("@estado", fornecedor.uf);

                executasql.Parameters.AddWithValue("@id", fornecedor.id);

                // 3 passo - Abrir a conexao e executa o comando sql
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Dados do fornecedor Alterados com Sucesso!");

                //fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }


        #endregion

        #region Método para excluir um fornecedor
        public void ExcluirFornecedor(int idfuncionario)
        {
            try
            {
                //1 passo - Criar o comando SQL
                string sql = @"delete from tb_fornecedores where id = @id";

                //2 Passo - Organizar e executar o comando sql
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@id", idfuncionario);

                // 3 passo - Abrir a conexao e executa o comando sql
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Fornecedor excluido com Sucesso!");

                //fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region Métódo que Lista Todos os fornecedores
        public DataTable ListarTodosFornecedores()
        {
            try
            {
                //1 Passo - Criar o comando SQL e o nosso DataTable
                DataTable tabelaCliente = new DataTable();
                string sql = @"select * from tb_fornecedores";

                //2 Passo - Organizar e executar o comando sql               
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
          
                //3 passo - Abrir a conexao e executa o comando sql
                conexao.Open();
                executasql.ExecuteNonQuery();

                //4 Passo - Preencher o nosso DataTable com os dados do select
                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaCliente);
                conexao.Close();

                return tabelaCliente;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
                return null;
            }
        }
        #endregion

        #region Método que listaFornecedor utilizando List
        public List<Fornecedores> ListarFornecedor()
        {
            try
            {
                List<Fornecedores> listafornecedor = new List<Fornecedores>();
                //1 passo - Criar o comando SQL
                string sql = @"select * from tb_fornecedores";

                //2 Passo - Organizar e executar o comando sql               
                MySqlCommand executasql = new MySqlCommand(sql, conexao);

                //3 passo - Abrir a conexao e executa o comando sql
                conexao.Open();

                MySqlDataReader dr = executasql.ExecuteReader();

                while (dr.Read())
                {
                    Fornecedores obj = new Fornecedores();

                    obj.id    = dr.GetInt32("id");
                    obj.nome  = dr.GetString("nome");
                    obj.cnpj    = dr.GetString("cnpj");

                    listafornecedor.Add(obj);
                }

                return listafornecedor;


            }
            catch (Exception)
            {

                return null;
            }
        }
        #endregion

        #region Método que Consulta um fornecedor Por Nome
        public DataTable ConsultarFornecedorPorNome(string nome)
        {
            try
            {
                //1 Passo - Criar o comando SQL e o nosso DataTable
                DataTable tabelaFornecedor = new DataTable();
                string sql = @"select * from tb_fornecedores where nome = @nome";

                //2 Passo - Organizar e executar o comando sql               
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@nome", nome);

                //3 passo - Abrir a conexao e executa o comando sql
                conexao.Open();
                executasql.ExecuteNonQuery();

                //4 Passo - Preencher o nosso DataTable com os dados do select
                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaFornecedor);
                conexao.Close();

                return tabelaFornecedor;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
                return null;
            }
        }

        #endregion

        #region Método que Consulta um Fornecedor Por cnpj
        public DataTable ConsultarFornecedorPorCNPJ(string cnpj)
        {
            try
            {
                //1 Passo - Criar o comando SQL e o nosso DataTable
                DataTable tabelaFornecedor = new DataTable();
                string sql = @"select * from tb_fornecedores where cnpj = @cnpj";

                //2 Passo - Organizar e executar o comando sql               
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@cnpj", cnpj);

                //3 passo - Abrir a conexao e executa o comando sql
                conexao.Open();
                executasql.ExecuteNonQuery();

                //4 Passo - Preencher o nosso DataTable com os dados do select
                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaFornecedor);

                conexao.Close();

                return tabelaFornecedor;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
                return null;
            }
        }

        #endregion

    }
}
