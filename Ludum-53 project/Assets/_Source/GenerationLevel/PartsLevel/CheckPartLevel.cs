using _Source.EventSystem;

namespace _Source.GenerationLevel.PartsLevel
{
    public class CheckPartLevel : APartLevel
    {
        public override void PlayerExit()
        {
            ReturnToPool();
            Signals.Get<FinishCheck>().Dispatch();
        }

        protected override void ReturnToPool()
        {
            _poolParts.AddToPool(typeof(CheckPartLevel), this);
        }
    }
}