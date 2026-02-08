/*
бизнес-сигнал
*/
namespace StockFlow.Domain;

public class DomainException(string message) : Exception(message) {
}