using Domain.Entitidades.Base;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entitidades
{
    public class Fornecedor : Entity
    {

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public Guid IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }
        private Fornecedor() { }

        public Fornecedor(string nome, string telefone, DateTime datanascimento)
        {
            Nome = nome;
            Telefone = telefone;
            DataNascimento = datanascimento;
        }

        public void Atualizar(string nome, string telefone, DateTime datanascimento)
        {
            Nome = nome;
            Telefone = telefone;
            DataNascimento = datanascimento;
        }

        public class ForcendorValidador : AbstractValidator<Fornecedor>
        {
            public ForcendorValidador()
            {
                RuleFor(x => x.Nome)
                    .NotEmpty()
                    .NotNull()
                    .MinimumLength(50)
                    .MaximumLength(150)
                    .WithMessage("Digite Nome do Fornecedor");

                RuleFor(x => x.Telefone)
                    .NotNull()
                    .NotEmpty()
                    .MinimumLength(6)
                    .MaximumLength(14)
                    .WithMessage("Digite Seu numero");

                RuleFor(x => x.DataNascimento)
                    .NotNull()
                    .LessThan(DateTime.Now)
                    .GreaterThan(DateTime.Now.AddYears(-120))
                    .WithMessage("Tem que ser maior de 18 anos ");

            }
        }

        public override ValidationResult ValidarEntidade()
        {
            return new ForcendorValidador().Validate(this);
        }

    }
}
