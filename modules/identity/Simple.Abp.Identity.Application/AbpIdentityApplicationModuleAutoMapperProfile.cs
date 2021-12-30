using AutoMapper;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;

namespace Simple.Abp.Identity
{
	public class AbpIdentityApplicationModuleAutoMapperProfile : Profile
	{
		public AbpIdentityApplicationModuleAutoMapperProfile()
		{
			CreateMap<IdentityUser, IdentityUserDto>().Ignore(x => x.IsLockedOut);
			CreateMap<IdentityRole, IdentityRoleDto>();
			CreateMap<IdentityClaimType, ClaimTypeDto>().Ignore(x => x.ValueTypeAsString);
			CreateMap<IdentityUserClaim, IdentityUserClaimDto>();
			CreateMap<IdentityUserClaimDto, IdentityUserClaim>().Ignore(x => x.TenantId).Ignore(x => x.Id);
			CreateMap<IdentityRoleClaim, IdentityRoleClaimDto>();
			CreateMap<IdentityRoleClaimDto, IdentityRoleClaim>().Ignore(x => x.TenantId).Ignore(x => x.Id);
			CreateMap<CreateClaimTypeDto, IdentityClaimType>().Ignore(x => x.IsStatic).Ignore(x => x.Id);
			CreateMap<UpdateClaimTypeDto, IdentityClaimType>().Ignore(x => x.IsStatic).Ignore(x => x.Id);
			CreateMap<IdentityUser, ProfileDto>();
			CreateMap<OrganizationUnit, OrganizationUnitDto>();
			CreateMap<OrganizationUnitRole, OrganizationUnitRoleDto>();
			CreateMap<OrganizationUnit, OrganizationUnitWithDetailsDto>().ForMember(x => x.Roles, opts => opts.Ignore());
			CreateMap<IdentityRole, OrganizationUnitRoleDto>().ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id));
		}
	}
}
