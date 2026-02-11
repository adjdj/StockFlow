/*!
 * @file DeleteClientCommand.cs
 * @brief Реализует паттерн Command для операции удаления
 * @author -
 * @copyright -
 * @details
 * Инкапсулирует данные и логику, необходимые для выполнения действия, отделяя запрос на изменение от его реализации.
 * Command - для бизнес-сценария
 */
namespace StockFlow.Application.UseCases;

/// <summary>
/// Команда для операции удаления
/// Command - для бизнес-сценария
/// </summary>
public class DeleteClientCommand(Guid id) {
    public Guid Id { get; } = id;
}