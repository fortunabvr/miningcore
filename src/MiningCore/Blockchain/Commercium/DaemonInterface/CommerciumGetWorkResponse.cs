namespace MiningCore.Blockchain.Commercium.DaemonInterface
{

    public class CommerciumGetWork
    {

        /// <summary>
        /// The hash target
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// data encoded in hexadecimal (byte-for-byte)
        /// </summary>
        public string Data { get; set; }


    }
}