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

public class IncreaseBalanceService {
    private readonly IBalanceRepository _repository;


    public IncreaseBalanceService(IBalanceRepository repository) {
        _repository = repository;
    }

    public async Task IncreaseAsync(Guid resourceId/*, UnitOfMeasure unit*/, decimal amount) {

        // amount > 0

        var balance = await _repository.GetAsync(resourceId/*, unit*/);

        if (balance is null) {
            balance = new Balance(resourceId/*, unit*/);
            await _repository.AddAsync(balance);
        }

        Console.WriteLine("Ошшшибка: Имя = {0} amount = {1} ID = {2}", balance.Resource?.Name, amount, resourceId);
        balance.Increase(amount);

        await _repository.SaveAsync();
    }
}