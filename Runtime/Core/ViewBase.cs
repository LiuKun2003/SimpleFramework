using UnityEngine;
using UnityEngine.Assertions;

namespace LK.SimpleFramework
{
    public class ViewBase : MonoBehaviour, IView
    {
        /// <summary>
        /// 获取指定类型的控制器
        /// </summary>
        public T GetController<T>() where T : class, IController, new()
        {
            T res = InstanceCollector.Instance.GetInstance<T>();

#if UNITY_ASSERTIONS
            Assert.IsNotNull(res);
#endif

            return res;
        }
    }
}
