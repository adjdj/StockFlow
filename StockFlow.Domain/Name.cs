/*!
 * @file Name.cs
 * @brief Объект-значение "Имя" (value-object)
 * @author -
 * @copyright -
 * @details
 *
 */
//using System;
using System.Text.RegularExpressions;

namespace StockFlow.Domain;

public class Name {

    // Имя обязательно, не может быть нулевой длины или более 100 символов и не должно содержать спецсимволы, пунктуацию и т.д.
    // А возраст не может быть меньше 10 или больше 120 лет.
    private static readonly Regex ValidationRegex = new Regex(@"^[\p{L}\p{M}\p{N}]{1,100}\z", RegexOptions.Singleline | RegexOptions.Compiled);

    public Name(string value) {
        if (!IsValid(value)) {
            throw new ArgumentException("Name is not valid");
        }

        Value = value;
    }

    public string Value { get; }

    public static bool IsValid(string value) {
        return !String.IsNullOrWhiteSpace(value) && ValidationRegex.IsMatch(value);
    }

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