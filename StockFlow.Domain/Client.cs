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
/// Содержит основные свойства: идентификатор, наименование, адрес, состояние(?).
/// </summary>
public class Client : BaseEntity {

    /// <summary>value-object: Имя</summary>
    private Name _name = null!;

    /// <summary>value-object: Адрес</summary>
    private Address _address = null!;

    public Name Name { get => _name; }
    public Address Address { get => _address; }

    /// <summary>Конструктор для репозитория</summary>
    private Client() { }

    public Client(Name name, Address address) {
        SetName(name);
        SetAddress(address);
    }

    /// <summary>Изменить имя клиента</summary>
    public void Rename(Name name) {
        SetName(name);
    }

    /// <summary>Загрузить имя клиента</summary>
    private void SetName(Name name) {
        _name = name ?? throw new ArgumentNullException(nameof(name));
    }

    /// <summary>Изменить адрес клиента</summary>
    public void ReplaceAddress(Address address) {
        SetAddress(address);
    }

    /// <summary>Загрузить адрес клиента</summary>
    private void SetAddress(Address address) {
        _address = address ?? throw new ArgumentNullException(nameof(address));
    }
}