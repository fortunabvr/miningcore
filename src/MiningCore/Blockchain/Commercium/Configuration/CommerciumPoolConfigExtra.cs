/*
Copyright 2018 Commercium (cmm.co)
*/

using MiningCore.Configuration;

namespace MiningCore.Blockchain.Commercium.Configuration
{
    public class CommerciumPoolConfigExtra
    {
        /// <summary>
        /// Maximum number of tracked jobs.
        /// Default: 12 - you should increase this value if your blockrefreshinterval is higher than 300ms
        /// </summary>
        public int? MaxActiveJobs { get; set; }

        /// <summary>
        /// Blocktemplate stream published via ZMQ
        /// </summary>
        public ZmqPubSubEndpointConfig BtStream { get; set; }
        
        /// <summary>
        /// Optional config of seperated wallet deamon
        /// </summary>
        public DaemonEndpointConfig[] Wallets { get; set; }
        
        public int? MinimumConfirmations { get; set; }
    }
}