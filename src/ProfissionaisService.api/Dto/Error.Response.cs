namespace ProfissionaisService.api.Dto;

public record ErrorResponse<T>(T Error) : Response(false);