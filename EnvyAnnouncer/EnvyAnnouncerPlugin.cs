using EnvyAnnouncer.Models;
using Rocket.Core.Plugins;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;

namespace EnvyAnnouncer
{
    public class EnvyAnnouncerPlugin : RocketPlugin<EnvyAnnouncerConfiguration>
    {
        public static EnvyAnnouncerPlugin Instance;
        private MessageController messageController;
        protected override void Load()
        {
            Instance = this;
            messageController = new MessageController();
            
        }



        public static void MandarMensaje(string message, string icon)
        {
            ChatManager.serverSendMessage(message.Replace('(', '<').Replace(')', '>'), Color.white, null, null, EChatMode.GLOBAL, icon, true);
        }
        protected override void Unload()
        {
            messageController.Dispose();
        }
    }
}
