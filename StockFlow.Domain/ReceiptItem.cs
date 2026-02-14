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
/// Представляет агрегат "Ресурс поступления" в системе.
/// Содержит основные свойства: идентификатор, идентификатор документа поступления, идентификатор ресурса, идентификатор единицы измерения, количество.
/// </summary>
public class ReceiptItem {
    /// <summary>Идентификатор</summary>
    public Guid Id { get; private set; }

    /// <summary>Идентификатор документа поступления</summary>
    public Guid ReceiptDocumentId { get; private set; }

    /// <summary>Идентификатор ресурса</summary>
    public Guid ResourceId { get; private set; }

    /// <summary>Идентификатор единицы измерения</summary>
    public Guid UnitId { get; private set; }

    /// <summary>Количество</summary>
    /// <remarks>
    /// Выделить в value-object
    /// </remarks>
    public decimal Quantity { get; private set; }

    // Навигация к агрегату
    //public ReceiptDocument ReceiptDocument { get; private set; }
    public ReceiptDocument? ReceiptDocument { get; set; } = null;

    /// <summary>Конструктор для EF</summary>
    private ReceiptItem() { } // EF

    /// <summary>Агрегат "Ресурс поступления" в системе (конструктор)</summary>
    /// <param name="resourceId">Идентификатор ресурса</param>
    /// <param name="unitId">Идентификатор единицы измерения</param>
    /// <param name="quantity">Идентификатор единицы измерения</param>
    public ReceiptItem(Guid resourceId, Guid unitId, decimal quantity) {
        if (quantity <= 0)
            throw new DomainException("Количество должно быть больше 0");

        Id = Guid.NewGuid();
        ResourceId = resourceId;
        UnitId = unitId;
        Quantity = quantity;
    }

    /// <summary>Возвращает пару-ключ ресурс-Единица измерения</summary>
    public ResourceUnitKey GetKey() => new(ResourceId, UnitId);
}