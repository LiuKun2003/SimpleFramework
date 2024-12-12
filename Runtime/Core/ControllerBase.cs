using UnityEngine.Assertions;

namespace LK.SimpleFramework
{
    /// <summary>
    /// 表示一个控制器
    /// </summary>
    public abstract class ControllerBase : IController
    {
        /// <summary>
        /// 获取指定的数据模型
        /// </summary>
        public T GetModel<T>() where T : class, IModel, new()
        {
            T res = InstanceCollector.Instance.GetInstance<T>();

#if UNITY_ASSERTIONS
            Assert.IsNotNull(res);
#endif

            return res;
        }
    }
}
