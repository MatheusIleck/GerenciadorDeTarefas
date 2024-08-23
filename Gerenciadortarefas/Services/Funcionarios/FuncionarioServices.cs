using GerenciamentoDeTarefas.Dto.Funcionario;
using GerenciamentoDeTarefas.Dto.Grupo;
using GerenciamentoDeTarefas.Dto.Tarefa;
using Microsoft.EntityFrameworkCore;
using Gerenciadortarefas.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq;


namespace Gerenciadortarefas.Services.Funcionarios
{
    public class FuncionarioServices : IFuncionarioInterface
    {
        private readonly db_gerenciamentoContext _db;
        public FuncionarioServices(db_gerenciamentoContext db)
        {
            _db = db;
        }

        public void AdicionarGrupo(CriarGrupoDto grupoDto)
        {

            try
            {
                var funcionario = _db.Funcionarios.FirstOrDefault(x => x.Id == 2);

                Grupos NovoGrupo = new Grupos
                {
                    NomeGrupo = grupoDto.nomeGrupo,
                    DescricaoGrupo = grupoDto.descricaoGrupo

                };
                _db.Grupos.Add(NovoGrupo);
                _db.SaveChanges();

                var grupo = _db.Grupos.FirstOrDefault(x => x.NomeGrupo == grupoDto.nomeGrupo);

                Funcionariogrupo funcionariogrupo = new Funcionariogrupo
                {
                    IdFuncionario = funcionario.Id,
                    IdGrupo = grupo.IdGrupo
                };

                _db.Funcionariogrupo.Add(funcionariogrupo);

                _db.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AdicionarTarefa(CriarTarefaDto criarTarefaDto)
        {
            try
            {
                if (criarTarefaDto != null)
                {
                    var tarefa = new Tarefas
                    {
                        NomeTarefa = criarTarefaDto.nomeTarefa,
                        DescricaoTarefa = criarTarefaDto.descricaoTarefa,
                        DataInicial = criarTarefaDto.dataInicial,
                        IdGrupo = criarTarefaDto.idgrupo,
                        IdStatus = criarTarefaDto.statusTarefa
                    };

                    _db.Tarefas.Add(tarefa);
                    _db.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AtualizarGrupo(Grupos grupo)
        {
            try
            {
                if (grupo != null)
                {
                    _db.Update(grupo);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AtualizarTarefa(Tarefas tarefas)
        {
            if (tarefas != null)
            {
                _db.Tarefas.Update(tarefas);
                _db.SaveChanges();

            }
        }



        public void ConcluirTarefa(int id)
        {
            var tarefa = _db.Tarefas.FirstOrDefault(x => x.Id == id);
            if (tarefa != null)
            {
                tarefa.IdStatus = 2;
                _db.Tarefas.Update(tarefa);
                _db.SaveChanges();
            }


        }

        public void CriarFuncionario(string nome, string senha)
        {
            try
            {
                if(nome != null && senha != null)
                {
                    Models.Funcionarios novoFuncionario = new Models.Funcionarios
                    {
                        Nome = nome,
                        Senha = senha
                    };
                    _db.Funcionarios.Add(novoFuncionario);
                    _db.SaveChanges();
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        public IEnumerable<Grupos> ListarGrupos(int idFuncionario)
        {
            try
            {

                var grupos = _db.Funcionariogrupo
               .Where(fg => fg.IdFuncionario == idFuncionario)
               .Join(_db.Grupos,
                     fg => fg.IdGrupo,
                     g => g.IdGrupo,
                     (fg, g) => g);


                return grupos.ToList();


            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Grupos ObterGrupoPorId(int id)
        {
            try
            {

                Grupos grupo = _db.Grupos
                .Include(x => x.Tarefas)
                .ThenInclude(s => s.IdStatusNavigation)
                .FirstOrDefault(x => x.IdGrupo == id);


                return grupo;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Tarefas ObterTarefaPorId(int id)
        {
            try
            {

                var tarefa = _db.Tarefas.FirstOrDefault(x => x.Id == id);
                return tarefa;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoverGrupo(Grupos grupo)
        {
            try
            {
                var funcionariogrupo = _db.Funcionariogrupo.FirstOrDefault(x => x.IdGrupo == grupo.IdGrupo);

                _db.Funcionariogrupo.Remove(funcionariogrupo);
                _db.Grupos.Remove(grupo);

                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void RemoverTarefa(int id)
        {
            try
            {
                var tarefa = _db.Tarefas.FirstOrDefault(x => x.Id == id);

                if (tarefa != null)
                    _db.Tarefas.Remove(tarefa);
                _db.SaveChanges(true);

            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int ValidaLogin(string nome, string senha)
        {
            try
            {
                var idFuncionario = _db.Funcionarios.FirstOrDefault(x => x.Nome == nome && x.Senha == senha).Id;

                return idFuncionario;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
