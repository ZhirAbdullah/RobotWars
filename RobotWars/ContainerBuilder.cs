using Microsoft.Extensions.DependencyInjection;
using RobotWars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class ContainerBuilder
    {

        public IServiceProvider Build()
        {
            var container = new ServiceCollection();

            container.AddSingleton<IArena, Arena>();
            container.AddSingleton<IRobot, Robot>();
            container.AddSingleton<IValidation, Validation>();
            container.AddSingleton<IInputOutput, InputOutput>();
            container.AddSingleton<IGame, Game>();

           return container.BuildServiceProvider();
        }
    }
}
