using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RobotWars;
using System;


IServiceProvider container = new ContainerBuilder().Build();
var robot = container.GetService<IRobot>();
var inputOutput = container.GetService<IInputOutput>();

new Application(robot,inputOutput);



