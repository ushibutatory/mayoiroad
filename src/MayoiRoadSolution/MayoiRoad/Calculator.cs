using System;
using System.Collections.Generic;
using System.Numerics;

namespace MayoiRoad
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
		private Dictionary<Int32, BigInteger> _list = new Dictionary<Int32, BigInteger>();

		/// <summary>
		/// Pを計算します。
		/// </summary>
		/// <param name="N">最大折り返し数N</param>
		/// <returns></returns>
		public BigInteger Execute(Int32 N)
		{
			var p = (BigInteger)0;

			// 0～NまでのYルート数を合算する
			for (var i = 0; i <= N; i++)
			{
				if (!this._list.ContainsKey(i))
				{
					// 未計算の場合
					var value = (BigInteger)0;
					switch (i % 2)
					{
						case 0:
							// 偶数の時はすべてZルートなので常に0
							value = 0;
							break;
						case 1:
							value = Fibonacci.Value(i) + Fibonacci.Value(i + 1);
							break;
					}

					// 格納
					this._list.Add(i, value);
				}

				// 加算
				p += this._list[i];
			}

			return p;
		}
	}

	/// <summary>
	/// フィボナッチ数列クラス
	/// </summary>
	public static class Fibonacci
	{
		#region Private変数
		/// <summary>
		/// フィボナッチ数列
		/// </summary>
		/// <remarks>
		/// singleton
		/// </remarks>
		private static Dictionary<Int32, BigInteger> _list = new Dictionary<Int32, BigInteger>();
		#endregion

		#region プロパティ
		/// <summary>
		/// 生成済みの数列を取得します。
		/// </summary>
		public static Dictionary<Int32, BigInteger> List
		{
			get { return _list; }
		}
		#endregion

		#region Publicメソッド
		/// <summary>
		/// フィボナッチ数列の値を取得します。
		/// </summary>
		/// <param name="n">n番目</param>
		/// <returns>値</returns>
		public static BigInteger Value(Int32 n)
		{
			var value = (BigInteger)0;

			if (!_list.ContainsKey(n))
			{
				// 計算
				value = _Calc(n);

				// 格納
				_list.Add(n, value);
			}

			return _list[n];
		}
		#endregion

		#region Privateメソッド
		/// <summary>
		/// 指定した引数のフィボナッチ数列の値を計算します。
		/// </summary>
		/// <param name="n">n番目</param>
		/// <returns>値</returns>
		private static BigInteger _Calc(Int32 n)
		{
			var value = (BigInteger)0;

			switch (n)
			{
				case 0:
					value = 0;
					break;
				case 1:
					value = 1;
					break;
				default:
					value = Fibonacci.Value(n - 2) + Fibonacci.Value(n - 1);
					break;
			}

			return value;
		}
		#endregion
	}
}
