using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_And_Cache
{
    class OfferCost : ActivityDecorator
    {
        public OfferCost(IActivity iActivity) : base(iActivity) { }

        public override List<Activities> CacheData()
        {
            return base.GetActivityList();
        }

        public override double GetOfferCost(double cost)
        {
            return .8 * cost;
        }
    }
}
