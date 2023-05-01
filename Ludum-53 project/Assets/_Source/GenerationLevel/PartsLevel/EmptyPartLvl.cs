namespace _Source.GenerationLevel.PartsLevel
{
    public class EmptyPartLvl : APartLevel
    {
        public override void Unvisible()
        {
            ReturnToPool();
        }

        protected override void ReturnToPool()
        {
            _poolParts.AddToPool(typeof(EmptyPartLvl), this);
        }
    }
}