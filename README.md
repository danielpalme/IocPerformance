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
|**No**|78|88|93|104|
|**[Autofac 3.3.0](http://code.google.com/p/autofac)**|1022|723|1717|5169|
|**[Caliburn.Micro 1.5.2](http://caliburnmicro.codeplex.com)**|435|409|1132|4488|
|**[Catel 3.9.0](http://www.catelproject.com)**|378|3756|9759|24901|
|**[DryIoc 1.2.0](https://bitbucket.org/dadhi/dryioc)**|**67**|66|**83**|**107**|
|**[Dynamo 3.0.2.0](http://www.dynamoioc.com)**|98|105|164|444|
|**[fFastInjector 0.8.1](http://ffastinjector.codeplex.com)**|86|113|140|216|
|**[Funq 1.0.0.0](http://funq.codeplex.com)**|127|131|289|952|
|**[Grace 2.2.1](https://github.com/ipjohnson/Grace)**|337|288|609|1729|
|**[Griffin 1.1.1](https://github.com/jgauffin/griffin.container)**|257|258|629|1772|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|102|84|92|138|
|**[Hiro 1.0.4.41795](https://github.com/philiplaureano/Hiro)**|132|127|139|176|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|109|127|135|176|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|451|2871|19797|102595|
|**[LightInject 3.0.1.6](https://github.com/seesharper/LightInject)**|76|**56**|88|110|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|6384|28237|70343|189899|
|**[Maestro 1.3.1](https://github.com/JonasSamuelsson/Maestro)**|532|456|1249|3542|
|**[Mef 4.0.0.0](http://mef.codeplex.com)**|36949|40471|67467|131693|
|**[Mef2 1.0.20.0](http://blogs.msdn.com/b/bclteam/p/composition.aspx)**|237|228|279|447|
|**[MicroSliver 2.1.6.0](http://microsliver.codeplex.com)**|335|956|3057|8282|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|808|877|2169|7957|
|**[Munq 3.1.6](http://munq.codeplex.com)**|92|127|411|1355|
|**[Ninject 3.2.0.0](http://ninject.org)**|8970|20314|47355|130156|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|5715|5375|5651|7121|
|**[SimpleInjector 2.5.0](http://simpleinjector.codeplex.com)**|327|161|194|229|
|**[Spring.NET 1.3.2](http://www.springframework.net/)**|1936|16471|40787|104762|
|**[StructureMap 2.6.4.1](http://structuremap.net/structuremap)**|2178|2009|5984|15834|
|**[StyleMVVM 3.1.5](http://stylemvvm.codeplex.com)**|578|543|748|1445|
|**[TinyIoC 1.2](https://github.com/grumpydev/TinyIoC)**|601|2723|9101|34886|
|**[Unity 3.0.1304.1](http://msdn.microsoft.com/unity)**|2915|4009|11660|33348|
|**[Windsor 3.2.1](http://castleproject.org)**|931|2700|8108|20969|

Advanced Features

|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Interception**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|---------------:|
|**No**|111|85|209|155|900|92|
|**[Autofac 3.3.0](http://code.google.com/p/autofac)**|5229|4161|5501||63200|26544|
|**[Caliburn.Micro 1.5.2](http://caliburnmicro.codeplex.com)**|5810||5222||||
|**[Catel 3.9.0](http://www.catelproject.com)**||9831||||3791|
|**[DryIoc 1.2.0](https://bitbucket.org/dadhi/dryioc)**|111|**75**|284|**130**|||
|**[Dynamo 3.0.2.0](http://www.dynamoioc.com)**|584||||||
|**[fFastInjector 0.8.1](http://ffastinjector.codeplex.com)**|||||||
|**[Funq 1.0.0.0](http://funq.codeplex.com)**|962||||||
|**[Grace 2.2.1](https://github.com/ipjohnson/Grace)**|1870|571|3065|1573|10500|7690|
|**[Griffin 1.1.1](https://github.com/jgauffin/griffin.container)**|||||||
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|788||1604|||**701**|
|**[Hiro 1.0.4.41795](https://github.com/philiplaureano/Hiro)**|1898||||||
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|295|125|||||
|**[LightCore 1.5.1](http://www.lightcore.ch)**|2111|12611|30342||||
|**[LightInject 3.0.1.6](https://github.com/seesharper/LightInject)**|**106**|82|**282**|135||1265|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|||||||
|**[Maestro 1.3.1](https://github.com/JonasSamuelsson/Maestro)**|6238|878|6153|2250|2189000|7305|
|**[Mef 4.0.0.0](http://mef.codeplex.com)**|139083|156400|103587||||
|**[Mef2 1.0.20.0](http://blogs.msdn.com/b/bclteam/p/composition.aspx)**|1023|263|1403||||
|**[MicroSliver 2.1.6.0](http://microsliver.codeplex.com)**|||||||
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|9774|7483|6901|3562|425500|21569|
|**[Munq 3.1.6](http://munq.codeplex.com)**|1160||||||
|**[Ninject 3.2.0.0](http://ninject.org)**|114510|51063|102846|73357|19831100|31037|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|9532||||||
|**[SimpleInjector 2.5.0](http://simpleinjector.codeplex.com)**|398|199|1316|610|**1300**|10558|
|**[Spring.NET 1.3.2](http://www.springframework.net/)**|96779|||||61985|
|**[StructureMap 2.6.4.1](http://structuremap.net/structuremap)**|19103|4577|19800||416600|11168|
|**[StyleMVVM 3.1.5](http://stylemvvm.codeplex.com)**|1499|1206|2956|2349|||
|**[TinyIoC 1.2](https://github.com/grumpydev/TinyIoC)**|4309|12615|||10900||
|**[Unity 3.0.1304.1](http://msdn.microsoft.com/unity)**|34445||54482||26700|110279|
|**[Windsor 3.2.1](http://castleproject.org)**|42784|7387|22505||126100|18511|
