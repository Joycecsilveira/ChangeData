using System;

namespace ChangeData
{
    class Program
    {
        static void Main()
        {
            string dateString = ReadDateString();
            DateTime date = DateTime.ParseExact(dateString, "dd/MM/yyyy HH:mm", null);

            
            char op = ReadDateChar(); 

            Console.WriteLine("\n Digite a quantidade desejada na operação:");
            long value = long.Parse(Console.ReadLine());

            string novaData = ChangeDate(date.ToString("dd/MM/yyyy HH:mm"), op, value);
            Console.WriteLine($"Nova data: {novaData}");
            Console.ReadLine();
        }

        private static char ReadDateChar()
        {
            Console.WriteLine("Se você deseja acrescentar minutos na data, digite '+'. Se preferir subtrair, digite '-' : ");
            char op = Console.ReadKey().KeyChar;

            if (op == '+' || op == '-')
            {
                return op;
            }
            else
            {
                return ReadDateChar();
            }
        }

        static string ReadDateString()
        {
            Console.WriteLine("Digite uma data no formato a seguir: dd/MM/yyyy HH:mm: ");
            string dateString = Console.ReadLine();

            if (DateTime.TryParseExact(dateString, "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out _))
            {
                return dateString;
            }
            else
            {
                Console.WriteLine("Formato de data inválido. A data inserida deve ser no formato 'dd/MM/yyyy HH:mm'.");
                return ReadDateString();
            }
        }

        public static string ChangeDate(string date, char op, long value)
        {
            if (DateTime.TryParseExact(date, "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime time))
            {
                if (op == '+')
                    time = time.AddMinutes(value);
                else if (op == '-')
                    time = time.AddMinutes(-value);

                //Console.WriteLine("Minutos atualizados na data específicada:" + "" + time.ToString("dd/MM/yyyy HH:mm"));
                return time.ToString("dd/MM/yyyy HH:mm");
            }
            else
            {
                return "Formato de data inválido. Por favor, defina uma data no formato 'dd/MM/yyyy HH:mm'.";
            }
        }
    }
}
