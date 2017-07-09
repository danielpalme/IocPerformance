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
|**No**|61<br/>53|68<br/>62|83<br/>103|90<br/>82|
|**[abioc 0.6.0](https://github.com/JSkimming/abioc)**|**27**<br/>**37**|**31**<br/>**57**|**48**<br/>84|63<br/>72|
|**[Autofac 4.6.0](https://github.com/autofac/Autofac)**|749<br/>623|707<br/>554|1950<br/>1832|6510<br/>6472|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|465<br/>270|533<br/>322|1583<br/>906|7403<br/>3712|
|**[Catel 4.5.4](http://www.catelproject.com)**|309<br/>356|4119<br/>4510|10048<br/>11082|24815<br/>26422|
|**[DryIoc 2.10.4](https://bitbucket.org/dadhi/dryioc)**|29<br/>42|38<br/>63|55<br/>**80**|**62**<br/>**70**|
|**[DryIocZero 2.7.0](https://bitbucket.org/dadhi/dryioc)**|91<br/>75|75<br/>74|107<br/>110|338<br/>231|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|83<br/>81|92<br/>96|201<br/>153|655<br/>384|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|66<br/>66|126<br/>99|249<br/>171|602<br/>350|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|118<br/>90|137<br/>110|381<br/>251|1124<br/>616|
|**[Grace 6.2.1](https://github.com/ipjohnson/Grace)**|**27**<br/>38|35<br/>58|49<br/>82|67<br/>75|
|**[Griffin 1.1.4](https://github.com/jgauffin/griffin.container)**|280<br/>182|304<br/>203|657<br/>431|1888<br/>1114|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|40<br/>48|51<br/>62|65<br/>88|103<br/>95|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|75<br/>60|128<br/>97|145<br/>124|197<br/>135|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|184<br/>189|2191<br/>1301|26718<br/>31570|151128*<br/>188142*|
|**[LightInject 5.0.3](https://github.com/seesharper/LightInject)**|28<br/>41|36<br/>61|56<br/>81|68<br/>83|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|3167<br/>1709|16506<br/>11878|45492<br/>29568|116514*<br/>76757*|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|356<br/>254|1755<br/>2906|2437<br/>1743|4342<br/>2528|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|22679<br/>11820|37640<br/>25052|57462<br/>68730*|112712*<br/>131716*|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|239<br/>167|254<br/>174|332<br/>256|528<br/>317|
|**[MicroResolver 2.1.0](https://github.com/neuecc/MicroResolver)**|51<br/>56|62<br/>67|81<br/>90|113<br/>98|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|193<br/>235|725<br/>611|2394<br/>1613|6829<br/>5881|
|**[Microsoft Extensions DependencyInjection 1.1.1](https://github.com/aspnet/DependencyInjection)**|207<br/>268|167<br/>141|463<br/>452|1608<br/>1668|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|484<br/>444|711<br/>751|2285<br/>2494|8297<br/>9494|
|**[Munq 3.1.6](http://munq.codeplex.com)**|90<br/>75|161<br/>107|517<br/>417|1812<br/>1050|
|**[Ninject 3.2.2.0](http://ninject.org)**|5192<br/>3216|16735<br/>11856|44930<br/>30318|131301*<br/>84559*|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|3856<br/>2093|3931<br/>2293|4330<br/>2283|5198<br/>2766|
|**[Rezolver 1.2.7050.900](http://rezolver.co.uk)**|135<br/>104|176<br/>135|227<br/>177|367<br/>238|
|**[SimpleInjector 4.0.8](https://simpleinjector.org)**|66<br/>68|77<br/>70|103<br/>103|129<br/>105|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|950<br/>987|9711<br/>11447|26941<br/>23873|74745*<br/>57777|
|**[Stashbox 2.5.3](https://github.com/z4kn4fein/stashbox)**|40<br/>52|48<br/>**57**|62<br/>87|81<br/>81|
|**[StructureMap 4.5.1](http://structuremap.net/structuremap)**|1182<br/>961|1259<br/>810|3477<br/>2015|8655<br/>4900|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|441<br/>263|480<br/>299|748<br/>437|1409<br/>795|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|420<br/>473|1683<br/>1081|7344<br/>5164|32219<br/>23617|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|2517<br/>1375|3761<br/>1962|10161<br/>5372|27963<br/>16013|
### Advanced Features
|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Asp Net Core**|**Interception With Proxy**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|---------------:|--------------------------:|
|**No**|119<br/>99|73<br/>79|177<br/>139|78<br/>69|606<br/>361|<br/>|72<br/>65|
|**[abioc 0.6.0](https://github.com/JSkimming/abioc)**|<br/>|<br/>|741<br/>506|<br/>|<br/>|<br/>|<br/>|
|**[Autofac 4.6.0](https://github.com/autofac/Autofac)**|6527<br/>6417|1949<br/>1563|7715<br/>5635|1453<br/>1406|51226<br/>31640|14292<br/>11982|22099<br/>11690|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|9157<br/>4733|<br/>|5965<br/>3393|<br/>|<br/>|<br/>|<br/>|
|**[Catel 4.5.4](http://www.catelproject.com)**|<br/>|10636<br/>11485|<br/>|<br/>|<br/>|<br/>|4354<br/>4492|
|**[DryIoc 2.10.4](https://bitbucket.org/dadhi/dryioc)**|82<br/>92|50<br/>84|**259**<br/>**184**|56<br/>66|<br/>|<br/>|**766**<br/>**502**|
|**[DryIocZero 2.7.0](https://bitbucket.org/dadhi/dryioc)**|394<br/>256|<br/>|319<br/>214|58<br/>**62**|<br/>|<br/>|<br/>|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|796<br/>467|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|1090<br/>639|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Grace 6.2.1](https://github.com/ipjohnson/Grace)**|87<br/>94|**46**<br/>77|265<br/>194|**55**<br/>64|52698<br/>29078|**490**<br/>**390**|847<br/>526|
|**[Griffin 1.1.4](https://github.com/jgauffin/griffin.container)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|741<br/>443|<br/>|1860<br/>1198|<br/>|<br/>|<br/>|774<br/>509|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|345<br/>227|147<br/>120|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|2289<br/>1755|15862<br/>14477|34754<br/>20480|<br/>|<br/>|<br/>|<br/>|
|**[LightInject 5.0.3](https://github.com/seesharper/LightInject)**|107<br/>93|47<br/>207|263<br/>245|375<br/>299|<br/>|2276<br/>1616|1346<br/>788|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|4502<br/>2616|2103<br/>2128|4443<br/>2483|2186<br/>1691|<br/>|<br/>|7591<br/>4418|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|124500*<br/>133833*|137086*<br/>114221*|97231*<br/>100896*|<br/>|<br/>|<br/>|<br/>|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|1188<br/>680|261<br/>429|1345<br/>758|<br/>|<br/>|<br/>|<br/>|
|**[MicroResolver 2.1.0](https://github.com/neuecc/MicroResolver)**|**73**<br/>**71**|<br/>|305<br/>208|<br/>|<br/>|<br/>|<br/>|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Microsoft Extensions DependencyInjection 1.1.1](https://github.com/aspnet/DependencyInjection)**|<br/>|226<br/>169|876<br/>521|<br/>|<br/>|1888<br/>1812|<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|10005<br/>8348|72189*<br/>72787*|5619<br/>7027|1824<br/>1883|550418*<br/>335171*|<br/>|13742<br/>16268|
|**[Munq 3.1.6](http://munq.codeplex.com)**|1536<br/>847|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Ninject 3.2.2.0](http://ninject.org)**|112654*<br/>76631*|48775<br/>27198|102856*<br/>68908*|34283<br/>22799|46654500*<br/>41128767*|<br/>|24945<br/>15694|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|6684<br/>3636|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Rezolver 1.2.7050.900](http://rezolver.co.uk)**|500<br/>317|218<br/>161|588<br/>364|<br/>|3143050*<br/>1677185*|10298<br/>7844|<br/>|
|**[SimpleInjector 4.0.8](https://simpleinjector.org)**|212<br/>146|75<br/>82|795<br/>451|103<br/>86|<br/>|<br/>|7060<br/>4967|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|52419<br/>51992|<br/>|<br/>|<br/>|<br/>|<br/>|43647<br/>43419|
|**[Stashbox 2.5.3](https://github.com/z4kn4fein/stashbox)**|106<br/>105|62<br/>**75**|301<br/>208|65<br/>71|208124*<br/>117082*|732<br/>537|894<br/>551|
|**[StructureMap 4.5.1](http://structuremap.net/structuremap)**|8737<br/>4902|2309<br/>1434|8706<br/>5081|<br/>|3276473*<br/>1793537*|44294<br/>26216|7746<br/>4276|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|1542<br/>914|1234<br/>708|3067<br/>2022|1432<br/>745|<br/>|<br/>|<br/>|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|5676<br/>5769|<br/>|<br/>|<br/>|**14183**<br/>**7663**|<br/>|<br/>|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|29064<br/>16150|<br/>|43685<br/>23347|<br/>|33727<br/>19896|<br/>|93122*<br/>49665|
### Prepare
|**Container**|**Prepare And Register**|**Prepare And Register And Simple Resolve**|
|:------------|-----------------------:|------------------------------------------:|
|**No**|2<br/>|3<br/>|
|**[abioc 0.6.0](https://github.com/JSkimming/abioc)**|5739<br/>|5992<br/>|
|**[Autofac 4.6.0](https://github.com/autofac/Autofac)**|287<br/>|310<br/>|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|55<br/>|56<br/>|
|**[Catel 4.5.4](http://www.catelproject.com)**|7844<br/>|8192<br/>|
|**[DryIoc 2.10.4](https://bitbucket.org/dadhi/dryioc)**|78<br/>|252<br/>|
|**[DryIocZero 2.7.0](https://bitbucket.org/dadhi/dryioc)**|**0**<br/>|**1**<br/>|
|**[Dynamo 3.0.2.0](http://martinf.github.io/Dynamo.IoC)**|15818<br/>|15809<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|6390<br/>|6336<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|8<br/>|8<br/>|
|**[Grace 6.2.1](https://github.com/ipjohnson/Grace)**|145<br/>|829<br/>|
|**[Griffin 1.1.4](https://github.com/jgauffin/griffin.container)**|8442<br/>|7933<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|54925<br/>|55463<br/>|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|1397<br/>|2016<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|226<br/>|204<br/>|
|**[LightInject 5.0.3](https://github.com/seesharper/LightInject)**|148<br/>|647<br/>|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|107<br/>|338<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|172<br/>|747<br/>|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|17<br/>|2299<br/>|
|**[Mef2 1.0.30.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|5585<br/>|7329<br/>|
|**[MicroResolver 2.1.0](https://github.com/neuecc/MicroResolver)**|29915<br/>|71033<br/>|
|**[MicroSliver 2.1.6.0](https://microsliver.codeplex.com)**|11<br/>|16<br/>|
|**[Microsoft Extensions DependencyInjection 1.1.1](https://github.com/aspnet/DependencyInjection)**|26<br/>|38<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|424<br/>|1820<br/>|
|**[Munq 3.1.6](http://munq.codeplex.com)**|9079<br/>|9500<br/>|
|**[Ninject 3.2.2.0](http://ninject.org)**|97125*<br/>|86107*<br/>|
|**[Petite 0.3.2](https://github.com/andlju/Petite)**|22<br/>|41<br/>|
|**[Rezolver 1.2.7050.900](http://rezolver.co.uk)**|221<br/>|3286<br/>|
|**[SimpleInjector 4.0.8](https://simpleinjector.org)**|651<br/>|3339<br/>|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|25014<br/>|24884<br/>|
|**[Stashbox 2.5.3](https://github.com/z4kn4fein/stashbox)**|73<br/>|574<br/>|
|**[StructureMap 4.5.1](http://structuremap.net/structuremap)**|1383<br/>|7609<br/>|
|**[StyleMVVM 3.1.5](https://stylemvvm.codeplex.com)**|69968<br/>|71562<br/>|
|**[TinyIoC 1.3](https://github.com/grumpydev/TinyIoC)**|58<br/>|67<br/>|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|588<br/>|2209<br/>|
### Charts
![Basic features](http://www.palmmedia.de/content/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)
![Advanced features](http://www.palmmedia.de/content/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)
![Prepare](http://www.palmmedia.de/content/blogimages/67b056a5-9da8-40b4-9ae6-0c838cdac180.png)
### Machine
The benchmark was executed on the following machine:  
**CPU**: Intel(R) Core(TM) i5-6260U CPU @ 1.80GHz  
**Memory**: 15,89GB
