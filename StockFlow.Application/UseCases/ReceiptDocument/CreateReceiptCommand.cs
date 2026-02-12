/*!
 * @file CreateUnitCommand.cs
 * @brief Реализует паттерн Command для операции добавления запасов (stock) в системе управления складом
 * @author -
 * @copyright -
 * @details
 * Инкапсулирует данные и логику, необходимые для выполнения действия, отделяя запрос на изменение от его реализации.
 * Command - для бизнес-сценария
 */
namespace StockFlow.Application.UseCases;

/// <summary>
/// Команда для операции создания единицы измерения
/// Содержит основные свойства товара: название.
/// Command - для бизне-сценария
/// </summary>
public class CreateReceiptCommand(string number, DateTime date, List<(Guid ResourceId, Guid UnitId, decimal Quantity)> items) {
    public string Number { get; set; } = number;
    public DateTime Date { get; set; } = date;
    public List<(Guid ResourceId, Guid UnitId, decimal Quantity)> Items { get; set; } = items;
}