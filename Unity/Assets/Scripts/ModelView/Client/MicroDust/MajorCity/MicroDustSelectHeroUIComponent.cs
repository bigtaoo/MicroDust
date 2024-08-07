using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class MicroDustSelectHeroUIComponent : Entity, IAwake
    {
        public GameObject Back;
        public GameObject ContentLeft;
        public GameObject HeroLeft;
        public GameObject ContentRight;
        public GameObject HeroRight;

        // hero info
        public GameObject HeroName;
        public GameObject HeroLevel;
        public GameObject HeroCamp;
        public GameObject HeroRuler;
        public GameObject HeroUsed;
        public GameObject HeroFire;
        public GameObject HeroWater;
        public GameObject HeroWood;
        public GameObject HeroMetal;
        public GameObject HeroEarth;
        public GameObject Choose;

        public ListComponent<GameObject> AllHeroPanels = new();
        public const string ChooseButton = "choose";
    }
}
