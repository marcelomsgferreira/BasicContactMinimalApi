using Microsoft.EntityFrameworkCore;

public class ContactContext(DbContextOptions<ContactContext> options)
    : DbContext(options)
{
    public DbSet<Contact> Contacts => Set<Contact>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>().HasData(
            new Contact
            {
                Id = 1,
                Name = "Alice Silva",
                Email = "alice.silva@example.com",
                Phone = "(11) 98765-4321",
                Address = "Rua das Flores, 123, São Paulo, SP",
                IsFavorite = true
            },
            new Contact
            {
                Id = 2,
                Name = "Bruno Oliveira",
                Email = "bruno.oliveira@example.com",
                Phone = "(21) 92345-6789",
                Address = "Avenida Atlântica, 456, Rio de Janeiro, RJ",
                IsFavorite = false
            },
            new Contact
            {
                Id = 3,
                Name = "Carla Mendes",
                Email = "carla.mendes@example.com",
                Phone = "(31) 99876-5432",
                Address = "Rua da Liberdade, 789, Belo Horizonte, MG",
                IsFavorite = true
            },
            new Contact
            {
                Id = 4,
                Name = "Diego Souza",
                Email = "diego.souza@example.com",
                Phone = "(51) 91234-5678",
                Address = "Rua das Palmeiras, 321, Porto Alegre, RS",
                IsFavorite = false
            },
            new Contact
            {
                Id = 5,
                Name = "Emanuel Costa",
                Email = "emanuel.costa@example.com",
                Phone = "(71) 98765-1234",
                Address = "Rua do Sol, 654, Salvador, BA",
                IsFavorite = true
            },
            new Contact
            {
                Id = 6,
                Name = "Fernanda Lima",
                Email = "fernanda.lima@example.com",
                Phone = "(85) 92345-9876",
                Address = "Avenida Beira Mar, 234, Fortaleza, CE",
                IsFavorite = false
            },
            new Contact
            {
                Id = 7,
                Name = "Gabriel Martins",
                Email = "gabriel.martins@example.com",
                Phone = "(41) 91234-8765",
                Address = "Rua das Acácias, 987, Curitiba, PR",
                IsFavorite = true
            }
        );
    }

}
