/*!
 * @file ReadClientsHandler.cs
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

/// <summary>Служба чтения данных</summary>
public class ReadClientsHandler(IClientRepository repository) {
    private readonly IClientRepository _repository = repository;
    public async Task<IReadOnlyList<ClientDto>> Handle() {
        var client = await _repository.GetAllAsync();
        return client.Select(r => new ClientDto(r.Id, r.Name.Value, r.Address.Value)).ToList();
    }
}
