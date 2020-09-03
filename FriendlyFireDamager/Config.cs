using Exiled.API.Interfaces;
using System.ComponentModel;

namespace FriendlyFireDamager
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("Sets how long the server broadcasts the TK message after they die")]
        public ushort tkBroadcastDuration { get; set; } = 5;
        [Description("Sets the broadcast message when the TKer died")]
        public string tkBroadcastMessage { get; set; } = "%player please dont teamkill on this server";
        [Description("Sets the amount of TKs before the server starts damaging the player(Note this also doesnt damage the players that are targets)")]
        public int tksAllowed { get; set; } = 2;
    }
}
