using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DAL
{
    public interface IToParameterMapper<in T, E> where E : Enum
    {
        Dictionary<string, object> MapToParameters(T data, E type);
    }

    public interface IToEntityMapper<out T, E> where E : Enum
    {
        T MapToEntity(Dictionary<string, object> data, E type);
    }

    public interface IParameterMapper<T, E> : IToParameterMapper<T, E>, IToEntityMapper<T, E> where E : Enum
    {
    }
}
