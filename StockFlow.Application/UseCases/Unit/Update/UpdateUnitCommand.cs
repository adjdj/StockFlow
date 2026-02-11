/*!
 * @file UpdateUnitCommand.cs
 * @brief Реализует паттерн Command для операции удаления единицы измерения в системе управления складом
 * @author -
 * @copyright -
 * @details
 * Инкапсулирует данные и логику, необходимые для выполнения действия, отделяя запрос на изменение от его реализации.
 * Command - для бизнес-сценария
 */
namespace StockFlow.Application.UseCases;

/// <summary>
/// Команда для операции удаления единицы измерения
/// Содержит основные свойства команды: идентификатор.
/// Command - для бизнес-сценария
/// </summary>
public class UpdateUnitCommand(Guid id, string name) {
    public Guid Id { get; } = id;
    public string Name { get; } = name;
}