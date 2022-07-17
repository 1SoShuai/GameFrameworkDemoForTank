using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Tank
{
    /// <summary>
    /// 修改脚本模板的项目名称
    /// </summary>
    public class ReplaceScriptKeyword : UnityEditor.AssetModificationProcessor
    {
        public static void OnWillCreateAsset(string path)
        {
            path = path.Replace(".meta", "").Replace("Assets", "");

            if (!path.Contains(".cs")) return;

            string dataPath = Application.dataPath + path;

            string file = System.IO.File.ReadAllText(dataPath);

            file = file.Replace("#PROJECTNAME#", PlayerSettings.productName);

            System.IO.File.WriteAllText(dataPath, file, System.Text.Encoding.UTF8);

            AssetDatabase.Refresh();
        }
    }
}
