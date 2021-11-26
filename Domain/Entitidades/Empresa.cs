using Domain.Entitidades.Base;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entitidades
{
    public class Empresa : Entity
    {
        public  string UF { get; set; }
        public string NomeFantasma { get; set; }
        public string CNPJ { get; set; }

        private Empresa(){}

        public Empresa(string uf,string nomefantasma,string cnpj)
        {
            UF = uf;
            NomeFantasma=nomefantasma;
            CNPJ = cnpj;
        }

        public void Atualizar(string uf, string nomefantasma, string cnpj)
        {
            UF = uf;
            NomeFantasma = nomefantasma;
            CNPJ = cnpj;
        }


        public class EmpresaValidador : AbstractValidator<Empresa>
        {
            public EmpresaValidador()
            {
                RuleFor(x => x.UF)
                    .NotEmpty()
                    .NotNull()
                    .MaximumLength(2)
                    .WithMessage("digita abreviação do seu UF ex: ");
    
               RuleFor(x => x.NomeFantasma)
                .NotEmpty()
                .NotNull()
                .MinimumLength(20)
                .MaximumLength(150)
                .WithMessage("Digite nome fantasma da sua Empresa");

                RuleFor(x => x.CNPJ)
                    .NotEmpty()
                    .NotNull()
                    .MaximumLength(11)
                    .WithMessage("O campo CNPJ nao pode ter mais de 11 numeros");



            }


        }

        public override ValidationResult ValidarEntidade()
        {
            return new EmpresaValidador().Validate(this);
        }
    }

}
