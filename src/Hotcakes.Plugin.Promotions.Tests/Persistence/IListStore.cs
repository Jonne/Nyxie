﻿using System.Collections.Generic;

using Sitecore.Commerce.Core;

namespace Hotcakes.Plugin.Promotions.Tests.Persistence
{
    public interface IListStore
    {
        void Add(string list, CommerceEntity entity);

        IEnumerable<CommerceEntity> GetEntitiesInList(string list);
    }
}
