namespace RestaurantManagementSystem.Core.RestaurantRequest.Entities;

public enum RegistrationRequestStatus
{
    PendingVerification,
    WaitingForAdminResponse,
    Approved,
    Rejected
}