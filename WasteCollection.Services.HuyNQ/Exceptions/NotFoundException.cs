namespace WasteCollection.Services.HuyNQ.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string message) : base(message) { }
}
