using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class MicroDustHeroDetailsUIComponent : Entity, IAwake
    {
        public GameObject Back;
        public GameObject GenerateSkill;
        public GameObject LevelUp;
        public GameObject Reset;
        public GameObject Skill3;
        public GameObject Skill2;
        public GameObject Skill1;
        public GameObject AddPolitic;
        public GameObject CurrentPolitic;
        public GameObject AddAgility;
        public GameObject CurrentAgility;
        public GameObject AddIntelligence;
        public GameObject CurrentIntelligence;
        public GameObject AddStrength;
        public GameObject CurrentStrength;
        public GameObject Energevalue;
        public GameObject Levelvalue;
        public GameObject Camp;
        public GameObject Power;
        public GameObject[] Stars = new GameObject[5];
        public GameObject Name;
        public GameObject Hero;
    }
}
