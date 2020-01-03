using System;
using System.Collections.Generic;
using WhatFlix.Api.Model;

namespace WhatFlix.Common
{

public interface ICreditRepository : IRepository<Credit>
{
    IEnumerable<Credit> GetByActor(string text);
}
}