/*!
 * @file ResourceUnitKey.cs
 * @brief Пара-ключ Ресурс-Единица измерения (value-object)
 * @author -
 * @copyright -
 * @details
 *
 */
namespace StockFlow.Domain;

/// <summary>Пара-ключ Ресурс-Единица измерения (value-object)</summary>
public record ResourceUnitKey(Guid ResourceId, Guid UnitId);