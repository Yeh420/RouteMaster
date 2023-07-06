﻿using RouteMaster.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteMaster.Models.Interfaces
{
	public interface IAdministratorRepository
	{
		void Register(AdministratorRegisterDto dto);

		bool ExistEmail(string email); //判斷註冊信箱是否存在
	}
}
