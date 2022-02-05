﻿using System.Collections.Generic;
using System.Linq;
using EntityFrameworkModel;

namespace SpecificationsTesting.Business
{
    public class BTemplateMotor
    {
        public static TemplateMotor Create(TemplateMotor templateMotor)
        {
            using (var dbContext = new SpecificationsDatabaseModel())
            {
                dbContext.TemplateMotors.Add(templateMotor);
                dbContext.SaveChanges();
                return templateMotor;
            }
        }

        public static List<TemplateMotor> GetAll()
        {
            using (var dbContext = new SpecificationsDatabaseModel())
            {
                return dbContext.TemplateMotors.ToList();
            }
        }

        public static TemplateMotor GetById(int id)
        {
            using (var dbContext = new SpecificationsDatabaseModel())
            {
                return dbContext.TemplateMotors.Find(id);
            }
        }

    }
}
