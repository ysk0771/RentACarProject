using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Cars>
    {
        public CarValidator()
        {
            RuleFor(p => p.Descriptions).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(0);
            RuleFor(p => p.Descriptions).MinimumLength(2);
            RuleFor(p => p.DailyPrice).NotEmpty();//.withmessage ile verilecek hata mesajını yazabiliriz
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(10).When(p => p.BrandId == 2);
        }
    }
}
