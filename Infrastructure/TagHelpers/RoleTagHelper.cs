using AuthenticationAndAuthorization.Models.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthenticationAndAuthorization.Infrastructure.TagHelpers
{
    [HtmlTargetElement("td", Attributes = "user-role")]
    public class RoleTagHelper : TagHelper
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleTagHelper(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HtmlAttributeName("user-role")]
        public string RoleId { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            List<string> names = new List<string>();

            IdentityRole role = await _roleManager.FindByNameAsync(RoleId);

            if (role != null)
            {
                foreach (AppUser user in _userManager.Users)
                {
                    if (user != null && await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        names.Add(user.UserName);
                    }
                }
            }

            output.Content.SetContent(names.Count == 0 ? "No Users" : string.Join(',', names));
        }
    }
}
