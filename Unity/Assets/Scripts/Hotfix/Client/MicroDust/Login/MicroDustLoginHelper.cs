namespace ET.Client
{
    public static class MicroDustLoginHelper
    {
        public static async ETTask Login(Scene root, string account, string password)
        {
            root.RemoveComponent<MicroDustClientSenderComponent>();

            var clientSenderComponent = root.AddComponent<MicroDustClientSenderComponent>();

            (long playerId, string userId) = await clientSenderComponent.LoginAsync(account, password);

            root.GetComponent<PlayerComponent>().MyId = playerId;

            await EventSystem.Instance.PublishAsync(root, new LoginFinish());
        }
    }
}
