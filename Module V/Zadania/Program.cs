using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zadania
{
    internal class Program
	{
        private static void Main(string[] args)
		{
			Caesar();
			ShannonFano();
			Huffman();
			Console.WriteLine();
            Console.ReadLine();
		}


        private static void Caesar()
		{
			Console.WriteLine("\n[###] Caesar Encryption");
			StringBuilder strBuild = new StringBuilder();
			Random random = new Random();

            for (int j = 0; j < 15; j++)
			{
				double flt = random.NextDouble();
				int shift = Convert.ToInt32(Math.Floor(25 * flt));
				var letter = Convert.ToChar(shift + 97);
				strBuild.Append(letter);
			}
			Console.Write("Your shift: ");
			int uShift = Convert.ToInt32(Console.ReadLine());

			string sh = strBuild.ToString();
			Console.WriteLine(sh);
			sh = CaesarEncryption(sh, uShift);
			CaesarDecryption(sh, uShift);
        }


        private static string CaesarEncryption(string message, int key)
		{
            string output = message.Aggregate(string.Empty, (current, ch) => current + (char) ((((ch + key) - 'a') % 26) + 'a'));
            Console.WriteLine(output);
			return output;
		}

        private static void CaesarDecryption(string message, int key)
		{
            CaesarEncryption(message, 26 - key);
		}

        private static void Huffman()
		{
            Console.WriteLine("\n[###] Huffman Encryption");
			const string toCode = "Text to code";
			Tree huffmanTree = new Tree(toCode);

			BitArray encoded = huffmanTree.Encode(toCode);
			Console.WriteLine("[#] Huffman Encrypted Input: ");
			for (int i = 0; i < encoded.Count; i++)
			{
				Console.Write(encoded[i]?"1":"0");

			}
			Console.WriteLine();
			string decoded = huffmanTree.Decode(encoded);
			Console.WriteLine("\n[#] Huffman Decrypted Output: " + decoded);

		}

        private static void ShannonFano()
		{
            Console.WriteLine("\n[###] ShannonFeno Encryption");
			const string toCode = "Text to code";
			Tree shannonTree = new Tree(toCode, 2);

			BitArray encoded = shannonTree.Encode(toCode);
			Console.WriteLine("[#] ShannonFeno Encrypted Input: ");
			for (int i = 0; i < encoded.Count; i++)
			{
				Console.Write(encoded[i] ? "1" : "0");

			}
			Console.WriteLine();
			string decoded = shannonTree.Decode(encoded);
			Console.WriteLine("\n[#] ShannonFeno Decrypted Output: " + decoded);

        }

		public class Node
		{
			public char Symbol { get; set; }
			public int Freq { get; set; }
			public Node NeighbourRight { get; set; }
			public Node NeighbourLeft { get; set; }

			public List<bool> Traverse(char symbol, List<bool> data)
			{

				if (NeighbourRight == null && NeighbourLeft == null)
                {
                    return symbol.Equals(Symbol) ? data : null;
                }

                List<bool> left = null;
                List<bool> right = null;

                if (NeighbourLeft != null)
                {
                    var leftPath = new List<bool>();
                    leftPath.AddRange(data);
                    leftPath.Add(false);

                    left = NeighbourLeft.Traverse(symbol, leftPath);
                }

                if (NeighbourRight == null) return left ?? right;
                var rightPath = new List<bool>();
                rightPath.AddRange(data);
                rightPath.Add(true);
                right = NeighbourRight.Traverse(symbol, rightPath);

                return left ?? right;
            }
		}

        private class Tree
		{
            private readonly int _shano;
            private List<Node> nodes = new List<Node>();
            private Node First { get; set; }
            private Dictionary<char, int> CharFreq = new Dictionary<char, int>();

			public Tree(string source)
			{
				foreach (var t in source)
                {
                    if (!CharFreq.ContainsKey(t))
                    {
                        CharFreq.Add(t, 0);
                    }
                    CharFreq[t]++;
                }

				foreach (var symbol in CharFreq)
				{
					nodes.Add(new Node() { Symbol = symbol.Key, Freq = symbol.Value });
				}

				while (nodes.Count >= 2)
				{

					var orderedNodes = nodes.OrderBy(node => node.Freq).ToList();

					if (orderedNodes.Count >= 2)
					{
						var taken = orderedNodes.Take(2).ToList();
						Node parent = new Node()
						{
							Symbol = '*',
							Freq = taken[0].Freq + taken[1].Freq,
							NeighbourLeft = taken[0],
							NeighbourRight = taken[1]
						};

						nodes.Remove(taken[0]);
						nodes.Remove(taken[1]);
						nodes.Add(parent);
					}

					First = nodes.FirstOrDefault();
				}
			}

			public Tree(string source, int shano)
			{
                _shano = shano;
                foreach (var t in source)
                {
                    if (!CharFreq.ContainsKey(t))
                    {
                        CharFreq.Add(t, 0);
                    }
                    CharFreq[t]++;
                }
				int valueOfAll = 0;
				foreach (var symbol in CharFreq)
				{

					nodes.Add(new Node() { Symbol = symbol.Key, Freq = symbol.Value });
					valueOfAll += symbol.Value;
				}

				var orderedNodes = nodes.OrderByDescending(node => node.Freq).ToList();
				this.First = new Node()
				{
					Symbol = '*',
					Freq = valueOfAll,
					NeighbourLeft = orderedNodes[0],
				};
				orderedNodes.RemoveAt(0);
				ShannonFenoCons(orderedNodes, valueOfAll - First.NeighbourLeft.Freq, First);
            }

            private static void ShannonFenoCons(List<Node> orderedNodes, int value, Node node)
            {
                while (true)
                {
                    if (!orderedNodes.Any()) return;
                    node.NeighbourRight = new Node() {Symbol = '*', Freq = value, NeighbourLeft = orderedNodes[0],};
                    orderedNodes.RemoveAt(0);
                    value -= node.NeighbourLeft.Freq;
                    node = node.NeighbourRight;
                }
            }


            public BitArray Encode(string source)
			{
				var encodedSource = new List<bool>();

				foreach (var encodedSymbol in source.Select(t => this.First.Traverse(t, new List<bool>())))
                {
                    encodedSource.AddRange(encodedSymbol);
                }

				BitArray bits = new BitArray(encodedSource.ToArray());
				return bits;
			}

			public string Decode(BitArray bits)
			{

				Node current = First;
				string decoded = "";

				foreach (bool bit in bits)
				{
					if (bit)
					{
						if (current.NeighbourRight != null)
						{
							current = current.NeighbourRight;
						}
					}
					else
					{
						if (current.NeighbourLeft != null)
						{
							current = current.NeighbourLeft;
						}
					}

                    if (current.NeighbourLeft != null || current.NeighbourRight != null) continue;
                    decoded += current.Symbol;
                    current = First;
                }
                return decoded;
			}
        }
    }
}
