using System;
using System.Linq;

namespace ET.Client
{
    public static class MicroDustHerosHelper
    {
        public static async ETTask GetHerosInfo(Scene root, string uiType)
        {
            try
            {
                var result = await root.GetComponent<MicroDustClientSenderComponent>().Call(
                    new C2M_MicroDust_Heros()) as M2C_MicroDust_Heros;
                
                root.RemoveComponent<MicroDustHeroComponent>();
                var heros = root.AddComponent<MicroDustHeroComponent>();
                heros.Heros = result.heros.Select(h => ToHero(h)).ToList();

                EventSystem.Instance.Publish(root, new MicroDustFetchHerosFinished() { uiType = uiType });
            }
            catch (Exception e)
            {
                root.Fiber.Error(e);
            }
        }

        private static MicroDustHero ToHero(MicroDustHeroInfo heroInfo)
        {
            return new MicroDustHero
            {
                Id = heroInfo.Id,
                ConfigId = heroInfo.ConfigId,
                Level = heroInfo.Level,
                Star = heroInfo.Star,
            };
        }
    }
}
