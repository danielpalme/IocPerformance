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
|**[Autofac 4.6.2](https://github.com/autofac/Autofac)**|766<br/>650|769<br/>558|1950<br/>1785|6685<br/>6442|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|465<br/>270|533<br/>322|1583<br/>906|7403<br/>3712|
|**[Catel 5.2.0](http://www.catelproject.com)**|299<br/>327|4165<br/>4575|9855<br/>10911|23025<br/>23582|
|**[DryIoc 2.12.5](https://bitbucket.org/dadhi/dryioc)**|30<br/>44|42<br/>64|55<br/>85|71<br/>79|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|95<br/>70|104<br/>86|207<br/>158|685<br/>381|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|66<br/>66|126<br/>99|249<br/>171|602<br/>350|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|118<br/>90|137<br/>110|381<br/>251|1124<br/>616|
|**[Grace 6.3.0](https://github.com/ipjohnson/Grace)**|27<br/>41|36<br/>63|51<br/>79|**64**<br/>78|
|**[Griffin 1.1.8](https://github.com/jgauffin/griffin.container)**|313<br/>202|318<br/>219|692<br/>461|2043<br/>1207|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|40<br/>48|51<br/>62|65<br/>88|103<br/>95|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|75<br/>60|128<br/>97|145<br/>124|197<br/>135|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|184<br/>189|2191<br/>1301|26718<br/>31570|151128*<br/>188142*|
|**[LightInject 5.1.1](https://github.com/seesharper/LightInject)**|30<br/>40|42<br/>57|52<br/>80|70<br/>76|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|3167<br/>1709|16506<br/>11878|45492<br/>29568|116514*<br/>76757*|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|356<br/>254|1755<br/>2906|2437<br/>1743|4342<br/>2528|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|22679<br/>11820|37640<br/>25052|57462<br/>68730*|112712*<br/>131716*|
|**[Mef2 1.0.32.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|309<br/>217|267<br/>174|363<br/>241|693<br/>411|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|**25**<br/>39|34<br/>59|55<br/>77|92<br/>89|
|**[MicroSliver 2.1.6](  )**|192<br/>232|742<br/>619|2394<br/>1786|7159<br/>6162|
|**[Microsoft Extensions DependencyInjection 2.0.0](https://github.com/aspnet/DependencyInjection)**|198<br/>223|112<br/>92|301<br/>319|1121<br/>1176|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|484<br/>444|711<br/>751|2285<br/>2494|8297<br/>9494|
|**[Munq 3.1.6](http://munq.codeplex.com)**|90<br/>75|161<br/>107|517<br/>417|1812<br/>1050|
|**[Ninject 3.3.3](http://ninject.org)**|2549<br/>1884|8353<br/>6262|24416<br/>16397|74364*<br/>54866|
|**[Rezolver 1.3.1](http://rezolver.co.uk)**|147<br/>111|175<br/>130|234<br/>183|391<br/>248|
|**[SimpleInjector 4.0.12](https://simpleinjector.org)**|64<br/>56|91<br/>74|96<br/>86|126<br/>101|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|950<br/>987|9711<br/>11447|26941<br/>23873|74745*<br/>57777|
|**[Stashbox 2.5.4](https://github.com/z4kn4fein/stashbox)**|35<br/>42|46<br/>58|57<br/>80|75<br/>78|
|**[StructureMap 4.5.2](http://structuremap.net/structuremap)**|1183<br/>656|1306<br/>800|3471<br/>2036|8933<br/>5270|
|**[Unity 5.1.2](https://github.com/unitycontainer/unity)**|4427<br/>2640|6139<br/>3481|16289<br/>9034|44622<br/>27933|
|**[Windsor 4.1.0](http://castleproject.org)**|459<br/>289|1772<br/>1050|6018<br/>3601|19319<br/>10972|
### Advanced Features
|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Asp Net Core**|**Interception With Proxy**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|---------------:|--------------------------:|
|**No**|119<br/>99|73<br/>79|177<br/>139|78<br/>69|606<br/>361|<br/>|72<br/>65|
|**[abioc 0.7.0](https://github.com/JSkimming/abioc)**|<br/>|<br/>|743<br/>453|<br/>|<br/>|<br/>|<br/>|
|**[Autofac 4.6.2](https://github.com/autofac/Autofac)**|6261<br/>6291|1953<br/>1493|7891<br/>6279|1719<br/>1686|56905<br/>35305|14203<br/>12404|23633<br/>12450|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|9157<br/>4733|<br/>|5965<br/>3393|<br/>|<br/>|<br/>|<br/>|
|**[Catel 5.2.0](http://www.catelproject.com)**|<br/>|10209<br/>10257|<br/>|<br/>|<br/>|<br/>|4231<br/>4578|
|**[DryIoc 2.12.5](https://bitbucket.org/dadhi/dryioc)**|88<br/>99|57<br/>71|295<br/>204|62<br/>70|<br/>|<br/>|834<br/>532|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|828<br/>455|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|1090<br/>639|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Grace 6.3.0](https://github.com/ipjohnson/Grace)**|83<br/>96|49<br/>**68**|269<br/>198|**54**<br/>**64**|48837<br/>29309|**511**<br/>**421**|906<br/>618|
|**[Griffin 1.1.8](https://github.com/jgauffin/griffin.container)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|741<br/>443|<br/>|1860<br/>1198|<br/>|<br/>|<br/>|**774**<br/>**509**|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|345<br/>227|147<br/>120|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|2289<br/>1755|15862<br/>14477|34754<br/>20480|<br/>|<br/>|<br/>|<br/>|
|**[LightInject 5.1.1](https://github.com/seesharper/LightInject)**|88<br/>97|**48**<br/>72|283<br/>**193**|340<br/>229|<br/>|2145<br/>1856|1435<br/>835|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|4502<br/>2616|2103<br/>2128|4443<br/>2483|2186<br/>1691|<br/>|<br/>|7591<br/>4418|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|124500*<br/>133833*|137086*<br/>114221*|97231*<br/>100896*|<br/>|<br/>|<br/>|<br/>|
|**[Mef2 1.0.32.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|1408<br/>819|309<br/>213|1425<br/>811|<br/>|<br/>|<br/>|<br/>|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|**39**<br/>**62**|<br/>|**262**<br/>195|<br/>|<br/>|<br/>|<br/>|
|**[MicroSliver 2.1.6](  )**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Microsoft Extensions DependencyInjection 2.0.0](https://github.com/aspnet/DependencyInjection)**|<br/>|125<br/>108|402<br/>265|<br/>|<br/>|1931<br/>1614|<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|10005<br/>8348|72189*<br/>72787*|5619<br/>7027|1824<br/>1883|550418*<br/>335171*|<br/>|13742<br/>16268|
|**[Munq 3.1.6](http://munq.codeplex.com)**|1536<br/>847|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Ninject 3.3.3](http://ninject.org)**|71857*<br/>55759|25813<br/>17761|67588*<br/>46001|20082<br/>13074|66700000*<br/>48883739*|<br/>|18698<br/>14858|
|**[Rezolver 1.3.1](http://rezolver.co.uk)**|530<br/>327|201<br/>165|9391<br/>4819|<br/>|7226777*<br/>3858842*|9039<br/>7341|<br/>|
|**[SimpleInjector 4.0.12](https://simpleinjector.org)**|178<br/>138|76<br/>77|778<br/>462|83<br/>81|<br/>|<br/>|7097<br/>4028|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|52419<br/>51992|<br/>|<br/>|<br/>|<br/>|<br/>|43647<br/>43419|
|**[Stashbox 2.5.4](https://github.com/z4kn4fein/stashbox)**|93<br/>95|57<br/>76|289<br/>203|63<br/>72|171702*<br/>98831*|654<br/>493|857<br/>552|
|**[StructureMap 4.5.2](http://structuremap.net/structuremap)**|8781<br/>5165|2605<br/>1520|9131<br/>4919|<br/>|3355666*<br/>1794884*|44899<br/>27751|7820<br/>4270|
|**[Unity 5.1.2](https://github.com/unitycontainer/unity)**|48079<br/>29277|<br/>|60639*<br/>33566|<br/>|**38218**<br/>**22824**|<br/>|103892*<br/>57456|
|**[Windsor 4.1.0](http://castleproject.org)**|39708<br/>20526|15333<br/>8640|15709<br/>9482|<br/>|236090*<br/>136957*|<br/>|16538<br/>7592|
### Prepare
|**Container**|**Prepare And Register**|**Prepare And Register And Simple Resolve**|
|:------------|-----------------------:|------------------------------------------:|
|**No**|2<br/>|3<br/>|
|**[abioc 0.7.0](https://github.com/JSkimming/abioc)**|5672<br/>|6613<br/>|
|**[Autofac 4.6.2](https://github.com/autofac/Autofac)**|287<br/>|304<br/>|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|55<br/>|56<br/>|
|**[Catel 5.2.0](http://www.catelproject.com)**|6956<br/>|7499<br/>|
|**[DryIoc 2.12.5](https://bitbucket.org/dadhi/dryioc)**|56<br/>|232<br/>|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|16240<br/>|16527<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|6390<br/>|6336<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|**8**<br/>|**8**<br/>|
|**[Grace 6.3.0](https://github.com/ipjohnson/Grace)**|153<br/>|869<br/>|
|**[Griffin 1.1.8](https://github.com/jgauffin/griffin.container)**|8600<br/>|8116<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|54925<br/>|55463<br/>|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|1397<br/>|2016<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|226<br/>|204<br/>|
|**[LightInject 5.1.1](https://github.com/seesharper/LightInject)**|131<br/>|661<br/>|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|107<br/>|338<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|172<br/>|747<br/>|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|17<br/>|2299<br/>|
|**[Mef2 1.0.32.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|5684<br/>|6729<br/>|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|27322<br/>|67518<br/>|
|**[MicroSliver 2.1.6](  )**|12<br/>|17<br/>|
|**[Microsoft Extensions DependencyInjection 2.0.0](https://github.com/aspnet/DependencyInjection)**|21<br/>|29<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|424<br/>|1820<br/>|
|**[Munq 3.1.6](http://munq.codeplex.com)**|9079<br/>|9500<br/>|
|**[Ninject 3.3.3](http://ninject.org)**|140334*<br/>|102774*<br/>|
|**[Rezolver 1.3.1](http://rezolver.co.uk)**|8024<br/>|12642<br/>|
|**[SimpleInjector 4.0.12](https://simpleinjector.org)**|618<br/>|3126<br/>|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|25014<br/>|24884<br/>|
|**[Stashbox 2.5.4](https://github.com/z4kn4fein/stashbox)**|71<br/>|522<br/>|
|**[StructureMap 4.5.2](http://structuremap.net/structuremap)**|1447<br/>|7360<br/>|
|**[Unity 5.1.2](https://github.com/unitycontainer/unity)**|100<br/>|1622<br/>|
|**[Windsor 4.1.0](http://castleproject.org)**|3098<br/>|3090<br/>|
### Charts
![Basic features](http://www.palmmedia.de/content/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)
![Advanced features](http://www.palmmedia.de/content/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)
![Prepare](http://www.palmmedia.de/content/blogimages/67b056a5-9da8-40b4-9ae6-0c838cdac180.png)
### Machine
The benchmark was executed on the following machine:  
**CPU**: Intel(R) Core(TM) i5-6260U CPU @ 1.80GHz  
**Memory**: 15,89GB
