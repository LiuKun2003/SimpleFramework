using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace LK.SimpleFramework.Editor
{
    /// <summary>
    /// SimpleFramework编辑器类
    /// </summary>
    internal static class SimpleFrameworkEditor
    {
        #region Public or protected fields and properties
        /// <summary>
        /// 标题名
        /// </summary>
        internal const string Name = "Simple Framework";

        /// <summary>
        /// 框架Editor目录路径
        /// </summary>
        internal const string EditorPath = "Packages/com.lk.simple-framework/Editor/";

        /// <summary>
        /// 框架配置文件
        /// </summary>
        internal static SimpleFrameworkConfigures ConfigureSource
        {
            get
            {
                if(m_ConfigureSource == null)
                {
                    m_ConfigureSource = LoadAsset<SimpleFrameworkConfigures>("Configure/SimpleFrameworkConfigure.asset");
                    if (m_ConfigureSource == null)
                    {
                        m_ConfigureSource = CreateConfigureSource();
                    }
                }
                return m_ConfigureSource;
            }
        }

        /// <summary>
        /// UI元素
        /// </summary>
        internal static VisualTreeAsset ConfigureUI
        { 
            get
            {
                if(m_ConfigureUI == null)
                {
                    m_ConfigureUI = LoadAsset<VisualTreeAsset>("Uxml/Configure.uxml");
                }
                return m_ConfigureUI;
            }
        }
        #endregion

        #region Private fields and properties
        /// <summary>
        /// Project Setting窗口对象
        /// </summary>
        private static SettingsProvider m_ProjectSettingWindow { get; set; }
        private static SimpleFrameworkConfigures m_ConfigureSource;
        private static VisualTreeAsset m_ConfigureUI;
        #endregion

        #region Public or protected methods
        /// <summary>
        /// 通过相对路径加载资源
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        internal static T LoadAsset<T>(string path) where T : UnityEngine.Object
        {
            path = Path.Combine(EditorPath, path);
            return AssetDatabase.LoadAssetAtPath<T>(path);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Project Setting 窗口
        /// </summary>
        /// <returns></returns>
        [SettingsProvider]
        private static SettingsProvider GetOrCreateSettingsProvider()
        {
            if(m_ProjectSettingWindow == null)
            {
                m_ProjectSettingWindow = new SettingsProvider("Project/MyCustomIMGUISettings", SettingsScope.Project)
                {
                    label = SimpleFrameworkEditor.Name,
                    activateHandler = SimpleFrameworkSettingsProvider.Activate,
                    inspectorUpdateHandler = SimpleFrameworkSettingsProvider.Updata,
                    deactivateHandler = SimpleFrameworkSettingsProvider.Deactivate
                };
            }
            return m_ProjectSettingWindow;
        }

        /// <summary>
        /// 创建配置文件
        /// </summary>
        /// <returns></returns>
        private static SimpleFrameworkConfigures CreateConfigureSource()
        {
            SimpleFrameworkConfigures source = ScriptableObject.CreateInstance<SimpleFrameworkConfigures>();
            AssetDatabase.CreateAsset(source, "Packages/com.lk.simple-framework/Editor/Configure/SimpleFrameworkConfigure.asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            return source;
        }

        /// <summary>
        /// 打开配置窗口
        /// </summary>
        [MenuItem(Name + "/Configure")]
        private static void OpenConfigureWindow() 
        {
            EditorWindow.GetWindow<SimpleFrameworkConfigureWindow>();
        }
        #endregion
    
    }
}
