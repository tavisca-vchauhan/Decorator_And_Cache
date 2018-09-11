using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_And_Cache
{
    public abstract class ActivityDecorator : IActivity
    {
        private IActivity _activity;
        public ActivityDecorator(IActivity activity)
        {
            _activity = activity;
        }
        public List<Activities> GetActivityList()
        {
            return _activity.GetActivityList();
        }
        public abstract double GetOfferCost(double cost);
        public abstract List<Activities> CacheData();
    }
}
