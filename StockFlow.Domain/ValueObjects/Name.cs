/*!
 * @file Name.cs
 * @brief Наименование (value-object)
 * @author -
 * @copyright -
 * @details
 *
 */
using System.Text.RegularExpressions;

namespace StockFlow.Domain;

/// <summary>Наименование (value-object)</summary>
public record class Name {
    /// <summary>Значение</summary>
    public string Value { get; }

    /// <summary>Регулярное выражение для валидации наименования</summary>
    /// <remarks>
    /// Надо разделить конкретно: имя ресурса, имя ед.измерения, имя клиента,но пока так
    /// Буквы любых языков, цифры, пробелыб знаки препинания (.,), апострофы ('), дефисы (-)
    /// </remarks>
    //private static readonly Regex ValidationRegex = new(@"^[\p{L}\p{M}\p{N}]{1,100}\z", RegexOptions.Singleline | RegexOptions.Compiled);
    private static readonly Regex ValidationRegex = new(
            @"(?i)^[\p{L}\p{M}\p{N}\s.,'-]{1,200}\z",
            RegexOptions.Singleline | RegexOptions.Compiled
        );

    /// <summary>Наименование (value-object) (только для чтения, конструктор)</summary>
    /// <param name="value">Значение</param>
    public Name(string value) {
        if (!IsValid(value)) {
            throw new ArgumentException("Имя не допустимо");
        }
        Value = value;
    }

    /// <summary>Проверяет корректность введенного наименований</summary>
    /// <param name="value">Значение</param>
    public static bool IsValid(string value) {
        return !String.IsNullOrWhiteSpace(value) && ValidationRegex.IsMatch(value);
    }

    //public override string ToString() {
    //    return Value;
    //}

    //public override Boolean Equals(Object? obj)
    //{
    //    return obj is Name other &&
    //           StringComparer.Ordinal.Equals(Value, other.Value);
    //}

    //public override Int32 GetHashCode()
    //{
    //    return StringComparer.Ordinal.GetHashCode(Value);
    //}
}