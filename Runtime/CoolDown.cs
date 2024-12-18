using UnityEngine;

namespace LK.SimpleFramework
{
    /// <summary>
    /// <para>表示一段冷却时间的对象</para>
    /// <para>此类内部使用<see cref="Time.time"/>来计算，所以会受到<see cref="Time.timeScale"/>的影响。</para>
    /// </summary>
    public class CoolDown
    {
        private float _endTime;
        private float _stopTime;
        private float _coolDownTime;
        private bool _isRunning;

        /// <summary>
        /// 使用指定的冷却时间初始化<see cref="CoolDown"/>新实例。
        /// </summary>
        /// <param name="coolDownTime">冷却需要的时间。</param>
        public CoolDown(float coolDownTime)
        {
            _coolDownTime = coolDownTime;
            Overload();
        }

        /// <summary>
        /// 获取一个值，此值指示了是否冷却完毕。
        /// </summary>
        public bool IsCool
        {
            get
            {
                if (_isRunning)
                {
                    return Time.time >= _endTime;
                }
                else
                {
                    return _stopTime >= _endTime;
                }
            }
        }

        /// <summary>
        /// 获取一个值，此值指示了冷却是否在进行中。
        /// </summary>
        public bool IsRunning => _isRunning;

        /// <summary>
        /// 获取冷却需要的时间。
        /// </summary>
        public float CoolDownTime => _coolDownTime;

        /// <summary>
        /// 使冷却重新开始。
        /// </summary>
        public void Overload()
        {
            _isRunning = true;
            _endTime = Time.time + _coolDownTime;
        }

        /// <summary>
        /// 如果冷却正在进行，则暂停冷却。
        /// </summary>
        public void Pause()
        {
            if (_isRunning)
            {
                _stopTime = Time.time;
                _isRunning = false;
            }
        }

        /// <summary>
        /// 如果冷却已经暂停，则继续冷却。
        /// </summary>
        public void Continue()
        {
            if (!_isRunning)
            {
                _endTime += Time.time - _stopTime;
                _isRunning = true;
            }
        }

        /// <summary>
        /// <para>修改冷却需要的时间。</para>
        /// <para>修改行为会立刻生效，如果将时间修改的更短，则当前冷却可能会立刻完成；如果将时间修改的更长，则已经冷却完毕也可能失效。
        /// 请确保修改行为不会使其他依赖于此对象的逻辑产生错误。</para>
        /// </summary>
        /// <param name="coolDownTime">新的冷却时间。</param>
        public void AlterCoolDownTime(float coolDownTime)
        {
            _endTime += coolDownTime - _coolDownTime;
            _coolDownTime = coolDownTime;
        }

        public override string ToString()
        {
            return IsCool ? "Cool" : "Overload";
        }
    }
}
