/*!
 * @file Client.cs
 * @brief Сущность "Клиент"
 * @author -
 * @copyright -
 * @details
 *
 */
namespace StockFlow.Domain;

/// <summary>
/// Представляет сущность "Клиент" в системе.
/// Содержит основные свойства: идентификатор, наименование, адрес, состояние.
/// </summary>
public class Client : BaseEntity {

    /// <summary>value-object: Название</summary>
    public Name Name { get; private set; } = null!;

    /// <summary>value-object: Адрес</summary>
    public Address Address { get; private set; } = null!;

    /// <summary>Конструктор для EF</summary>
    private Client() { }

    /// <summary>Сущность "Клиент" в системе (конструктор)</summary>
    /// <param name="name">Наименование</param>
    /// <param name="address">Адрес</param>
    public Client(Name name, Address address) {
        SetName(name);
        SetAddress(address);
    }
    /// <summary>Загрузить имя клиента</summary>
    /// <param name="name">Наименование</param>
    private void SetName(Name name) {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    /// <summary>Загрузить адрес клиента</summary>
    /// <param name="address">Адрес</param>
    private void SetAddress(Address address) {
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }

    /// <summary>Изменить имя клиента</summary>
    /// <param name="name">Наименование</param>
    public void Rename(Name name) {
        SetName(name);
    }


    /// <summary>Изменить адрес клиента</summary>
    /// <param name="address">Адрес</param>
    public void ReplaceAddress(Address address) {
        SetAddress(address);
    }
}