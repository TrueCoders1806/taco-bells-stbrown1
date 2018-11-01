using System;
namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            if(line == null)
            {
                logger.LogWarning("Line was null!");
                return null;
            }

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3 || cells.Length > 3)
            {
                logger.LogWarning("Incorrect Array Size!");
                // Log that and return null
                return null;
            }

            // grab the latitude from your array at index 0
            string stringLat = cells[0];

            // grab the longitude from your array at index 1
            string stringLong = cells[1];

            // grab the name from your array at index 2
            string name = cells[2].Trim();
            if (name.Length < 9 || name.Substring(0, 9) != "Taco Bell")
            {
                logger.LogWarning("Incorrect location name!");
                return null;
            }

            // Your going to need to parse your string as a `double`
            double latitude = 0;
            try
            {
                latitude = double.Parse(stringLat);
            }
            catch (Exception error)
            {
                logger.LogError("Latitude was in the wrong format!", error);
                return null;
            }
            if (latitude < -90 || latitude > 90)
            {
                logger.LogWarning("Not a valid latitude!");
                return null;
            }

            double longitude = 0;
            try
            {
                longitude = double.Parse(stringLong);
            }
            catch (Exception error)
            {
                logger.LogError("Longitude was in the wrong format!", error);
                return null;
            }
            if (longitude < -180 || longitude > 180)
            {
                logger.LogWarning("Not a valid longitude!");
                return null;
            }
           
            // Then, you'll need an instance of the TacoBell class
            TacoBell taco = new TacoBell();

            // With the name and point set correctly
            taco.Name = name;
            Point location = new Point();
            location.Latitude = latitude;
            location.Longitude = longitude;

            taco.Location = location;
            // Then, return the instance of your TacoBell class
            return taco;
            // Since it conforms to ITrackable
        }
    }
}