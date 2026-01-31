/*!
 * @file Client.cs
 * @brief Агрегат баланс в системе
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Domain.Common;

namespace StockFlow.Domain.Aggregates;

public class Client : Entity
{
    public string Name { get; private set; }

    private Client() { }

    public Client(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Имя клиента пустое");

        Name = name;
    }
}