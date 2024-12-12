using LK.SimpleFramework.Editor;
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
    /// 用于在Project Setting中创建配置窗口
    /// </summary>
    internal class SimpleFrameworkSettingsProvider
    {
        #region Private fields and properties
        private static SerializedObject m_ConfigureStream;
        #endregion

        #region Public or protected methods
        internal static void Activate(string searchContext, VisualElement rootElement)
        {
            if (m_ConfigureStream == null)
            {
                m_ConfigureStream = new SerializedObject(SimpleFrameworkEditor.ConfigureSource);
            }
            VisualElement element = SimpleFrameworkEditor.ConfigureUI.Instantiate();
            element.Bind(m_ConfigureStream);
            rootElement.Add(element);
        }
        internal static void Updata()
        {
            if (m_ConfigureStream != null)
            {
                m_ConfigureStream.Update();
            }
        }
        internal static void Deactivate()
        {
            if (m_ConfigureStream != null)
            {
                m_ConfigureStream.ApplyModifiedProperties();
            }
        }
        #endregion
    }
}
