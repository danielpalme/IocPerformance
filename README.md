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
|**[abioc 0.7.0](https://github.com/JSkimming/abioc)**|27<br/>**38**|**32**<br/>**54**|**48**<br/>**73**|**64**<br/>**71**|
|**[Autofac 4.7.0](https://github.com/autofac/Autofac)**|913<br/>775|830<br/>667|2015<br/>1961|6843<br/>6765|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|465<br/>270|533<br/>322|1583<br/>906|7403<br/>3712|
|**[Catel 5.3.0](http://www.catelproject.com)**|297<br/>349|4064<br/>4492|9501<br/>11353|22008<br/>24941|
|**[DryIoc 3.0.0-preview-11](https://bitbucket.org/dadhi/dryioc)**|32<br/>48|43<br/>66|56<br/>89|72<br/>83|
|**[DryIocZero 4.0.0-preview-15](https://bitbucket.org/dadhi/dryioc)**|110<br/>99|90<br/>94|96<br/>110|219<br/>170|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|95<br/>70|104<br/>86|207<br/>158|685<br/>381|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|66<br/>66|126<br/>99|249<br/>171|602<br/>350|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|118<br/>90|137<br/>110|381<br/>251|1124<br/>616|
|**[Grace 6.3.3](https://github.com/ipjohnson/Grace)**|27<br/>46|34<br/>60|55<br/>84|74<br/>80|
|**[Griffin 1.1.9](https://github.com/jgauffin/griffin.container)**|300<br/>205|318<br/>226|719<br/>476|2004<br/>1228|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|40<br/>48|51<br/>62|65<br/>88|103<br/>95|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|75<br/>60|128<br/>97|145<br/>124|197<br/>135|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|184<br/>189|2191<br/>1301|26718<br/>31570|151128*<br/>188142*|
|**[LightInject 5.1.2](https://github.com/seesharper/LightInject)**|28<br/>45|36<br/>62|54<br/>82|72<br/>81|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|3167<br/>1709|16506<br/>11878|45492<br/>29568|116514*<br/>76757*|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|356<br/>254|1755<br/>2906|2437<br/>1743|4342<br/>2528|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|22679<br/>11820|37640<br/>25052|57462<br/>68730*|112712*<br/>131716*|
|**[Mef2 1.0.32.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|309<br/>217|267<br/>174|363<br/>241|693<br/>411|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|**25**<br/>39|34<br/>59|55<br/>77|92<br/>89|
|**[MicroSliver 2.1.6](  )**|192<br/>232|742<br/>619|2394<br/>1786|7159<br/>6162|
|**[Microsoft Extensions DependencyInjection 2.0.0](https://github.com/aspnet/DependencyInjection)**|198<br/>223|112<br/>92|301<br/>319|1121<br/>1176|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|484<br/>444|711<br/>751|2285<br/>2494|8297<br/>9494|
|**[Munq 3.1.6](http://munq.codeplex.com)**|90<br/>75|161<br/>107|517<br/>417|1812<br/>1050|
|**[Ninject 3.3.4](http://ninject.org)**|3473<br/>2563|8686<br/>6969|23529<br/>17635|63579*<br/>49285|
|**[Rezolver 1.3.2](http://rezolver.co.uk)**|156<br/>121|170<br/>140|239<br/>194|372<br/>254|
|**[SimpleInjector 4.1.1](https://simpleinjector.org)**|56<br/>68|85<br/>80|106<br/>110|140<br/>121|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|950<br/>987|9711<br/>11447|26941<br/>23873|74745*<br/>57777|
|**[Stashbox 2.5.9](https://github.com/z4kn4fein/stashbox)**|30<br/>48|40<br/>61|57<br/>89|70<br/>79|
|**[StructureMap 4.6.1](http://structuremap.net/structuremap)**|1169<br/>739|1367<br/>922|3741<br/>2261|9203<br/>5407|
|**[Unity 5.8.5](https://github.com/unitycontainer/unity)**|335<br/>282|568<br/>363|1462<br/>887|3542<br/>1939|
|**[Windsor 4.1.0](http://castleproject.org)**|459<br/>289|1772<br/>1050|6018<br/>3601|19319<br/>10972|
### Advanced Features
|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Asp Net Core**|**Interception With Proxy**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|---------------:|--------------------------:|
|**No**|119<br/>99|73<br/>79|177<br/>139|78<br/>**69**|606<br/>361|<br/>|72<br/>65|
|**[abioc 0.7.0](https://github.com/JSkimming/abioc)**|<br/>|<br/>|743<br/>453|<br/>|<br/>|<br/>|<br/>|
|**[Autofac 4.7.0](https://github.com/autofac/Autofac)**|6220<br/>6330|1942<br/>1714|7533<br/>5490|1396<br/>1308|53831<br/>33308|14518<br/>12562|20946<br/>12245|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|9157<br/>4733|<br/>|5965<br/>3393|<br/>|<br/>|<br/>|<br/>|
|**[Catel 5.3.0](http://www.catelproject.com)**|<br/>|9165<br/>10729|<br/>|<br/>|<br/>|<br/>|4106<br/>4490|
|**[DryIoc 3.0.0-preview-11](https://bitbucket.org/dadhi/dryioc)**|110<br/>111|53<br/>80|280<br/>215|60<br/>74|<br/>|1011<br/>680|848<br/>532|
|**[DryIocZero 4.0.0-preview-15](https://bitbucket.org/dadhi/dryioc)**|286<br/>200|87<br/>91|307<br/>281|403<br/>278|<br/>|<br/>|<br/>|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|828<br/>455|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|1090<br/>639|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Grace 6.3.3](https://github.com/ipjohnson/Grace)**|87<br/>127|**49**<br/>79|381<br/>220|61<br/>72|50713<br/>30097|**483**<br/>**413**|856<br/>536|
|**[Griffin 1.1.9](https://github.com/jgauffin/griffin.container)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|741<br/>443|<br/>|1860<br/>1198|<br/>|<br/>|<br/>|**774**<br/>**509**|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|345<br/>227|147<br/>120|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|2289<br/>1755|15862<br/>14477|34754<br/>20480|<br/>|<br/>|<br/>|<br/>|
|**[LightInject 5.1.2](https://github.com/seesharper/LightInject)**|96<br/>104|51<br/>82|285<br/>211|351<br/>245|<br/>|2416<br/>1965|1480<br/>877|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|4502<br/>2616|2103<br/>2128|4443<br/>2483|2186<br/>1691|<br/>|<br/>|7591<br/>4418|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|124500*<br/>133833*|137086*<br/>114221*|97231*<br/>100896*|<br/>|<br/>|<br/>|<br/>|
|**[Mef2 1.0.32.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|1408<br/>819|309<br/>213|1425<br/>811|<br/>|<br/>|<br/>|<br/>|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|**39**<br/>**62**|<br/>|**262**<br/>**195**|<br/>|<br/>|<br/>|<br/>|
|**[MicroSliver 2.1.6](  )**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Microsoft Extensions DependencyInjection 2.0.0](https://github.com/aspnet/DependencyInjection)**|<br/>|125<br/>108|402<br/>265|<br/>|<br/>|1931<br/>1614|<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|10005<br/>8348|72189*<br/>72787*|5619<br/>7027|1824<br/>1883|550418*<br/>335171*|<br/>|13742<br/>16268|
|**[Munq 3.1.6](http://munq.codeplex.com)**|1536<br/>847|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Ninject 3.3.4](http://ninject.org)**|62765*<br/>47908|24256<br/>15895|64193*<br/>49074|19294<br/>12954|73303000*<br/>50234113*|<br/>|20215<br/>15029|
|**[Rezolver 1.3.2](http://rezolver.co.uk)**|498<br/>371|208<br/>174|8989<br/>5058|<br/>|7517375*<br/>4298495*|8634<br/>6885|<br/>|
|**[SimpleInjector 4.1.1](https://simpleinjector.org)**|208<br/>156|93<br/>96|758<br/>466|88<br/>86|<br/>|<br/>|7332<br/>4268|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|52419<br/>51992|<br/>|<br/>|<br/>|<br/>|<br/>|43647<br/>43419|
|**[Stashbox 2.5.9](https://github.com/z4kn4fein/stashbox)**|96<br/>109|53<br/>**73**|280<br/>219|**58**<br/>**69**|172580*<br/>101191*|824<br/>948|883<br/>656|
|**[StructureMap 4.6.1](http://structuremap.net/structuremap)**|9409<br/>5581|2543<br/>1599|9224<br/>5432|<br/>|3389333*<br/>1980624*|48834<br/>28827|8300<br/>4778|
|**[Unity 5.8.5](https://github.com/unitycontainer/unity)**|3106<br/>1853|1112<br/>670|4322<br/>2574|787<br/>495|**5336**<br/>**6000**|13799<br/>11275|<br/>|
|**[Windsor 4.1.0](http://castleproject.org)**|39708<br/>20526|15333<br/>8640|15709<br/>9482|<br/>|236090*<br/>136957*|<br/>|16538<br/>7592|
### Prepare
|**Container**|**Prepare And Register**|**Prepare And Register And Simple Resolve**|
|:------------|-----------------------:|------------------------------------------:|
|**No**|2<br/>|3<br/>|
|**[abioc 0.7.0](https://github.com/JSkimming/abioc)**|5672<br/>|6613<br/>|
|**[Autofac 4.7.0](https://github.com/autofac/Autofac)**|469<br/>|415<br/>|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|55<br/>|56<br/>|
|**[Catel 5.3.0](http://www.catelproject.com)**|8010<br/>|8411<br/>|
|**[DryIoc 3.0.0-preview-11](https://bitbucket.org/dadhi/dryioc)**|58<br/>|211<br/>|
|**[DryIocZero 4.0.0-preview-15](https://bitbucket.org/dadhi/dryioc)**|**0**<br/>|**1**<br/>|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|16240<br/>|16527<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|6390<br/>|6336<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|8<br/>|8<br/>|
|**[Grace 6.3.3](https://github.com/ipjohnson/Grace)**|174<br/>|836<br/>|
|**[Griffin 1.1.9](https://github.com/jgauffin/griffin.container)**|8387<br/>|8960<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|54925<br/>|55463<br/>|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|1397<br/>|2016<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|226<br/>|204<br/>|
|**[LightInject 5.1.2](https://github.com/seesharper/LightInject)**|167<br/>|747<br/>|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|107<br/>|338<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|172<br/>|747<br/>|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|17<br/>|2299<br/>|
|**[Mef2 1.0.32.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|5684<br/>|6729<br/>|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|27322<br/>|67518<br/>|
|**[MicroSliver 2.1.6](  )**|12<br/>|17<br/>|
|**[Microsoft Extensions DependencyInjection 2.0.0](https://github.com/aspnet/DependencyInjection)**|21<br/>|29<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|424<br/>|1820<br/>|
|**[Munq 3.1.6](http://munq.codeplex.com)**|9079<br/>|9500<br/>|
|**[Ninject 3.3.4](http://ninject.org)**|130706*<br/>|126470*<br/>|
|**[Rezolver 1.3.2](http://rezolver.co.uk)**|9756<br/>|14335<br/>|
|**[SimpleInjector 4.1.1](https://simpleinjector.org)**|681<br/>|3161<br/>|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|25014<br/>|24884<br/>|
|**[Stashbox 2.5.9](https://github.com/z4kn4fein/stashbox)**|78<br/>|409<br/>|
|**[StructureMap 4.6.1](http://structuremap.net/structuremap)**|1536<br/>|7909<br/>|
|**[Unity 5.8.5](https://github.com/unitycontainer/unity)**|63<br/>|64<br/>|
|**[Windsor 4.1.0](http://castleproject.org)**|3098<br/>|3090<br/>|
### Charts
![Basic features](http://www.palmmedia.de/content/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)
![Advanced features](http://www.palmmedia.de/content/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)
![Prepare](http://www.palmmedia.de/content/blogimages/67b056a5-9da8-40b4-9ae6-0c838cdac180.png)
### Machine
The benchmark was executed on the following machine:  
**CPU**: Intel(R) Core(TM) i5-6260U CPU @ 1.80GHz  
**Memory**: 15,89GB
