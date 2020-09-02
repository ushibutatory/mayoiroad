using Microsoft.Extensions.CommandLineUtils;
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
        public static int Main(string[] args)
        {
            var app = new CommandLineApplication(throwOnUnexpectedArg: false)
            {
                Name = "MayoiRoad.App",
            };

            // help
            const string helpOption = "-?|-h|--help";
            app.HelpOption(template: helpOption);

            // 処理本隊
            var execute = new Action<int>((n) =>
            {
                var calculator = new Calculator();
                var start = DateTime.Now;
                var p = calculator.Execute(n);
                var end = DateTime.Now;

                // 結果表示
                Console.WriteLine($"Time:{end - start:hh\\:mm\\:ss\\.ffffff}, N:{n}, P:{p}");
            });

            app.Command("calc", (command) =>
            {
                command.Description = "計算を実行します。";
                command.HelpOption(helpOption);

                var argN = command.Argument("n", "対象の数値");

                command.OnExecute(() =>
                {
                    if (!int.TryParse(argN.Value, out var n))
                        return command.Execute("-h");

                    execute(n);

                    return 0;
                });
            });

            app.Command("list", (command) =>
            {
                command.Description = "まとめて実行します。";
                command.HelpOption(helpOption);

                var argN1 = command.Argument("n1", "開始N");
                var argN2 = command.Argument("n2", "終了N");

                command.OnExecute(() =>
                {
                    if (!int.TryParse(argN1.Value, out var n1))
                        return command.Execute("-h");
                    if (!int.TryParse(argN2.Value, out var n2))
                        return command.Execute("-h");

                    Console.WriteLine("※一度計算したフィボナッチ数はキャッシュするため、計算時間は正確ではありません。");
                    for (var n = n1; n <= n2; n++)
                    {
                        execute(n);
                    }

                    return 0;
                });
            });

            app.OnExecute(() =>
            {
                // 引数なしで実行された場合はヘルプ表示
                return app.Execute("-h");
            });

            return app.Execute(args);
        }
    }
}
