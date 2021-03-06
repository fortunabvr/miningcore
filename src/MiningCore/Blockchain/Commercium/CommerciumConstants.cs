/*
Copyright 2017 Coin Foundry (coinfoundry.org)
Authors: Oliver Weichhold (oliver@weichhold.com)

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
associated documentation files (the "Software"), to deal in the Software without restriction,
including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial
portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT
LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using MiningCore.Blockchain.Bitcoin;
using MiningCore.Configuration;
using MiningCore.Crypto.Hashing.Equihash;
using NBitcoin;
using NBitcoin.BouncyCastle.Math;

namespace MiningCore.Blockchain.Commercium
{
    public class CommerciumChainConfig
    {
        public BigInteger Diff1;
        public System.Numerics.BigInteger Diff1b;
        public int SolutionSize { get; set; } = 100;
        public Func<EquihashSolverBase> Solver { get; set; } = () => CommerciumConstants.EquihashSolver_144_5;
    }

    public class CommerciumConstants
    {
        public const int TargetPaddingLength = 32;

        private static readonly Network CommerciumNetworkMain;
        private static readonly Network CommerciumNetworkTest;

        internal static readonly EquihashSolverBase EquihashSolver_144_5 = new EquihashSolver_Commercium();

        static CommerciumConstants()
        {
            CommerciumNetworkMain = Network.GetNetwork("mainnet");
            CommerciumNetworkTest = Network.GetNetwork("testnet");
        }
        private static readonly Dictionary<BitcoinNetworkType, CommerciumChainConfig> CMMCoinbaseTxConfig = new Dictionary<BitcoinNetworkType, CommerciumChainConfig>
        {
            {
                BitcoinNetworkType.Main, new CommerciumChainConfig
                {
                    Diff1 = new BigInteger("3fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff", 16),
                    Diff1b = System.Numerics.BigInteger.Parse("3fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff", NumberStyles.HexNumber),
                    
                    Solver = () => EquihashSolver_144_5,
                    SolutionSize = 100,
                }
            },
            {
                BitcoinNetworkType.Test, new CommerciumChainConfig
                {
                    Diff1 = new BigInteger("3fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff", 16),
                    Diff1b = System.Numerics.BigInteger.Parse("3fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff", NumberStyles.HexNumber),
                        
                    Solver = () => EquihashSolver_144_5,
                    SolutionSize = 100,
                }
            },
        };

        public static Dictionary<CoinType, Dictionary<BitcoinNetworkType, CommerciumChainConfig>> Chains =
            new Dictionary<CoinType, Dictionary<BitcoinNetworkType, CommerciumChainConfig>>
            {
                { CoinType.CMM, CMMCoinbaseTxConfig },
            };
    }
}
