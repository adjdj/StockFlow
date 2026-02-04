/*!
 * @file Resource.cs
 * @brief Агрегат ресурс в системе
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Domain.Common;

namespace StockFlow.Domain.Aggregates;

/// <summary>
/// Представляет ресурс в системе.
/// Содержит основные свойства товара: идентификатор, название, состояние.
/// </summary>
public class Resource : Entity
{
    public string Name { get; private set; } = null!;

    private Resource() { }

    public Resource(string name)
    {
        SetName(name);
        Name = name;
    }

    /// <summary>
    /// Изменить имя ресурса
    /// </summary>
    public void Rename(string name)
    {
        SetName(name);
    }


    /// <summary>
    /// Загрузить имя ресурса
    /// </summary>
    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название ресурса пустое");

        Name = name;
    }
}