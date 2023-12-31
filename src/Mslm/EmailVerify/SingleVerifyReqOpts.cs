using Mslm.Lib;

namespace Mslm.EmailVerify
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
