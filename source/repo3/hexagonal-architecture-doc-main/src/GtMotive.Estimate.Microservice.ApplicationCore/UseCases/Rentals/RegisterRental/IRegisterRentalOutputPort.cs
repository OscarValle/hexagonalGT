namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals
{
    /// <summary>
    /// Intercafe of RegisterRentalOutputPort.
    /// </summary>
    public interface IRegisterRentalOutputPort
    {
        /// <summary>
        /// Get Ok.
        /// </summary>
        /// <param name="output">RegisterRentalOutput.</param>
        void Ok(RegisterRentalOutput output);

        /// <summary>
        /// Get InvalidRental.
        /// </summary>
        /// <param name="reason">Reason.</param>
        void InvalidRental(string reason);

        /// <summary>
        /// Get RentalTooOld.
        /// </summary>
        /// <param name="reason">Reason.</param>
        void PersonNotMoreThanOneATime(string reason);
    }
}
