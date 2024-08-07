﻿namespace ET.Server
{
    public static class MicroDustGateMapFactory
    {
        public static async ETTask<Scene> Create(Entity parent, long id, long instanceId, string name)
        {
            await ETTask.CompletedTask;
            var scene = EntitySceneFactory.CreateScene(parent, id, instanceId, SceneType.Map, name);

            scene.AddComponent<MicroDustPlayerComponent>();
            //scene.AddComponent<AOIManagerComponent>();
            //scene.AddComponent<RoomManagerComponent>();

            scene.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);

            return scene;
        }
    }
}
