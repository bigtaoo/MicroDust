using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustArmyConfirmUIComponent))]
    [FriendOf(typeof(MicroDustArmyConfirmUIComponent))]
    [FriendOfAttribute(typeof(MicroDustArmyConfirmUIComponent))]
    public static partial class MicroDustArmyConfirmUISystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustArmyConfirmUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.Back = rc.Get<GameObject>("back");
            self.TotalSoldiers = rc.Get<GameObject>("totalsoldiers");
            self.CityAttack = rc.Get<GameObject>("cityattack");
            self.MoveSpeed = rc.Get<GameObject>("movespeed");
            self.AutoBack = rc.Get<GameObject>("autoback");
            self.Action = rc.Get<GameObject>("action");
            self.MiddleText = rc.Get<GameObject>("middletext");
            self.Arrive = rc.Get<GameObject>("arrive");
            self.Path = rc.Get<GameObject>("path");
            self.Distance = rc.Get<GameObject>("distance");
            self.Time = rc.Get<GameObject>("time");
            self.Energy = rc.Get<GameObject>("energy");
            self.Defender = rc.Get<GameObject>("defender");
            self.Resource = rc.Get<GameObject>("resource");
            self.Command = rc.Get<GameObject>("command");

            for(int i = 0; i < 3; i++)
            {
                var hero = rc.Get<GameObject>($"hero{i + 1}");
            }

            self.Back.GetComponent<Button>().onClick.AddListener(() => { self.OnBackClick().Coroutine(); });
            self.Action.GetComponent<Button>().onClick.AddListener(() => { self.OnActionClick().Coroutine(); });
        }

        private static async ETTask OnBackClick(this MicroDustArmyConfirmUIComponent self)
        {
            await UIHelper.Remove(self.Root(), UIType.MicroDustArmyConfirm);
        }

        private static async ETTask OnActionClick(this MicroDustArmyConfirmUIComponent self)
        {
            var tileInfo = self.Root().GetComponent<MicroDustSelectedMapTileComponent>();
            await MicroDustArmyCommandHelper.SendArmyCommand(self.Root(), tileInfo.ArmyIndex, tileInfo.PosX, tileInfo.PosY);
            await UIHelper.Remove(self.Root(), UIType.MicroDustArmyConfirm);
        }
    }
}
