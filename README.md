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
|**[abioc 0.7.0](https://github.com/JSkimming/abioc)**|27<br/>**38**|**32**<br/>54|**48**<br/>**73**|**64**<br/>**71**|
|**[Autofac 4.8.1](https://github.com/autofac/Autofac)**|908<br/>914|804<br/>818|1917<br/>2140|6597<br/>7581|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|465<br/>270|533<br/>322|1583<br/>906|7403<br/>3712|
|**[Catel 5.5.0](http://www.catelproject.com)**|401<br/>496|5140<br/>5927|10930<br/>13791|25721<br/>32013|
|**[Cauldron.Activator 3.0.29](https://github.com/Capgemini/Cauldron)**|37<br/>48|43<br/>61|90<br/>106|184<br/>145|
|**[DryIoc 3.0.0](https://bitbucket.org/dadhi/dryioc)**|32<br/>46|43<br/>64|57<br/>88|67<br/>79|
|**[DryIocZero 4.0.0-preview-15](https://bitbucket.org/dadhi/dryioc)**|110<br/>99|90<br/>94|96<br/>110|219<br/>170|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|95<br/>70|104<br/>86|207<br/>158|685<br/>381|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|66<br/>66|126<br/>99|249<br/>171|602<br/>350|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|118<br/>90|137<br/>110|381<br/>251|1124<br/>616|
|**[Grace 6.4.0](https://github.com/ipjohnson/Grace)**|28<br/>43|41<br/>**53**|60<br/>75|73<br/>100|
|**[Griffin 1.1.9](https://github.com/jgauffin/griffin.container)**|300<br/>205|318<br/>226|719<br/>476|2004<br/>1228|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|40<br/>48|51<br/>62|65<br/>88|103<br/>95|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|75<br/>60|128<br/>97|145<br/>124|197<br/>135|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|184<br/>189|2191<br/>1301|26718<br/>31570|151128*<br/>188142*|
|**[LightInject 5.1.4](https://github.com/seesharper/LightInject)**|31<br/>44|36<br/>60|54<br/>81|66<br/>82|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|3167<br/>1709|16506<br/>11878|45492<br/>29568|116514*<br/>76757*|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|356<br/>254|1755<br/>2906|2437<br/>1743|4342<br/>2528|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|22679<br/>11820|37640<br/>25052|57462<br/>68730*|112712*<br/>131716*|
|**[Mef2 1.0.33.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|276<br/>260|341<br/>265|425<br/>374|901<br/>654|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|**25**<br/>39|34<br/>59|55<br/>77|92<br/>89|
|**[MicroSliver 2.1.6](  )**|192<br/>232|742<br/>619|2394<br/>1786|7159<br/>6162|
|**[Microsoft Extensions DependencyInjection 2.1.1](https://github.com/aspnet/DependencyInjection)**|81<br/>69|116<br/>106|152<br/>134|199<br/>152|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|484<br/>444|711<br/>751|2285<br/>2494|8297<br/>9494|
|**[Munq 3.1.6](http://munq.codeplex.com)**|90<br/>75|161<br/>107|517<br/>417|1812<br/>1050|
|**[MvvmCross 6.1.2](https://github.com/MvvmCross/MvvmCross)**|233<br/>285|962<br/>1011|2617<br/>2855|7756<br/>8181|
|**[Ninject 3.3.4](http://ninject.org)**|3473<br/>2563|8686<br/>6969|23529<br/>17635|63579*<br/>49285|
|**[Rezolver 1.3.3](http://rezolver.co.uk)**|170<br/>153|207<br/>186|255<br/>238|428<br/>390|
|**[SimpleInjector 4.3.0](https://simpleinjector.org)**|74<br/>77|100<br/>90|111<br/>109|119<br/>126|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|950<br/>987|9711<br/>11447|26941<br/>23873|74745*<br/>57777|
|**[Stashbox 2.6.0](https://github.com/z4kn4fein/stashbox)**|31<br/>45|45<br/>62|56<br/>89|74<br/>81|
|**[StructureMap 4.6.1](http://structuremap.net/structuremap)**|1169<br/>739|1367<br/>922|3741<br/>2261|9203<br/>5407|
|**[Unity 5.8.6](https://github.com/unitycontainer/unity)**|302<br/>281|437<br/>405|1282<br/>1095|3962<br/>3553|
|**[Windsor 4.1.0](http://castleproject.org)**|459<br/>289|1772<br/>1050|6018<br/>3601|19319<br/>10972|
### Advanced Features
|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Asp Net Core**|**Interception With Proxy**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|---------------:|--------------------------:|
|**No**|186<br/>134|70<br/>75|193<br/>176|53<br/>63|644<br/>596|<br/>|469<br/>438|
|**[abioc 0.7.0](https://github.com/JSkimming/abioc)**|<br/>|<br/>|743<br/>453|<br/>|<br/>|<br/>|<br/>|
|**[Autofac 4.8.1](https://github.com/autofac/Autofac)**|6299<br/>8246|1982<br/>2161|7889<br/>8397|1311<br/>1544|70219*<br/>55666|16308<br/>16321|23726<br/>16331|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|9157<br/>4733|<br/>|5965<br/>3393|<br/>|<br/>|<br/>|<br/>|
|**[Catel 5.5.0](http://www.catelproject.com)**|<br/>|10866<br/>13647|<br/>|<br/>|<br/>|<br/>|4954<br/>10575|
|**[Cauldron.Activator 3.0.29](https://github.com/Capgemini/Cauldron)**|51<br/>66|77<br/>84|325<br/>232|<br/>|<br/>|<br/>|**650**<br/>**434**|
|**[DryIoc 3.0.0](https://bitbucket.org/dadhi/dryioc)**|115<br/>117|56<br/>77|270<br/>200|50<br/>69|<br/>|1018<br/>664|826<br/>508|
|**[DryIocZero 4.0.0-preview-15](https://bitbucket.org/dadhi/dryioc)**|286<br/>200|87<br/>91|307<br/>281|403<br/>278|<br/>|<br/>|<br/>|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|828<br/>455|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|1090<br/>639|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Grace 6.4.0](https://github.com/ipjohnson/Grace)**|108<br/>126|**49**<br/>**67**|357<br/>360|68<br/>**67**|47907<br/>30596|**522**<br/>**417**|854<br/>572|
|**[Griffin 1.1.9](https://github.com/jgauffin/griffin.container)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|741<br/>443|<br/>|1860<br/>1198|<br/>|<br/>|<br/>|774<br/>509|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|345<br/>227|147<br/>120|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|2289<br/>1755|15862<br/>14477|34754<br/>20480|<br/>|<br/>|<br/>|<br/>|
|**[LightInject 5.1.4](https://github.com/seesharper/LightInject)**|110<br/>110|51<br/>81|**257**<br/>199|308<br/>215|<br/>|2355<br/>1794|1347<br/>795|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|4502<br/>2616|2103<br/>2128|4443<br/>2483|2186<br/>1691|<br/>|<br/>|7591<br/>4418|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|124500*<br/>133833*|137086*<br/>114221*|97231*<br/>100896*|<br/>|<br/>|<br/>|<br/>|
|**[Mef2 1.0.33.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|1525<br/>1272|310<br/>299|1554<br/>1273|<br/>|<br/>|<br/>|<br/>|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|**39**<br/>**62**|<br/>|262<br/>**195**|<br/>|<br/>|<br/>|<br/>|
|**[MicroSliver 2.1.6](  )**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Microsoft Extensions DependencyInjection 2.1.1](https://github.com/aspnet/DependencyInjection)**|<br/>|141<br/>135|411<br/>291|<br/>|<br/>|1004<br/>676|<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|10005<br/>8348|72189*<br/>72787*|5619<br/>7027|1824<br/>1883|550418*<br/>335171*|<br/>|13742<br/>16268|
|**[Munq 3.1.6](http://munq.codeplex.com)**|1536<br/>847|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[MvvmCross 6.1.2](https://github.com/MvvmCross/MvvmCross)**|948<br/>1034|6458<br/>7098|<br/>|<br/>|**4175**<br/>**2825**|<br/>|<br/>|
|**[Ninject 3.3.4](http://ninject.org)**|62765*<br/>47908|24256<br/>15895|64193*<br/>49074|19294<br/>12954|73303000*<br/>50234113*|<br/>|20215<br/>15029|
|**[Rezolver 1.3.3](http://rezolver.co.uk)**|553<br/>482|233<br/>228|10897<br/>8336|<br/>|9544000*<br/>6972002*|10816<br/>9875|<br/>|
|**[SimpleInjector 4.3.0](https://simpleinjector.org)**|191<br/>207|96<br/>118|905<br/>776|87<br/>88|<br/>|<br/>|7841<br/>6132|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|52419<br/>51992|<br/>|<br/>|<br/>|<br/>|<br/>|43647<br/>43419|
|**[Stashbox 2.6.0](https://github.com/z4kn4fein/stashbox)**|109<br/>115|54<br/>68|276<br/>211|**47**<br/>**67**|284231*<br/>205433*|760<br/>887|859<br/>557|
|**[StructureMap 4.6.1](http://structuremap.net/structuremap)**|9409<br/>5581|2543<br/>1599|9224<br/>5432|<br/>|3389333*<br/>1980624*|48834<br/>28827|8300<br/>4778|
|**[Unity 5.8.6](https://github.com/unitycontainer/unity)**|4097<br/>3333|1396<br/>1210|4815<br/>4031|1042<br/>861|7035<br/>9942|16895<br/>18546|<br/>|
|**[Windsor 4.1.0](http://castleproject.org)**|39708<br/>20526|15333<br/>8640|15709<br/>9482|<br/>|236090*<br/>136957*|<br/>|16538<br/>7592|
### Prepare
|**Container**|**Prepare And Register**|**Prepare And Register And Simple Resolve**|
|:------------|-----------------------:|------------------------------------------:|
|**No**|2<br/>|2<br/>|
|**[abioc 0.7.0](https://github.com/JSkimming/abioc)**|5672<br/>|6613<br/>|
|**[Autofac 4.8.1](https://github.com/autofac/Autofac)**|421<br/>|445<br/>|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|55<br/>|56<br/>|
|**[Catel 5.5.0](http://www.catelproject.com)**|9507<br/>|10047<br/>|
|**[Cauldron.Activator 3.0.29](https://github.com/Capgemini/Cauldron)**|**0**<br/>|**0**<br/>|
|**[DryIoc 3.0.0](https://bitbucket.org/dadhi/dryioc)**|59<br/>|222<br/>|
|**[DryIocZero 4.0.0-preview-15](https://bitbucket.org/dadhi/dryioc)**|**0**<br/>|1<br/>|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|16240<br/>|16527<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|6390<br/>|6336<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|8<br/>|8<br/>|
|**[Grace 6.4.0](https://github.com/ipjohnson/Grace)**|145<br/>|809<br/>|
|**[Griffin 1.1.9](https://github.com/jgauffin/griffin.container)**|8387<br/>|8960<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|54925<br/>|55463<br/>|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|1397<br/>|2016<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|226<br/>|204<br/>|
|**[LightInject 5.1.4](https://github.com/seesharper/LightInject)**|104<br/>|626<br/>|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|107<br/>|338<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|172<br/>|747<br/>|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|17<br/>|2299<br/>|
|**[Mef2 1.0.33.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|6053<br/>|7259<br/>|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|27322<br/>|67518<br/>|
|**[MicroSliver 2.1.6](  )**|12<br/>|17<br/>|
|**[Microsoft Extensions DependencyInjection 2.1.1](https://github.com/aspnet/DependencyInjection)**|22<br/>|28<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|424<br/>|1820<br/>|
|**[Munq 3.1.6](http://munq.codeplex.com)**|9079<br/>|9500<br/>|
|**[MvvmCross 6.1.2](https://github.com/MvvmCross/MvvmCross)**|15<br/>|13<br/>|
|**[Ninject 3.3.4](http://ninject.org)**|130706*<br/>|126470*<br/>|
|**[Rezolver 1.3.3](http://rezolver.co.uk)**|13353<br/>|19672<br/>|
|**[SimpleInjector 4.3.0](https://simpleinjector.org)**|771<br/>|3503<br/>|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|25014<br/>|24884<br/>|
|**[Stashbox 2.6.0](https://github.com/z4kn4fein/stashbox)**|73<br/>|463<br/>|
|**[StructureMap 4.6.1](http://structuremap.net/structuremap)**|1536<br/>|7909<br/>|
|**[Unity 5.8.6](https://github.com/unitycontainer/unity)**|84<br/>|79<br/>|
|**[Windsor 4.1.0](http://castleproject.org)**|3098<br/>|3090<br/>|
### Charts
![Basic features](http://www.palmmedia.de/content/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)
![Advanced features](http://www.palmmedia.de/content/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)
![Prepare](http://www.palmmedia.de/content/blogimages/67b056a5-9da8-40b4-9ae6-0c838cdac180.png)
### Machine
The benchmark was executed on the following machine:  
**CPU**: Intel(R) Core(TM) i5-6260U CPU @ 1.80GHz  
**Memory**: 15,89GB
