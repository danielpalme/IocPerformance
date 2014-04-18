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
|**No**|115|94|102|127|
|**[Autofac 3.3.1](https://github.com/autofac/Autofac)**|826|2132|5659|16112|
|**[Caliburn.Micro 1.5.2](https://caliburnmicro.codeplex.com)**|474|566|1664|7402|
|**[Catel 3.9.0](http://www.catelproject.com)**|372|4498|13350|33606|
|**[DryIoc 1.2.0](https://bitbucket.org/dadhi/dryioc)**|53|77|82|**101**|
|**[Dynamo 3.0.2.0](http://www.dynamoioc.com)**|108|140|216|791|
|**[fFastInjector 0.8.1](https://ffastinjector.codeplex.com)**|98|129|164|271|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|158|186|423|1271|
|**[Grace 2.2.3](https://github.com/ipjohnson/Grace)**|589|451|1541|4022|
|**[Griffin 1.1.1](https://github.com/jgauffin/griffin.container)**|269|261|709|2026|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|78|86|95|151|
|**[Hiro 1.0.4.41795](https://github.com/philiplaureano/Hiro)**|196|195|208|263|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|99|152|175|231|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|190|3000|36503|215898|
|**[LightInject 3.0.1.6](https://github.com/seesharper/LightInject)**|**51**|**71**|**74**|121|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|4067|26467|66663|184134|
|**[Maestro 1.3.1](https://github.com/JonasSamuelsson/Maestro)**|427|519|1459|5887|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|33062|50433|80331|156652|
|**[Mef2 1.0.20.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|322|301|364|596|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|252|787|2781|7985|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|482|836|2283|8461|
|**[Munq 3.1.6](http://munq.codeplex.com)**|108|143|502|1862|
|**[Ninject 3.2.0.0](http://ninject.org)**|8970|20314|47355|130156|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|5584|4980|5612|6129|
|**[SimpleInjector 2.5.0](https://simpleinjector.org)**|85|109|123|169|
|**[Spring.NET 1.3.2](http://www.springframework.net/)**|1063|16794|44736|114565|
|**[StructureMap 3.0.2.115](http://structuremap.net/structuremap)**|3306|2781|8063|19988|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|535|574|854|1696|
|**[TinyIoC 1.2](https://github.com/grumpydev/TinyIoC)**|400|2555|10215|45779|
|**[Unity 3.0.1304.1](http://msdn.microsoft.com/unity)**|3321|5171|21068|53036|
|**[Windsor 3.2.1](http://castleproject.org)**|508|2603|8161|23208|

Advanced Features

|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Interception**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|---------------:|
|**No**|124|98|266|86|690|79|
|**[Autofac 3.3.1](https://github.com/autofac/Autofac)**|34668|4882|17360||110250|45333|
|**[Caliburn.Micro 1.5.2](https://caliburnmicro.codeplex.com)**|9670||7156||||
|**[Catel 3.9.0](http://www.catelproject.com)**||12697||||4384|
|**[DryIoc 1.2.0](https://bitbucket.org/dadhi/dryioc)**|131|**69**|**354**|66|||
|**[Dynamo 3.0.2.0](http://www.dynamoioc.com)**|913||||||
|**[fFastInjector 0.8.1](https://ffastinjector.codeplex.com)**|||||||
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|1211||||||
|**[Grace 2.2.3](https://github.com/ipjohnson/Grace)**|3365|503|2443|1101|13100|8243|
|**[Griffin 1.1.1](https://github.com/jgauffin/griffin.container)**|||||||
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|1025||2177|||**883**|
|**[Hiro 1.0.4.41795](https://github.com/philiplaureano/Hiro)**|3013||||||
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|422|167|||||
|**[LightCore 1.5.1](http://www.lightcore.ch)**|2474|25055|52115||||
|**[LightInject 3.0.1.6](https://github.com/seesharper/LightInject)**|**115**|87|355|**65**||1568|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|||||||
|**[Maestro 1.3.1](https://github.com/JonasSamuelsson/Maestro)**|9301|2779|8024|2355|28248100|9538|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|165820|186915|117780||||
|**[Mef2 1.0.20.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|1474|312|1657||||
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|||||||
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|14046|70232|6643|1805|676980|17034|
|**[Munq 3.1.6](http://munq.codeplex.com)**|1648||||||
|**[Ninject 3.2.0.0](http://ninject.org)**|114510|51063|102846|73357|19831100|31037|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|6995||||||
|**[SimpleInjector 2.5.0](https://simpleinjector.org)**|227|109|853|228|**630**|13380|
|**[Spring.NET 1.3.2](http://www.springframework.net/)**|104652|||||75437|
|**[StructureMap 3.0.2.115](http://structuremap.net/structuremap)**|21075|5713|16743||3374090|13518|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|1792|2914|3828|2830|||
|**[TinyIoC 1.2](https://github.com/grumpydev/TinyIoC)**|4346||||16900||
|**[Unity 3.0.1304.1](http://msdn.microsoft.com/unity)**|53142||74087||46320|133957|
|**[Windsor 3.2.1](http://castleproject.org)**|47378|4330|22863||317550|22180|
