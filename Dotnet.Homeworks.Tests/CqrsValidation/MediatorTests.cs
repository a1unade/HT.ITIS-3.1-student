#if false
using Dotnet.Homeworks.Tests.CqrsValidation.Helpers;
using Dotnet.Homeworks.Tests.RunLogic.Attributes;
using Dotnet.Homeworks.Tests.Shared.Cqrs;

namespace Dotnet.Homeworks.Tests.CqrsValidation;

[Collection(nameof(AllUsersRequestsFixture))]
public class MediatorTests
{
    [Homework(RunLogic.Homeworks.CqrsValidatorsDecorators)]
    public void CustomMediator_Should_ResideInMainProject()
    {
        var mediator = typeof(MainProject.Helpers.AssemblyReference).Assembly.GetReferencedAssemblies()
            .FirstOrDefault(x => x.Name == Constants.CustomMediatorNamespace);

        Assert.NotNull(mediator);
    }

    [Homework(RunLogic.Homeworks.CqrsValidatorsDecorators)]
    public void MediatR_ShouldNot_ResideInFeatures()
    {
        var mediator = typeof(Features.Helpers.AssemblyReference).Assembly.GetReferencedAssemblies()
            .FirstOrDefault(x => x.Name == Constants.MediatR);

        Assert.Null(mediator);
    }
}
#endif