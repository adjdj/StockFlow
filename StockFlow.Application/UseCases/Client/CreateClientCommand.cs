/*!
 * @file CreateClientCommand.cs
 * @brief Реализует паттерн Command для операции добавления клиента в системе управления складом
 * @author -
 * @copyright -
 * @details
 * Инкапсулирует данные и логику, необходимые для выполнения действия, отделяя запрос на изменение от его реализации.
 * Command - для бизнес-сценария
 */
namespace StockFlow.Application.UseCases;

/// <summary>
/// Команда для операции создания клиента
/// Содержит основные свойства товара: имя, адрес.
/// Command - для бизне-сценария
/// </summary>
public class CreateClientCommand(string name, string address) {
    public string Name { get; } = name;
    public string Address { get; } = address;
}