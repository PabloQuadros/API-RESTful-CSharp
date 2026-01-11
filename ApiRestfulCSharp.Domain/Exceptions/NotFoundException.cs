using System;

namespace ApiRestfulCSharp.Domain.Exceptions;

public sealed class NotFoundException : Exception
{
    public NotFoundException(string entityName, Guid id)
        : base($"{entityName} with Id {id} was not found.") { }

    public static NotFoundException For<T>(Guid id)
    {
        return new NotFoundException(typeof(T).Name, id);
    }
}
