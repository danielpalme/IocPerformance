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
|**[abioc 0.1.7](https://github.com/JSkimming/abioc)**|95<br/>71|119<br/>88|120<br/>112|168<br/>123|
|**[Autofac 4.4.0](https://github.com/autofac/Autofac)**|746<br/>633|954<br/>715|2634<br/>2215|8130<br/>7635|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|470<br/>281|552<br/>343|1669<br/>927|7434<br/>4084|
|**[Catel 4.5.4](http://www.catelproject.com)**|379<br/>410|4316<br/>5117|11198<br/>11641|24795<br/>27404|
|**[DryIoc 2.10.4](https://bitbucket.org/dadhi/dryioc)**|**25**<br/>**40**|39<br/>61|55<br/>80|**65**<br/>78|
|**[DryIocZero 2.7.0](https://bitbucket.org/dadhi/dryioc)**|138<br/>79|83<br/>81|109<br/>117|376<br/>295|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|97<br/>72|100<br/>84|211<br/>152|635<br/>368|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|63<br/>71|132<br/>103|290<br/>205|654<br/>402|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|122<br/>92|143<br/>111|396<br/>258|1066<br/>631|
|**[Grace 6.0.1](https://github.com/ipjohnson/Grace)**|**25**<br/>**40**|**33**<br/>61|**53**<br/>**78**|66<br/>**74**|
|**[Griffin 1.1.4](https://github.com/jgauffin/griffin.container)**|296<br/>192|318<br/>219|715<br/>453|2010<br/>1182|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|41<br/>51|47<br/>60|66<br/>97|106<br/>90|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|74<br/>81|121<br/>101|154<br/>129|206<br/>146|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|184<br/>196|2478<br/>1349|25106<br/>30593|160556<br/>207181*|
|**[LightInject 5.0.2](https://github.com/seesharper/LightInject)**|38<br/>50|46<br/>**59**|62<br/>87|82<br/>82|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|3794<br/>2406|19975<br/>14511|51402<br/>35572|122377<br/>75771|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|337<br/>253|374<br/>278|1094<br/>643|3104<br/>1747|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|22424<br/>12124|35595<br/>25034|59216<br/>67576|118099<br/>146429|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|240<br/>208|250<br/>209|345<br/>292|613<br/>443|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|215<br/>271|881<br/>776|2690<br/>2317|8213<br/>7327|
|**[Microsoft Extensions DependencyInjection 1.1.0](https://github.com/aspnet/DependencyInjection)**|182<br/>217|168<br/>139|398<br/>446|1352<br/>1582|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|498<br/>563|822<br/>968|2255<br/>2745|7666<br/>9388|
|**[Munq 3.1.6](http://munq.codeplex.com)**|119<br/>98|161<br/>148|669<br/>467|1992<br/>1319|
|**[Ninject 3.2.2.0](http://ninject.org)**|5224<br/>3437|16579<br/>11961|46445<br/>30800|136712<br/>85362|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|4118<br/>2690|4161<br/>2763|4477<br/>2584|4966<br/>2670|
|**[Rezolver 1.1.71702.500](http://rezolver.co.uk)**|137<br/>102|146<br/>123|221<br/>182|371<br/>256|
|**[SimpleInjector 4.0.3](https://simpleinjector.org)**|58<br/>61|66<br/>67|113<br/>107|135<br/>107|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|976<br/>978|10185<br/>11925|27810<br/>24892|73589<br/>58129|
|**[Stashbox 2.3.2](https://github.com/z4kn4fein/stashbox)**|46<br/>52|58<br/>67|72<br/>82|94<br/>100|
|**[StructureMap 4.4.5](http://structuremap.net/structuremap)**|1164<br/>882|1267<br/>828|3388<br/>2125|8197<br/>4926|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|437<br/>266|485<br/>303|721<br/>451|1513<br/>864|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|455<br/>467|1576<br/>1051|7081<br/>5117|29000<br/>20842|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|2531<br/>1406|3857<br/>2088|10225<br/>5657|28572<br/>16225|
### Advanced Features
|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Asp Net Core**|**Interception With Proxy**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|---------------:|--------------------------:|
|**No**|115<br/>98|71<br/>69|177<br/>135|71<br/>63|613<br/>367|<br/>|72<br/>62|
|**[abioc 0.1.7](https://github.com/JSkimming/abioc)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Autofac 4.4.0](https://github.com/autofac/Autofac)**|21547<br/>14076|1897<br/>1546|9523<br/>6395|<br/>|53674<br/>32505|13723<br/>11964|22840<br/>12583|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|9578<br/>5126|<br/>|6207<br/>3466|<br/>|<br/>|<br/>|<br/>|
|**[Catel 4.5.4](http://www.catelproject.com)**|<br/>|10712<br/>11508|<br/>|<br/>|<br/>|<br/>|4765<br/>5210|
|**[DryIoc 2.10.4](https://bitbucket.org/dadhi/dryioc)**|**85**<br/>96|49<br/>77|**270**<br/>**194**|46<br/>66|<br/>|<br/>|**805**<br/>**520**|
|**[DryIocZero 2.7.0](https://bitbucket.org/dadhi/dryioc)**|439<br/>285|<br/>|311<br/>221|47<br/>**60**|<br/>|<br/>|<br/>|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|786<br/>464|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|1153<br/>641|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Grace 6.0.1](https://github.com/ipjohnson/Grace)**|89<br/>**95**|**47**<br/>79|**270**<br/>212|**39**<br/>**60**|47605<br/>33034|**660**<br/>**528**|944<br/>736|
|**[Griffin 1.1.4](https://github.com/jgauffin/griffin.container)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|815<br/>447|<br/>|1784<br/>993|<br/>|<br/>|<br/>|838<br/>639|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|391<br/>252|146<br/>127|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|2490<br/>2259|17591<br/>17980|40054<br/>31362|<br/>|<br/>|<br/>|<br/>|
|**[LightInject 5.0.2](https://github.com/seesharper/LightInject)**|98<br/>102|59<br/>81|321<br/>236|523<br/>358|<br/>|2106<br/>1649|1309<br/>802|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|3403<br/>1863|714<br/>480|3150<br/>1763|930<br/>586|<br/>|<br/>|5898<br/>3379|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|124601<br/>138121|147178<br/>139065|104933<br/>130921|<br/>|<br/>|<br/>|<br/>|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|1313<br/>1022|315<br/>248|1617<br/>1116|<br/>|<br/>|<br/>|<br/>|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Microsoft Extensions DependencyInjection 1.1.0](https://github.com/aspnet/DependencyInjection)**|<br/>|236<br/>213|942<br/>527|<br/>|<br/>|1713<br/>1742|<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|10420<br/>9159|71665<br/>79952|6639<br/>8367|1841<br/>2230|580141*<br/>542910*|<br/>|13182<br/>16491|
|**[Munq 3.1.6](http://munq.codeplex.com)**|1683<br/>1155|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Ninject 3.2.2.0](http://ninject.org)**|126340<br/>94262|51421<br/>34619|116662<br/>86730|39381<br/>28760|75048000*<br/>53320497*|<br/>|23677<br/>17483|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|6076<br/>3382|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Rezolver 1.1.71702.500](http://rezolver.co.uk)**|532<br/>348|194<br/>167|481<br/>318|<br/>|3540294*<br/>2103281*|26678<br/>16285|<br/>|
|**[SimpleInjector 4.0.3](https://simpleinjector.org)**|188<br/>143|74<br/>84|801<br/>523|87<br/>77|<br/>|<br/>|6792<br/>5499|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|56159<br/>53415|<br/>|<br/>|<br/>|<br/>|<br/>|50289<br/>60213|
|**[Stashbox 2.3.2](https://github.com/z4kn4fein/stashbox)**|116<br/>118|81<br/>**76**|303<br/>297|62<br/>73|209969*<br/>130942|848<br/>587|832<br/>532|
|**[StructureMap 4.4.5](http://structuremap.net/structuremap)**|8462<br/>5138|2321<br/>1451|10205<br/>7610|<br/>|3277400*<br/>1743124*|43792<br/>26532|8377<br/>4566|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|1713<br/>979|1269<br/>699|3082<br/>1725|1329<br/>743|<br/>|<br/>|<br/>|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|4712<br/>4934|<br/>|<br/>|<br/>|**12401**<br/>**7236**|<br/>|<br/>|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|29090<br/>17028|<br/>|45898<br/>23941|<br/>|34469<br/>21442|<br/>|85715<br/>48196|
### Prepare
|**Container**|**Prepare And Register**|**Prepare And Register And Simple Resolve**|
|:------------|-----------------------:|------------------------------------------:|
|**No**|2<br/>|3<br/>|
|**[abioc 0.1.7](https://github.com/JSkimming/abioc)**|67926<br/>|71557<br/>|
|**[Autofac 4.4.0](https://github.com/autofac/Autofac)**|320<br/>|346<br/>|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|58<br/>|64<br/>|
|**[Catel 4.5.4](http://www.catelproject.com)**|6248<br/>|6611<br/>|
|**[DryIoc 2.10.4](https://bitbucket.org/dadhi/dryioc)**|80<br/>|233<br/>|
|**[DryIocZero 2.7.0](https://bitbucket.org/dadhi/dryioc)**|**0**<br/>|**4**<br/>|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|14445<br/>|14432<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|6491<br/>|5686<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|7<br/>|11<br/>|
|**[Grace 6.0.1](https://github.com/ipjohnson/Grace)**|178<br/>|870<br/>|
|**[Griffin 1.1.4](https://github.com/jgauffin/griffin.container)**|8934<br/>|9169<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|56245<br/>|54602<br/>|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|1332<br/>|1819<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|183<br/>|200<br/>|
|**[LightInject 5.0.2](https://github.com/seesharper/LightInject)**|139<br/>|608<br/>|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|99<br/>|346<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|182<br/>|674<br/>|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|15<br/>|2095<br/>|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|5370<br/>|6620<br/>|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|11<br/>|17<br/>|
|**[Microsoft Extensions DependencyInjection 1.1.0](https://github.com/aspnet/DependencyInjection)**|24<br/>|30<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|412<br/>|1672<br/>|
|**[Munq 3.1.6](http://munq.codeplex.com)**|8502<br/>|8519<br/>|
|**[Ninject 3.2.2.0](http://ninject.org)**|88376<br/>|82548<br/>|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|14<br/>|34<br/>|
|**[Rezolver 1.1.71702.500](http://rezolver.co.uk)**|57<br/>|3861<br/>|
|**[SimpleInjector 4.0.3](https://simpleinjector.org)**|806<br/>|3076<br/>|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|27800<br/>|26678<br/>|
|**[Stashbox 2.3.2](https://github.com/z4kn4fein/stashbox)**|104<br/>|345<br/>|
|**[StructureMap 4.4.5](http://structuremap.net/structuremap)**|1434<br/>|7380<br/>|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|67610<br/>|67671<br/>|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|58<br/>|72<br/>|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|645<br/>|2045<br/>|
### Charts
![Basic features](http://www.palmmedia.de/content/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)
![Advanced features](http://www.palmmedia.de/content/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)
![Prepare](http://www.palmmedia.de/content/blogimages/67b056a5-9da8-40b4-9ae6-0c838cdac180.png)
### Machine
The benchmark was executed on the following machine:  
**CPU**: Intel(R) Core(TM) i5-6260U CPU @ 1.80GHz  
**Memory**: 15,89GB
