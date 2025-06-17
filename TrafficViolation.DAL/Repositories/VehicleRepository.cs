using System;
using System.Collections.Generic;
using System.Linq;
using TrafficViolation.DAL.Entities;

namespace TrafficViolation.DAL.Repositories
{
    public class VehicleRepository
    {
        private PrnProjectContext _context;

        public Vehicle GetVehicleByPlateNumber(string plateNumber)
        {
            _context = new();
            return _context.Vehicles
                .FirstOrDefault(v => v.PlateNumber == plateNumber);
        }

        public List<Vehicle> GetVehiclesByOwner(int ownerId)
        {
            _context = new();
            return _context.Vehicles
                .Where(v => v.OwnerId == ownerId)
                .ToList();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _context = new();
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            _context = new();
            var existingVehicle = _context.Vehicles
                .FirstOrDefault(v => v.VehicleId == vehicle.VehicleId);

            if (existingVehicle != null)
            {
                existingVehicle.Brand = vehicle.Brand;
                existingVehicle.Model = vehicle.Model;
                existingVehicle.ManufactureYear = vehicle.ManufactureYear;

                _context.SaveChanges();
            }
        }

        public void DeleteVehicle(int vehicleId)
        {
            _context = new();
            var vehicle = _context.Vehicles.Find(vehicleId);

            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                _context.SaveChanges();
            }
        }

        public bool IsPlateNumberUnique(string plateNumber)
        {
            _context = new();
            return !_context.Vehicles.Any(v => v.PlateNumber == plateNumber);
        }

        public Vehicle GetVehicleWithOwnerDetails(string plateNumber)
        {
            _context = new();
            return _context.Vehicles
                .FirstOrDefault(v => v.PlateNumber == plateNumber);
        }

        // Get all vehicles
        public List<Vehicle> GetAllVehicles()
        {
            _context = new();
            return _context.Vehicles.ToList();
        }
        public List<dynamic> GetAllVehiclesWithOwnerDetails()
        {
            _context = new PrnProjectContext();
            return _context.Vehicles
                .Join(_context.Users,
                      vehicle => vehicle.OwnerId,
                      user => user.UserId,
                      (vehicle, user) => new
                      {
                          vehicle.PlateNumber,
                          vehicle.Brand,
                          vehicle.Model,
                          vehicle.ManufactureYear,
                          FullName = user.FullName
                      })
                .ToList<dynamic>();
        }

    }
}