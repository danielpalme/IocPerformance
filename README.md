Ioc Performance
===============

Source code of my performance comparison of the most popular .NET IoC containers:  
[www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison](http://www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison)

Author: Daniel Palme  
Blog: [www.palmmedia.de](http://www.palmmedia.de)  
Twitter: [@danielpalme](http://twitter.com/danielpalme)  

Results
-------
|**Container**|**Singleton**|**Transient**|**Combined**|**Complex**|
|:------------|------------:|------------:|-----------:|----------:|
|**No**|48|49|51|61|
|**[Autofac 3.3.0](https://github.com/autofac/Autofac)**|565|1108|2951|8821|
|**[Caliburn.Micro 1.5.2](https://caliburnmicro.codeplex.com)**|272|327|959|4258|
|**[Catel 3.9.0](http://www.catelproject.com)**|196|2141|6051|14905|
|**[DryIoc 1.2.0](https://bitbucket.org/dadhi/dryioc)**|**26**|**36**|43|**60**|
|**[Dynamo 3.0.2.0](http://www.dynamoioc.com)**|51|62|108|346|
|**[fFastInjector 0.8.1](https://ffastinjector.codeplex.com)**|53|68|125|197|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|74|87|224|605|
|**[Grace 2.2.1](https://github.com/ipjohnson/Grace)**|89|122|322|1015|
|**[Griffin 1.1.1](https://github.com/jgauffin/griffin.container)**|144|142|384|1112|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|42|47|50|90|
|**[Hiro 1.0.4.41795](https://github.com/philiplaureano/Hiro)**|110|108|120|156|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|51|77|88|124|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|102|1600|17940|101629|
|**[LightInject 3.0.1.6](https://github.com/seesharper/LightInject)**|**26**|37|**35**|**60**|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|2137|11686|30296|80563|
|**[Maestro 1.3.1](https://github.com/JonasSamuelsson/Maestro)**|215|265|787|2442|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|16063|23734|38397|75288|
|**[Mef2 1.0.20.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|131|132|176|308|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|125|405|1518|4444|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|276|409|1297|4780|
|**[Munq 3.1.6](http://munq.codeplex.com)**|54|77|278|935|
|**[Ninject 3.2.0.0](http://ninject.org)**|359|1247|3286|9304|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|3571|2800|2948|4277|
|**[SimpleInjector 2.5.0](https://simpleinjector.org)**|41|57|66|88|
|**[Spring.NET 1.3.2](http://www.springframework.net/)**|540|7988|21302|55075|
|**[StructureMap 2.6.4.1](http://structuremap.net/structuremap)**|911|1066|3088|8992|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|262|288|430|873|
|**[TinyIoC 1.2](https://github.com/grumpydev/TinyIoC)**|216|1150|4913|19284|
|**[Unity 3.0.1304.1](http://msdn.microsoft.com/unity)**|1511|2359|6982|21308|
|**[Windsor 3.2.1](http://castleproject.org)**|319|1307|4226|12650|

Advanced Features

|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Interception**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|---------------:|
|**No**|69|52|145|49|330|45|
|**[Autofac 3.3.0](https://github.com/autofac/Autofac)**|17381|2328|7964||44710|20359|
|**[Caliburn.Micro 1.5.2](https://caliburnmicro.codeplex.com)**|5585||4086||||
|**[Catel 3.9.0](http://www.catelproject.com)**||5711||||2106|
|**[DryIoc 1.2.0](https://bitbucket.org/dadhi/dryioc)**|66|**35**|186|32|||
|**[Dynamo 3.0.2.0](http://www.dynamoioc.com)**|458||||||
|**[fFastInjector 0.8.1](https://ffastinjector.codeplex.com)**|||||||
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|618||||||
|**[Grace 2.2.1](https://github.com/ipjohnson/Grace)**|1078|274|1247|352|6000|3975|
|**[Griffin 1.1.1](https://github.com/jgauffin/griffin.container)**|||||||
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|565||1058|||**429**|
|**[Hiro 1.0.4.41795](https://github.com/philiplaureano/Hiro)**|1690||||||
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|215|87|||||
|**[LightCore 1.5.1](http://www.lightcore.ch)**|1521|10930|25564||||
|**[LightInject 3.0.1.6](https://github.com/seesharper/LightInject)**|**62**|43|**185**|**31**||784|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|||||||
|**[Maestro 1.3.1](https://github.com/JonasSamuelsson/Maestro)**|3974|582|3547|702|7363770|4661|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|78562|92767|55434||||
|**[Mef2 1.0.20.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|704|152|820||||
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|||||||
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|5877|33780|3368|1001|310810|10329|
|**[Munq 3.1.6](http://munq.codeplex.com)**|836||||||
|**[Ninject 3.2.0.0](http://ninject.org)**|7951|3571|8016|2518|1661020|2115|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|3415||||||
|**[SimpleInjector 2.5.0](https://simpleinjector.org)**|125|61|483|124|**340**|5226|
|**[Spring.NET 1.3.2](http://www.springframework.net/)**|51779|||||37902|
|**[StructureMap 2.6.4.1](http://structuremap.net/structuremap)**|10518|2169|10431||358510|5728|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|990|736|1858|772|||
|**[TinyIoC 1.2](https://github.com/grumpydev/TinyIoC)**|2318||||7970||
|**[Unity 3.0.1304.1](http://msdn.microsoft.com/unity)**|21704||35653||21950|65935|
|**[Windsor 3.2.1](http://castleproject.org)**|25247|2747|13416||153850|11052|
