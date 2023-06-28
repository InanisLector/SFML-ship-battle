using System.Xml.Linq;
using System;

namespace AgarIO.scripts.GameEngine
{
    public abstract class GameObject
    {
        protected Tags<string> tags = new();

        public Transform transform { get; protected set; } = new();
        protected MeshRenderer? mesh;

        private List<Script> scripts = new();

        public bool IsCollideable 
            { get; protected set; } = true;

        protected bool IsDead = false;

        protected GameObject()
        {
            GameObjectLoop.Instance += this;
        }

        public void CallAwake()
        {
            if (IsDead)
                return;

            foreach(var script in scripts)
                script?.Awake();
        }

        public void CallUpdate()
        {
            if (IsDead)
                return;

            foreach (var script in scripts)
                script?.Update();
        }

        protected void Destroy()
        {
            IsDead = true;
            mesh?.OnDestroy();

            GameObjectLoop.Instance -= this;
        }

        public bool ContainsTag(string tag)
            => tags.Contains(tag);

        public T? GetComponent<T>() where T : Script
        {
            foreach (var script in scripts)
            {
                if(script is T)
                    return (T)script;
            }

            return null;
        }

        public MeshRenderer? GetMeshRenderer()
        => mesh;
    }
}