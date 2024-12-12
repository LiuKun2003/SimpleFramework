using UnityEngine;

namespace LK.SimpleFramework.Editor
{
    /// <summary>
    /// SimpleFramework配置文件
    /// </summary>
    //[CreateAssetMenu(fileName = "SimpleFrameworkConfigure", menuName = "SimpleFrameworkConfigure", order = 0)]
    public class SimpleFrameworkConfigures : ScriptableObject
    {
        #region Scripts 脚本模块
        /// <summary>
        /// 需要替换的脚本宏
        /// </summary>
        public string Script_Define;
        /// <summary>
        /// 脚本宏替换后的文本
        /// </summary>
        public string Script_Replace;
        #endregion
    }
}
