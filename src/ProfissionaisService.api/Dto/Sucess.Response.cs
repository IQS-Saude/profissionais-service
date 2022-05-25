namespace ProfissionaisService.api.Dto;

public record SuccessResponse<T>(T Data) : Response(true);