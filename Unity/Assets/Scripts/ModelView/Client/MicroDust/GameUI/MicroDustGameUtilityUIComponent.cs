using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class MicroDustGameUtilityUIComponent : Entity, IAwake
    {
        public GameObject Map;
        public GameObject Battle;
        public GameObject Friend;
        public GameObject Mail;
    }
}
