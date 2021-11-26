using Core;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entitidades.Base
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public DateTime Registration { get; set; }

        public DateTime Alteration { get; set; }

        public bool Lixeira { get; set; }
        public Entity()
        {
            Id = Guid.NewGuid();
            Registration = HorarioDeBrasilia.Get();
            Alteration = HorarioDeBrasilia.Get();
        }

        public void EnviarParaLixeira ()=> Lixeira = true;

        public abstract ValidationResult ValidarEntidade();
    }
}
