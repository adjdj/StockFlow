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
    public Name Name { get; private set; } = null!;

    /// <summary>Конструктор для EF</summary>
    private Resource() { }

    /// <summary>Сущность "Ресурс" в системе (конструктор)</summary>
    /// <param name="name">Наименование</param>
    public Resource(Name name) {
        SetName(name);
    }

    /// <summary>Изменить имя ресурса</summary>
    /// <param name="name">Наименование</param>
    public void Rename(Name name) {
        SetName(name);
    }

    /// <summary>Загрузить имя ресурса</summary>
    /// <param name="name">Наименование</param>
    private void SetName(Name name) {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}