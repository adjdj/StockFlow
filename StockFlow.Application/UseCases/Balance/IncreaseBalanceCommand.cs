/*!
 * @file AddStockCommand.cs
 * @brief Реализует паттерн Command для операции добавления запасов (stock) в системе управления складом
 * @author -
 * @copyright -
 * @details
 * Класс AddStockCommand реализует паттерн Command для операции добавления запасов (stock) в системе 
 * управления складом. Он инкапсулирует данные и логику, необходимые для выполнения действия, отделяя запрос на изменение от его реализации.
 * Command - для бизне-сценария
 */
namespace StockFlow.Application.UseCases;

/// <summary>
/// Команда для операции добавления товара
/// Содержит основные свойства товара: идентификатор товара, количество.
/// Command - для бизне-сценария
/// </summary>
public class IncreaseBalanceCommand(Guid resourceId, Guid unitId, int amount) {
    public Guid ResourceId { get; } = resourceId;
    public Guid UnitId { get; } = unitId;
    public decimal Amount { get; } = amount;
}