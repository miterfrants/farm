using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Homo.FarmApi
{
    public class StrawberryMachineLearningRawDataservice
    {

        public static StrawberryMachineLearningRaw Create(FarmDbContext dbContext, DTOs.StrawberryMachineLearningRaw dto)
        {
            StrawberryMachineLearningRaw record = new StrawberryMachineLearningRaw();
            foreach (var propOfDTO in dto.GetType().GetProperties())
            {
                var value = propOfDTO.GetValue(dto);
                var prop = record.GetType().GetProperty(propOfDTO.Name);
                prop.SetValue(record, value);
            }
            record.CreatedAt = System.DateTime.Now;
            dbContext.StrawberryMachineLearningRaw.Add(record);
            dbContext.SaveChanges();
            return record;
        }

      
    }
}
