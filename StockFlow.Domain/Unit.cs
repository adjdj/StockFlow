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
public class Unit : Entity {

    /// <summary>value-object: Имя</summary>
    private Name _name = null!;

    public Name Name { get => _name; }

    /// <summary>Конструктор для репозитория</summary>
    private Unit() { }

    public Unit(Name name) {
        SetName(name);
    }

    /// <summary>Изменить название единицы измерения</summary>
    public void Rename(Name name) {
        SetName(name);
    }

    /// <summary>Загрузить имя ресурса</summary>
    private void SetName(Name name) {
        _name = name ?? throw new ArgumentNullException(nameof(name));
    }
}