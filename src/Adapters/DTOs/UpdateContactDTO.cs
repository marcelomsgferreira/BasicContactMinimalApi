public record class UpdateContactDto(
    string Name,
    string Email,
    string Phone,
    string Address,
    bool IsFavorite
);