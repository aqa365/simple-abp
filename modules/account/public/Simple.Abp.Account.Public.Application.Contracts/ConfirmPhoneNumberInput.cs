using System.ComponentModel.DataAnnotations;

namespace Simple.Abp.Account
{
	public class ConfirmPhoneNumberInput
	{
		[Required]
		public string Token { get; set; }
	}
}
