namespace LateRooms.CI.Monitor.Web.Service.Connectors
{
	public interface IRepository<TRequest, TResponse>
			where TRequest : new() 
			where TResponse : new()
	{
		string ServerUri { get; set; }

		TResponse Get(TRequest request);
	}
}