/*!
 * @file Receipt.cs
 * @brief Сущность "Ресурс поступления"
 * @author -
 * @copyright -
 * @details
 *
 */
namespace StockFlow.Domain;

/// <summary>
/// Представляет сущность "Ресурс поступления" в системе.
/// Содержит основные свойства: идентификатор, идентификатор документа поступления, идентификатор ресурса, идентификатор единицы измерения, количество.
/// </summary>
public class ReceiptItem {
    public Guid Id { get; private set; }

    // Внешний ключ к ReceiptDocument
    public Guid ReceiptDocumentId { get; private set; }

    // Навигация к агрегату
    public ReceiptDocument ReceiptDocument { get; private set; }

    public Guid ResourceId { get; private set; }
    public Guid UnitId { get; private set; }
    public decimal Quantity { get; private set; }

    private ReceiptItem() { } // EF

    public ReceiptItem(Guid resourceId, Guid unitId, decimal quantity) {
        if (quantity <= 0)
            throw new DomainException("Количество должно быть больше 0");

        Id = Guid.NewGuid();
        ResourceId = resourceId;
        UnitId = unitId;
        Quantity = quantity;
    }

    public ResourceUnitKey GetKey() => new(ResourceId, UnitId);
}