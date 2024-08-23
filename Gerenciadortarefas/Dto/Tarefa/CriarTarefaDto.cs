namespace GerenciamentoDeTarefas.Dto.Tarefa
{
    public class CriarTarefaDto
    {
        public string nomeTarefa { get; set; } = string.Empty;
        public string descricaoTarefa { get; set; } = string.Empty;

        public DateTime dataInicial { get; set; } = DateTime.Now;

        public DateTime dataFinal { get; set; }

        public int idgrupo { get; set; }

        public int statusTarefa { get; set; } = 1;
}
}
