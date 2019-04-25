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
**_*_**: Benchmark was stopped after 1 minute and result is extrapolated.  
### Basic Features
|**Container**|**Singleton**|**Transient**|**Combined**|**Complex**|
|:------------|------------:|------------:|-----------:|----------:|
|**No**|41<br/>49|49<br/>59|69<br/>76|99<br/>103|
|**[abioc 0.7.0](https://github.com/JSkimming/abioc)**|27<br/>**38**|**32**<br/>**54**|**48**<br/>**73**|**64**<br/>**71**|
|**[Autofac 4.9.2](https://github.com/autofac/Autofac)**|549<br/>441|963<br/>603|2315<br/>1165|5779<br/>3431|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|465<br/>270|533<br/>322|1583<br/>906|7403<br/>3712|
|**[Catel 5.10.0](http://www.catelproject.com)**|262<br/>317|4123<br/>4456|9359<br/>10445|21780<br/>25331|
|**[Cauldron.Activator 3.2.3](https://github.com/Capgemini/Cauldron)**|36<br/>51|50<br/>64|86<br/>103|197<br/>152|
|**[DryIoc 4.0.3](https://bitbucket.org/dadhi/dryioc)**|33<br/>47|45<br/>68|63<br/>96|76<br/>79|
|**[DryIocZero 4.0.0](https://bitbucket.org/dadhi/dryioc)**|110<br/>96|88<br/>89|98<br/>105|220<br/>169|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|95<br/>70|104<br/>86|207<br/>158|685<br/>381|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|66<br/>66|126<br/>99|249<br/>171|602<br/>350|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|118<br/>90|137<br/>110|381<br/>251|1124<br/>616|
|**[Grace 6.4.2](https://github.com/ipjohnson/Grace)**|49<br/>45|40<br/>60|65<br/>79|86<br/>97|
|**[Griffin 1.1.9](https://github.com/jgauffin/griffin.container)**|300<br/>205|318<br/>226|719<br/>476|2004<br/>1228|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|40<br/>48|51<br/>62|65<br/>88|103<br/>95|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|75<br/>60|128<br/>97|145<br/>124|197<br/>135|
|**[Lamar 3.0.1](https://jasperfx.github.io/lamar/)**|59<br/>61|71<br/>80|93<br/>125|116<br/>131|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|184<br/>189|2191<br/>1301|26718<br/>31570|151128*<br/>188142*|
|**[LightInject 5.4.0](https://github.com/seesharper/LightInject)**|33<br/>45|45<br/>67|64<br/>89|80<br/>100|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|3167<br/>1709|16506<br/>11878|45492<br/>29568|116514*<br/>76757*|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|356<br/>254|1755<br/>2906|2437<br/>1743|4342<br/>2528|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|22679<br/>11820|37640<br/>25052|57462<br/>68730*|112712*<br/>131716*|
|**[Mef2 1.0.33.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|276<br/>260|341<br/>265|425<br/>374|901<br/>654|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|**25**<br/>39|34<br/>59|55<br/>77|92<br/>89|
|**[MicroSliver 2.1.6](  )**|192<br/>232|742<br/>619|2394<br/>1786|7159<br/>6162|
|**[Microsoft Extensions DependencyInjection 2.2.0](https://github.com/aspnet/DependencyInjection)**|81<br/>69|124<br/>107|148<br/>143|197<br/>159|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|484<br/>444|711<br/>751|2285<br/>2494|8297<br/>9494|
|**[Mugen MVVM Toolkit 6.5.0](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)**|102<br/>138|409<br/>715|2052<br/>2590|9348<br/>11352|
|**[Munq 3.1.6](http://munq.codeplex.com)**|90<br/>75|161<br/>107|517<br/>417|1812<br/>1050|
|**[MvvmCross 6.2.3](https://github.com/MvvmCross/MvvmCross)**|233<br/>291|966<br/>1085|2655<br/>2975|7674<br/>8583|
|**[Ninject 3.3.4](http://ninject.org)**|3473<br/>2563|8686<br/>6969|23529<br/>17635|63579*<br/>49285|
|**[Rezolver 1.4.0](http://rezolver.co.uk)**|176<br/>138|198<br/>161|248<br/>207|342<br/>245|
|**[SimpleInjector 4.5.1](https://simpleinjector.org)**|63<br/>59|70<br/>73|109<br/>111|127<br/>110|
|**[Singularity 0.10.0](https://github.com/Barsonax/Singularity)**|26<br/>42|41<br/>60|58<br/>87|73<br/>82|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|950<br/>987|9711<br/>11447|26941<br/>23873|74745*<br/>57777|
|**[Stashbox 2.7.3](https://github.com/z4kn4fein/stashbox)**|36<br/>48|49<br/>68|64<br/>93|77<br/>79|
|**[StructureMap 4.7.1](http://structuremap.net/structuremap)**|1121<br/>717|1281<br/>856|3410<br/>2166|8312<br/>6052|
|**[Unity 5.8.6](https://github.com/unitycontainer/unity)**|302<br/>281|437<br/>405|1282<br/>1095|3962<br/>3553|
|**[Windsor 5.0.0](http://castleproject.org)**|437<br/>350|1821<br/>1108|6402<br/>3712|20536<br/>11821|
|**[Zenject 8.0.0](https://github.com/modesttree/Zenject)**|479<br/>448|1370<br/>1070|3689<br/>3065|11142<br/>10106|
### Advanced Features
|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Asp Net Core**|**Interception With Proxy**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|---------------:|--------------------------:|
|**No**|186<br/>134|70<br/>75|193<br/>176|53<br/>**63**|644<br/>596|<br/>|469<br/>438|
|**[abioc 0.7.0](https://github.com/JSkimming/abioc)**|<br/>|<br/>|743<br/>453|<br/>|<br/>|<br/>|<br/>|
|**[Autofac 4.9.2](https://github.com/autofac/Autofac)**|6186<br/>3538|2197<br/>1359|7840<br/>4498|1410<br/>867|78796*<br/>47840|12609<br/>8039|22750<br/>13294|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|9157<br/>4733|<br/>|5965<br/>3393|<br/>|<br/>|<br/>|<br/>|
|**[Catel 5.10.0](http://www.catelproject.com)**|<br/>|9350<br/>10275|<br/>|<br/>|<br/>|<br/>|4087<br/>4533|
|**[Cauldron.Activator 3.2.3](https://github.com/Capgemini/Cauldron)**|65<br/>76|80<br/>84|358<br/>256|<br/>|<br/>|<br/>|**54**<br/>**72**|
|**[DryIoc 4.0.3](https://bitbucket.org/dadhi/dryioc)**|117<br/>116|56<br/>81|281<br/>205|**56**<br/>69|<br/>|641<br/>484|835<br/>556|
|**[DryIocZero 4.0.0](https://bitbucket.org/dadhi/dryioc)**|294<br/>205|92<br/>92|302<br/>229|380<br/>270|<br/>|<br/>|<br/>|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|828<br/>455|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|1090<br/>639|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Grace 6.4.2](https://github.com/ipjohnson/Grace)**|127<br/>126|59<br/>**68**|348<br/>298|61<br/>**63**|52454<br/>43244|561<br/>528|1025<br/>845|
|**[Griffin 1.1.9](https://github.com/jgauffin/griffin.container)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|741<br/>443|<br/>|1860<br/>1198|<br/>|<br/>|<br/>|774<br/>509|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|345<br/>227|147<br/>120|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Lamar 3.0.1](https://jasperfx.github.io/lamar/)**|71<br/>82|89<br/>116|527<br/>Error|<br/>|<br/>|595<br/>794|<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|2289<br/>1755|15862<br/>14477|34754<br/>20480|<br/>|<br/>|<br/>|<br/>|
|**[LightInject 5.4.0](https://github.com/seesharper/LightInject)**|115<br/>113|52<br/>81|275<br/>215|311<br/>230|<br/>|4654<br/>2822|1373<br/>962|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|4502<br/>2616|2103<br/>2128|4443<br/>2483|2186<br/>1691|<br/>|<br/>|7591<br/>4418|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|124500*<br/>133833*|137086*<br/>114221*|97231*<br/>100896*|<br/>|<br/>|<br/>|<br/>|
|**[Mef2 1.0.33.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|1525<br/>1272|310<br/>299|1554<br/>1273|<br/>|<br/>|<br/>|<br/>|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|**39**<br/>**62**|<br/>|**262**<br/>**195**|<br/>|<br/>|<br/>|<br/>|
|**[MicroSliver 2.1.6](  )**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Microsoft Extensions DependencyInjection 2.2.0](https://github.com/aspnet/DependencyInjection)**|<br/>|149<br/>130|430<br/>303|<br/>|<br/>|1080<br/>703|<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|10005<br/>8348|72189*<br/>72787*|5619<br/>7027|1824<br/>1883|550418*<br/>335171*|<br/>|13742<br/>16268|
|**[Mugen MVVM Toolkit 6.5.0](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)**|436<br/>705|<br/>|9749<br/>7094|<br/>|**4370**<br/>3103|<br/>|<br/>|
|**[Munq 3.1.6](http://munq.codeplex.com)**|1536<br/>847|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[MvvmCross 6.2.3](https://github.com/MvvmCross/MvvmCross)**|974<br/>1107|6525<br/>8730|<br/>|<br/>|4645<br/>**2945**|<br/>|<br/>|
|**[Ninject 3.3.4](http://ninject.org)**|62765*<br/>47908|24256<br/>15895|64193*<br/>49074|19294<br/>12954|73303000*<br/>50234113*|<br/>|20215<br/>15029|
|**[Rezolver 1.4.0](http://rezolver.co.uk)**|502<br/>338|231<br/>191|10945<br/>5286|<br/>|18076000*<br/>11632170*|27887<br/>16925|<br/>|
|**[SimpleInjector 4.5.1](https://simpleinjector.org)**|237<br/>176|77<br/>89|809<br/>493|73<br/>76|<br/>|<br/>|7231<br/>4253|
|**[Singularity 0.10.0](https://github.com/Barsonax/Singularity)**|<br/>|**49**<br/>83|293<br/>224|<br/>|<br/>|555<br/>**448**|<br/>|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|52419<br/>51992|<br/>|<br/>|<br/>|<br/>|<br/>|43647<br/>43419|
|**[Stashbox 2.7.3](https://github.com/z4kn4fein/stashbox)**|116<br/>117|65<br/>81|294<br/>213|57<br/>70|169556*<br/>100439*|**505**<br/>635|862<br/>581|
|**[StructureMap 4.7.1](http://structuremap.net/structuremap)**|8697<br/>5284|2271<br/>1460|8399<br/>5170|<br/>|3215578*<br/>1887211*|42001<br/>26976|7859<br/>4464|
|**[Unity 5.8.6](https://github.com/unitycontainer/unity)**|4097<br/>3333|1396<br/>1210|4815<br/>4031|1042<br/>861|7035<br/>9942|16895<br/>18546|<br/>|
|**[Windsor 5.0.0](http://castleproject.org)**|38096<br/>19775|15557<br/>9071|17839<br/>10135|<br/>|239286*<br/>140421*|<br/>|13662<br/>7695|
|**[Zenject 8.0.0](https://github.com/modesttree/Zenject)**|15829<br/>13135|9021<br/>6513|17932<br/>12687|3082<br/>2428|22250<br/>18595|<br/>|<br/>|
### Prepare
|**Container**|**Prepare And Register**|**Prepare And Register And Simple Resolve**|
|:------------|-----------------------:|------------------------------------------:|
|**No**|2<br/>|2<br/>|
|**[abioc 0.7.0](https://github.com/JSkimming/abioc)**|5672<br/>|6613<br/>|
|**[Autofac 4.9.2](https://github.com/autofac/Autofac)**|330<br/>|376<br/>|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|55<br/>|56<br/>|
|**[Catel 5.10.0](http://www.catelproject.com)**|10241<br/>|10934<br/>|
|**[Cauldron.Activator 3.2.3](https://github.com/Capgemini/Cauldron)**|**0**<br/>|**0**<br/>|
|**[DryIoc 4.0.3](https://bitbucket.org/dadhi/dryioc)**|61<br/>|66<br/>|
|**[DryIocZero 4.0.0](https://bitbucket.org/dadhi/dryioc)**|**0**<br/>|1<br/>|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|16240<br/>|16527<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|6390<br/>|6336<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|8<br/>|8<br/>|
|**[Grace 6.4.2](https://github.com/ipjohnson/Grace)**|159<br/>|936<br/>|
|**[Griffin 1.1.9](https://github.com/jgauffin/griffin.container)**|8387<br/>|8960<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|54925<br/>|55463<br/>|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|1397<br/>|2016<br/>|
|**[Lamar 3.0.1](https://jasperfx.github.io/lamar/)**|2074<br/>|2367<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|226<br/>|204<br/>|
|**[LightInject 5.4.0](https://github.com/seesharper/LightInject)**|112<br/>|698<br/>|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|107<br/>|338<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|172<br/>|747<br/>|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|17<br/>|2299<br/>|
|**[Mef2 1.0.33.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|6053<br/>|7259<br/>|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|27322<br/>|67518<br/>|
|**[MicroSliver 2.1.6](  )**|12<br/>|17<br/>|
|**[Microsoft Extensions DependencyInjection 2.2.0](https://github.com/aspnet/DependencyInjection)**|22<br/>|30<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|424<br/>|1820<br/>|
|**[Mugen MVVM Toolkit 6.5.0](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)**|15<br/>|19<br/>|
|**[Munq 3.1.6](http://munq.codeplex.com)**|9079<br/>|9500<br/>|
|**[MvvmCross 6.2.3](https://github.com/MvvmCross/MvvmCross)**|10<br/>|15<br/>|
|**[Ninject 3.3.4](http://ninject.org)**|130706*<br/>|126470*<br/>|
|**[Rezolver 1.4.0](http://rezolver.co.uk)**|29424<br/>|39964<br/>|
|**[SimpleInjector 4.5.1](https://simpleinjector.org)**|671<br/>|3099<br/>|
|**[Singularity 0.10.0](https://github.com/Barsonax/Singularity)**|91<br/>|572<br/>|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|25014<br/>|24884<br/>|
|**[Stashbox 2.7.3](https://github.com/z4kn4fein/stashbox)**|65<br/>|243<br/>|
|**[StructureMap 4.7.1](http://structuremap.net/structuremap)**|1325<br/>|7389<br/>|
|**[Unity 5.8.6](https://github.com/unitycontainer/unity)**|84<br/>|79<br/>|
|**[Windsor 5.0.0](http://castleproject.org)**|2954<br/>|2990<br/>|
|**[Zenject 8.0.0](https://github.com/modesttree/Zenject)**|199<br/>|201<br/>|
### Charts
![Basic features](http://www.palmmedia.de/content/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)
![Advanced features](http://www.palmmedia.de/content/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)
![Prepare](http://www.palmmedia.de/content/blogimages/67b056a5-9da8-40b4-9ae6-0c838cdac180.png)
### Machine
The benchmark was executed on the following machine:  
**CPU**: Intel(R) Core(TM) i5-6260U CPU @ 1.80GHz  
**Memory**: 15,89GB
