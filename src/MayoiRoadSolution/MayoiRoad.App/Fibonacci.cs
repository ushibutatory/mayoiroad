using System.Collections.Generic;
using System.Numerics;

namespace MayoiRoad.App
{
    /// <summary>
    /// フィボナッチ数列クラス
    /// </summary>
    public static class Fibonacci
    {
        /// <summary>
        /// 生成済みの数列を取得します。
        /// </summary>
        private static readonly Dictionary<int, BigInteger> _cache = new();

        /// <summary>
        /// フィボナッチ数列の値を取得します。
        /// </summary>
        /// <param name="n">n番目</param>
        /// <returns>値</returns>
        public static BigInteger Value(int n)
        {
            if (!_cache.ContainsKey(n))
            {
                _cache.Add(n, _Calc(n));
            }

            return _cache[n];
        }

        /// <summary>
        /// 指定した引数のフィボナッチ数列の値を計算します。
        /// </summary>
        /// <param name="n">n番目</param>
        /// <returns>値</returns>
        private static BigInteger _Calc(int n) => n switch
        {
            0 => 0,
            1 => 1,
            _ => Value(n - 2) + Value(n - 1),
        };
    }
}
