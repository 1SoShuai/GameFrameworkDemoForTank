using GameFramework;
using System;
using System.Collections.Generic;

namespace Tank
{
    /// <summary>
    /// 资源路径功能类
    /// </summary>
    public static class AssetUtility
    {
        /// <summary>
        /// 根据名称获取UI资源地址
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetUIFormAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/UI/UIForms/{0}.prefab", assetName);
        }

        /// <summary>
        /// 根据名称获取场景资源地址
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetSceneAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/Scenes/{0}.unity", assetName);
        }

        /// <summary>
        /// 根据名称获取实体资源地址
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public static string GetEntityAsset(string entityName)
        {
            return Utility.Text.Format("Assets/GameMain/Entities/{0}.prefab", entityName);
        }

        /// <summary>
        /// 加载数据表
        /// </summary>
        /// <param name="tableName">数据表名称</param>
        /// <param name="fromBytes">是否以bytes形式加载资源</param>
        /// <returns></returns>
        public static string GetDataTableAsset(string tableName, bool fromBytes)
        {
            return Utility.Text.Format("Assets/GameMain/DataTables/{0}.{1}", tableName, fromBytes ? "bytes" : "txt");
        }
    }
}
