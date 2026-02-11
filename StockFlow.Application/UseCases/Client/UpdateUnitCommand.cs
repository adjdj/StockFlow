/*!
 * @file UpdateClientCommand.cs
 * @brief Реализует паттерн Command для операции обновления данных
 * @author -
 * @copyright -
 * @details
 * Инкапсулирует данные и логику, необходимые для выполнения действия, отделяя запрос на изменение от его реализации.
 * Command - для бизнес-сценария
 */
namespace StockFlow.Application.UseCases;

/// <summary>
/// Команда для операции обновления данных
/// Command - для бизнес-сценария
/// </summary>
public class UpdateClientCommand(Guid id, string name, string address) {
    public Guid Id { get; } = id;
    public string Name { get; } = name;
    public string Address { get; } = address;
}