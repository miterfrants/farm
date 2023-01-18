using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Homo.FarmApi
{
    public class StrawberryLogDataservice
    {

        public static StrawberryLog Create(FarmDbContext dbContext, long strawberryId, DTOs.StrawberryLog dto)
        {
            StrawberryLog record = new StrawberryLog();
            foreach (var propOfDTO in dto.GetType().GetProperties())
            {
                var value = propOfDTO.GetValue(dto);
                var prop = record.GetType().GetProperty(propOfDTO.Name);
                prop.SetValue(record, value);
            }
            record.StrawberryId = strawberryId;
            dbContext.StrawberryLog.Add(record);
            dbContext.SaveChanges();
            return record;
        }

        public static List<StrawberryLog> GetList(FarmDbContext dbContext, long strawberryId, DateTime? startAt, DateTime? endAt, int page, int limit)
        {
            return dbContext.StrawberryLog.Where(x =>
                    x.StrawberryId == strawberryId
                    && (startAt == null || x.CreatedAt >= startAt)
                    && (endAt == null || x.CreatedAt <= endAt)
                ).OrderByDescending(x => x.CreatedAt).Skip((page - 1) * limit).Take(limit).ToList();
        }

        public static List<StrawberryLog> GetLast(FarmDbContext dbContext, List<long> strawberryId)
        {
            return dbContext.StrawberryLog.Where(x =>
                strawberryId.Contains(x.StrawberryId)
            ).OrderBy(x => x.StrawberryId)
            .ThenByDescending(x => x.CreatedAt)
            .ThenBy(x => x.Id)
            .ToList()
            .GroupBy(x => x.StrawberryId)
            .Select(x => x.First())
            .ToList();
        }


        public static StrawberryLog GetOne(FarmDbContext dbContext, long id)
        {
            return dbContext.StrawberryLog.Where(x =>
                    x.Id == id
                ).FirstOrDefault();
        }

        public static void Update(FarmDbContext dbContext, long id, DTOs.StrawberryLog dto)
        {
            StrawberryLog record = dbContext.StrawberryLog.Where(x => x.Id == id).FirstOrDefault();
            foreach (var propOfDTO in dto.GetType().GetProperties())
            {
                var value = propOfDTO.GetValue(dto);
                var prop = record.GetType().GetProperty(propOfDTO.Name);
                prop.SetValue(record, value);
            }
            dbContext.SaveChanges();
        }
    }
}
