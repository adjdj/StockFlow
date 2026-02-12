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


            Console.WriteLine("Ошшшибка: amount = {0}", command.Amount);

            // Лог (можно заменить на ILogger)
            //Console.WriteLine(
            //(
            //    "Баланс обновлён: ResourceId = {0}, Amount = {1}, Новый баланс = {2}",
            //    command.ResourceId,
            //    command.Amount,
            //    balance.Amount
            //);
        }

        //    // amount > 0
        //
        //    var balance = await _repository.GetAsync(resourceId/*, unit*/);
        //
        //    if (balance is null) {
        //        balance = new Balance(resourceId/*, unit*/);
        //        await _repository.AddAsync(balance);
        //    }
        //
        //    Console.WriteLine("Ошшшибка: Имя = {0} amount = {1} ID = {2}", balance.Resource?.Name, amount, resourceId);
        //    balance.Increase(amount);
        //
        //    await _repository.SaveAsync();
        //}
    }
}