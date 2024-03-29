﻿using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace Simple.Abp.Account.Emailing
{
	public interface IAccountEmailer
	{
		Task SendPasswordResetLinkAsync(IdentityUser user, string resetToken, string appName);

		Task SendEmailConfirmationLinkAsync(IdentityUser user, string confirmationToken, string appName);
	}
}
