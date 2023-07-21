﻿using Dotnet.Homeworks.Tests.RunLogic.Attributes;
using Dotnet.Homeworks.Tests.RunLogic.Utils.Docker;

namespace Dotnet.Homeworks.Tests.MasstransitRabbit;

public class DockerRabbitmqTests
{
    [Homework(RunLogic.Homeworks.RabbitMasstransit)]
    public void Services_ShouldContain_DotnetRabbitmq()
    {
        var docker = Parser.Parse();

        Assert.NotNull(docker.Services?.DotnetRabbitmq);
    }

    [Homework(RunLogic.Homeworks.RabbitMasstransit)]
    public void DotnetRabbitmq_ShouldContain_CredentialEnvVars()
    {
        var docker = Parser.Parse();
        var rabbitmqDefaultUser =
            docker.Services?.DotnetRabbitmq?.Environment?.GetValueOrDefault(Constants.RabbitmqDefaultUserEnvVar);
        var rabbitmqDefaultPassword =
            docker.Services?.DotnetRabbitmq?.Environment?.GetValueOrDefault(Constants.RabbitmqDefaultPassEnvVar);

        Assert.NotNull(rabbitmqDefaultUser);
        Assert.NotNull(rabbitmqDefaultPassword);
    }
}