using AutoMapper;
using Simple.Abp.AuditLogging.Dtos;
using Volo.Abp.AuditLogging;

namespace Simple.Abp.AuditLogging
{
    public class AbpAuditLoggingApplicationAutoMapperProfile : Profile
	{
		public AbpAuditLoggingApplicationAutoMapperProfile()
		{
			base.CreateMap<AuditLog, AuditLogDto>().MapExtraProperties();
			base.CreateMap<EntityChange, EntityChangeDto>().MapExtraProperties();
			base.CreateMap<EntityChangeWithUsername, EntityChangeWithUsernameDto>();
			base.CreateMap<EntityPropertyChange, EntityPropertyChangeDto>();
			base.CreateMap<AuditLogAction, AuditLogActionDto>().MapExtraProperties();
		}
	}
}
