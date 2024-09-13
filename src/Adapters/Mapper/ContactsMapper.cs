public static class ContactsMapper
{
    public static Contact ToEntityCreate(this CreateContactDto newContact)
    {
        return new Contact()
        {
            Name = newContact.Name,
            Email = newContact.Email,
            Phone = newContact.Phone,
            Address = newContact.Address,
            IsFavorite = newContact.IsFavorite,
            CreatedAt = DateTime.Now
        };
    }

    public static Contact ToEntityUpdate(this UpdateContactDto newContact, int id)
    {
        return new Contact()
        {
            Id = id,
            Name = newContact.Name,
            Email = newContact.Email,
            Phone = newContact.Phone,
            Address = newContact.Address,
            IsFavorite = newContact.IsFavorite,
            ChangedAt = DateTime.Now
        };
    }

    public static ContactDetailsDto ToContactDetails(this Contact contact)
    {
        return new ContactDetailsDto(
            contact.Id,
            contact.Name,
            contact.Email,
            contact.Phone,
            contact.Address,
            contact.IsFavorite
        );
    }

}