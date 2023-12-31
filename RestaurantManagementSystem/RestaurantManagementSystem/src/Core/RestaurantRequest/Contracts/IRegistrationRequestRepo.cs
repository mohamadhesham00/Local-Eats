﻿using RestaurantManagementSystem.src.Core.Entities;

namespace RestaurantManagementSystem.src.Core.Contracts
{
    public interface IRegistrationRequestRepo
    {
        public void AddRequest(RegistrationRequest waitingListRestaurant);
        public Task<RegistrationRequest> FindByIdAsync (string ID);
        public void Update(RegistrationRequest registrationRequest);
        public Task<List<RegistrationRequest>> GetRegistrationRequestsAsync();

    }
}
