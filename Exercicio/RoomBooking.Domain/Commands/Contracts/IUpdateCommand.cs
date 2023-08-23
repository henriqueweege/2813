namespace Domain.Commands.Contracts;

public interface IUpdateCommand
{
    public Guid Id { get; set; }
}
