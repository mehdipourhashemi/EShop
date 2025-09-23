﻿using IDP.Domain.Entities;
using IDP.Domain.IRepository.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Infra.Repository.Command;

public interface IUserCommandRepository : ICommandRepository<User>
{

}