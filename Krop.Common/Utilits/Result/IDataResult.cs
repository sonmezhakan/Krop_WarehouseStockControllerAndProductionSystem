﻿namespace Krop.Common.Utilits.Result
{
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
