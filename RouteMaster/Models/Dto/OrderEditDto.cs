﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RouteMaster.Models.Dto
{
	public class OrderEditDto
	{
		public int Id { get; set; }

		public int MemberId { get; set; }
		public string MemberName { get; set; }
		public string MemberEmail { get; set; }

		public int PaymentMethodId { get; set; }
		public string PaymentMethodName { get; set; }
		public int TravelPlanId { get; set; }
		public int PaymentStatus { get; set; }

		public DateTime? CreateDate { get; set; }

		public int Total { get; set; }

		
	}
}