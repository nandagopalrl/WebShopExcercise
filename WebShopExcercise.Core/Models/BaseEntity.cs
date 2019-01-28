﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopExcercise.Core.Models
{
    public abstract class BaseEntity
    {
        public string Id { get;}
        public DateTimeOffset CreatedAt { get;}

        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.Now;
        }
    }
}
