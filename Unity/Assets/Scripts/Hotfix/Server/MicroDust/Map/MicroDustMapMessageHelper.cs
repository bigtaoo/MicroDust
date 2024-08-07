namespace ET.Server
{
    public static partial class MicroDustMapMessageHelper
    {
        public static void SendToClient(MicroDustPlayerComponent unit, IMessage message)
        {
            var locationId = unit.GetComponent<MicroDustLocationComponent>().Id;
            unit.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession).Send(locationId, message);
        }
    }
}
