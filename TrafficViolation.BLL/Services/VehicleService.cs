using System.Collections.Generic;
using TrafficViolation.DAL.Entities;
using TrafficViolation.DAL.Repositories;

namespace TrafficViolation.BLL.Services
{
    public class VehicleService
    {
        private readonly VehicleRepository _vehicleRepository;

        public VehicleService()
        {
            _vehicleRepository = new VehicleRepository();
        }

        // Get vehicle by plate number
        public Vehicle GetVehicleByPlateNumber(string plateNumber)
        {
            return _vehicleRepository.GetVehicleByPlateNumber(plateNumber);
        }

        // Get vehicles by owner
        public List<Vehicle> GetVehiclesByOwner(int ownerId)
        {
            return _vehicleRepository.GetVehiclesByOwner(ownerId);
        }

        // Add a new vehicle
        public bool AddVehicle(Vehicle vehicle)
        {
            if (_vehicleRepository.IsPlateNumberUnique(vehicle.PlateNumber))
            {
                _vehicleRepository.AddVehicle(vehicle);
                return true;
            }

            return false;
        }

        // Update vehicle information
        public bool UpdateVehicle(Vehicle vehicle)
        {
            var existingVehicle = _vehicleRepository.GetVehicleByPlateNumber(vehicle.PlateNumber);

            if (existingVehicle != null)
            {
                _vehicleRepository.UpdateVehicle(vehicle);
                return true;
            }

            return false;
        }

        // Delete a vehicle
        public bool DeleteVehicle(int vehicleId)
        {
            var vehicle = _vehicleRepository.GetVehicleByPlateNumber(vehicleId.ToString());

            if (vehicle != null)
            {
                _vehicleRepository.DeleteVehicle(vehicleId);
                return true;
            }

            return false;
        }

        // Check if a plate number is unique
        public bool IsPlateNumberUnique(string plateNumber)
        {
            return _vehicleRepository.IsPlateNumberUnique(plateNumber);
        }

        // Get vehicle details with owner information
        public Vehicle GetVehicleWithOwnerDetails(string plateNumber)
        {
            return _vehicleRepository.GetVehicleWithOwnerDetails(plateNumber);
        }

        // Get all vehicles
        public List<Vehicle> GetAllVehicles()
        {
            return _vehicleRepository.GetAllVehicles();
        }


        public List<dynamic> GetAllVehiclesWithOwnerDetails()
        {
            return _vehicleRepository.GetAllVehiclesWithOwnerDetails();
        }

    }
}
