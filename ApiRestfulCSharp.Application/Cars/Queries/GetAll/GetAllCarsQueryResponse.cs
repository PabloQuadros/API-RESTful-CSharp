using ApiRestfulCSharp.Application.Common;

namespace ApiRestfulCSharp.Application.Cars.Queries.GetAll;

public class GetAllCarsQueryResponse : PaginatedResult<GetAllCarsQueryResponseDto>
{
    public GetAllCarsQueryResponse(
        List<GetAllCarsQueryResponseDto> items, 
        int totalCount, 
        int pageNumber, 
        int pageSize) 
        : base(items, totalCount, pageNumber, pageSize)
    {
    }
}
    
public record GetAllCarsQueryResponseDto()
{
    public Guid Id { get; init; }
    public required string Brand { get; init; }
    public required string Model { get; init; }
    public required string Color { get; init; }
    public required string Currency { get; init; }
    public decimal Price { get; init; }
    public int Year { get; init; }
}