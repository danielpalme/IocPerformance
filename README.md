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
|**No**|67|75|78|93|
|**[Autofac 3.3.0](https://github.com/autofac/Autofac)**|847|1654|4475|13348|
|**[Caliburn.Micro 1.5.2](https://caliburnmicro.codeplex.com)**|410|492|1447|6382|
|**[Catel 3.9.0](http://www.catelproject.com)**|292|3378|9725|23946|
|**[DryIoc 1.2.0](https://bitbucket.org/dadhi/dryioc)**|**40**|55|65|**76**|
|**[Dynamo 3.0.2.0](http://www.dynamoioc.com)**|77|99|163|519|
|**[fFastInjector 0.8.1](https://ffastinjector.codeplex.com)**|81|101|136|216|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|117|134|338|904|
|**[Grace 2.2.1](https://github.com/ipjohnson/Grace)**|137|184|484|1543|
|**[Griffin 1.1.1](https://github.com/jgauffin/griffin.container)**|216|215|579|1665|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|63|68|75|138|
|**[Hiro 1.0.4.41795](https://github.com/philiplaureano/Hiro)**|156|155|171|225|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|75|116|135|186|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|153|2433|26920|153181|
|**[LightInject 3.0.1.6](https://github.com/seesharper/LightInject)**|**40**|**52**|**52**|90|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|3387|17778|46166|121786|
|**[Maestro 1.3.1](https://github.com/JonasSamuelsson/Maestro)**|324|411|1294|4058|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|24284|34485|59656|112843|
|**[Mef2 1.0.20.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|198|199|266|462|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|186|606|2215|6492|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|401|611|1905|7064|
|**[Munq 3.1.6](http://munq.codeplex.com)**|78|116|409|1409|
|**[Ninject 3.2.0.0](http://ninject.org)**|359|1247|3286|9304|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|5217|4373|4591|6499|
|**[SimpleInjector 2.5.0](https://simpleinjector.org)**|61|84|99|129|
|**[Spring.NET 1.3.2](http://www.springframework.net/)**|807|12007|32640|84936|
|**[StructureMap 2.6.4.1](http://structuremap.net/structuremap)**|1356|1493|4557|13016|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|457|507|711|1346|
|**[TinyIoC 1.2](https://github.com/grumpydev/TinyIoC)**|322|1773|7166|27836|
|**[Unity 3.0.1304.1](http://msdn.microsoft.com/unity)**|2237|3585|10430|32086|
|**[Windsor 3.2.1](http://castleproject.org)**|487|2026|6522|19474|

Advanced Features

|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Interception**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|---------------:|
|**No**|104|79|219|74|490|67|
|**[Autofac 3.3.0](https://github.com/autofac/Autofac)**|25365|3617|12163||67530|30594|
|**[Caliburn.Micro 1.5.2](https://caliburnmicro.codeplex.com)**|8386||6172||||
|**[Catel 3.9.0](http://www.catelproject.com)**||8991||||3283|
|**[DryIoc 1.2.0](https://bitbucket.org/dadhi/dryioc)**|100|**54**|286|48|||
|**[Dynamo 3.0.2.0](http://www.dynamoioc.com)**|685||||||
|**[fFastInjector 0.8.1](https://ffastinjector.codeplex.com)**|||||||
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|927||||||
|**[Grace 2.2.1](https://github.com/ipjohnson/Grace)**|1627|413|2075|533|8950|6255|
|**[Griffin 1.1.1](https://github.com/jgauffin/griffin.container)**|||||||
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|837||1609|||**642**|
|**[Hiro 1.0.4.41795](https://github.com/philiplaureano/Hiro)**|2623||||||
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|328|131|||||
|**[LightCore 1.5.1](http://www.lightcore.ch)**|1920|16499|39178||||
|**[LightInject 3.0.1.6](https://github.com/seesharper/LightInject)**|**94**|65|**279**|**46**||1193|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|||||||
|**[Maestro 1.3.1](https://github.com/JonasSamuelsson/Maestro)**|6623|974|5341|1183|15840070|7502|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|119077|131162|84713||||
|**[Mef2 1.0.20.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|1049|230|1228||||
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|||||||
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|8945|50485|4986|1459|467600|15326|
|**[Munq 3.1.6](http://munq.codeplex.com)**|1231||||||
|**[Ninject 3.2.0.0](http://ninject.org)**|7951|3571|8016|2518|1661020|2115|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|6895||||||
|**[SimpleInjector 2.5.0](https://simpleinjector.org)**|187|88|725|186|**510**|8799|
|**[Spring.NET 1.3.2](http://www.springframework.net/)**|76910|||||54140|
|**[StructureMap 2.6.4.1](http://structuremap.net/structuremap)**|15427|3180|15500||519940|8699|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|1486|1225|2913|1322|||
|**[TinyIoC 1.2](https://github.com/grumpydev/TinyIoC)**|3466||||11690||
|**[Unity 3.0.1304.1](http://msdn.microsoft.com/unity)**|32259||50113||31270|94388|
|**[Windsor 3.2.1](http://castleproject.org)**|37975|3852|19681||222820|16522|
