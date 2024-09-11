public record class CreateContactDto(
    int Id,
    string Name,
    string Email,
    string Phone,
    string Address,
    bool IsFavorite
);