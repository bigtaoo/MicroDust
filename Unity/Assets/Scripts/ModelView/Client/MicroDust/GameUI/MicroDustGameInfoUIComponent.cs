using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class MicroDustGameInfoUIComponent : Entity, IAwake
    {
        public GameObject Diamond;
        public GameObject Gold;
        public GameObject Spirit;
        public GameObject Territory;
        public GameObject Power;
        public GameObject Reputation;
    }
}
