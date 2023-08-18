using System.Diagnostics;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            TestTrainingScheduleSolution_TC1();
            TestTrainingScheduleSolution_TC2();
            TestMaxProductSubSequence();
        }

        static void TestMaxProductSubSequence()
        {
            Console.WriteLine("-1, 2 ,-3, 4, - 5");
            long result = MaxProdcutSubSequence.GetMaxProduct(new long[] { -1, 2 ,-3, 4, - 5 });
            Console.WriteLine(result);

            Console.WriteLine("-5 -4 -3 -2 -6");
            result = MaxProdcutSubSequence.GetMaxProduct(new long[] { -5, - 4, - 3, - 2, - 6 });
            Console.WriteLine(result);
        }

        static void TestTrainingScheduleSolution_TC2()
        {
            const int ROW = 4;
            const int COL = 3;
            int[,] sample = new int[ROW, COL] {

                            { 3, 4, 20 },
                            { 1, 2, 5 },
                            { 4, 5, 15 },
                            { 2, 4, 10 }
            };

            int i;
            List<TrainingInfo> testCase = new List<TrainingInfo>();
            for (i = 0; i < ROW; i++)
            {
                TrainingInfo trainingInfo = new TrainingInfo(sample[i, 0],
                                                              sample[i, 1],
                                                              sample[i, 2]);
                testCase.Add(trainingInfo);

            }

            TrainingScheduleSolver solver = new TrainingScheduleSolver();
            int result = solver.FindMaxPoints(testCase);
            Console.WriteLine(result);

        }

        static void TestTrainingScheduleSolution_TC1()
        {
            const int ROW = 6;
            const int COL = 3;
            int[,] sample = new int[ROW,COL] {

                            { 0, 6, 60 },
                            { 5, 9, 50 },
                            { 1, 4, 30 },
                            { 5, 7, 30 },
                            { 3, 5, 10 },
                            { 7, 8, 10 }
            };

            int i;
            List<TrainingInfo> testCase = new List<TrainingInfo>();
            for ( i = 0; i < ROW; i++)
            {
                TrainingInfo trainingInfo = new TrainingInfo( sample[i, 0],
                                                              sample[i, 1],
                                                              sample[i, 2]  );
                testCase.Add( trainingInfo );

            }

            TrainingScheduleSolver  solver = new TrainingScheduleSolver();
            int result = solver.FindMaxPoints( testCase );
            Console.WriteLine( result );

        }
    }
}