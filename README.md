Ioc Performance
===============

Source code of my performance comparison of the most popular .NET IoC containers:  
[www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison](http://www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison)

Author: Daniel Palme  
Blog: [www.palmmedia.de](http://www.palmmedia.de)  
Twitter: [@danielpalme](http://twitter.com/danielpalme)  

Results
-------
### Explantions
**First value**: Time of single-threaded execution in [ms]  
**Second value**: Time of multi-threaded execution in [ms]  
**_*_**: Benchmark was stopped after 3 minutes and result is extrapolated.  
### Basic Features
|**Container**|**Singleton**|**Transient**|**Combined**|**Complex**|
|:------------|------------:|------------:|-----------:|----------:|
|**No**|53<br/>55|65<br/>71|82<br/>108|101<br/>88|
|**[Autofac 4.3.0](https://github.com/autofac/Autofac)**|827<br/>611|1066<br/>719|2860<br/>1888|9015<br/>6600|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|530<br/>318|637<br/>382|1870<br/>1071|8425<br/>4572|
|**[Catel 4.5.4](http://www.catelproject.com)**|329<br/>370|4710<br/>5487|11211<br/>12381|26377<br/>29142|
|**[DryIoc 2.10.1](https://bitbucket.org/dadhi/dryioc)**|**27**<br/>**42**|45<br/>66|59<br/>99|71<br/>**74**|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|86<br/>74|106<br/>97|208<br/>164|643<br/>387|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|67<br/>68|123<br/>109|257<br/>196|602<br/>364|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|130<br/>106|154<br/>132|422<br/>288|1198<br/>710|
|**[Grace 5.1.0](https://github.com/ipjohnson/Grace)**|30<br/>43|**39**<br/>**64**|**57**<br/>99|**66**<br/>76|
|**[Griffin 1.1.4](https://github.com/jgauffin/griffin.container)**|323<br/>219|330<br/>227|748<br/>474|2040<br/>1248|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|55<br/>50|54<br/>70|103<br/>100|118<br/>109|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|79<br/>76|124<br/>111|164<br/>140|218<br/>158|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|195<br/>199|2550<br/>1510|28264<br/>31537|163188<br/>184686*|
|**[LightInject 5.0.1](https://github.com/seesharper/LightInject)**|38<br/>52|49<br/>70|68<br/>**93**|87<br/>87|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|3645<br/>2095|19218<br/>13994|49807<br/>34538|128498<br/>84457|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|361<br/>271|419<br/>313|1140<br/>696|3454<br/>2055|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|23079<br/>13486|38375<br/>24670|62628<br/>51574|125998<br/>151105|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|234<br/>167|251<br/>179|342<br/>239|572<br/>374|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|204<br/>277|827<br/>525|2752<br/>1709|7899<br/>5467|
|**[Microsoft Extensions DependencyInjection 1.1.0](https://github.com/aspnet/DependencyInjection)**|207<br/>291|165<br/>125|412<br/>368|1315<br/>1541|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|514<br/>426|771<br/>696|2231<br/>2038|8647<br/>7747|
|**[Munq 3.1.6](http://munq.codeplex.com)**|90<br/>82|150<br/>128|592<br/>369|1885<br/>1076|
|**[Ninject 3.2.2.0](http://ninject.org)**|5632<br/>3718|17838<br/>12993|49931<br/>34541|139492<br/>95924|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|4041<br/>2451|4103<br/>2379|4934<br/>2887|5391<br/>3091|
|**[Rezolver 1.1.71702.109](http://rezolver.co.uk)**|160<br/>126|183<br/>150|274<br/>217|445<br/>317|
|**[SimpleInjector 3.3.2](https://simpleinjector.org)**|65<br/>65|91<br/>85|130<br/>123|171<br/>133|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|1060<br/>885|10886<br/>7659|29980<br/>23016|82442<br/>53232|
|**[Stashbox 2.3.1](https://github.com/z4kn4fein/stashbox)**|46<br/>54|69<br/>77|99<br/>120|141<br/>127|
|**[StructureMap 4.4.3](http://structuremap.net/structuremap)**|1337<br/>1000|1474<br/>987|3874<br/>2595|9519<br/>6137|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|496<br/>326|568<br/>364|814<br/>524|1682<br/>1136|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|570<br/>606|2143<br/>1362|8400<br/>6118|34593<br/>25591|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|2721<br/>1647|4100<br/>2399|10792<br/>6494|31347<br/>19226|
|**[Windsor 3.3.0](http://castleproject.org)**|529<br/>415|1958<br/>1237|6325<br/>3748|18920<br/>11005|
### Advanced Features
|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Asp Net Core**|**Interception With Proxy**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|---------------:|--------------------------:|
|**No**|127<br/>112|81<br/>74|189<br/>146|75<br/>74|667<br/>432|<br/>|73<br/>72|
|**[Autofac 4.3.0](https://github.com/autofac/Autofac)**|23159<br/>14153|2118<br/>1404|10025<br/>6120|<br/>|52481<br/>31380|15128<br/>10411|23350<br/>13270|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|10744<br/>5933|<br/>|7280<br/>4054|<br/>|<br/>|<br/>|<br/>|
|**[Catel 4.5.4](http://www.catelproject.com)**|<br/>|11542<br/>12452|<br/>|<br/>|<br/>|<br/>|4616<br/>5071|
|**[DryIoc 2.10.1](https://bitbucket.org/dadhi/dryioc)**|97<br/>**95**|51<br/>84|**313**<br/>**218**|53<br/>**66**|<br/>|13011<br/>Error|896<br/>588|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|882<br/>533|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|1211<br/>739|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Grace 5.1.0](https://github.com/ipjohnson/Grace)**|**88**<br/>102|**49**<br/>**76**|**313**<br/>224|**49**<br/>69|50826<br/>30210|**1145**<br/>**762**|897<br/>592|
|**[Griffin 1.1.4](https://github.com/jgauffin/griffin.container)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|849<br/>551|<br/>|2010<br/>1178|<br/>|<br/>|<br/>|**811**<br/>**529**|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|381<br/>259|153<br/>124|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|2443<br/>2072|17794<br/>13519|39619<br/>24847|<br/>|<br/>|<br/>|<br/>|
|**[LightInject 5.0.1](https://github.com/seesharper/LightInject)**|105<br/>106|60<br/>79|325<br/>226|559<br/>352|<br/>|2347<br/>1736|1441<br/>897|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|3612<br/>2121|820<br/>532|3755<br/>2140|1033<br/>653|<br/>|<br/>|6024<br/>3542|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|132291<br/>145308|149273<br/>122144|103419<br/>105077|<br/>|<br/>|<br/>|<br/>|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|1254<br/>781|290<br/>213|1535<br/>904|<br/>|<br/>|<br/>|<br/>|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Microsoft Extensions DependencyInjection 1.1.0](https://github.com/aspnet/DependencyInjection)**|<br/>|229<br/>164|903<br/>553|<br/>|<br/>|1949<br/>1627|<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|11417<br/>8821|62864<br/>70622|6319<br/>7533|1857<br/>1573|674014*<br/>545378*|<br/>|15787<br/>17135|
|**[Munq 3.1.6](http://munq.codeplex.com)**|1794<br/>1024|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Ninject 3.2.2.0](http://ninject.org)**|122417<br/>81827|50115<br/>31398|112418<br/>74162|40244<br/>24048|54086250*<br/>32063769*|<br/>|26952<br/>19033|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|6918<br/>4052|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Rezolver 1.1.71702.109](http://rezolver.co.uk)**|661<br/>449|246<br/>203|613<br/>434|<br/>|3851127*<br/>2317135*|<br/>|<br/>|
|**[SimpleInjector 3.3.2](https://simpleinjector.org)**|256<br/>194|81<br/>92|942<br/>565|76<br/>82|<br/>|<br/>|7674<br/>4551|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|61011<br/>41785|<br/>|<br/>|<br/>|<br/>|<br/>|52280<br/>41135|
|**[Stashbox 2.3.1](https://github.com/z4kn4fein/stashbox)**|163<br/>144|108<br/>114|425<br/>293|89<br/>91|<br/>|828224*<br/>504860*|<br/>|
|**[StructureMap 4.4.3](http://structuremap.net/structuremap)**|9780<br/>6385|2666<br/>1749|8135<br/>5246|<br/>|3712653*<br/>2171036*|49211<br/>32327|8040<br/>4975|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|1816<br/>1253|1336<br/>985|3738<br/>2212|1530<br/>954|<br/>|<br/>|<br/>|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|5557<br/>5180|<br/>|<br/>|<br/>|**13892**<br/>**9010**|<br/>|<br/>|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|31969<br/>19469|<br/>|48305<br/>27737|<br/>|36939<br/>24379|<br/>|102696<br/>57567|
|**[Windsor 3.3.0](http://castleproject.org)**|36753<br/>21563|15700<br/>9196|16278<br/>10255|<br/>|260604*<br/>Error|<br/>|13413<br/>7774|
### Prepare
|**Container**|**Prepare And Register**|**Prepare And Register And Simple Resolve**|
|:------------|-----------------------:|------------------------------------------:|
|**No**|2<br/>|3<br/>|
|**[Autofac 4.3.0](https://github.com/autofac/Autofac)**|325<br/>|348<br/>|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|65<br/>|66<br/>|
|**[Catel 4.5.4](http://www.catelproject.com)**|16915<br/>|17281<br/>|
|**[DryIoc 2.10.1](https://bitbucket.org/dadhi/dryioc)**|87<br/>|334<br/>|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|20071<br/>|19972<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|8663<br/>|8688<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|**8**<br/>|**9**<br/>|
|**[Grace 5.1.0](https://github.com/ipjohnson/Grace)**|175<br/>|1067<br/>|
|**[Griffin 1.1.4](https://github.com/jgauffin/griffin.container)**|10810<br/>|10819<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|61496<br/>|61661<br/>|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|1549<br/>|2300<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|214<br/>|223<br/>|
|**[LightInject 5.0.1](https://github.com/seesharper/LightInject)**|151<br/>|889<br/>|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|108<br/>|368<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|207<br/>|923<br/>|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|16<br/>|2315<br/>|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|5759<br/>|7341<br/>|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|13<br/>|18<br/>|
|**[Microsoft Extensions DependencyInjection 1.1.0](https://github.com/aspnet/DependencyInjection)**|27<br/>|38<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|560<br/>|2153<br/>|
|**[Munq 3.1.6](http://munq.codeplex.com)**|12136<br/>|12107<br/>|
|**[Ninject 3.2.2.0](http://ninject.org)**|106435<br/>|101525<br/>|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|18<br/>|38<br/>|
|**[Rezolver 1.1.71702.109](http://rezolver.co.uk)**|66<br/>|4663<br/>|
|**[SimpleInjector 3.3.2](https://simpleinjector.org)**|416<br/>|3815<br/>|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|28579<br/>|28675<br/>|
|**[Stashbox 2.3.1](https://github.com/z4kn4fein/stashbox)**|132<br/>|470<br/>|
|**[StructureMap 4.4.3](http://structuremap.net/structuremap)**|1506<br/>|8808<br/>|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|86428<br/>|87709<br/>|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|71<br/>|84<br/>|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|715<br/>|2680<br/>|
|**[Windsor 3.3.0](http://castleproject.org)**|3530<br/>|3526<br/>|
### Charts
![Basic features](http://www.palmmedia.de/content/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)
![Advanced features](http://www.palmmedia.de/content/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)
![Prepare](http://www.palmmedia.de/content/blogimages/67b056a5-9da8-40b4-9ae6-0c838cdac180.png)
### Machine
The benchmark was executed on the following machine:  
**CPU**: Intel(R) Core(TM) i5-5200U CPU @ 2.20GHz  
**Memory**: 11.91GB
