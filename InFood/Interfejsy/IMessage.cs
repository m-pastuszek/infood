using InFood.Klasy;

namespace InFood.Interfejsy
{
    public interface IMessage
    {
        IMessage ProcessRequest(StateObject a_oStateObject = null);
        IMessage ProcessResponse(StateObject a_oStateObject = null);

   //     NetworkData AsNetworkData(int a_iDataSize = NetworkService.BUFFER_SIZE);
    }
}
