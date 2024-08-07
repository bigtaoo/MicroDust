using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class MicroDustLoginUIComponent : Entity, IAwake
    {
        public GameObject Account;
        public GameObject Password;
        public GameObject LoginButton;
    }
}
