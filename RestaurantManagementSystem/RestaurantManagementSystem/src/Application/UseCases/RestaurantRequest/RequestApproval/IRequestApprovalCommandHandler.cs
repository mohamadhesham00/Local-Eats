namespace RestaurantManagementSystem.src.Application.UseCases.RestaurantRequest.RequestApproval
{
    public interface IRequestApprovalCommandHandler
    {
        public Task ApproveRequest(string id);
    }
}
