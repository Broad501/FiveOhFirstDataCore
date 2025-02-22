﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiveOhFirstDataCore.Core.Account
{
    public class TrooperRoleManager : RoleManager<TrooperRole>
    {
        public TrooperRoleManager(IRoleStore<TrooperRole> store, IEnumerable<IRoleValidator<TrooperRole>> roleValidators,
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<TrooperRole>> logger)
            : base(store, roleValidators, keyNormalizer, errors, logger)
        {

        }

        public async Task SeedRoles<T>() where T : Enum
        {
            var values = Enum.GetValues(typeof(T));
            foreach (var v in values)
            {
                await CreateAsync(new TrooperRole(v.ToString()));
            }
        }
    }
}
