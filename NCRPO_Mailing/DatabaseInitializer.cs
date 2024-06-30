using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCRPO_Mailing
{
    internal class DatabaseInitializer
    {
        private readonly ncrpoContext _context;
        public DatabaseInitializer(ncrpoContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                // Проверка подключения к базе данных
                if (!_context.Database.CanConnect())
                {
                   
                    _context.Database.EnsureCreated();

                    
                    SeedDatabase();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void SeedDatabase()
        {
            
            var departments = new List<Departments>
            {
                new Departments { Name = "IT Department", Password = "it123" },
                new Departments { Name = "HR Department", Password = "hr123" }
            };

                  
            var directors = new List<Directors>
            {
                new Directors { Name = "Ivan", Patronymic = "Ivanovich", Surname = "Ivanov" },
                new Directors { Name = "Petr", Patronymic = "Petrovich", Surname = "Petrov" }
            };

                  
            var positions = new List<Positions>
            {
                new Positions { Name = "Developer" },
                new Positions { Name = "HR Manager" }
            };

                   
            var regions = new List<Regions>
            {
                new Regions { Name = "Moscow" },
                new Regions { Name = "Saint Petersburg" }
            };

              
            var types = new List<Types>
            {
                new Types { Name = "Школа" },
                new Types { Name = "Колледж" }
            };

                   
            var organizations = new List<Organizations>
            {
                new Organizations { Name = "TechCorp", ShortName = "TC", Address = "Tech Street 1", Email = "info@techcorp.com", Inn = "1234567890", PhoneNumber = "123-456-7890", Website = "www.techcorp.com", DirectorId = 1, RegionId = 1, TypeId = 1 },
                new Organizations { Name = "HRCorp", ShortName = "HR", Address = "HR Street 1", Email = "info@hrcorp.com", Inn = "0987654321", PhoneNumber = "098-765-4321", Website = "www.hrcorp.com", DirectorId = 2, RegionId = 2, TypeId = 2 }
            };

                   
            var employees = new List<Employees>
            {
                new Employees { Name = "John", Surname = "Doe", Patronymic = "N/A", DepartmentId = 1, PositionId = 1 },
                new Employees { Name = "Jane", Surname = "Doe", Patronymic = "N/A", DepartmentId = 2, PositionId = 2 }
            };

                  
            var emails = new List<Emails>
            {
                new Emails { Email = "londanv@yandex.ru", Password = "bbpbdtirrlabjpck", DepartmentId = 2 },
                new Emails { Email = "testmail89_89@mail.ru", Password = "q7CmemJshdUagPhP6mpt", DepartmentId = 2 },
                new Emails { Email = "emtityMail@yandex.ru", Password = "password", DepartmentId = 1 },
                new Emails { Email = "emtityMail@mail.ru", Password = "password", DepartmentId = 1 }
            };

                    
            var signatures = new List<Signatures>
            {
                new Signatures { DepartmentId = 1 },
                new Signatures { DepartmentId = 2 }
            };

            // Добавляем данные в контекст
            _context.Departments.AddRange(departments);
            _context.Directors.AddRange(directors);
            _context.Positions.AddRange(positions);
            _context.Regions.AddRange(regions);
            _context.Types.AddRange(types);
            _context.Organizations.AddRange(organizations);
            _context.Employees.AddRange(employees);
            _context.Emails.AddRange(emails);
            _context.Signatures.AddRange(signatures);

            
            _context.SaveChanges();
        }

    }
}
