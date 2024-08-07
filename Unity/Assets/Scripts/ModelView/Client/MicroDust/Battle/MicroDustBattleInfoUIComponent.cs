using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class MicroDustBattleInfoUIComponent : Entity, IAwake
    {
        public GameObject Back;
        public GameObject Summary;
        public GameObject Details;
    }
}