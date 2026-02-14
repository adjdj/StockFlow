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
/// Представляет агрегат "Документ поступления" в системе.
/// Содержит основные свойства: идентификатор, номер, дата.
/// </summary>
public class ReceiptDocument {
    /// <summary>Идентификатор</summary>
    public Guid Id { get; private set; }

    /// <summary>Номер</summary>
    public string Number { get; private set; } = null!;

    /// <summary>Дата</summary>
    public DateTime Date { get; private set; }

    /// <summary>Ресурсы поступления</summary>
    private readonly List<ReceiptItem> _items = new();

    /// <summary>Ресурсы поступления</summary>
    public IReadOnlyCollection<ReceiptItem> Items => _items;

    /// <summary>Конструктор для EF</summary>
    private ReceiptDocument() { }

    /// <summary>Агрегат "Документ поступления" в системе (конструктор)</summary>
    /// <param name="number">Номер</param>
    /// <param name="date">Дата</param>
    public ReceiptDocument(string number, DateTime date) {
        if (string.IsNullOrWhiteSpace(number))
            throw new DomainException("Номер документа обязателен");
        Id = Guid.NewGuid();
        Number = number!;
        Date = date;
    }

    /// <summary>Добавляет ресурс</summary>
    /// <param name="resourceId">Идентификатор ресурса</param>
    /// <param name="unitId">Идентификатор единицы измерения</param>
    /// <param name="quantity">Количество</param>
    public void AddItem(Guid resourceId, Guid unitId, decimal quantity) {
        // Immutable
        // Поиск существующей позиции по идентификаторам ресурса и единицы измерения
        var existing = _items
            .FirstOrDefault(x => x.ResourceId == resourceId &&
                                 x.UnitId == unitId);

        if (existing != null) {
            // Удаляем старую позицию
            _items.Remove(existing);
            // Создаем новую позицию с обновленным количеством
            _items.Add(new ReceiptItem(
                resourceId,
                unitId,
                existing.Quantity + quantity));
        } else {
            // Добавляем новую
            _items.Add(new ReceiptItem(resourceId, unitId, quantity));
        }
    }

    /// <summary>Возвращает dictionary Ресурс-Единица измерения-Количество</summary>
    public Dictionary<ResourceUnitKey, decimal> GetGroupedQuantities() {
        // В данной реализации суммирование лишнее, но пусть пока будет
        return _items
            .GroupBy(x => x.GetKey())
            .ToDictionary(
                g => g.Key,
                g => g.Sum(x => x.Quantity));
    }
}