using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{

    [EntitySystemOf(typeof(MicroDustLoginUIComponent))]
    [FriendOf(typeof(MicroDustLoginUIComponent))]
    [FriendOfAttribute(typeof(MicroDustLoginUIComponent))]
    public static partial class MicroDustLoginSystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustLoginUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.Account = rc.Get<GameObject>("username");
            self.Password = rc.Get<GameObject>("password");
            self.LoginButton = rc.Get<GameObject>("login");

            self.LoginButton.GetComponent<Button>().onClick.AddListener(() => { self.OnLogin().Coroutine(); });
        }

        private static async ETTask OnLogin(this MicroDustLoginUIComponent self)
        {
            self.Root().RemoveComponent<MicroDustClientSenderComponent>();
            var clientSenderCompnent = self.Root().AddComponent<MicroDustClientSenderComponent>();

            var result = await clientSenderCompnent.LoginAsync(
                self.Account.GetComponent<TMP_InputField>().text,
                self.Password.GetComponent<TMP_InputField>().text);

            self.Root().GetComponent<MicroDustClientPlayerComponent>().MyId = result.Item1;
            self.Root().GetComponent<MicroDustClientPlayerComponent>().UserId = result.Item2;

            await EventSystem.Instance.PublishAsync(self.Root(), new MicroDustLoginFinished());
        }
    }
}