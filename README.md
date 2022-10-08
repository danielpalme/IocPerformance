# Ioc Performance

[![Build Status](https://github.com/danielpalme/IocPerformance/workflows/Smoketest/badge.svg)](https://github.com/danielpalme/IocPerformance/workflows/Smoketest/badge.svg)

Source code of my performance comparison of the most popular .NET IoC containers:  
[www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison](https://www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison)

Author: Daniel Palme  
Blog: [www.palmmedia.de](https://www.palmmedia.de)  
Twitter: [@danielpalme](https://twitter.com/danielpalme)  

## Results
### Explantions
**First value**: Time of single-threaded execution in [ms]  
**Second value**: Time of multi-threaded execution in [ms]  
**_*_**: Benchmark was stopped after 1 minute and result is extrapolated.  
### Basic Features
|**Container**|**Singleton**|**Transient**|**Combined**|**Complex**|
|:------------|------------:|------------:|-----------:|----------:|
|**No**|41<br/>49|49<br/>59|69<br/>76|99<br/>103|
|**[abioc 0.8.0](https://github.com/JSkimming/abioc)**|26<br/>43|**33**<br/>56|**51**<br/>82|**67**<br/>**78**|
|**[Autofac 6.4.0](https://github.com/autofac/Autofac)**|820<br/>589|970<br/>663|2648<br/>1675|8048<br/>5021|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|465<br/>270|533<br/>322|1583<br/>906|7403<br/>3712|
|**[Catel 5.12.22](http://www.catelproject.com)**|250<br/>296|3979<br/>4314|8954<br/>9876|25104<br/>23025|
|**[DryIoc 4.8.5](https://github.com/dadhi/DryIoc)**|63<br/>54|73<br/>73|89<br/>100|110<br/>101|
|**[DryIocZero 4.0.0](https://github.com/dadhi/DryIoc)**|110<br/>96|88<br/>89|98<br/>105|220<br/>169|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|95<br/>70|104<br/>86|207<br/>158|685<br/>381|
|**[Faster.Ioc 1.0.0](https://github.com/Wsm2110/Faster.Ioc)**|25<br/>46|72<br/>62|67<br/>82|139<br/>93|
|**[Grace 7.2.1](https://github.com/ipjohnson/Grace)**|**20**<br/>**31**|39<br/>**55**|52<br/>84|73<br/>83|
|**[Lamar 8.0.1](https://jasperfx.github.io/lamar/)**|61<br/>63|86<br/>83|117<br/>110|130<br/>127|
|**[LightInject 6.6.1](https://github.com/seesharper/LightInject)**|40<br/>49|53<br/>60|85<br/>91|167<br/>128|
|**[Maestro 3.6.6](https://github.com/JonasSamuelsson/Maestro)**|386<br/>269|342<br/>241|580<br/>438|1411<br/>1097|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|22679<br/>11820|37640<br/>25052|57462<br/>68730*|112712*<br/>131716*|
|**[Mef2 6.0.0.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|217<br/>152|210<br/>162|322<br/>268|724<br/>416|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|25<br/>39|34<br/>59|55<br/>**77**|92<br/>89|
|**[Microsoft Extensions DependencyInjection 6.0.0](https://github.com/aspnet/Extensions)**|65<br/>57|108<br/>82|108<br/>109|150<br/>115|
|**[Microsoft.VisualStudio.Composition 17.2.41](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|9738<br/>5088|13203<br/>9883|20881<br/>16572|55582<br/>49981|
|**[Mugen MVVM Toolkit 6.5.0](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)**|102<br/>138|409<br/>715|2052<br/>2590|9348<br/>11352|
|**[MvvmCross 8.0.2](https://github.com/MvvmCross/MvvmCross)**|205<br/>251|1318<br/>1402|3316<br/>3726|8677<br/>9516|
|**[Ninject 3.3.6](http://ninject.org)**|3809<br/>4583|13588<br/>11986|37822<br/>28199|105486*<br/>79549*|
|**[Pure.DI 1.1.55](https://github.com/DevTeam/Pure.DI)**|24<br/>36|38<br/>60|62<br/>81|80<br/>91|
|**[Rezolver 2.1.0](http://rezolver.co.uk)**|121<br/>100|137<br/>126|194<br/>171|328<br/>238|
|**[SimpleInjector 5.4.1](https://simpleinjector.org)**|87<br/>67|71<br/>91|152<br/>129|233<br/>179|
|**[Singularity 0.18.0](https://github.com/Barsonax/Singularity)**|24<br/>39|39<br/>59|66<br/>82|76<br/>84|
|**[Spring.NET 3.0.0](http://www.springframework.net/)**|553<br/>446|2533<br/>1535|8190<br/>5084|23729<br/>15167|
|**[Stashbox 5.4.3](https://github.com/z4kn4fein/stashbox)**|62<br/>61|112<br/>68|85<br/>113|186<br/>167|
|**[StructureMap 4.7.1](http://structuremap.net/structuremap)**|1121<br/>717|1281<br/>856|3410<br/>2166|8312<br/>6052|
|**[Unity 5.11.10](https://github.com/unitycontainer/unity)**|216<br/>148|1443<br/>835|3326<br/>1995|9503<br/>4739|
|**[Windsor 5.1.2](http://castleproject.org)**|473<br/>406|2815<br/>1308|9305<br/>4215|21281<br/>12262|
|**[ZenIoc 1.0.1](https://github.com/zenmvvm/ZenIoc)**|306<br/>198|267<br/>188|674<br/>440|1809<br/>1103|
|**[Zenject 8.0.0](https://github.com/modesttree/Zenject)**|479<br/>448|1370<br/>1070|3689<br/>3065|11142<br/>10106|
### Advanced Features
|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Asp Net Core**|**Interception With Proxy**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|---------------:|--------------------------:|
|**No**|186<br/>134|70<br/>75|193<br/>176|53<br/>63|644<br/>596|<br/>|469<br/>438|
|**[abioc 0.8.0](https://github.com/JSkimming/abioc)**|<br/>|<br/>|799<br/>506|<br/>|<br/>|<br/>|<br/>|
|**[Autofac 6.4.0](https://github.com/autofac/Autofac)**|8548<br/>7022|2059<br/>1481|10702<br/>5475|2258<br/>1645|75196*<br/>69767*|45323<br/>39283|22455<br/>14802|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|9157<br/>4733|<br/>|5965<br/>3393|<br/>|<br/>|<br/>|<br/>|
|**[Catel 5.12.22](http://www.catelproject.com)**|<br/>|8872<br/>9710|<br/>|<br/>|<br/>|<br/>|3937<br/>4257|
|**[DryIoc 4.8.5](https://github.com/dadhi/DryIoc)**|144<br/>131|86<br/>88|294<br/>219|81<br/>79|<br/>|1379<br/>1005|835<br/>555|
|**[DryIocZero 4.0.0](https://github.com/dadhi/DryIoc)**|294<br/>205|92<br/>92|302<br/>229|380<br/>270|<br/>|<br/>|<br/>|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|828<br/>455|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Faster.Ioc 1.0.0](https://github.com/Wsm2110/Faster.Ioc)**|<br/>|95<br/>87|388<br/>287|107<br/>**66**|<br/>|797<br/>**635**|<br/>|
|**[Grace 7.2.1](https://github.com/ipjohnson/Grace)**|101<br/>112|**50**<br/>**80**|257<br/>210|**45**<br/>70|50375<br/>32231|657<br/>674|827<br/>571|
|**[Lamar 8.0.1](https://jasperfx.github.io/lamar/)**|133<br/>98|106<br/>108|634<br/>432|<br/>|<br/>|4753<br/>4323|<br/>|
|**[LightInject 6.6.1](https://github.com/seesharper/LightInject)**|195<br/>214|85<br/>83|384<br/>244|454<br/>281|<br/>|2246<br/>1488|1484<br/>1040|
|**[Maestro 3.6.6](https://github.com/JonasSamuelsson/Maestro)**|3886<br/>2438|419<br/>318|1272<br/>843|<br/>|<br/>|10764<br/>8560|6757<br/>3630|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|124500*<br/>133833*|137086*<br/>114221*|97231*<br/>100896*|<br/>|<br/>|<br/>|<br/>|
|**[Mef2 6.0.0.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|1390<br/>928|363<br/>223|1212<br/>811|<br/>|<br/>|<br/>|<br/>|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|**39**<br/>**62**|<br/>|262<br/>195|<br/>|<br/>|<br/>|<br/>|
|**[Microsoft Extensions DependencyInjection 6.0.0](https://github.com/aspnet/Extensions)**|<br/>|108<br/>101|336<br/>251|<br/>|<br/>|3725<br/>2785|<br/>|
|**[Microsoft.VisualStudio.Composition 17.2.41](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|44751<br/>52108|<br/>|85109*<br/>40759|<br/>|<br/>|<br/>|<br/>|
|**[Mugen MVVM Toolkit 6.5.0](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)**|436<br/>705|<br/>|9749<br/>7094|<br/>|**4370**<br/>**3103**|<br/>|<br/>|
|**[MvvmCross 8.0.2](https://github.com/MvvmCross/MvvmCross)**|1310<br/>1415|6576<br/>7299|<br/>|<br/>|4968<br/>3230|<br/>|<br/>|
|**[Ninject 3.3.6](http://ninject.org)**|78292*<br/>60394*|28241<br/>20249|92792*<br/>68004*|24794<br/>18311|78784000*<br/>45766768*|<br/>|22231<br/>19065|
|**[Pure.DI 1.1.55](https://github.com/DevTeam/Pure.DI)**|47<br/>68|57<br/>100|**201**<br/>**174**|52<br/>71|<br/>|<br/>|**242**<br/>**227**|
|**[Rezolver 2.1.0](http://rezolver.co.uk)**|520<br/>385|183<br/>145|669<br/>408|<br/>|9589857*<br/>5697265*|86587*<br/>56374|<br/>|
|**[SimpleInjector 5.4.1](https://simpleinjector.org)**|366<br/>204|99<br/>103|755<br/>738|85<br/>83|<br/>|<br/>|5503<br/>4220|
|**[Singularity 0.18.0](https://github.com/Barsonax/Singularity)**|<br/>|54<br/>**80**|241<br/>193|<br/>|<br/>|**631**<br/>652|<br/>|
|**[Spring.NET 3.0.0](http://www.springframework.net/)**|18982<br/>11962|<br/>|<br/>|<br/>|<br/>|<br/>|18461<br/>11065|
|**[Stashbox 5.4.3](https://github.com/z4kn4fein/stashbox)**|221<br/>189|61<br/>87|366<br/>230|61<br/>73|795236*<br/>419952*|1926<br/>2247|1774<br/>740|
|**[StructureMap 4.7.1](http://structuremap.net/structuremap)**|8697<br/>5284|2271<br/>1460|8399<br/>5170|<br/>|3215578*<br/>1887211*|65269*<br/>41725|7859<br/>4464|
|**[Unity 5.11.10](https://github.com/unitycontainer/unity)**|9045<br/>5814|9842<br/>6443|17755<br/>12048|3547<br/>2046|147355*<br/>74313*|61350*<br/>39009|56226<br/>31096|
|**[Windsor 5.1.2](http://castleproject.org)**|44988<br/>24115|25168<br/>10238|19471<br/>10795|<br/>|300485*<br/>157429*|<br/>|15799<br/>11699|
|**[ZenIoc 1.0.1](https://github.com/zenmvvm/ZenIoc)**|264<br/>195|276<br/>209|704<br/>488|314<br/>222|602490*<br/>471765*|<br/>|<br/>|
|**[Zenject 8.0.0](https://github.com/modesttree/Zenject)**|15829<br/>13135|9021<br/>6513|17932<br/>12687|3082<br/>2428|22250<br/>18595|<br/>|<br/>|
### Prepare
|**Container**|**Prepare And Register**|**Prepare And Register And Simple Resolve**|
|:------------|-----------------------:|------------------------------------------:|
|**No**|2<br/>|2<br/>|
|**[abioc 0.8.0](https://github.com/JSkimming/abioc)**|6327<br/>|6556<br/>|
|**[Autofac 6.4.0](https://github.com/autofac/Autofac)**|386<br/>|425<br/>|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|55<br/>|56<br/>|
|**[Catel 5.12.22](http://www.catelproject.com)**|11925<br/>|9956<br/>|
|**[DryIoc 4.8.5](https://github.com/dadhi/DryIoc)**|56<br/>|64<br/>|
|**[DryIocZero 4.0.0](https://github.com/dadhi/DryIoc)**|**0**<br/>|**1**<br/>|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|16240<br/>|16527<br/>|
|**[Faster.Ioc 1.0.0](https://github.com/Wsm2110/Faster.Ioc)**|51<br/>|1283<br/>|
|**[Grace 7.2.1](https://github.com/ipjohnson/Grace)**|157<br/>|966<br/>|
|**[Lamar 8.0.1](https://jasperfx.github.io/lamar/)**|2516<br/>|3044<br/>|
|**[LightInject 6.6.1](https://github.com/seesharper/LightInject)**|123<br/>|2232<br/>|
|**[Maestro 3.6.6](https://github.com/JonasSamuelsson/Maestro)**|128<br/>|144<br/>|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|17<br/>|2299<br/>|
|**[Mef2 6.0.0.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|4978<br/>|7954<br/>|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|27322<br/>|67518<br/>|
|**[Microsoft Extensions DependencyInjection 6.0.0](https://github.com/aspnet/Extensions)**|42<br/>|70<br/>|
|**[Microsoft.VisualStudio.Composition 17.2.41](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|15753<br/>|10223<br/>|
|**[Mugen MVVM Toolkit 6.5.0](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)**|15<br/>|19<br/>|
|**[MvvmCross 8.0.2](https://github.com/MvvmCross/MvvmCross)**|10<br/>|16<br/>|
|**[Ninject 3.3.6](http://ninject.org)**|134240*<br/>|112279*<br/>|
|**[Pure.DI 1.1.55](https://github.com/DevTeam/Pure.DI)**|**0**<br/>|<br/>|
|**[Rezolver 2.1.0](http://rezolver.co.uk)**|20835<br/>|27706<br/>|
|**[SimpleInjector 5.4.1](https://simpleinjector.org)**|825<br/>|3214<br/>|
|**[Singularity 0.18.0](https://github.com/Barsonax/Singularity)**|314<br/>|874<br/>|
|**[Spring.NET 3.0.0](http://www.springframework.net/)**|14198<br/>|14141<br/>|
|**[Stashbox 5.4.3](https://github.com/z4kn4fein/stashbox)**|46<br/>|1929<br/>|
|**[StructureMap 4.7.1](http://structuremap.net/structuremap)**|1325<br/>|7389<br/>|
|**[Unity 5.11.10](https://github.com/unitycontainer/unity)**|122<br/>|287<br/>|
|**[Windsor 5.1.2](http://castleproject.org)**|2993<br/>|3344<br/>|
|**[ZenIoc 1.0.1](https://github.com/zenmvvm/ZenIoc)**|77<br/>|964<br/>|
|**[Zenject 8.0.0](https://github.com/modesttree/Zenject)**|199<br/>|201<br/>|
### Charts
![Basic features](https://raw.githubusercontent.com/danielpalme/IocPerformance/master/docs/img/Overview_Basic_Fast.png)
![Advanced features](https://raw.githubusercontent.com/danielpalme/IocPerformance/master/docs/img/Overview_Advanced_Fast.png)
![Prepare](https://raw.githubusercontent.com/danielpalme/IocPerformance/master/docs/img/Overview_Prepare_Fast.png)
### Machine
The benchmark was executed on the following machine:  
**CPU**: Intel(R) Core(TM) i5-6260U CPU @ 1.80GHz  
**Memory**: 15,89GB
