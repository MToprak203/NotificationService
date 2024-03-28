namespace Core.Utilities.Results.Abstract
{
    public interface IResult
    {
        bool IsSuccess { get; }
        public string Message { get; }
    }
}
