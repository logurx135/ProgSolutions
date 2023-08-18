using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class TrainingScheduleSolver
    {
        internal int FindMaxPoints( List<TrainingInfo> trainings )
        {
            int result = 0;

            trainings.Sort((x, y) => x.OrderWith(y));

            int i = 0;

            int theLastOfEndTime = 0 ;
            for (i = 1; i < trainings.Count; i++)
            {
                if(trainings[i].EndTime > theLastOfEndTime )
                    theLastOfEndTime = trainings[i].EndTime;
                
                // Remove the points which have lower scores for the same start and end time
                while ((trainings[i - 1].StTime == trainings[i].StTime) &&
                       (trainings[i - 1].EndTime == trainings[i].EndTime)
                       )
                {
                    trainings.RemoveAt(i);
                    if (i == trainings.Count)
                        break;
                }
            }

            foreach (var tc in trainings)
            {
                tc.Print();
            }

            short theLastHighScore = (short)trainings[trainings.Count - 1].Points;
            int theLastStartPoint = trainings[trainings.Count - 1].StTime;

            // hard coding the array size, based on the contraints on the end time
            short[] bestScoresAt = new short[theLastOfEndTime+2]; // +2 is to keep it generic for all searchs
            Array.Fill<short>(bestScoresAt,
                       0,
                       theLastStartPoint,
                       theLastOfEndTime - theLastStartPoint);

            int theScore = theLastHighScore;

            int theBestScoreSoFar = 0; 
            List<TrainingInfo> listWithSameStartPoints = new List<TrainingInfo>();
            // traverse from last start point to first
            i = trainings.Count-1;
            int prevSeenStartPoint = theLastStartPoint;

            while (i >= 0)
            {
                int stTime = trainings[i].StTime;

                // Get the list of all trainings with same start time
                int currIndex = i;
                listWithSameStartPoints.Clear();
                int numDuplicates = 0;
                while (currIndex >=0 && trainings[currIndex].StTime == stTime )
                {
                    listWithSameStartPoints.Add(trainings[currIndex]);
                    currIndex--;
                    numDuplicates++;
                }

                //Fill the bestScore
                Array.Fill<short>(bestScoresAt,
                                  (short)theBestScoreSoFar,
                                  stTime,
                                  prevSeenStartPoint-stTime);
                
                // find the best score at the current location
                foreach(var tc in listWithSameStartPoints)
                {
                    int bestScoreIfWeTakeThis = tc.Points + bestScoresAt[tc.EndTime];
                    if(bestScoreIfWeTakeThis > theBestScoreSoFar )
                    {
                        theBestScoreSoFar = bestScoreIfWeTakeThis;
                    }
                }

                bestScoresAt[trainings[i].StTime] = (short)theBestScoreSoFar;
                prevSeenStartPoint = trainings[i].StTime;

                if (numDuplicates > 1 )
                {
                    i = i - numDuplicates;
                }
                else
                {
                    i--;
                }
            }

            return bestScoresAt[trainings[0].StTime];
        }
    }
}
