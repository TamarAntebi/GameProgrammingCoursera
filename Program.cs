using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex1
{
    /// <summary> 
    /// A program to calculate the maximum height of 
    /// the shell and the distance it will travel along the ground
    /// </summary> 
    class Program
    {
        const float G = 9.8F;

        /// <summary> 
        /// The standard Main method 
        /// </summary> 
        /// <param name="args">command-line args</param> 
        static void Main(string[] args)
        {
            //get input from user
            WriteWelcomeOutput();
            double theta = getTheta();
            float speed = getSpeed();

            //calculate the height and distance
            float voy = speed * (float)Math.Sin(theta);
            float vox = speed * (float)Math.Cos(theta);
            float h = voy * voy / (2 * G);
            float t = voy / G;
            float dx = vox * 2 * t;

            //write result
            OutputResult(h, dx);
        }

        /// <summary> 
        /// print the results
        /// </summary> 
        private static void OutputResult(float h, float dx)
        {
            Console.WriteLine("Maximum shell height: " + h);
            Console.WriteLine("Horizontal distance: " + dx);
            Console.WriteLine();
        }

        /// <summary> 
        /// Get the speed from the  user
        /// </summary> 
        /// <returns>the speed in radians</returns> 
        private static float getSpeed()
        {
            Console.WriteLine("Please input the initial speed:");
            float speed = float.Parse(Console.ReadLine());
            return speed;
        }

        /// <summary> 
        /// Get the angle from the user in degrees and convert it to radians
        /// </summary> 
        /// <returns>the angle in radians</returns> 
        private static double getTheta()
        {
            Console.WriteLine("Please input the initial angle in degrees:");
            double theta = float.Parse(Console.ReadLine());
            return (Math.PI / 180) * theta;
        }

        /// <summary> 
        /// Print The Welcome message and information about the program
        /// </summary> 
        private static void WriteWelcomeOutput()
        {
            Console.WriteLine("Welcome all!");
            Console.WriteLine("This application will calculate the maximum height of"+ 
            "the shell and \nthe distance it will travel along the ground");
            Console.WriteLine();
        }
    }
}
