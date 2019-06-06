using System;

namespace MayoiRoad
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
		public static void Main(String[] args)
		{
			// 計算機を生成
			var calculator = new Calculator();

			// 処理本体
			var execute = new Action<Int32>((n) =>
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
						Int32 n;
						if (Int32.TryParse(args[0], out n))
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
						Int32 n1;
						Int32 n2;
						if (Int32.TryParse(args[0], out n1) && Int32.TryParse(args[1], out n2))
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
