using System.IO;

namespace The_Movies.Model
{
    /// <summary>
    /// Handles the operations related to storing and retrieving bookings.
    /// </summary>
    public class BookingRepository
    {
        private string _bookingFilePath = "bookings.csv";

        /// <summary>
        /// Creates a new booking and saves it to the CSV file.
        /// </summary>
        /// <param name="booking">The booking to save.</param>
        public void CreateBooking(Booking booking)
        {
            using (StreamWriter writer = new StreamWriter(_bookingFilePath, true))
            {
                writer.WriteLine($"{booking.MovieTitle},{booking.CustomerEmail},{booking.CustomerPhone},{booking.TicketQuantity}");
            }
        }

        /// <summary>
        /// Checks if there are enough available seats for a specific movie.
        /// </summary>
        /// <param name="movieTitle">The title of the movie.</param>
        /// <param name="requestedTickets">The number of tickets requested by the customer.</param>
        /// <returns>True if there are enough seats available, false otherwise.</returns>
        public bool CheckAvailability(string movieTitle, int requestedTickets)
        {
            int totalTicketsSold = 0;

            // Read the booking data and calculate total tickets sold for the specified movie.
            using (StreamReader reader = new StreamReader(_bookingFilePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    if (values[0] == movieTitle)
                    {
                        totalTicketsSold += int.Parse(values[3]);
                    }
                }
            }

            // Assume a standard theater capacity of 100 seats.
            int theaterCapacity = 100;
            return (totalTicketsSold + requestedTickets) <= theaterCapacity;
        }
    }
}
