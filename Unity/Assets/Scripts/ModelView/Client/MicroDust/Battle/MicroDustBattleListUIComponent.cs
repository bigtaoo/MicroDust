using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class MicroDustBattleListUIComponent : Entity, IAwake
    {
        public GameObject Back;
        public GameObject BattleInfo;
    }
}
