namespace AgarIO.scripts.GameEngine
{ 
    public abstract class Script
    {
        protected GameObject parent { get; private set; }

        public Script(GameObject parent)
        {
            this.parent = parent;
        }

        public virtual void Awake() { }

        public virtual void Update() { }
    }
}