using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Online_Shop.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Online_Shop.Utility
{
    public class OnlineShopClaimsPrincipalFactory : UserClaimsPrincipalFactory<Online_ShopUser, IdentityRole>

    {
        
        public OnlineShopClaimsPrincipalFactory(UserManager<Online_ShopUser>userManager,RoleManager<IdentityRole> roleManager,IOptions<IdentityOptions> options):base(userManager,roleManager,options)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Online_ShopUser user)
        {
            var identity= await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("Fullname", user.FullName ?? ""));
            return identity;
        }
    }
}
