using Microsoft.EntityFrameworkCore;

public static class ContactsEndpoints
{
    const string GetContactEndpointName = "GetContact";

    public static RouteGroupBuilder MapContactsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/contacts")
                       .WithParameterValidation();

        // GET /contacts
        group.MapGet("/", (ContactContext dbContext) =>
        {

            var contacts = dbContext.Contacts.ToList();
            return contacts is null ?
            Results.NotFound() : Results.Ok(contacts);
        });

        // GET /contacts/1
        group.MapGet("/{id}", async (int id, ContactContext dbContext) =>
        {
            Contact? contact = await dbContext.Contacts.FindAsync(id);

            return contact is null ?
                Results.NotFound() : Results.Ok(contact.ToContactDetails());
        })
        .WithName(GetContactEndpointName);

        // POST /contacts
        group.MapPost("/", async (CreateContactDto newContact, ContactContext dbContext) =>
        {
            Contact contact = newContact.ToEntityCreate();

            dbContext.Contacts.Add(contact);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetContactEndpointName,
                new { id = contact.Id },
                contact.ToContactDetails());
        });

        // PUT /contacts
        group.MapPut("/{id}", async (int id, UpdateContactDto updatedContact, ContactContext dbContext) =>
        {
            var existingContact = await dbContext.Contacts.FindAsync(id);

            if (existingContact is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingContact)
                     .CurrentValues
                     .SetValues(updatedContact.ToEntityUpdate(id));

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

        group.MapPatch("/{id}/favorite/", async (int id, ContactContext dbContext) =>
        {
            var existingContact = await dbContext.Contacts.FindAsync(id);

            if (existingContact is null)
            {
                return Results.NotFound();
            }

            existingContact.IsFavorite = !existingContact.IsFavorite;

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // GET /contacts/favorites - Lista contatos marcados como favoritos.

        group.MapGet("/favorites/", (ContactContext dbContext) =>
        {
            var contacts = dbContext.Contacts
            .Where(contact => contact.IsFavorite == true)
            .ToList();

            return contacts is null ?
            Results.NotFound() : Results.Ok(contacts);
        });


        return group;
    }

}