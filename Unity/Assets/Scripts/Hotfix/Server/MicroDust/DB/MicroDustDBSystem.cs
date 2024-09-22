//using MongoDB.Driver;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;

//namespace ET.Server
//{
//    //[EntitySystemOf(typeof(DBComponent))]
//    [FriendOf(typeof(DBComponent))]
//    public static partial class DBComponentSystem
//    {
//        public static async ETTask SaveWithComponents<T>(this DBComponent self, T entity, string collection) where T : Entity
//        {
//            Fiber fiber = self.Fiber();
//            if (entity == null)
//            {
//                Log.Error($"save entity is null: {typeof(T).FullName}");
//                return;
//            }

//            var dbObject = new MicroDustDBObject
//            {
//                Self = entity,
//            };
//            if (entity is MicroDustPlayerComponent unit)
//            {
//                dbObject.PlayerId = unit.UserId;
//            }
//            foreach (var component in entity.Components.Values)
//            {
//                dbObject.Entities.Add(component);
//            }

//            using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DB, entity.Id % DBComponent.TaskCount))
//            {
//                await self.GetCollection(collection).ReplaceOneAsync(d => d.Id == entity.Id, dbObject, new ReplaceOptions { IsUpsert = true });
//            }
//        }

//        public static async ETTask<T> QueryWithComponents<T>(this DBComponent self, Entity entity, Expression<Func<MicroDustDBObject, bool>> filter, string collection) where T : Entity
//        {
//            List<MicroDustDBObject> result;
//            using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DB, RandomGenerator.RandInt64() % DBComponent.TaskCount))
//            {
//                var cursor = await self.GetCollection<MicroDustDBObject>(collection).FindAsync(filter);
//                result = await cursor.ToListAsync();
//            }
//            Log.Debug($"Database: query result type: {result.GetType()}");
//            if (result.FirstOrDefault() is not MicroDustDBObject obj)
//            {
//                Log.Debug("Database, query with components is not MicroDustDBObject");
//                return null;
//            }

//            var r = obj.Self as T;
//            entity.RemoveComponent(r.GetType());
//            entity.AddComponent(r);
//            foreach(var c in obj.Entities)
//            {
//                Log.Debug($"Database, add component: {c.ToJson()}");
//                r.AddComponent(c);
//            }
//            Log.Debug($"Database, query result: {r.ToJson()}");
//            return r;
//        }
//    }
//}
