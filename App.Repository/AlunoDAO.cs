using App.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace App.Repository
{
    public class AlunoDAO
    {
        //private string stringConexao = ConfigurationManager.AppSettings["ConnectionString"];
        private string stringConexao = ConfigurationManager.ConnectionStrings["ConexaoDev"].ConnectionString;
        private IDbConnection conexao;
        public AlunoDAO()
        {

            conexao = new SqlConnection(stringConexao);
            conexao.Open();
        }


        public List<AlunoDTO> listarAlunosDB(int? id)
        {
            try
            {
                var listasAlunos = new List<AlunoDTO>();

                IDbCommand selectCmd = conexao.CreateCommand();

                if (id == null)
                    selectCmd.CommandText = "select * from Alunos";
                else
                    selectCmd.CommandText = $"select * from Alunos where Id = {id}";

                IDataReader resultado = selectCmd.ExecuteReader();
                while (resultado.Read())
                {
                    var aluno = new AlunoDTO 
                    { 
                        Id = Convert.ToInt32(resultado["Id"]),
                        Nome = Convert.ToString(resultado["Nome"]),
                        Sobrenome = Convert.ToString(resultado["Sobrenome"]),
                        Telefone = Convert.ToString(resultado["Telefone"]),
                        RA = Convert.ToInt32(resultado["RA"])
                    };

                listasAlunos.Add(aluno);
                }

                return listasAlunos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void InserirAlunoDB(AlunoDTO aluno)
        {
            try
            {
                IDbCommand insertCmd = conexao.CreateCommand();
                insertCmd.CommandText = "insert into Alunos (Nome, Sobrenome, Telefone, RA) values (@Nome, @Sobrenome, @Telefone, @RA)";

                IDbDataParameter paramNome = new SqlParameter("Nome", aluno.Nome);
                IDbDataParameter paramSobrenome = new SqlParameter("Sobrenome", aluno.Sobrenome);
                IDbDataParameter paramTelefone = new SqlParameter("Telefone", aluno.Telefone);
                IDbDataParameter paramRA = new SqlParameter("RA", aluno.RA);

                insertCmd.Parameters.Add(paramNome);
                insertCmd.Parameters.Add(paramSobrenome);
                insertCmd.Parameters.Add(paramTelefone);
                insertCmd.Parameters.Add(paramRA);

                insertCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }


        public void AtualizarAlunoDB(AlunoDTO aluno)
        {
            try
            {
                IDbCommand updateCmd = conexao.CreateCommand();
                updateCmd.CommandText = "update Alunos set Nome = @Nome, Sobrenome = @Sobrenome, Telefone = @Telefone, RA = @RA where Id = @Id";

                IDbDataParameter paramId = new SqlParameter("Id", aluno.Id);
                IDbDataParameter paramNome = new SqlParameter("Nome", aluno.Nome);
                IDbDataParameter paramSobrenome = new SqlParameter("Sobrenome", aluno.Sobrenome);
                IDbDataParameter paramTelefone = new SqlParameter("Telefone", aluno.Telefone);
                IDbDataParameter paramRA = new SqlParameter("RA", aluno.RA);

                updateCmd.Parameters.Add(paramId);
                updateCmd.Parameters.Add(paramNome);
                updateCmd.Parameters.Add(paramSobrenome);
                updateCmd.Parameters.Add(paramTelefone);
                updateCmd.Parameters.Add(paramRA);

                updateCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void DeletarAlunoDB(int id)
        {
            try
            {
                IDbCommand deleteCmd = conexao.CreateCommand();
                deleteCmd.CommandText = "Delete Alunos where Id = @Id";

                IDbDataParameter paramId = new SqlParameter("Id", id);
                deleteCmd.Parameters.Add(paramId);

                deleteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

    }
}