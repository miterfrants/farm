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

        public static List<ViewRelationOfStrawberryAndLog> GetAll(FarmDbContext dbContext, DTOs.StrawberryQuery dto)
        {
            List<Strawberry> list = dbContext.Strawberry
            .Where(x =>
                    (dto.Label == null || x.Label.Contains(dto.Label))
                    && (dto.Spec == null || x.Spec.Contains(dto.Spec)))
            .ToList();

            List<StrawberryLog> lastLogs = StrawberryLogDataservice.GetLast(dbContext, list.Select(x => x.Id).ToList<long>());

            return list.Select(x =>
                new ViewRelationOfStrawberryAndLog
                {
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    Label = x.Label,
                    Spec = x.Spec,
                    InitialState = x.InitialState,
                    Situation = x.Situation,
                    BornFrom = x.BornFrom,
                    CurrentState = lastLogs.Where(item => item.StrawberryId == x.Id).FirstOrDefault()?.CurrentState
                }).ToList();
        }

        public static Strawberry GetOne(FarmDbContext dbContext, [FromRoute] long id)
        {
            return dbContext.Strawberry.Where(x =>
                    x.Id == id
                ).FirstOrDefault();
        }

    }

    public class ViewRelationOfStrawberryAndLog
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Label { get; set; }
        public string Spec { get; set; }
        public string InitialState { get; set; }
        public string Situation { get; set; }
        public BORN_FORM BornFrom { get; set; }
        public string CurrentState { get; set; }
    }

}
