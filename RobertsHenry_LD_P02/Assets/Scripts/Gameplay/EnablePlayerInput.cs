using Platformer.Core;
using Platformer.Model;

namespace Platformer.Gameplay
{
    /// <summary>
    /// This event is fired when user input should be enabled.
    /// </summary>
    public class EnablePlayerInput : Simulation.Event<EnablePlayerInput>
    {
        GameController model = Simulation.GetModel<GameController>();

        public override void Execute()
        {
            var player = model.player;
            player.controlEnabled = true;
        }
    }
}