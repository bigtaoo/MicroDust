using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustSelectHeroUIComponent))]
    [FriendOf(typeof(MicroDustSelectHeroUIComponent))]
    [FriendOfAttribute(typeof(MicroDustSelectHeroUIComponent))]
    [FriendOfAttribute(typeof(ET.Client.MicroDustConfigureArmyComponent))]
    public static partial class MicroDustSelectHeroUISystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustSelectHeroUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.Back = rc.Get<GameObject>("back");
            self.Choose = rc.Get<GameObject>("choose");
            self.HeroMetal = rc.Get<GameObject>("herometal");
            self.HeroWood = rc.Get<GameObject>("herowood");
            self.HeroEarth = rc.Get<GameObject>("heroearth");
            self.HeroWater = rc.Get<GameObject>("herowater");
            self.HeroFire = rc.Get<GameObject>("herofire");
            self.HeroUsed = rc.Get<GameObject>("heroused");
            self.HeroRuler = rc.Get<GameObject>("heroruler");
            self.HeroLevel = rc.Get<GameObject>("herolevel");
            self.HeroCamp = rc.Get<GameObject>("herocamp");
            self.HeroName = rc.Get<GameObject>("heroname");
            self.HeroRight = rc.Get<GameObject>("heroright");
            self.ContentRight = rc.Get<GameObject>("ContentRight");
            self.HeroLeft = rc.Get<GameObject>("heroleft");
            self.ContentLeft = rc.Get<GameObject>("ContentLeft");

            self.DrawLeftHeros();
            self.DrawRightHeros();

            self.Back.GetComponent<Button>().onClick.AddListener(() => { self.OnBackClick().Coroutine(); });
        }

        private static async ETTask OnBackClick(this MicroDustSelectHeroUIComponent self)
        {
            await UIHelper.Create(self.Root(), UIType.MicroDustConfigureArmy, UILayer.Mid);
            await UIHelper.Remove(self.Root(), UIType.MicroDustSelectHero);
        }

        private static void DrawLeftHeros(this MicroDustSelectHeroUIComponent self)
        {
            var heros = self.Root().GetComponent<MicroDustHeroComponent>();
            var index = 0;
            foreach (var hero in heros.Heros)
            {
                var b = UnityEngine.Object.Instantiate(self.HeroLeft);
                b.transform.SetParent(self.ContentLeft.transform, false);
                var rect = b.GetComponent<RectTransform>();
                rect.localPosition = new Vector3(150, -index * 250 - 150, 0);
                b.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = hero.ConfigId.ToString();
                ++index;
            }
            var contentRect = self.ContentLeft.GetComponent<RectTransform>();
            var currentSize = contentRect.sizeDelta;
            contentRect.sizeDelta = new Vector2(currentSize.x, index * 250 + 300);

            self.HeroLeft.SetActive(false);
        }

        private static void DrawRightHeros(this MicroDustSelectHeroUIComponent self)
        {
            var heros = self.Root().GetComponent<MicroDustHeroComponent>();
            var index = 0;
            const int hight = 80;
            foreach (var hero in heros.Heros)
            {
                var panel = UnityEngine.Object.Instantiate(self.HeroRight);
                panel.transform.SetParent(self.ContentRight.transform, false);
                var rect = panel.GetComponent<RectTransform>();
                rect.localPosition = new Vector3(10, 390 - index * hight, 0);
                rect.sizeDelta = new Vector2(1500, hight);
                ++index;

                var heroConfig = MicroDustHeroConfigCategory.Instance.Get(hero.ConfigId);
                panel.transform.Find("heroname").GetComponent<TMP_Text>().text = heroConfig.Name;
                panel.transform.Find("herocamp").GetComponent<TMP_Text>().text = heroConfig.Camp;
                panel.transform.Find("herolevel").GetComponent<TMP_Text>().text = hero.Level.ToString();
                panel.transform.Find("heroruler").GetComponent<TMP_Text>().text = heroConfig.Ruler;
                panel.transform.Find("heroused").GetComponent<TMP_Text>().text = "-";
                panel.transform.Find("herofire").GetComponent<TMP_Text>().text = heroConfig.Fire;
                panel.transform.Find("herowater").GetComponent<TMP_Text>().text = heroConfig.Water;
                panel.transform.Find("heroearth").GetComponent<TMP_Text>().text = heroConfig.Earth;
                panel.transform.Find("herowood").GetComponent<TMP_Text>().text = heroConfig.Wood;
                panel.transform.Find("herometal").GetComponent<TMP_Text>().text = heroConfig.Metal;
                panel.transform.Find("heroid").GetComponent<TMP_Text>().text = hero.Id;
                panel.transform.Find(MicroDustSelectHeroUIComponent.ChooseButton).gameObject.SetActive(false);
                self.AllHeroPanels.Add(panel);
                panel.GetComponent<Button>().onClick.AddListener(() => self.OnHeroPanelClick(panel).Coroutine());
                panel.transform.Find(MicroDustSelectHeroUIComponent.ChooseButton).GetComponent<Button>().
                    onClick.AddListener(() => self.OnChooseClick(panel).Coroutine());
            }
            var contentRect = self.ContentRight.GetComponent<RectTransform>();
            var currentSize = contentRect.sizeDelta;
            contentRect.sizeDelta = new Vector2(currentSize.x, index * hight + 50);

            self.HeroRight.SetActive(false);
        }

        private static async ETTask OnHeroPanelClick(this MicroDustSelectHeroUIComponent self, GameObject panel)
        {
            // Log.Debug($"Hero: all-{self.AllHeroPanels.Count}, index-{panel.name}");
            foreach (var hero in self.AllHeroPanels)
            {
                hero.transform.Find(MicroDustSelectHeroUIComponent.ChooseButton).gameObject.SetActive(false);
            }
            var heroId = panel.transform.Find("heroid").GetComponent<TMP_Text>().text;
            var armyComponent = self.Root().PlayerComponent().GetComponent<MicroDustArmyComponent>();
            if (!armyComponent.IsHeroInUse(heroId))
            {
                panel.transform.Find(MicroDustSelectHeroUIComponent.ChooseButton).gameObject.SetActive(true);
            }

            await ETTask.CompletedTask;
        }

        private static async ETTask OnChooseClick(this MicroDustSelectHeroUIComponent self, GameObject panel)
        {
            var heroId = panel.transform.Find("heroid").GetComponent<TMP_Text>().text;
            //Log.Debug($"hero: id-{heroId}");

            var army = self.Root().GetComponent<MicroDustConfigureArmyComponent>();
            await MicroDustConfigureArmyHelper.ConfigureArmy(self.Root(), army.SelectedArmy, army.SelectedHero, heroId);

            await UIHelper.Create(self.Root(), UIType.MicroDustConfigureArmy, UILayer.Mid);
            await UIHelper.Remove(self.Root(), UIType.MicroDustSelectHero);
        }
    }
}
