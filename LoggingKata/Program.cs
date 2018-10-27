﻿using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            // HINT:  You'll need two nested forloops

            // DON'T FORGET TO LOG YOUR STEPS
            // Grab the path from the name of your file

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            var lines = File.ReadAllLines("./TacoBell-US-AL.csv");

            // Log and error if you get 0 lines and a warning if you get 1 line
            //logger.LogInfo($"Lines: {lines[0]}");
            //logger.LogWarning($"Lines: {lines[1]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse);

            // Now, here's the new code

            // Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the furthest from each other.
            ITrackable tacoBell1 = null;
            ITrackable tacoBell2 = null;

            // Create a `double` variable to store the distance
            double longestDist = 0;
            double dist = 0;
            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            foreach (var locationA in locations)
            {
                var locA = locationA.Location;
                // Create a new corA Coordinate with your locA's lat and long
                GeoCoordinate coordinateA = new GeoCoordinate(locA.Latitude, locA.Longitude);

                // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
                foreach (var locationB in locations)
                {
                    var locB = locationB.Location;
                    // Create a new Coordinate with your locB's lat and long
                    GeoCoordinate coordinateB = new GeoCoordinate(locB.Latitude, locB.Longitude);

                    // Now, compare the two using `.GetDistanceTo()`, which returns a double
                    dist = coordinateA.GetDistanceTo(coordinateB);

                    // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above
                    if (dist > longestDist)
                    {
                        longestDist = dist;
                        tacoBell1 = locationA;
                        tacoBell2 = locationB;

                    }
                }
            }

            Console.WriteLine($"{tacoBell1.Name} and {tacoBell2.Name} are the furthest apart with a distance between them of {longestDist}.");
            // Once you've looped through everything, you've found the two Taco Bells furthest away from each other.
        }
    }
}