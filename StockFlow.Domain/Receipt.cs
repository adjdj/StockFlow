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
public class Receipt : Entity {

    /// <summary>Конструктор для репозитория</summary>
    //private Receipt() { }

    public Receipt() {
    }
}