/*!
 * @file Unit.cs
 * @brief Сущность "Единица измерения"
 * @author -
 * @copyright -
 * @details
 *
 */
namespace StockFlow.Domain;

/// <summary>
/// Представляет сущность "Единица измерения" в системе.
/// Содержит основные свойства: идентификатор, название, состояние.
/// </summary>
public class Unit : BaseEntity {
    /// <summary>value-object: Название</summary>
    public Name Name { get; private set; } = null!;

    /// <summary>Конструктор для EF</summary>
    private Unit() { }

    /// <summary>Сущность "Единица измерения" в системе (конструктор)</summary>
    /// <param name="name">Наименование</param>
    public Unit(Name name) {
        SetName(name);
    }

    /// <summary>Загрузить имя ресурса</summary>
    /// <param name="name">Наименование</param>
    private void SetName(Name name) {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    /// <summary>Изменить название единицы измерения</summary>
    /// <param name="name">Новое наименование</param>
    public void Rename(Name name) {
        SetName(name);
    }
}