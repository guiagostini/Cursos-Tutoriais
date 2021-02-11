﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Musicas.Web.Identity
{
    public class MusicasIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public MusicasIdentityDbContext()
            :base("MusicasDbContext")
        {

        }
    }
}