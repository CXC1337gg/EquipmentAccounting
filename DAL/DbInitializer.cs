using DAL.Entities;
using System.Linq;

namespace DAL
{
    public static class DbInitializer
    {
        public static void EnsureCreatedAndSeed()
        {
            using (var db = new DLADbContext())
            {
                db.Database.EnsureCreated();

                if (!db.Departments.Any())
                {
                    db.Departments.AddRange(
                        new Department { Name = "ИТ отдел", Manager = "Кузнецов А.В." },
                        new Department { Name = "Бухгалтерия", Manager = "Смирнова Е.Н." },
                        new Department { Name = "Отдел продаж", Manager = "Волков Д.С." }
                    );
                    db.SaveChanges();
                }

                if (!db.EquipmentTypes.Any())
                {
                    db.EquipmentTypes.AddRange(
                        new EquipmentType { Name = "Ноутбук" },
                        new EquipmentType { Name = "Проектор" },
                        new EquipmentType { Name = "МФУ (Многофункциональное устройство)" }
                    );
                    db.SaveChanges();
                }
            }
        }
    }
}