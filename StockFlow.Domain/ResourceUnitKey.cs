/*!
 * @file ResourceUnitKey.cs
 * @brief value-object
 * @author -
 * @copyright -
 * @details
 *
 */
//using System;
namespace StockFlow.Domain;

public record ResourceUnitKey(Guid ResourceId, Guid UnitId);