using System;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// DateTime Provider.
    /// </summary>
    public interface IDateTimeProvider
    {
        /// <summary>
        /// Gets now date.
        /// </summary>
        DateTime Now { get; }

        /// <summary>
        /// Gets Today date.
        /// </summary>
        DateTime Today { get; }
    }
}
