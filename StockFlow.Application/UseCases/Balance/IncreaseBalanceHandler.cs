/*!
 * @file IncreaseBalanceService.cs
 * @brief -
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Domain;
using StockFlow.Application.Repositories;

namespace StockFlow.Application.UseCases;

public class IncreaseBalanceHandler {
    private readonly IBalanceRepository _repository;


    public IncreaseBalanceHandler(IBalanceRepository repository) {
        _repository = repository;
    }

    public async Task IncreaseAsync(IncreaseBalanceCommand[] commands) {
        if (commands == null || commands.Length == 0)
            throw new ArgumentException("Команды не могут быть null или пустыми");

        foreach (var command in commands) {
            // Валидация входных данных
            if (command.Amount <= 0)
                throw new DomainException($"Сумма должна быть положительной. ResourceId: {command.ResourceId}, Amount: {command.Amount}");

            if (command.ResourceId == Guid.Empty)
                throw new DomainException("ResourceId не может быть пустым");

            if (command.UnitId == Guid.Empty)
                throw new DomainException("UnitId не может быть пустым");

            // Получаем баланс по ResourceId
            var balance = await _repository.GetAsync(command.ResourceId, command.UnitId);

            // Если баланса нет — создаём новый
            if (balance == null) {
                balance = new Balance(command.ResourceId, command.UnitId);
                await _repository.AddAsync(balance);
            }

            // Увеличиваем баланс
            balance.Increase(command.Amount);

            // Сохраняем изменения
            await _repository.SaveAsync();
        }
    }
}