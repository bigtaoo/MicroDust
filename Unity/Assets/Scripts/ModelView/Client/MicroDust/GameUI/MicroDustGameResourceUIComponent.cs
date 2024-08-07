using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class MicroDustGameResourceUIComponent : Entity, IAwake, ILateUpdate
    {
        public GameObject WoodCurrent;
        public GameObject WoodProduce;
        public GameObject IronCurrent;
        public GameObject IronProduce;
        public GameObject FoodCurrent;
        public GameObject FoodProduce;
        public GameObject StoneCurrent;
        public GameObject StoneProduce;

        public long ResourceUpdateTime;
    }
}
