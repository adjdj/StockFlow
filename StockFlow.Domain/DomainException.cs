/*
не техническая ошибка
не HTTP
чистый бизнес-сигнал
*/
namespace StockFlow.Domain;

public class DomainException : Exception {
    public DomainException(string message) : base(message) { }
}