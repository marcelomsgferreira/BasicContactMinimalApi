public record class UpdateGameDto(
    int Id,
    string Name,
    string Email,
    string Phone,
    string Address,
    bool IsFavorite
);