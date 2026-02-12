/*!
 * @file DecreaseBalanceService.cs
 * @brief -
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Domain;
using StockFlow.Application.Repositories;

namespace StockFlow.Application.UseCases;

public class DecreaseBalanceService {
    private readonly IBalanceRepository _repository;

    public DecreaseBalanceService(IBalanceRepository repository) {
        _repository = repository;
    }

    public async Task DecreaseAsync(Guid resourceId, Guid unitId, decimal amount) {

        // amount > 0

        var balance = await _repository.GetAsync(resourceId, unitId);

        if (balance is null) {
            // Инвариант - ошибка
            return;
            //balance = new Balance(resourceId, unitId);
            //await _repository.AddAsync(balance);
        }

        // amount > 0
        balance.Decrease(Math.Abs(amount));

        await _repository.SaveAsync();
    }
}