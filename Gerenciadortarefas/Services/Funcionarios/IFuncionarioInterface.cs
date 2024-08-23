
using Gerenciadortarefas.Models;
using GerenciamentoDeTarefas.Dto.Funcionario;
using GerenciamentoDeTarefas.Dto.Grupo;
using GerenciamentoDeTarefas.Dto.Tarefa;


namespace Gerenciadortarefas.Services.Funcionarios
{
    public interface IFuncionarioInterface
    {
        public void AtualizarGrupo(Grupos grupo);

        public void AdicionarGrupo(CriarGrupoDto grupoDto);
        public void RemoverGrupo(Grupos grupos);

        public IEnumerable<Grupos> ListarGrupos(int idFuncionario);

        public Grupos ObterGrupoPorId(int id);
        public Tarefas ObterTarefaPorId(int id);


        public void RemoverTarefa(int id);

        public void AdicionarTarefa(CriarTarefaDto criarTarefaDto);

        public void AtualizarTarefa(Tarefas tarefas);

        public void ConcluirTarefa(int id);
        public int ValidaLogin(string nome, string senha);
        void CriarFuncionario(string nome, string senha);
    }
}
