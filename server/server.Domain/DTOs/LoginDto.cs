using System.ComponentModel.DataAnnotations;

namespace server.Domain.DTOs;

public record LoginDto(
    [Required] string Login,
    [Required] string Password);
