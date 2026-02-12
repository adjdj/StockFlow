/*!
 * @file ReceiptDocument.cs
 * @brief Агрегат "Документ поступления"
 * @author -
 * @copyright -
 * @details
 *
 */
namespace StockFlow.Domain;

/// <summary>
/// Представляет сущность "Документ поступления" в системе.
/// Содержит основные свойства: идентификатор, номер, дата.
/// </summary>
public class ReceiptDocument {
    private readonly List<ReceiptItem> _items = new();

    public Guid Id { get; private set; }
    public string Number { get; private set; }
    public DateTime Date { get; private set; }

    public IReadOnlyCollection<ReceiptItem> Items => _items;

    private ReceiptDocument() { } // EF

    public ReceiptDocument(string number, DateTime date) {
        if (string.IsNullOrWhiteSpace(number))
            throw new DomainException("Номер документа обязателен");

        Id = Guid.NewGuid();
        Number = number;
        Date = date;
    }

    public void AddItem(Guid resourceId, Guid unitId, decimal quantity) {
        var existing = _items
            .FirstOrDefault(x => x.ResourceId == resourceId &&
                                 x.UnitId == unitId);

        if (existing != null) {
            _items.Remove(existing);
            _items.Add(new ReceiptItem(
                resourceId,
                unitId,
                existing.Quantity + quantity));
        } else {
            _items.Add(new ReceiptItem(resourceId, unitId, quantity));
        }
    }

    public Dictionary<ResourceUnitKey, decimal> GetGroupedQuantities() {
        return _items
            .GroupBy(x => x.GetKey())
            .ToDictionary(
                g => g.Key,
                g => g.Sum(x => x.Quantity));
    }
}