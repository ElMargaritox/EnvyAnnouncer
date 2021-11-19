using EnvyAnnouncer.Models;
using Rocket.Core.Utils;
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
    public class MessageController : MonoBehaviour, IDisposable
    {
        private Timer timer;
        private int contador;
        public MessageController()
        {
            contador = 0;
            timer = new Timer(1000 * EnvyAnnouncerPlugin.Instance.Configuration.Instance.Time); timer.Elapsed += Timer_Elapsed;
            timer.Start(); timer.AutoReset = true;
        }

        public void Dispose()
        {
            contador = 0;
             timer.Elapsed -= Timer_Elapsed;
                timer.Stop(); timer.AutoReset = false;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            TaskDispatcher.QueueOnMainThread(() =>
            {
                if (EnvyAnnouncerPlugin.Instance.Configuration.Instance.RandomizeMessages)
                {
                    int numero = new System.Random().Next(0, EnvyAnnouncerPlugin.Instance.Configuration.Instance.Messages.Count);
                    Message message = EnvyAnnouncerPlugin.Instance.Configuration.Instance.Messages.ElementAt(numero);
                    if (EnvyAnnouncerPlugin.Instance.Configuration.Instance.ShowInConsole) Rocket.Core.Logging.Logger.Log(message.Content);
                }
                else
                {
                    try
                    {
                        Message message = EnvyAnnouncerPlugin.Instance.Configuration.Instance.Messages[contador];
                        if (EnvyAnnouncerPlugin.Instance.Configuration.Instance.ShowInConsole) Rocket.Core.Logging.Logger.Log(message.Content);

                        ChatManager.serverSendMessage(message.Content.Replace('(', '<').Replace(')', '>'), Color.white, null, null, EChatMode.GLOBAL, message.Icon, true);
                        contador++;
                    }
                    catch
                    {
                        contador = 0;
                    }

                }
            });
            
        }


    }
}
