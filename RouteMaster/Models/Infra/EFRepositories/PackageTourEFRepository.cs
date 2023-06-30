﻿using RouteMaster.Models.Dto;
using RouteMaster.Models.EFModels;
using RouteMaster.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RouteMaster.Models.Infra.Extensions;

namespace RouteMaster.Models.Infra.EFRepositories
{
    public class PackageTourEFRepository : IPackageTourRepository
    {
        private AppDbContext _db;
        public PackageTourEFRepository()
        {
            _db = new AppDbContext();
        }


        public IEnumerable<PackageTourIndexDto> Search()
        {
            var packageTours = _db.PackageTours.Include(p => p.Coupon).ToList().Select(x => x.ToIndexDto());
            return packageTours;                     
        }


        public void Create(PackageTourCreateDto dto)
        {
            PackageTour packageTour= dto.ToEntity();
            _db.PackageTours.Add(packageTour);

            foreach(var vm in dto.Activities)
            {
                Activity activity=vm.ToIndexDto().ToEntity();
                packageTour.Activities.Add(activity);
            }


            //todo Attractions
            //foreach (var attractionDto in dto.Attractions)
            //{
            //    Attraction attraction = attractionDto.ToEntity();
            //    packageTour.Attractions.Add(attraction);
            //}



            foreach (var vm in dto.ExtraServices)
            {
                ExtraService extraService = vm.ToIndexDto().ToEntity();
                packageTour.ExtraServices.Add(extraService);
            }

            _db.SaveChanges();

        }

        public void Delete(int id)
        {
            var packageTour = _db.PackageTours.Find(id);
            _db.PackageTours.Remove(packageTour);
            _db.SaveChanges();
        }



        public void Edit(PackageTourEditDto dto)
        {
            var packageInDb = _db.PackageTours.Find(dto.Id);

            packageInDb.Description = dto.Description;
            packageInDb.Status= dto.Status;
            packageInDb.CouponId = dto.CouponId;

            //packageInDb.Activities.Add(dto.Activities);
            //packageInDb.ExtraServices = dto.ExtraServices;



            packageInDb.Activities.Clear();
            foreach (var vm in dto.Activities)
            {
                var activity = vm.ToIndexDto().ToEntity();
                packageInDb.Activities.Add(activity);  
            }

            //todo Attractions
            //packageInDb.Attractions.Clear();
            //foreach (var vm in dto.Attractions)
            //{
            //    var attraction = vm.ToIndexDto().ToEntity();
            //    packageInDb.Attractions.Add(attraction);
            //}




            packageInDb.ExtraServices.Clear();
            foreach (var vm in dto.ExtraServices)
            {
                var extraService = vm.ToIndexDto().ToEntity();
                packageInDb.ExtraServices.Add(extraService);
            }
            _db.SaveChanges();              

        }

   
    }
}