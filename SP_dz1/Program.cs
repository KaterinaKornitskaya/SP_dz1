using System.Runtime.InteropServices;

namespace SP_dz1
{
    internal class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);
        static void Main(string[] args)
        {
            // Задание 1
            // написать приложение, позволяющее вывести на экран краткое резюме
            // с помощью окон сообщений. На заголовке последнего окна должно
            // отобразиться среднее число чимволов на странице.

            string[] myCv =
            {
                "Kateryna Kornytska",
                "Age: 29",
                "University: IT Step Odessa",
                "Department: Software Development"
            };
            string headMessage = "My CV";
            double symbCount = 0;

            for (int i = 0; i < myCv.Length; i++)
            {
                symbCount += myCv[i].Length;
                if (i == myCv.Length - 1)
                {
                    headMessage = "Strings avg length: " + (symbCount / myCv.Length).ToString();
                }
                MessageBox(new IntPtr(0), myCv[i], headMessage, 1);

            }


            // Задание 2
            // Приложение угадывает задуманные пользователем числа от 1 до 100
            // Для запроса к полбзователю используются окна сообщений.
            // После того, как число угадано, необходимо вывести кол-во
            // попыток, и предоставить пользователю возможность сыграть еще раз,
            // не завершая программу.

            int userSay = 0;
            int tryCount = 0;

            while(userSay!=2)
            {
                do
                {
                    tryCount++;
                    userSay = MessageBox(new IntPtr(0), new Random().Next(0, 100).ToString(), "Guessing game", 3);

                } while (userSay!=6 && userSay!=2);
                userSay = MessageBox(new IntPtr(0), $"I won in {tryCount} tries. Let's play again?", "Guessing game", 1);
                tryCount = 0;
            }
        }
    }
}
