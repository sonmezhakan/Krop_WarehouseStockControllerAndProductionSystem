using Krop.Common.Utilits.Result;

namespace Krop.Common.Utilits.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if(!logic.Success)
                {
                    return logic;
                }
            }
            return new SuccessResult();
        }
    }
}
