using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class MicroDustGameMainUIComponent : Entity, IAwake
    {
        public GameObject Mission;
        public GameObject Hero;
        public GameObject Skill;
        public GameObject Politic;
        public GameObject More;
        public GameObject Recruit;
        public GameObject Chat;
    }
}
