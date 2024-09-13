public record class CreateContactDto(
    string Name,
    string Email,
    string Phone,
    string Address,
    bool IsFavorite
);