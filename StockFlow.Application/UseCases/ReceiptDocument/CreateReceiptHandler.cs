/*!
 * @file CreateUnitHandler.cs
 * @brief -
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Domain;
using StockFlow.Application.Repositories;

namespace StockFlow.Application.UseCases;

/// <summary>Служба создания единицы измерения</summary>
public class CreateReceiptUseCase(IReceiptRepository receiptRepository, IBalanceRepository balanceRepository, IUnitOfWork unitOfWork) {
    private readonly IReceiptRepository _receiptRepository = receiptRepository;
    private readonly IBalanceRepository _balanceRepository = balanceRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Guid> Execute(CreateReceiptCommand command) {

        if (await _receiptRepository.ExistsByNumberAsync(command.Number))
            throw new DomainException("Документ с таким номером уже существует");

        var document = new ReceiptDocument(command.Number, command.Date);

        foreach (var item in command.Items) {
            document.AddItem(item.ResourceId, item.UnitId, item.Quantity);
        }

        await _unitOfWork.BeginTransactionAsync();

        await _receiptRepository.AddAsync(document);

        var grouped = document.GetGroupedQuantities();

        foreach (var kvp in grouped) {
            var balance = await _balanceRepository.GetAsync(kvp.Key.ResourceId, kvp.Key.UnitId);

            if (balance == null) {
                balance = new Balance(kvp.Key.ResourceId, kvp.Key.UnitId);
                balance.Increase(kvp.Value);
                await _balanceRepository.AddAsync(balance);
            } else {
                balance.Increase(kvp.Value);
            }
        }

        await _unitOfWork.CommitAsync();

        return document.Id;
    }
}