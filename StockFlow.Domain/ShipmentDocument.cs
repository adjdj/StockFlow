/*!
 * @file ShipmentDocument.cs
 * @brief Сущность "Документ отгрузки"
 * @author -
 * @copyright -
 * @details
 *
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
    public string Number { get; private set; }
    public Guid ClientId { get; private set; }
    public DateTime Date { get; private set; }
    public ShipmentStatus Status { get; private set; }
    public ICollection<ShipmentItem> Items { get; private set; }

    //private ShipmentDocument() { }  // EF

    public ShipmentDocument() {
    }
}