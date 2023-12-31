﻿using RouteMaster.Models.Dto;
using RouteMaster.Models.Dto.Accommodation;
using RouteMaster.Models.Dto.Accommodation.Room;
using RouteMaster.Models.Infra;
using RouteMaster.Models.Interfaces;
using RouteMaster.Models.ViewModels;
using RouteMaster.Models.ViewModels.Accommodations;
using RouteMaster.Models.ViewModels.Accommodations.Room;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RouteMaster.Models.Services
{
	public class AccommodationService
	{
		private readonly IAccommodationRepository _repo;

		public AccommodationService(IAccommodationRepository repo)
		{
			this._repo = repo;
		}

		public IEnumerable<AccommodationIndexDto> Search(int? id)
		{
			return _repo.Search(id);
		}

        public Result Create(AccommodationCreateDto dto)
        {
            if (_repo.ExistName(dto.Name))
            {
				//丟出異常,或者傳回 Result
				return Result.Fail($@"住所名稱: '{dto.Name}'已存在, 請確認後再試一次");
			}

			if (dto.RegionId == 0 || dto.TownId == 0) return Result.Fail("請再確認欄位資料是否正確");

			// 新增一筆紀錄
			_repo.Create(dto);

            return Result.Success();
        }

		public AccommodationEditDto GetEditInfo(int? id)
		{
			return _repo.GetEditInfo(id);
		}

		public Result EditAccommodationProfile(AccommodationEditDto dto, ImagesDto iDto, string path)
		{
			
			if (_repo.ExistName(dto.Name) && !_repo.IsOriginalName(dto))
			{
				//丟出異常,或者傳回 Result
				return Result.Fail($@"住所名稱: '{dto.Name}'已存在, 請確認後再試一次");
			}

			if (dto.RegionId == 0 || dto.TownId == 0) return Result.Fail("請再確認欄位資料是否正確");

			// 新增一筆紀錄
			_repo.EditAccommodationProfile(dto, iDto, path);

			return Result.Success();
			
		}
		public Result EditRoomProfile(RoomEditDto dto, ImagesDto iDto, string path)
		{
			
			if (_repo.ExistRoomName(dto.AccommodationId, dto.Name) && !_repo.IsOriginalRoomName(dto))
			{
				//丟出異常,或者傳回 Result
				return Result.Fail($"這個房間你新增過了喔, 請再確認一下");
			}


			// 新增一筆紀錄
			_repo.EditRoomProfile(dto, iDto, path);

			return Result.Success();
			
		}

		public Result CreateRoomAndImages(RoomCreateDto dto, ImagesDto iDto, String path)
		{
			if (_repo.ExistRoomName(dto.AccommodationId, dto.Name))
			{
				//丟出異常,或者傳回 Result
				return Result.Fail($"這個房間你新增過了喔, 請再確認一下");
			}
			// 新增一筆紀錄
			_repo.CreateRoomAndImages(dto, iDto, path);

			return Result.Success();
		}

		internal Result EditService(ServiceInfoVM vm)
		{
			_repo.EditService(vm);

			return Result.Success();
		}

		internal RoomEditDto GetRoomInfo(int? id)
		{
			return _repo.GetRoomInfo(id);
		}
	}
}