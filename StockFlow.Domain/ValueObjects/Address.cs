/*!
 * @file Address.cs
 * @brief Адрес (value-object)
 * @author -
 * @copyright -
 * @details 
 * - Адрес надо разбить на составляющие
 */
//using System;
using System.Text.RegularExpressions;

namespace StockFlow.Domain;

/// <summary>Адрес (value-object)</summary>
public record class Address {
    /// <summary>Значение</summary>
    public string Value { get; }

    /// <summary>Регулярное выражение для валидации адреса</summary>
    private static readonly Regex ValidationRegex = new(
        @"(?i)^(?:" +                // Начало строки, регистронезависимый поиск
        @"[\p{L}\p{M}\p{N}\s.,#-]{1,200}" +  // Основная часть адреса (до 200 символов)
        @"(?:\s+" +                   // Пробел перед номером дома
        @"[\p{N}\/\-]{1,10}" +        // Номер дома (цифры, слеши, дефисы)
        @")?" +                       // Номер дома необязателен
        @"(?:\s+" +                   // Пробел перед дополнительными данными
        @"[\p{L}\p{M}\p{N}\s.,#-]{1,100}" +  // Дополнительные данные (до 100 символов)
        @")?" +                       // Дополнительные данные необязательны
        @")\z",                       // Конец строки
        RegexOptions.Singleline | RegexOptions.Compiled
    );
    /// <summary>Адрес (value-object)(только для чтения, конструктор)</summary>
    /// <param name="value">Значение</param>
    public Address(string value) {
        if (!IsValid(value)) {
            throw new ArgumentException("Адрес введен неверно");
        }
        Value = value;
    }

    /// <summary>Проверяет корректность введенного адреса</summary>
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