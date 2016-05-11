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
**OoM**: Benchmark was stopped after an *OutOfMemoryException* was thrown.  
**Error**: Benchmark was stopped after an *Exception* was thrown.  
### Basic Features
|**Container**|**Singleton**|**Transient**|**Combined**|**Complex**|
|:------------|------------:|------------:|-----------:|----------:|
|**No**|108<br/>78|126<br/>116|147<br/>168|222<br/>206|
|**[Autofac 3.5.2](https://github.com/autofac/Autofac)**|893<br/>723|2568<br/>2571|6407<br/>4071|18191<br/>11244|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|538<br/>353|670<br/>405|1867<br/>1085|7969<br/>4632|
|**[Catel 4.4.0](http://www.catelproject.com)**|326<br/>371|5088<br/>5360|13304<br/>14009|30210<br/>32487|
|**[DryIoc 2.4.3](https://bitbucket.org/dadhi/dryioc)**|102<br/>169|179<br/>196|301<br/>288|403<br/>359|
|**[DryIocZero 2.1.0](https://bitbucket.org/dadhi/dryioc)**|78<br/>72|82<br/>81|85<br/>82|203<br/>150|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|105<br/>80|134<br/>103|234<br/>162|823<br/>493|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|75<br/>68|134<br/>112|280<br/>204|680<br/>428|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|149<br/>111|181<br/>132|451<br/>338|1327<br/>852|
|**[Grace 3.0.1.0](https://github.com/ipjohnson/Grace)**|234<br/>160|436<br/>290|1048<br/>627|2779<br/>1536|
|**[Griffin 1.1.2](https://github.com/jgauffin/griffin.container)**|374<br/>231|377<br/>243|971<br/>573|2813<br/>1548|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|91<br/>76|110<br/>95|122<br/>87|222<br/>194|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|108<br/>86|144<br/>115|180<br/>142|233<br/>166|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|203<br/>171|3364<br/>1998|34315<br/>34496|193101*<br/>205435*|
|**[LightInject 4.0.9](https://github.com/seesharper/LightInject)**|**53**<br/>**52**|**63**<br/>**74**|**76**<br/>**80**|**110**<br/>**96**|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|4163<br/>2443|24399<br/>16041|64412<br/>41898|170694<br/>104578|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|333<br/>259|397<br/>306|1115<br/>728|3512<br/>2556|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|34967<br/>19746|53521<br/>31946|87598<br/>65396|175864<br/>169289|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|252<br/>179|263<br/>187|328<br/>250|559<br/>481|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|566<br/>303|818<br/>543|2901<br/>1802|8322<br/>8170|
|**[Microsoft.Framework.DependencyInjection 1.0.0-beta8](https://github.com/aspnet/DependencyInjection)**|193<br/>256|148<br/>124|317<br/>292|908<br/>993|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|459<br/>359|810<br/>582|2380<br/>1666|9042<br/>6674|
|**[Munq 3.1.6](http://munq.codeplex.com)**|111<br/>79|283<br/>192|751<br/>454|2389<br/>1482|
|**[Ninject 3.2.2.0](http://ninject.org)**|7259<br/>4486|24276<br/>15296|69214<br/>39610|191033*<br/>117563|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|6626<br/>4071|5546<br/>3373|6971<br/>4657|8246<br/>6118|
|**[SimpleInjector 3.1.4](https://simpleinjector.org)**|65<br/>58|91<br/>80|116<br/>98|157<br/>125|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|997<br/>752|13890<br/>9012|39235<br/>33605|119975<br/>82439|
|**[Stashbox 1.0.104.0](https://github.com/z4kn4fein/stashbox)**|122<br/>98|183<br/>146|231<br/>180|286<br/>205|
|**[StructureMap 4.2.0.402](http://structuremap.net/structuremap)**|1401<br/>1332|4065<br/>2355|4847<br/>4548|16668<br/>8442|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|656<br/>454|543<br/>383|833<br/>527|2170<br/>2363|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|454<br/>468|2123<br/>1548|8825<br/>6132|35707<br/>26670|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|2846<br/>1872|4571<br/>2754|11527<br/>7661|35292<br/>23766|
|**[Windsor 3.3.0](http://castleproject.org)**|519<br/>383|2626<br/>3658|8893<br/>4861|26098<br/>16700|
### Advanced Features
|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Interception With Proxy**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|--------------------------:|
|**No**|348<br/>176|107<br/>106|275<br/>177|214<br/>180|1899<br/>524|88<br/>106|
|**[Autofac 3.5.2](https://github.com/autofac/Autofac)**|32706<br/>20892|5158<br/>3346|17288<br/>12199|<br/>|108964<br/>86101|51505<br/>37712|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|10427<br/>6064|<br/>|7758<br/>4514|<br/>|<br/>|<br/>|
|**[Catel 4.4.0](http://www.catelproject.com)**|<br/>|12718<br/>13475|<br/>|<br/>|<br/>|5002<br/>5392|
|**[DryIoc 2.4.3](https://bitbucket.org/dadhi/dryioc)**|377<br/>291|236<br/>241|1236<br/>789|104<br/>120|<br/>|1642<br/>1104|
|**[DryIocZero 2.1.0](https://bitbucket.org/dadhi/dryioc)**|217<br/>158|<br/>|403<br/>319|**77**<br/>**73**|<br/>|<br/>|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|855<br/>519|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|1299<br/>789|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Grace 3.0.1.0](https://github.com/ipjohnson/Grace)**|3153<br/>1762|1029<br/>617|3784<br/>2147|1077<br/>673|19958<br/>16758|14134<br/>5589|
|**[Griffin 1.1.2](https://github.com/jgauffin/griffin.container)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|1119<br/>697|<br/>|2252<br/>1373|<br/>|<br/>|**868**<br/>**538**|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|385<br/>269|170<br/>131|<br/>|<br/>|<br/>|<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|2487<br/>1843|23120<br/>15653|52456<br/>31250|<br/>|<br/>|<br/>|
|**[LightInject 4.0.9](https://github.com/seesharper/LightInject)**|**112**<br/>**104**|**76**<br/>**77**|**340**<br/>**243**|600<br/>375|<br/>|1576<br/>1030|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|3866<br/>2367|783<br/>534|3901<br/>2707|1070<br/>693|<br/>|8955<br/>5331|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|180329*<br/>178984|198621*<br/>151746|137126<br/>140873|<br/>|<br/>|<br/>|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|1388<br/>1099|347<br/>241|1759<br/>1379|<br/>|<br/>|<br/>|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Microsoft.Framework.DependencyInjection 1.0.0-beta8](https://github.com/aspnet/DependencyInjection)**|<br/>|217<br/>169|817<br/>552|<br/>|<br/>|<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|11883<br/>7521|71914<br/>76734|6944<br/>7444|2060<br/>1369|706941*<br/>OoM|5051527*<br/>Error|
|**[Munq 3.1.6](http://munq.codeplex.com)**|1899<br/>1169|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Ninject 3.2.2.0](http://ninject.org)**|165177<br/>106569|67347<br/>42019|151450<br/>96672|53576<br/>31926|45724250*<br/>37677615*|36162<br/>22413|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|6297<br/>3789|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[SimpleInjector 3.1.4](https://simpleinjector.org)**|225<br/>175|107<br/>98|2201<br/>1302|267<br/>196|<br/>|3537<br/>760|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|91587<br/>63045|<br/>|<br/>|<br/>|<br/>|72303<br/>69545|
|**[Stashbox 1.0.104.0](https://github.com/z4kn4fein/stashbox)**|442<br/>313|221<br/>177|591<br/>392|224<br/>168|**9818**<br/>**6584**|<br/>|
|**[StructureMap 4.2.0.402](http://structuremap.net/structuremap)**|14457<br/>7863|3709<br/>2022|15119<br/>6406|<br/>|4932054*<br/>2897527*|18488<br/>9464|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|2391<br/>1093|1407<br/>881|3703<br/>4850|1598<br/>965|<br/>|<br/>|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|5062<br/>4660|<br/>|<br/>|<br/>|15411<br/>9844|<br/>|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|42874<br/>29680|<br/>|72235<br/>50134|<br/>|60679<br/>38214|157119<br/>110328|
|**[Windsor 3.3.0](http://castleproject.org)**|52083<br/>32659|27157<br/>17004|26641<br/>13537|<br/>|340330*<br/>Error|21772<br/>13042|
### Prepare
|**Container**|**Prepare And Register**|**Prepare And Register And Simple Resolve**|
|:------------|-----------------------:|------------------------------------------:|
|**No**|4<br/>|4<br/>|
|**[Autofac 3.5.2](https://github.com/autofac/Autofac)**|487<br/>|643<br/>|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|63<br/>|70<br/>|
|**[Catel 4.4.0](http://www.catelproject.com)**|17067<br/>|17340<br/>|
|**[DryIoc 2.4.3](https://bitbucket.org/dadhi/dryioc)**|99<br/>|734<br/>|
|**[DryIocZero 2.1.0](https://bitbucket.org/dadhi/dryioc)**|**0**<br/>|**0**<br/>|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|19090<br/>|18509<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|9324<br/>|8177<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|12<br/>|Error<br/>|
|**[Grace 3.0.1.0](https://github.com/ipjohnson/Grace)**|4884<br/>|4625<br/>|
|**[Griffin 1.1.2](https://github.com/jgauffin/griffin.container)**|12609<br/>|12089<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|81766<br/>|83181<br/>|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|2101<br/>|2795<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|233<br/>|247<br/>|
|**[LightInject 4.0.9](https://github.com/seesharper/LightInject)**|167<br/>|855<br/>|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|140<br/>|538<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|232<br/>|952<br/>|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|23<br/>|3054<br/>|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|7330<br/>|11858<br/>|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|18<br/>|23<br/>|
|**[Microsoft.Framework.DependencyInjection 1.0.0-beta8](https://github.com/aspnet/DependencyInjection)**|31<br/>|40<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|559<br/>|2378<br/>|
|**[Munq 3.1.6](http://munq.codeplex.com)**|12084<br/>|12117<br/>|
|**[Ninject 3.2.2.0](http://ninject.org)**|115051<br/>|157982<br/>|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|25<br/>|49<br/>|
|**[SimpleInjector 3.1.4](https://simpleinjector.org)**|507<br/>|1574<br/>|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|40443<br/>|34294<br/>|
|**[Stashbox 1.0.104.0](https://github.com/z4kn4fein/stashbox)**|1332<br/>|2227<br/>|
|**[StructureMap 4.2.0.402](http://structuremap.net/structuremap)**|1995<br/>|14198<br/>|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|91820<br/>|85792<br/>|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|185<br/>|224<br/>|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|957<br/>|3174<br/>|
|**[Windsor 3.3.0](http://castleproject.org)**|4141<br/>|4463<br/>|
### Charts
![Basic features](http://www.palmmedia.de/content/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)
![Advanced features](http://www.palmmedia.de/content/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)
![Prepare](http://www.palmmedia.de/content/blogimages/67b056a5-9da8-40b4-9ae6-0c838cdac180.png)
### Machine
The benchmark was executed on the following machine:  
**CPU**: Intel(R) Core(TM) i7 CPU       M 620  @ 2.67GHz  
**Memory**: 7,86GB
