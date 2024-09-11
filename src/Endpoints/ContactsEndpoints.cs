using Microsoft.EntityFrameworkCore;

public static class ContactsEndpoints
{
    const string GetGameEndpointName = "GetGame";

    public static RouteGroupBuilder MapContactsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/contacts")
                       .WithParameterValidation();

        // GET /contacts
        group.MapGet("/", async (ContactContext dbContext) =>
            await dbContext.Contacts
                     .Include(contact => contact.Genre)
                     .Select(contact => contact.ToGameSummaryDto())
                     .AsNoTracking()
                     .ToListAsync());

        // GET /contacts/1
        group.MapGet("/{id}", async (int id, ContactContext dbContext) =>
        {
            Contact? contact = await dbContext.Contacts.FindAsync(id);

            return contact is null ?
                Results.NotFound() : Results.Ok(contact.ToGameDetailsDto());
        })
        .WithName(GetGameEndpointName);

        // POST /contacts
        group.MapPost("/", async (CreateGameDto newGame, ContactContext dbContext) =>
        {
            Game contact = newGame.ToEntity();

            dbContext.Contacts.Add(contact);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetGameEndpointName,
                new { id = contact.Id },
                contact.ToGameDetailsDto());
        });

        // PUT /contacts
        group.MapPut("/{id}", async (int id, UpdateGameDto updatedGame, ContactContext dbContext) =>
        {
            var existingGame = await dbContext.Contacts.FindAsync(id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingGame)
                     .CurrentValues
                     .SetValues(updatedGame.ToEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // DELETE /contacts/1
        group.MapDelete("/{id}", async (int id, ContactContext dbContext) =>
        {
            await dbContext.Contacts
                     .Where(contact => contact.Id == id)
                     .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        // PATCH /contacts/{id}/favorite 

        group.MapPatch("/{id}/favorite/", (int id) => {

        });

        // GET /contacts/favorites - Lista contatos marcados como favoritos.

        group.MapGet("/favorites/", () => {

        });


        return group;
    }

}