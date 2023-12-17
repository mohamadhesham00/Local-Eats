namespace RestaurantManagementSystem.Application.UseCases.RestaurantRequest.RequestApproval
{
    public interface IRequestApprovalCommandHandler
    {
        public Task ApproveRequest(string id);
    }
}
