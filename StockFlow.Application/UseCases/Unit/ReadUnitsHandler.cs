/*!
 * @file ReadUnitsHandler.cs
 * @brief -
 * @author -
 * @copyright -
 * @details
 *
 */
//using StockFlow.Domain;
using StockFlow.Application.Contracts;
using StockFlow.Application.Repositories;

namespace StockFlow.Application.UseCases;

/// <summary>Служба чтения данных единиц измерения</summary>
public class ReadUnitsHandler(IUnitRepository repository) {
    private readonly IUnitRepository _repository = repository;
    public async Task<IReadOnlyList<UnitDto>> Handle() {
        var resources = await _repository.GetAllAsync();
        return resources.Select(r => new UnitDto(r.Id, r.Name.Value)).ToList();
    }
}
