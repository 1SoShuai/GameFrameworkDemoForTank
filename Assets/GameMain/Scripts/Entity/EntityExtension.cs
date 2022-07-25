using GameFramework.DataTable;
using System;
using System.Collections.Generic;
using UnityGameFramework.Runtime;

namespace Tank
{
    /// <summary>
    /// 实体拓展类
    /// </summary>
    public static class EntityExtension
    {
        private static int m_serialId = 0;

        public static void ShowEntity<T>(this EntityComponent entityComponent, EntityData data) where T : EntityLogic
        {
            Log.Info("Show entity :" + data.Id + ":" + data.TypeId);
            IDataTable<DREntity> dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
            DREntity dREntity = dtEntity.GetDataRow(data.TypeId);

            string assetName = AssetUtility.GetEntityAsset(dREntity.AssetName);

            GameEntry.Entity.ShowEntity(data.Id, typeof(T), assetName, dREntity.GroupName, data);
        }

        public static int GenerateSerialId(this EntityComponent entityComponent)
        {
            return --m_serialId;
        }
    }
}
