using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class MicroDustConfigureArmyUIComponent : Entity, IAwake
    {
        public GameObject Back;

        // army
        public ListComponent<GameObject> Heros = new();
        public GameObject ArmyType;
        public GameObject ArmySwitch;

        // info
        public GameObject Name;
        public GameObject Ruler;
        public GameObject Soldiers;
        public GameObject MoveSpeed;
        public GameObject CityDestory;

        // soldier
        public GameObject SoldierReady;
        public GameObject Auto;
        public ListComponent<GameObject> Less = new();
        public ListComponent<GameObject> More = new();
        public ListComponent<GameObject> Slider = new();
        public GameObject Confirm;
    }
}
