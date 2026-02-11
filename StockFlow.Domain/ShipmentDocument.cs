/*!
 * @file ShipmentDocument.cs
 * @brief Сущность "Документ отгрузки"
 * @author -
 * @copyright -
 * @details
 *
 */
namespace StockFlow.Domain;

/// <summary>
/// Представляет сущность "Документ отгрузки" в системе.
/// Содержит основные свойства: идентификатор, номер, идентификатор клиента, дата, состояние(?).
/// </summary>
public class ShipmentDocument : Entity {

    /// <summary>Конструктор для репозитория</summary>
    //private ShipmentDocument() { }

    public ShipmentDocument() {
    }
}