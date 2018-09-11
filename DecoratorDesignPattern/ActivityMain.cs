using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_And_Cache
{
    class ActivityMain
    {
        static void Main(string[] args)
        {
            IActivity iactivity = new Activity();
            ActivityDecorator activityDecorator = new OfferCost(iactivity);
            Console.WriteLine("From Database : ");
            List<Activities> activity = activityDecorator.GetActivityList();
            for(int index=0;index<activity.Count;index++)
            {
                Console.WriteLine(activity[index].activityId+"  "+activity[index].activityName+"    "+
                activity[index].activityDuration+"  "+ activity[index].cost+"   "+ activity[index].isBooked);
            }
            Console.WriteLine("\nFrom Cache : ");
            activity = activityDecorator.CacheData();
            for (int index = 0; index < activity.Count; index++)
            {
                Console.WriteLine(activity[index].activityId + "  " + activity[index].activityName + "    " +
                activity[index].activityDuration + "  " + activity[index].cost + "   " + activity[index].isBooked);
            }
            Console.ReadLine();
        }
    }
}
