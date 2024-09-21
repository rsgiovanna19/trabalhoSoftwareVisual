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

 // Adicionando tênis na lista
    public static Tenis AddTenis(Tenis tenis)
    {
        tenis.Id = tenis.Count + 1; // Ajuste aqui para atribuir um novo ID
        Banco.tenis.Add(tenis); // Use a lista corretamente
        return tenis;
    }

    // Atualizando um tênis por ID
    public static Tenis UpdateTenis(int id, Tenis tenisAtualizado)
    {
        var tenisExistente = tenis.FirstOrDefault(t => t.Id == id);
        if (tenisExistente == null)
        {
            return null;
        }

        tenisExistente.Nome = tenisAtualizado.Nome;
        tenisExistente.Marca = tenisAtualizado.Marca;
        return tenisExistente;
    }

    // Deletando um tênis por ID
    public static bool DeleteTenis(int id)
    {
        var tenisExistente = tenis.FirstOrDefault(t => t.Id == id);
        if (tenisExistente == null)
        {
            return false;
        }

        tenis.Remove(tenisExistente);
        return true;
    }
}