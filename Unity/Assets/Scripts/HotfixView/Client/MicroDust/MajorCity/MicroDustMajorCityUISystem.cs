using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustMajorCityUIComponent))]
    [FriendOf(typeof(MicroDustMajorCityUIComponent))]
    [FriendOfAttribute(typeof(MicroDustMajorCityUIComponent))]
    [FriendOfAttribute(typeof(ET.MicroDustArmy))]
    [FriendOfAttribute(typeof(ET.Client.MicroDustConfigureArmyComponent))]
    public static partial class MicroDustMajorCityUISystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustMajorCityUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.Armies.Add(rc.Get<GameObject>("army1"));
            self.Armies.Add(rc.Get<GameObject>("army2"));
            self.Armies.Add(rc.Get<GameObject>("army3"));
            self.Armies.Add(rc.Get<GameObject>("army4"));
            self.Armies.Add(rc.Get<GameObject>("army5"));
            self.Back = rc.Get<GameObject>("back");
            self.RecruitSoldiers = rc.Get<GameObject>("soldier");
            self.BuildBuildings = rc.Get<GameObject>("build");

            self.DisplayArmyInfo();

            self.Back.GetComponent<Button>().onClick.AddListener(() => { self.OnBackClick().Coroutine(); });
            for (int i = 0; i < self.Armies.Count; i++)
            {
                var army = self.Armies[i];
                army.GetComponent<Button>().onClick.AddListener(() => { self.ConfigureArmy(army).Coroutine(); });
            }
            self.RecruitSoldiers.GetComponent<Button>().onClick.AddListener(() => { self.OnRecruitSoldiersClick().Coroutine(); });
            self.BuildBuildings.GetComponent<Button>().onClick.AddListener(() => { self.OnBuildBuildingsClick().Coroutine(); });
        }

        private static void DisplayArmyInfo(this MicroDustMajorCityUIComponent self)
        {
            //Log.Warning($"player component is null {self.Root().CurrentScenePlayerComponent() == null}");
            var army = self.Root().PlayerComponent().GetComponent<MicroDustArmyComponent>();
            Log.Warning($"army is null: {army == null}");
            var heros = self.Root().GetComponent<MicroDustHeroComponent>();
            for (int i = 0; i < self.Armies.Count; i++)
            {
                var firstHeroId = army.GetArmyByIndex(i).HeroIds[0];
                if (!string.IsNullOrEmpty(firstHeroId))
                {
                    self.Armies[i].GetComponentInChildren<TMP_Text>().text =
                        heros.GetHeroConfigById(firstHeroId)?.Name;
                }
            }
        }

        private static async ETTask OnBackClick(this MicroDustMajorCityUIComponent self)
        {
            await UIHelper.Remove(self.Root(), UIType.MicroDustMajorCity);
        }

        private static async ETTask OnRecruitSoldiersClick(this MicroDustMajorCityUIComponent self)
        {
            await UIHelper.Create(self.Root(), UIType.MicroDustBuilding, UILayer.Mid);
        }

        private static async ETTask OnBuildBuildingsClick(this MicroDustMajorCityUIComponent self)
        {
            await UIHelper.Create(self.Root(), UIType.MicroDustBuilding, UILayer.Mid);
        }

        private static async ETTask ConfigureArmy(this MicroDustMajorCityUIComponent self, GameObject a)
        {
            var army = self.Root().GetComponent<MicroDustConfigureArmyComponent>();
            if (army == null)
            {
                army = self.Root().AddComponent<MicroDustConfigureArmyComponent>();
            }
            army.SelectedArmy = int.Parse(a.name.Substring(a.name.Length - 1)) - 1;
            //Log.Debug($"Army: select army: {army.SelectedArmy}");

            await UIHelper.Remove(self.Root(), UIType.MicroDustConfigureArmy);
            await UIHelper.Create(self.Root(), UIType.MicroDustConfigureArmy, UILayer.Mid);
            await UIHelper.Remove(self.Root(), UIType.MicroDustMajorCity);
        }
    }
}
