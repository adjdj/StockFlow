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
public class Shipment : Entity {

    /// <summary>Конструктор для репозитория</summary>
    //private Shipment() { }

    public Shipment() {
    }
}