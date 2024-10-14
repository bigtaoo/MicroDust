using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class MicroDustArmyConfirmUIComponent : Entity, IAwake
    {
        public GameObject Back;
        public GameObject Command;
        public GameObject Resource;
        public GameObject Defender;
        public GameObject Energy;
        public GameObject Time;
        public GameObject Distance;
        public GameObject Path;
        public GameObject Arrive;
        public GameObject MiddleText;

        public ListComponent<GameObject> Heros = new();
        public ListComponent<GameObject> Camps = new();
        public ListComponent<GameObject> Stars1 = new();
        public ListComponent<GameObject> Stars2 = new();
        public ListComponent<GameObject> Stars3 = new();
        public ListComponent<GameObject> Levels = new();
        public ListComponent<GameObject> Names = new();
        public ListComponent<GameObject> Position = new();
        public ListComponent<GameObject> Soldiers = new();
        public ListComponent<GameObject> Camplevels = new();

        public GameObject Action;
        public GameObject TotalSoldiers;
        public GameObject MoveSpeed;
        public GameObject CityAttack;
        public GameObject AutoBack;
    }
}
