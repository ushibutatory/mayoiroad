using System;

namespace MayoiRoad.App
{
    /// <summary>
    /// マヨイドーロ問題回答
    /// </summary>
    public class Program
    {
        /// <summary>
        /// エントリポイント
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // 計算機を生成
            var calculator = new Calculator();

            // 処理本体
            var execute = new Action<int>((n) =>
            {
                var start = DateTime.Now;
                var p = calculator.Execute(n);
                var end = DateTime.Now;

                Console.WriteLine("Time:{0}, N:{1}, P:{2}", (end - start).ToString(@"hh\:mm\:ss\.ffffff"), n, p);
            });

            try
            {
                // 引数の数による分岐
                switch (args.Length)
                {
                    case 1:
                        if (int.TryParse(args[0], out var n))
                        {
                            Console.WriteLine("N={0}を計算中...", n);
                            execute(n);
                        }
                        else
                        {
                            Console.WriteLine("数値を指定してね");
                        }
                        break;
                    case 2:
                        if (int.TryParse(args[0], out var n1) && int.TryParse(args[1], out var n2))
                        {
                            Console.WriteLine("N={0}から順に計算中...", n1);
                            for (var i = n1; i <= n2; i++)
                            {
                                execute(i);
                            }
                        }
                        else
                        {
                            Console.WriteLine("数値を指定してね");
                        }
                        break;
                    default:
                        Console.WriteLine("Nを数値で指定してね");
                        Console.WriteLine("例）MayoiRoad.exe 10");
                        Console.WriteLine("例）MayoiRoad.exe 1 10");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("--");
        }
    }
}
