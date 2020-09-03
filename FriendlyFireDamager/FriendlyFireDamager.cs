using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.API.Enums;

namespace FriendlyFireDamager
{
    public class FriendlyFireDamager : Plugin<Config>
    {
        private static readonly Lazy<FriendlyFireDamager> LazyInstance = new Lazy<FriendlyFireDamager>(valueFactory: () => new FriendlyFireDamager());
        static public FriendlyFireDamager instance => LazyInstance.Value;
        public override PluginPriority Priority { get; } = PluginPriority.Medium;
        private FriendlyFireDamager()
        {

        }
        public override void OnEnabled()
        {
            RegisterEvents();
        }
        public override void OnDisabled()
        {
            UnregisterEvents();
        }
        private Handlers.Player player;
        public void RegisterEvents()
        {
            player = new Handlers.Player();
            Exiled.Events.Handlers.Player.Hurting += player.OnHurt;
            Exiled.Events.Handlers.Player.Died += player.OnDeath;
        }
        public void UnregisterEvents()
        {
            Exiled.Events.Handlers.Player.Hurting -= player.OnHurt;
            Exiled.Events.Handlers.Player.Died -= player.OnDeath;
        }
    }
}
