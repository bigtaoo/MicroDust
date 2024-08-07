using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustHerosUIComponent))]
    [FriendOf(typeof(MicroDustHerosUIComponent))]
    [FriendOfAttribute(typeof(MicroDustHerosUIComponent))]
    public static partial class MicroDustHerosUISystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustHerosUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.Back = rc.Get<GameObject>("back");
            self.Content = rc.Get<GameObject>("Content");
            self.Hero = rc.Get<GameObject>("hero");

            self.DisplayHeros();

            self.Back.GetComponent<Button>().onClick.AddListener(() => { self.OnBackClick().Coroutine(); });
            self.Hero.SetActive(false);
        }

        private static async ETTask OnBackClick(this MicroDustHerosUIComponent self)
        {
            await UIHelper.Remove(self.Root(), UIType.MicroDustHeros);
        }

        private static async ETTask OnHeroClick(this MicroDustHerosUIComponent self, MicroDustHero hero)
        {
            MicroDustSelectHeroHelper.SelectHero(self.Root(), hero);
            await UIHelper.Create(self.Root(), UIType.MicroDustHeroDetails, UILayer.Mid);
        }

        private static void DisplayHeros(this MicroDustHerosUIComponent self)
        {
            var heros = self.Root().GetComponent<MicroDustHeroComponent>();
            var index = 0;
            foreach (var hero in heros.Heros)
            {
                var b = UnityEngine.Object.Instantiate(self.Hero);
                var offsetX = index % 3;
                var offsetY = index / 3;
                ++index;
                b.transform.SetParent(self.Content.transform, false);
                var rect = b.GetComponent<RectTransform>();
                rect.localPosition = new Vector3(offsetX * 470, -offsetY * 370, 0);
                var config = MicroDustHeroConfigCategory.Instance.Get(hero.ConfigId);

                b.GetComponent<Button>().onClick.AddListener(() => { self.OnHeroClick(hero).Coroutine(); });

                var texts = b.GetComponentsInChildren<TMPro.TextMeshProUGUI>();
                foreach (var text in texts)
                {
                    if (text.name == "ruler")
                    {
                        text.text = config.Ruler;
                    }
                    else if (text.name == "level")
                    {
                        text.text = hero.Level.ToString();
                    }
                    else if (text.name == "name")
                    {
                        text.text = config.Name;
                    }
                    else
                    {
                        text.text = config.Name;
                    }
                }

                var images = b.GetComponentsInChildren<Image>();
                foreach (var image in images)
                {
                    if (image.name == "star5" && config.Type < 5)
                    {
                        image.gameObject.SetActive(false);
                    }
                    else if (image.name == "star4" && config.Type < 4)
                    {
                        image.gameObject.SetActive(false);
                    }
                    else if (image.name == "star3" && config.Type < 3)
                    {
                        image.gameObject.SetActive(false);
                    }
                    else if (image.name == "star2" && config.Type < 2)
                    {
                        image.gameObject.SetActive(false);
                    }
                }
            }
            var contentRect = self.Content.GetComponent<RectTransform>();
            var currentSize = contentRect.sizeDelta;
            contentRect.sizeDelta = new Vector2(currentSize.x, index / 3 * 370 + 500);
        }
    }
}
