/*!
 * @file Address.cs
 * @brief Объект-значение "Адрес" (value-object)
 * @author -
 * @copyright -
 * @details 
 * УПРОЩЕННЫЙ.НАДО РАЗБИТЬ НА ДОМ+УЛИЦА+ГОРОД
 *
 */
//using System;
using System.Text.RegularExpressions;

namespace StockFlow.Domain;

public class Address {
    private static readonly Regex ValidationRegex = new Regex(
        @"^" +
        // Разрешаем: буквы, цифры, пробелы, дефисы, точки, запятые, апострофы, скобки, слэш
        @"[\\p{L}\\p{M}\\p{N}\\s\\-\\.,'\\/\\(\\)]" +
        // Минимум 5 символов, максимум 500 (можно настроить)
        "{5,500}" +
        "$",
        RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant
    );

    public Address(string value) {
        if (!IsValid(value)) {
            throw new ArgumentException("Address is not valid");
        }

        Value = value;
    }

    public string Value { get; }

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