using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class MicroDustCameraComponent : Entity, IAwake, ILateUpdate
    {
        private Camera _camera;
        public Transform Transform;
        public bool IsMouseLeftButtonDown;
        public Vector3 LastMousePosition;
        public Vector3 MouseDownPosition;

        public Camera Camera
        {
            get
            {
                return _camera;
            }
            set
            {
                _camera = value;
                Transform = _camera.transform;
            }
        }

        public void SetPosition(float x, float y)
        {
            _camera.transform.position = new Vector3(x, y, -6);
        }
    }
}
