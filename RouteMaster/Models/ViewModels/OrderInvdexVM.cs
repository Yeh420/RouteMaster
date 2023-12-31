﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace RouteMaster.Models.ViewModels
{
	public class OrderIndexVM
	{

		[Display(Name = "訂單編號")]
		public int Id { get; set; }

		[Display(Name = "訂購人編號")]
		public int MemberId { get; set; }
		[Display(Name = "訂購人")]
		public string MemberName { get; set; }

		[Display(Name = "電子信箱")]
		public string MemberEmail { get; set; }
		[Display(Name = "付款方式")]
		//public int PaymentMethodId { get; set; }
		
		public string PaymentMethodName { get; set; }
		
		[Display(Name = "付款狀態")]
		public int PaymentStatus { get; set; }

		[Display(Name = "付款狀態")]
		public string PaymentStatusText
		{
			get
			{
				switch (PaymentStatus)
				{
					case 1:
						return "已付款";
					case 2:
						return "未付款";
					case 3:
						return "已取消";
					default:
						return "未知狀態";
				}
			}
		}
		//private string GetPaymentStatusText(int paymentStatus)
		//{
		//	switch (paymentStatus)
		//	{
		//		case 1:
		//			return "已付款";
		//		case 2:
		//			return "未付款";
		//		case 3:
		//			return "已取消";
		//		default:
		//			return "未知狀態";
		//	}
		//}

		[Display(Name = "訂購日期")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
		public DateTime? CreateDate { get; set; }
		
		[Display(Name = "金額")]
		[DisplayFormat(DataFormatString = "${0:#,#}")]
		public int Total { get; set; }
		public bool IsSuccess { get; set; } = false;
	}
}