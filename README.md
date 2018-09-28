AnyContainer lets you write type registration code and static resolve code that's easily swappable to any number of IoC containers.

# How to use

### Register:
```c#
AnyContainerBase container = new SimpleInjectorAnyContainer();
container.RegisterSingleton<ILogger, Logger>();
container.RegisterTransient<ITransientService, TransientService>();
container.RegisterSingleton<IOtherService>(() => new OtherService("abc"));
```

### Setting up static resolver:
```c#
StaticResolver.SetResolver(container);
```

### Resolving from static context:
```c#
var logger = StaticResolver.Resolve<ILogger>();
```

For good design you should try to avoid doing a lot of static resolves and instead take the dependencies on the constructor. But sometimes it's still handy to be able to do it.

# Supported containers

* Simple Injector
* DryIoc
* Unity

# Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
