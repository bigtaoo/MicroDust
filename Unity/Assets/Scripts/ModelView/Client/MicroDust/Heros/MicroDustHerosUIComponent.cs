using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class MicroDustHerosUIComponent : Entity, IAwake
    {
        public GameObject Hero;
        public GameObject Content;
        public GameObject Back;
    }
}
