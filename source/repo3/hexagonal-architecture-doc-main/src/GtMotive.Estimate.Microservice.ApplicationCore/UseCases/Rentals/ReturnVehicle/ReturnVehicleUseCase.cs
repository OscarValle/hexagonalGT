using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ReturnVehicleUseCase"/> class.
    /// </summary>
    /// <param name="rentalRepository">RentalRepository.</param>
    /// <param name="outputPort">OutputPort.</param>
    public class ReturnVehicleUseCase(IRentalRepository rentalRepository, IReturnVehicleOutputPort outputPort) : IReturnVehicleUseCase
    {
        private readonly IRentalRepository _rentalRepository = rentalRepository;
        private readonly IReturnVehicleOutputPort _outputPort = outputPort;

        /// <summary>
        /// Execute.
        /// </summary>
        /// <param name="input">ReturnVehicleInput.</param>
        /// <returns>Response.</returns>
        public async Task Execute(ReturnVehicleInput input)
        {
            if (input == null)
            {
                _outputPort.InvalidReturnVehicle("Insufficient data");
                return;
            }

            var rental = await _rentalRepository.GetByIdAsync(input.RentalId);

            if (rental == null)
            {
                _outputPort.InvalidReturnVehicle("Rent does not exist.");
            }

            if (rental.IsClosed())
            {
                _outputPort.InvalidReturnVehicle("This rental has already been returned.");
            }

            rental.CloseRental(input.RealEndDate.Value);
            await _rentalRepository.UpdateAsync(rental);

            _outputPort.Ok(new ReturnVehicleOutput(rental.Id, input.RealEndDate.Value, "Rental return successfully."));
        }
    }
}
