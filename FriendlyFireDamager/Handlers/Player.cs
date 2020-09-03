using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.Events.EventArgs;
using Exiled.API.Features;

namespace FriendlyFireDamager.Handlers
{
    class Player
    {
        internal readonly Dictionary<Exiled.API.Features.Player, int> TKs = new Dictionary<Exiled.API.Features.Player, int>();
        public void OnHurt(HurtingEventArgs ev)
        {
            if (ev.Attacker.Team == ev.Target.Team)
            {
                Log.Info(ev.Attacker + " Team Killed " + ev.Target);
                if (TKs.ContainsKey(ev.Attacker))
                {
                    Log.Info(ev.Attacker + " Has Team Killed Before");
                    if (TKs.ContainsValue(FriendlyFireDamager.instance.Config.tksAllowed))
                    {
                        Log.Info(ev.Attacker + " Has Team Killed twice or more causing " + ev.Amount + " damage to player");
                        ev.IsAllowed = false;
                        ev.Attacker.Hurt(ev.Amount, ev.Attacker, ev.DamageType);
                        var BroadcastMessage = FriendlyFireDamager.instance.Config.tkBroadcastMessage;
                        Map.Broadcast(FriendlyFireDamager.instance.Config.tkBroadcastDuration, BroadcastMessage.Replace("%player", ev.Attacker.Nickname));
                    }
                }
            }
        }
        public void OnDeath(DiedEventArgs ev)
        {
            if (ev.Target.Team == ev.Killer.Team)
            {
                TKs[ev.Killer]++;
            }
        }
    }
}
