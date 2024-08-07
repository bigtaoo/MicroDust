using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class MicroDustMoreUIComponent : Entity, IAwake
    {
        public GameObject InitializeMap;
    }
}
