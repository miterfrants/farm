using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Homo.FarmApi
{
    public class StrawberryDataservice
    {

        public static Strawberry Create(FarmDbContext dbContext, DTOs.Strawberry dto)
        {
            Strawberry record = new Strawberry();
            foreach (var propOfDTO in dto.GetType().GetProperties())
            {
                var value = propOfDTO.GetValue(dto);
                var prop = record.GetType().GetProperty(propOfDTO.Name);
                prop.SetValue(record, value);
            }
            dbContext.Strawberry.Add(record);
            dbContext.SaveChanges();
            return record;
        }

        public static List<Strawberry> GetAll(FarmDbContext dbContext, DTOs.StrawberryQuery dto)
        {
            return dbContext.Strawberry.Where(x =>
                    (dto.Label == null || x.Label.Contains(dto.Label))
                    && (dto.Spec == null || x.Spec.Contains(dto.Spec))
                ).ToList();
        }

        [Route("{id}")]

        public static Strawberry GetOne(FarmDbContext dbContext, [FromRoute] long id)
        {
            return dbContext.Strawberry.Where(x =>
                    x.Id == id
                ).FirstOrDefault();
        }
    }
}
