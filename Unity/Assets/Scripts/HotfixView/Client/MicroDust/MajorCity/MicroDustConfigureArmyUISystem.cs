using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustConfigureArmyUIComponent))]
    [FriendOf(typeof(MicroDustConfigureArmyUIComponent))]
    [FriendOfAttribute(typeof(MicroDustConfigureArmyUIComponent))]
    [FriendOfAttribute(typeof(ET.Client.MicroDustConfigureArmyComponent))]
    [FriendOfAttribute(typeof(ET.MicroDustArmy))]
    public static partial class MicroDustConfigureArmyUISystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustConfigureArmyUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.Back = rc.Get<GameObject>("back");
            self.Heros.Add(rc.Get<GameObject>("army1"));
            self.Heros.Add(rc.Get<GameObject>("army2"));
            self.Heros.Add(rc.Get<GameObject>("army3"));
            self.ArmyType = rc.Get<GameObject>("armytype");
            self.ArmySwitch = rc.Get<GameObject>("armytypeswitch");

            self.Name = rc.Get<GameObject>("name");
            self.Ruler = rc.Get<GameObject>("rulerpowervalue");
            self.Soldiers = rc.Get<GameObject>("soldiersvalue");
            self.MoveSpeed = rc.Get<GameObject>("movespeedvalue");
            self.CityDestory = rc.Get<GameObject>("citydestoryvalue");

            self.SoldierReady = rc.Get<GameObject>("soldiervalue");
            self.Auto = rc.Get<GameObject>("auto");
            self.Confirm = rc.Get<GameObject>("confirm");
            self.Less.Add(rc.Get<GameObject>("soldier1less"));
            self.Less.Add(rc.Get<GameObject>("soldier2less"));
            self.Less.Add(rc.Get<GameObject>("soldier3less"));
            self.More.Add(rc.Get<GameObject>("soldier1more"));
            self.More.Add(rc.Get<GameObject>("soldier2more"));
            self.More.Add(rc.Get<GameObject>("soldier3more"));
            self.Slider.Add(rc.Get<GameObject>("soldier1slider"));
            self.Slider.Add(rc.Get<GameObject>("soldier2slider"));
            self.Slider.Add(rc.Get<GameObject>("soldier3slider"));

            self.DisplayHeroInfo();

            self.Back.GetComponent<Button>().onClick.AddListener(() => { self.OnBackClick().Coroutine(); });
            for (int i = 0; i < self.Heros.Count; i++)
            {
                var hero = self.Heros[i];
                hero.GetComponent<Button>().onClick.AddListener(() => { self.ConfigureHero(hero).Coroutine(); });
            }
        }

        private static void DisplayHeroInfo(this MicroDustConfigureArmyUIComponent self)
        {
            var index = self.Root().GetComponent<MicroDustConfigureArmyComponent>().SelectedArmy;
            var army = self.Root().CurrentScene().GetComponent<MicroDustPlayerComponent>().GetComponent<MicroDustArmyComponent>().GetArmyByIndex(index);
            var heros = self.Root().GetComponent<MicroDustHeroComponent>();
            for (int i = 0; i < self.Heros.Count; i++)
            {
                if (!string.IsNullOrEmpty(army.HeroIds[i]))
                {
                    self.Heros[i].GetComponentInChildren<TMP_Text>().text =
                        heros.GetHeroConfigById(army.HeroIds[i])?.Name;
                }
            }
        }

        private static async ETTask OnBackClick(this MicroDustConfigureArmyUIComponent self)
        {
            await UIHelper.Create(self.Root(), UIType.MicroDustMajorCity, UILayer.Mid);
            await UIHelper.Remove(self.Root(), UIType.MicroDustConfigureArmy);
        }

        private static async ETTask ConfigureHero(this MicroDustConfigureArmyUIComponent self, GameObject hero)
        {
            var army = self.Root().GetComponent<MicroDustConfigureArmyComponent>();
            army.SelectedHero = int.Parse(hero.name.Substring(hero.name.Length - 1)) - 1;

            if (self.Root().GetComponent<MicroDustHeroComponent>() == null)
            {
                await MicroDustHerosHelper.GetHerosInfo(self.Root(), UIType.MicroDustSelectHero);
            }
            else
            {
                await UIHelper.Remove(self.Root(), UIType.MicroDustSelectHero);
                await UIHelper.Create(self.Root(), UIType.MicroDustSelectHero, UILayer.Mid);
                await UIHelper.Remove(self.Root(), UIType.MicroDustConfigureArmy);
            }
        }
    }
}
