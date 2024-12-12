using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace LK.SimpleFramework.Editor
{
    internal class SimpleFrameworkConfigureWindow : EditorWindow
    {

        #region Private fields and properties
        private SerializedObject m_ConfigureStream;
        #endregion

        #region Private methods
        private SimpleFrameworkConfigureWindow()
        {
            titleContent = new GUIContent(SimpleFrameworkEditor.Name);
        }

        private void CreateGUI()
        {
            if (m_ConfigureStream == null)
            {
                m_ConfigureStream = new SerializedObject(SimpleFrameworkEditor.ConfigureSource);
            }
            VisualElement element = SimpleFrameworkEditor.ConfigureUI.Instantiate();
            element.Bind(m_ConfigureStream);
            rootVisualElement.Add(element);
        }

        private void Update()
        {
            if (m_ConfigureStream != null)
            {
                m_ConfigureStream.Update();
            }
        }

        private void OnDestroy()
        {
            if (m_ConfigureStream != null)
            {
                m_ConfigureStream.ApplyModifiedProperties();
            }
        }
        #endregion
    
    }
}
