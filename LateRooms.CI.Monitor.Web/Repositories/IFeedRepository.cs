namespace LateRooms.CI.Monitor.Web.Repositories
{
	public interface IFeedRepository<TRequest, TResponse>
			where TRequest : new() 
			where TResponse : new()
	{
		string ServerUri { get; set; }

		TResponse Get(TRequest request);
	}
}