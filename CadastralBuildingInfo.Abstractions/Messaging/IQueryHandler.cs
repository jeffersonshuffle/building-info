﻿using MediatR;

namespace CadastralBuildingInfo.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse>: IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
