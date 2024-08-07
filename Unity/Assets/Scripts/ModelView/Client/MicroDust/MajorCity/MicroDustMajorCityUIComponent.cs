using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class MicroDustMajorCityUIComponent : Entity, IAwake
    {
        public List<GameObject> Armies = new();
        public GameObject Back;
        public GameObject BuildBuildings;
        public GameObject RecruitSoldiers;
    }
}
