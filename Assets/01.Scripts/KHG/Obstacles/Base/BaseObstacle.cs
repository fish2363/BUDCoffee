using UnityEngine;

namespace KHG.Obstacles
{
    public abstract class BaseObstacle : MonoBehaviour
    {
        public virtual void Initialize() { }
        public virtual void Activate() { }
        public virtual void Deactivate() { }
    }

}