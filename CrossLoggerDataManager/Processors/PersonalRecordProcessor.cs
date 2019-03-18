using CrossLoggerDataManager.Data;
using CrossLoggerDataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossLoggerDataManager.Processors
{
    public class PersonalRecordProcessor
    {
        public static string Create(AppDbContext database, PersonalRecord record)
        {
            PersonalRecord newRecord = new PersonalRecord
            {
                Name = record.Name,
                Weight = record.Weight,
                Date = record.Date
            };

            database.Add(newRecord);
            database.SaveChangesAsync();

            return "Record Added";
        }
    }
}
