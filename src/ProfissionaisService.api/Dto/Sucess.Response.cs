namespace ProfissionaisService.api.Dto;

public record SucessResponse<T>(T Data) : Response(true);