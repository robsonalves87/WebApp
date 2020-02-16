using App.Domain;
using App.Repository;
using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class AlunoModel
    {

        //public List<Aluno> listarAlunos()
        //{
        //    var caminhoAqruivo = HostingEnvironment.MapPath("~/App_Data/Base.json");

        //    var json = File.ReadAllText(caminhoAqruivo);

        //    var listasAlunos = JsonConvert.DeserializeObject<List<Aluno>>(json);

        //    return listasAlunos;
        //}


        public List<AlunoDTO> listarAlunos(int? id = null)
        {
            try
            {
                var alunoDB = new AlunoDAO();
                return alunoDB.listarAlunosDB(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar Alunos: Erro => {ex.Message}");
            }
        }

        //public bool RescreverArquivo(List<AlunoDTO> Alunos)
        //{
        //    var caminhoAqruivo = HostingEnvironment.MapPath("~/App_Data/Base.json");

        //    var json = JsonConvert.SerializeObject(Alunos, Formatting.Indented);

        //    File.WriteAllText(caminhoAqruivo, json);

        //    return true;
        //}

        //public Aluno Inserir(Aluno aluno)
        //{
        //    var listaAlunos = this.listarAlunos();
        //    var maxId = listaAlunos.Max(a => a.Id);
        //    aluno.Id = maxId + 1;
        //    listaAlunos.Add(aluno);

        //    this.RescreverArquivo(listaAlunos);
        //    return aluno;
        //}

        public void Inserir(AlunoDTO aluno)
        {
            try
            {
                var alunoDB = new AlunoDAO();
                alunoDB.InserirAlunoDB(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir Aluno: Erro => {ex.Message}");
            }
        }


        //public Aluno Atualizar(int id, Aluno aluno)
        //{
        //    var listaAlunos = this.listarAlunos();

        //    var itemIndex = listaAlunos.FindIndex(a => a.Id == id);
        //    if (itemIndex >= 0)
        //    {
        //        aluno.Id = id;
        //        listaAlunos[itemIndex] = aluno;
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //    this.RescreverArquivo(listaAlunos);
        //    return aluno;
        //}

        public void Atualizar(AlunoDTO aluno)
        {
            try
            {
                var alunoDB = new AlunoDAO();
                alunoDB.AtualizarAlunoDB(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar Aluno: Erro => {ex.Message}");
            }
        }


        //public bool Deletar(int id)
        //{
        //    var listaAlunos = this.listarAlunos();

        //    var itemIndex = listaAlunos.FindIndex(a => a.Id == id);
        //    if (itemIndex >= 0)
        //    {
        //        listaAlunos.RemoveAt(itemIndex);
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //    this.RescreverArquivo(listaAlunos);
        //    return true;
        //}

        public void Deletar(int id)
        {
            try
            {
                var alunoDB = new AlunoDAO();
                alunoDB.DeletarAlunoDB(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar Aluno: Erro => {ex.Message}");
            }
        }
    }
}