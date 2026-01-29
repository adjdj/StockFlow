/*!
 * @file Resource.cs
 * @brief Агрегат единица измерения в системе
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Domain.Common;

namespace StockFlow.Domain.Aggregates;

public class Unit : Entity
{
    public string Name { get; private set; }

    private Unit() { } // для ORM

    public Unit(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название не может быть пустым");

        Name = name;
    }
}