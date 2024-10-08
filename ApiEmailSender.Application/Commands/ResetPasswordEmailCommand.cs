﻿namespace ApiEmailSender.Application.Commands
{
    public class ResetPasswordEmailCommand : IRequest<BaseResponse>
    {
        public ResetPasswordEmailCommand(ResetPasswordEmailDto resetPasswordEmail)
        {
            ResetPasswordEmail = resetPasswordEmail;        
        }
        public ResetPasswordEmailDto ResetPasswordEmail { get; set; }
    }
}
