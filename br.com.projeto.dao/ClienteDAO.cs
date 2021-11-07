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
    public class ClienteDAO
    {
        //Atributo
        private MySqlConnection conexao;

        //Construtor
        public ClienteDAO()
        {
            this.conexao = new ConnectionFactory().GetConnection();
        }

        #region  Método que cadastra um cliente
        public void CadastrarCliente(Cliente cliente)
        {
            try
            {                
                //1 passo - Criar o comando SQL
                string sql = @"insert into tb_clientes (nome,rg,cpf,email,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado)
                                 values (@nome, @rg, @cpf, @email, @telefone, @celular, @cep, @end, @numero, @comp, @bairro, @cidade, @estado)";

                //2 passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@nome",     cliente.nome);
                executasql.Parameters.AddWithValue("@rg",       cliente.rg);
                executasql.Parameters.AddWithValue("@cpf",      cliente.cpf);
                executasql.Parameters.AddWithValue("@email",    cliente.email);
                executasql.Parameters.AddWithValue("@telefone", cliente.telefone);
                executasql.Parameters.AddWithValue("@celular",  cliente.celular);
                executasql.Parameters.AddWithValue("@cep",      cliente.cep);
                executasql.Parameters.AddWithValue("@end",      cliente.endereco);
                executasql.Parameters.AddWithValue("@numero",   cliente.numero);
                executasql.Parameters.AddWithValue("@comp",     cliente.complemento);
                executasql.Parameters.AddWithValue("@bairro",   cliente.bairro);
                executasql.Parameters.AddWithValue("@cidade",   cliente.cidade);
                executasql.Parameters.AddWithValue("@estado",   cliente.uf);

                // 3 passo - Abrir a conexao e executa o comando sql
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Cliente Cadastrado com Sucesso!");

                //fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);                
            }
        }


        #endregion


        #region Método que alterar um cliente
        public void AlterarCliente(Cliente cliente)
        {
            try
            {
                //1 passo - Criar o comando SQL
                string sql = @"update tb_clientes set nome = @nome, rg = @rg, cpf= @cpf,
                               email = @email, telefone = @telefone, celular = @celular,
                               cep = @cep, endereco = @endereco, numero = @numero, complemento = @comp,
                               bairro = @bairro, cidade = @cidade, estado = @estado where id = @id";

                //2 passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@nome", cliente.nome);
                executasql.Parameters.AddWithValue("@rg", cliente.rg);
                executasql.Parameters.AddWithValue("@cpf", cliente.cpf);
                executasql.Parameters.AddWithValue("@email", cliente.email);
                executasql.Parameters.AddWithValue("@telefone", cliente.telefone);
                executasql.Parameters.AddWithValue("@celular", cliente.celular);
                executasql.Parameters.AddWithValue("@cep", cliente.cep);
                executasql.Parameters.AddWithValue("@endereco", cliente.endereco);
                executasql.Parameters.AddWithValue("@numero", cliente.numero);
                executasql.Parameters.AddWithValue("@comp", cliente.complemento);
                executasql.Parameters.AddWithValue("@bairro", cliente.bairro);
                executasql.Parameters.AddWithValue("@cidade", cliente.cidade);
                executasql.Parameters.AddWithValue("@estado", cliente.uf);

                executasql.Parameters.AddWithValue("@id", cliente.id);

                // 3 passo - Abrir a conexao e executa o comando sql
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Dados do cliente Alterados com Sucesso!");

                //fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }


        #endregion


        #region Método para excluir um Cliente
        public void ExcluirCliente(int idcliente)
        {
            try
            {
                //1 passo - Criar o comando SQL
                string sql = @"delete from tb_clientes where id = @id";

                //2 Passo - Organizar e executar o comando sql
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@id", idcliente);

                // 3 passo - Abrir a conexao e executa o comando sql
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Cliente excluido com Sucesso!");

                //fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region Métódo que Lista Todos os Clientes
        public DataTable ListarTodosClientes()
        {
            try
            {
                //1 Passo - Criar o comando SQL e o nosso DataTable
                DataTable tabelaCliente = new DataTable();
                string sql = @"select * from tb_clientes";

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


        #region Método que listaClientes utilizando List
        public List<Cliente> ListarClientes()
        {
            try
            {
                List<Cliente> listacliente = new List<Cliente>();
                //1 passo - Criar o comando SQL
                string sql = @"select * from tb_clientes";

                //2 Passo - Organizar e executar o comando sql               
                MySqlCommand executasql = new MySqlCommand(sql, conexao);

                //3 passo - Abrir a conexao e executa o comando sql
                conexao.Open();

                MySqlDataReader dr = executasql.ExecuteReader();

                while (dr.Read())
                {
                    Cliente obj = new Cliente();

                    obj.id    = dr.GetInt32("id");
                    obj.nome  = dr.GetString("nome");
                    obj.rg    = dr.GetString("rg");

                    listacliente.Add(obj);
                }

                return listacliente;


            }
            catch (Exception)
            {

                return null;
            }
        }
        #endregion

        #region Método que Consulta um Cliente Por Nome
        public DataTable ConsultarClientePorNome(string nome)
        {
            try
            {
                //1 Passo - Criar o comando SQL e o nosso DataTable
                DataTable tabelaCliente = new DataTable();
                string sql = @"select * from tb_clientes where nome = @nome";

                //2 Passo - Organizar e executar o comando sql               
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@nome", nome);

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

        #region Método que Consulta um Cliente Por CPF
        public DataTable ConsultarClientePorCPF(string cpf)
        {
            try
            {
                //1 Passo - Criar o comando SQL e o nosso DataTable
                DataTable tabelaCliente = new DataTable();
                string sql = @"select * from tb_clientes where cpf = @cpf";

                //2 Passo - Organizar e executar o comando sql               
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@cpf", cpf);

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



    }
}
