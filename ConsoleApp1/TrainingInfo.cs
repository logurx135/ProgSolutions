using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class TrainingInfo
    {
        public int Points { get; set; }
        public int StTime { get; set; }
        public int EndTime { get; set; }

        public TrainingInfo( int _stTime, int _endTime , int _points ) { 
            Points= _points;
            StTime= _stTime;
            EndTime= _endTime;
        }

        public int OrderWith( TrainingInfo other )
        {
            int result = 0;

            int stTimeComparison = StTime.CompareTo(other.StTime);
            int endTimeComarison = EndTime.CompareTo(other.EndTime);
            int PointComparision = Points.CompareTo(other.Points);

            result = stTimeComparison;

            if (stTimeComparison == 0 )
            {
                if (endTimeComarison == 0)
                {
                    result = PointComparision;
                }
                else
                {
                    result= endTimeComarison;
                }                
            }
            return result;
        }
        public void Print()
        {
            Console.WriteLine("{0,4}--{1,4}--{2,6}", StTime,EndTime,Points );
        }
    }
}
