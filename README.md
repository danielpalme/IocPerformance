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
|**No**|40<br/>42|49<br/>49|62<br/>79|70<br/>66|
|**[Autofac 3.5.2](https://github.com/autofac/Autofac)**|593<br/>411|1513<br/>874|4178<br/>2283|11456<br/>6984|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|372<br/>218|453<br/>258|1357<br/>732|5845<br/>3084|
|**[Catel 4.4.0](http://www.catelproject.com)**|245<br/>264|3196<br/>3359|7894<br/>8045|18460<br/>19081|
|**[DryIoc 2.3.0](https://bitbucket.org/dadhi/dryioc)**|**25**<br/>**32**|**35**<br/>54|**48**<br/>**76**|**64**<br/>**63**|
|**[DryIocZero 2.1.0](https://bitbucket.org/dadhi/dryioc)**|65<br/>55|62<br/>56|65<br/>81|158<br/>112|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|68<br/>53|75<br/>65|164<br/>117|490<br/>280|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|61<br/>50|101<br/>78|211<br/>141|477<br/>273|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|95<br/>71|120<br/>88|309<br/>210|871<br/>487|
|**[Grace 2.4.2](https://github.com/ipjohnson/Grace)**|138<br/>91|238<br/>157|590<br/>346|1621<br/>883|
|**[Griffin 1.1.2](https://github.com/jgauffin/griffin.container)**|232<br/>146|245<br/>163|574<br/>336|1599<br/>883|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|31<br/>41|39<br/>52|57<br/>77|85<br/>74|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|63<br/>52|101<br/>84|124<br/>99|176<br/>117|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|144<br/>135|1914<br/>1102|21137<br/>22079|122835<br/>129321|
|**[LightInject 4.0.8](https://github.com/seesharper/LightInject)**|31<br/>36|39<br/>**51**|51<br/>81|68<br/>**63**|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|2696<br/>1439|14272<br/>8922|36394<br/>21709|95710<br/>54667|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|274<br/>190|312<br/>220|893<br/>524|2595<br/>1406|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|17923<br/>9648|30137<br/>21535|49821<br/>57394|98316<br/>148040|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|178<br/>115|188<br/>126|257<br/>165|450<br/>259|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|157<br/>181|602<br/>369|1978<br/>1116|5952<br/>3889|
|**[Microsoft.Framework.DependencyInjection 1.0.0-beta8](https://github.com/aspnet/DependencyInjection)**|142<br/>161|123<br/>91|267<br/>283|702<br/>759|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|378<br/>320|603<br/>500|1807<br/>1452|6878<br/>5707|
|**[Munq 3.1.6](http://munq.codeplex.com)**|78<br/>68|118<br/>111|477<br/>324|1628<br/>1016|
|**[Ninject 3.2.2.0](http://ninject.org)**|4100<br/>2643|14115<br/>9007|37962<br/>23254|109832<br/>66536|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|3240<br/>1759|3287<br/>1749|3933<br/>2112|4239<br/>2202|
|**[SimpleInjector 3.1.2](https://simpleinjector.org)**|49<br/>45|59<br/>55|73<br/>89|120<br/>88|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|811<br/>566|7978<br/>5728|22504<br/>15233|60493<br/>37084|
|**[Stashbox 1.0.104.0](https://github.com/z4kn4fein/stashbox)**|83<br/>69|153<br/>110|184<br/>140|224<br/>157|
|**[StructureMap 4.1.2.386](http://structuremap.net/structuremap)**|982<br/>649|1098<br/>665|3083<br/>1806|7657<br/>4310|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|381<br/>217|427<br/>245|653<br/>376|1251<br/>688|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|368<br/>363|1429<br/>868|6096<br/>3953|25026<br/>16608|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|2062<br/>1121|3223<br/>1714|8356<br/>4389|24167<br/>12564|
|**[Windsor 3.3.0](http://castleproject.org)**|381<br/>274|1627<br/>908|5204<br/>2784|15127<br/>8053|
### Advanced Features
|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Interception With Proxy**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|--------------------------:|
|**No**|94<br/>75|58<br/>56|143<br/>98|55<br/>**52**|489<br/>287|53<br/>50|
|**[Autofac 3.5.2](https://github.com/autofac/Autofac)**|21168<br/>12858|3243<br/>2090|11774<br/>6189|<br/>|57577<br/>30082|25086<br/>13041|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|7702<br/>4014|<br/>|5212<br/>2745|<br/>|<br/>|<br/>|
|**[Catel 4.4.0](http://www.catelproject.com)**|<br/>|7809<br/>8071|<br/>|<br/>|<br/>|3210<br/>3348|
|**[DryIoc 2.3.0](https://bitbucket.org/dadhi/dryioc)**|**78**<br/>**72**|**45**<br/>**55**|**235**<br/>**152**|**43**<br/>**52**|<br/>|651<br/>398|
|**[DryIocZero 2.1.0](https://bitbucket.org/dadhi/dryioc)**|166<br/>123|<br/>|268<br/>174|57<br/>59|<br/>|<br/>|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|667<br/>365|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|942<br/>495|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Grace 2.4.2](https://github.com/ipjohnson/Grace)**|1752<br/>941|572<br/>342|2036<br/>1085|624<br/>362|9868<br/>5371|4574<br/>2472|
|**[Griffin 1.1.2](https://github.com/jgauffin/griffin.container)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|666<br/>362|<br/>|1481<br/>811|<br/>|<br/>|**578**<br/>**365**|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|306<br/>195|118<br/>97|<br/>|<br/>|<br/>|<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|1897<br/>1459|13369<br/>9665|29433<br/>16245|<br/>|<br/>|<br/>|
|**[LightInject 4.0.8](https://github.com/seesharper/LightInject)**|88<br/>73|47<br/>70|238<br/>**152**|427<br/>254|<br/>|1082<br/>609|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|2729<br/>1491|631<br/>382|2676<br/>1491|819<br/>476|<br/>|4601<br/>2517|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|102358<br/>107159|115888<br/>99151|81370<br/>78788|<br/>|<br/>|<br/>|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|986<br/>533|219<br/>149|1147<br/>628|<br/>|<br/>|<br/>|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Microsoft.Framework.DependencyInjection 1.0.0-beta8](https://github.com/aspnet/DependencyInjection)**|<br/>|177<br/>124|674<br/>373|<br/>|<br/>|<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|8642<br/>5914|54108<br/>56571|4982<br/>5422|1505<br/>1157|489945*<br/>576857*|30802<br/>35829|
|**[Munq 3.1.6](http://munq.codeplex.com)**|1513<br/>965|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Ninject 3.2.2.0](http://ninject.org)**|97470<br/>59767|39210<br/>22666|91175<br/>59811|30116<br/>18335|53916500*<br/>41394482*|21702<br/>13987|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|5395<br/>2870|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[SimpleInjector 3.1.2](https://simpleinjector.org)**|173<br/>122|60<br/>66|685<br/>376|60<br/>65|<br/>|840<br/>498|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|45667<br/>28873|<br/>|<br/>|<br/>|<br/>|37734<br/>35581|
|**[Stashbox 1.0.104.0](https://github.com/z4kn4fein/stashbox)**|352<br/>234|169<br/>130|441<br/>271|163<br/>114|**6558**<br/>**3872**|<br/>|
|**[StructureMap 4.1.2.386](http://structuremap.net/structuremap)**|7996<br/>4350|2069<br/>1241|6410<br/>3560|<br/>|2806338*<br/>1525251*|6130<br/>3331|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|1399<br/>800|1071<br/>595|2712<br/>1433|1226<br/>652|<br/>|<br/>|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|4041<br/>3822|<br/>|<br/>|<br/>|10600<br/>5990|<br/>|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|24405<br/>12959|<br/>|37129<br/>19022|<br/>|27933<br/>15527|85704<br/>44313|
|**[Windsor 3.3.0](http://castleproject.org)**|28248<br/>14847|12377<br/>6621|13322<br/>7190|<br/>|193328*<br/>Error|11341<br/>5927|
### Prepare
|**Container**|**Prepare And Register**|**Prepare And Register And Simple Resolve**|
|:------------|-----------------------:|------------------------------------------:|
|**No**|2<br/>|2<br/>|
|**[Autofac 3.5.2](https://github.com/autofac/Autofac)**|267<br/>|286<br/>|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|47<br/>|48<br/>|
|**[Catel 4.4.0](http://www.catelproject.com)**|7770<br/>|8048<br/>|
|**[DryIoc 2.3.0](https://bitbucket.org/dadhi/dryioc)**|53<br/>|409<br/>|
|**[DryIocZero 2.1.0](https://bitbucket.org/dadhi/dryioc)**|**0**<br/>|**0**<br/>|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|13572<br/>|13618<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|5747<br/>|5907<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|6<br/>|6<br/>|
|**[Grace 2.4.2](https://github.com/ipjohnson/Grace)**|84048<br/>|84060<br/>|
|**[Griffin 1.1.2](https://github.com/jgauffin/griffin.container)**|7332<br/>|7300<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|45009<br/>|45180<br/>|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|1148<br/>|1635<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|152<br/>|162<br/>|
|**[LightInject 4.0.8](https://github.com/seesharper/LightInject)**|138<br/>|617<br/>|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|80<br/>|295<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|141<br/>|632<br/>|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|11<br/>|1744<br/>|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|4471<br/>|5497<br/>|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|11<br/>|18<br/>|
|**[Microsoft.Framework.DependencyInjection 1.0.0-beta8](https://github.com/aspnet/DependencyInjection)**|19<br/>|24<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|458<br/>|1711<br/>|
|**[Munq 3.1.6](http://munq.codeplex.com)**|8400<br/>|8595<br/>|
|**[Ninject 3.2.2.0](http://ninject.org)**|107930<br/>|72683<br/>|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|24<br/>|41<br/>|
|**[SimpleInjector 3.1.2](https://simpleinjector.org)**|335<br/>|1121<br/>|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|20751<br/>|20590<br/>|
|**[Stashbox 1.0.104.0](https://github.com/z4kn4fein/stashbox)**|821<br/>|1325<br/>|
|**[StructureMap 4.1.2.386](http://structuremap.net/structuremap)**|1176<br/>|6462<br/>|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|64094<br/>|62895<br/>|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|50<br/>|57<br/>|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|514<br/>|1866<br/>|
|**[Windsor 3.3.0](http://castleproject.org)**|2579<br/>|2648<br/>|
### Charts
![Basic features](http://www.palmmedia.de/content/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)
![Advanced features](http://www.palmmedia.de/content/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)
![Prepare](http://www.palmmedia.de/content/blogimages/67b056a5-9da8-40b4-9ae6-0c838cdac180.png)
### Machine
The benchmark was executed on the following machine:  
**CPU**: Intel(R) Core(TM) i7-4710MQ CPU @ 2.50GHz  
**Memory**: 7.88GB
