namespace StockFlow.Application.Contracts;

public record ReceiptDto(string number, DateTime date, List<(Guid ResourceId, Guid UnitId, decimal Quantity)> items);
