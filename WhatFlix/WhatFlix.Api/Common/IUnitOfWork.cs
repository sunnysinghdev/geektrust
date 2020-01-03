using System;
using System.Collections.Generic;
namespace WhatFlix.Common
{

    public interface IUnitOfWork : IDisposable
    {
        ICreditRepository Credits { get; }
        IMovieRepositry Movies { get; }
    }
}