using TMPro;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustGameResourceUIComponent))]
    [FriendOf(typeof(MicroDustGameResourceUIComponent))]
    [FriendOfAttribute(typeof(MicroDustGameResourceUIComponent))]
    public static partial class MicroDustGameResourceSystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustGameResourceUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.StoneProduce = rc.Get<GameObject>("StoneProduceValue");
            self.StoneCurrent = rc.Get<GameObject>("StoneValue");
            self.IronProduce = rc.Get<GameObject>("IronProduceValue");
            self.IronCurrent = rc.Get<GameObject>("IronValue");
            self.FoodProduce = rc.Get<GameObject>("FoodProduceValue");
            self.FoodCurrent = rc.Get<GameObject>("FoodValue");
            self.WoodProduce = rc.Get<GameObject>("WoodProduceValue");
            self.WoodCurrent = rc.Get<GameObject>("WoodValue");

            self.ResourceUpdateTime = TimeInfo.Instance.ClientFrameTime();

            self.Update();
        }

        [EntitySystem]
        private static void LateUpdate(this MicroDustGameResourceUIComponent self)
        {
            var currentTime = TimeInfo.Instance.ClientFrameTime();
            if (currentTime - self.ResourceUpdateTime < MicroDustConstants.ResourceDeltaSeconds)
            {
                return;
            }
            self.ResourceUpdateTime += MicroDustConstants.ResourceDeltaSeconds;

            var numericComponent = self.Root().GetComponent<MicroDustClientPlayerComponent>()?.GetComponent<MicroDustNumericComponent>();
            if (numericComponent == null)
            {
                return;
            }
            MicroDustResource.UpdateResource(numericComponent, 1);

            self.Update();
        }

        private static void Update(this MicroDustGameResourceUIComponent self)
        {
            var numericComponent = self.Root().GetComponent<MicroDustClientPlayerComponent>()?.GetComponent<MicroDustNumericComponent>();
            if (numericComponent == null)
            {
                return;
            }
            Log.Debug($"GameInfo, {numericComponent.NumericDic.Count}");
            self.FoodCurrent.GetComponent<TMP_Text>().text = numericComponent.NumericDic[MicroDustNumericTypes.FoodCurrent].ToString();
            self.FoodProduce.GetComponent<TMP_Text>().text = numericComponent.NumericDic[MicroDustNumericTypes.FoodProduce].ToString();
            self.WoodCurrent.GetComponent<TMP_Text>().text = numericComponent.NumericDic[MicroDustNumericTypes.WoodCurrent].ToString();
            self.WoodProduce.GetComponent<TMP_Text>().text = numericComponent.NumericDic[MicroDustNumericTypes.WoodProduce].ToString();
            self.IronCurrent.GetComponent<TMP_Text>().text = numericComponent.NumericDic[MicroDustNumericTypes.IronCurrent].ToString();
            self.IronProduce.GetComponent<TMP_Text>().text = numericComponent.NumericDic[MicroDustNumericTypes.IronProduce].ToString();
            self.StoneCurrent.GetComponent<TMP_Text>().text = numericComponent.NumericDic[MicroDustNumericTypes.StoneCurrent].ToString();
            self.StoneProduce.GetComponent<TMP_Text>().text = numericComponent.NumericDic[MicroDustNumericTypes.StoneProduce].ToString();
        }
    }
}
