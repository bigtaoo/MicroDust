using TMPro;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustGameInfoUIComponent))]
    [FriendOf(typeof(MicroDustGameInfoUIComponent))]
    [FriendOfAttribute(typeof(MicroDustGameInfoUIComponent))]
    public static partial class MicroDustGameInfoSystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustGameInfoUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.Diamond = rc.Get<GameObject>("DiamondValue");
            self.Gold = rc.Get<GameObject>("GoldValue");
            self.Spirit = rc.Get<GameObject>("SpiritValue");
            self.Territory = rc.Get<GameObject>("TerritoriesValue");
            self.Power = rc.Get<GameObject>("PowerValue");
            self.Reputation = rc.Get<GameObject>("ReputationValue");

            self.Update();
        }

        private static void Update(this MicroDustGameInfoUIComponent self)
        {
            var numericComponent = self.Root().GetComponent<MicroDustClientPlayerComponent>()?.GetComponent<MicroDustNumericComponent>();
            if (numericComponent == null)
            {
                return;
            }
            Log.Debug($"GameInfo, {numericComponent.NumericDic.Count}");
            self.Diamond.GetComponent<TMP_Text>().text = numericComponent.NumericDic[MicroDustNumericTypes.Diamond].ToString();
            self.Gold.GetComponent<TMP_Text>().text = numericComponent.NumericDic[MicroDustNumericTypes.GoldCurrent].ToString();
            self.Territory.GetComponent<TMP_Text>().text = numericComponent.NumericDic[MicroDustNumericTypes.Territory].ToString();
            self.Power.GetComponent<TMP_Text>().text = numericComponent.NumericDic[MicroDustNumericTypes.Power].ToString();
            self.Spirit.GetComponent<TMP_Text>().text = numericComponent.NumericDic[MicroDustNumericTypes.Spirit].ToString();
            self.Reputation.GetComponent<TMP_Text>().text = numericComponent.NumericDic[MicroDustNumericTypes.Reputation].ToString();
        }
    }
}
