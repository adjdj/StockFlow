/*!
 * @file GetResourcesService.cs
 * @brief -
 * @author -
 * @copyright -
 * @details
 *
 */
namespace StockFlow.Application;

public class GetResourcesService {
    private readonly IResourceRepository _repository;

    public GetResourcesService(IResourceRepository repository) {
        _repository = repository;
    }

    public async Task<IReadOnlyList<ResourceDto>> GetAllAsync() {
        var resources = await _repository.GetAllAsync();

        return resources
            //.Select(r => new ResourceDto(r.Id, r.Name.ToString()))
            .Select(r => new ResourceDto(r.Id, r.GetName.Value))
            .ToList();
    }
}