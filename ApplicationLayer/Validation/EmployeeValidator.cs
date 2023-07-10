using DomainLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Validation
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public class OrderValidator : AbstractValidator<Orders>
        {
            public OrderValidator()
            {
                RuleFor(order => order.CustomerName)
                    .NotEmpty().WithMessage("Name cannot be empty.")
                    .Length(1, 50).WithMessage("The name must be between 2 and 50 characters.");

                RuleFor(order => order.OrderDate)
        .Must(date => date >= new DateTime(2022, 1, 1) && date <= new DateTime(2024, 12, 31))
        .WithMessage("The order date must be between 2022 and 2024.");
                RuleFor(order => order.OrderCompleteDate)
    .Must(date => date >= new DateTime(2022, 1, 1) && date <= new DateTime(2024, 12, 31))
    .WithMessage("The order date must be between 2022 and 2024.");
            }
        }
        public EmployeeValidator()
        {
            RuleFor(employee => employee.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .Length(1, 50).WithMessage("The name must be between 2 and 50 characters.");

            RuleFor(employee => employee.Surname)
            .NotEmpty().WithMessage("Name cannot be empty.")
            .Length(1, 50).WithMessage("The name must be between 2 and 50 characters.");

            RuleFor(employee => employee.Age)
                .InclusiveBetween(18, 99).WithMessage("Age must be between 18 and 99.");
        }

    }
  
}
