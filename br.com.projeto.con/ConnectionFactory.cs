﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Vendas_Fatec_2.br.com.projeto.con
{
    public class ConnectionFactory
    {
        //método para criar a conexao com o banco de dados
        public MySqlConnection GetConnection()
        {
            string conexao = ConfigurationManager.ConnectionStrings["bdfatec"].ConnectionString;

            return new MySqlConnection(conexao);
        }
    }
}
