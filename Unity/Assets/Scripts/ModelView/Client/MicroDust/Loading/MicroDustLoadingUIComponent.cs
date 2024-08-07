using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class MicroDustLoadingUIComponent : Entity, IAwake
    {
        public GameObject EnterMapButton;
    }
}
