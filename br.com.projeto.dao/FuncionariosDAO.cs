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
    public class FuncionarioDAO
    {
        //Atributo
        private MySqlConnection conexao;

        //Construtor
        public FuncionarioDAO()
        {
            this.conexao = new ConnectionFactory().GetConnection();
        }

        #region  Método que cadastra um funcionario
        public void CadastrarFuncionario(Funcionarios funcionario)
        {
            try
            {
                //1 passo - Criar o comando SQL
                string sql = @"insert into tb_Funcionarios (nome,rg,cpf,email,senha,cargo,nivel_acesso,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado)
                                 values (@nome, @rg, @cpf, @email, @senha, @cargo, @nivel, @telefone, @celular, @cep, @end, @numero, @comp, @bairro, @cidade, @estado)";

                //2 passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@nome", funcionario.nome);
                executasql.Parameters.AddWithValue("@rg", funcionario.rg);
                executasql.Parameters.AddWithValue("@cpf", funcionario.cpf);
                executasql.Parameters.AddWithValue("@email", funcionario.email);
                executasql.Parameters.AddWithValue("@senha", funcionario.senha);
                executasql.Parameters.AddWithValue("@cargo", funcionario.cargo);
                executasql.Parameters.AddWithValue("@nivel", funcionario.nivel);
                executasql.Parameters.AddWithValue("@telefone", funcionario.telefone);
                executasql.Parameters.AddWithValue("@celular", funcionario.celular);
                executasql.Parameters.AddWithValue("@cep", funcionario.cep);
                executasql.Parameters.AddWithValue("@end", funcionario.endereco);
                executasql.Parameters.AddWithValue("@numero", funcionario.numero);
                executasql.Parameters.AddWithValue("@comp", funcionario.complemento);
                executasql.Parameters.AddWithValue("@bairro", funcionario.bairro);
                executasql.Parameters.AddWithValue("@cidade", funcionario.cidade);
                executasql.Parameters.AddWithValue("@estado", funcionario.uf);

                // 3 passo - Abrir a conexao e executa o comando sql
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Funcionario Cadastrado com Sucesso!");

                //fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }


        #endregion

        #region Método que alterar um funcionario
        public void AlterarFuncionario(Funcionarios funcionario)
        {
            try
            {
                //1 passo - Criar o comando SQL
                string sql = @"update tb_funcionarios set nome = @nome, rg= @rg,cpf= @cpf,
                               email = @email, senha=@senha, cargo = @cargo, nivel_acesso= @nivel, telefone = @telefone, celular = @celular,
                               cep = @cep, endereco = @endereco, numero = @numero, complemento = @comp,
                               bairro = @bairro, cidade = @cidade, estado = @estado where id = @id";

                //2 passo - Organizar o comando SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@nome", funcionario.nome);
                executasql.Parameters.AddWithValue("@rg", funcionario.rg);
                executasql.Parameters.AddWithValue("@cpf", funcionario.cpf);
                executasql.Parameters.AddWithValue("@email", funcionario.email);
                executasql.Parameters.AddWithValue("@senha", funcionario.senha);
                executasql.Parameters.AddWithValue("@cargo", funcionario.cargo);
                executasql.Parameters.AddWithValue("@nivel", funcionario.nivel);
                executasql.Parameters.AddWithValue("@telefone", funcionario.telefone);
                executasql.Parameters.AddWithValue("@celular", funcionario.celular);
                executasql.Parameters.AddWithValue("@cep", funcionario.cep);
                executasql.Parameters.AddWithValue("@endereco", funcionario.endereco);
                executasql.Parameters.AddWithValue("@numero", funcionario.numero);
                executasql.Parameters.AddWithValue("@comp", funcionario.complemento);
                executasql.Parameters.AddWithValue("@bairro", funcionario.bairro);
                executasql.Parameters.AddWithValue("@cidade", funcionario.cidade);
                executasql.Parameters.AddWithValue("@estado", funcionario.uf);

                executasql.Parameters.AddWithValue("@id", funcionario.id);

                // 3 passo - Abrir a conexao e executa o comando sql
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Dados do funcionario Alterados com Sucesso!");

                //fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }


        #endregion

        #region Método para excluir um Funcionario
        public void ExcluirFuncionario(int idfuncionario)
        {
            try
            {
                //1 passo - Criar o comando SQL
                string sql = @"delete from tb_funcionarios where id = @id";

                //2 Passo - Organizar e executar o comando sql
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@id", idfuncionario);

                // 3 passo - Abrir a conexao e executa o comando sql
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Funcionario excluido com Sucesso!");

                //fechar a conexao
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region Métódo que Lista Todos os funcionario
        public DataTable ListarTodosFuncionarios()
        {
            try
            {
                //1 Passo - Criar o comando SQL e o nosso DataTable
                DataTable tabelaFuncionario = new DataTable();
                string sql = @"select * from tb_funcionarios";

                //2 Passo - Organizar e executar o comando sql               
                MySqlCommand executasql = new MySqlCommand(sql, conexao);

                //3 passo - Abrir a conexao e executa o comando sql
                conexao.Open();
                executasql.ExecuteNonQuery();

                //4 Passo - Preencher o nosso DataTable com os dados do select
                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaFuncionario);
                conexao.Close();

                return tabelaFuncionario;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
                return null;
            }
        }
        #endregion

        #region Método que listaFuncionario utilizando List
        public List<Funcionarios> ListaFuncionario()
        {
            try
            {
                List<Funcionarios> listafuncionario = new List<Funcionarios>();
                //1 passo - Criar o comando SQL
                string sql = @"select * from tb_funcionarios";

                //2 Passo - Organizar e executar o comando sql               
                MySqlCommand executasql = new MySqlCommand(sql, conexao);

                //3 passo - Abrir a conexao e executa o comando sql
                conexao.Open();

                MySqlDataReader dr = executasql.ExecuteReader();

                while (dr.Read())
                {
                    Funcionarios obj = new Funcionarios();

                    obj.id = dr.GetInt32("id");
                    obj.nome = dr.GetString("nome");
                    obj.cpf = dr.GetString("cpf");

                    listafuncionario.Add(obj);
                }

                return listafuncionario;


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
                DataTable tabelaFuncionario = new DataTable();
                string sql = @"select * from tb_funcionarios where nome = @nome";

                //2 Passo - Organizar e executar o comando sql               
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@nome", nome);

                //3 passo - Abrir a conexao e executa o comando sql
                conexao.Open();
                executasql.ExecuteNonQuery();

                //4 Passo - Preencher o nosso DataTable com os dados do select
                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaFuncionario);
                conexao.Close();

                return tabelaFuncionario;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
                return null;
            }
        }

        #endregion

        #region Método que Consulta um Funcionario Por cnpj
        public DataTable ConsultarFuncionarioPorCPF(string cnpj)
        {
            try
            {
                //1 Passo - Criar o comando SQL e o nosso DataTable
                DataTable tabelaFuncionario = new DataTable();
                string sql = @"select * from tb_funcionarios where cpf = @cpf";

                //2 Passo - Organizar e executar o comando sql               
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@cpf", cnpj);

                //3 passo - Abrir a conexao e executa o comando sql
                conexao.Open();
                executasql.ExecuteNonQuery();

                //4 Passo - Preencher o nosso DataTable com os dados do select
                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaFuncionario);

                conexao.Close();

                return tabelaFuncionario;

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
