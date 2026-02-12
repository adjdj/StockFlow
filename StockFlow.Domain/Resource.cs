/*!
 * @file Resource.cs
 * @brief Сущность "Ресурс"
 * @author -
 * @copyright -
 * @details
 *
 */
namespace StockFlow.Domain;

/// <summary>
/// Представляет сущность "Ресурс" в системе.
/// Содержит основные свойства товара: идентификатор, название, состояние.
/// </summary>
public class Resource : BaseEntity {

    /// <summary>value-object: Имя</summary>
    private Name _name = null!;

    public Name Name { get => _name; }

    /// <summary>Конструктор для репозитория</summary>
    private Resource() { }

    public Resource(Name name) {
        SetName(name);
    }

    /// <summary>Изменить имя ресурса</summary>
    public void Rename(Name name) {
        SetName(name);
    }

    /// <summary>Загрузить имя ресурса</summary>
    private void SetName(Name name) {
        _name = name ?? throw new ArgumentNullException(nameof(name));
    }
}