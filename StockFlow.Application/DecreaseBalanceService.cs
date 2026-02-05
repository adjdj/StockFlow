/*!
 * @file DecreaseBalanceService.cs
 * @brief -
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Domain;

namespace StockFlow.Application;

public class DecreaseBalanceService {
    private readonly IBalanceRepository _repository;


    public DecreaseBalanceService(IBalanceRepository repository) {
        _repository = repository;
    }


    public async Task DecreaseAsync(Guid resourceId/*, UnitOfMeasure unit*/, decimal amount) {

        // amount > 0

        var balance = await _repository.GetAsync(resourceId/*, unit*/);

        if (balance is null) {

            // Инавриант - ошибка
            return;
            balance = new Balance(resourceId/*, unit*/);
            await _repository.AddAsync(balance);
        }

        // amount > 0
        balance.Decrease(Math.Abs(amount));

        await _repository.SaveAsync();
    }
}