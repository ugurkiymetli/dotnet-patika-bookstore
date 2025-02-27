﻿using FluentValidation;
namespace BookStoreWebAPI.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
            //RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(2).When(book => book.Model.Title.Trim() != string.Empty);
            RuleFor(command => command.Model.GenreId).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.AuthorId).NotEmpty().GreaterThan(0);
        }
    }
}
