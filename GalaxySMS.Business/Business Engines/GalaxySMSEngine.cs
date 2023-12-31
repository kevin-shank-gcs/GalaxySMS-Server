﻿using GalaxySMS.Business.Common;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business
{
    [Export(typeof(IGalaxySMSEngine))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GalaxySMSEngine : IGalaxySMSEngine
    {
        [ImportingConstructor]
        public GalaxySMSEngine(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        IDataRepositoryFactory _DataRepositoryFactory;

        //public bool IsCarCurrentlyRented(int carId, int accountId)
        //{
        //    bool rented = false;

        //    IRentalRepository rentalRepository = _DataRepositoryFactory.GetDataRepository<IRentalRepository>();

        //    var currentRental = rentalRepository.GetCurrentRentalByCar(carId);
        //    if (currentRental != null && currentRental.AccountId == accountId)
        //        rented = true;

        //    return rented;
        //}

        //public bool IsCarCurrentlyRented(int carId)
        //{
        //    bool rented = false;

        //    IRentalRepository rentalRepository = _DataRepositoryFactory.GetDataRepository<IRentalRepository>();

        //    var currentRental = rentalRepository.GetCurrentRentalByCar(carId);
        //    if (currentRental != null)
        //        rented = true;

        //    return rented;
        //}

        //public bool IsCarAvailableForRental(int carId, DateTimeOffset pickupDate, DateTimeOffset returnDate, 
        //                                    IEnumerable<Rental> rentedCars, IEnumerable<Reservation> reservedCars)
        //{
        //    bool available = true;
            
        //    Reservation reservation = reservedCars.Where(item => item.CarId == carId).FirstOrDefault();
        //    if (reservation != null && (
        //        (pickupDate >= reservation.RentalDate && pickupDate <= reservation.ReturnDate) ||
        //        (returnDate >= reservation.RentalDate && returnDate <= reservation.ReturnDate)))
        //    {
        //        available = false;
        //    }

        //    if (available)
        //    {
        //        Rental rental = rentedCars.Where(item => item.CarId == carId).FirstOrDefault();
        //        if (rental != null && (pickupDate <= rental.DateDue))
        //            available = false;
        //    }

        //    return available;
        //}

        //public Rental RentCarToCustomer(string loginEmail, int carId, DateTimeOffset rentalDate, DateTimeOffset dateDueBack)
        //{
        //    if (rentalDate > DateTimeOffset.Now)
        //        throw new UnableToRentForDateException(string.Format("Cannot rent for date {0} yet.", rentalDate.ToShortDateString()));

        //    IAccountRepository accountRepository = _DataRepositoryFactory.GetDataRepository<IAccountRepository>();
        //    IRentalRepository rentalRepository = _DataRepositoryFactory.GetDataRepository<IRentalRepository>();

        //    bool carIsRented = IsCarCurrentlyRented(carId);
        //    if (carIsRented)
        //        throw new CarCurrentlyRentedException(string.Format("Car {0} is already rented.", carId));

        //    Account account = accountRepository.GetByLogin(loginEmail);
        //    if (account == null)
        //        throw new NotFoundException(string.Format("No account found for login '{0}'.", loginEmail));

        //    Rental rental = new Rental()
        //    {
        //        AccountId = account.AccountId,
        //        CarId = carId,
        //        DateRented = rentalDate,
        //        DateDue = dateDueBack
        //    };

        //    Rental savedEntity = rentalRepository.Add(rental);

        //    return savedEntity;
        //}
    }
}
