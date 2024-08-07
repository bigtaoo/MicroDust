using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class MicroDustRecruitUIComponent : Entity, IAwake
    {
        public GameObject GoodPack;
        public GameObject NormalPack;
        public GameObject Once;
        public GameObject Five;
        public GameObject Back;
    }
}
