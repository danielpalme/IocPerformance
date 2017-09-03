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
|**[abioc 0.6.0](https://github.com/JSkimming/abioc)**|27<br/>**37**|**31**<br/>**57**|**48**<br/>84|**63**<br/>**72**|
|**[Autofac 4.6.1](https://github.com/autofac/Autofac)**|781<br/>616|715<br/>556|1933<br/>1947|6248<br/>6452|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|465<br/>270|533<br/>322|1583<br/>906|7403<br/>3712|
|**[Catel 5.1.0](http://www.catelproject.com)**|325<br/>342|4252<br/>4634|9636<br/>10392|22053<br/>23370|
|**[DryIoc 2.12.0](https://bitbucket.org/dadhi/dryioc)**|30<br/>40|58<br/>69|63<br/>87|77<br/>91|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|95<br/>70|104<br/>86|207<br/>158|685<br/>381|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|66<br/>66|126<br/>99|249<br/>171|602<br/>350|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|118<br/>90|137<br/>110|381<br/>251|1124<br/>616|
|**[Grace 6.2.3](https://github.com/ipjohnson/Grace)**|**26**<br/>41|34<br/>60|49<br/>82|66<br/>73|
|**[Griffin 1.1.4](https://github.com/jgauffin/griffin.container)**|280<br/>182|304<br/>203|657<br/>431|1888<br/>1114|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|40<br/>48|51<br/>62|65<br/>88|103<br/>95|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|75<br/>60|128<br/>97|145<br/>124|197<br/>135|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|184<br/>189|2191<br/>1301|26718<br/>31570|151128*<br/>188142*|
|**[LightInject 5.1.0](https://github.com/seesharper/LightInject)**|27<br/>42|38<br/>59|51<br/>84|69<br/>76|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|3167<br/>1709|16506<br/>11878|45492<br/>29568|116514*<br/>76757*|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|356<br/>254|1755<br/>2906|2437<br/>1743|4342<br/>2528|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|22679<br/>11820|37640<br/>25052|57462<br/>68730*|112712*<br/>131716*|
|**[Mef2 1.0.32.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|309<br/>217|267<br/>174|363<br/>241|693<br/>411|
|**[MicroResolver 2.3.4](https://github.com/neuecc/MicroResolver)**|27<br/>44|36<br/>63|56<br/>**78**|97<br/>85|
|**[MicroSliver 2.1.6](https://microsliver.codeplex.com)**|192<br/>232|742<br/>619|2394<br/>1786|7159<br/>6162|
|**[Microsoft Extensions DependencyInjection 2.0.0](https://github.com/aspnet/DependencyInjection)**|198<br/>223|112<br/>92|301<br/>319|1121<br/>1176|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|484<br/>444|711<br/>751|2285<br/>2494|8297<br/>9494|
|**[Munq 3.1.6](http://munq.codeplex.com)**|90<br/>75|161<br/>107|517<br/>417|1812<br/>1050|
|**[Ninject 3.2.2](http://ninject.org)**|5192<br/>3216|16735<br/>11856|44930<br/>30318|131301*<br/>84559*|
|**[Rezolver 1.2.7050.900](http://rezolver.co.uk)**|135<br/>104|176<br/>135|227<br/>177|367<br/>238|
|**[SimpleInjector 4.0.8](https://simpleinjector.org)**|66<br/>68|77<br/>70|103<br/>103|129<br/>105|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|950<br/>987|9711<br/>11447|26941<br/>23873|74745*<br/>57777|
|**[Stashbox 2.5.4](https://github.com/z4kn4fein/stashbox)**|35<br/>42|46<br/>58|57<br/>80|75<br/>78|
|**[StructureMap 4.5.2](http://structuremap.net/structuremap)**|1183<br/>656|1306<br/>800|3471<br/>2036|8933<br/>5270|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|2517<br/>1375|3761<br/>1962|10161<br/>5372|27963<br/>16013|
|**[Windsor 4.0.0](http://castleproject.org)**|516<br/>405|1967<br/>1164|5812<br/>3392|17496<br/>9639|
### Advanced Features
|**Container**|**Property**|**Generics**|**IEnumerable**|**Conditional**|**Child Container**|**Asp Net Core**|**Interception With Proxy**|
|:------------|-----------:|-----------:|--------------:|--------------:|------------------:|---------------:|--------------------------:|
|**No**|119<br/>99|73<br/>79|177<br/>139|78<br/>69|606<br/>361|<br/>|72<br/>65|
|**[abioc 0.6.0](https://github.com/JSkimming/abioc)**|<br/>|<br/>|741<br/>506|<br/>|<br/>|<br/>|<br/>|
|**[Autofac 4.6.1](https://github.com/autofac/Autofac)**|6235<br/>6537|2006<br/>1794|7577<br/>5477|1365<br/>1413|53762<br/>31770|14338<br/>11871|22996<br/>12849|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|9157<br/>4733|<br/>|5965<br/>3393|<br/>|<br/>|<br/>|<br/>|
|**[Catel 5.1.0](http://www.catelproject.com)**|<br/>|9844<br/>10177|<br/>|<br/>|<br/>|<br/>|4313<br/>4553|
|**[DryIoc 2.12.0](https://bitbucket.org/dadhi/dryioc)**|100<br/>96|57<br/>**74**|360<br/>263|67<br/>66|<br/>|<br/>|865<br/>537|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|828<br/>455|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|1090<br/>639|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Grace 6.2.3](https://github.com/ipjohnson/Grace)**|105<br/>103|**47**<br/>77|**268**<br/>**192**|**55**<br/>**65**|49730<br/>27852|**474**<br/>**383**|819<br/>549|
|**[Griffin 1.1.4](https://github.com/jgauffin/griffin.container)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|741<br/>443|<br/>|1860<br/>1198|<br/>|<br/>|<br/>|**774**<br/>**509**|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|345<br/>227|147<br/>120|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|2289<br/>1755|15862<br/>14477|34754<br/>20480|<br/>|<br/>|<br/>|<br/>|
|**[LightInject 5.1.0](https://github.com/seesharper/LightInject)**|95<br/>97|49<br/>79|280<br/>196|337<br/>216|<br/>|2116<br/>1740|1567<br/>976|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|4502<br/>2616|2103<br/>2128|4443<br/>2483|2186<br/>1691|<br/>|<br/>|7591<br/>4418|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|124500*<br/>133833*|137086*<br/>114221*|97231*<br/>100896*|<br/>|<br/>|<br/>|<br/>|
|**[Mef2 1.0.32.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|1408<br/>819|309<br/>213|1425<br/>811|<br/>|<br/>|<br/>|<br/>|
|**[MicroResolver 2.3.4](https://github.com/neuecc/MicroResolver)**|**38**<br/>**64**|<br/>|281<br/>204|<br/>|<br/>|<br/>|<br/>|
|**[MicroSliver 2.1.6](https://microsliver.codeplex.com)**|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Microsoft Extensions DependencyInjection 2.0.0](https://github.com/aspnet/DependencyInjection)**|<br/>|125<br/>108|402<br/>265|<br/>|<br/>|1931<br/>1614|<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|10005<br/>8348|72189*<br/>72787*|5619<br/>7027|1824<br/>1883|550418*<br/>335171*|<br/>|13742<br/>16268|
|**[Munq 3.1.6](http://munq.codeplex.com)**|1536<br/>847|<br/>|<br/>|<br/>|<br/>|<br/>|<br/>|
|**[Ninject 3.2.2](http://ninject.org)**|112654*<br/>76631*|48775<br/>27198|102856*<br/>68908*|34283<br/>22799|46654500*<br/>41128767*|<br/>|24945<br/>15694|
|**[Rezolver 1.2.7050.900](http://rezolver.co.uk)**|500<br/>317|218<br/>161|588<br/>364|<br/>|3143050*<br/>1677185*|10298<br/>7844|<br/>|
|**[SimpleInjector 4.0.8](https://simpleinjector.org)**|212<br/>146|75<br/>82|795<br/>451|103<br/>86|<br/>|<br/>|7060<br/>4967|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|52419<br/>51992|<br/>|<br/>|<br/>|<br/>|<br/>|43647<br/>43419|
|**[Stashbox 2.5.4](https://github.com/z4kn4fein/stashbox)**|93<br/>95|57<br/>76|289<br/>203|63<br/>72|171702*<br/>98831*|654<br/>493|857<br/>552|
|**[StructureMap 4.5.2](http://structuremap.net/structuremap)**|8781<br/>5165|2605<br/>1520|9131<br/>4919|<br/>|3355666*<br/>1794884*|44899<br/>27751|7820<br/>4270|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|29064<br/>16150|<br/>|43685<br/>23347|<br/>|**33727**<br/>**19896**|<br/>|93122*<br/>49665|
|**[Windsor 4.0.0](http://castleproject.org)**|34788<br/>19114|14730<br/>8383|16344<br/>9298|<br/>|233653*<br/>127558*|<br/>|13738<br/>7473|
### Prepare
|**Container**|**Prepare And Register**|**Prepare And Register And Simple Resolve**|
|:------------|-----------------------:|------------------------------------------:|
|**No**|2<br/>|3<br/>|
|**[abioc 0.6.0](https://github.com/JSkimming/abioc)**|5739<br/>|5992<br/>|
|**[Autofac 4.6.1](https://github.com/autofac/Autofac)**|284<br/>|313<br/>|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|55<br/>|56<br/>|
|**[Catel 5.1.0](http://www.catelproject.com)**|9115<br/>|9925<br/>|
|**[DryIoc 2.12.0](https://bitbucket.org/dadhi/dryioc)**|79<br/>|251<br/>|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|16240<br/>|16527<br/>|
|**[fFastInjector 1.0.1](https://ffastinjector.codeplex.com)**|6390<br/>|6336<br/>|
|**[Funq 1.0.0.0](https://funq.codeplex.com)**|**8**<br/>|**8**<br/>|
|**[Grace 6.2.3](https://github.com/ipjohnson/Grace)**|143<br/>|808<br/>|
|**[Griffin 1.1.4](https://github.com/jgauffin/griffin.container)**|8442<br/>|7933<br/>|
|**[HaveBox 2.0.0](https://bitbucket.org/Have/havebox)**|54925<br/>|55463<br/>|
|**[IfInjector 0.8.1](https://github.com/iamahern/IfInjector)**|1397<br/>|2016<br/>|
|**[LightCore 1.5.1](http://www.lightcore.ch)**|226<br/>|204<br/>|
|**[LightInject 5.1.0](https://github.com/seesharper/LightInject)**|175<br/>|748<br/>|
|**[LinFu 2.3.0.41559](https://github.com/philiplaureano/LinFu)**|107<br/>|338<br/>|
|**[Maestro 1.5.4](https://github.com/JonasSamuelsson/Maestro)**|172<br/>|747<br/>|
|**[Mef 4.0.0.0](https://mef.codeplex.com)**|17<br/>|2299<br/>|
|**[Mef2 1.0.32.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|5684<br/>|6729<br/>|
|**[MicroResolver 2.3.4](https://github.com/neuecc/MicroResolver)**|27930<br/>|66854<br/>|
|**[MicroSliver 2.1.6](https://microsliver.codeplex.com)**|12<br/>|17<br/>|
|**[Microsoft Extensions DependencyInjection 2.0.0](https://github.com/aspnet/DependencyInjection)**|21<br/>|29<br/>|
|**[Mugen 3.5.1](http://mugeninjection.codeplex.com)**|424<br/>|1820<br/>|
|**[Munq 3.1.6](http://munq.codeplex.com)**|9079<br/>|9500<br/>|
|**[Ninject 3.2.2](http://ninject.org)**|97125*<br/>|86107*<br/>|
|**[Rezolver 1.2.7050.900](http://rezolver.co.uk)**|221<br/>|3286<br/>|
|**[SimpleInjector 4.0.8](https://simpleinjector.org)**|651<br/>|3339<br/>|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|25014<br/>|24884<br/>|
|**[Stashbox 2.5.4](https://github.com/z4kn4fein/stashbox)**|71<br/>|522<br/>|
|**[StructureMap 4.5.2](http://structuremap.net/structuremap)**|1447<br/>|7360<br/>|
|**[Unity 4.0.1](http://msdn.microsoft.com/unity)**|588<br/>|2209<br/>|
|**[Windsor 4.0.0](http://castleproject.org)**|2985<br/>|3137<br/>|
### Charts
![Basic features](http://www.palmmedia.de/content/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)
![Advanced features](http://www.palmmedia.de/content/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)
![Prepare](http://www.palmmedia.de/content/blogimages/67b056a5-9da8-40b4-9ae6-0c838cdac180.png)
### Machine
The benchmark was executed on the following machine:  
**CPU**: Intel(R) Core(TM) i5-6260U CPU @ 1.80GHz  
**Memory**: 15,89GB
