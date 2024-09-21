//essa parte do banco eu utilizei como base a do professor

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext {


    protected override void OnConfiguring(
        DbContextOptionsBuilder builder)
    {
        string con = "server=localhost;port=3306;" +
                     "database=planner;user=root;password=1234";

        builder.UseMySQL(con)
        .LogTo(Console.WriteLine, LogLevel.Information);
        
    }

    //Tabelas
    public DbSet<Tarefa> Tarefas => Set<Tarefa>();

}




public class Banco
{
    // Lista de tênis
    private static List<Tenis> tenis = new List<Tenis>
    {
        new Tenis { Id = 1, Nome = "NMD", Marca = "Adidas" },
        new Tenis { Id = 2, Nome = "Dunk Low", Marca = "Nike" }
    };

    // Retornando todos os tênis da lista
    public static List<Tenis> GetTenis()
    {
        return tenis;
    }

    // Retornando os tênis por ID
    public static Tenis GetTenis(int id)
    {
        return tenis.FirstOrDefault(t => t.Id == id);
    }

//add tenis na list Loja
    public static Loja addTenis (Loja tenis)
    {
        Tenis.Id = Tenis.Count + 1;
        Tenis.Add(Loja);
        return tenis;
    }

    public static Tarefa updateTarefa(int id, Tarefa tarefa)
    {
        var tarefaExistente = tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefaExistente == null)
        {
            return null;
        }

        tarefaExistente.Descricao = tarefa.Descricao;
        tarefaExistente.Concluida = tarefa.Concluida;
        return tarefaExistente;
    }

    public static bool deleteTarefa(int id)
    {
        var tarefaExistente = tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefaExistente == null)
        {
            return false;
        }

        tarefas.Remove(tarefaExistente);
        return true;
    }

}