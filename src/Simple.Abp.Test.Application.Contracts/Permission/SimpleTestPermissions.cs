using Volo.Abp.Reflection;

namespace Simple.Abp.Test.Permission
{
    public class SimpleTestPermissions
	{
		public static string[] GetAll()
		{
			return ReflectionHelper.GetPublicConstantsRecursively(typeof(SimpleTestPermissions));
		}

		public const string GroupName = "Venom";

		public class Venom
		{
			public const string Default = "Venom.Configs";
			public const string Aim = "Venom.Aim";
			public const string Rcs = "Venom.Rcs";
			public const string Radar = "Venom.Radar";
			public const string Trigger = "Venom.Trigger";
			public const string Sonar = "Venom.Sonar";
		}
	}
}
