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
|**No**|54<br/>61|67<br/>71|87<br/>103|106<br/>91|
|**[Autofac 4.4.0](https://github.com/autofac/Autofac)**|823<br/>608|1081<br/>731|2951<br/>1943|10424<br/>6676|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|512<br/>344|620<br/>399|1876<br/>1104|8092<br/>4635|
|**[Catel 4.5.4](http://www.catelproject.com)**|342<br/>401|4686<br/>5218|11356<br/>12758|26629<br/>29753|
|**[DryIoc 2.10.4](https://bitbucket.org/dadhi/dryioc)**|**31**<br/>46|43<br/>**66**|**60**<br/>92|78<br/>**83**|
|**[DryIocZero 2.7.0](https://bitbucket.org/dadhi/dryioc)**|101<br/>92|83<br/>90|120<br/>116|399<br/>277|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|87<br/>85|109<br/>94|208<br/>169|656<br/>430|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|69<br/>70|125<br/>109|305<br/>201|592<br/>370|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|133<br/>106|159<br/>135|447<br/>294|1189<br/>725|
|**[Grace 6.0.1](https://github.com/ipjohnson/Grace)**|**31**<br/>**43**|**41**<br/>70|79<br/>**84**|**72**<br/>84|
|**[Griffin 1.1.4](https://github.com/jgauffin/griffin.container)**|320<br/>229|358<br/>231|740<br/>489|2035<br/>1335|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|44<br/>55|53<br/>67|96<br/>94|113<br/>109|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|83<br/>71|130<br/>113|164<br/>139|218<br/>158|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|204<br/>196|2601<br/>1665|29759<br/>33745|176326<br/>203140*|
|**[LightInject 5.0.2](https://github.com/seesharper/LightInject)**|39<br/>56|52<br/>67|69<br/>97|88<br/>91|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|3758<br/>2171|19762<br/>14384|50527<br/>35633|130506<br/>87054|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|369<br/>279|1927<br/>2667|1148<br/>733|3487<br/>2021|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|23571<br/>13866|40190<br/>26135|66049<br/>54833|131319<br/>159197|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|276<br/>238|288<br/>277|404<br/>276|575<br/>368|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|201<br/>255|808<br/>580|2786<br/>1864|7978<br/>5820|
|**[Microsoft Extensions DependencyInjection 1.1.0](https://github.com/aspnet/DependencyInjection)**|207<br/>269|177<br/>121|404<br/>415|1417<br/>1792|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|597<br/>462|869<br/>777|2516<br/>2212|9418<br/>8383|
|**[Munq 3.1.6](http://munq.codeplex.com)**|98<br/>92|183<br/>154|613<br/>424|1864<br/>1262|
|**[Ninject 3.2.2.0](http://ninject.org)**|5612<br/>3765|19063<br/>631951*|56924<br/>34347|150343<br/>97100|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|4292<br/>2547|4242<br/>2729|5068<br/>3290|5714<br/>3420|
|**[Rezolver 1.1.71702.500](http://rezolver.co.uk)**|165<br/>121|186<br/>140|254<br/>216|471<br/>318|
|**[SimpleInjector 4.0.0](https://simpleinjector.org)**|59<br/>77|92<br/>88|133<br/>119|166<br/>132|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|1095<br/>947|11501<br/>8172|31280<br/>22907|84470<br/>55607|
|**[Stashbox 2.3.2](https://github.com/z4kn4fein/stashbox)**|47<br/>59|75<br/>73|88<br/>108|99<br/>103|
|**[StructureMap 4.4.3](http://structuremap.net/structuremap)**|1393<br/>1102|1534<br/>1030|4147<br/>2592|9526<br/>6276|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|511<br/>329|601<br/>368|828<br/>528|1637<br/>1005|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|511<br/>511|2004<br/>1397|8621<br/>6403|35642<br/>25439|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|2714<br/>1723|4261<br/>2586|11262<br/>6922|31996<br/>19938|
### Advanced Features
|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Asp Net Core**|**Interception With Proxy**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|---------------:|--------------------------:|
|**No**|126<br/>113|80<br/>76|194<br/>152|73<br/>80|690<br/>465|<br/>|73<br/>70|
|**[Autofac 4.4.0](https://github.com/autofac/Autofac)**|23707<br/>14526|2166<br/>1445|10470<br/>6430|<br/>|60280<br/>36277|15303<br/>10641|27003<br/>15963|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|10649<br/>6149|<br/>|7308<br/>4224|<br/>|<br/>|<br/>|<br/>|
|**[Catel 4.5.4](http://www.catelproject.com)**|<br/>|11416<br/>12878|<br/>|<br/>|<br/>|<br/>|4643<br/>5254|
|**[DryIoc 2.10.4](https://bitbucket.org/dadhi/dryioc)**|90<br/>**100**|54<br/>83|348<br/>231|49<br/>70|<br/>|<br/>|895<br/>585|
|**[DryIocZero 2.7.0](https://bitbucket.org/dadhi/dryioc)**|443<br/>317|<br/>|362<br/>312|53<br/>**67**|<br/>|<br/>|<br/>|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|906<br/>556|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|1220<br/>749|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Grace 6.0.1](https://github.com/ipjohnson/Grace)**|**87**<br/>101|**51**<br/>80|**321**<br/>**229**|**48**<br/>74|52743<br/>31370|**601**<br/>**468**|913<br/>605|
|**[Griffin 1.1.4](https://github.com/jgauffin/griffin.container)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|856<br/>583|<br/>|2010<br/>1191|<br/>|<br/>|<br/>|**791**<br/>**540**|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|385<br/>260|161<br/>129|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|2474<br/>2115|18993<br/>14635|41298<br/>25874|<br/>|<br/>|<br/>|<br/>|
|**[LightInject 5.0.2](https://github.com/seesharper/LightInject)**|108<br/>103|61<br/>**72**|348<br/>230|590<br/>352|<br/>|2422<br/>1806|1478<br/>958|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|3691<br/>2132|832<br/>544|3719<br/>2293|1078<br/>679|<br/>|<br/>|6424<br/>3830|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|137068<br/>156328|155877<br/>130318|108392<br/>123854|<br/>|<br/>|<br/>|<br/>|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|1252<br/>802|378<br/>279|1669<br/>1121|<br/>|<br/>|<br/>|<br/>|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Microsoft Extensions DependencyInjection 1.1.0](https://github.com/aspnet/DependencyInjection)**|<br/>|226<br/>170|952<br/>608|<br/>|<br/>|1990<br/>1809|<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|11645<br/>9460|79433<br/>90829|6687<br/>8439|2071<br/>1835|722348*<br/>570139*|<br/>|25352<br/>24958|
|**[Munq 3.1.6](http://munq.codeplex.com)**|1769<br/>1225|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Ninject 3.2.2.0](http://ninject.org)**|130276<br/>90733|50730<br/>34804|121448<br/>84529|41837<br/>26154|53927500*<br/>34264359*|<br/>|28441<br/>18217|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|7237<br/>4508|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Rezolver 1.1.71702.500](http://rezolver.co.uk)**|705<br/>422|288<br/>187|614<br/>437|<br/>|4319833*<br/>2627441*|31185<br/>20298|<br/>|
|**[SimpleInjector 4.0.0](https://simpleinjector.org)**|238<br/>188|84<br/>97|980<br/>573|82<br/>90|<br/>|<br/>|7974<br/>4743|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|64899<br/>43955|<br/>|<br/>|<br/>|<br/>|<br/>|53340<br/>40079|
|**[Stashbox 2.3.2](https://github.com/z4kn4fein/stashbox)**|130<br/>122|73<br/>88|367<br/>262|65<br/>75|270578*<br/>151329|1003<br/>910|983<br/>694|
|**[StructureMap 4.4.3](http://structuremap.net/structuremap)**|9635<br/>6261|2579<br/>1771|7883<br/>5128|<br/>|3729265*<br/>2227459*|47835<br/>30608|8213<br/>4949|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|1831<br/>1109|1379<br/>915|3631<br/>2211|1538<br/>932|<br/>|<br/>|<br/>|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|5465<br/>5143|<br/>|<br/>|<br/>|**14211**<br/>**9201**|<br/>|<br/>|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|32246<br/>20305|<br/>|49488<br/>28635|<br/>|38461<br/>25684|<br/>|107595<br/>61291|
### Prepare
|**Container**|**Prepare And Register**|**Prepare And Register And Simple Resolve**|
|:------------|-----------------------:|------------------------------------------:|
|**No**|2<br/>|3<br/>|
|**[Autofac 4.4.0](https://github.com/autofac/Autofac)**|369<br/>|405<br/>|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|66<br/>|68<br/>|
|**[Catel 4.5.4](http://www.catelproject.com)**|26901<br/>|27442<br/>|
|**[DryIoc 2.10.4](https://bitbucket.org/dadhi/dryioc)**|94<br/>|345<br/>|
|**[DryIocZero 2.7.0](https://bitbucket.org/dadhi/dryioc)**|**0**<br/>|**1**<br/>|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|20339<br/>|20229<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|8963<br/>|8841<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|9<br/>|9<br/>|
|**[Grace 6.0.1](https://github.com/ipjohnson/Grace)**|172<br/>|1078<br/>|
|**[Griffin 1.1.4](https://github.com/jgauffin/griffin.container)**|10960<br/>|10991<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|62706<br/>|63460<br/>|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|1517<br/>|2327<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|233<br/>|237<br/>|
|**[LightInject 5.0.2](https://github.com/seesharper/LightInject)**|161<br/>|904<br/>|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|111<br/>|384<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|204<br/>|987<br/>|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|22<br/>|3006<br/>|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|6432<br/>|8296<br/>|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|13<br/>|18<br/>|
|**[Microsoft Extensions DependencyInjection 1.1.0](https://github.com/aspnet/DependencyInjection)**|28<br/>|33<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|627<br/>|2243<br/>|
|**[Munq 3.1.6](http://munq.codeplex.com)**|12663<br/>|12392<br/>|
|**[Ninject 3.2.2.0](http://ninject.org)**|115769<br/>|109147<br/>|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|25<br/>|47<br/>|
|**[Rezolver 1.1.71702.500](http://rezolver.co.uk)**|64<br/>|5032<br/>|
|**[SimpleInjector 4.0.0](https://simpleinjector.org)**|756<br/>|4146<br/>|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|28730<br/>|29345<br/>|
|**[Stashbox 2.3.2](https://github.com/z4kn4fein/stashbox)**|133<br/>|478<br/>|
|**[StructureMap 4.4.3](http://structuremap.net/structuremap)**|1567<br/>|8667<br/>|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|85608<br/>|87242<br/>|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|71<br/>|78<br/>|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|738<br/>|2712<br/>|
### Charts
![Basic features](http://www.palmmedia.de/content/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)
![Advanced features](http://www.palmmedia.de/content/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)
![Prepare](http://www.palmmedia.de/content/blogimages/67b056a5-9da8-40b4-9ae6-0c838cdac180.png)
### Machine
The benchmark was executed on the following machine:  
**CPU**: Intel(R) Core(TM) i5-5200U CPU @ 2.20GHz  
**Memory**: 11.91GB
