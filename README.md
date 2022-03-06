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
|**[Autofac 6.3.0](https://github.com/autofac/Autofac)**|744<br/>541|887<br/>637|2463<br/>1539|7421<br/>4568|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|465<br/>270|533<br/>322|1583<br/>906|7403<br/>3712|
|**[Catel 5.12.22](http://www.catelproject.com)**|250<br/>296|3979<br/>4314|8954<br/>9876|25104<br/>23025|
|**[DryIoc 4.8.5](https://github.com/dadhi/DryIoc)**|63<br/>54|73<br/>73|89<br/>100|110<br/>101|
|**[DryIocZero 4.0.0](https://github.com/dadhi/DryIoc)**|110<br/>96|88<br/>89|98<br/>105|220<br/>169|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|95<br/>70|104<br/>86|207<br/>158|685<br/>381|
|**[Grace 7.2.1](https://github.com/ipjohnson/Grace)**|**20**<br/>**31**|39<br/>**55**|52<br/>84|73<br/>83|
|**[Lamar 6.0.0](https://jasperfx.github.io/lamar/)**|51<br/>59|74<br/>79|98<br/>110|108<br/>109|
|**[LightInject 6.4.0](https://github.com/seesharper/LightInject)**|46<br/>47|45<br/>57|88<br/>99|153<br/>143|
|**[Maestro 3.6.6](https://github.com/JonasSamuelsson/Maestro)**|386<br/>269|342<br/>241|580<br/>438|1411<br/>1097|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|22679<br/>11820|37640<br/>25052|57462<br/>68730*|112712*<br/>131716*|
|**[Mef2 5.0.0.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|259<br/>178|252<br/>192|355<br/>263|657<br/>444|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|25<br/>39|34<br/>59|55<br/>**77**|92<br/>89|
|**[Microsoft Extensions DependencyInjection 5.0.2](https://github.com/aspnet/Extensions)**|73<br/>57|99<br/>81|116<br/>109|134<br/>113|
|**[Microsoft.VisualStudio.Composition 16.9.20](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|10657<br/>7328|16329<br/>14386|28141<br/>18099|75101*<br/>66068*|
|**[Mugen MVVM Toolkit 6.5.0](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)**|102<br/>138|409<br/>715|2052<br/>2590|9348<br/>11352|
|**[MvvmCross 8.0.2](https://github.com/MvvmCross/MvvmCross)**|205<br/>251|1318<br/>1402|3316<br/>3726|8677<br/>9516|
|**[Ninject 3.3.4](http://ninject.org)**|3473<br/>2563|8686<br/>6969|23529<br/>17635|63579*<br/>49285|
|**[Pure.DI 1.1.35](https://github.com/DevTeam/Pure.DI)**|28<br/>36|38<br/>58|56<br/>82|71<br/>80|
|**[Rezolver 2.1.0](http://rezolver.co.uk)**|121<br/>100|137<br/>126|194<br/>171|328<br/>238|
|**[SimpleInjector 5.3.2](https://simpleinjector.org)**|56<br/>63|91<br/>77|119<br/>113|127<br/>110|
|**[Singularity 0.18.0](https://github.com/Barsonax/Singularity)**|24<br/>39|39<br/>59|66<br/>82|76<br/>84|
|**[Spring.NET 3.0.0](http://www.springframework.net/)**|553<br/>446|2533<br/>1535|8190<br/>5084|23729<br/>15167|
|**[Stashbox 3.6.4](https://github.com/z4kn4fein/stashbox)**|33<br/>42|57<br/>64|68<br/>96|85<br/>87|
|**[StructureMap 4.7.1](http://structuremap.net/structuremap)**|1121<br/>717|1281<br/>856|3410<br/>2166|8312<br/>6052|
|**[Unity 5.11.10](https://github.com/unitycontainer/unity)**|216<br/>148|1443<br/>835|3326<br/>1995|9503<br/>4739|
|**[Windsor 5.1.1](http://castleproject.org)**|461<br/>333|1839<br/>1127|8062<br/>5972|19313<br/>13001|
|**[ZenIoc 1.0.1](https://github.com/zenmvvm/ZenIoc)**|306<br/>198|267<br/>188|674<br/>440|1809<br/>1103|
|**[Zenject 8.0.0](https://github.com/modesttree/Zenject)**|479<br/>448|1370<br/>1070|3689<br/>3065|11142<br/>10106|
### Advanced Features
|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Asp Net Core**|**Interception With Proxy**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|---------------:|--------------------------:|
|**No**|186<br/>134|70<br/>75|193<br/>176|53<br/>63|644<br/>596|<br/>|469<br/>438|
|**[abioc 0.8.0](https://github.com/JSkimming/abioc)**|<br/>|<br/>|799<br/>506|<br/>|<br/>|<br/>|<br/>|
|**[Autofac 6.3.0](https://github.com/autofac/Autofac)**|7448<br/>4570|2165<br/>1445|8127<br/>5176|1858<br/>1195|75548*<br/>57801|46484<br/>41519|28432<br/>16233|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|9157<br/>4733|<br/>|5965<br/>3393|<br/>|<br/>|<br/>|<br/>|
|**[Catel 5.12.22](http://www.catelproject.com)**|<br/>|8872<br/>9710|<br/>|<br/>|<br/>|<br/>|3937<br/>4257|
|**[DryIoc 4.8.5](https://github.com/dadhi/DryIoc)**|144<br/>131|86<br/>88|294<br/>219|81<br/>79|<br/>|1379<br/>1005|835<br/>555|
|**[DryIocZero 4.0.0](https://github.com/dadhi/DryIoc)**|294<br/>205|92<br/>92|302<br/>229|380<br/>270|<br/>|<br/>|<br/>|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|828<br/>455|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Grace 7.2.1](https://github.com/ipjohnson/Grace)**|101<br/>112|**50**<br/>80|257<br/>210|**45**<br/>70|50375<br/>32231|657<br/>674|827<br/>571|
|**[Lamar 6.0.0](https://jasperfx.github.io/lamar/)**|83<br/>84|90<br/>100|473<br/>366|<br/>|<br/>|4268<br/>3886|<br/>|
|**[LightInject 6.4.0](https://github.com/seesharper/LightInject)**|185<br/>150|61<br/>77|294<br/>239|384<br/>285|<br/>|2268<br/>1643|1548<br/>1062|
|**[Maestro 3.6.6](https://github.com/JonasSamuelsson/Maestro)**|3886<br/>2438|419<br/>318|1272<br/>843|<br/>|<br/>|10764<br/>8560|6757<br/>3630|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|124500*<br/>133833*|137086*<br/>114221*|97231*<br/>100896*|<br/>|<br/>|<br/>|<br/>|
|**[Mef2 5.0.0.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|1431<br/>1012|290<br/>226|1343<br/>895|<br/>|<br/>|<br/>|<br/>|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|**39**<br/>**62**|<br/>|262<br/>195|<br/>|<br/>|<br/>|<br/>|
|**[Microsoft Extensions DependencyInjection 5.0.2](https://github.com/aspnet/Extensions)**|<br/>|114<br/>100|304<br/>234|<br/>|<br/>|3618<br/>2299|<br/>|
|**[Microsoft.VisualStudio.Composition 16.9.20](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|56863<br/>39925|<br/>|69695*<br/>46056|<br/>|<br/>|<br/>|<br/>|
|**[Mugen MVVM Toolkit 6.5.0](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)**|436<br/>705|<br/>|9749<br/>7094|<br/>|**4370**<br/>**3103**|<br/>|<br/>|
|**[MvvmCross 8.0.2](https://github.com/MvvmCross/MvvmCross)**|1310<br/>1415|6576<br/>7299|<br/>|<br/>|4968<br/>3230|<br/>|<br/>|
|**[Ninject 3.3.4](http://ninject.org)**|62765*<br/>47908|24256<br/>15895|64193*<br/>49074|19294<br/>12954|73303000*<br/>50234113*|<br/>|20215<br/>15029|
|**[Pure.DI 1.1.35](https://github.com/DevTeam/Pure.DI)**|42<br/>64|51<br/>**68**|**189**<br/>**152**|46<br/>**67**|<br/>|<br/>|**228**<br/>**208**|
|**[Rezolver 2.1.0](http://rezolver.co.uk)**|520<br/>385|183<br/>145|669<br/>408|<br/>|9589857*<br/>5697265*|86587*<br/>56374|<br/>|
|**[SimpleInjector 5.3.2](https://simpleinjector.org)**|254<br/>187|111<br/>106|586<br/>360|106<br/>90|<br/>|<br/>|5382<br/>3141|
|**[Singularity 0.18.0](https://github.com/Barsonax/Singularity)**|<br/>|54<br/>80|241<br/>193|<br/>|<br/>|**631**<br/>**652**|<br/>|
|**[Spring.NET 3.0.0](http://www.springframework.net/)**|18982<br/>11962|<br/>|<br/>|<br/>|<br/>|<br/>|18461<br/>11065|
|**[Stashbox 3.6.4](https://github.com/z4kn4fein/stashbox)**|112<br/>116|61<br/>79|273<br/>217|60<br/>68|329202*<br/>215002*|1403<br/>1155|809<br/>548|
|**[StructureMap 4.7.1](http://structuremap.net/structuremap)**|8697<br/>5284|2271<br/>1460|8399<br/>5170|<br/>|3215578*<br/>1887211*|65269*<br/>41725|7859<br/>4464|
|**[Unity 5.11.10](https://github.com/unitycontainer/unity)**|9045<br/>5814|9842<br/>6443|17755<br/>12048|3547<br/>2046|147355*<br/>74313*|61350*<br/>39009|56226<br/>31096|
|**[Windsor 5.1.1](http://castleproject.org)**|40830<br/>22225|15542<br/>9318|19361<br/>10763|<br/>|242149*<br/>176823*|<br/>|18018<br/>8775|
|**[ZenIoc 1.0.1](https://github.com/zenmvvm/ZenIoc)**|264<br/>195|276<br/>209|704<br/>488|314<br/>222|602490*<br/>471765*|<br/>|<br/>|
|**[Zenject 8.0.0](https://github.com/modesttree/Zenject)**|15829<br/>13135|9021<br/>6513|17932<br/>12687|3082<br/>2428|22250<br/>18595|<br/>|<br/>|
### Prepare
|**Container**|**Prepare And Register**|**Prepare And Register And Simple Resolve**|
|:------------|-----------------------:|------------------------------------------:|
|**No**|2<br/>|2<br/>|
|**[abioc 0.8.0](https://github.com/JSkimming/abioc)**|6327<br/>|6556<br/>|
|**[Autofac 6.3.0](https://github.com/autofac/Autofac)**|374<br/>|363<br/>|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|55<br/>|56<br/>|
|**[Catel 5.12.22](http://www.catelproject.com)**|11925<br/>|9956<br/>|
|**[DryIoc 4.8.5](https://github.com/dadhi/DryIoc)**|56<br/>|64<br/>|
|**[DryIocZero 4.0.0](https://github.com/dadhi/DryIoc)**|**0**<br/>|**1**<br/>|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|16240<br/>|16527<br/>|
|**[Grace 7.2.1](https://github.com/ipjohnson/Grace)**|157<br/>|966<br/>|
|**[Lamar 6.0.0](https://jasperfx.github.io/lamar/)**|2006<br/>|2437<br/>|
|**[LightInject 6.4.0](https://github.com/seesharper/LightInject)**|131<br/>|1686<br/>|
|**[Maestro 3.6.6](https://github.com/JonasSamuelsson/Maestro)**|128<br/>|144<br/>|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|17<br/>|2299<br/>|
|**[Mef2 5.0.0.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|4715<br/>|6984<br/>|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|27322<br/>|67518<br/>|
|**[Microsoft Extensions DependencyInjection 5.0.2](https://github.com/aspnet/Extensions)**|21<br/>|30<br/>|
|**[Microsoft.VisualStudio.Composition 16.9.20](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|11600<br/>|11473<br/>|
|**[Mugen MVVM Toolkit 6.5.0](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)**|15<br/>|19<br/>|
|**[MvvmCross 8.0.2](https://github.com/MvvmCross/MvvmCross)**|10<br/>|16<br/>|
|**[Ninject 3.3.4](http://ninject.org)**|130706*<br/>|126470*<br/>|
|**[Pure.DI 1.1.35](https://github.com/DevTeam/Pure.DI)**|**0**<br/>|<br/>|
|**[Rezolver 2.1.0](http://rezolver.co.uk)**|20835<br/>|27706<br/>|
|**[SimpleInjector 5.3.2](https://simpleinjector.org)**|639<br/>|3011<br/>|
|**[Singularity 0.18.0](https://github.com/Barsonax/Singularity)**|314<br/>|874<br/>|
|**[Spring.NET 3.0.0](http://www.springframework.net/)**|14198<br/>|14141<br/>|
|**[Stashbox 3.6.4](https://github.com/z4kn4fein/stashbox)**|56<br/>|578<br/>|
|**[StructureMap 4.7.1](http://structuremap.net/structuremap)**|1325<br/>|7389<br/>|
|**[Unity 5.11.10](https://github.com/unitycontainer/unity)**|122<br/>|287<br/>|
|**[Windsor 5.1.1](http://castleproject.org)**|2949<br/>|3445<br/>|
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
