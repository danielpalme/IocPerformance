# Ioc Performance

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
|**[abioc 0.8.0](https://github.com/JSkimming/abioc)**|26<br/>43|**33**<br/>56|**51**<br/>82|67<br/>78|
|**[Autofac 4.9.3](https://github.com/autofac/Autofac)**|569<br/>382|704<br/>475|1927<br/>1183|5727<br/>3449|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|465<br/>270|533<br/>322|1583<br/>906|7403<br/>3712|
|**[Catel 5.11.0](http://www.catelproject.com)**|252<br/>305|4190<br/>4576|9695<br/>10709|22222<br/>25242|
|**[Cauldron.Activator 3.2.3](https://github.com/Capgemini/Cauldron)**|36<br/>51|50<br/>64|86<br/>103|197<br/>152|
|**[DryIoc 4.0.5](https://bitbucket.org/dadhi/dryioc)**|33<br/>47|48<br/>76|68<br/>103|79<br/>89|
|**[DryIocZero 4.0.0](https://bitbucket.org/dadhi/dryioc)**|110<br/>96|88<br/>89|98<br/>105|220<br/>169|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|95<br/>70|104<br/>86|207<br/>158|685<br/>381|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|66<br/>66|126<br/>99|249<br/>171|602<br/>350|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|118<br/>90|137<br/>110|381<br/>251|1124<br/>616|
|**[Grace 7.0.0](https://github.com/ipjohnson/Grace)**|**25**<br/>45|35<br/>**55**|54<br/>87|68<br/>79|
|**[Griffin 1.1.9](https://github.com/jgauffin/griffin.container)**|300<br/>205|318<br/>226|719<br/>476|2004<br/>1228|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|40<br/>48|51<br/>62|65<br/>88|103<br/>95|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|75<br/>60|128<br/>97|145<br/>124|197<br/>135|
|**[Lamar 3.0.4](https://jasperfx.github.io/lamar/)**|56<br/>61|71<br/>73|93<br/>127|113<br/>127|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|184<br/>189|2191<br/>1301|26718<br/>31570|151128*<br/>188142*|
|**[LightInject 5.5.0](https://github.com/seesharper/LightInject)**|29<br/>49|36<br/>60|54<br/>86|75<br/>82|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|3167<br/>1709|16506<br/>11878|45492<br/>29568|116514*<br/>76757*|
|**[Maestro 3.6.0](https://github.com/JonasSamuelsson/Maestro)**|329<br/>229|304<br/>215|543<br/>387|1483<br/>962|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|22679<br/>11820|37640<br/>25052|57462<br/>68730*|112712*<br/>131716*|
|**[Mef2 1.0.33.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|276<br/>260|341<br/>265|425<br/>374|901<br/>654|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|**25**<br/>**39**|34<br/>59|55<br/>**77**|92<br/>89|
|**[MicroSliver 2.1.6](  )**|192<br/>232|742<br/>619|2394<br/>1786|7159<br/>6162|
|**[Microsoft Extensions DependencyInjection 2.2.0](https://github.com/aspnet/Extensions)**|81<br/>69|124<br/>107|148<br/>143|197<br/>159|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|484<br/>444|711<br/>751|2285<br/>2494|8297<br/>9494|
|**[Mugen MVVM Toolkit 6.5.0](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)**|102<br/>138|409<br/>715|2052<br/>2590|9348<br/>11352|
|**[Munq 3.1.6](http://munq.codeplex.com)**|90<br/>75|161<br/>107|517<br/>417|1812<br/>1050|
|**[MvvmCross 6.3.1](https://github.com/MvvmCross/MvvmCross)**|240<br/>283|996<br/>1123|2627<br/>2889|7351<br/>8498|
|**[Ninject 3.3.4](http://ninject.org)**|3473<br/>2563|8686<br/>6969|23529<br/>17635|63579*<br/>49285|
|**[Rezolver 2.0.0](http://rezolver.co.uk)**|91<br/>98|120<br/>93|174<br/>147|303<br/>231|
|**[SimpleInjector 4.6.2](https://simpleinjector.org)**|59<br/>67|76<br/>75|99<br/>110|119<br/>101|
|**[Singularity 0.13.0](https://github.com/Barsonax/Singularity)**|32<br/>44|37<br/>57|52<br/>83|**66**<br/>**77**|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|950<br/>987|9711<br/>11447|26941<br/>23873|74745*<br/>57777|
|**[Stashbox 2.7.8](https://github.com/z4kn4fein/stashbox)**|34<br/>47|46<br/>68|61<br/>86|77<br/>83|
|**[StructureMap 4.7.1](http://structuremap.net/structuremap)**|1121<br/>717|1281<br/>856|3410<br/>2166|8312<br/>6052|
|**[Unity 5.8.6](https://github.com/unitycontainer/unity)**|302<br/>281|437<br/>405|1282<br/>1095|3962<br/>3553|
|**[Windsor 5.0.0](http://castleproject.org)**|437<br/>350|1821<br/>1108|6402<br/>3712|20536<br/>11821|
|**[Zenject 8.0.0](https://github.com/modesttree/Zenject)**|479<br/>448|1370<br/>1070|3689<br/>3065|11142<br/>10106|
### Advanced Features
|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Asp Net Core**|**Interception With Proxy**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|---------------:|--------------------------:|
|**No**|186<br/>134|70<br/>75|193<br/>176|53<br/>63|644<br/>596|<br/>|469<br/>438|
|**[abioc 0.8.0](https://github.com/JSkimming/abioc)**|<br/>|<br/>|799<br/>506|<br/>|<br/>|<br/>|<br/>|
|**[Autofac 4.9.3](https://github.com/autofac/Autofac)**|5853<br/>3461|2104<br/>1286|8141<br/>5264|1396<br/>870|75656*<br/>45789|32221<br/>19866|21376<br/>12564|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|9157<br/>4733|<br/>|5965<br/>3393|<br/>|<br/>|<br/>|<br/>|
|**[Catel 5.11.0](http://www.catelproject.com)**|<br/>|9399<br/>10388|<br/>|<br/>|<br/>|<br/>|4180<br/>4518|
|**[Cauldron.Activator 3.2.3](https://github.com/Capgemini/Cauldron)**|65<br/>76|80<br/>84|358<br/>256|<br/>|<br/>|<br/>|**54**<br/>**72**|
|**[DryIoc 4.0.5](https://bitbucket.org/dadhi/dryioc)**|122<br/>121|58<br/>87|316<br/>218|56<br/>74|<br/>|1867<br/>1394|836<br/>545|
|**[DryIocZero 4.0.0](https://bitbucket.org/dadhi/dryioc)**|294<br/>205|92<br/>92|302<br/>229|380<br/>270|<br/>|<br/>|<br/>|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|828<br/>455|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|1090<br/>639|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Grace 7.0.0](https://github.com/ipjohnson/Grace)**|110<br/>109|50<br/>**80**|266<br/>201|**47**<br/>**69**|52706<br/>30542|786<br/>750|902<br/>602|
|**[Griffin 1.1.9](https://github.com/jgauffin/griffin.container)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|741<br/>443|<br/>|1860<br/>1198|<br/>|<br/>|<br/>|774<br/>509|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|345<br/>227|147<br/>120|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Lamar 3.0.4](https://jasperfx.github.io/lamar/)**|75<br/>80|90<br/>120|499<br/>Error|<br/>|<br/>|1603<br/>1470|<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|2289<br/>1755|15862<br/>14477|34754<br/>20480|<br/>|<br/>|<br/>|<br/>|
|**[LightInject 5.5.0](https://github.com/seesharper/LightInject)**|122<br/>141|52<br/>81|296<br/>225|331<br/>227|<br/>|14895<br/>9956|1492<br/>927|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Maestro 3.6.0](https://github.com/JonasSamuelsson/Maestro)**|3402<br/>2335|514<br/>294|1598<br/>1079|<br/>|<br/>|9639<br/>7096|10385<br/>3878|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|124500*<br/>133833*|137086*<br/>114221*|97231*<br/>100896*|<br/>|<br/>|<br/>|<br/>|
|**[Mef2 1.0.33.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|1525<br/>1272|310<br/>299|1554<br/>1273|<br/>|<br/>|<br/>|<br/>|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|**39**<br/>**62**|<br/>|**262**<br/>**195**|<br/>|<br/>|<br/>|<br/>|
|**[MicroSliver 2.1.6](  )**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Microsoft Extensions DependencyInjection 2.2.0](https://github.com/aspnet/Extensions)**|<br/>|149<br/>130|430<br/>303|<br/>|<br/>|2852<br/>1840|<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|10005<br/>8348|72189*<br/>72787*|5619<br/>7027|1824<br/>1883|550418*<br/>335171*|<br/>|13742<br/>16268|
|**[Mugen MVVM Toolkit 6.5.0](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)**|436<br/>705|<br/>|9749<br/>7094|<br/>|4370<br/>3103|<br/>|<br/>|
|**[Munq 3.1.6](http://munq.codeplex.com)**|1536<br/>847|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[MvvmCross 6.3.1](https://github.com/MvvmCross/MvvmCross)**|1236<br/>1343|6518<br/>6917|<br/>|<br/>|**4151**<br/>**2704**|<br/>|<br/>|
|**[Ninject 3.3.4](http://ninject.org)**|62765*<br/>47908|24256<br/>15895|64193*<br/>49074|19294<br/>12954|73303000*<br/>50234113*|<br/>|20215<br/>15029|
|**[Rezolver 2.0.0](http://rezolver.co.uk)**|454<br/>360|139<br/>156|490<br/>354|<br/>|6570200*<br/>4095208*|59211<br/>33867|<br/>|
|**[SimpleInjector 4.6.2](https://simpleinjector.org)**|243<br/>181|80<br/>92|842<br/>508|82<br/>80|<br/>|<br/>|8282<br/>4409|
|**[Singularity 0.13.0](https://github.com/Barsonax/Singularity)**|<br/>|**49**<br/>83|287<br/>214|<br/>|<br/>|**530**<br/>**560**|<br/>|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|52419<br/>51992|<br/>|<br/>|<br/>|<br/>|<br/>|43647<br/>43419|
|**[Stashbox 2.7.8](https://github.com/z4kn4fein/stashbox)**|125<br/>119|58<br/>83|304<br/>222|59<br/>**69**|174697*<br/>99904*|1647<br/>1429|832<br/>554|
|**[StructureMap 4.7.1](http://structuremap.net/structuremap)**|8697<br/>5284|2271<br/>1460|8399<br/>5170|<br/>|3215578*<br/>1887211*|65269*<br/>41725|7859<br/>4464|
|**[Unity 5.8.6](https://github.com/unitycontainer/unity)**|4097<br/>3333|1396<br/>1210|4815<br/>4031|1042<br/>861|7035<br/>9942|38392<br/>31255|<br/>|
|**[Windsor 5.0.0](http://castleproject.org)**|38096<br/>19775|15557<br/>9071|17839<br/>10135|<br/>|239286*<br/>140421*|<br/>|13662<br/>7695|
|**[Zenject 8.0.0](https://github.com/modesttree/Zenject)**|15829<br/>13135|9021<br/>6513|17932<br/>12687|3082<br/>2428|22250<br/>18595|<br/>|<br/>|
### Prepare
|**Container**|**Prepare And Register**|**Prepare And Register And Simple Resolve**|
|:------------|-----------------------:|------------------------------------------:|
|**No**|2<br/>|2<br/>|
|**[abioc 0.8.0](https://github.com/JSkimming/abioc)**|6327<br/>|6556<br/>|
|**[Autofac 4.9.3](https://github.com/autofac/Autofac)**|414<br/>|470<br/>|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|55<br/>|56<br/>|
|**[Catel 5.11.0](http://www.catelproject.com)**|90538*<br/>|88375*<br/>|
|**[Cauldron.Activator 3.2.3](https://github.com/Capgemini/Cauldron)**|**0**<br/>|**0**<br/>|
|**[DryIoc 4.0.5](https://bitbucket.org/dadhi/dryioc)**|73<br/>|79<br/>|
|**[DryIocZero 4.0.0](https://bitbucket.org/dadhi/dryioc)**|**0**<br/>|1<br/>|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|16240<br/>|16527<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|6390<br/>|6336<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|8<br/>|8<br/>|
|**[Grace 7.0.0](https://github.com/ipjohnson/Grace)**|171<br/>|942<br/>|
|**[Griffin 1.1.9](https://github.com/jgauffin/griffin.container)**|8387<br/>|8960<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|54925<br/>|55463<br/>|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|1397<br/>|2016<br/>|
|**[Lamar 3.0.4](https://jasperfx.github.io/lamar/)**|2019<br/>|2320<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|226<br/>|204<br/>|
|**[LightInject 5.5.0](https://github.com/seesharper/LightInject)**|115<br/>|774<br/>|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|107<br/>|338<br/>|
|**[Maestro 3.6.0](https://github.com/JonasSamuelsson/Maestro)**|145<br/>|157<br/>|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|17<br/>|2299<br/>|
|**[Mef2 1.0.33.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|6053<br/>|7259<br/>|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|27322<br/>|67518<br/>|
|**[MicroSliver 2.1.6](  )**|12<br/>|17<br/>|
|**[Microsoft Extensions DependencyInjection 2.2.0](https://github.com/aspnet/Extensions)**|22<br/>|30<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|424<br/>|1820<br/>|
|**[Mugen MVVM Toolkit 6.5.0](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)**|15<br/>|19<br/>|
|**[Munq 3.1.6](http://munq.codeplex.com)**|9079<br/>|9500<br/>|
|**[MvvmCross 6.3.1](https://github.com/MvvmCross/MvvmCross)**|10<br/>|13<br/>|
|**[Ninject 3.3.4](http://ninject.org)**|130706*<br/>|126470*<br/>|
|**[Rezolver 2.0.0](http://rezolver.co.uk)**|12625<br/>|18413<br/>|
|**[SimpleInjector 4.6.2](https://simpleinjector.org)**|667<br/>|3205<br/>|
|**[Singularity 0.13.0](https://github.com/Barsonax/Singularity)**|30<br/>|439<br/>|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|25014<br/>|24884<br/>|
|**[Stashbox 2.7.8](https://github.com/z4kn4fein/stashbox)**|70<br/>|256<br/>|
|**[StructureMap 4.7.1](http://structuremap.net/structuremap)**|1325<br/>|7389<br/>|
|**[Unity 5.8.6](https://github.com/unitycontainer/unity)**|84<br/>|79<br/>|
|**[Windsor 5.0.0](http://castleproject.org)**|2954<br/>|2990<br/>|
|**[Zenject 8.0.0](https://github.com/modesttree/Zenject)**|199<br/>|201<br/>|
### Charts
![Basic features](https://www.palmmedia.de/content/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)
![Advanced features](https://www.palmmedia.de/content/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)
![Prepare](https://www.palmmedia.de/content/blogimages/67b056a5-9da8-40b4-9ae6-0c838cdac180.png)
### Machine
The benchmark was executed on the following machine:  
**CPU**: Intel(R) Core(TM) i5-6260U CPU @ 1.80GHz  
**Memory**: 15,89GB
