using UnityEngine;

namespace ET.Client
{
    public class MicroDustArmyCommandUIComponent : Entity, IAwake
    {
        public GameObject Back;
        public GameObject Target;
        public GameObject Command;

        public ListComponent<GameObject> Icons = new();
        public ListComponent<GameObject> Status = new();
        public ListComponent<GameObject> Soilders = new();
        public ListComponent<GameObject> Seconds = new();
        public ListComponent<GameObject> Thirds = new();
        public ListComponent<GameObject> Levels = new();
        public ListComponent<GameObject> Names = new();
    }
}
