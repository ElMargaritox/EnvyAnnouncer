using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvyAnnouncer.Models;
using Rocket.API;

namespace EnvyAnnouncer
{
    public class EnvyAnnouncerConfiguration : IRocketPluginConfiguration
    {
        public int Time;
        public bool RandomizeMessages;
        public bool ShowInConsole;
        public List<Message> Messages;
        public void LoadDefaults()
        {
            Time = 5;
            ShowInConsole = true;
            RandomizeMessages = false;
            Messages = new List<Message>
            {
                new Message{ Content = "(color=red)EnvyHosting - By Margarita#8172(/color) 1", Icon = "https://i.pinimg.com/736x/c5/38/01/c53801a34adcad784397180fd15d5638.jpg"},
                new Message{ Content = "(color=red)EnvyHosting - By Margarita#8172(/color) 2", Icon = "https://i.pinimg.com/736x/c5/38/01/c53801a34adcad784397180fd15d5638.jpg"},
                new Message{ Content = "(color=red)EnvyHosting - By Margarita#8172(/color) 3", Icon = "https://i.pinimg.com/736x/c5/38/01/c53801a34adcad784397180fd15d5638.jpg"}
            };
            

        }
    }
}
