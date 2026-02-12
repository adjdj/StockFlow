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

    public async Task IncreaseAsync(Guid resourceId, Guid unitId, decimal amount) {

        // amount > 0
        var balance = await _repository.GetAsync(resourceId, unitId);

        if (balance is null) {
            balance = new Balance(resourceId, unitId);
            await _repository.AddAsync(balance);
        }
        balance.Increase(amount);

        await _repository.SaveAsync();
    }
}