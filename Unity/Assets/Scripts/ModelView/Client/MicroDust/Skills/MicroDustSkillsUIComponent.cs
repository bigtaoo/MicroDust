using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class MicroDustSkillsUIComponent : Entity, IAwake
    {
        public GameObject Skill;
        public GameObject Content;
        public GameObject Back;
    }
}
