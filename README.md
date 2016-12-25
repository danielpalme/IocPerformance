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
|**No**|58<br/>54|65<br/>68|89<br/>99|96<br/>80|
|**[Autofac 3.5.2](https://github.com/autofac/Autofac)**|713<br/>525|1650<br/>1016|4515<br/>3206|12625<br/>10193|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|470<br/>281|552<br/>343|1669<br/>927|7434<br/>4084|
|**[Catel 4.5.4](http://www.catelproject.com)**|379<br/>410|4316<br/>5117|11198<br/>11641|24795<br/>27404|
|**[DryIoc 2.4.3](https://bitbucket.org/dadhi/dryioc)**|**31**<br/>**43**|**38**<br/>62|**56**<br/>91|**70**<br/>**71**|
|**[DryIocZero 2.1.0](https://bitbucket.org/dadhi/dryioc)**|79<br/>65|77<br/>70|80<br/>95|188<br/>140|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|97<br/>72|100<br/>84|211<br/>152|635<br/>368|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|63<br/>71|132<br/>103|290<br/>205|654<br/>402|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|122<br/>92|143<br/>111|396<br/>258|1066<br/>631|
|**[Grace 4.0.2](https://github.com/ipjohnson/Grace)**|179<br/>134|328<br/>240|789<br/>487|2177<br/>1278|
|**[Griffin 1.1.2](https://github.com/jgauffin/griffin.container)**|301<br/>192|305<br/>210|707<br/>435|2004<br/>1525|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|41<br/>51|47<br/>60|66<br/>97|106<br/>90|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|74<br/>81|121<br/>101|154<br/>129|206<br/>146|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|184<br/>196|2478<br/>1349|25106<br/>30593|160556<br/>207181*|
|**[LightInject 4.1.5](https://github.com/seesharper/LightInject)**|40<br/>52|50<br/>**58**|64<br/>**83**|85<br/>82|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|3794<br/>2406|19975<br/>14511|51402<br/>35572|122377<br/>75771|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|337<br/>253|374<br/>278|1094<br/>643|3104<br/>1747|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|22424<br/>12124|35595<br/>25034|59216<br/>67576|118099<br/>146429|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|240<br/>208|250<br/>209|345<br/>292|613<br/>443|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|215<br/>271|881<br/>776|2690<br/>2317|8213<br/>7327|
|**[Microsoft.Framework.DependencyInjection 1.0.0-beta8](https://github.com/aspnet/DependencyInjection)**|197<br/>217|191<br/>126|387<br/>448|1044<br/>1133|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|498<br/>563|822<br/>968|2255<br/>2745|7666<br/>9388|
|**[Munq 3.1.6](http://munq.codeplex.com)**|119<br/>98|161<br/>148|669<br/>467|1992<br/>1319|
|**[Ninject 3.2.2.0](http://ninject.org)**|5224<br/>3437|16579<br/>11961|46445<br/>30800|136712<br/>85362|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|4118<br/>2690|4161<br/>2763|4477<br/>2584|4966<br/>2670|
|**[SimpleInjector 3.3.2](https://simpleinjector.org)**|63<br/>80|120<br/>86|150<br/>121|151<br/>132|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|976<br/>978|10185<br/>11925|27810<br/>24892|73589<br/>58129|
|**[Stashbox 1.0.104.0](https://github.com/z4kn4fein/stashbox)**|112<br/>102|195<br/>158|228<br/>199|291<br/>243|
|**[StructureMap 4.2.0.402](http://structuremap.net/structuremap)**|1413<br/>1207|1546<br/>1096|4181<br/>2968|10955<br/>7435|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|437<br/>266|485<br/>303|721<br/>451|1513<br/>864|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|455<br/>467|1576<br/>1051|7081<br/>5117|29000<br/>20842|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|2531<br/>1406|3857<br/>2088|10225<br/>5657|28572<br/>16225|
|**[Windsor 3.3.0](http://castleproject.org)**|475<br/>327|1855<br/>1062|6026<br/>3346|18122<br/>9722|
### Advanced Features
|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Interception With Proxy**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|--------------------------:|
|**No**|115<br/>98|71<br/>69|177<br/>135|71<br/>63|613<br/>367|70<br/>63|
|**[Autofac 3.5.2](https://github.com/autofac/Autofac)**|25023<br/>17237|3568<br/>2282|11017<br/>7756|<br/>|67261<br/>37960|27306<br/>14319|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|9578<br/>5126|<br/>|6207<br/>3466|<br/>|<br/>|<br/>|
|**[Catel 4.5.4](http://www.catelproject.com)**|<br/>|10712<br/>11508|<br/>|<br/>|<br/>|4433<br/>4715|
|**[DryIoc 2.4.3](https://bitbucket.org/dadhi/dryioc)**|**95**<br/>**97**|**55**<br/>**75**|**264**<br/>**189**|**53**<br/>**66**|<br/>|816<br/>498|
|**[DryIocZero 2.1.0](https://bitbucket.org/dadhi/dryioc)**|211<br/>156|<br/>|309<br/>210|70<br/>84|<br/>|<br/>|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|786<br/>464|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|1153<br/>641|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Grace 4.0.2](https://github.com/ipjohnson/Grace)**|2358<br/>1339|774<br/>496|2665<br/>1440|804<br/>491|10364<br/>**5939**|5928<br/>3177|
|**[Griffin 1.1.2](https://github.com/jgauffin/griffin.container)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|815<br/>447|<br/>|1784<br/>993|<br/>|<br/>|**720**<br/>**417**|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|391<br/>252|146<br/>127|<br/>|<br/>|<br/>|<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|2490<br/>2259|17591<br/>17980|40054<br/>31362|<br/>|<br/>|<br/>|
|**[LightInject 4.1.5](https://github.com/seesharper/LightInject)**|103<br/>100|60<br/>78|275<br/>205|512<br/>308|<br/>|1591<br/>900|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|3403<br/>1863|714<br/>480|3150<br/>1763|930<br/>586|<br/>|5763<br/>3138|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|124601<br/>138121|147178<br/>139065|104933<br/>130921|<br/>|<br/>|<br/>|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|1313<br/>1022|315<br/>248|1617<br/>1116|<br/>|<br/>|<br/>|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Microsoft.Framework.DependencyInjection 1.0.0-beta8](https://github.com/aspnet/DependencyInjection)**|<br/>|253<br/>211|932<br/>655|<br/>|<br/>|<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|10420<br/>9159|71665<br/>79952|6639<br/>8367|1841<br/>2230|580141*<br/>542910*|20313<br/>24812|
|**[Munq 3.1.6](http://munq.codeplex.com)**|1683<br/>1155|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Ninject 3.2.2.0](http://ninject.org)**|126340<br/>94262|51421<br/>34619|116662<br/>86730|39381<br/>28760|75048000*<br/>53320497*|27366<br/>21004|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|6076<br/>3382|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[SimpleInjector 3.3.2](https://simpleinjector.org)**|295<br/>160|89<br/>88|805<br/>463|72<br/>79|<br/>|7113<br/>3998|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|56159<br/>53415|<br/>|<br/>|<br/>|<br/>|53353<br/>55179|
|**[Stashbox 1.0.104.0](https://github.com/z4kn4fein/stashbox)**|499<br/>384|239<br/>191|565<br/>452|225<br/>186|**8751**<br/>6023|<br/>|
|**[StructureMap 4.2.0.402](http://structuremap.net/structuremap)**|10857<br/>7345|2789<br/>1904|8721<br/>5663|<br/>|3555039*<br/>1896903*|7414<br/>4064|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|1713<br/>979|1269<br/>699|3082<br/>1725|1329<br/>743|<br/>|<br/>|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|4712<br/>4934|<br/>|<br/>|<br/>|12401<br/>7236|<br/>|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|29090<br/>17028|<br/>|45898<br/>23941|<br/>|34469<br/>21442|93685<br/>49400|
|**[Windsor 3.3.0](http://castleproject.org)**|34678<br/>18895|14956<br/>7996|16662<br/>9241|<br/>|225855*<br/>Error|13791<br/>7336|
### Prepare
|**Container**|**Prepare And Register**|**Prepare And Register And Simple Resolve**|
|:------------|-----------------------:|------------------------------------------:|
|**No**|2<br/>|3<br/>|
|**[Autofac 3.5.2](https://github.com/autofac/Autofac)**|322<br/>|377<br/>|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|53<br/>|59<br/>|
|**[Catel 4.5.4](http://www.catelproject.com)**|8804<br/>|8968<br/>|
|**[DryIoc 2.4.3](https://bitbucket.org/dadhi/dryioc)**|79<br/>|420<br/>|
|**[DryIocZero 2.1.0](https://bitbucket.org/dadhi/dryioc)**|**0**<br/>|**0**<br/>|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|14896<br/>|15395<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|6142<br/>|6037<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|7<br/>|8<br/>|
|**[Grace 4.0.2](https://github.com/ipjohnson/Grace)**|1116<br/>|2814<br/>|
|**[Griffin 1.1.2](https://github.com/jgauffin/griffin.container)**|7545<br/>|8020<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|54181<br/>|54777<br/>|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|1509<br/>|2001<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|228<br/>|230<br/>|
|**[LightInject 4.1.5](https://github.com/seesharper/LightInject)**|160<br/>|673<br/>|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|99<br/>|337<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|173<br/>|677<br/>|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|14<br/>|2320<br/>|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|6024<br/>|7467<br/>|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|11<br/>|16<br/>|
|**[Microsoft.Framework.DependencyInjection 1.0.0-beta8](https://github.com/aspnet/DependencyInjection)**|29<br/>|31<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|508<br/>|2066<br/>|
|**[Munq 3.1.6](http://munq.codeplex.com)**|9945<br/>|9547<br/>|
|**[Ninject 3.2.2.0](http://ninject.org)**|142265<br/>|139074<br/>|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|37<br/>|47<br/>|
|**[SimpleInjector 3.3.2](https://simpleinjector.org)**|377<br/>|2935<br/>|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|27593<br/>|27718<br/>|
|**[Stashbox 1.0.104.0](https://github.com/z4kn4fein/stashbox)**|1144<br/>|1728<br/>|
|**[StructureMap 4.2.0.402](http://structuremap.net/structuremap)**|1320<br/>|7638<br/>|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|71837<br/>|78801<br/>|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|58<br/>|71<br/>|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|638<br/>|2254<br/>|
|**[Windsor 3.3.0](http://castleproject.org)**|3027<br/>|3141<br/>|
### Charts
![Basic features](http://www.palmmedia.de/content/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)
![Advanced features](http://www.palmmedia.de/content/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)
![Prepare](http://www.palmmedia.de/content/blogimages/67b056a5-9da8-40b4-9ae6-0c838cdac180.png)
### Machine
The benchmark was executed on the following machine:  
**CPU**: Intel(R) Core(TM) i5-6260U CPU @ 1.80GHz  
**Memory**: 15,89GB
