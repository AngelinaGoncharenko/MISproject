using System;
using System.IO;
using DbClasses;
using DbClasses.Models;

namespace DataGenerator
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            // Создаем экземпляр контекста базы данных
            using (var context = new MISdbContext())
            {
                // Генерируем 100 записей пациентов
                for (int i = 0; i < 100; i++)
                {
                    var medCard = GenerateRandomMedCard();
                    context.MedCard.Add(medCard);

                    var patient = GenerateRandomPatient(medCard);
                    context.Patient.Add(patient);
                }

                // Сохраняем изменения в базе данных
                context.SaveChanges();
            }

            Console.WriteLine("Данные успешно добавлены в базу данных.");
            Console.ReadLine();
        }

        // Метод для генерации случайных данных пациента
        static PatientEntities GenerateRandomPatient(MedCardEntities medCard)
        {
            var rnd = new Random();

            var genders = new[] { 309, 310 };
            var paymentTypes = new[] { 305, 306 };
            var insuranceTypes = new[] { 307, 308 };
            var govTypes = new[] { 304 };

            var patient = new PatientEntities
            {
                name = GenerateRandomRussianName(),
                middleName = GenerateRandomRussianName(),
                lastName = GenerateRandomRussianLastName(),
                pasport = GenerateRandomPassportNumber(),
                birthday = DateTime.Now.AddYears(-rnd.Next(18, 90)),
                gender = new GenderEntities { id = genders[(genders.Length)] }, // Случайно выбираем между 1 и 2
                address = GenerateRandomAddress(),
                number = GenerateRandomPhoneNumber(),
                email = GenerateRandomEmail(),
                policy = rnd.Next(100000, 999999),
                policyDate = DateTime.Now.AddDays(-rnd.Next(30, 365)),
                workPlace = "Работа",
                paiment = new PaimentEntities { Id = paymentTypes[paymentTypes.Length] }, // Случайно выбираем между 1 и 2
                typeInsuranceCompany = new TypeInsuranceEntities { Id = insuranceTypes[insuranceTypes.Length] }, // Случайно выбираем между 1 и 2
                insuranceCompany = "Страховая компания",
                gov = new GovEntities { id = 1}, // Случайно выбираем между 1
                snils = GenerateRandomSnils(),
                medcard = medCard
            };

            return patient;
        }

        // Метод для генерации случайных данных для медкарты
        static MedCardEntities GenerateRandomMedCard()
        {
            var medCard = new MedCardEntities
            {
                
                dateCreateMedCard = DateTime.Now,
                // appointment и medHistory оставляем пустыми
                photoPatients = GetRandomPhotoPath()
            };

            return medCard;
        }

        // Метод для генерации случайного русского имени
        static string GenerateRandomRussianName()
        {
            var names = new[] { "Иван", "Петр", "Александр", "Михаил", "Елена", "Ольга", "Наталья", "Татьяна" };
            return names[rnd.Next(names.Length)];
        }

        // Метод для генерации случайной русской фамилии
        static string GenerateRandomRussianLastName()
        {
            var lastNames = new[] { "Иванов", "Петров", "Сидоров", "Кузнецов", "Михайлова", "Егорова", "Павлова", "Смирнова" };
            return lastNames[rnd.Next(lastNames.Length)];
        }

        // Метод для генерации случайного номера паспорта
        static string GenerateRandomPassportNumber()
        {
            return rnd.Next(100000000, 999999999).ToString();
        }

        static string GeneratedRandomAddress()
        {
            var street = new[] { "Набережная", "Уральская", "Высотная", "Кравченко", "Михайлова", "Конституции", "Павлова", "Смирнова" };
            return street[rnd.Next(street.Length)];
        }

        // Метод для генерации случайного адреса
        static string GenerateRandomAddress()
        {
            return $"{rnd.Next(1, 200)}, ул. {GeneratedRandomAddress()}, д. {rnd.Next(1, 100)}";
        }

        // Метод для генерации случайного номера телефона
        static string GenerateRandomPhoneNumber()
        {
            return $"+7({rnd.Next(100, 999)}){rnd.Next(1000000, 9999999)}";
        }

        // Метод для генерации случайного email
        static string GenerateRandomEmail()
        {
            return $"user{rnd.Next(1000, 9999)}@example.com";
        }

        // Метод для генерации случайного СНИЛСа
        static string GenerateRandomSnils()
        {
            return $"{rnd.Next(100, 999)}-{rnd.Next(100, 999)}-{rnd.Next(100, 999)} {rnd.Next(10, 99)}";
        }

        // Метод для получения случайного пути к фото
        static string GetRandomPhotoPath()
        {
            // Предположим, что фото находятся в одной директории и имеют расширение .jpeg
            var photoDir = @"D:\Загрузки\Photo";
            var files = Directory.GetFiles(photoDir, "*.jpg");
            return files[rnd.Next(files.Length)];
        }
    }
}
