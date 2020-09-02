using System;
using System.Collections.Generic;
using System.Numerics;

namespace MayoiRoad.App
{
    /// <summary>
    /// マヨイドーロ問題の計算機
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// 折り返し数ごとのYルート数リスト
        /// </summary>
        /// <remarks>
        /// Key  :折り返し数
        /// Value:Yルート数
        /// </remarks>
        private readonly Dictionary<int, BigInteger> _list = new Dictionary<int, BigInteger>();

        /// <summary>
        /// Pを計算します。
        /// </summary>
        /// <param name="N">最大折り返し数N</param>
        /// <returns></returns>
        /// <remarks>
        /// 問題文の表記と合わせるため、敢えて変数名を大文字の「N」にしています。
        /// </remarks>
        public BigInteger Execute(int N)
        {
            var p = (BigInteger)0;

            // 0～NまでのYルート数を合算する
            for (var i = 0; i <= N; i++)
            {
                if (!_list.ContainsKey(i))
                {
                    // 未計算の場合
                    var value = (i % 2) switch
                    {
                        // 偶数の時はすべてZルートなので常に0
                        0 => 0,
                        1 => Fibonacci.Value(i) + Fibonacci.Value(i + 1),
                        _ => throw new Exception("ありえないケースなので例外とする。"),
                    };

                    // 格納
                    _list.Add(i, value);
                }

                // 加算
                p += _list[i];
            }

            return p;
        }
    }
}
