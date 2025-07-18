namespace Calculators.Core.Interfaces
{
    public interface ICalculator<TInput, TOutput>
    {
        TOutput Calculate(TInput input);
        bool IsValidInput(TInput input);
        string GetCalculatorName();
    }
}