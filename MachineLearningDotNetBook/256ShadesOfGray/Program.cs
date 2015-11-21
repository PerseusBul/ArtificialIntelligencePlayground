﻿namespace _256ShadesOfGray
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            IDistance distance = new EuclideanDistance();
            IClassifier classifier = new CountClassifier(distance, 3200000);

            var trainingPath = @"..\..\..\Data\trainingsample.csv";
            var training = DataReader.ReadObservations(trainingPath);
            classifier.Train(training);

            var validationPath = @"..\..\..\Data\validationsample.csv";
            var validation = DataReader.ReadObservations(validationPath);

            var correct = Evaluator.Correct(validation, classifier);
            Console.WriteLine("Correctly classified: {0:P2}", correct);

            Console.ReadLine();
        }
    }
}
