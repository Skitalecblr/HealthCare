using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.ApiTest.Infrastructure.Helpers
{
    internal class PopulatorHelper
    {
        public static List<string> Families = new List<string>
        {
            "Smirnov",
            "Ivanov",
            "Kuznetsov",
            "Popov",
            "Sokolov",
            "Lebedev",
            "Kozlov",
            "Novikov",
            "Morozov",
            "Petrov",
            "Volkov",
            "Solovyov",
            "Vasilyev",
            "Zaytsev",
            "Pavlov",
            "Semyonov",
            "Golubev",
            "Bogdanov",
            "Vorobyov",
            "Kharitonov",
            "Shubin",
            "Frolov",
            "Kolesnikov",
            "Kiselev",
            "Gavrilov",
            "Belyakov",
            "Denisov",
            "Sorokin",
            "Fadeev"
        };

        public static List<string> Names = new List<string>()
            {
                "Ivan",
                "Aleksandr",
                "Dmitry",
                "Andrey",
                "Sergei",
                "Alexey",
                "Yuri",
                "Vladimir",
                "Pavel",
                "Anatoly",
                "Viktor",
                "Yevgeny",
                "Nikolay",
                "Oleg",
                "Igor",
                "Valentin",
                "Vasiliy",
                "Viktor",
                "Grigory",
                "Yaroslav",
                "Mikhail",
                "Artem",
                "Denis",
                "Stanislav",
                "Semyon",
                "Fyodor",
                "Konstantin",
                "Aleksey",
                "Roman",
                "Boris"
            };

        public static List<string> Surnames = new List<string>()
            {
                "Smirnovich",
                "Ivanovich",
                "Kuznetsovich",
                "Popovich",
                "Sokolovich",
                "Lebedevich",
                "Kovalenkovich",
                "Novikovich",
                "Morozovich",
                "Volkovich",
                "Semyonovich",
                "Golubevich",
                "Bogdanovich",
                "Vorobyovich",
                "Romanovich",
                "Zaitsevich",
                "Pavlovich",
                "Konovalovich",
                "Nikitovich",
                "Dmitrievich",
                "Egorovich",
                "Gusevich",
                "Vishnevskovich",
                "Antonovich",
                "Korolevich",
                "Sergeevich",
                "Belovich",
                "Rodionovich",
                "Medvedevich",
                "Fedorovich"
            };

        public static List<string> Genders = new List<string>()
            {
                "Male",
                "Female",
                "Other",
                "Unknown"
            };

        public static string GetRandomFamily()
        {
            var index = new Random().Next(0, Families.Count - 1);
            return Families[index];
        }

        public static string GetRandomName()
        {
            var index = new Random().Next(0, Names.Count - 1);
            return Names[index];
        }

        public static string GetRandomSurname()
        {
            var index = new Random().Next(0, Surnames.Count - 1);
            return Surnames[index];
        }

        public static string GetRandomGender()
        {
            var index = new Random().Next(0, Genders.Count - 1);
            return Genders[index];
        }

        public static string GetRandomDateTime()
        {
            DateTime minDateTime = new DateTime(1950, 1, 1);
            DateTime maxDateTime = DateTime.Now;
            Random random = new Random();
            TimeSpan timeSpan = new TimeSpan((long)(random.NextDouble() * (maxDateTime - minDateTime).Ticks));
            DateTime randomDateTime = minDateTime + timeSpan;

            return randomDateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        }
    }
}
