using _Source.EventSystem;

namespace _Source.GenerationLevel.PartsLevel
{
    public class CheckPartLevel : APartLevel
    {
        public void PlayerEnter()
        {
            Signals.Get<OnGenerateNextLevel>().Dispatch();
        }
        public override void Unvisible()
        {
            ReturnToPool();
        }

        protected override void ReturnToPool()
        {
            _poolParts.AddToPool(typeof(CheckPartLevel), this);
        }
    }
}