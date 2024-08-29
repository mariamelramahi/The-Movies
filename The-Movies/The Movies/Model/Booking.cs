namespace The_Movies.Model
{
    /// <summary>
    /// Represents a booking for a movie.
    /// </summary>
    public class Booking
    {
        /// <summary>
        /// Gets or sets the title of the movie.
        /// </summary>
        public string MovieTitle { get; set; }

        /// <summary>
        /// Gets or sets the customer's email.
        /// </summary>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// Gets or sets the customer's phone number.
        /// </summary>
        public string CustomerPhone { get; set; }

        /// <summary>
        /// Gets or sets the quantity of tickets booked.
        /// </summary>
        public int TicketQuantity { get; set; }
    }
}
