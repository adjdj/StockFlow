namespace StockFlow.Application.ReadModel;

public class ReceiptDocumentDto {
    public Guid Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public List<ReceiptItemDto> Items { get; set; } = new();
}