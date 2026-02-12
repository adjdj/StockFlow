/*!
 * @file Shipment.cs
 * @brief Сущность "Ресурс отгрузки"
 * @author -
 * @copyright -
 * @details
 *
 */
namespace StockFlow.Domain;

/// <summary>
/// Представляет сущность "Ресурс отгрузки" в системе.
/// Содержит основные свойства: идентификатор, идентификатор документа отгрузки, идентификатор ресурса, идентификатор единицы измерения, количество.
/// </summary>
public class ShipmentItem {
    public Guid Id { get; set; }
    public Guid ShipmentDocumentId { get; set; }
    public Guid ResourceId { get; set; }
    public Guid UnitId { get; set; }
    public decimal Quantity { get; set; }

    /// <summary>Конструктор для репозитория</summary>
    //private Shipment() { }

    public ShipmentItem() {
    }
}