/*!
 * @file ShipmentDocument.cs
 * @brief Сущность "Документ отгрузки"
 * @author -
 * @copyright -
 * @details
 *  ЗАГОТОВКА
 */
namespace StockFlow.Domain;

public enum ShipmentStatus {
    Draft,
    Signed
}

/// <summary>
/// Представляет сущность "Документ отгрузки" в системе.
/// Содержит основные свойства: идентификатор, номер, идентификатор клиента, дата, состояние(?).
/// </summary>
public class ShipmentDocument {

    public Guid Id { get; set; }
    public string Number { get; private set; } = null!;
    public Guid ClientId { get; private set; }
    public DateTime Date { get; private set; }
    public ShipmentStatus Status { get; private set; }
    public ICollection<ShipmentItem> Items { get; private set; } = null!;

    //private ShipmentDocument() { }  // EF

    public ShipmentDocument() {
    }
}