namespace Domain.Commands.Contracts;

public interface IDeleteCommand
{
    public Guid Id { get; set; }
}
