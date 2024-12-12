using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace LK.SimpleFramework.Editor
{
    internal class CsharpModificationProcessor : AssetModificationProcessor
    {
        #region Private fields and properties
        private static readonly char[] Separators = { ',' , '，', '\n'};
        #endregion

        #region Private methods
        /// <summary>
        /// 创建.cs文件时替换指定的宏
        /// </summary>
        private static void OnWillCreateAsset(string assetName)
        {
            assetName = assetName.Replace(".meta", "");
            if(assetName.EndsWith(".cs"))
            {
                string[] defines = SimpleFrameworkEditor.ConfigureSource.Script_Define.Split(Separators);
                string[] replaces = SimpleFrameworkEditor.ConfigureSource.Script_Replace.Split(Separators);
                string content = File.ReadAllText(assetName);
                for(int i = 0; i < Math.Min(defines.Length, replaces.Length); i++)
                {
                    string replace = replaces[i];
                    switch (replaces[i].ToLower())
                    {
                        case "time":
                            replace = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
                            break;
                        default:
                            replace = replaces[i];
                            break;
                    }
                    content = content.Replace($"#{defines[i]}#", replace);
                }
                File.WriteAllText(assetName, content);
            }
        }
        #endregion
    }
}
