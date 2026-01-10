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
    
public record GetAllCarsQueryResponseDto(
    Guid Id, 
    string Brand, 
    string Model, 
    string Color,
    string Currency,
    decimal Price, 
    int Year
);