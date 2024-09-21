using System.Collections.Generic;
using System.Linq;


//base na do professor - tem que arrumar - eh a forma de conexao com o banco de dados 
public class AppDbContext : DbContext {

    // public AppDbContext(
    //     DbContextOptions<AppDbContext> options)
    //      : base(options)
    // {
    // }

    protected override void OnConfiguring(
        DbContextOptionsBuilder builder)
    {
        string con = "server=localhost;port=3306;" +
                     "database=planner;user=root;password=positivo";

        builder.UseMySQL(con)
        .LogTo(Console.WriteLine, LogLevel.Information);
        
    }
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
    public static Tenis AddTenis(Tenis novoTenis)
    {
        novoTenis.Id = tenis.Count + 1; // Atribui um novo ID
        tenis.Add(novoTenis); // Adiciona o novo tênis à lista
        return novoTenis;
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

