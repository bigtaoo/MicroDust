using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustArmyCommandUIComponent))]
    [FriendOf(typeof(MicroDustArmyCommandUIComponent))]
    [FriendOfAttribute(typeof(MicroDustArmyCommandUIComponent))]
    [FriendOfAttribute(typeof(ET.Client.MicroDustSelectedMapTileComponent))]
    [FriendOfAttribute(typeof(ET.MicroDustArmyComponent))]
    [FriendOfAttribute(typeof(ET.MicroDustArmy))]
    public static partial class MicroDustArmyCommandUISystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustArmyCommandUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.Back = rc.Get<GameObject>("back");
            self.Target = rc.Get<GameObject>("target");
            self.Command = rc.Get<GameObject>("command");

            var army = new ListComponent<GameObject>();
            for (int i = 1; i <= 5; i++)
            {
                army.Add(rc.Get<GameObject>($"army{i}"));
            }
            foreach (var o in army)
            {
                o.GetComponent<Button>().onClick.AddListener(() => self.OnArmyClick(o).Coroutine());
                self.Icons.Add(o.GetComponentInChildren<Image>().gameObject);
                var texts = o.GetComponentsInChildren<TMPro.TextMeshProUGUI>();
                foreach (var text in texts)
                {
                    if (text.name == "status")
                    {
                        self.Status.Add(text.gameObject);
                    }
                    else if (text.name == "soilders")
                    {
                        self.Soilders.Add(text.gameObject);
                    }
                    else if (text.name == "second")
                    {
                        self.Seconds.Add(text.gameObject);
                    }
                    else if (text.name == "third")
                    {
                        self.Thirds.Add(text.gameObject);
                    }
                    else if (text.name == "level")
                    {
                        self.Levels.Add(text.gameObject);
                    }
                    else if (text.name == "name")
                    {
                        self.Names.Add(text.gameObject);
                    }
                }
            }

            self.DisplayArmyInfo();

            self.Back.GetComponent<Button>().onClick.AddListener(() => { self.OnBackClick().Coroutine(); });
        }

        private static async ETTask OnArmyClick(this MicroDustArmyCommandUIComponent self, GameObject army)
        {
            var tileInfo = self.Root().GetComponent<MicroDustSelectedMapTileComponent>();
            tileInfo.ArmyIndex = int.Parse(army.name.Substring(army.name.Length - 1)) - 1;
            Log.Debug($"Army, choose army: {army.name} index: {tileInfo.ArmyIndex}");

            await UIHelper.Create(self.Root(), UIType.MicroDustArmyConfirm, UILayer.Mid);
            await UIHelper.Remove(self.Root(), UIType.MicroDustArmyCommand);
        }

        private static async ETTask OnBackClick(this MicroDustArmyCommandUIComponent self)
        {
            await UIHelper.Remove(self.Root(), UIType.MicroDustArmyCommand);
        }

        private static void DisplayArmyInfo(this MicroDustArmyCommandUIComponent self)
        {
            var tileInfo = self.Root().GetComponent<MicroDustSelectedMapTileComponent>();
            self.Command.GetComponent<TMPro.TextMeshProUGUI>().text = tileInfo.ArmyCommandType.ToString();
            self.Target.GetComponent<TMPro.TextMeshProUGUI>().text = tileInfo.TileType;

            var army = self.Root().CurrentScene().GetComponent<MicroDustPlayerComponent>().GetComponent<MicroDustArmyComponent>();
            var heroComponent = self.Root().GetComponent<MicroDustHeroComponent>();
            //Log.Debug($"Hero, {heroComponent == null}");
            for (int i = 0; i < 5; ++i)
            {
                var a = army.GetArmyByIndex(i);
                if (a.HeroIds.FirstOrDefault() == null)
                {
                    continue;
                }

                var config1 = heroComponent.GetHeroConfigById(a.HeroIds[0]);
                self.Names[i].GetComponent<TMPro.TextMeshProUGUI>().text = config1.Name;
                var hero1 = heroComponent.GetHeroById(a.HeroIds[0]);
                self.Levels[i].GetComponent<TMPro.TextMeshProUGUI>().text = hero1.Level.ToString();

                if (!string.IsNullOrEmpty(a.HeroIds[1]))
                {
                    var config2 = heroComponent.GetHeroConfigById(a.HeroIds[1]);
                    self.Seconds[i].GetComponent<TMPro.TextMeshProUGUI>().text = config2.Name;
                }
                if (!string.IsNullOrEmpty(a.HeroIds[2]))
                {
                    var config3 = heroComponent.GetHeroConfigById(a.HeroIds[2]);
                    self.Thirds[i].GetComponent<TMPro.TextMeshProUGUI>().text = config3.Name;
                }
            }
        }
    }
}
