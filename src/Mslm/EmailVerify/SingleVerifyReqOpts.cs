using Mslm.LibNS;

namespace Mslm.EmailVerifyNS
{
    /// <summary>
    /// Represents request options specifically for the single email verification operation.
    /// </summary>
    public class SingleVerifyReqOpts
    {
        public ReqOpts ReqOpts { get; set; }

        public SingleVerifyReqOpts()
        {
            ReqOpts = new ReqOpts();
        }
    }
}
