namespace Delivery.Domain.Dtos;

public readonly record struct CoverageAreaDto
{
    public string Type { get; init; }
    public string[] Coordinates { get; init; }
}


