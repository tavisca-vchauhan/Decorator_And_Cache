using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.Data.SqlClient;

namespace Decorator_And_Cache
{
    class Activity : IActivity
    {
        private const string Key = "activityList";
        public List<Activities> GetActivityList()
        {
            ObjectCache cache = MemoryCache.Default;
            if (cache.Contains(Key))
            {
                return (List<Activities>)cache.Get(Key);
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=TAVDESK013\SQLEXPRESS;Initial Catalog=Travel;User ID= sa; Password=test123!@#";
                con.Open();
                string query = "select * from Activity";
                List<Activities> activityValues = new List<Activities>();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Activities activity = new Activities();
                        activity.activityId = Convert.ToString(dr[0]);
                        activity.activityName = Convert.ToString(dr[1]);
                        activity.activityDuration = Convert.ToString(dr[2]);
                        activity.cost = Convert.ToString(dr[3]);
                        activity.isBooked = Convert.ToString(dr[4]);
                        activityValues.Add(activity);
                    }
                }
                con.Close();
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
                cache.Add(Key, activityValues, policy);

                return activityValues;
            }
        }
    }
}