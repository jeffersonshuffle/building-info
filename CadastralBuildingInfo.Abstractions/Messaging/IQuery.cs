using MediatR;

namespace CadastralBuildingInfo.Abstractions.Messaging;

public interface IQuery<TResponse>: IRequest<Result<TResponse>>
{
}
