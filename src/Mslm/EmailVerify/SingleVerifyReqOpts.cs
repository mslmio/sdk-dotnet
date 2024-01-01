using Mslm.LibNS;

namespace Mslm.EmailVerifyNS
{
    public class SingleVerifyReqOpts
    {
        public ReqOpts ReqOpts { get; set; }
        public bool? DisableUrlEncode { get; set; }

        public SingleVerifyReqOpts()
        {
            ReqOpts = new ReqOpts();
            DisableUrlEncode = false;
        }
    }
}
