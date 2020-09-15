using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.EfCore.Domains
{
    /// <summary>
    /// Define a classe BaseDomain que tem a funcção de abstrair o Guid Id das outras classes
    /// </summary>
    public abstract class BaseDomain
    {
        [Key]
        public Guid Id { get; private set; }

        public BaseDomain()
        {
            Id = Guid.NewGuid();
        }

        public void setId(Guid id)
        {
            this.Id = id;
        }
    }
}