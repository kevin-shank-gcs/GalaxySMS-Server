using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Common
{
    public interface IGalaxySMSEngine : IBusinessEngine
    {
        //bool IsCarCurrentlyRented(int carId, int accountId);
        //bool IsCarCurrentlyRented(int carId);
        //bool IsCarAvailableForRental(int carId, DateTimeOffset pickupDate, DateTimeOffset returnDate,
        //                             IEnumerable<Rental> rentedCars, IEnumerable<Reservation> reservedCars);
        //Rental RentCarToCustomer(string loginEmail, int carId, DateTimeOffset rentalDate, DateTimeOffset dateDueBack);
    }
}
