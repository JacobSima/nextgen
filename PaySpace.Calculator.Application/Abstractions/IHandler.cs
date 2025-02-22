namespace PaySpace.Calculator.Application.Abstractions
{
  public interface IHandler<in TQuery, TResult>
    where TQuery : class, IAppHandler<TResult>
  {
    Task<TResult> HandleAsync(TQuery query);
  }
}
