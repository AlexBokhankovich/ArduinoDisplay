namespace ArduinoDisplay.MatrixOrbitalProtocol
{
    #region

    using System.Text;

    using ArduinoDisplay.DisplayInterface;

    #endregion

    /// <summary>
    ///     The protocol.
    /// </summary>
    public class MatrixOrbitalProtocol : ICommunicationProtocol<ByteLengthWrapper>
    {
        /// <summary>
        /// The acscii encoding.
        /// </summary>
        private readonly ASCIIEncoding acsciiEncoding;

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixOrbitalProtocol"/> class.
        /// </summary>
        public MatrixOrbitalProtocol() => this.acsciiEncoding = new ASCIIEncoding();

        /// <summary>
        /// The prepare data.
        /// </summary>
        /// <param name="strData">
        /// The str data.
        /// </param>
        /// <returns>
        /// The <see cref="ByteLengthWrapper"/>.
        /// </returns>
        public ByteLengthWrapper PrepareData(string strData)
        {
            return new ByteLengthWrapper()
                       {
                           Data = this.acsciiEncoding.GetBytes(strData),
                           Length = this.acsciiEncoding.GetByteCount(strData)
                       };
        }
    }
}