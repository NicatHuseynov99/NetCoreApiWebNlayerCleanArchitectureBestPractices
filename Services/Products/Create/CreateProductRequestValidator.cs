using App.Repositories.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Products.Create
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductRequestValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required")
                .NotEmpty().WithMessage("Name is required")
                .Length(3, 10).WithMessage("Name must be between 3 and 10 characters");
            //.Must(MustUniqueProductName).WithMessage("Product already exists");
            RuleFor(x => x.Price).NotNull()
                .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
        //1.way sync validation
        //private bool MustUniqueProductName(string name)
        //{
        //    return !_productRepository.Where(p => p.Name == name).Any();
        //}

    }
}
