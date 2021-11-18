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
        private int contador;
        private Timer timer;
        protected override void Load()
        {
            Instance = this;
            contador = 0;

            timer = new Timer(1000 * Configuration.Instance.Time); timer.Elapsed += Timer_Elapsed; timer.AutoReset = true; timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
           


            if (Configuration.Instance.RandomizeMessages)
            {
                Message message = Configuration.Instance.Messages.RandomOrDefault();
                ChatManager.serverSendMessage(message.Content.Replace('(', '<').Replace(')', '>'), Color.white, null, null, EChatMode.GLOBAL, message.Icon, true);
                if (Configuration.Instance.ShowInConsole) Console.WriteLine(message.Content);
            }
            else
            {
                try
                {
                    Message message = Configuration.Instance.Messages[contador];
                    ChatManager.serverSendMessage(message.Content.Replace('(', '<').Replace(')', '>'), Color.white, null, null, EChatMode.GLOBAL, message.Icon, true);


                    if (Configuration.Instance.ShowInConsole) Console.WriteLine(message.Content);
                    contador++;
                }
                catch
                {
                    contador = 0;
                }
                
            }
        }


        protected override void Unload()
        {
            timer.Stop(); timer.Elapsed -= Timer_Elapsed; timer.Dispose();
            contador = 0;
        }
    }
}
