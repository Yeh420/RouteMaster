﻿using RouteMaster.Models.Dto;
using RouteMaster.Models.Infra.Criterias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteMaster.Models.Interfaces
{
	public interface IComments_AttractionsRepository
	{
		IEnumerable<Comments_AttractionsIndexDto> Search(Comments_AttractionCriteria criteria);
	}
}