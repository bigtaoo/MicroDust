using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class MicroDustRecruitResultUIComponent : Entity, IAwake
    {
        public GameObject Once;
        public GameObject Five;
        public GameObject Back;
        public GameObject PanelOne;
        public GameObject HeroOne;
    }
}
