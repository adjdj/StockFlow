/*!
 * @file DomainException.cs
 * @brief Доменное событие в результате исключения (бизнес-сигнал нарушения инварианта)
 * @author -
 * @copyright -
 * @details
 *
 */
namespace StockFlow.Domain;

/// <summary>Доменное событие в результате исключения(бизнес-сигнал нарушения инварианта)</summary>
public class DomainException(string message) : Exception(message) {
}